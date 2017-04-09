using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController g;
    private CharacterManager manager;
    private MbUsoDeItem usoDeItens;

    [SerializeField]private MbEncontros encontros;
    [SerializeField]private HudManager hudM;

    public HudManager HudM
    {
        get { return hudM; }
    }

    public bool estaEmLuta
    {
        get { return encontros.Luta; }
    }

    public CreatureManager InimigoAtivo
    {
        get { return encontros.InimigoAtivo; }
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
    }

    void VerificaSetarManager()
    {
        if(manager==null)
            manager = FindObjectOfType<CharacterManager>();
    }

    public void BotaoPulo()
    {
        VerificaSetarManager();
        manager.IniciaPulo(); 
    }

    public void BotaoAlternar()
    {
        VerificaSetarManager();
        manager.BotaoAlternar();
    }

    public void BotaoAtaque()
    {
        VerificaSetarManager();
        manager.BotaoAtacar();
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

    void FuncaoDoUseiItem(int indice)
    {
        if (!usoDeItens.EstouUsandoItem)
        {
            hudM.MenuDeI.FinalizarHud();

            usoDeItens.Start(manager,
                manager.Estado == EstadoDePersonagem.comMeuCriature
                ? FluxoDeRetorno.criature
                : FluxoDeRetorno.heroi);
        }
    }

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
        manager.Dados.criaturesAtivos[0].CaracCriature.meusAtributos.PV.Corrente = 1;
        hudM.AtualizaHudHeroi(manager.Dados.criaturesAtivos[0]);
    }

    public void UmXpParaNivel()
    {
        IGerenciadorDeExperiencia gXP = manager.Dados.criaturesAtivos[0].CaracCriature.mNivel;
        gXP.XP = gXP.ParaProxNivel - 1;
    }
}
