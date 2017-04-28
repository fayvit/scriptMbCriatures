using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoArmagedom : AtivadorDeBotao
{
    [SerializeField]private Sprite fotoDoNPC;    

    private bool Ativo = false;    

    public void BotaoArmagedom()
    {
        GameController g = GameController.g;
        HudManager hudM = g.HudM;
        AndroidController.a.DesligarControlador();
        AplicadorDeCamera.cam.InicializaCameraExibicionista(transform.parent,1);
        Ativo = true;

        g.Manager.Estado = EstadoDePersonagem.parado;
        g.Manager.transform.rotation = Quaternion.LookRotation(
            Vector3.ProjectOnPlane(transform.position-g.Manager.transform.position,Vector3.up));
        
        hudM.DesligaControladores();
        hudM.MenuDeI.FinalizarHud();
        g.HudM.MenuDeA.Inicia(transform.parent, fotoDoNPC);
        Update();
    }
}
