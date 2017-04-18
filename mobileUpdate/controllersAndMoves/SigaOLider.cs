using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[System.Serializable]
public class SigaOLider
{
    [SerializeField]private NavMeshAgent nav;
    [SerializeField]private Animator animator;

    // Use this for initialization
    public void Start(CreatureManager meuCriature)
    {
        nav = meuCriature.GetComponent<NavMeshAgent>();
        if (nav == null)
        {
            nav = meuCriature.gameObject.AddComponent<NavMeshAgent>();
            nav.stoppingDistance = nav.radius < 1 ? 5 : 2 * nav.radius;
            nav.baseOffset = 0;
            nav.speed = 7;//nav.radius < 1 ? 7 : 0;
        }
        animator = meuCriature.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update(Vector3 posAlvo)
    {
        if (nav)
        {
            nav.Resume();
            nav.destination = posAlvo;
            animator.SetFloat("velocidade", Vector3.ProjectOnPlane(nav.velocity, Vector3.up).magnitude);
        }
    }

    public void PareAgora()
    {
        //nav.destination = nav.transform.position;
        animator.SetFloat("velocidade", 0);
        if(nav.enabled)
            nav.Stop();
    }
}
