using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UmaOpcaoDeShop : UmaOpcaoDeMenu
{
    [SerializeField] private RawImage imgDoItem;
    [SerializeField] private Text precoDoItem;

    public void SetarOpcao(System.Action<int> acaoDaOpcao, string txtDaOpcao,bool comprar = true)
    {
        
        nomeIDitem nomeID = (nomeIDitem)System.Enum.Parse(typeof(nomeIDitem), txtDaOpcao);
        Acao += acaoDaOpcao;
        TextoOpcao.text = item.nomeEmLinguas(nomeID);
        imgDoItem.texture = elementosDoJogo.el.RetornaMini(nomeID);
        if(comprar)
            precoDoItem.text = PegaUmItem.Retorna(nomeID).Valor.ToString();
        else
            precoDoItem.text = (Mathf.Max(PegaUmItem.Retorna(nomeID).Valor/4,1)).ToString();
    }
}
