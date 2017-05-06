using UnityEngine;
using System.Collections;

[System.Serializable]
public class ImpactoBase : GolpeBase
{
    private AtualizadorDeImpactos aImpacto = new AtualizadorDeImpactos();
    protected CaracteristicasDeImpacto carac = new CaracteristicasDeImpacto()
    {
        noImpacto = NoImpacto.impactoComum.ToString(),
        nomeTrail = Trails.tresCubos.ToString(),
        parentearNoOsso = true
    };

    public ImpactoBase(ContainerDeCaracteristicasDeGolpe C) : base(C) { }

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
