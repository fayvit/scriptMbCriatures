using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class menuInTravel2 : MonoBehaviour {
	private bool acao = false;
	private bool menuEAux = false;
	private bool acaoAlt = false;
	private string nomeMenu = "emEspera";
	private movimentoBasico mB;
	private heroi H;
	private Vector3 posTroca;
	private cameraPrincipal cameraCorean;
	private mensagemEmLuta mL;
	private mensagemEmLuta mL2;
	private Dictionary<string,List<string>> tMIT2;
	private int escolhaAntiga = -1;
	private Menu menu;
	
	public GUISkin skin;
	public GUISkin destaque;

	private mensagemBasica mensS;
	private nomeieSave nomeie;

	// Use this for initialization
	void Start () {
		mB = GameObject.FindGameObjectWithTag ("Player").GetComponent<movimentoBasico> ();
		H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();
		cameraCorean = GameObject.FindGameObjectWithTag ("Player").GetComponent<cameraPrincipal> ();
		tMIT2 = bancoDeTextos.falacoes[heroi.lingua];

		/*   Teste de novo HUD para luta
		vidaEmLuta v =  gameObject.AddComponent<vidaEmLuta>();
		v.minhaLuta = true;
		v.doMenu = new Florest();
		v.nomeVida = "meuCriature";
		v.n = 2;
		v.posX = 0.74f;
		v.posY = 0.78f;
		/**/
	
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("menu e auxiliar"))
				menuEAux = true;

		if (Input.GetButtonDown ("acao"))
			acao = true;

		if (Input.GetButtonDown ("acaoAlt"))
			acaoAlt = true;

		switch(nomeMenu)
		{
		case "emEspera":
			if(menuEAux == true&&!pausaJogo.pause)
			{
				alternancia.focandoHeroi();
				mB.podeAndar = false;
				cameraCorean.enabled = false;
				mB.pararOHeroi();
				menu = gameObject.AddComponent<Menu>();
				string[] opcoes = tMIT2["mitPrincipal"].ToArray();//{"Status","Itens","Suporte","Organizaçao","Salvar"};
				menu.skin = skin;
				menu.destaque = destaque;
				menu.opcoes = opcoes;
				menu.posXalvo = 0.01f;
				menu.posYalvo = 0.01f;
				menu.lMenu = 0.2f;
				menu.aMenu = 0.1f*opcoes.Length;
				nomeMenu = "Principal";
				menu.Nome = nomeMenu;

				mL = gameObject.AddComponent<mensagemEmLuta>();
				mL.posX = 0.01f;
				mL.posY = 0.52f;
				mL.aCaixa = 0.1f;
				mL.lCaixa = 0.2f;
				mL.tempoDeFuga = 0;
				mL.mensagem = tMIT2["mitSoltos"][5]+H.cristais;

			}
		break;
		

		case "Status":
			if(acaoAlt)
				poderDoClick("Principal");

			if(menuEAux == true)
				fechaEVai(nomeMenu,"Principal");

			if(acao == true)
				escolhaStatus();
		break;
		case "StatusDeCriature":
			if (Input.GetButtonDown ("acao") || Input.GetButtonDown ("menu e auxiliar")||acaoAlt){
				painelStatus painel = GetComponent<painelStatus>();
				painel.fechaJanela ();
				nomeMenu = "Status";
				try{
				retornaMenu(nomeMenu).podeMudar = true;
				}catch(NullReferenceException e)
				{
					Debug.LogWarning("nulidade de Menu, "+e.InnerException);
				}
				
			}
		break;
		case "Principal":
			if(menuEAux == true){
				FechaMenu(nomeMenu);
				nomeMenu = "emEspera";
				mB.podeAndar = true;
				cameraCorean.enabled = true;
				if(mL!=null)
					mL.fechaJanela();
			}

			if(acaoAlt)
			{
				Menu daKi = retornaMenu(nomeMenu);
				if(daKi.dentroOuFora()>-1)
				
					acao = true;
				else
				{
					FechaMenu(nomeMenu);
					nomeMenu = "emEspera";
					mB.podeAndar = true;
					cameraCorean.enabled = true;
					if(mL!=null)
						mL.fechaJanela();
				}

			}

			if(acao == true)
			{
				escolhaPrincipal();
			}
		break;
		case "Suporte":
			if(acaoAlt)
				poderDoClick("Principal");

			if(menuEAux == true)
				fechaEVai(nomeMenu,"Principal");
			
			if(acao == true)
			{
				escolhaSuporte();
			}
		break;
		case "semSuporte":
			if(menuEAux||acao||acaoAlt)
				fechaEVai(nomeMenu,"Suporte",false);
		break;
		case "Itens":
			uint escolhaAtual = retornaMenu("Itens").escolha;
			if(escolhaAtual != escolhaAntiga)
			{
				if(!mL2)
				{
					mL2 = gameObject.AddComponent<mensagemEmLuta>();
					mL2.posX = 0.57f;
					mL2.posY = 0.52f;
					mL2.lCaixa = 0.4f;
					mL2.tempoDeFuga = 0;
					mL2.positivo = true;
				}
				escolhaAntiga = (int)retornaMenu("Itens").escolha;
				trocaInfo();
			}
			if(acaoAlt)
				poderDoClick("Principal");

			if(acao)
				useiOItem();
			if(menuEAux)
			{
				fechaEVai(nomeMenu,"Principal");
				mL2.fechaJanela();
				escolhaAntiga = -1;
			}
		break;
		case "usandoItem":
			nomeMenu = GetComponent<acaoDeItem2>().estadoPublico;
		break;
		case "retornarAosItens":
			nomeMenu = "Itens";
			int escolha  = (int)retornaMenu(nomeMenu).escolha;
			if(escolha>=H.itens.Count)
			{
				if(H.itens.Count>0)
					retornaMenu(nomeMenu).escolha--;
				else
				{
					fechaEVai(nomeMenu,"Principal");
					if(mL2)
						mL2.fechaJanela();
				}
			}else
			{
				if(mL2)
					mL2.entrando = true;
				
				retornaMenu(nomeMenu).podeMudar = true;
			}
			if(GetComponent<vidaEmLuta>())
				GetComponent<vidaEmLuta>().fechaJanela();
		break;
		case "semItem":
			if(menuEAux)
				fechaEVai(nomeMenu,"Principal",false);
		break;

		case "Organizaçao":

			if(acaoAlt)
				poderDoClick("Principal");

			if(menuEAux)
				fechaEVai(nomeMenu,"Principal");

				
			if(acao)
				perguntaDeOrganizacao();
		break;

		case "organizaCriatures":
			if(menuEAux)
				fechaEVai(nomeMenu,"Organizaçao");

			if(acaoAlt)
				poderDoClick("Organizaçao");

			if(acao)
				segundaOrganizacao();
		break;

		case "segundaOrganizaçao":
			if(menuEAux)
				fechaEVai(nomeMenu,"organizaCriatures");

			if(acaoAlt)
				poderDoClick("organizaCriatures");
				
			

			if(acao)
				trocaCriatures();
		break;
		case "animandoTroca":
			if(!GetComponent<animaTroca>())
			{
				GameObject meuHeroi = GameObject.FindGameObjectWithTag("Player");
				Animator animator = meuHeroi.GetComponent<Animator> ();
				animator.SetBool("envia",true);

				animaEnvia a = gameObject.AddComponent<animaEnvia>();
				a.posCriature = posTroca;
				a.oInstanciado = H.criaturesAtivos[0].nomeID;
				nomeMenu = "trocou";

			}
		break;
		case "trocou":
			if(!GetComponent<animaEnvia>())
			{
				Menu[] menus = GetComponents<Menu> ();
				foreach (Menu menu in menus)
					menu.entrando = true;

				if(mL!=null)
					mL.entrando = true;


				fechaEVai("segundaOrganizaçao","organizaCriatures");
				fechaEVai("organizaCriatures","Organizaçao");
				Animator animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
					animator.SetBool("envia",false);
				animator.SetBool("chama",false);
			}

		break;
		case "escolhaSave":
			if(acaoAlt)
				poderDoClick("Principal");

			if(menuEAux == true){
				FechaMenu(nomeMenu);
				nomeMenu = "Principal";
				retornaMenu(nomeMenu).podeMudar = true;
			}


				
			

			if(acao == true)
			{
				perguntaDeSave();
			}
		break;
		case "novoSave":
			if(nomeie == null)
			{
				nomeMenu = "escolhaSave";
					retornaMenu(nomeMenu).podeMudar = true;
			}

			if(Input.GetButtonDown("Submit"))
				if(nomeie!= null)
					if(nomeie.entrando == true)
						nomeie.acaoDoBotaoSalvar();

			if(Input.GetButtonDown("paraCriature"))
				nomeie.fechaJanela();

		break;
		case "mensagemDeSave":
			if(acao || menuEAux||acaoAlt)
			{
				mensS.fechaJanela();
				Menu m = retornaMenu("Principal");
				m.entrando = true;
				m.podeMudar = true;
				nomeMenu = m.Nome;
			}
		break;
		case "mensagemOrganizacaoFail":
			if(acao || menuEAux||acaoAlt)
			{
				mensS.fechaJanela();
				retornaParaOrganizacao();
			}
		break;
		case "limpaMIT":
			limpaOMIT();
		break;
		}

		acao = false;
		menuEAux = false;
		acaoAlt = false;
	}

	void trocaInfo()
	{
		
		mL2.entrando = false;
		
		
		Invoke("voltaML2",0.15f);
	}
	
	void voltaML2()
	{

		mL2.mensagem = 
			bancoDeTextos.falacoes[heroi.lingua]["shopInfoItem"][(int)(H.itens[(int)(menu.escolha)].ID)];
		if(nomeMenu=="Itens")
			mL2.entrando=true;
	}

	void poderDoClick(string menuDeFuga)
	{
		Menu daKi = retornaMenu(nomeMenu);
		if(daKi.dentroOuFora()>-1)
			
			acao = true;
		else
			menuEAux = true;//fechaEVai(nomeMenu,menuDeFuga);

	}
	
	public void salveOCorrente(int onde = -1)
	{
		
		if(jogoParaSalvar.corrente == null)
			jogoParaSalvar.corrente = new jogoParaSalvar();

		jogoParaSalvar j = jogoParaSalvar.corrente;

		j.osItens = H.itens;
		j.ativos = H.criaturesAtivos;
		j.armagedados = H.criaturesArmagedados;
		j.cristais = H.cristais;
		j.nomeCena = Application.loadedLevelName;
		j.tempoDeJogo+= heroi.tempoNoJogo + Time.time;
		float[] posicoes = {transform.position.x,transform.position.y,transform.position.z};
		j.posicao = new List<float>(posicoes);
		j.rotacao = new Rotacao(transform.forward,heroi.chavesDaViagem);
		j.shift = variaveisChave.shift;
		j.contadorChave = variaveisChave.contadorChave;
		j.ondeEntrei = heroi.ondeEntrei;
		
		
		//LevelSerializer.SaveGame("oi11");
		
		
		nomeMenu = "mensagemDeSave";
		mensS =  gameObject.AddComponent<mensagemBasica>();
			mensS.posY = 0.68f;
			mensS.mensagem =tMIT2["mitSoltos"][6];
			mensS.skin = skin;
			mensS.destaque = destaque;
			mensS.title = "";
		retornaMenu("escolhaSave").fechaJanela();
		retornaMenu("Principal").entrando = false;


		saveGame.Save(onde);
	}

	void perguntaDeSave()
	{
		uint escolha = retornaMenu("escolhaSave").escolha;
		if(escolha == saveGame.savedGames.Count){
			nomeie = gameObject.AddComponent<nomeieSave>();
			nomeie.posX = 0.3f;
			nomeie.posY = 0.35f;
			nomeie.lCaixa = 0.4f;
			nomeie.aCaixa = 0.3f;
			nomeie.skin = skin;
			nomeie.m2 = this;
			retornaMenu("escolhaSave").podeMudar = false;
			nomeMenu = "novoSave";
		}
		else
		{
			jogoParaSalvar.corrente = saveGame.savedGames[(int)escolha] ;
			salveOCorrente((int)escolha);
		}
	}

	void animaTroca()
	{

		nomeMenu = "animandoTroca";
		Menu[] menus = GetComponents<Menu> ();
		foreach (Menu menu in menus)
						menu.entrando = false;
		if(mL!=null)
			mL.entrando = false;

		posTroca = GameObject.Find("CriatureAtivo").transform.position;
		gameObject.AddComponent<animaTroca> ();


	}

	void trocaCriatures()
	{
		uint indice1 = retornaMenu ("organizaCriatures").escolha;
		uint indice2 = retornaMenu ("segundaOrganizaçao").escolha;
//		print (indice2+" : "+indice1);
		indice2 = (indice1 <= indice2) ? indice2 + 1: indice2;
//		print (indice2+" : "+indice1);
		if((indice1==0 && H.criaturesAtivos [(int)indice2].cAtributos[0].Corrente>0)
		   ||
		   ((indice2==0 && H.criaturesAtivos [(int)indice1].cAtributos[0].Corrente>0))
		   ||
		   (indice1!=0&&indice2!=0))
		{
		Criature aux = H.criaturesAtivos[(int)indice1];
		H.criaturesAtivos [(int)indice1] = H.criaturesAtivos [(int)indice2];
		H.criaturesAtivos [(int)indice2] = aux;

		if (indice1 == 0 || indice2 == 0)
						animaTroca ();
		else
				retornaParaOrganizacao();
		}else
		{
			Criature daMens;
			if(indice1==0)
				daMens = H.criaturesAtivos[(int)indice2];
			else
				daMens = H.criaturesAtivos[(int)indice1];
			mensS = gameObject.AddComponent<mensagemBasica>();
			mensS.posY = 0.68f;
			mensS.skin = skin;
			mensS.mensagem = tMIT2["mitSoltos"][1]+daMens.Nome+ tMIT2["mitSoltos"][2];
			nomeMenu = "mensagemOrganizacaoFail";
		}
	}

	void retornaParaOrganizacao()
	{
		if(retornaMenu("segundaOrganizaçao"))
			fechaEVai("segundaOrganizaçao","organizaCriatures");
		fechaEVai("organizaCriatures","Organizaçao");
	}

	void segundaOrganizacao()
	{
		retornaMenu (nomeMenu).podeMudar = false;
		uint escolha = retornaMenu ("organizaCriatures").escolha;
		List<string> opcoes = new List<string>(H.nomesCriaturesHeroi ());
		opcoes.RemoveAt ((int)escolha);
		if(opcoes.Count>0)
		{
			Menu menu = gameObject.AddComponent<Menu> ();
			menu = menu.detalhesBase (menu, "segundaOrganizaçao", opcoes.ToArray (), skin, destaque);
			menu.aMenu = 0.1f * opcoes.Count;
			menu.posXalvo = 0.65f;
			menu.posYalvo = retornaMenu ("organizaCriatures").posYalvo;
			nomeMenu = menu.Nome;
		}else
		{
			nomeMenu = "mensagemOrganizacaoFail";
			mensS = gameObject.AddComponent<mensagemBasica>();
			mensS.mensagem = tMIT2["mitSoltos"][7];
		}

	}

	void fechaEVai(string fecha,string vai,bool menu = true)
	{
		if (menu) {
			try{
			retornaMenu (fecha).fechaJanela ();
			}catch(NullReferenceException e)
			{
				Debug.LogWarning("Nulidade de Menu; nomeMenu: "+fecha+" : "+e.InnerException);
			}
			nomeMenu = vai;
			try{
				retornaMenu (nomeMenu).podeMudar = true;
			}catch(NullReferenceException e)
			{
				Debug.LogWarning("Nulidade de Menu; nomeMenu: "+nomeMenu+" : "+e.InnerException);
			}
		}else
		{
			mensagemBasica mens = GetComponent<mensagemBasica>();
			mens.fechaJanela ();
			nomeMenu = vai;
			retornaMenu(nomeMenu).podeMudar = true;
		}


	}

	void perguntaDeOrganizacao()
	{
		uint escolha = retornaMenu (nomeMenu).escolha;
		string[] opcoes = null;
		switch(escolha)
		{
		case 0:
			nomeMenu = "organizaCriatures";
			retornaMenu("Organizaçao").podeMudar = false;

			opcoes = H.nomesCriaturesHeroi();

			Menu menu = gameObject.AddComponent<Menu>();
			menu = menu.detalhesBase(menu,nomeMenu,opcoes,skin,destaque);
			menu.posXalvo = 0.43f;
			menu.aMenu = 0.1f*H.criaturesAtivos.Count;
			menu.posYalvo = 0.2f;
		break;
		default:
			fechaEVai(nomeMenu,"Principal");
		break;
		}
	}

	void useiOItem()
	{
		mL2.entrando = false;
		menu = retornaMenu("Itens");
		int escolha = (int)menu.escolha;
		menu.podeMudar = false;
		acaoDeItem2 a = gameObject.AddComponent <acaoDeItem2>();
		a.skin =skin;
		a.destaque = destaque;
		a.nomeItem =  H.itens[escolha].ID;//print (H.itens [escolha].nome);
		nomeMenu = "usandoItem";
	}

	void escolhaSuporte()
	{
		try{
			mensagemBasica mens = null;
			Menu principal = retornaMenu("Suporte");
			principal.podeMudar = false;
			mens = gameObject.AddComponent<mensagemBasica>();
			mens.posY = 0.68f;
			mens.mensagem =tMIT2["mitSoltos"][3];
			mens.skin = skin;
			mens.destaque = destaque;
			mens.title = "";
			nomeMenu = "semSuporte";
		}catch(NullReferenceException e)
		{
			Debug.LogWarning("Nulidade do Menu Suporte "+e.InnerException);
		}
	}

	public Menu retornaMenu(string nome,bool finalizaEmErro = true)
	{
		Menu retorno = null;
			Menu[] menus = GetComponents<Menu>();
			foreach(Menu menu in menus)
			{
				if(menu.Nome == nome)
					retorno = menu;
			}

		if(finalizaEmErro && retorno == null)
		{
			limpaOMIT();
			Debug.LogWarning("Nulidade de Menus");
		}

		return retorno;
	}

	void limpaOMIT()
	{
		Menu[] menusX = GetComponents<Menu>();
		foreach(Menu menu in menusX)
		{
			menu.fechaJanela();
		}
		
		mensagemBasica[] mensagens = GetComponents<mensagemBasica>();
		foreach(mensagemBasica mensagem in mensagens)
		{
			mensagem.fechaJanela();
		}
		
		mensagemEmLuta[] mLs = GetComponents<mensagemEmLuta>();
		
		foreach(mensagemEmLuta mL in mLs)
		{
			mL.fechaJanela();
		}
		
		painelStatus[] pS = GetComponents<painelStatus>();
		foreach(painelStatus p in pS)
		{
			p.fechaJanela();
		}

		nomeMenu = "emEspera";
	}

	void escolhaStatus()
	{
		try{
			Menu status = retornaMenu("Status");
		
			uint escolha = status.escolha;
			status.podeMudar = false;
			painelStatus painel = gameObject.AddComponent<painelStatus> ();
			painel.skin = skin;
			painel.posX = 0.43f;
			painel.posY = 0.03f;
			painel.aCaixa = 0.7f;
			painel.lCaixa = 0.5f;
			painel.criature = H.criaturesAtivos[(int)escolha];
			nomeMenu = "StatusDeCriature";
		}catch(NullReferenceException e)
		{
			Debug.LogWarning("Nulidade do Menu Status "+e.InnerException);
		}
	}

	void escolhaPrincipal()
	{
	try{
		Menu principal = retornaMenu("Principal");
		uint escolha = principal.escolha;
		mensagemBasica mens = null;
		string[] opcoes = null;
		switch(escolha)
		{
		case 0:
			menu = gameObject.AddComponent<Menu>();
			principal.podeMudar = false;
			opcoes = H.nomesCriaturesHeroi();
			menu.posYalvo = 0.02f;
			menu.aMenu = 0.1f*H.criaturesAtivos.Count;
			menu = menu.detalhesBase(menu,"Status",opcoes,skin,destaque);
			nomeMenu = menu.Nome;
		break;
		case 1:
			if(H.itens.Count<=0){
				principal.podeMudar = false;

				mens = gameObject.AddComponent<mensagemBasica>();
				mens.posY = 0.68f;
				mens.mensagem =tMIT2["mitSoltos"][4];
				mens.skin = skin;
				mens.destaque = destaque;
				mens.title = "";
				nomeMenu = "semItem";
			}else
			{
				opcoes = new string[H.itens.Count];
				for(int i=0;i<H.itens.Count;i++)
				{
					opcoes[i] = item.nomeEmLinguas(H.itens[i].ID)+"  :"+H.itens[i].estoque;
				}
				menu = gameObject.AddComponent<Menu>();

				menu = menu.detalhesBase(menu,"Itens",opcoes,skin,destaque);
				nomeMenu = menu.Nome;
				menu.posYalvo = 0.12f;
				menu.aMenu = 0.1f*H.itens.Count;
				principal.podeMudar = false;
			}
			
		break;
		case 2:
			menu = gameObject.AddComponent<Menu>();
			principal.podeMudar = false;
			opcoes = H.nomesCriaturesHeroi();
			menu = menu.detalhesBase(menu,"Suporte",opcoes,skin,destaque);
			nomeMenu = menu.Nome;
			menu.posYalvo = 0.22f;
			menu.aMenu = 0.1f*H.criaturesAtivos.Count;
			
		break;
		case 3:
			menu = gameObject.AddComponent<Menu>();
			principal.podeMudar = false;
			string[] caos = tMIT2["mitOrg"].ToArray();//{"Criatures","Golpes","Itens Rapidos"};
			opcoes = caos;
			menu = menu.detalhesBase(menu,"Organizaçao",opcoes,skin,destaque);
			menu.posYalvo = 0.32f;
			menu.aMenu = 0.3f;
			nomeMenu = menu.Nome;
		break;
		case 4:
			menu = gameObject.AddComponent<Menu>();
			principal.podeMudar = false;

			List<string> opcoes2 = saveGame.jogosSalvos();
			opcoes2.Add(tMIT2["mitSoltos"][0]);
			menu = menu.detalhesBase(menu,"escolhaSave",opcoes2.ToArray(),skin,destaque);
			menu.posYalvo = 0.32f;
			menu.aMenu = 0.1f*opcoes2.Count;
			nomeMenu = menu.Nome;

		break;
		}
		}catch(NullReferenceException e)
		{
			Debug.LogWarning("Nulidade do Menu Itens "+e.InnerException);
		}

	}

	void FechaMenu(string nome)
	{
		if(nome != "todos")
		{
			Menu[] menus = GetComponents<Menu>();
			foreach(Menu menu in menus)
			{
				if(menu.Nome == nome)
					menu.fechaJanela();
			}
		}
	}
}

