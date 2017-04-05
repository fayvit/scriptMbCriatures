using UnityEngine;
using System.Collections;

public class projetil : Iprojetil{

	// Use this for initialization
	void Start () {
		quaternionDeImpacto();
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += velocidadeProjetil* transform.forward*Time.deltaTime;	
	}

	void OnTriggerEnter(Collider emQ)
	{
		funcaoTrigger(emQ);
	}

}
