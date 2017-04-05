using UnityEngine;
using System.Collections;

public abstract class pergaminhoComTransporte : MonoBehaviour {
	

	public Color C = Color.white;
	
	
	protected Transform T;
	private float tempoDecorrido = 0;
	private faseDaSaida fase = faseDaSaida.instanciandoGeiserCriature;
	
	enum faseDaSaida
	{
		instanciandoGeiserCriature,
		
		instanciandoGeiserPersonagem,
		
		
	}
	
	// Use this for initialization
	protected virtual void Start () {
		T = GameObject.Find("CriatureAtivo").transform;
		T.GetComponent<umCriature>().enabled = false;
		T.GetComponent<sigaOLider>().enabled = false;
		T.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
		GameObject geiser = (GameObject)Instantiate(
			elementosDoJogo.el.retorna("geiserDeEnergia"),
			T.position,
			elementosDoJogo.el.retorna("geiserDeEnergia").transform.rotation);
		
		if(C!=Color.white)
		{
			ParticleSystem P = geiser.GetComponent<ParticleSystem>();
			P.startColor = C;
		}
		Destroy(geiser,3);
	}
	
	// Update is called once per frame
	void Update () {
		tempoDecorrido+=Time.deltaTime;
		
		switch(fase)
		{
		case faseDaSaida.instanciandoGeiserCriature:
			T.position+=0.4f*Time.deltaTime*Vector3.up;
			if(tempoDecorrido>2)
			{
				SkinnedMeshRenderer[] sKs =  T.GetComponentsInChildren<SkinnedMeshRenderer>();
				foreach(SkinnedMeshRenderer sk in sKs)
					sk.enabled = false;
				
				T = GameObject.FindWithTag("Player").transform;
				T.GetComponent<CharacterController>().enabled = false;
				GameObject geiser = (GameObject)Instantiate(
					elementosDoJogo.el.retorna("geiserDeEnergia"),
					T.position,
					elementosDoJogo.el.retorna("geiserDeEnergia").transform.rotation);

				if(C!=Color.white)
				{
					ParticleSystem P = geiser.GetComponent<ParticleSystem>();
					P.startColor = C;
				}
				Destroy(geiser,3);
				fase = faseDaSaida.instanciandoGeiserPersonagem;
				tempoDecorrido = 0;
			}
			break;
		case faseDaSaida.instanciandoGeiserPersonagem:
			T.position+=0.4f*Time.deltaTime*Vector3.up;
			if(tempoDecorrido>2)
			{
				SkinnedMeshRenderer[] sKs =  T.GetComponentsInChildren<SkinnedMeshRenderer>();
				foreach(SkinnedMeshRenderer sk in sKs)
					sk.enabled = false;
				
				if(tempoDecorrido>2)
				{
					acaoDoItem();
				}
				tempoDecorrido = 0;
				
				
			}
			break;
		}
	}

	protected abstract void acaoDoItem();
}
