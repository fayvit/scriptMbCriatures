using UnityEngine;

[System.Serializable]
public class GarraG2 : GolpeBase
{
    private AtualizadorDeImpactos aImpacto = new AtualizadorDeImpactos();
    private CaracteristicasDeImpacto carac = new CaracteristicasDeImpacto()
    {
        noImpacto = NoImpacto.impactoComum.ToString(),
        nomeTrail = Trails.tresCubos.ToString(),
        parentearNoOsso = true
    };

    public GarraG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.garra,
        tipo = nomeTipos.Normal,
        carac = caracGolpe.colisao,
        custoPE = 0,
        potenciaCorrente = 1,
        potenciaMaxima = 8,
        potenciaMinima = 1,
        tempoDeReuso = 5,
        TempoNoDano = 0.25f,
        velocidadeDeGolpe = 15f,
        distanciaDeRepulsao = 45f,
        velocidadeDeRepulsao = 23,
        tempoDeMoveMin = 0.15f,//74
        tempoDeMoveMax = 0.4f,
        tempoDeDestroy = 1.2f
    }
        )
    {

    }

    public override void IniciaGolpe(GameObject G)
    {
        aImpacto.ReiniciaAtualizadorDeImpactos();
        AnimadorCriature.AnimaAtaque(G, Nome.ToString());
    }

    public override void UpdateGolpe(GameObject G)
    {
        aImpacto.ImpatoAtivo(G, this, carac);
    }
}
