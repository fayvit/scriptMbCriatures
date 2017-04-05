using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ControladorDaHudEntradaDeCriatures
{
    [SerializeField]private GameObject itemDoContainer;
    [SerializeField]private RectTransform painelDeTamanhoVariavel;

   
    public void IniciarEssaHUD(DadosDoPersonagem dados)
    {
        painelDeTamanhoVariavel.parent.parent.gameObject.SetActive(true);

        itemDoContainer.SetActive(true);

        painelDeTamanhoVariavel.sizeDelta 
            = new Vector2(0, dados.criaturesAtivos.Count* itemDoContainer.GetComponent<LayoutElement>().preferredHeight);

        for (int i = 0; i < dados.criaturesAtivos.Count; i++)
        {
            GameObject G = MonoBehaviour.Instantiate(itemDoContainer);
            RectTransform T = G.GetComponent<RectTransform>();
            T.SetParent(painelDeTamanhoVariavel.transform);
            G.GetComponent<CriatureParaMostrador>().SetarCriature(dados.criaturesAtivos[i], AoEscolherUmCriature);
            T.localScale = new Vector3(1, 1, 1);

            T.offsetMax = Vector2.zero;
            T.offsetMin = Vector2.zero;
        }

        itemDoContainer.SetActive(false);
    }

    public void AoEscolherUmCriature(int qual)
    {

    }
}
