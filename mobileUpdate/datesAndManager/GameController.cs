using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController g;
    private CharacterManager manager;

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

    public Transform InimigoAtivo
    {
        get { return encontros.InimigoAtivo; }
    }



    // Use this for initialization
    void Start()
    {
        g = this;
        VerificaSetarManager();
        encontros.Start();
    }

    // Update is called once per frame
    void Update()
    {
        encontros.Update();
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
    }
}
