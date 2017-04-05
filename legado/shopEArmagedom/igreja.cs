using UnityEngine;
using System.Collections;

public class igreja : shopBase {



	private vidaEmLuta[] v;
	private int valorParaCura = 0;

	//private pausaJogo pJ;
//	private float tempoDeTrocas = 0;
//	private Vector3 paraCor = Vector3.zero;


	// Use this for initialization
	new void Start () {
		base.Start();

		conversa = bancoDeTextos.falacoes[heroi.lingua]["igreja"].ToArray();

	}
	
	// Update is called once per frame
	void Update () {
		
		if(((noLugar&& 
		     Vector3.Distance(T.position,transform.position)<5
		     &&mB.podeAndar==true && mB.enabled==true )|| estado!="emEspera")&&!pausaJogo.pause)
		{
			leituraDoHospital();
		}
	}

	void conversaNaIgreja()
	{
		valorParaCura = 0;
		cam.enabled = false;
		for(int i=0;i<H.criaturesAtivos.Count;i++)
		{
			if(H.criaturesAtivos[i].cAtributos[0].Corrente>0)
				valorParaCura+=(int)(H.criaturesAtivos[i].cAtributos[0].Maximo - H.criaturesAtivos[i].cAtributos[0].Corrente);

		}
		estado = "iniciouConversa";
		mens = G.AddComponent<mensagemBasica>();
		mens.posX = 0.01f;
		mens.posY = 0.68f;
		mens.mensagem  = conversa[0];
		mens.skin = skin;

		menu = G.AddComponent<Menu>();


		string[] opcoes = new string[H.criaturesAtivos.Count+1];
		opcoes[0] = simOuNao[1];
		for(int i=0;i<H.criaturesAtivos.Count;i++)
			opcoes[i+1] = H.criaturesAtivos[i].Nome;
		menu.opcoes = opcoes;
		menu.posXalvo = 0.7f;
		menu.posYalvo = 0.1f;
		menu.aMenu = 0.1f*opcoes.Length;
		menu.lMenu = 0.2f;
		menu.skin = skin;
		menu.Nome = "responde";
		menu.destaque = destaque;
		
		mB.podeAndar = false;
		mIT2.enabled = false;

		mL = G.AddComponent<mensagemEmLuta>();
		mL.posX = 0.3f;
		mL.posY = 0.01f;
		mL.tempoDeFuga = 0;
		mL.emY = true;
		mL.mensagem = "CRISTAIS: \r\n "+H.cristais;
	}



	void mensagemSimples(string mensagem)
	{
		estado = "";
		mens.entrando = false;
		menu.entrando = false;
		menu.podeMudar = false;
		mens.mensagem = mensagem;
		Invoke("voltaMens",0.15f);
	}

	void voltaMens()
	{
		estado = "mensagemSimples";
		mens.entrando = true;
	}

	void colocaPreco()
	{
		estado = "";
		mens.entrando = false;
		menu.entrando = false;
		menu.podeMudar = false;
		mens.mensagem = conversa[2]+H.criaturesAtivos[(int)menu.escolha-1].cAtributos[0].Maximo+conversa[3];
		Invoke("perguntaSeSim",0.15f);

	}

	void perguntaSeSim()
	{
		mens.entrando = true;
		menu2 = G.AddComponent<Menu>();
		menu2.opcoes = simOuNao;
		menu2.posXalvo = 0.7f;
		menu2.posYalvo = 0.4f;
		menu2.aMenu = 0.2f;
		menu2.lMenu = 0.2f;
		menu2.skin = skin;
		menu2.Nome = "respondeSimOuNao";
		estado = "respondeSimOuNao";
		menu2.destaque = destaque;
	}

	void escolhaPrimaria()
	{
		switch(menu.escolha)
		{
		case 0:
			despedida();
		break;
		default:
			if(H.criaturesAtivos[(int)menu.escolha-1].cAtributos[0].Corrente==0)
			{
				colocaPreco();
			}
			else
			{
				mensagemSimples(conversa[1]);
			}
		break;
		}
	}

