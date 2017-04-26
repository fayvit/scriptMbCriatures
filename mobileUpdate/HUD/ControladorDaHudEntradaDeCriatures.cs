using UnityEngine;
using System.Collections;

[System.Serializable]
public class ControladorDaHudEntradaDeCriatures : UiDeOpcoes
{
    private CriatureBase[] listaDeCriatures;
    private System.Action<int> aoClique;

    public void IniciarEssaHUD(CriatureBase[] listaDeCriatures,System.Action<int> AoEscolherUmCriature)
    {
        this.listaDeCriatures = listaDeCriatures;
        aoClique += AoEscolherUmCriature;
        IniciarHUD(listaDeCriatures.Length);
    }

    public override void SetarComponenteAdaptavel(GameObject G,int indice)
    {
        G.GetComponent<CriatureParaMostrador>().SetarCriature(listaDeCriatures[indice], aoClique);
    }

    protected override void FinalizarEspecifico()
    {
        aoClique = null;
    }
}
