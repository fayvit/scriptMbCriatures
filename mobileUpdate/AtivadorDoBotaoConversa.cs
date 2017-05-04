using UnityEngine;
using System.Collections;

public class AtivadorDoBotaoConversa : AtivadorDeBotao
{
    [SerializeField]protected NPCdeConversa npc;
    private Vector3 forwardInicialDoBotao;

    // Use this for initialization
    protected void Start()
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
        Vector3 cross = Vector3.Cross(Vector3.up, dir);
        if (Vector3.Dot(cross, -Vector3.forward) < 0)
            cross *= -1;
        T.rotation = Quaternion.LookRotation(cross);
        AplicadorDeCamera.cam.InicializaCameraExibicionista(T, 1,true);
    }
}
