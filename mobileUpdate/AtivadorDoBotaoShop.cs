using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoShop : AtivadorDeBotao
{
    [SerializeField]private Sprite fotoDoNPC;   
    [SerializeField]private nomeIDitem[] aVenda;
    [SerializeField]private Transform focoDeCamera;

    public void BotaoShop()
    {
        FluxoDeBotao();
        GameController.g.HudM.Shop_Manager.IniciarShop(aVenda,fotoDoNPC);
        AplicadorDeCamera.cam.InicializaCameraExibicionista(focoDeCamera, 1);
    }
}
