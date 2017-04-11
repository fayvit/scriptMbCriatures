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
}