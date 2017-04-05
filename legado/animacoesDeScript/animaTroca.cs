using UnityEngine;
using System.Collections;

public class animaTroca : LuvaDeGuarde {

	public string alvo = "CriatureAtivo";
	public GameObject meuHeroi;

	private float tempoDeAnima;
	private uint faseDaAnima = 1;
	private Vector3 instancia;
	private GameObject criatureAlvo;


	public bool troca = true;
	// Use this for initialization
	void Start () {
		tempoDeAnima = 0;
		elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		if(!meuHeroi)
			meuHeroi = GameObject.FindGameObjectWithTag("Player");
		criatureAlvo = GameObject.Find(alvo);
		Transform meuCriature = criatureAlvo.transform;
		Animator animator = meuHeroi.GetComponent<Animator> ();
		animator.SetBool ("chama",true);
		Vector3 posSegura = new Vector3 ((meuCriature.position - meuHeroi.transform.position).x, 0, (meuCriature.position - meuHeroi.transform.position).z);
		meuHeroi.transform.rotation = Quaternion.LookRotation(posSegura);
	}
	
	// Update is called once per frame
	void Update () {
		Transform X;
		tempoDeAnima += Time.deltaTime;
		if(criatureAlvo)
			X = criatureAlvo.transform;
		else
			X = null;

		if(tempoDeAnima>1.05f && faseDaAnima==1)
		{
			setarInstancia();

			GameObject luz = elementos.retorna("particulaLuvaDeGuarde");
			Object luz2 = Instantiate(luz,instancia,Quaternion.identity);

			faseDaAnima = 2;
			tempoDeAnima = 0;

			luz2.name = "luz";
		}else if(faseDaAnima == 2)
		{
			Vector3 posCriature = criatureAlvo.transform.position;
			GameObject raio = elementos.retorna("raioDeLuvaDeGuarde");
			Object raio2 = Instantiate(raio,instancia,Quaternion.LookRotation(
				 posCriature - instancia
				));
			raio2.name = "raio";
			ParticleSystem P = GameObject.Find("raio").GetComponent<ParticleSystem>();
			P.startSpeed*=(posCriature - instancia).magnitude*2;
			faseDaAnima = 3;

		}else if(faseDaAnima == 3 && tempoDeAnima>0.5f && X.localScale.sqrMagnitude>0.01f)
		{
			/*
			GameObject volte = elementos.retorna("acaoDeCura1");
			Object volte1 = Instantiate(volte,X.position,Quaternion.LookRotation(X.forward));
			volte1.name = "volte1";
			GameObject volte2 = GameObject.Find("volte1");
			volte2.GetComponent<ParticleSystem>().renderer.material 
				=  elementos.materiais[0];
			volte2.GetComponent<ParticleSystem>().startColor = new Color(1,0.64f,0,1);
			*/
			particulasSaiDaLuva(X);
			faseDaAnima = 4;
			tempoDeAnima = 0;

		}else if(faseDaAnima == 4 && tempoDeAnima <1f)
		{
			if(troca)
				X.localScale = Vector3.Lerp(X.localScale,Vector3.zero,2*Time.deltaTime);
		}else if(faseDaAnima ==4 && tempoDeAnima>1f){
			faseDaAnima = 5;
			tempoDeAnima = 0;
		}else if(faseDaAnima == 5 && tempoDeAnima<0.25f)
		{
			if(troca)
				Destroy(criatureAlvo);
			Destroy(GameObject.Find("volte1"));
			ParticleSystem P = GameObject.Find("raio").GetComponent<ParticleSystem>();
			P.startSpeed = Mathf.Lerp(P.startSpeed,0,10*Time.deltaTime);
			P.startLifetime = Mathf.Lerp(P.startLifetime,0,10*Time.deltaTime);//*=(posCriature - instancia).magnitude*2;
		}else if(faseDaAnima == 5&& tempoDeAnima>0.25f)
		{

			Destroy(GameObject.Find("raio"));
			Destroy(GameObject.Find("luz"));

			Destroy(this);
		}


	}

	void setarInstancia()
	{
		string nomeEsqueleto = meuHeroi.tag=="Player"?"esqueletodoCorean":"metarig";
		
		instancia = meuHeroi
			.transform.Find(nomeEsqueleto+"/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_02_R")
				.transform.position;
	}
}
