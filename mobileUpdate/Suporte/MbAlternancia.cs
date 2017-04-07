using UnityEngine;
using System.Collections;

public class MbAlternancia
{
    public static void AoCriature(CreatureManager C,CreatureManager inimigo = null)
    {
        if (inimigo!=null)
        {
            AplicadorDeCamera aCam = MonoBehaviour.FindObjectOfType<AplicadorDeCamera>();
            aCam.InicializaCameraDeLuta(C, inimigo.transform);
            C.Estado = CreatureManager.CreatureState.emLuta;
            inimigo.Estado = CreatureManager.CreatureState.selvagem;
        }
        else
        {
            CameraBasica cam = MonoBehaviour.FindObjectOfType<AplicadorDeCamera>().Basica;
            cam.NovoFoco(C.transform, C.MeuCriatureBase.alturaCamera, C.MeuCriatureBase.distanciaCamera);
            C.Estado = CreatureManager.CreatureState.aPasseio;
            C.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
    }

    public static void AoHeroi(CreatureManager C,CharacterManager manager)
    {
        CameraBasica cam = MonoBehaviour.FindObjectOfType<AplicadorDeCamera>().Basica;
        cam.NovoFoco(manager.transform, 10,10);
        C.Estado = CreatureManager.CreatureState.seguindo;
        C.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
    }
}
