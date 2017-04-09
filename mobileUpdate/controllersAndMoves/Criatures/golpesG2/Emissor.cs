using UnityEngine;
using System.Collections;

public class Emissor
{
    public static Vector3 UseOEmissor(GameObject G,nomesGolpes nome)
    {

        GolpePersonagem gP = GolpePersonagem.RetornaGolpePersonagem(G,nome);

        if (GameController.g.estaEmLuta && G.name=="CriatureAtivo")
        {
            G.transform.rotation = Quaternion.LookRotation(
                GameController.g.InimigoAtivo.transform.position-G.transform.position
                );
        }

        return  G.transform.Find(gP.Colisor.osso).position
            + G.transform.forward * (gP.DistanciaEmissora)
                + Vector3.up * gP.AcimaDoChao;
    }
}
