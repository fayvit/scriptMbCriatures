using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class HudManager 
{
    [SerializeField]private HudVida hudCriatureAtivo;
    [SerializeField]private HudVida hudInimigo;
    [SerializeField]private GameObject containerDoInimigo;
    [SerializeField]private GameObject containerDoLabelInimigo;

    [SerializeField]private BtnsManager btns;
    [SerializeField]private ControladorDaHudEntradaDeCriatures entraCriatures;
    [SerializeField]private ControladorDaHudEntradaDeCriatures entraCriaturesArmagedados;
    [SerializeField]private MenuDeImagens menuDeI;

    [SerializeField]private PainelUmaMensagem umaMensagem;
    [SerializeField]private PainelDeConfirmacao confirmacao;
    [SerializeField]private PauseMenu pauseM;
    [SerializeField]private PainelStatus pEscolheUsoDeItens;
    [SerializeField]private PainelDeCriature pCriature;
    [SerializeField]private PainelDeGolpe pGolpe;
    [SerializeField]private HudTentandoAprenderGolpe hTenta;
    [SerializeField]private DisparaTexto disparaT;
    [SerializeField]private MenuDeArmagedom menuDeA;
    [SerializeField]private MenuBasico menuBasico;
    [SerializeField]private PainelMostrarItem mostrarItem;
    [SerializeField]private ShopManager shop_Manager;
    [SerializeField]private BotaoZaoExterno botaozao;


    public BotaoZaoExterno Botaozao
    {
        get { return botaozao; }
    }
    public ShopManager Shop_Manager
    {
        get { return shop_Manager; }
    }
    public PainelMostrarItem MostrarItem
    {
        get { return mostrarItem; }
    }
    public MenuBasico Menu_Basico
    {
        get { return menuBasico; }
    }
    public MenuDeArmagedom MenuDeA
    {
        get { return menuDeA; }
    }
    public DisparaTexto DisparaT
    {
        get { return disparaT; }
    }
    public PauseMenu PauseM
    {
        get { return pauseM; }
    }
    public PainelUmaMensagem UmaMensagem
    {
        get { return umaMensagem; }
    }

    public PainelDeConfirmacao Confirmacao
    {
        get { return confirmacao; }
    }

    public BtnsManager Btns
    {
        get { return btns; }
    }

    public ControladorDaHudEntradaDeCriatures EntraCriatures
    {
        get { return entraCriatures; }
    }

    public ControladorDaHudEntradaDeCriatures EntraCriaturesArmagedados
    {
        get { return entraCriaturesArmagedados; }
    }

    public MenuDeImagens MenuDeI
    {
        get { return menuDeI; }
    }

    public HudVida HudCriatureAtivo
    {
        get { return hudCriatureAtivo; }
    }

    public PainelStatus P_EscolheUsoDeItens
    {
        get { return pEscolheUsoDeItens; }
    }

    public PainelDeCriature P_Criature
    {
        get { return pCriature; }
    }

    public PainelDeGolpe P_Golpe
    {
        get { return pGolpe; }
    }

    public HudTentandoAprenderGolpe H_Tenta
    {
        get { return hTenta; }
    }

    /*
    public HudVida HudInimigo
    {
        get { return hudInimigo; }
    }*/

    void LigaContainerDoInimigo()
    {
        containerDoInimigo.SetActive(true);
        containerDoLabelInimigo.SetActive(true);
    }

    public void DesligaContainerDoInimigo()
    {
        containerDoInimigo.SetActive(false);
        containerDoLabelInimigo.SetActive(false);
    }

    void AtualizaDadosDaHud(HudVida essaHud, CriatureBase C)
    {
        Atributos A = C.CaracCriature.meusAtributos;
        essaHud.PV.text = A.PV.Corrente + " \t/\t " + A.PV.Maximo;
        essaHud.PE.text = A.PE.Corrente + " \t/\t " + A.PE.Maximo;
        essaHud.nomeCriature.text = C.NomeID.ToString();
        essaHud.nivel.text = C.G_XP.Nivel.ToString();
        essaHud.barraDeVida.fillAmount = (float)A.PV.Corrente / A.PV.Maximo;
        essaHud.barraDeEnergia.fillAmount = (float)A.PE.Corrente / A.PE.Maximo;
    }

    public void InicializaPaineisCriature(CharacterManager manager)
    {
        DesligaContainerDoInimigo();
        btns.BotoesDoHeroi(manager);
        AtualizaDadosDaHud(HudCriatureAtivo, manager.Dados.CriaturesAtivos[0]);
    }

    public void InicializaHudDeLuta(CriatureBase inimigo)
    {
        LigaContainerDoInimigo();
        AtualizaDadosDaHud(hudInimigo, inimigo);
    }

    public void AtualizeHud(CharacterManager manager,CriatureBase inimigo)
    {
        AtualizaDadosDaHud(hudInimigo, inimigo);
        AtualizaDadosDaHud(HudCriatureAtivo, manager.Dados.CriaturesAtivos[0]);
    }

    public void AtualizaHudHeroi()
    {
        AtualizaHudHeroi(GameController.g.Manager.CriatureAtivo.MeuCriatureBase);
    }

    public void AtualizaHudHeroi(CriatureBase C)
    {
        AtualizaDadosDaHud(HudCriatureAtivo, C);
    }

    public void DesligaControladores()
    {
        containerDoInimigo.transform.parent.gameObject.SetActive(false);
        btns.btnAtaque.transform.parent.gameObject.SetActive(false);
    }

    public void ligarControladores()
    {
        containerDoInimigo.transform.parent.gameObject.SetActive(true);
        btns.btnAtaque.transform.parent.gameObject.SetActive(true);
    }
}

[System.Serializable]
public class HudVida
{
    public Text nomeCriature;
    public Text PV;
    public Text PE;
    public Text nivel;
    public Image barraDeVida;
    public Image barraDeEnergia;
    
}
