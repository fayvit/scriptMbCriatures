using UnityEngine;
using System.Collections;

public class animaEnvia : LuvaDeGuarde {
	public Vector3 posCriature;
	public nomesCriatures oInstanciado;
	public GameObject oQEnvia;

	private float tempoDeAnima =0;
	private int faseDaAnima = 1;
	private Vector3 instancia;


	// Use this for initialization
	void Start () {
		elementos = elementosDoJogo.el;
	}
	
	// Update is called once per frame
	void Update () {



		Transform X;
		tempoDeAnima += Time.deltaTime;

		if(oQEnvia)
		{
			if(GameObject.Find("inimigo"))
				X = GameObject.Find("inimigo").transform;
			else
				X = null;
		}else
		{
			if(GameObject.Find("CriatureAtivo"))
				X = GameObject.Find("CriatureAtivo").transform;
			else
				X = null;
		}
		
		if(tempoDeAnima>1.2f && faseDaAnima==1)
		{
			if(oQEnvia != null)
			{
				instancia = oQEnvia.transform
					.Find("metarig/hips/spine/chest/shoulder_L/upper_arm_L/forearm_L/hand_L/palm_02_L")
						.transform.position;
			}else
			instancia = GameObject.FindWithTag("Player")
				.transform.Find("esqueletodoCorean/hips/spine/chest/shoulder_L/upper_arm_L/forearm_L/hand_L/palm_02_L")
					.transform.position;

			GameObject luz = elementos.retorna("particulaLuvaDeGuarde");
			Object luz2 = Instantiate(luz,instancia,Quaternion.identity);
			faseDaAnima = 2;
			tempoDeAnima = 0;
			luz2.name = "luz";
		}else if(faseDaAnima == 2 )
		{
			faseDaAnima = 3;
			GameObject raio = elementos.retorna("raioDeLuvaDeGuarde");
			raio = Instantiate(raio,instancia,Quaternion.LookRotation(
				posCriature - instancia
				))as GameObject;
			raio.name = "raio";
			ParticleSystem P = raio.GetComponent<ParticleSystem>();
			P.startSpeed*=(posCriature - instancia).magnitude*2;




			
		}else if(faseDaAnima == 3 && tempoDeAnima>0.5f )
		{
			GameObject X1 = elementos.criature(oInstanciado.ToString());
			
			//Vector3 lrot = new Vector3((posH-posCriature).x,0, (posH-posCriature).z);
			posCriature = new melhoraPos().novaPos(posCriature,X1.transform.lossyScale.y);



			X1 = Instantiate(X1,posCriature,Quaternion.identity) as GameObject;//.LookRotation(posH-posCriature) );



			if(oQEnvia != null)
			{
				X1.name = "inimigo"	;
			}else
			{
				X1.name = "CriatureAtivo";

				if(!X1.GetComponent<umCriature>())
				{
					umCriature uC = X1.AddComponent<umCriature>();
					uC.nomeCriature = GameObject.FindGameObjectWithTag("Player")
						.GetComponent<heroi>().criaturesAtivos[0].nomeID;
					//uC.X.colocaStatus(uC.gameObject);
					
				}

				if(!X1.GetComponent<alternancia>())
					X1.AddComponent<alternancia>();

				if(!X1.GetComponent<UnityEngine.AI.NavMeshAgent>()){
					UnityEngine.AI.NavMeshAgent N = X1.AddComponent<UnityEngine.AI.NavMeshAgent>();
					N.stoppingDistance = N.radius<1?7:5*N.radius;
					N.baseOffset = 0;
					N.speed = N.radius<1?9:0;
				}
				
				if(!X1.GetComponent<sigaOLider>())
					X1.AddComponent<sigaOLider>();
			}
			
						
		
			X = X1.transform;
			
			X.localScale = new Vector3(0.01f,0.01f,0.01f);

			particulasSaiDaLuva(X);
			faseDaAnima = 4;
			tempoDeAnima = 0;
			
		}else if(faseDaAnima == 4 && X.localScale.sqrMagnitude< 2.5)
		{
//			new auxDeInstancia(X.transform,GameObject.FindWithTag("Player").GetComponent<CharacterController>());
			X.localScale = Vector3.Lerp(X.localScale,new Vector3(1,1,1),4*Time.deltaTime);
			X.position = posCriature;
		}else if(faseDaAnima ==4 && X.localScale.sqrMagnitude>= 2.5){
			faseDaAnima = 5;
			tempoDeAnima = 0;
			X.localScale = new Vector3(1,1,1);
		}else if(faseDaAnima == 5 && tempoDeAnima<0.25f)
		{
			Destroy(GameObject.Find("volte1"));
			ParticleSystem P = GameObject.Find("raio").GetComponent<ParticleSystem>();
			P.startSpeed = Mathf.Lerp(P.startSpeed,0,10*Time.deltaTime);
			P.startLifetime = Mathf.Lerp(P.startLifetime,0,10*Time.deltaTime);//*=(posCriature - instancia).magnitude*2;
		}else if(faseDaAnima == 5&& tempoDeAnima>0.15f)
		{
			
			Destroy(GameObject.Find("raio"));
			Destroy(GameObject.Find("luz"));
			
			Destroy(this);
		}
		
		

	}
}
