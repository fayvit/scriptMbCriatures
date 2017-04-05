using UnityEngine;
using System.Collections;

public class LuvaDeGuarde : alternanciaEmLuta {


	protected elementosDoJogo elementos;
	protected Animator animator;

	protected void particulasSaiDaLuva(Transform X,string oQ = "acaoDeCura1")
	{
		GameObject volte = elementos.retorna(oQ);
		volte = Instantiate(volte,X.position,Quaternion.LookRotation(X.forward)) as GameObject;
		
		
		volte.GetComponent<ParticleSystem>().GetComponent<Renderer>().material 
			=  elementos.materiais[0];
		volte.GetComponent<ParticleSystem>().startColor = new Color(1,0.64f,0,1);

		Destroy(volte,2);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
