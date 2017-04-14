using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RedimensionarUI
{
    public static void NaVertical(RectTransform redimensionado, GameObject item, int num)
    {
        redimensionado.sizeDelta
            = new Vector2(0, num * item.GetComponent<LayoutElement>().preferredHeight);
    }

    public static void EmGrade(RectTransform redimensionado, GameObject item, int num)
    {
        LayoutElement lay = item.GetComponent<LayoutElement>();
        GridLayoutGroup grid = redimensionado.GetComponent<GridLayoutGroup>();
        
        int quantidade = (int)(redimensionado.rect.width / (lay.preferredWidth + grid.spacing.x+5));

        int numeroDeLinhas = ((num-1) / (quantidade)) + 1;
        redimensionado.sizeDelta
                    = new Vector2(0, numeroDeLinhas * (lay.preferredHeight+ grid.spacing.y));
    }
}

public enum TipoDeRedimensionamento
{
    vertical,
    emGrade
}