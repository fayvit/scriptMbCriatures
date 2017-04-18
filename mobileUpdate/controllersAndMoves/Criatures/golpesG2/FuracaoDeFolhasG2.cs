﻿using UnityEngine;
using System.Collections;

public class FuracaoDeFolhasG2 : GolpeBase
{

    private bool addView = false;
    private float tempoDecorrido = 0;

    private CaracteristicasDeProjetil carac = new CaracteristicasDeProjetil()
    {
        noImpacto = NoImpacto.impactoDeFolhas,
        tipo = TipoDoProjetil.rigido
    };

    public FuracaoDeFolhasG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.furacaoDeFolhas,
        tipo = nomeTipos.Planta,
        carac = caracGolpe.projetil,
        custoPE = 2,
        potenciaCorrente = 4,
        potenciaMaxima = 10,
        potenciaMinima = 2,
        tempoDeReuso = 7.5f,
        tempoDeMoveMax = 1 ,
        tempoDeMoveMin = 0.15f,
        tempoDeDestroy = 2,
        TempoNoDano = 0.75f,
        velocidadeDeGolpe = 18 
    }
        )
    {
        //Corpo do construtor
    }

    public override void IniciaGolpe(GameObject G)
    {
        addView = false;
        tempoDecorrido = 0;
        carac.posInicial = Emissor.UseOEmissor(G, this.Nome);
        DirDeREpulsao = G.transform.forward;
        AnimadorCriature.AnimaAtaque(G, "emissor");
    }

    public override void UpdateGolpe(GameObject G)
    {

        tempoDecorrido += Time.deltaTime;
        if (!addView && tempoDecorrido > this.TempoDeMoveMin)
        {
            addView = true;
            AplicadorDeProjeteis.AplicaProjetil(G, this, carac);
        }


    }

}
