using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManager : MonoBehaviour {
    [SerializeField]private CaracteristicasDeMovimentacao caracMov;
    [SerializeField]private ElementosDeMovimentacao elementos;
    [SerializeField]private MovimentacaoBasica mov;
    [SerializeField]private DadosDoPersonagem dados;
    [SerializeField]private EstadoDePersonagem estado = EstadoDePersonagem.naoIniciado;

    private AndroidController controle;
    private CreatureManager criatureAtivo;

    public DadosDoPersonagem Dados
    {
        get { return dados; }
        set { dados = value; }
    }

    public EstadoDePersonagem Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    public CreatureManager CriatureAtivo
    {
        get {
            if (criatureAtivo == null)
            {
                GameObject G = GameObject.Find("CriatureAtivo");
                if(G)
                    criatureAtivo = G.GetComponent<CreatureManager>();
            }
            return criatureAtivo;
        }
    }

    public MovimentacaoBasica Mov
    {
        get { return mov; }
    }

    // Use this for initialization
    void Start () {
        mov = new MovimentacaoBasica(caracMov, elementos);
        controle = FindObjectOfType<AndroidController>();
        if (Estado == EstadoDePersonagem.naoIniciado)
        {
            dados.InicializadorDosDados();

            InserirCriatureEmJogo();
            Estado = EstadoDePersonagem.aPasseio;
        }
    }

    public void InserirCriatureEmJogo()
    {
        GameObject G = InicializadorDoJogo.InstanciaCriature(transform, dados.CriaturesAtivos[0]);
        InicializadorDoJogo.InsereCriatureEmJogo(G, this);
        GameController.g.HudM.InicializaPaineisCriature(this);
    }

    // Update is called once per frame
    void Update () {
        switch (estado)
        {
            case EstadoDePersonagem.aPasseio:
                mov.AplicadorDeMovimentos(controle.ValorParaEixos());
            break;
            case EstadoDePersonagem.comMeuCriature:
            case EstadoDePersonagem.parado:
                mov.AplicadorDeMovimentos(Vector3.zero);
            break;
        }
        
	}

    public void AoCriature(CreatureManager inimigo = null)
    {
        estado = EstadoDePersonagem.comMeuCriature;
        criatureAtivo = GameObject.Find("CriatureAtivo").GetComponent<CreatureManager>();
        GameController.g.HudM.Btns.BotoesDoCriature(this);
        MbAlternancia.AoCriature(criatureAtivo,inimigo);
    }

    public void AoHeroi()
    {
        MbAlternancia.AoHeroi(this);
        GameController.g.HudM.Btns.BotoesDoHeroi(this);
        estado = EstadoDePersonagem.aPasseio;
    }

    public void BotaoAlternar()
    {
        if (estado == EstadoDePersonagem.aPasseio)
        {
            AoCriature();
        }
        else if (estado == EstadoDePersonagem.comMeuCriature)
        {
            AoHeroi();
        }
    }

    public void BotaoAtacar()
    {
        
        if(estado==EstadoDePersonagem.comMeuCriature)
            criatureAtivo.ComandoDeAtacar();
    }

    public void IniciaPulo()
    {
        if (!caracMov.caracPulo.estouPulando && estado == EstadoDePersonagem.aPasseio)
            mov._Pulo.IniciaAplicaPulo();
        else if (estado == EstadoDePersonagem.comMeuCriature)
            criatureAtivo.IniciaPulo();
    }
}

public enum EstadoDePersonagem
{
    aPasseio,
    parado,
    comMeuCriature,
    naoIniciado
}
