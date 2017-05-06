using UnityEngine;
using System.Collections;

[System.Serializable]
public class MenuDeShop : MenuBasico
{

    private bool comprar = true;
    public void IniciarHud(
        bool comprar,
        System.Action<int> acao,
        string[] txDeOpcoes,
        TipoDeRedimensionamento tipoDeR = TipoDeRedimensionamento.vertical)
    {
        this.comprar = comprar;
        IniciarHud(acao,txDeOpcoes,tipoDeR);
    }

    public override void SetarComponenteAdaptavel(GameObject G, int indice)
    {
        G.GetComponent<UmaOpcaoDeShop>().SetarOpcao(Acao, Opcoes[indice]);
    }

    public void SetActive(bool active)
    {
        sr.transform.parent.parent.gameObject.SetActive(active);
    }
}
