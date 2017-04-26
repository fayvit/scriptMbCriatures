using UnityEngine;
using System.Collections;

public class InsereInimigoEmCampo
{
    public static CreatureManager RetornaInimigoEmCampo(encontravel encontrado,CharacterManager manager)
    {
        Debug.Log(encontrado.nome);
        GameObject M = elementosDoJogo.el.criature(encontrado.nome.ToString());
        Transform doCriatureAtivo = manager.CriatureAtivo.transform;
        Vector3 instancia = doCriatureAtivo.position + 10 * doCriatureAtivo.forward;
        Debug.Log(M);
        /*
		RaycastHit hit = new RaycastHit ();
			if(Physics.Linecast(posHeroi,posHeroi+10*tHeroi.forward,out hit))
		{
			instancia = hit.point+Vector3.up;
		}
        */
        melhoraPos melhoraPF = new melhoraPos();

        instancia = melhoraPF.posEmparedado(instancia, doCriatureAtivo.position);

        instancia = melhoraPF.novaPos(instancia, M.transform.lossyScale.y);

        GameObject InimigoX = MonoBehaviour.Instantiate(M, instancia, Quaternion.identity) as GameObject;

        int nivel = Random.Range(encontrado.nivelMin, encontrado.nivelMax);
        CreatureManager retorno = InimigoX.GetComponent<CreatureManager>();
        
        retorno.MeuCriatureBase
            = new CriatureBase(encontrado.nome,nivel);
        retorno.IA = new IA_Agressiva();
        retorno.IA.Start(retorno);
        retorno.Estado = CreatureManager.CreatureState.selvagem;

        return retorno;
    }
}
