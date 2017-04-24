using UnityEngine;
using System.Collections;

public class MbAlternancia
{
    public static void AoCriature(CreatureManager C,CreatureManager inimigo = null)
    {
        Debug.Log("aqui");
        if (inimigo!=null)
        {
            AplicadorDeCamera aCam = AplicadorDeCamera.cam;
            aCam.InicializaCameraDeLuta(C, inimigo.transform);
            C.Estado = CreatureManager.CreatureState.emLuta;
            inimigo.Estado = CreatureManager.CreatureState.selvagem;
        }
        else
        {
            AplicadorDeCamera.cam.FocarBasica(C.transform, C.MeuCriatureBase.alturaCamera, C.MeuCriatureBase.distanciaCamera);
            C.Estado = CreatureManager.CreatureState.aPasseio;                        
        }

        C.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
    }

    public static void AoHeroi(CharacterManager manager)
    {
        CreatureManager C = manager.CriatureAtivo;
        AplicadorDeCamera.cam.FocarBasica(manager.transform, 10,10);
        C.Estado = CreatureManager.CreatureState.seguindo;
        manager.Estado = EstadoDePersonagem.aPasseio;
        C.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
    }
}