	void despedida()
	{
		mens.entrando = false;
		menu.entrando = false;
		estado = "";
		mens.mensagem = conversa[4];
		Invoke("despedida2",0.15f);
	}

	void despedida2()
	{
		estado = "despedida";
		mens.entrando = true;
	}

	void voltaAoComeco()
	{
		menu.entrando = true;
		if(menu2!=null)
			menu2.fechaJanela();
		menu.podeMudar = true;
		mens.entrando = true;
		mens.mensagem = conversa[0];
		estado = "iniciouConversa";
	}

	void garrafadaNele()
	{
		estado = "";
		menu2.entrando = false;
		mens.entrando = false;
		H.criaturesAtivos[(int)menu.escolha-1].cAtributos[0].Corrente = H.criaturesAtivos[(int)menu.escolha-1].cAtributos[0].Maximo;
		elementosDoJogo elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		GameObject volte = elementos.retorna("acaoDeCura1");
		volte = Instantiate(volte,H.transform.position,Quaternion.identity) as GameObject;
		volte.GetComponent<ParticleSystem>().startColor = new Color(1,1,1,0.5f);
		
		Destroy(volte,2);
		Invoke("mensagemDeVivo",0.5f);
	}

	void mensagemDeVivo()
	{
		estado="mensagemDevivo";
		mens.entrando = true;
		mens.mensagem = conversa[6]+H.criaturesAtivos[(int)menu.escolha-1].Nome+conversa[7]+
			H.criaturesAtivos[(int)menu.escolha-1].cAtributos[0].Corrente+conversa[8];
	}

	void verificaSimOuNao()
	{
		int custo =(int) H.criaturesAtivos[(int)menu.escolha-1].cAtributos[0].Maximo;
		if(menu2.escolha==0)
		{
			if(H.cristais>=custo)
			{
				H.cristais-=(uint)custo;
				mL.mensagem = "CRISTAIS: \r\n "+H.cristais;
				garrafadaNele();
			}else{
				mensagemSimples(conversa[5]);
			}
		}else
		{
			mens.entrando = false;
			Invoke("voltaAoComeco",0.15f);
		}
	}


	void leituraDoHospital()
	{
		acao = Input.GetButtonDown("acao");
		menuEAux = Input.GetButtonDown("menu e auxiliar");
		bool acaoAlt = Input.GetButtonDown("acaoAlt");
		switch(estado)
		{
		case "emEspera":
			if(acao||acaoAlt)
				conversaNaIgreja();
		break;
		case "iniciouConversa":
			if(acaoAlt && menu.dentroOuFora()>-1)
				acao = true;
			else if(acaoAlt)
				menuEAux = true;

			if(menuEAux)
				despedida();

			if(acao)
				escolhaPrimaria();
		break;
		case "mensagemSimples":
			if(acao||menuEAux||acaoAlt)
			{
				estado = "";
				mens.entrando = false;
				Invoke("voltaAoComeco",0.15f);
			}
		break;
		case "despedida":
			if(acao|| menuEAux||acaoAlt)
				voltaAPasseio();
		break;
		case "respondeSimOuNao":
			if(acaoAlt&&menu2.dentroOuFora()>-1)
				acao = true;
			else if(acaoAlt)
				menuEAux = true;

			if(acao)
				verificaSimOuNao();

			if(menuEAux)
			{
				estado = "";
				mens.entrando = false;
				Invoke("voltaAoComeco",0.15f);
			}

		break;
		case "mensagemDevivo":
			if(acao||menuEAux||acaoAlt)
			{
				estado = "";
				mens.entrando = false;
				Invoke("voltaAoComeco",0.15f);
			}
		break;
		}
	}

	void OnTriggerEnter()
	{
		noLugar = true;
	}
	
	void OnTriggerExit()
	{
		noLugar = false;
	}
}
