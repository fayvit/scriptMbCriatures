﻿using UnityEngine;
using System.Collections;

public class MbItens:System.ICloneable
{
    [SerializeField]private nomeIDitem nomeID;
    [SerializeField]private bool usavel;
    [SerializeField]private int acumulavel;
    [SerializeField]private int estoque;
    [SerializeField]private int valor;

    //private GameObject gAlvoDoItem;
    private CharacterManager manager;
    private FluxoDeRetorno fluxo;
    private EstadoDeUsoDeItem estado = EstadoDeUsoDeItem.nulo;
    private AnimaBraco animaB;
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
        int indice = gerente.Dados.itens.IndexOf(nomeItem);
        if (indice > -1)
            if (gerente.Dados.itens[indice].Estoque >= quantidade)
            {
                gerente.Dados.itens[indice].Estoque -= quantidade;
                if (gerente.Dados.itens[indice].Estoque == 0)
                {
                    gerente.Dados.itens.Remove(gerente.Dados.itens[indice]);

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