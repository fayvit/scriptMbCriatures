using UnityEngine;
using System.Collections;

public class AtualizadorDeImpactos
{
    private bool procurouAlvo = false;
    private bool addView = false;
    private float tempoDecorrido = 0;
    private Transform alvoProcurado;
    private CharacterController controle;

    public void ReiniciaAtualizadorDeImpactos()
    {
        tempoDecorrido = 0;
        addView = false;
    }

    void ajudaAtaque(Transform alvo,Transform T)
    {

        Vector3 gira = Vector3.zero;
        if (alvo != null)
        {
            gira = alvo.position - T.position;

            gira.y = 0;
            T.rotation = Quaternion.LookRotation(gira);

        }
    }

    public void ImpatoAtivo(GameObject G,IGolpeBase ativa,CaracteristicasDeImpacto caracteristica)
    {
        tempoDecorrido += Time.deltaTime;
        if (!procurouAlvo)
            alvoProcurado = CriaturesPerto.procureUmBomAlvo(G);

        if (tempoDecorrido > ativa.TempoDeMoveMin  && !addView)
        {

            ColisorDeGolpe.AdicionaOColisor(G,ativa,caracteristica,tempoDecorrido);

            addView = true;

        }

        if (tempoDecorrido < ativa.TempoDeMoveMax && tempoDecorrido > ativa.TempoDeMoveMin)
        {
            if (((int)(tempoDecorrido * 10)) % 2 == 0 && alvoProcurado)
                ajudaAtaque(alvoProcurado,G.transform);

            if (!controle)
                controle = G.GetComponent<CharacterController>();
            controle.Move(ativa.VelocidadeDeGolpe * G.transform.forward * Time.deltaTime + Vector3.down * 9.8f);
        }
    }
}

public struct CaracteristicasDeImpacto
{
    public string nomeTrail;
    public string noImpacto;
    public bool parentearNoOsso;

    public CaracteristicasDeImpacto(Trails trail,NoImpacto noImpacto,bool parentearOsso)
    {
        nomeTrail = trail.ToString();
        this.noImpacto = noImpacto.ToString();
        this.parentearNoOsso = parentearOsso;
    }
}

public enum Trails
{
    umCuboETrail,
    tresCubos
}

public enum NoImpacto
{
    impactoComum,
    impactoDeFolhas
}
