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
    [SerializeField]private PainelDeCriature principal;
    //[SerializeField]private DadosDoPainelPrincipal principal;
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
        CriatureBase[] ativos = GameController.g.Manager.Dados.CriaturesAtivos.ToArray();

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
        principal.InserirDadosNoPainelPrincipal(C);
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
               +principal.transform.GetComponent<LayoutElement>().preferredHeight
               );
    }

    void AbaSelecionada(int indice)
    {
        for (int i = 0; i < 7; i++)
        {
            btnAbas[i].sprite = deselecionado;
        }

        sRect.verticalScrollbar.value = 1;
        GameController.g.StartCoroutine(ScrollPos());
        
        btnAbas[indice].sprite = selecionado;
        indiceDoSelecionado = indice;
    }

    IEnumerator ScrollPos()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        if (sRect != null)
            if (sRect.verticalScrollbar)
                sRect.verticalScrollbar.value = 1;

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
        InserirDadosNoPainelPrincipal(GameController.g.Manager.Dados.CriaturesAtivos[indice]);
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
