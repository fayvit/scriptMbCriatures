using UnityEngine;
using System.Collections;

[System.Serializable]
public class ControladorDaHudEntradaDeCriatures : UiDeOpcoes
{
    private DadosDoPersonagem dados;
    private System.Action<int> aoClique;

    public void IniciarEssaHUD(DadosDoPersonagem dados,System.Action<int> AoEscolherUmCriature)
    {
        this.dados = dados;
        aoClique += AoEscolherUmCriature;
        IniciarHUD(dados.criaturesAtivos.Count);
    }

    public override void SetarComponenteAdaptavel(GameObject G,int indice)
    {
        G.GetComponent<CriatureParaMostrador>().SetarCriature(dados.criaturesAtivos[indice], aoClique);
    }

    protected override void FinalizarEspecifico()
    {
        aoClique = null;
    }
}
