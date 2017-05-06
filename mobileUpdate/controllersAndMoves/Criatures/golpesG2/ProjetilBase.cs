using UnityEngine;
using System.Collections;

[System.Serializable]
public class ProjetilBase : GolpeBase
{
    private bool addView = false;
    private float tempoDecorrido = 0;

    protected CaracteristicasDeProjetil carac = new CaracteristicasDeProjetil()
    {
        noImpacto = NoImpacto.impactoComum,
        tipo = TipoDoProjetil.basico
    };

    public ProjetilBase(ContainerDeCaracteristicasDeGolpe C) : base(C) { }

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
