using UnityEngine;
using System.Collections;
using System;

public class HudEntraArmagedados : CriatureParaMostrador
{
    public override void FuncaoDoBotao()
    {
        BtnsManager.DesligarBotoes(transform.parent.gameObject);
        cliqueDoPersonagem(transform.GetSiblingIndex() - 1);
    }

    public void BotaoVoltar()
    {
        GameController.g.HudM.MenuDeA.VoltarDoEntraArmagedado();
    }
}
