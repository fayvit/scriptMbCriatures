using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoConversa : AtivadorDeBotao
{
    [SerializeField]private NPCdeConversa npc;
    private Vector3 forwardInicialDoBotao;

    // Use this for initialization
    void Start()
    {
        npc.Start(transform);
        forwardInicialDoBotao = btn.transform.parent.forward;
        SempreEstaNoTrigger();
    }

    new protected void Update()
    {
        base.Update();

        if (btn.activeSelf)
            btn.transform.parent.forward = forwardInicialDoBotao;

        if (npc.Update())
        {
            GameController.g.Manager.AoHeroi();
        }
    }

    public void BotaoConversa()
    {
        FluxoDeBotao();
        
        Vector3 dir = GameController.g.Manager.transform.position - transform.position;
        dir = Vector3.ProjectOnPlane(dir, Vector3.up);
        transform.rotation = Quaternion.LookRotation(dir);

        Transform T = new GameObject().transform;
        npc.IniciaConversa(T);
        T.position = transform.position + 0.5f * dir+2*Vector3.up;
        T.rotation = Quaternion.LookRotation(-Vector3.Cross(Vector3.up,dir));
        AplicadorDeCamera.cam.InicializaCameraExibicionista(T, 1,true);
    }
}
