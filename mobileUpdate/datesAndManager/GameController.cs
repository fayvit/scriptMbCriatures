using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController g;
    private CharacterManager manager;
    private MbUsoDeItem usoDeItens;
    private ReplaceManager replace;

    [SerializeField]private MbEncontros encontros;
    [SerializeField]private HudManager hudM;

    public bool estaEmLuta
    {
        get { return encontros.Luta; }
    }

    public HudManager HudM
    {
        get { return hudM; }
    }

    public CreatureManager InimigoAtivo
    {
        get { return encontros.InimigoAtivo; }
    }

    public CharacterManager Manager
    {
        get {
            VerificaSetarManager();
            return manager;
        }
    }

    // Use this for initialization
    void Start()
    {
        g = this;
        usoDeItens = new MbUsoDeItem();
        VerificaSetarManager();
        encontros.Start();
    }

    // Update is called once per frame
    void Update()
    {
        usoDeItens.Update();
        encontros.Update();
        HudM.MenuDeI.Update();

        if (replace != null)
            if (replace.Update())
            {
                if (replace.Fluxo == FluxoDeRetorno.criature)
                {
                    if (estaEmLuta)
                        encontros.InimigoAtivo.Estado = CreatureManager.CreatureState.selvagem;

                    manager.AoCriature(encontros.InimigoAtivo);
                    GameController.g.HudM.AtualizaHudHeroi(manager.CriatureAtivo.MeuCriatureBase);
                    replace = null;
                }
            }
    }

    void VerificaSetarManager()
    {
        if(manager==null)
            manager = FindObjectOfType<CharacterManager>();
    }

    public void BotaoPulo()
    {
        Manager.IniciaPulo(); 
    }

    public void BotaoAlternar()
    {
        Manager.BotaoAlternar();
    }

    public void BotaoAtaque()
    {
        Manager.BotaoAtacar();
    }

    bool PodeAbrirMenuDeImagem(TipoDeDado tipo)
    {
        
        if (HudM.MenuDeI.Aberto)
        {
            hudM.MenuDeI.FinalizarHud();
            if (hudM.MenuDeI.Tipo == tipo)
                return false;
        }

        if (usoDeItens.EstouUsandoItem)
            return false;

        if (replace != null)
            return !replace.EstouTrocandoDeCriature;

        return true;
    }

    public void BotaoMaisAtaques()
    {
        if (PodeAbrirMenuDeImagem(TipoDeDado.golpe))
        {
            VerificaSetarManager();
            hudM.MenuDeI.IniciarHud(manager.Dados, TipoDeDado.golpe, manager.Dados.criaturesAtivos[0].GerenteDeGolpes.meusGolpes.Count,
                (int i) =>
                {
                    manager.Dados.criaturesAtivos[0].GerenteDeGolpes.golpeEscolhido = i;
                    hudM.MenuDeI.FinalizarHud();
                },5
                );
        }
    }

    public void BotaItens()
    {
        if (PodeAbrirMenuDeImagem(TipoDeDado.item))
        {
            VerificaSetarManager();
            hudM.MenuDeI.IniciarHud(manager.Dados, TipoDeDado.item, manager.Dados.itens.Count,FuncaoDoUseiItem, 15);
        }
    }

    public void BotaoMaisCriature()
    {
        if (PodeAbrirMenuDeImagem(TipoDeDado.criature))
        {
            VerificaSetarManager();
            hudM.MenuDeI.IniciarHud(manager.Dados, TipoDeDado.criature, manager.Dados.criaturesAtivos.Count - 1,FuncaoTrocarCriature, 5);
        }
    }

    void FuncaoTrocarCriature(int indice)
    {
        if (estaEmLuta)
        {
            encontros.InimigoAtivo.Estado = CreatureManager.CreatureState.parado;
            //encontros.InimigoAtivo.Mov.Animador.PararAnimacao();
        }

        manager.Dados.criatureSai = indice+1;
        hudM.MenuDeI.FinalizarHud();
        PainelMensCriature.p.EsconderMensagem();
        FluxoDeRetorno fluxo = manager.Estado == EstadoDePersonagem.comMeuCriature?FluxoDeRetorno.criature:FluxoDeRetorno.heroi;
        replace = new ReplaceManager(manager, manager.CriatureAtivo.transform, fluxo);
        manager.Estado = EstadoDePersonagem.parado;

    }

    void FuncaoDoUseiItem(int indice)
    {
        if (!usoDeItens.EstouUsandoItem)
        {
            hudM.MenuDeI.FinalizarHud();

            usoDeItens.Start(manager,
                manager.Estado == EstadoDePersonagem.comMeuCriature
                ? FluxoDeRetorno.criature
                : FluxoDeRetorno.heroi);

            manager.Estado = EstadoDePersonagem.parado;
        }
    }

    #region botões de teste
    public void EncontroAgora()
    {
        encontros.ZerarPassosParaProxEncontro();
    }

    public void InimigoComUmPV()
    {
        encontros.ColocarUmPvNoInimigo();
    }

    public void MeuCriatureComUmPV()
    {
        Manager.Dados.criaturesAtivos[0].CaracCriature.meusAtributos.PV.Corrente = 1;
        hudM.AtualizaHudHeroi(manager.Dados.criaturesAtivos[0]);
    }
    public void MeuCriatureComUZeroPE()
    {
        Manager.Dados.criaturesAtivos[0].CaracCriature.meusAtributos.PE.Corrente = 0;
        hudM.AtualizaHudHeroi(manager.Dados.criaturesAtivos[0]);
    }

    public void UmXpParaNivel()
    {
        IGerenciadorDeExperiencia gXP = Manager.Dados.criaturesAtivos[0].CaracCriature.mNivel;
        gXP.XP = gXP.ParaProxNivel - 1;
    }
    #endregion
}
