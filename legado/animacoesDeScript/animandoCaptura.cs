using UnityEngine;
using System.Collections;

public class animandoCaptura : LuvaDeGuarde {
    
	public GameObject G;
	public string estado = "tentandoCapturar";

	private float tempoEmCena = 0;
	private int disparado = 0;
	private Transform Inimigo;

	private bool captura = true;
	private string[] mensagens;
	private bool fim = false;
	private GameObject raio;
	private GameObject oHeroi;

	private const int LOOPS = 8;
	
	//private elementosDoJogo elementos;


	// Use this for initialization
	void Start () {

		Inimigo = G.transform;

		if(Application.loadedLevelName!="Entradinha2")
			captura = continhaDeCaptura();
		else
			captura = true;

		IA = Inimigo.GetComponent<IA_inimigo>();
		IA.podeAtualizar = false;
		IA.paraMovimento();
		elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		animator = Inimigo.GetComponent<Animator>();
		particulasSaiDaLuva(G.transform);
		mensagens = bancoDeTextos.falacoes[heroi.lingua]["tentaCapturar"].ToArray();
	}

	void oFim()
	{
		estado = "finalisaUsaItem";
		Destroy(this);
	}

	void cameraCorean()
	{
		Destroy(oHeroi.GetComponent<centralizaEGiraCamera>());
		olharEmLuta();
	}

	void fimComCaptura()
	{
		animaCapturado animaC = oHeroi.AddComponent<animaCapturado>();
		animaC.oCapturado = Inimigo.GetComponent<umCriature>().criature();
		estado = "finalisaComCaptura";
		Destroy(raio);
		Destroy(gameObject);
	}

	bool continhaDeCaptura()
	{
		int vida = (int)Inimigo.GetComponent<umCriature>().criature().cAtributos[0].Corrente;

		bool retorno = false;


		if(vida == 2){
			float x = Random.value;
			if(x>0.75f)
				retorno = true;
			else
				retorno = false;
		}

		if(vida ==1){
			float y = Random.value;
		if(y>0.25f)
			retorno = true;
		else
			retorno = false;
	}

		return retorno;
	}
	
	// Update is called once per frame
	void Update () {

		tempoEmCena+=Time.deltaTime;
		int arredondado = Mathf.RoundToInt(tempoEmCena);
		Vector3 variacao = arredondado%2==1?Vector3.zero:new Vector3(1.5f,1.5f,1.5f);

		if(arredondado!=disparado&& arredondado<LOOPS)
		{
			particulasSaiDaLuva(G.transform);
			animator.CrossFade("dano1",0);
			animator.SetBool("dano1",true);
			animator.SetBool("dano2",true);

			disparado = arredondado;
		}

		if(arredondado>=LOOPS&&!fim)
		{
			if(!captura)
			{
				particulasSaiDaLuva(Inimigo,"encontro");
				Inimigo.localScale = new Vector3(1,1,1);
				animator.SetBool("dano1",false);
				animator.SetBool("dano2",false);
				mensagemEmLuta mensL;
				if(!Camera.main.GetComponent<mensagemEmLuta>())
					mensL = Camera.main.gameObject.AddComponent<mensagemEmLuta>();
				else
				{
					Camera.main.GetComponent<mensagemEmLuta>().fechador();
					mensL = Camera.main.gameObject.AddComponent<mensagemEmLuta>();
				}
				mensL.mensagem = Inimigo.GetComponent<umCriature>().criature().Nome+mensagens[0];
				Invoke("oFim",1);

			}else
			{
				fechaVidaEmLuta();
				oHeroi = GameObject.FindWithTag("Player");
				Vector3 maoDoHeroi = oHeroi.transform
					.Find("esqueletodoCorean/hips/spine/chest/shoulder_L/upper_arm_L/forearm_L/hand_L/palm_02_L")
						.transform.position;
				Inimigo.localScale = Vector3.zero;
				raio = elementos.retorna("raioDeLuvaDeGuarde");
				raio = Instantiate(raio,Inimigo.position,Quaternion.LookRotation(
					maoDoHeroi - Inimigo.position
					))as GameObject;
				raio.name = "raio";
				ParticleSystem P = raio.GetComponent<ParticleSystem>();
				P.startSpeed*=(maoDoHeroi - Inimigo.position).magnitude*2;
				Invoke("cameraCorean",1.5f);
				Invoke("fimComCaptura",2.5f);

			}
			fim = true;
		}else if(!fim)
		Inimigo.localScale = Vector3.Lerp(Inimigo.localScale,variacao,Time.deltaTime);

//		if()
	}
}
