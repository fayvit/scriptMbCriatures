using UnityEngine;
using System.Collections;

public class amedrontado : statusTemporarioSimples {


	// Use this for initialization
	new void Start () {

		forcaDoDano = Random.Range(0,11);
		esseStatus = tipoStatus.amedrontado;



		nomeParticula = "particulasAmedrontado";

		base.Start();



		//animator = GetComponent<Animator>();
		//textos = bancoDeTextos.falacoes[heroi.lingua]["status"].ToArray();
	}

}
