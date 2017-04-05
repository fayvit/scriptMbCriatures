using UnityEngine;
using System.Collections;

public class animaCapturado : LuvaDeGuarde {

	public Criature oCapturado;

	private Vector3 maoDoHeroi;
	private heroi H;
	private bool entraGUI = false;
	private apresentaCaptura apC;
	private bool foiParaArmagedom;
	private encontros oEncontro;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		oEncontro = GameObject.Find("Terrain").GetComponent<encontros>();


		if(oEncontro ==  null)
		
			oEncontro =  GameObject.Find("encontreEle").GetComponent<encontros>();

		

		H = GetComponent<heroi>();

		if(H.criaturesAtivos.Count < H.maxCarregaveis)
		{
			H.criaturesAtivos.Add(oCapturado);
			foiParaArmagedom = false;
		}else
		{
			H.criaturesArmagedados.Add(oCapturado);
			/*
			linhas para encher a vida e retirar status quando o Criature for para o Armagedom
			 */

			statusTemporarioBase.limpaStatus(oCapturado,-1);
			oCapturado.cAtributos[0].Corrente = oCapturado.cAtributos[0].Maximo;
			oCapturado.cAtributos[1].Corrente = oCapturado.cAtributos[1].Maximo;

			/**************************************************/
			foiParaArmagedom = true;
		}




		elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();

		
		animator.SetBool("travar",true);
		animator.SetBool("chama",false);
		animator.Play("capturou");

		Invoke("primeiroBrilho",1f);
		Invoke("primeiroBrilho",2.1f);
		Invoke("informacoesDeCaptura",2.5f);
	
	}

	void informacoesDeCaptura()
	{

		/*	 parte de teste*/
		//oCapturado = H.criaturesAtivos[0];
		/* fim do teste*/

		apC = gameObject.AddComponent<apresentaCaptura>();
		apC.oCapturado = oCapturado;
		//apC.elementos = elementos;
		entraGUI = true;
	}

	void primeiroBrilho()
	{

		maoDoHeroi = transform
			.Find("esqueletodoCorean/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_04_R")
				.transform.position;//+0.2f*transform.forward;
		Instantiate(elementos.retorna("luz1captura"),maoDoHeroi,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if(entraGUI)
		{
			bool acao = Input.GetButtonDown("acao");
			bool menuEAux = Input.GetButtonDown("menu e auxiliar");

			if(acao || menuEAux)
			{
				if(!foiParaArmagedom)
					apC.fase = 4;
				else
					apC.fase++;

			}

			if(apC == null)
			{
				animator.SetBool("travar",false);
				oEncontro.voltarParaPasseio();
				Destroy(GetComponent<usaItemEmLuta>());
				Destroy(this);
			}
		}
	}
}
