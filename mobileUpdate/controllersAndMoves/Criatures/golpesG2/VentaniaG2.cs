using UnityEngine;
using System.Collections;

[System.Serializable]
public class VentaniaG2 : ProjetilBase
{

    public VentaniaG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.ventania,
        tipo = nomeTipos.Voador,
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
        velocidadeDeGolpe = 18
    }
        )
    {
        carac = new CaracteristicasDeProjetil()
        {
            noImpacto = NoImpacto.impactoDeVento,
            tipo = TipoDoProjetil.basico
        };
    }
    

}
