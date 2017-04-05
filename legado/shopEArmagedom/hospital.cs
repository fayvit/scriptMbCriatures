using UnityEngine;
using System.Collections;

public class hospital : shopBase {


	private vidaEmLuta[] v;
	private int valorParaCura = 0;
	private float tempoDeTrocas = 0;
	private Vector3 paraCor = Vector3.zero;
	
	private float gambiarraParaIntLerp;
	//private pausaJogo pJ;



	// Use this for initialization
	new void Start () {
		base.Start();
		conversa = bancoDeTextos.falacoes[heroi.lingua]["hospital"].ToArray();

	}
	
	// Update is called once per frame
	void Update () {
		
		if(((noLugar&& 
		     Vector3.Distance(T.position,transform.position)<5
		     && (mB.podeAndar==true && mB.enabled==true) )|| estado!="emEspera")&&!pausaJogo.pause)
		{
			leituraDoHospital();
		}
	}

	void conversaNoHospital()
	{
		valorParaCura = 0;
		for(int i=0;i<H.criaturesAtivos.Count;i++)
		{
			if(H.criaturesAtivos[i].cAtributos[0].Corrente>0){
				valorParaCura+=(int)(H.criaturesAtivos[i].cAtributos[0].Maximo - H.criaturesAtivos[i].cAtributos[0].Corrente);
				valorParaCura+=(int)(H.criaturesAtivos[i].cAtributos[1].Maximo - H.criaturesAtivos[i].cAtributos[1].Corrente);
			}

		}
		cam.enabled = false;
		estado = "iniciouConversa";
		mens = G.AddComponent<mensagemBasica>();
		mens.posX = 0.01f;
		mens.posY = 0.68f;
		mens.mensagem  = conversa[0]+valorParaCura.ToString()+conversa[1];
		mens.skin = skin;

		menu = G.AddComponent<Menu>();

		
		menu.opcoes = simOuNao;
		menu.posXalvo = 0.7f;
		menu.posYalvo = 0.4f;
		menu.aMenu = 0.2f;
		menu.lMenu = 0.2f;
		menu.skin = skin;
		menu.Nome = "responde";
		menu.destaque = destaque;
		
		mB.podeAndar = false;
		mIT2.enabled = false;

		mL = G.AddComponent<mensagemEmLuta>();
		mL.posX = 0.5f;
		mL.posY = 0.01f;
		mL.tempoDeFuga = 0;
		mL.emY = true;
		mL.mensagem = "CRISTAIS: \r\n "+H.cristais;
	}

	void curarCriatures()
	{
		mens.entrando = false;
		menu.entrando = false;
		menu.podeMudar = false;
		Vector3 V = GameObject.Find("CriatureAtivo").transform.position;
		Criature[] C  = H.criaturesAtivos.ToArray();
		Vector3 V2 = T.transform.position;
		Vector3 V3 = new Vector3(1,0,0);
		Vector3[] Vs = new Vector3[]{V,V2+V3,V2+2*V3,V2-V3,V2-2*V3};
		GameObject animaVida = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ().retorna ("acaoDeCura1");
		Object animaVida2;
		v = new vidaEmLuta[C.Length];
		for(int i=0;i<C.Length;i++){
			if(C[i].cAtributos[0].Corrente>0){
				if(i<Vs.Length){
				animaVida2 = Instantiate (animaVida, Vs[i], Quaternion.identity);
				Destroy(animaVida2,1);
				}
			
			v[i] = G.AddComponent<vidaEmLuta>();
			gambiarraParaIntLerp = C[i].cAtributos[0].Corrente;
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
		}
		tempoDeTrocas = 0;
		estado = "curando";
		
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

	void escolhaPrimaria()
	{
		switch(menu.escolha)
		{
		case 0:
			if(valorParaCura>0)
			{
				if(H.cristais >=valorParaCura)
				{
					H.cristais-=(uint)valorParaCura;
					mL.mensagem = "CRISTAIS: \r\n "+H.cristais;
					curarCriatures();
				}else
				{
					mensagemSimples(conversa[2]);
				}
			}else
			{
				mensagemSimples( conversa[3]);
			}
		break;
		case 1:
			despedida();
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
		menu.podeMudar = true;
		mens.entrando = true;
		mens.mensagem = conversa[0]+ valorParaCura.ToString() +conversa[1];
		estado = "iniciouConversa";
	}

	void saindoDoCura()
	{
		for(int i=0;i<v.Length;i++)
		{	
			if(v[i]!=null){
			v[i].doMenu.cAtributos[0].Corrente = v[i].doMenu.cAtributos[0].Maximo;
			v[i].alteraCor(Color.white);
			v[i].fechaJanela();
			}
			valorParaCura = 0;
		}
		voltaAoComeco();
		
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
				conversaNoHospital();
		break;
		case "iniciouConversa":
			if(acaoAlt&&menu.dentroOuFora()>-1)
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
		case "fimCura":
			tempoDeTrocas+=Time.deltaTime;
			Vector3 maisUmV2 = new Vector3(1,1,1);
			paraCor = Vector3.Slerp(paraCor,maisUmV2,3*Time.deltaTime);
			Color cor2 = new Color(paraCor.x,paraCor.y,paraCor.z,1);
			for(int i=0;i<v.Length;i++)
			{		
				if(v[i]!=null){
				v[i].doMenu.cAtributos[0].Corrente = v[i].doMenu.cAtributos[0].Maximo;
				v[i].doMenu.cAtributos[1].Corrente = v[i].doMenu.cAtributos[1].Maximo;
				v[i].alteraCor(cor2);
				}
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
		case "curando":
			tempoDeTrocas+=Time.deltaTime;
			Vector3 maisUmV = new Vector3(0,1,0);
			paraCor = Vector3.Slerp(paraCor,maisUmV,3*Time.deltaTime);
			Color cor = new Color(paraCor.x,paraCor.y,paraCor.z,1);
			for(int i=0;i<v.Length;i++)
			{
				if(v[i]!= null){
				gambiarraParaIntLerp = Mathf.Lerp(
					gambiarraParaIntLerp,
					(float)v[i].doMenu.cAtributos[0].Maximo,
					3*Time.deltaTime
					);
				
				v[i].doMenu.cAtributos[0].Corrente = (uint)gambiarraParaIntLerp;
				v[i].alteraCor(cor);
				}
			}
			
			if(tempoDeTrocas>1.5f)
			{
				estado = "fimCura";
				tempoDeTrocas = 0;
			}
			
			if(acao || menuEAux||acaoAlt)
				saindoDoCura();
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
