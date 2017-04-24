using UnityEngine;

[System.Serializable]
public class BicoG2 : GolpeBase
{
    private AtualizadorDeImpactos aImpacto = new AtualizadorDeImpactos();
    private CaracteristicasDeImpacto carac = new CaracteristicasDeImpacto()
    {
        noImpacto = NoImpacto.impactoComum.ToString(),
        nomeTrail = Trails.umCuboETrail.ToString(),
        parentearNoOsso = true
    };

    public BicoG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.bico,
        tipo = nomeTipos.Normal,
        carac = caracGolpe.colisao,
        custoPE = 0,
        potenciaCorrente = 1,
        potenciaMaxima = 8,
        potenciaMinima = 1,
        tempoDeReuso = 3.5f,
        TempoNoDano = 0.5f,
        velocidadeDeGolpe = 18f,
        distanciaDeRepulsao = 65f,
        velocidadeDeRepulsao = 33,
        tempoDeMoveMin = 0.15f,//74
        tempoDeMoveMax = 0.6f,
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
