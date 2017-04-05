using UnityEngine;
using System.Collections;

public class testeDeAtaqueInimigo : MonoBehaviour {
	//Transform Xuash;
//	float coolDown = 1f;
	// Use this for initialization
	void Start () {
		//Xuash = GameObject.Find ("Xuash").transform;

		/*
		umCriature umC = GetComponent<umCriature>();
		print(umC.nomeCriature);
		GameObject G = GameObject.Find("elementosDoJogo")
			.GetComponent<elementosDoJogo>()
				.retorna(umC.nomeCriature.ToString(),"criature");
		G =	Instantiate(G,
		                new melhoraPos().novaPos( transform.position+transform.right),
		                Quaternion.identity) as GameObject;*/

		print(bancoDeTextos.falacoes.Keys.Count);


	}

	void Update()
	{
		//transform.position +=transform.forward*25*Time.deltaTime; 
	}
	/*
	void aplicaGolpe(golpe G,Vector3 emissor)
	{
		if(G.UltimoUso < Time.time -  G.TempoReuso){
			G.UltimoUso = Time.time;
			acaoDeGolpe acao = gameObject.AddComponent<acaoDeGolpe> ();
			acao.ativa = G;
			acao.emissor = emissor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		umCriature criature = GetComponent<umCriature>();
		coolDown -= Time.deltaTime;
		if(coolDown <= 0 && criature.criature().cAtributos[0].Corrente>0)
		{
			aplicaGolpe(criature.X.Golpes[0], 
			            transform.Find(criature.X.emissor).position
			            +transform.forward*criature.X.Golpes[0].DistanciaDeEmissao);
			coolDown = 2f;
		}
	
	}
	*/

	/*
	public float pushPower = 2.0F;
	void OnCollisionEnter(Collision collision)
	{
		print(collision.transform.name);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		print("algo");
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}
	*/
}
