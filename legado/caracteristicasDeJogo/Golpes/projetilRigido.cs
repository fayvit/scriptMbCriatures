using UnityEngine;
using System.Collections;

public class projetilRigido : Iprojetil {


	private Vector3 dirInicial;

	// Use this for initialization
	void Start () {
		dirInicial = transform.forward;
		quaternionDeImpacto();
	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position += velocidadeProjetil* transform.forward*Time.deltaTime;	
		if(GetComponent<Rigidbody>().velocity.magnitude<velocidadeProjetil)
			GetComponent<Rigidbody>().AddForce(10*velocidadeProjetil*dirInicial);
	}
	
	void OnCollisionEnter(Collision emQ)
	{
		if(emQ.gameObject != dono){
			if(emQ.gameObject.tag=="Criature"){
				facaImpacto(emQ.gameObject,true);
//				print(emQ.transform.name);	
			}

		foreach(ContactPoint P in emQ.contacts )
			{
				if(Vector3.Angle(P.normal,Vector3.up)>75)
				{
					facaImpacto(emQ.gameObject,true);
				}
			}
	}
	}

}
