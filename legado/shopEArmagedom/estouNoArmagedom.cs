using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class estouNoArmagedom : MonoBehaviour {

	private GUISkin skin;
	private GUISkin destaque;
	private string estado;
	private movimentoBasico mB;
	private mensagemBasica mens;
	private string[] conversa;
	private Menu menu1;
	private menuInTravel2 mIT2 ;
	private bool menuEAux = false;
	private bool acao = false;
	private vidaEmLuta[] v;
	private Vector3 paraCor = new Vector3(1,1,1);
	private float tempoDeTrocas = 0;
	private heroi H;
	private GameObject G;
	private HUDArmagedom hudA;
	private HUDCriaturesComMuda hudC;
	private vidasEmLutaArmagedom vidasArmgd;
	private int aSerTrocado;
	private int aSerInserido;
	private string bugDosInput;
	private string[] falas;
	private Vector3 Vaux;
	private cameraPrincipal cam;
	private float gambiarraParaIntLerp;
	private float gamb2;



	// Use this for initialization
	void Start () {
		G = GameObject.FindWithTag("Player");
		cam = G.GetComponent<cameraPrincipal>();
		H = G.GetComponent<heroi>();
		heroi.chavesDaViagem = new List<string>();
		mB = G.GetComponent<movimentoBasico>();
		mIT2 = GameObject.Find("Main Camera").GetComponent<menuInTravel2>();
		skin = mIT2.skin;
		destaque = mIT2.destaque;
		estado = "emEspera";
		conversa = bancoDeTextos.falacoes[heroi.lingua]["armagedomDeInfinity"].ToArray();
		falas = bancoDeTextos.falacoes[heroi.lingua]["falasDeArmagedom"].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void unityTaSacaneando()
	{
		mIT2.enabled = true;
	}

	void retornaAPasseo()
	{
		cam.enabled = true;
		menu1.fechaJanela();
		mens.fechaJanela();
		mB.podeAndar = true;
		Invoke("unityTaSacaneando",0.15f);
		estado = "emEspera";
	}

	void semArmagedado()
	{
		mens.mensagem = conversa[1];
		mens.entrando = true;
		estado = "nenhumArmagedado";
	}

	void temArmagedado()
	{
		if(H.criaturesArmagedados.Count<=0)
			semArmagedado();
		else
		{
			vidasArmgd = gameObject.AddComponent<vidasEmLutaArmagedom>();
			vidasArmgd.H = H;
			hudA = gameObject.AddComponent<HUDArmagedom>();
			hudA.posX = 0.01f;
			hudA.posY = 0.01f;
			hudA.lCaixa = 0.7f;
			hudA.aCaixa = 0.69f;
			hudA.skin = skin;
			hudA.destaque = destaque;
			hudA.criatures = H.criaturesArmagedados;
			hudA.podeMudar = false;

			hudC = gameObject.AddComponent<HUDCriaturesComMuda >();
			hudC.tempoDeFuga = 0;
			hudC.extraCriature = true;

			estado  ="temArmagedado";
		}


	}

	void curarCriatures()
	{
		Vector3 V = GameObject.Find("CriatureAtivo").transform.position;
		Criature[] C  = H.criaturesAtivos.ToArray();
		Vector3 V2 = G.transform.position;
		Vector3 V3 = new Vector3(1,0,0);
		Vector3[] Vs = new Vector3[]{V,V2+V3,V2+2*V3,V2-V3,V2-2*V3};
		GameObject animaVida = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ().retorna ("acaoDeCura1");
		Object animaVida2;
		v = new vidaEmLuta[C.Length];
		for(int i=0;i<C.Length;i++){
			if(i<Vs.Length){
			animaVida2 = Instantiate (animaVida, Vs[i], Quaternion.identity);
			Destroy(animaVida2,1);
			}

			v[i] = gameObject.AddComponent<vidaEmLuta>();
			gambiarraParaIntLerp = C[i].cAtributos[0].Corrente;
			gamb2 = C[i].cAtributos[1].Corrente;
			//v[i].gambiarraParaIntLerp = C[i].cAtributos[1].Corrente;
			v[i].doMenu = C[i];
			v[i].nomeVida = "meuCriature"+i;
			v[i].n = i;
			if(i == 0)
			{
				v[i].posX = 0.74f;
				v[i].posY = 0.78f;
			}else
			{
				v[i].posX = (i%2==0)?0.74f:0.01f;
				v[i].posY = 0.21f*((int)(i-1)/2);
			}

		}

		invocaAntiBug ("curando");

	}

	void escolhaInicial()
	{
		switch(menu1.escolha)
		{
		case 0:
			estado = "";
			mens.entrando = false;
			menu1.fechaJanela();
			curarCriatures();
		break;
		case 1:
			mens.entrando = false;
			menu1.fechaJanela();
			estado="";
			Invoke("temArmagedado",0.15f);

		break;
		case 2:
			retornaAPasseo();
		break;
		}
	}

	void mensInicial()
	{
		estado = "iniciouConversa";
		if(mens == null)
			mens = gameObject.AddComponent<mensagemBasica>();

		mens.mensagem = conversa[0];
		mens.entrando = true;
		
		menu1 = gameObject.AddComponent<Menu>();
		menu1.skin = skin;
		menu1.destaque = destaque;
		menu1.opcoes = bancoDeTextos.falacoes[heroi.lingua]["opcoesDeArmagedom1"].ToArray();
		menu1.lMenu = 0.4f;
		menu1.posYalvo = 0.35f;
		menu1.posXalvo = 0.01f;
		menu1.aMenu = 0.3f;
	}

	void retornaMensagemInicial()
	{
		estado="";
		mens.entrando = false;
		Invoke("mensInicial",0.15f);
	}


	void saindoDoCura()
	{
		for(int i=0;i<v.Length;i++)
		{				
			v[i].doMenu.cAtributos[0].Corrente = v[i].doMenu.cAtributos[0].Maximo;
			v[i].alteraCor(Color.white);
			v[i].fechaJanela();
		}
		retornaMensagemInicial();

	}

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player")
			LeituraDeArmagedom();
	}

	void LeituraDeArmagedom()
	{

		menuEAux = Input.GetButtonDown("menu e auxiliar");
		acao = Input.GetButtonDown("acao");
		bool acaoAlt = Input.GetButtonDown("acaoAlt");;

	switch(estado){
		case "emEspera":
			if(mB.podeAndar && mB.enabled==true)
			{
				if((acao||acaoAlt) && mens == null)
				{
					cam.enabled = false;
					mB.podeAndar = false;
					mIT2.enabled = false;
					acao = false;
					mensInicial();
					
					mens.skin = skin;
					mens.posY = 0.68f;
					H.ultimoArmagedom = new UltimoArmagedom
					{
						nomeCena= Application.loadedLevelName,
						V = new float[3]{
							H.transform.position.x,
							H.transform.position.y,
							H.transform.position.z
						}
					};;
				}
			}
			break;
		case "iniciouConversa":
			if(acaoAlt&&menu1.dentroOuFora()>-1)
				acao = true;
			else if(acaoAlt)
				menuEAux = true;

			if(menuEAux)
				retornaAPasseo();


			if(acao)
				escolhaInicial();
		break;
		case "nenhumArmagedado":
			if(menuEAux||acao||acaoAlt)
				retornaMensagemInicial();
		break;
		case "curando":
			tempoDeTrocas+=Time.deltaTime;
			Vector3 maisUmV = new Vector3(0,1,0);
			paraCor = Vector3.Slerp(paraCor,maisUmV,3*Time.deltaTime);
			Color cor = new Color(paraCor.x,paraCor.y,paraCor.z,1);
			for(int i=0;i<v.Length;i++)
			{
				gambiarraParaIntLerp = Mathf.Lerp(
					gambiarraParaIntLerp,
					(float)v[i].doMenu.cAtributos[0].Maximo,
					3*Time.deltaTime
					);

				gamb2 = Mathf.Lerp(
					gamb2,
					(float)v[i].doMenu.cAtributos[1].Maximo,
					3*Time.deltaTime
					);

				v[i].doMenu.cAtributos[0].Corrente = (uint)Mathf.Min(gambiarraParaIntLerp,v[i].doMenu.cAtributos[0].Maximo);
				v[i].doMenu.cAtributos[1].Corrente = (uint)Mathf.Min(gamb2,v[i].doMenu.cAtributos[1].Maximo);
				v[i].alteraCor(cor);
			}

			if(tempoDeTrocas>1.5f)
			{
				estado = "fimCura";
				tempoDeTrocas = 0;
			}

			if(acao || menuEAux||acaoAlt)
				saindoDoCura();
		break;
		case "fimCura":
			tempoDeTrocas+=Time.deltaTime;
			Vector3 maisUmV2 = new Vector3(1,1,1);
			paraCor = Vector3.Slerp(paraCor,maisUmV2,3*Time.deltaTime);
			Color cor2 = new Color(paraCor.x,paraCor.y,paraCor.z,1);
			for(int i=0;i<v.Length;i++)
			{				
				v[i].doMenu.cAtributos[0].Corrente = v[i].doMenu.cAtributos[0].Maximo;
				v[i].doMenu.cAtributos[1].Corrente = v[i].doMenu.cAtributos[1].Maximo;
				statusTemporarioBase.limpaStatus(v[i].doMenu,i);
				v[i].alteraCor(cor2);
			}

			for(int i=0;i<H.criaturesArmagedados.Count;i++)
			{
				H.criaturesArmagedados[i].cAtributos[0].Corrente = H.criaturesArmagedados[i].cAtributos[0].Maximo;
				H.criaturesArmagedados[i].cAtributos[1].Corrente = H.criaturesArmagedados[i].cAtributos[1].Maximo;
			}
			if(tempoDeTrocas>0.75f)
				estado = "saindoDoCura";

			if(acao || menuEAux||acaoAlt)
				saindoDoCura();
		break;
		case "saindoDoCura":
			if(acao || menuEAux||acaoAlt)
				saindoDoCura();
		break;
		case "temArmagedado":


			if(acaoAlt&&hudC.dentroOuFora()>-1)
				acao = true;
			else if(acaoAlt)
				menuEAux = true;


			if(acao)
			{
				invocaAntiBug("inserindoArmagedado");
				vidasArmgd.segundos = true;
				vidasArmgd.hudA = hudA;
				hudC.podeMudar = false;
				hudA.podeMudar = true;
			}

			if(menuEAux)
			{
				hudA.fechaJanela();
				hudC.fechaJanela();
				vidasArmgd.fechaEsse();
				H.criatureSai = 1;
				retornaMensagemInicial();
			}
		break;
		case "inserindoArmagedado":

			if(acaoAlt && hudA.dentroOuFora()>-1)
				acao = true;
			else if(acaoAlt)
				menuEAux = true;

			if(menuEAux)
			{
				hudC.podeMudar = true;
				hudA.podeMudar = false;
				invocaAntiBug( "temArmagedado");
				vidasArmgd.fechaSegundos = true;
			}

			if(acao)
			{
				hudC.entrando = false;
				hudA.entrando = false;
				hudA.podeMudar = false;
				vidasArmgd.trocando();
				mens.mensagem = falas[0]+H.criaturesAtivos[H.criatureSai].Nome+
					falas[1]+H.criaturesAtivos[H.criatureSai].mNivel.Nivel+
					falas[2]+H.criaturesArmagedados[(int)hudA.escolha].Nome+
						falas[1]+H.criaturesArmagedados[(int)hudA.escolha].mNivel.Nivel;
				mens.entrando = true;
				Criature aux = H.criaturesAtivos[H.criatureSai];
				H.criaturesAtivos[H.criatureSai] = H.criaturesArmagedados[(int)hudA.escolha];
				H.criaturesArmagedados[(int)hudA.escolha] = aux;
				if(H.criatureSai!=0)
					invocaAntiBug("substituiu");
				else
				{
					invocaAntiBug("animandoTroca");

					
					Vaux = GameObject.Find("CriatureAtivo").transform.position;
					gameObject.AddComponent<animaTroca> ();
				}
			}
		break;
		case "substituiu":
			if(acao ||menuEAux||acaoAlt)
			{
				hudC.podeMudar = true;
				mens.entrando = false;
				hudC.entrando = true;
				hudA.entrando = true;
				vidasArmgd.voltadoATrocar();
				invocaAntiBug("temArmagedado");
			}
		break;
			/*
			if(acao || menuEAux||acaoAlt) 7777  7 X 
			{
				hudC.podeMudar = true;
				mens.entrando = false;
				hudC.entrando = true;
				hudA.entrando = true;
				vidasArmgd.voltadoATrocar();
				invocaAntiBug("temArmagedado");
			}
		break;*/
		case "animandoTroca":
			if(!GetComponent<animaTroca>())
			{
				GameObject meuHeroi = GameObject.FindGameObjectWithTag("Player");
				Animator animator = meuHeroi.GetComponent<Animator> ();
				animator.SetBool("envia",true);
				animaEnvia a = gameObject.AddComponent<animaEnvia>();
				a.posCriature = Vaux;
				a.oInstanciado = H.criaturesAtivos[0].nomeID;
				estado = "trocou";
				
			}
		break;
		case "trocou":
			if(!GetComponent<animaEnvia>())
			{
				//Menu[] menus = GetComponents<Menu> ();
				//foreach (Menu menu in menus)
				//	menu.entrando = true;
				//fechaEVai("segundaOrganizaçao","organizaCriatures");
				//fechaEVai("organizaCriatures","Organizaçao");
				Animator animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
				animator.SetBool("envia",false);
				animator.SetBool("chama",false);
				G.transform.rotation = Quaternion.LookRotation(-G.transform.position+transform.position);
				invocaAntiBug("substituiu");
			}
			
		break;
		
		
	}

		acao = false;
		menuEAux = false;
	}

	void invocaAntiBug(string bugouOnde)
	{
		estado = "";
		bugDosInput = bugouOnde;
		Invoke("inputBugados",0.05f);
	}


	void inputBugados()
	{

		estado = bugDosInput;
	}
}
