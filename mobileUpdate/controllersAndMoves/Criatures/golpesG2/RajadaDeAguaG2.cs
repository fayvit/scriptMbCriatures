﻿using UnityEngine;
public class RajadaDeAguaG2 : GolpeBase
{
    public RajadaDeAguaG2() : base(new ContainerDeCaracteristicasDeGolpe()
    {
        nome = nomesGolpes.rajadaDeAgua,
        tipo = nomeTipos.Agua,
        carac = caracGolpe.projetil,
        custoPE = 1,
        potenciaCorrente = 2,
        potenciaMaxima = 7,
        potenciaMinima = 1,
        tempoDeReuso = 5,
        tempoDeMoveMax = 1 ,
        tempoDeMoveMin = 0,
        tempoDeDestroy = 2,
        TempoNoDano = 0.75f       
    }
        )
    {
        
    }


    /****************************************************
    
        Essas variaveis são relacionadas com a ação de Golpe

    */
    private Vector3 posInicial;
    private Vector3 forwardInicial;
    private float tempoDecorrido = 0;
    private int impactos = 0;
    private bool addView = false;
    private RaycastHit hit;

    /********************************************************/
    public override void IniciaGolpe(GameObject G)
    {
        impactos = 0;
        addView = false;
        tempoDecorrido = 0;
        posInicial = Emissor.UseOEmissor(G, this.Nome);
        forwardInicial = G.transform.forward;        
        AnimadorCriature.AnimaAtaque(G, "emissor");         
    }

    public override void UpdateGolpe(GameObject G)
    {
        if (!addView)
        {
            AuxiliarDeInstancia.InstancieEDestrua(Nome, posInicial, forwardInicial, TempoDeDestroy);
            addView = true;
        }

        hit = new RaycastHit();
        tempoDecorrido += Time.deltaTime;
        Vector3 ort = Vector3.Cross(forwardInicial, Vector3.up).normalized;

        float deslocadorInicial = tempoDecorrido > 1 ? tempoDecorrido : 1;
        float deslocadorFinal = tempoDecorrido < 0.7f ? tempoDecorrido : 0.7f;
        if (tempoDecorrido < TempoDeDestroy)
        {
            Debug.DrawLine(posInicial + 25 * (deslocadorInicial - 1) * forwardInicial, posInicial + forwardInicial * 25 * deslocadorFinal, Color.red);
            Debug.DrawLine(
                posInicial + 25 * (deslocadorInicial - 1) * forwardInicial + 0.25f * Vector3.up,
                posInicial + 0.25f * Vector3.up + forwardInicial * 25 * deslocadorFinal,
                Color.red);
            Debug.DrawLine(
                posInicial + 25 * (deslocadorInicial - 1) * forwardInicial - 0.25f * Vector3.up,
                posInicial - 0.25f * Vector3.up + forwardInicial * 25 * deslocadorFinal,
                Color.red);
            Debug.DrawLine(
                posInicial + 25 * (deslocadorInicial - 1) * forwardInicial - 0.25f * ort,
                posInicial - 0.25f * ort + forwardInicial * 25 * deslocadorFinal,
                Color.red);


            if (Physics.Linecast(posInicial + 25 * (deslocadorInicial - 1) * forwardInicial, posInicial + forwardInicial * 25 * tempoDecorrido, out hit)
               ||
               Physics.Linecast(
                posInicial + 25 * (deslocadorInicial - 1) * forwardInicial - 0.25f * Vector3.up,
                posInicial - 0.25f * Vector3.up + forwardInicial * 25 * tempoDecorrido,
                out hit)
               ||
               Physics.Linecast(
                posInicial + 25 * (deslocadorInicial - 1) * forwardInicial - 0.25f * ort,
                posInicial - 0.25f * ort + forwardInicial * 25 * tempoDecorrido,
                out hit)
               ||
               Physics.Linecast(
                posInicial + 25 * (deslocadorInicial - 1) * forwardInicial + 0.25f * ort,
                posInicial + 0.25f * ort + forwardInicial * 25 * tempoDecorrido,
                out hit)

               )
            {
                if (impactos % 10 == 0)
                {
                    GameObject Golpe = elementosDoJogo.el.retorna(DoJogo.impactoDeAgua);
                    Object impacto = MonoBehaviour.Instantiate(Golpe, hit.point, Quaternion.identity);
                    MonoBehaviour.Destroy(impacto, 0.5f);

                    if (impactos == 0)
                        Dano.VerificaDano(hit.transform.gameObject, G, this,forwardInicial);

                }
                impactos++;
            }
        }
    }
}
