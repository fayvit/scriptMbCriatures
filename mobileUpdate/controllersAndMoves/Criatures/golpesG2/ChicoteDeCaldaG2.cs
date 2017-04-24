using UnityEngine;

[System.Serializable]
public class ChicoteDeCaldaG2 : ImpactoBase
{
    public ChicoteDeCaldaG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.chicoteDeCalda,
        tipo = nomeTipos.Normal,
        carac = caracGolpe.colisao,
        custoPE = 0,
        potenciaCorrente = 1,
        potenciaMaxima = 8,
        potenciaMinima = 1,
        tempoDeReuso = 3.5f,
        TempoNoDano = 0.5f,
        distanciaDeRepulsao = 65f,
        velocidadeDeRepulsao = 33,
        tempoDeMoveMin = 0.34f,//74
        tempoDeMoveMax = 0.7f,
        tempoDeDestroy = 1.2f
    }
        )
    {
        carac = new CaracteristicasDeImpacto()
        {
            noImpacto = NoImpacto.impactoComum.ToString(),
            nomeTrail = Trails.umCuboETrail.ToString(),
            parentearNoOsso = true
        };
    }
}
