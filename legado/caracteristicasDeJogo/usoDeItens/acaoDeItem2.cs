using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class acaoDeItem2 : abaixoDeMenu {
	public nomeIDitem nomeItem;
	public string estadoPublico = "usandoItem";

	private bool acao = false;
	private bool menuEAux = false;
	private string[] opcoes;
	private bool giraCam;
	private float tempoDeAcao;
	private int janelaDetroca = 0;
	private string proxAcao;
	private string[] textos;
	private Vector3 paraCor = new Vector3(1,1,1);
	private string mensCorrente;
	private string oQ;
	
	public GUISkin destaque;

	protected heroi H;
	protected string acaoAtual;
	protected elementosDoJogo elementos;

	// Use this for initialization
	void Start () {
		textos = bancoDeTextos.falacoes[heroi.lingua]["itens"].ToArray();
		elementos = elementosDoJogo.el;
		H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();
		switch(nomeItem)
		{
		case nomeIDitem.maca:
		case nomeIDitem.burguer:
		case nomeIDitem.pergaminhoDePerfeicao:
		case nomeIDitem.gasolina:
		case nomeIDitem.regador:
		case nomeIDitem.aguaTonica :
		case nomeIDitem.pilha :
		case nomeIDitem.estrela :
		case nomeIDitem.quartzo :
		case nomeIDitem.adubo :
		case nomeIDitem.seiva :
		case nomeIDitem.inseticida :
		case nomeIDitem.aura  :
		case nomeIDitem.repolhoComOvo :
		case nomeIDitem.geloSeco :
		case nomeIDitem.ventilador :
		case nomeIDitem.antidoto:
		case nomeIDitem.tonico:
		case nomeIDitem.amuletoDaCoragem:
			perguntaQuem();
		break;
		case nomeIDitem.pergDeRajadaDeAgua:
		case nomeIDitem.pergSabre:
		case nomeIDitem.pergGosmaDeInseto:
		case nomeIDitem.pergGosmaAcida:
		case nomeIDitem.pergMultiplicar:
		case nomeIDitem.pergVentania:
		case nomeIDitem.pergVentosCortantes:
		case nomeIDitem.pergOlharParalisante:
		case nomeIDitem.pergOlharMal:
		case nomeIDitem.pergFuracaoDeFolhas:
			perguntaQuem("golpe");
		break;
		case nomeIDitem.pergSaida:
		case nomeIDitem.pergArmagedom:
			perguntaTemCerteza();
		break;
		default:
			acaoAtual = "naoUsar";
			mensCorrente = textos[0];
			proxAcao = "naoUsarAberta";
		break;
		}
	}

	void perguntaTemCerteza()
	{
		mensagemBasica mens = gameObject.AddComponent<mensagemBasica>();
		mens.posX = 0.01f;
		mens.posY = 0.68f;
		mens.mensagem  = string.Format(textos[8],item.nomeEmLinguas(nomeItem));
		mens.skin = skin;
		
		Menu menu = gameObject.AddComponent<Menu>();
		
		
		menu.opcoes = bancoDeTextos.falacoes[heroi.lingua]["simOuNao"].ToArray();
		menu.posXalvo = 0.7f;
		menu.posYalvo = 0.4f;
		menu.aMenu = 0.2f;
		menu.lMenu = 0.2f;
		menu.skin = skin;
		menu.Nome = "simOuNao";
		menu.destaque = destaque;

		acaoAtual = "respondendoSimOuNao";

		switch(nomeItem)
		{
		case nomeIDitem.pergArmagedom:
			proxAcao = "usarArmagedom";
		break;
		case nomeIDitem.pergSaida:
			proxAcao = "usarSaida";
		break;
		}

	}

	Menu retornaMenu(string nome)
	{
		Menu retorno = null;
		Menu[] menus = GetComponents<Menu>();
		foreach(Menu menu in menus)
		{
			if(menu.Nome == nome)
				retorno = menu;
		}
		return retorno;
	}

	void perguntaQuem(string oQq = "vida")
	{
		oQ = oQq;
		Menu menu = gameObject.AddComponent<Menu> ();
		opcoes = new string[H.criaturesAtivos.Count];
		for(int i=0;i<H.criaturesAtivos.Count;i++)
		{
			opcoes[i] = H.criaturesAtivos[i].Nome;
		}
		menu.posYalvo = 0.13f;
		menu.aMenu = 0.1f*H.criaturesAtivos.Count;
		menu = menu.detalhesBase(menu,"perguntaQuem",opcoes,skin,destaque);
		menu.posXalvo = 0.43f;
		acaoAtual = "respondeQuem";

		switch(oQ)
		{
		case "vida":
			mostraOSelecionado(gameObject,H.criaturesAtivos[(int)menu.escolha],(int)menu.escolha);
		break;
		}
	}

	void restaura(uint tanto,int quem,int oQ = 0)
	{
		if(H.criaturesAtivos[quem].cAtributos[oQ].Corrente<H.criaturesAtivos[quem].cAtributos[oQ].Maximo
		   &&
		   H.criaturesAtivos[quem].cAtributos[0].Corrente>0)
			if(H.criaturesAtivos[quem].cAtributos[oQ].Corrente+tanto<H.criaturesAtivos[quem].cAtributos[oQ].Maximo)
				H.criaturesAtivos[quem].cAtributos[oQ].Corrente+=tanto;
			else
				H.criaturesAtivos[quem].cAtributos[oQ].Corrente = H.criaturesAtivos[quem].cAtributos[oQ].Maximo;
		else if (H.criaturesAtivos[quem].cAtributos[0].Corrente>0)
			acaoAtual = "eleNaoPrecisa";
		else{
			acaoAtual = "naoUsar";
			mensCorrente = string.Format(textos[2],H.criaturesAtivos[quem].Nome);
			proxAcao = "naoUsarQuemAberta";
		}
	}

	public static void estadoPerfeito(Criature C,int quem)
	{
		atributos[] aH = C.cAtributos;
		aH[0].Corrente = aH[0].Maximo;
		aH[1].Corrente = aH[1].Maximo;
		statusTemporarioBase.limpaStatus(C,quem);
		if(quem==0)			
			statusTemporarioBase.retiraComponenteStatus(tipoStatus.todos,GameObject.Find("CriatureAtivo"));
		else
			statusTemporarioBase.retiraStatusDoGerente(C);
	}

	void perfeicao(int quem)
	{
		Criature C = H.criaturesAtivos[quem];
		atributos[] aH = C.cAtributos;
		if((aH[0].Corrente<aH[0].Maximo
		   ||
		   aH[1].Corrente<aH[1].Maximo)
		   &&
		   aH[0].Corrente>0
		   )
		{
			estadoPerfeito(C,quem);
		}else if (H.criaturesAtivos[quem].cAtributos[0].Corrente>0)
			acaoAtual = "eleNaoPrecisa";
		else{
			acaoAtual = "naoUsar";
			mensCorrente = string.Format(textos[2],H.criaturesAtivos[quem].Nome);
			proxAcao = "naoUsarQuemAberta";
		}
	}

	public static void retiraStatusTemporario(int quem,tipoStatus nomeStatus,heroi H)
	{
		Criature C = H.criaturesAtivos[quem];

		if(quem == 0)
		{
			statusTemporarioBase.retiraComponenteStatus(
				nomeStatus,
				GameObject.Find("CriatureAtivo"));

		}
		else
		{
			statusTemporarioBase.retiraStatusDoGerente(C,tipoStatus.envenenado);
		}

		statusTemporarioBase.tiraStatus(nomeStatus,C.statusTemporarios);

	}

	tipoStatus statusDesseItem()
	{
		tipoStatus retorno = tipoStatus.nulo;
		switch(nomeItem)
		{
		case nomeIDitem.antidoto:
			retorno = tipoStatus.envenenado;
		break;
		case nomeIDitem.tonico:
			retorno  =tipoStatus.paralisado;
		break;
		case nomeIDitem.amuletoDaCoragem:
			retorno = tipoStatus.amedrontado;
		break;
		}

		return retorno;
	}

	void verificaUsoComQuem()
	{
		int quem = (int)retornaMenu("perguntaQuem").escolha;
		switch(nomeItem)
		{
		case nomeIDitem.maca:
			acaoAtual = "usandoMaca";
			restaura(10,quem);
		break;
		case nomeIDitem.burguer :
			acaoAtual = "usandoMaca";
			restaura(40,quem);
		break;
		case nomeIDitem.pergaminhoDePerfeicao:
			acaoAtual = "usandoPerfeicao";
			perfeicao(quem);
		break;
		case nomeIDitem.antidoto:
		case nomeIDitem.amuletoDaCoragem:
		case nomeIDitem.tonico:
			tipoStatus statusDoItem = statusDesseItem();
			if(statusTemporarioBase.contemStatus(statusDoItem,H.criaturesAtivos[quem])>-1)
			{
				retiraStatusTemporario(quem,statusDoItem,H);
				acaoAtual = "animandoAntidoto";
			}else
			{
				acaoAtual = "eleNaoPrecisa";
			}
		break;
		case nomeIDitem.gasolina:
		case nomeIDitem.regador:
		case nomeIDitem.aguaTonica :
		case nomeIDitem.pilha :
		case nomeIDitem.estrela :
		case nomeIDitem.quartzo :
		case nomeIDitem.adubo :
		case nomeIDitem.seiva :
		case nomeIDitem.inseticida :
		case nomeIDitem.aura  :
		case nomeIDitem.repolhoComOvo :
		case nomeIDitem.geloSeco :
		case nomeIDitem.ventilador :
			esseUsaIsso e = verifiqueEsseUsaIsso(nomeItem,quem);

			if(e.eleUsa)
			{
				acaoAtual="usandoMaisPE";
				restaura(40,quem,1);
			}else
			{
				acaoAtual = "naoUsar";
				mensCorrente = textos[3]+ e.oTipo +textos[4];
				proxAcao = "naoUsarQuemAberta";
			}
		break;
		case nomeIDitem.pergDeRajadaDeAgua:
		case nomeIDitem.pergSabre:
		case nomeIDitem.pergGosmaDeInseto:
		case nomeIDitem.pergGosmaAcida:
		case nomeIDitem.pergMultiplicar:
		case nomeIDitem.pergVentania:
		case nomeIDitem.pergVentosCortantes:
		case nomeIDitem.pergOlharParalisante:
		case nomeIDitem.pergOlharMal:
		case nomeIDitem.pergFuracaoDeFolhas:

			Criature C = H.criaturesAtivos[quem];
			nomesGolpes[] nomeDoGolpeDesseItem = golpeDesseItem();
			nivelGolpe nG = C.GolpeNaLista(nomeDoGolpeDesseItem);

		   if(nG.nome != nomesGolpes.nulo)
			{
			   if(!C.NosMeusGolpes(nomeDoGolpeDesseItem))
				{
					escondeTodosMenus();
					acaoAtual = "";
					encontros E = GameObject.Find("Terrain").GetComponent<encontros>();

					E.aprendeuGolpeForaDoEncontro(C,nG);
				}else
				{
					acaoAtual = "naoUsar";
					mensCorrente = string.Format(textos[5],C.Nome,
					                             item.nomeEmLinguas(nomeItem),
					                             golpe.nomeEmLinguas(
													new pegaUmGolpe(nG.nome).OGolpe()
												 ));
					proxAcao = "naoUsarQuemAberta";
				}
			}else
			{
				acaoAtual = "naoUsar";
				mensCorrente = string.Format(textos[6],C.Nome, new pegaUmGolpe(nG.nome).OGolpe().Nome);
				proxAcao = "naoUsarQuemAberta";
			}

		break;
		}
	}

	public void finalisaAprendeGolpe()
	{
		int quem = (int)retornaMenu("perguntaQuem").escolha;
		Criature C = H.criaturesAtivos[quem];
		nomesGolpes[] nomeDoGolpeDesseItem = golpeDesseItem();

		if(C.NosMeusGolpes(nomeDoGolpeDesseItem))
		{
			acaoAtual = "animandoNovoGolpe";
		}else
		{
			retornaMenusEscondidos();
			acaoAtual = "naoUsar";
			mensCorrente = string.Format(textos[7],C.Nome,item.nomeEmLinguas(nomeItem));
			proxAcao = "naoUsarQuemAberta";
		}
	}

	nomesGolpes[] golpeDesseItem()
	{
		List<nomesGolpes> retorno = new List<nomesGolpes>();
		switch(nomeItem)
		{
		case nomeIDitem.pergDeRajadaDeAgua:
			retorno.Add(nomesGolpes.rajadaDeAgua);
		break;
		case nomeIDitem.pergSabre:
			retorno.Add(nomesGolpes.sabreDeBastao);
			retorno.Add(nomesGolpes.sabreDeAsa);
			retorno.Add(nomesGolpes.sabreDeEspada);
			retorno.Add(nomesGolpes.sabreDeNadadeira);
		break;
		case nomeIDitem.pergGosmaDeInseto:
			retorno.Add(nomesGolpes.gosmaDeInseto);
		break;
		case nomeIDitem.pergGosmaAcida:
			retorno.Add(nomesGolpes.gosmaAcida);
		break;
		case nomeIDitem.pergMultiplicar:
			retorno.Add(nomesGolpes.multiplicar);
		break;
		case nomeIDitem.pergVentania:
			retorno.Add(nomesGolpes.ventania);
		break;
		case nomeIDitem.pergVentosCortantes:
			retorno.Add(nomesGolpes.ventosCortantes);
		break;
		case nomeIDitem.pergOlharParalisante:
			retorno.Add(nomesGolpes.olharParalisante);
		break;
		case nomeIDitem.pergOlharMal:
			retorno.Add(nomesGolpes.olharMal);
		break;
		case nomeIDitem.pergFuracaoDeFolhas:
			retorno.Add(nomesGolpes.furacaoDeFolhas);
		break;
		}

		return retorno.ToArray();
	}


	

	protected bool temOTipo( nomeTipos tipo ,int quem)
	{
		print(quem);
		bool retorno = false;
		for(int i=0;i<H.criaturesAtivos[quem].meusTipos.Length;i++)
		{
			if(H.criaturesAtivos[quem].meusTipos[i].ToString() == tipo.ToString())
				retorno = true;
		}

		return retorno;
	}

	public struct esseUsaIsso
	{
		public string oTipo;
		public bool eleUsa;
	}

	protected esseUsaIsso verifiqueEsseUsaIsso(nomeIDitem esseItem,int quem)
	{
		esseUsaIsso retorno = new esseUsaIsso {oTipo = "",eleUsa = false};
		//bool eleUsa = false;
		//string oTipo = "";
		switch(esseItem)
		{
		case nomeIDitem.gasolina:
			retorno.oTipo = nomeTipos.Fogo.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Fogo,quem);
		break;
		case nomeIDitem.regador :
			retorno.oTipo = nomeTipos.Planta.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Planta,quem);
		break;
		case nomeIDitem.aguaTonica :
			retorno.oTipo = nomeTipos.Agua.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Agua,quem);
		break;
		case nomeIDitem.pilha : 
			retorno.oTipo = nomeTipos.Eletrico.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Eletrico,quem);
		break;
		case nomeIDitem.estrela : 
			retorno.oTipo = nomeTipos.Normal.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Normal,quem);
		break;
		case nomeIDitem.quartzo :
			retorno.oTipo = nomeTipos.Pedra.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Pedra,quem);
		break;
		case nomeIDitem.adubo :
			retorno.oTipo = nomeTipos.Terra.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Terra,quem);
		break;
		case nomeIDitem.seiva :
			retorno.oTipo = nomeTipos.Inseto.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Inseto,quem);
		break;
		case nomeIDitem.inseticida : 
			retorno.oTipo = nomeTipos.Veneno.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Veneno,quem);
		break;
		case nomeIDitem.aura :
			retorno.oTipo = nomeTipos.Psiquico.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Psiquico,quem);
		break;
		case nomeIDitem.repolhoComOvo :
			retorno.oTipo = nomeTipos.Gas.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Gas,quem);
		break;
		case nomeIDitem.geloSeco :
			retorno.oTipo = nomeTipos.Gelo.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Gelo,quem);
		break;
		case nomeIDitem.ventilador :
			retorno.oTipo = nomeTipos.Voador.ToString();
			retorno.eleUsa = temOTipo(nomeTipos.Voador,quem);
		break;
		}

		return retorno;


	}

	static int IndiceDoItem(nomeIDitem nome,heroi H)
	{
		int oItem = -1;
		for (int i=0; i<H.itens.Count; i++)
			if (nome == H.itens [i].ID)
				oItem = i;
		return oItem;
	}

	int numeroDeItens(nomeIDitem nome)
	{
		print (nome + " : " + H.itens [0].nome);
		return H.itens [IndiceDoItem(nome,H)].estoque;
	}

	void atualizaMenuItem()
	{

		Menu menu = retornaMenu ("Itens");
		opcoes = new string[H.itens.Count];
		for(int i=0;i<H.itens.Count;i++)
		{
			opcoes[i] = item.nomeEmLinguas(H.itens[i].ID)+" :"+H.itens[i].estoque;
		}
		menu.opcoes = opcoes;
		menu.aMenu = 0.1f*H.itens.Count;
	}

	public static void retiraItem(nomeIDitem nome,int retirada,heroi H)
	{
		int indice = IndiceDoItem (nome,H);
		H.itens [indice].estoque-=retirada;
		if(H.itens [indice].estoque<=0)
		{
			H.itens.RemoveAt(indice);
			if(H.itemAoUso==indice && indice>=H.itens.Count&&H.itens.Count>0)
			{

				H.itemAoUso--;
			}

			/*
			item[] itens = new item[H.itens.Count -1];
			for(int i=0;i<H.itens.Count-1;i++)
				if(i < indice)
					itens[i] = H.itens[i];
				else
					itens[i] = H.itens[i+1];

			H.itens = itens;
			*/
		}

	}

	protected void giraCameraCriature(Transform meuCriature)
	{

		centralizaEGiraCamera c = gameObject.AddComponent<centralizaEGiraCamera> ();
		GameObject.FindGameObjectWithTag ("Player").GetComponent<cameraPrincipal> ().enabled = false;
		c.T = meuCriature.transform;
	}

	protected void escondeTodosMenus()
	{
		Menu[] menus = GetComponents<Menu> ();
		foreach (Menu menu in menus)
			menu.entrando = false;

		if(GetComponent<mensagemEmLuta>())
			GetComponent<mensagemEmLuta>().entrando = false;
	}

	protected void instancieEDestrua(GameObject instanciado,Vector3 emQ,float tempoDeDestruicao)
	{
		instanciado = Instantiate(instanciado,emQ,Quaternion.identity)as GameObject;
		Destroy(instanciado,tempoDeDestruicao);
	}

	protected void animaUsaItem(uint quem,string animacao = "acaoDeCura1"){
		if (numeroDeItens (nomeItem) > 0) {
			retiraItem (nomeItem,1,H);

			if(GetComponent<Menu>())
				atualizaMenuItem ();

			escondeTodosMenus();
			tempoDeAcao = 0;
			if (quem == 0) {
	 					Transform meuCriature = GameObject.Find ("CriatureAtivo").transform;
						giraCameraCriature(meuCriature);
						acaoAtual = "animandoVida";
						instancieEDestrua(elementos.retorna (animacao),meuCriature.position,1);
			}else
			{	
				acaoAtual = "animandoVidaFora";
				Vector3 ilusaoDeCura = GameObject.FindWithTag("Player").transform.position;
				instancieEDestrua(elementos.retorna (animacao),ilusaoDeCura,1);
			}
				}
	}

	void animandoVida()
	{
		tempoDeAcao += Time.deltaTime;
		if(tempoDeAcao>2f || Input.GetButtonDown("acaoAlt")|| Input.GetButtonDown("acao") || Input.GetButtonDown("menu e auxiliar"))
		{
			//GameObject.FindGameObjectWithTag("Player").GetComponent<cameraPrincipal>().enabled = true;
			finalisaACura();
			Destroy(GetComponent<centralizaEGiraCamera>());

		}
	}

	void retornaMenusEscondidos()
	{
		Menu[] menus = GetComponents<Menu>();
		foreach(Menu menu in menus)
			menu.entrando = true;


		mensagemEmLuta mL = GetComponent<mensagemEmLuta>();
		if(mL)
			mL.entrando = true;
			
	}

	void finalisaACura()
	{
		retornaMenusEscondidos();

		vidaEmLuta v = GetComponent<vidaEmLuta>();

		if(v)
			v.alteraCor(new Color(1,1,1,1));

		if(shopBasico.temItem(nomeItem,H)>-1){
			acaoAtual = "respondeQuem";
			retornaMenu("perguntaQuem").podeMudar = true;
		}
		else
		{
			estadoPublico =	"retornarAosItens";
			retornaMenu("perguntaQuem").fechaJanela();
			fechaJanela();
		}

	}


	void animandoVidaFora()
	{
		
		tempoDeAcao += Time.deltaTime;
		Vector3 maisUmV;
		if(tempoDeAcao<1){

			switch(nomeItem)
			{
			case nomeIDitem.maca  :			
			case nomeIDitem.burguer :
				maisUmV = new Vector3(0,1,0);
			break;
			case nomeIDitem.gasolina:
			case nomeIDitem.regador:
			case nomeIDitem.aguaTonica :
			case nomeIDitem.pilha :
			case nomeIDitem.estrela :
			case nomeIDitem.quartzo :
			case nomeIDitem.adubo :
			case nomeIDitem.seiva :
			case nomeIDitem.inseticida :
			case nomeIDitem.aura  :
			case nomeIDitem.repolhoComOvo :
			case nomeIDitem.geloSeco :
			case nomeIDitem.ventilador :
				maisUmV = new Vector3(1,1,0);
			break;
			default:
				maisUmV = new Vector3(0,1,0);
			break;
			}

		}else
			maisUmV = new Vector3(1,1,1);

		paraCor = Vector3.Slerp(paraCor,maisUmV,3*Time.deltaTime);
		Color cor = new Color(paraCor.x,paraCor.y,paraCor.z,1);
		vidaEmLuta v = GetComponent<vidaEmLuta>();
		if(v)
			v.alteraCor(cor);
		if(tempoDeAcao>2f || Input.GetButtonDown("acaoAlt")|| Input.GetButtonDown("acao") || Input.GetButtonDown("menu e auxiliar"))
		{
			finalisaACura();
		}
	}

	void verificaUsoDePergArmagedom()
	{
		encontros E = GameObject.Find("Terrain").GetComponent<encontros>();
		
		if(E.saidas.Count==0)
		{			
			pergaminhoDeArmagedom pergA =  gameObject.AddComponent<pergaminhoDeArmagedom>();
			pergA.C = Color.red;
			pergA.H = H;
			acaoAtual = "";
			retiraItem (nomeItem,1,H);
			estadoPublico = "limpaMIT";
			escondeTodosMenus();
			movimentoBasico.pararFluxoHeroi();
			Destroy(this,10f);
			acaoAtual = "";
		}else
		{
			acaoAtual = "naoUsar";
			proxAcao = "naoUsarAberta";
			mensCorrente = textos[9];
		}
	}

	void verificaUsoDeSaida()
	{
		encontros E = GameObject.Find("Terrain").GetComponent<encontros>();
		if(E)
		{
			if(E.saidas.Count>0)
			{
				saidaDeCaverna S = E.saidas[0];
				for(int i=0;i<E.saidas.Count;i++)
				{
					if(E.saidas[i].entreiPorAqui)
						S = E.saidas[i];
				}

				pergaminhoDeSaida pergS =  gameObject.AddComponent<pergaminhoDeSaida>();
				pergS.S = S;
				acaoAtual = "";
				retiraItem (nomeItem,1,H);
			}else
			{
				acaoAtual = "naoUsar";
				proxAcao = "naoUsarAberta";
				mensCorrente = textos[9];
			}
		}else
		{
			acaoAtual = "naoUsar";
			proxAcao = "naoUsarAberta";
			mensCorrente = textos[9];
		}

	}

	// Update is called once per frame
	void Update () {
		mensagemBasica mens = null;
		Menu menu = null;

		bool acaoAlt = Input.GetButtonDown("acaoAlt");

		if (Input.GetButtonDown ("acao"))
						acao = true;

		if (Input.GetButtonDown ("menu e auxiliar"))
						menuEAux = true;


		switch(acaoAtual)
		{
		case "respondeQuem":
			if(acaoAlt)
			{
				if(retornaMenu("perguntaQuem").dentroOuFora()>-1)
					acao = true;
				else 
					menuEAux = true;
			}

			if(acao){
				retornaMenu("perguntaQuem").podeMudar = false;
				verificaUsoComQuem();
			}

			//if(nomeItem=="Maça"||nomeItem=="Burguer")
			if(janelaDetroca != retornaMenu("perguntaQuem").escolha)
			{
				int essaEscolha = (int)retornaMenu("perguntaQuem").escolha;
				deslizaOuFecha(gameObject,essaEscolha);
				if(oQ!="golpe")
					mostraOSelecionado(gameObject,H.criaturesAtivos[essaEscolha],
				                   essaEscolha);
				janelaDetroca = essaEscolha;
			}

			if(menuEAux)
			{
				menu = retornaMenu("perguntaQuem");
				menu.fechaJanela();
				estadoPublico = "retornarAosItens";
				deslizaOuFecha(gameObject,(int)retornaMenu("perguntaQuem").escolha);
				fechaJanela();
			}
		break;

		case "naoUsarQuem":
			mens  = gameObject.AddComponent<mensagemBasica>();
			mens.posY = 0.68f;
			mens.mensagem =textos[0];
			mens.skin = skin;
			mens.destaque = destaque;
			mens.title = "";
			acaoAtual = "naoUsarQuemAberta";
		break;

		case "naoUsarQuemAberta":
			if(menuEAux){
				mens = GetComponent<mensagemBasica>();
				mens.fechaJanela ();
				acaoAtual = "respondeQuem";
				retornaMenu("perguntaQuem").podeMudar = true;
			}
		break;
		case "eleNaoPrecisa":
			mens  = gameObject.AddComponent<mensagemBasica>();
			mens.posY = 0.68f;
			mens.mensagem =textos[1];
			mens.skin = skin;
			mens.destaque = destaque;
			mens.title = "";
			acaoAtual = "naoUsarQuemAberta";
		break;

		case "usandoMaca":
			animaUsaItem(retornaMenu ("perguntaQuem").escolha);
		break;

		case "usandoPerfeicao":
			animaUsaItem(retornaMenu ("perguntaQuem").escolha,"perfeicao");
		break;

		case "usandoMaisPE":
			animaUsaItem(retornaMenu ("perguntaQuem").escolha,"animaPE");
		break;
		
		case "animandoNovoGolpe":
			animaUsaItem(retornaMenu ("perguntaQuem").escolha,"animaNovoGolpe");
		break;

		case "animandoVida":
			animandoVida();
		break;

		case "animandoVidaFora":
			animandoVidaFora();
		break;

		case "animandoAntidoto":
			animaUsaItem(retornaMenu ("perguntaQuem").escolha,"animaPE");
		break;

		case "respondendoSimOuNao":
			if(acaoAlt)
				if(retornaMenu("simOuNao").dentroOuFora()>-1)
					acao = true;

			if(acao)
			{
				Menu M = retornaMenu("simOuNao");
				if(M.escolha == 0)
	
					acaoAtual = proxAcao;
	
				else
				{
					estadoPublico = "retornarAosItens";
					fechaJanela();
				}

				M.fechaJanela();
				GetComponent<mensagemBasica>().fechaJanela();
			}
		break;
		
		case "usarSaida":
			verificaUsoDeSaida();
		break;
		
		case "usarArmagedom":
			verificaUsoDePergArmagedom();
		break;

		case "naoUsarAberta":
			if(menuEAux||acao)
			{
				mens = GetComponent<mensagemBasica>();
				mens.fechaJanela();
				estadoPublico = "retornarAosItens";
				fechaJanela();
			}
		break;

		case "naoUsar":
			mens  = gameObject.AddComponent<mensagemBasica>();
			mens.posY = 0.68f;
			mens.mensagem = mensCorrente;
			mens.skin = skin;
			mens.destaque = destaque;
			mens.title = "";
			acaoAtual = proxAcao;
		break;
		}
		acao = false;
		menuEAux = false;
	}
}
