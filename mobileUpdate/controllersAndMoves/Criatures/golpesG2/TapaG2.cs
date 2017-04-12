using UnityEngine;

[System.Serializable]
public class TapaG2 : GolpeBase
{
    private AtualizadorDeImpactos aImpacto = new AtualizadorDeImpactos();
    private CaracteristicasDeImpacto carac = new CaracteristicasDeImpacto()
    {
        noImpacto = "impactoComum",
        nomeTrail = "umCuboETrail",
        parentearNoOsso = true
    };

    public TapaG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.tapa,
        tipo = nomeTipos.Normal,
        carac = caracGolpe.colisao,
        custoPE = 0,
        potenciaCorrente = 1,
        potenciaMaxima = 8,
        potenciaMinima = 1,
        tempoDeReuso = 3.5f,        
        TempoNoDano = 0.25f,
        distanciaDeRepulsao = 45f,
        velocidadeDeRepulsao = 23,
        tempoDeMoveMin = 0.44f,//74
        tempoDeMoveMax = 0.7f,
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
        aImpacto.ImpatoAtivo(G,this,carac);
    }
}
