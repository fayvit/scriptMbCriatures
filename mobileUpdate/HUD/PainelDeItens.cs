using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PainelDeItens : MonoBehaviour
{
    [SerializeField]private Text infos;
    [SerializeField]private MenuDeImagens insereI;
    [SerializeField]private Button voltar;
    [SerializeField]private Button usar;
    [SerializeField]private Text txtBtnOrganizar;
    [SerializeField]private Sprite deselecionado;
    [SerializeField]private Sprite selecionado;

    private MbItens[] meusItens;
    private int oSelecionado = -1;
    private bool modoOrganizar = false;

    private System.Action acao;
    private System.Action voltarEspecifico;

    public void Ativar(System.Action a,System.Action v = null)
    {
        gameObject.SetActive(true);
        acao += a;
        voltarEspecifico = v;
    }

    void OnEnable()
    {
        SetarMenuDeIetns();
        oSelecionado = -1;
    }

    void OnDisable()
    {        
        insereI.FinalizarHud();        
    }

    void SetarMenuDeIetns()
    {
        meusItens = GameController.g.Manager.Dados.Itens.ToArray();
        insereI.IniciarHud(GameController.g.Manager.Dados,
            TipoDeDado.item, meusItens.Length, AoClique, 0, TipoDeRedimensionamento.emGrade
            );
    }

    void AoClique(int i)
    {
        if (!modoOrganizar)
        {
            infos.text = bancoDeTextos.falacoes[heroi.lingua]["shopInfoItem"][(int)(meusItens[i].ID)];
            MudaSpriteDoItem(i);
        }
        else
        {
            if (oSelecionado >= 0)
            {
                
                insereI.FinalizarHud();
                TrocarDePosicao(oSelecionado, i);
                infos.text = bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.selecioneParaOrganizar);

                gameObject.SetActive(true);
                    
            }
            else
            {                
                MudaSpriteDoItem(i);
                infos.text = string.Format(
                                bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.selecioneParaOrganizar)[1],
                                item.nomeEmLinguas(meusItens[oSelecionado].ID));
            }
        }
    }

    void MudaSpriteDoItem(int j)
    {
        DadoDaHudRapida[] d = GetComponentsInChildren<DadoDaHudRapida>();
        for (int i = 0; i < d.Length; i++)
        {
            d[i].DaSelecao.sprite = deselecionado;
        }

        oSelecionado = j;
        if (j > -1)           
            d[j].DaSelecao.sprite = selecionado;       

    }

    void TrocarDePosicao(int a, int b)
    {
        MbItens temp = (MbItens)meusItens[a].Clone();
        meusItens[a] = (MbItens)meusItens[b].Clone();
        meusItens[b] = temp;

        GameController.g.Manager.Dados.Itens = new System.Collections.Generic.List<MbItens>();
        GameController.g.Manager.Dados.Itens.AddRange(meusItens);
    }

    public void AtualizaHudDeItens()
    {
        OnDisable();
        gameObject.SetActive(true);
    }

    public void BtnUsarItem()
    {
        if (!GameController.g.estaEmLuta)
        {
            if (GameController.g.EmEstadoDeAcao() && oSelecionado > -1)
            {
                BtnsManager.DesligarBotoes(gameObject);
                GameController.g.FuncaoDoUseiItem(oSelecionado, FluxoDeRetorno.menuHeroi);
            }
            else if (oSelecionado <= -1)
            {
                PainelMensCriature.p.AtivarNovaMens(bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.naoPodeEssaAcao)[2], 30);
                StartCoroutine(PauseMenu.VoltaTextoPause());
            }
            else
            {
                PainelMensCriature.p.AtivarNovaMens(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.naoPodeEssaAcao), 30);
                StartCoroutine(PauseMenu.VoltaTextoPause());
            }
        }
        else
        {
            BtnsManager.DesligarBotoes(gameObject);
            GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(()=> {
                //int guarda = oSelecionado;
                insereI.FinalizarHud();
                gameObject.SetActive(true);
                
                BtnsManager.ReligarBotoes(gameObject);
            }, bancoDeTextos.falacoes[heroi.lingua]["itens"][11]);
        }
    }

    public void BtnVoltar()
    {
        if (voltarEspecifico != null)
            voltarEspecifico();

        voltarEspecifico = null;

        gameObject.SetActive(false);
        acao();
        acao = null;
        SairDoModoOrganizar();
        infos.text = "Toque sobre um item para seleciona-lo";
    }

    public void BtnOrganizar()
    {
        if (!modoOrganizar)
        {
            if (oSelecionado < 0)
            {
                infos.text = bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.selecioneParaOrganizar);
            }
            else
            {
                infos.text = string.Format(
                    bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.selecioneParaOrganizar)[1],
                    item.nomeEmLinguas(meusItens[oSelecionado].ID));
            }
            EntrarNoModoOrganizar();
        }
        else
        {
            SairDoModoOrganizar();
            if (oSelecionado > -1)
            {
                infos.text = bancoDeTextos.falacoes[heroi.lingua]["shopInfoItem"][(int)(meusItens[oSelecionado].ID)];
            }
            else
                infos.text = "Toque sobre um item para seleciona-lo";
        }
    }

    void EntrarNoModoOrganizar()
    {
        modoOrganizar = true;
        txtBtnOrganizar.text = "Sair do Modo Organizar";
        txtBtnOrganizar.fontSize = 18;
        voltar.interactable = false;
        usar.interactable = false;
    }

    void SairDoModoOrganizar()
    {
        modoOrganizar = false;
        txtBtnOrganizar.text = "Organizar";
        txtBtnOrganizar.fontSize = 24;
        voltar.interactable = true;
        usar.interactable = true;
    }
}
