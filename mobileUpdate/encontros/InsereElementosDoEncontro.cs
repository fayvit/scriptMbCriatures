using UnityEngine;
using System.Collections;

public class InsereElementosDoEncontro
{
    
    public static void encontroPadrao(CharacterManager manager)
    {
        animacaoDeEncontro(manager.transform.position);
        adicionaCilindroEncontro(manager.transform.position);
        alternanciaParaCriature(manager);
        impedeMovimentoDoCriature(manager.CriatureAtivo);
        alteraPosDoCriature(manager);    
        colocaOHeroiNaPOsicaoDeEncontro(manager);        

    }

    protected static void animacaoDeEncontro(Vector3 posHeroi)
    {
        heroi.emLuta = true;
        GameObject anima = elementosDoJogo.el.retorna("encontro");

        MonoBehaviour.Destroy(MonoBehaviour.Instantiate(anima, posHeroi, Quaternion.identity),2);
    }

    protected static void adicionaCilindroEncontro(Vector3 posHeroi)
    {
        GameObject cilindro = elementosDoJogo.el.retorna("cilindroEncontro");
        Object cilindro2 = MonoBehaviour.Instantiate(cilindro, posHeroi, Quaternion.identity);
        cilindro2.name = "cilindroEncontro";
    }

    protected static void alteraPosDoCriature(CharacterManager manager)
    {
        GameObject  X = GameObject.Find("CriatureAtivo");

        X.transform.position = manager.transform.position;//new melhoraPos().novaPos(posHeroi,X.transform.lossyScale.y);
        X.transform.rotation = manager.transform.rotation;
    }


    protected static void alternanciaParaCriature(CharacterManager manager)
    {
        manager.AoCriature();
    }

    protected static void impedeMovimentoDoCriature(CreatureManager C)
    {
        
        C.Estado = CreatureManager.CreatureState.parado;
    }

    protected static void colocaOHeroiNaPOsicaoDeEncontro(CharacterManager manager)
    {
        manager.transform.position = novaPos(manager);//40f * tHeroi.forward;


        manager.gameObject.AddComponent<gravidadeGambiarra>();
    }

    static Vector3 novaPos(CharacterManager manager)
    {
        RaycastHit hit = new RaycastHit();
        string nomeDoTerreno = "Terrain";
        if (Physics.Raycast(manager.transform.position, Vector3.down, out hit))
        {
            nomeDoTerreno = hit.collider.name;
        }
        Vector3 retorno = manager.transform.position - 40f * manager.transform.forward;
        retorno = new melhoraPos().posEmparedado(retorno, manager.transform.position);
        float saoSalvador = manager.GetComponent<CharacterController>().height;
        retorno = emBuscaDeUmaBoaPosicao(retorno, saoSalvador, nomeDoTerreno);

        return retorno;
    }

    static Vector3 emBuscaDeUmaBoaPosicao(Vector3 pontoInicial, float PQP, string terreno = "Terrain")
    {
        Vector3 retorno = pontoInicial;
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(pontoInicial + PQP * Vector3.up, -Vector3.up, out hit))
        {
            if (hit.transform.name == terreno)
            {
                retorno = hit.point + 2f * Vector3.up;
                
            }
        }
        else if (Physics.Raycast(pontoInicial - PQP * Vector3.up, Vector3.up, out hit))
            if (hit.transform.name == terreno)
            {
                retorno = hit.point + 2f * Vector3.up;
                
            }
        return retorno;
    }
}
