using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(NavMeshAgent))]
public class sigaOLider : MonoBehaviour {

	public Transform lider;
	public UnityEngine.AI.NavMeshAgent caminhos;

	private Animator animator;

	// Use this for initialization
	void Start () {
		if(!lider)
			lider = GameObject.FindGameObjectWithTag("Player").transform;
		if(!caminhos)
			caminhos = transform.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		if (GetComponent<Animator> ())
						animator = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
//		print(lider);
		if(lider)
			caminhos.destination = lider.position;
		else
			caminhos.destination = transform.position;
		animator.SetFloat ("velocidade", caminhos.velocity.sqrMagnitude );
	}
}
