using UnityEngine;
using System.Collections;

public class ColisorDeDanoBase : MonoBehaviour
{

    public float velocidadeProjetil = 6f;
    public GameObject dono;
    public string noImpacto;
    public IGolpeBase esseGolpe;

    protected Quaternion Qparticles;

    protected void funcaoTrigger(Collider emQ)
    {
        
        if (emQ.gameObject != dono
           &&
           ((emQ.tag != "cenario" && emQ.gameObject.layer != 2) /*|| velocidadeProjetil > 0*/)
           &&
           emQ.tag != "desvieCamera")
        {
            facaImpacto(emQ.gameObject);

        }


    }

    protected void quaternionDeImpacto()
    {

        switch (noImpacto)
        {
            /*
		case "ImpactoDeFogo":
			Qparticles  =Quaternion.LookRotation(Vector3.up);
		break;
		*/
            case "impactoComum":
            case "impactoDeVento":
            case "impactoDeGosma":
            case "impactoDeGosmaAcida":
            case "impactoDeFogo":
                Qparticles = Quaternion.LookRotation(dono.transform.forward);
                break;
            default:
                Qparticles = Quaternion.LookRotation(Vector3.up);
                break;
        }


    }

    protected void facaImpacto(GameObject emQ, bool colocaImpactos = false, bool destroiAqui = true, bool noTransform = false)
    {
        /*
        Precisaser reformulado
        if (emQ.gameObject.tag == "eventoComGolpe")
        {
            eventoComGolpe eCG = emQ.GetComponent<eventoComGolpe>();
            acaoDeGolpe aG2 = dono.GetComponent<acaoDeGolpe>();
            if (eCG && aG2)
                eCG.disparaEvento(aG2.ativa.nomeID);

        }*/

        GameObject impacto = elementosDoJogo.el.retorna(noImpacto);
        

        if (!noTransform)
            impacto = (GameObject)Instantiate(impacto, transform.position, Qparticles);

        if (emQ.tag == "Criature")
        {
            Atributos A = emQ.GetComponent<CreatureManager>().MeuCriatureBase.CaracCriature.meusAtributos;
            if (A!=null)
                if (A.PV.Corrente > 0)

                    Dano.VerificaDano(emQ, dono, esseGolpe);

            if (noTransform)
                impacto = (GameObject)Instantiate(impacto, emQ.transform.position, Qparticles);

                /*
                if (colocaImpactos)
                    aG.impactos++;
                    */
                    
        }

        if (impacto)
            Destroy(impacto, 1.5f);
        if (destroiAqui)
            Destroy(gameObject);
    }
}
