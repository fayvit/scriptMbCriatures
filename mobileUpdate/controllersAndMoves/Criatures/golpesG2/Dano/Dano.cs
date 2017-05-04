using UnityEngine;
using System.Collections;

public class Dano
{

    public static void VerificaComportamentoDeIA(CreatureManager GdC,GameObject atacante)
    {
        /*
        if (!GdC.gerenteCri)
        {
            GerenciadorDeIA GdIA = GdC.GetComponent<GerenciadorDeIA>();
            
            
            if (GdIA)
            {
                CreatureManager gDoAtacante = atacante.GetComponent<CreatureManager>();
                if (gDoAtacante.gerenteCri)
                {
                    GdIA.FuiAtacadoPor(gDoAtacante);
                }
            }
        }*/
    }

    public static void VerificaDano(GameObject atacado,GameObject atacante,IGolpeBase golpe)
    {
        Vector3 dirDano = golpe.DirDeREpulsao;
        CreatureManager GdC = atacado.GetComponent<CreatureManager>();
        if (GdC && !GameController.g.UsandoItemOuTrocandoCriature)
        {
            if (GdC.MeuCriatureBase.CaracCriature.meusAtributos.PV.Corrente > 0)
            {
                AplicaDano(GdC,atacante,golpe,dirDano);
                VerificaComportamentoDeIA(GdC,atacante);
            }
        }
    }

    public static void AplicaDano(CreatureManager doAtacado,GameObject atacante,IGolpeBase golpe,Vector3 dirDano)
    {
        doAtacado.Estado = CreatureManager.CreatureState.emDano;
        //Transform T = doAtacado.transform;
        Animator animatorDoAtacado = doAtacado.GetComponent<Animator>();
      //  doAtacado.MudaEmDano();

        animatorDoAtacado.Play("dano2");
        animatorDoAtacado.SetBool("dano1", true);
        animatorDoAtacado.Play("dano1");

        CalculaDano(doAtacado,atacante,golpe);

        EstouEmDano eED =  doAtacado.gameObject.AddComponent<EstouEmDano>();
        eED.esseGolpe = golpe;
        eED.animator = animatorDoAtacado;
        eED.gerente = doAtacado;
        eED.direcaoDoDano = dirDano;

        VerificaVida(atacante,doAtacado,animatorDoAtacado);
    }

    static void VerificaVida(GameObject atacante,CreatureManager doAtacado,Animator a)
    {
        if (doAtacado.MeuCriatureBase.CaracCriature.meusAtributos.PV.Corrente <= 0)
        {
            a.SetBool("cair", true);

            sigaOLider s = a.GetComponent<sigaOLider>();
            if (s)
                s.enabled = false;

            UnityEngine.AI.NavMeshAgent nav = a.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (nav.enabled)
                nav.Stop();// nav.isStopped = true;
            
         /*   doAtacado.MudaParaDerrotado();

            if (!doAtacado.gerenteCri)
            {
                AplicaSelvagemDerrotado aSD =  doAtacado.gameObject.AddComponent<AplicaSelvagemDerrotado>();
                aSD.oDerrotado = doAtacado;
                aSD.oQDerrotou = atacante.GetComponent<GerenciadorDeCriature>();

            }
            else
            {
                //Morte de um criature selvagem
            }
            */
        }
    }

    static void CalculaDano(CreatureManager doAtacado, GameObject atacante, IGolpeBase golpe)
    {
        float multiplicador = 1;

        for (int i = 0; i < doAtacado.MeuCriatureBase.CaracCriature.contraTipos.Length; i++)
        {
            if (golpe.Tipo.ToString() == doAtacado.MeuCriatureBase.CaracCriature.contraTipos[i].Nome)
            {
                multiplicador *= doAtacado.MeuCriatureBase.CaracCriature.contraTipos[i].Mod;
            }
        }

        CriatureBase cDoAtacante = atacante.GetComponent<CreatureManager>().MeuCriatureBase;
        Atributos A = cDoAtacante.CaracCriature.meusAtributos;

        int potenciaDoAtacante = (golpe.Caracteristica == caracGolpe.colisao)
            ?
                Mathf.RoundToInt(A.Ataque.Minimo + (A.Ataque.Corrente - A.Ataque.Minimo) * Random.Range(0.85f, 1))
            :
                Mathf.RoundToInt(A.Poder.Minimo + (A.Poder.Corrente - A.Poder.Minimo) * Random.Range(0.85f, 1));

        GolpePersonagem golpePersonagem =  cDoAtacante.GerenteDeGolpes.ProcuraGolpeNaLista(cDoAtacante.NomeID, golpe.Nome);

        int dano = Mathf.Abs(
            Mathf.RoundToInt(
                multiplicador * (golpe.PotenciaCorrente 
                            + golpePersonagem.ModPersonagem 
                            + potenciaDoAtacante)
                            ));

        potenciaDoAtacante = dano;//apenas para exibir no print a potencia original do golpe sem a defesa

        Atributos aDoAtacado = doAtacado.MeuCriatureBase.CaracCriature.meusAtributos;

        int defesa = Mathf.RoundToInt(aDoAtacado.Defesa.Corrente * Random.Range(0.85f,1));

        if (defesa < 0.75f * dano)
            dano =(dano-defesa>=1)?dano- defesa:1;
        else
            dano = (int)(0.25f * dano) >=1  ? Mathf.Max((int)(0.25f * dano*Random.Range(0.9f,1.15f)),1) : 1;

        /*
        if (dano > golpe.DanoMaximo && multiplicador <= 1)
            dano = golpe.DanoMaximo;
        else if (dano > multiplicador * golpe.DanoMaximo)
        {
            int mudaUmPoco = Random.Range(-1, 2);
            Debug.Log(mudaUmPoco);
            dano = Mathf.Max((int)(multiplicador * golpe.DanoMaximo) + mudaUmPoco, 1);
        }*/

        /*
        if (elementos == null)
            elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();

        mostraDano(elementos, T, dano);*/

        AplicaCalculoDoDano(aDoAtacado, dano);
        Debug.Log("O dano do GOlpe e " + dano + " O nome do golpe e " + golpe.Nome + " o multiplicador e" + multiplicador
            +" A defesa do inimigo é "+defesa
            +" A potencia original é "+potenciaDoAtacante);

        /*
        if (X.cAtributos[0].Corrente > 0)
            aplicaStatus(T, X, ativa, Y);
            */
    }

    static void AplicaCalculoDoDano(Atributos A, int dano)
    {
        if (A.PV.Corrente - dano > 0)
            A.PV.Corrente -= dano;
        else
            A.PV.Corrente = 0;
    }


}
