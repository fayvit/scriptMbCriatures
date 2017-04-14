using UnityEngine;
using System.Collections;

[System.Serializable]
public class MenuDeImagens : UiDeOpcoes
{
    private bool aberto = false;
    private float contadorDeTempo = 0;
    private float tempoParaFechar = 0;
    private DadosDoPersonagem dados;
    private TipoDeDado tipo;
    private System.Action<int> acao;

    public bool Aberto
    {
        get { return aberto; }
    }

    public TipoDeDado Tipo
    {
        get{ return tipo; }
    }

    protected override void FinalizarEspecifico()
    {
        aberto = false;
        acao = null;
    }

    public override void SetarComponenteAdaptavel(GameObject G, int indice)
    {
        G.GetComponent<DadoDaHudRapida>().SetarDados(dados, indice, tipo, acao);
    }

    public void IniciarHud(
        DadosDoPersonagem dados,
        TipoDeDado tipo,
        int quantidade,System.Action<int> acao,
        float tempoParaFechar,
        TipoDeRedimensionamento tipoDeR = TipoDeRedimensionamento.vertical)
    {
        this.dados = dados;
        this.tipo = tipo;
        this.acao = acao;
        this.tempoParaFechar = tempoParaFechar;
        contadorDeTempo = 0;
        aberto = true;        
        IniciarHUD(quantidade,tipoDeR);
    }

    public void Update()
    {
        if (tempoParaFechar > 0)
        {
            contadorDeTempo += Time.deltaTime;
            if (contadorDeTempo > tempoParaFechar)
                FinalizarHud();
        }
    }
}
