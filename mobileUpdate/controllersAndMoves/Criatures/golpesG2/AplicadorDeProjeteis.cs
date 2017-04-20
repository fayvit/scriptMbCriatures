using UnityEngine;
using System.Collections;

public class AplicadorDeProjeteis
{
    public static void AplicaProjetil(GameObject G,IGolpeBase ativa,CaracteristicasDeProjetil carac)
    {
        GolpePersonagem golpeP = GolpePersonagem.RetornaGolpePersonagem(G, ativa.Nome);
            if (golpeP.TempoDeInstancia > 0)
                carac.posInicial = Emissor.UseOEmissor(G, ativa.Nome);

        GameObject KY = AuxiliarDeInstancia.InstancieEDestrua(ativa.Nome, carac.posInicial, ativa.DirDeREpulsao, ativa.TempoDeDestroy);

        ColisorDeDanoBase proj = null;
        switch (carac.tipo)
        {
            case TipoDoProjetil.rigido:
                proj = KY.AddComponent<ColisorDeDanoRigido>();
            break;
            case TipoDoProjetil.basico:
                proj = KY.AddComponent<ColisorDeDano>();
            break;
            case TipoDoProjetil.status:
               // proj = KY.AddComponent<projetilStatusExpansivel>();
            break;
            case TipoDoProjetil.direcional:
                //projetilDirecional projD = KY.AddComponent<projetilDirecional>();
                //projD.alvo = (gameObject.name == "inimigo") ? GameObject.Find("CriatureAtivo") : GameObject.Find("inimigo");
                //proj = projD;
            break;
        }
        
        proj.velocidadeProjetil = ativa.VelocidadeDeGolpe;
        proj.noImpacto = carac.noImpacto.ToString();
        proj.dono = G;
        proj.esseGolpe = ativa;

    }
}

public struct CaracteristicasDeProjetil
{
    public Vector3 posInicial;
    public TipoDoProjetil tipo;
    public NoImpacto noImpacto;
}

public enum TipoDoProjetil
{
    basico,
    rigido,
    status,
    direcional
}
