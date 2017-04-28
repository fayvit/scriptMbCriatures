using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class UiDeOpcoes
{
    [SerializeField]protected GameObject itemDoContainer;
    [SerializeField]protected RectTransform painelDeTamanhoVariavel;
    [SerializeField]protected ScrollRect sr;

    public abstract void SetarComponenteAdaptavel(GameObject G,int indice);
    protected abstract void FinalizarEspecifico();

    protected void IniciarHUD(int quantidade,TipoDeRedimensionamento tipo = TipoDeRedimensionamento.vertical)
    {
        painelDeTamanhoVariavel.parent.parent.gameObject.SetActive(true);

        itemDoContainer.SetActive(true);

        if(tipo==TipoDeRedimensionamento.vertical)
            RedimensionarUI.NaVertical(painelDeTamanhoVariavel, itemDoContainer, quantidade);
        else if(tipo==TipoDeRedimensionamento.emGrade)
            RedimensionarUI.EmGrade(painelDeTamanhoVariavel, itemDoContainer, quantidade);

        for (int i = 0; i < quantidade; i++)
        {
            GameObject G = ParentearNaHUD.Parentear(itemDoContainer, painelDeTamanhoVariavel);
            SetarComponenteAdaptavel(G,i);
        }

        itemDoContainer.SetActive(false);

        if (sr != null)
            if (sr.verticalScrollbar)
                sr.verticalScrollbar.value = 1;
        GameController.g.StartCoroutine(ScrollPos());
        
    }

    IEnumerator ScrollPos()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        
        if (sr != null)
            if (sr.verticalScrollbar)
                sr.verticalScrollbar.value = 1;
        
    }

    public void FinalizarHud()
    {
        for (int i = 1; i < painelDeTamanhoVariavel.transform.childCount; i++)
        {
            MonoBehaviour.Destroy(painelDeTamanhoVariavel.GetChild(i).gameObject);
            painelDeTamanhoVariavel.parent.parent.gameObject.SetActive(false);
        }

        FinalizarEspecifico();
    }

    
}
