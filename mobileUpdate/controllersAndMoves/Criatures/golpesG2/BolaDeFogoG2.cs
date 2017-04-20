using UnityEngine;
using System.Collections;

public class BolaDeFogoG2 : GolpeBase
{

    private bool addView = false;
    private float tempoDecorrido = 0;

    private CaracteristicasDeProjetil carac = new CaracteristicasDeProjetil()
    {
        noImpacto = NoImpacto.impactoDeFogo,
        tipo = TipoDoProjetil.basico
    };

    public BolaDeFogoG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.bolaDeFogo,
        tipo = nomeTipos.Fogo,
        carac = caracGolpe.projetil,
        custoPE = 1,
        potenciaCorrente = 2,
        potenciaMaxima = 7,
        potenciaMinima = 1,
        tempoDeReuso = 5,
        tempoDeMoveMax = 1,
        tempoDeMoveMin = 0.15f,
        tempoDeDestroy = 2,
        TempoNoDano = 0.75f,
        velocidadeDeGolpe = 10
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
