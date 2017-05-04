using UnityEngine;

[System.Serializable]
public class MenuBasico : UiDeOpcoes
{
    private string[] opcoes;
    private System.Action<int> acao;

    public void IniciarHud(
        System.Action<int> acao,
        string[] txDeOpcoes,
        TipoDeRedimensionamento tipoDeR = TipoDeRedimensionamento.vertical)
    {
        this.opcoes = txDeOpcoes;
        this.acao += acao;
        IniciarHUD(opcoes.Length, tipoDeR);
    }
    public override void SetarComponenteAdaptavel(GameObject G, int indice)
    {
        G.GetComponent<UmaOpcaoDeMenu>().SetarOpcao(acao, opcoes[indice]);
    }

    protected override void FinalizarEspecifico()
    {
        acao = null;
        //Seria preciso uma finalização especifica??
    }
}
