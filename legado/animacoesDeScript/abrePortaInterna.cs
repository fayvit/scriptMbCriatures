using UnityEngine;
using System.Collections;

public class abrePortaInterna : MonoBehaviour {
	public Transform baseDaPorta;

	private Transform tHeroi;
	private movimentoBasico mB;

	private bool podeAbrir = false;
	private bool estaAberta = false;
	private bool estaAbrindo = false;

	private int dir = 1;
	private float tempoComPortaAberta = 0;
	// Use this for initialization
	void Start () {
		tHeroi = GameObject.FindWithTag("Player").transform;
		mB = tHeroi.GetComponent<movimentoBasico>();
	}
	
	// Update is called once per frame
	void Update () {
		//print(Vector3.Distance(transform.position,tHeroi.position)+" : "+podeAbrir);
		if(mB.podeAndar && mB.enabled && podeAbrir && Vector3.Distance(transform.position,tHeroi.position)<16)
		{
			if(Input.GetButtonDown("acao"))
			{
				estaAbrindo = true;
				if(Vector3.Dot(transform.position-tHeroi.position,transform.forward)>0)
					dir = 1;
				else
					dir = -1;
			}
		}

		if(Vector3.Distance(transform.position,tHeroi.position)>20)
			podeAbrir = false;

		if(estaAbrindo)
		{
			if(!estouAbrindoAPorta(transform,baseDaPorta,1,dir))
			{
				estaAbrindo = false;
				estaAberta = true;
			}
		}

		if(estaAberta)
		{
			tempoComPortaAberta+=Time.deltaTime;
			if(tempoComPortaAberta>5f)
			{
				if(!estouFechandoAPorta(transform,baseDaPorta,1,dir))
				{
					tempoComPortaAberta=0;
					estaAberta = false;
				}
			}
		}
	}

	public static bool estouFechandoAPorta(Transform porta,Transform baseDaPorta,int deComparacao = 0,int dir = 1)
	{
		Vector3 comparavel = vetorComparavel(porta,deComparacao,dir);
		if(Vector3.Angle(comparavel,Vector3.up)<90)
			porta.RotateAround(baseDaPorta.position,baseDaPorta.up,-dir*25*Time.deltaTime);
		else{
			return false;
		}
		
		return true;
	}

	static Vector3 vetorComparavel(Transform T,int deComparacao,int dir)
	{
		/*
			Apliquei a funçao estouAbrindoAPOrta em dois blocos 
			que tinham o forward apontando para direçoes diferentes
			entao precisei saber com qual vetor comparar para parar o giro
		 */


		Vector3 retorno = T.up;
		
		switch(deComparacao)
		{
		case 0:
			retorno = T.up; 
		break;
		case 1:
			retorno = dir*T.forward;
		break;
		}

		return retorno;
	}

	public static bool estouAbrindoAPorta(Transform porta,Transform baseDaPorta,int deComparacao = 0,int dir = 1)
	{
		Vector3 V = porta.position-4*Vector3.up;
		Vector3 comparavel = vetorComparavel(porta,deComparacao,dir);

		if(((int)Vector3.Angle(comparavel,Vector3.up))%7==0)
		for(int i = 0;i<5;i++)
		{
		
			Destroy(Instantiate(
				elementosDoJogo.el.retorna("poeiraAoVento"),
				V+i*2*
				((deComparacao==0 && dir==1)?baseDaPorta.forward:baseDaPorta.up),
				Quaternion.identity
				),2);
			Destroy(Instantiate(
				elementosDoJogo.el.retorna("poeiraAoVento"),
				V-i*2*
				((deComparacao==0 && dir==1)?baseDaPorta.forward:baseDaPorta.up),
				Quaternion.identity
				),2);
		}


		if(Vector3.Angle(comparavel,Vector3.up)>1)
			porta.RotateAround(baseDaPorta.position,
			  (deComparacao==0)?-baseDaPorta.forward : baseDaPorta.up,dir*25*Time.deltaTime);
		else{
			return false;
		}

		return true;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag=="Player"&&Vector3.Distance(transform.position,tHeroi.position)<16)
		{
			podeAbrir = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag=="Player")
		{
			podeAbrir = false;
		}
	}
}
