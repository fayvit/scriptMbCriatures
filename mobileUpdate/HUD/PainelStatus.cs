using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PainelStatus : MonoBehaviour
{
    [SerializeField]private RawImage[] abas;
    [SerializeField]private Image[] btnAbas;
    [SerializeField]private PainelDeGolpe[] pGolpe;
    [SerializeField]private Sprite selecionado;
    [SerializeField]private Sprite deselecionado;
    [SerializeField]private DadosDoPainelPrincipal principal;
    [SerializeField]private RectTransform containerDeTamanhoVariavel;
    [SerializeField]private ScrollRect sRect;

    private int indiceDoSelecionado = 0;
    private System.Action<int> acaoDeUsoDeItem;

    [System.Serializable]
    public class DadosDoPainelPrincipal
    {
        public RawImage imgDoPersonagem;
        public Text numPV;
        public Text numPE;
        public Text numAtk;
        public Text numDef;
        public Text numPod;
        public Text numXp;
        public Text txtMeusTipos;
        public Text txtNomeC;
        public Text numNivel;
    }

    void OnEnable()
    {
        CriatureBase[] ativos = GameController.g.Manager.Dados.criaturesAtivos.ToArray();

        for (int i = 0; i < abas.Length; i++)
        {
            if (i < ativos.Length)
            {
                abas[i].texture = elementosDoJogo.el.RetornaMini(ativos[i].NomeID);
                btnAbas[i].sprite = deselecionado;
            }
            else
            {
                abas[i].transform.parent.gameObject.SetActive(false);
            }
        }

        btnAbas[0].sprite = selecionado;
        indiceDoSelecionado = 0;

        InserirDadosNoPainelPrincipal(ativos[0]);
    }

    void InserirDadosNoPainelPrincipal(CriatureBase C)
    {
        Atributos A = C.CaracCriature.meusAtributos;
        IGerenciadorDeExperiencia g_XP = C.CaracCriature.mNivel;

        principal.imgDoPersonagem.texture = elementosDoJogo.el.RetornaMini(C.NomeID);
        principal.txtNomeC.text = C.NomeEmLinguas;
        principal.numNivel.text = g_XP.Nivel.ToString();
        principal.numPV.text = A.PV.Corrente + "\t/\t" + A.PV.Maximo;
        principal.numPE.text = A.PE.Corrente + "\t/\t" + A.PE.Maximo;
        principal.numXp.text = g_XP.XP + "\t/\t" + g_XP.ParaProxNivel;
        principal.numAtk.text = A.Ataque.Corrente.ToString();
        principal.numDef.text = A.Defesa.Corrente.ToString();
        principal.numPod.text = A.Poder.Corrente.ToString();
        string paraTipos = "";

        for (int i = 0; i < C.CaracCriature.meusTipos.Length; i++)
        {
            paraTipos += tipos.NomeEmLinguas(C.CaracCriature.meusTipos[i])+", ";
        }

        principal.txtMeusTipos.text = paraTipos.Substring(0, paraTipos.Length - 2);

        InsereGolpes(C.GerenteDeGolpes.meusGolpes.ToArray());

    }

    void InsereGolpes(GolpeBase[] golpes)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i < golpes.Length)
            {
                pGolpe[i].Aciona(golpes[i]);
            }
            else
                pGolpe[i].gameObject.SetActive(false);
        }

        CalculaTamanhoDoContainer(golpes.Length);
    }

    void CalculaTamanhoDoContainer(int numGOlpes)
    {
        containerDeTamanhoVariavel.sizeDelta
               = new Vector2(0, numGOlpes * pGolpe[0].GetComponent<LayoutElement>().preferredHeight
               +principal.numPV.transform.parent.GetComponent<LayoutElement>().preferredHeight
               );
    }

    void AbaSelecionada(int indice)
    {
        for (int i = 0; i < 7; i++)
        {
            btnAbas[i].sprite = deselecionado;
        }

        sRect.verticalScrollbar.value = 1;
        btnAbas[indice].sprite = selecionado;
        indiceDoSelecionado = indice;
    }

    public void AtivarParaItem(System.Action<int> a)
    {
        gameObject.SetActive(true);
        acaoDeUsoDeItem += a;
    }
    public void DesativarParaItem()
    {
        acaoDeUsoDeItem = null;
        gameObject.SetActive(false);
        GameController.g.HudM.PauseM.ReligarBotoesDoPainelDeItens();
    }

    public void DesligarMeusBotoes()
    {
        BtnsManager.DesligarBotoes(gameObject);
    }

    public void ReligarMeusBotoes()
    {
        BtnsManager.ReligarBotoes(gameObject);
    }

    public void BtnMeuOutro(int indice)
    {
        InserirDadosNoPainelPrincipal(GameController.g.Manager.Dados.criaturesAtivos[indice]);
        AbaSelecionada(indice);
    }

    public void BtnVoltar()
    {
        gameObject.SetActive(false);
    }

    public void BtnSubstituir()
    {
        if (GameController.g.EmEstadoDeAcao() && indiceDoSelecionado != 0)
        {
            sRect.verticalScrollbar.value = 1;
            FindObjectOfType<PauseMenu>().VoltarAoJogo();
            BtnVoltar();
            GameController.g.FuncaoTrocarCriature(indiceDoSelecionado, 
                (GameController.g.Manager.Estado==EstadoDePersonagem.comMeuCriature)?
                FluxoDeRetorno.menuCriature:FluxoDeRetorno.menuHeroi,true
                );
        }
        else if (indiceDoSelecionado != 0)
        {
            PainelMensCriature.p.AtivarNovaMens(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.naoPodeEssaAcao), 30);
            StartCoroutine(PauseMenu.VoltaTextoPause());
        }
        else if (indiceDoSelecionado == 0)
        {
            PainelMensCriature.p.AtivarNovaMens(
                string.Format(
                    bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.naoPodeEssaAcao)[1],
                    GameController.g.Manager.CriatureAtivo.MeuCriatureBase.NomeEmLinguas)
                    , 30);
            StartCoroutine(PauseMenu.VoltaTextoPause());
        }        
    }

    public void VoltarDosItens()
    {
        DesativarParaItem();
    }

    public void UsarNeste()
    {        
        acaoDeUsoDeItem(indiceDoSelecionado);        
    }
}
