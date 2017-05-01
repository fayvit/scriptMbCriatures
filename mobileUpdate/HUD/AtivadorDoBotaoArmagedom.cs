using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoArmagedom : AtivadorDeBotao
{
    [SerializeField]private Sprite fotoDoNPC;       

    public void BotaoArmagedom()
    {
        FluxoDeBotao();
        AplicadorDeCamera.cam.InicializaCameraExibicionista(transform.parent, 1);
        GameController.g.HudM.MenuDeA.Inicia(transform.parent, fotoDoNPC);
    }
}
