using UnityEngine;
using System.Collections.Generic;

public class ReplaceManager
{
    private AnimaBraco animaB;
    private FluxoDeRetorno fluxo;
    private CharacterManager manager;

    public ReplaceManager(CharacterManager manager,Transform alvo,FluxoDeRetorno fluxo)
    {
        this.fluxo = fluxo;
        this.manager = manager;
        List<CriatureBase> lista = manager.Dados.criaturesAtivos;
        CriatureBase temp = lista[0];
        lista[0] = lista[manager.Dados.criatureSai];
        lista[manager.Dados.criatureSai] = temp;
        animaB = new AnimaBraco(manager, alvo);
    }

    public bool Update()
    {
        if (!animaB.AnimaTroca())
        {
            if (!animaB.AnimaEnvia())
            {
                if (fluxo == FluxoDeRetorno.heroi)
                {
                    manager.AoHeroi();
                }
                
                manager.Mov.Animador.ResetaTroca();
                manager.Mov.Animador.ResetaEnvia();
                return true;
            }
        }

        return false;
    }
}

public enum FluxoDeRetorno
{
    heroi,
    criature,
    menu
}
