using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController g;
    private CharacterManager manager;
    private MbUsoDeItem usoDeItens;
    private ReplaceManager replace;
    private KeyVar myKeys = new KeyVar();
    private SaveManager salvador = new SaveManager();

    [SerializeField]private MbEncontros encontros;
    [SerializeField]private HudManager hudM;

    public bool UsandoItemOuTrocandoCriature
    {
        get { return 
                (usoDeItens == null ? false : usoDeItens.EstouUsandoItem) 
                || 
                (replace == null ? false : replace.EstouTrocandoDeCriature);
        }
    }
    public bool estaEmLuta
    {
        get { return encontros.Luta; }
    }

    public SaveManager Salvador
    {
        get { return salvador; }
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

    public KeyVar MyKeys
    {
        get { return myKeys; }
        set { myKeys = value; }
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
        hudM.Shop_Manager.Update();

        if (manager.Estado == EstadoDePersonagem.aPasseio)
            salvador.Update();

        if (replace != null)
            if (replace.Update())
            {
                RetornoDeReplace();
            }
    }

    void RetornoDeReplace()
    {

        if (replace.Fluxo == FluxoDeRetorno.criature || replace.Fluxo == FluxoDeRetorno.menuCriature)
        {
            if (estaEmLuta)
                encontros.InimigoAtivo.Estado = CreatureManager.CreatureState.selvagem;

            manager.AoCriature(encontros.InimigoAtivo);

        }

        if (replace.Fluxo == FluxoDeRetorno.menuCriature || replace.Fluxo == FluxoDeRetorno.menuHeroi)
        {
            hudM.PauseM.PausarJogo();
            hudM.PauseM.BotaoCriature();
        }

        replace = null;
        HudM.AtualizaHudHeroi(manager.CriatureAtivo.MeuCriatureBase);
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
        HudM.MenuDeI.FinalizarHud();
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
            hudM.MenuDeI.IniciarHud(manager.Dados, TipoDeDado.golpe, manager.Dados.CriaturesAtivos[0].GerenteDeGolpes.meusGolpes.Count,
                (int i) =>
                {
                    manager.Dados.CriaturesAtivos[0].GerenteDeGolpes.golpeEscolhido = i;
                    hudM.MenuDeI.FinalizarHud();
                    hudM.Btns.ImagemDoAtaque(manager);
                },5
                );
            
        }
    }

    public void RetornarParaFluxoDoHeroi()
    {
        encontros.FinalizaEncontro();
        usoDeItens.FinalizaUsaItemDeFora();
    }

    public void BotaItens()
    {
        if (PodeAbrirMenuDeImagem(TipoDeDado.item))
        {
            VerificaSetarManager();
            hudM.MenuDeI.IniciarHud(manager.Dados, TipoDeDado.item, manager.Dados.Itens.Count,FuncaoDoUseiItem, 15);
        }
    }

    public void BotaoMaisCriature()
    {
        if (PodeAbrirMenuDeImagem(TipoDeDado.criature))
        {
            VerificaSetarManager();
            hudM.MenuDeI.IniciarHud(
                manager.Dados, 
                TipoDeDado.criature, 
                manager.Dados.CriaturesAtivos.Count - 1,
                FuncaoTrocarCriatureSemMenu, 5);
        }
    }

    public bool EmEstadoDeAcao(bool chao = false)
    {
        bool foi = false;
        EstadoDePersonagem estadoP = Manager.Estado;
        CreatureManager.CreatureState estadoC = manager.CriatureAtivo.Estado;


        if (estadoP == EstadoDePersonagem.comMeuCriature && !chao)
            chao = Manager.CriatureAtivo.Mov.NoChao(Manager.CriatureAtivo.MeuCriatureBase.CaracCriature.distanciaFundamentadora);
        else if (estadoP == EstadoDePersonagem.aPasseio && !chao)
            chao = Manager.Mov.NoChao(0.01f);

        if (estadoP == EstadoDePersonagem.comMeuCriature && 
            chao &&
            (estadoC == CreatureManager.CreatureState.emLuta 
            || estadoC == CreatureManager.CreatureState.aPasseio)
            )
            foi = true;
        else if (estadoP == EstadoDePersonagem.aPasseio&& chao)
            foi = true;

        return foi;
    }

    void FuncaoTrocarCriatureSemMenu(int indice)
    {
        if (Manager.Dados.CriaturesAtivos[indice + 1].CaracCriature.meusAtributos.PV.Corrente > 0)
        {
            FluxoDeRetorno fluxo = manager.Estado == EstadoDePersonagem.comMeuCriature ? FluxoDeRetorno.criature : FluxoDeRetorno.heroi;
            FuncaoTrocarCriature(indice + 1, fluxo);
        }
        else
        {
            PainelMensCriature.p.AtivarNovaMens(string.Format(
                bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.criatureParaMostrador)[1],
                Manager.Dados.CriaturesAtivos[indice + 1].NomeEmLinguas
                ),30,5);
            HudM.MenuDeI.FinalizarHud();
        }
    }

    public void FuncaoTrocarCriature(int indice, FluxoDeRetorno fluxo, bool bugDoTesteChao = false)
    {
        if (EmEstadoDeAcao(bugDoTesteChao))
        {
            if (estaEmLuta)
            {
                encontros.InimigoAtivo.PararCriatureNoLocal();
            }

            manager.Dados.CriatureSai = indice;
            
            replace = new ReplaceManager(manager, manager.CriatureAtivo.transform, fluxo);
        }

    }

    public void FuncaoDoUseiItem(int indice, FluxoDeRetorno fluxo)
    {
        if (EmEstadoDeAcao())
        {
            if (!usoDeItens.EstouUsandoItem)
            {
                manager.Dados.itemSai = indice;

                hudM.MenuDeI.FinalizarHud();

                usoDeItens.Start(manager,fluxo);

                if(fluxo!=FluxoDeRetorno.menuCriature && fluxo!=FluxoDeRetorno.menuHeroi)
                    manager.Estado = EstadoDePersonagem.parado;

            }
        }
    }

    void FuncaoDoUseiItem(int indice)
    {
        FluxoDeRetorno fluxo = manager.Estado == EstadoDePersonagem.comMeuCriature
                    ? FluxoDeRetorno.criature
                    : FluxoDeRetorno.heroi;

        FuncaoDoUseiItem(indice, fluxo);
    }

    public void ReiniciarContadorDeEncontro()
    {
        encontros.ZeraPosAnterior();
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
        Manager.Dados.CriaturesAtivos[0].CaracCriature.meusAtributos.PV.Corrente = 1;
        hudM.AtualizaHudHeroi(manager.Dados.CriaturesAtivos[0]);
    }
    public void MeuCriatureComUZeroPE()
    {
        Manager.Dados.CriaturesAtivos[0].CaracCriature.meusAtributos.PE.Corrente = 0;
        hudM.AtualizaHudHeroi(manager.Dados.CriaturesAtivos[0]);
    }

    public void UmXpParaNivel()
    {
        IGerenciadorDeExperiencia gXP = Manager.Dados.CriaturesAtivos[0].CaracCriature.mNivel;
        gXP.XP = gXP.ParaProxNivel - 1;
    }

    public void TesteSave()
    {
        salvador.SalvarAgora();
    }

    public void ColocaQuatroGolpesNosCriatures()
    {
        CriatureBase[] Cs = Manager.Dados.CriaturesAtivos.ToArray();

        for (int i = 0; i < Cs.Length; i++)
        {
            GolpeBase duplicado = Cs[i].GerenteDeGolpes.meusGolpes[0];
            while (Cs[i].GerenteDeGolpes.meusGolpes.Count< 4)
            {
                Cs[i].GerenteDeGolpes.meusGolpes.Add(duplicado);
            }
        }
    }
    #endregion
}
