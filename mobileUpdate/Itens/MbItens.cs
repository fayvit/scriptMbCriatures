using UnityEngine;
using System.Collections;

[System.Serializable]

public class MbItens:System.ICloneable
{
    [SerializeField]private nomeIDitem nomeID;
    [SerializeField]private bool usavel;
    [SerializeField]private int acumulavel;
    [SerializeField]private int estoque;
    [SerializeField]private int valor;

    //private GameObject gAlvoDoItem;
    [System.NonSerialized]private CharacterManager manager;
    [System.NonSerialized]private AnimaBraco animaB;
    private FluxoDeRetorno fluxo;
    private EstadoDeUsoDeItem estado = EstadoDeUsoDeItem.nulo;
    
    private float tempoDecorrido = 0;

    public MbItens(ContainerDeCaracteristicasDeItem cont)
    {
        this.nomeID = cont.NomeID;
        this.usavel = cont.usavel;
        this.acumulavel = cont.acumulavel;
        this.estoque = cont.estoque;
        this.valor = cont.valor;
    }
    public nomeIDitem ID
    {
        get { return nomeID; }
    }

    public bool Usavel
    {
        get { return usavel; }
    }

    public int Acumulavel
    {
        get { return acumulavel; }
    }

    public int Estoque
    {
        get { return estoque; }
        set { estoque = value; }
    }

    public int Valor
    {
        get { return valor; }
    }

    public EstadoDeUsoDeItem Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    public float TempoDecorrido
    {
        get { return tempoDecorrido; }
        set { tempoDecorrido = value; }
    }

    public CharacterManager Manager
    {
        get { return manager; }
        set { manager = value; }
    }

    public AnimaBraco AnimaB
    {
        get { return animaB; }
        set { animaB = value; }
    }

    public virtual void IniciaUsoDeMenu(GameObject dono)
    {
        throw new System.NotImplementedException();
    }

    public virtual bool AtualizaUsoDeMenu()
    {
        throw new System.NotImplementedException();
        //return false;
    }

    public virtual void IniciaUsoComCriature(GameObject dono)
    {
        throw new System.NotImplementedException();
    }

    public virtual bool AtualizaUsoComCriature()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IniciaUsoDeHeroi(GameObject dono)
    {
        throw new System.NotImplementedException();
    }

    public virtual bool AtualizaUsoDeHeroi()
    {
        throw new System.NotImplementedException();
    }

    public static bool RetirarUmItem(
        CharacterManager gerente,
        MbItens nomeItem,
        int quantidade = 1,
        FluxoDeRetorno fluxo = FluxoDeRetorno.heroi)
    {
        bool retorno = true;
        for (int i = 0; i < quantidade; i++)
        {
            retorno &= RetirarUmItem(gerente,ProcuraItemNaLista(nomeItem.ID),fluxo);
            
        }

        return retorno;
    }

    static MbItens ProcuraItemNaLista(nomeIDitem nome)
    {
        MbItens retorno = new MbItens(new ContainerDeCaracteristicasDeItem());
        for (int i = GameController.g.Manager.Dados.Itens.Count - 1; i > -1;i--)
        {
            if (GameController.g.Manager.Dados.Itens[i].ID == nome)
                retorno = GameController.g.Manager.Dados.Itens[i];
        }
        return retorno;

    }

    public static bool RetirarUmItem(
        CharacterManager gerente, 
        MbItens nomeItem, 
        FluxoDeRetorno fluxo = FluxoDeRetorno.heroi)
    {
        int indice = gerente.Dados.Itens.IndexOf(nomeItem);
        if (indice > -1)
            if (gerente.Dados.Itens[indice].Estoque >= 1)
            {
                gerente.Dados.Itens[indice].Estoque--;
                Debug.Log("remove ai vai");
                if (gerente.Dados.Itens[indice].Estoque == 0)
                {
                    Debug.Log("Tira daí");
                    gerente.Dados.Itens.Remove(gerente.Dados.Itens[indice]);

                    if (fluxo == FluxoDeRetorno.menuCriature || fluxo == FluxoDeRetorno.menuHeroi)
                    {
                        GameController.g.StartCoroutine(VoltarDosItensQuandoNaoTemMais());
                    }
                }
                return true;
            }

        return false;
    }

    protected void InicializacaoComum(GameObject dono,Transform alvoDoItem)
    {

        TempoDecorrido = 0;

        Manager.Estado = EstadoDePersonagem.parado;
        Manager.CriatureAtivo.PararCriatureNoLocal();
        Manager.Mov.Animador.PararAnimacao();

        if (GameController.g.estaEmLuta)
            GameController.g.InimigoAtivo.PararCriatureNoLocal();

        AnimaB = new AnimaBraco(Manager, alvoDoItem);

    }

    static IEnumerator VoltarDosItensQuandoNaoTemMais()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameController.g.HudM.P_EscolheUsoDeItens.VoltarDosItens();
    }

    public object Clone()
    {
        return PegaUmItem.Retorna(nomeID, estoque);
    }
}

public struct ContainerDeCaracteristicasDeItem
{
    public nomeIDitem NomeID;
    public bool usavel;
    public int acumulavel;
    public int estoque;
    public int valor;

    /// <summary>
    /// Ao construir com o parametro nome, os campos recebem valores padrões
    /// </summary>
    /// <param name="nome">Nome do item a ser construido</param>
    public ContainerDeCaracteristicasDeItem(nomeIDitem nome)
    {
        this.NomeID = nome;
        this.usavel = true;
        this.acumulavel = 99;
        this.estoque = 1;
        this.valor = 1;
    }
}

public enum EstadoDeUsoDeItem
{
    nulo = -1,
    animandoBraco,
    aplicandoItem,
    finalizaUsaItem
}