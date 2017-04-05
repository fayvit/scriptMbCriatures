using UnityEngine;
using System.Collections;

public class projetilStatusExpansivel : Iprojetil{


	float Yinicial;
	float alturaInicial;
	// Use this for initialization
	void Start () {
		Yinicial = transform.position.y;
		quaternionDeImpacto();
		alturaInicial = GetComponent<BoxCollider>().size.y;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += velocidadeProjetil* transform.forward*Time.deltaTime;	
		transform.localScale = Vector3.Lerp(transform.localScale,new Vector3(20,20,1),3*Time.deltaTime);
		transform.position = new Vector3(transform.position.x,
		                                 Yinicial+(transform.localScale.y-1)*alturaInicial/4,
		                                 transform.position.z);
	}

	void OnTriggerEnter(Collider emQ)
	{
		if(emQ.gameObject!=dono && emQ.tag == "Criature")
			facaImpacto(emQ.gameObject,true,false,true);
	}

}
