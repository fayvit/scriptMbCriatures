using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shopBasico : shopBase {

	[System.Serializable]
	public class vendendo
	{
		public nomeIDitem nomeItem;
		public int valor;
	}
	
	public List<vendendo> aVenda = new List<vendendo>();



	private string[] info;
	private mensagemEmLuta mL2;

	//private pausaJogo pJ;

	private uint menuEscolhaAntiga = 0;
	private uint menu2EscolhaAntiga = 0;



	// Use this for initialization
	new void Start () {
		base.Start();
		conversa = bancoDeTextos.falacoes[heroi.lingua]["Shop1"].ToArray();
		info = bancoDeTextos.falacoes[heroi.lingua]["shopInfoItem"].ToArray();
	}

	
	// Update is called once per frame
	void Update () {

		if(((noLugar && 
		     Vector3.Distance(T.position,transform.position)<5 
		     && (mB.podeAndar==true && mB.enabled==true) )|| estado!="emEspera")
		   	 &&!pausaJogo.pause)
		{
			leituraDoShop();
		}
	}

	void leituraDoShop()
	{
		acao = Input.GetButtonDown("acao");
		menuEAux = Input.GetButtonDown("menu e auxiliar");
		bool acaoAlt = Input.GetButtonDown("acaoAlt");
		switch(estado)
		{
		case "emEspera":
			if(acao||acaoAlt)
				conversaNoShop();
		break;
		case "iniciouConversa":
			if(acao || menuEAux||acaoAlt)
			{
				mens.entrando = false;
				estado = "mostraItens";
				mostraItens();
			}
		break;
		case "mostraItens":

			if(menu2.escolha!=menu2EscolhaAntiga)
			{
				//print("um");
				//print(menu2.escolha+" : "+menu.escolha+" : "+menu2EscolhaAntiga);
				menu2EscolhaAntiga = menu2.escolha;
				menuEscolhaAntiga = menu2.escolha;
				menu.escolha = menu2.escolha;
				trocaInfo();
			}
			
			if(menu.escolha != menuEscolhaAntiga)
			{
				//print("dois");
				menuEscolhaAntiga = menu.escolha;
				menu2.escolha = menu.escolha;
				menu2EscolhaAntiga = menu.escolha;
				//print(menu2.escolha+" : "+menu.escolha+" : "+menu2EscolhaAntiga);
				trocaInfo();
			}


			if(acaoAlt&&(menu.dentroOuFora()>-1||menu2.dentroOuFora()>-1))
				acao = true;
			else if(acaoAlt)
				menuEAux = true;


			if(menuEAux)
			{
				estado = "despedida";
				mens.mensagem = conversa[1];
				mens.entrando = true;
			}

			
			if(acao)
				comprando();




		break;
		case "despedida":
			if(acao|| menuEAux||acaoAlt)
				voltaAPasseio();
		break;
		case "comprou":
			if(acao||menuEAux||acaoAlt)
				retornaInicia();
		break;
		case "fechaMensEvoltaInicial":
			if(acao|| menuEAux||acaoAlt)
			{
				mens.entrando = false;
				estado = "";
				Invoke("retornaInicia",0.15f);
			}
		break;
		case "mensagemDeComprouAnubis":
			if(acao|| menuEAux||acaoAlt)
			{
				mens.entrando = false;
				estado = "";
				Invoke("mensEstatuaMisteriosa",0.15f);
			}
		break;
		}
	}

	void mensEstatuaMisteriosa()
	{
		resgataItem(nomeIDitem.estatuaMisteriosa);
		variaveisChave.shift["comprouEstatuaDoAnubis"] = true;
		aVenda.RemoveAt(3);
		menu.escolha = 0;
		menu2.escolha = 0;
		opcoesMenu();
	}

	void trocaInfo()
	{

		mL2.entrando = false;


		Invoke("voltaML2",0.15f);
	}

	void voltaML2()
	{
		mL2.mensagem = info[(int)(aVenda[(int)menu.escolha].nomeItem)];
		mL2.entrando=true;
	}

	void retornaInicia()
	{
		mens.entrando = false;
		menu.podeMudar = true;
		menu2.podeMudar = true;
		menu.entrando = true;
		menu2.entrando = true;
		mL2.entrando = true;
		estado = "mostraItens";
	}

	public static int temItem(nomeIDitem nomeItem,heroi H)
	{
		int ondeTem = -1;
		for(int i=0;i<H.itens.Count;i++)
		{
			if(H.itens[i].ID == nomeItem)
			{
				ondeTem = i;
			}
		}
		
		return ondeTem;
	}

	public static void adicionaItem(nomeIDitem nomeItem,heroi H,int quantidade)
	{
		for(int i=0;i<quantidade;i++)
		{
			adicionaItem(nomeItem,H);
		}
	}

	public static void adicionaItem(nomeIDitem nomeItem,heroi H)
	{
		item I = new item(nomeItem);
		bool foi = false;
		if(I.acumulavel>1)
		{
			
			int ondeTem = -1;
			for(int i=0;i<H.itens.Count;i++)
			{
				if(H.itens[i].nome == I.nome)
				{
					if(H.itens[i].estoque<H.itens[i].acumulavel)
					{
						if(!foi)
						{
							ondeTem = i;
							foi = true;
						}
					}
				}
			}
			
			if(foi)
			{
				H.itens[ondeTem].estoque++; 
			}else
			{
				H.itens.Add(new item(nomeItem));
			}
		}else
		{
			H.itens.Add(new item(nomeItem));
		}
	}

	void resgataItem(nomeIDitem nomeItem)
	{
		estado = "comprou";
		H.cristais-=(uint)aVenda[(int)menu.escolha].valor;

		adicionaItem(nomeItem,H);

		mL.mensagem = "CRISTAIS: \r\n "+H.cristais;
		menu.entrando = false;
		menu2.entrando = false;
		mL2.entrando = false;
		mens.entrando = true;

		if(aVenda[(int)menu.escolha].nomeItem!=nomeIDitem.segredo)
			mens.mensagem = conversa[8];
		else if(aVenda[(int)menu.escolha].nomeItem==nomeIDitem.segredo)
			mens.mensagem = conversa[7];

	}

	void perguntasDoSegredo()
	{
		if(variaveisChave.contadorChave["vezesTentandoComprarAnubis"]<3)
		{
			mens.entrando = true;
			mens.mensagem = conversa[3+variaveisChave.contadorChave["vezesTentandoComprarAnubis"]];
			estado = "fechaMensEvoltaInicial";
		}else
		{
			mens.entrando = true;
			mens.mensagem = conversa[6];
			estado = "mensagemDeComprouAnubis";
		}
		
		variaveisChave.contadorChave["vezesTentandoComprarAnubis"]++;
	}

	void comprando()
	{
		menu.podeMudar = false;
		menu2.podeMudar = false;

		if(H.cristais>=aVenda[(int)menu.escolha].valor)
		{
			if(aVenda[(int)menu.escolha].nomeItem!=nomeIDitem.segredo)
				resgataItem(aVenda[(int)menu.escolha].nomeItem);
			else if(aVenda[(int)menu.escolha].nomeItem==nomeIDitem.segredo)
			{
				perguntasDoSegredo();
			}
		}
		else
		{
			mens.entrando =true;
			mens.mensagem = conversa[2];
			estado = "fechaMensEvoltaInicial";
		}

	}

	new void voltaAPasseio()
	{
		base.voltaAPasseio();
		mL2.fechaJanela();

		
	}

	void opcoesMenu()
	{
		string[] opcoes = new string[aVenda.Count];
		string[] opcoes2 = new string[aVenda.Count];
		
		for(int i=0;i<aVenda.Count;i++)
		{
			opcoes[i] = item.nomeEmLinguas(aVenda[i].nomeItem);
			opcoes2[i] = aVenda[i].valor.ToString();
		}

		menu.opcoes = opcoes;
		menu2.opcoes = opcoes2;
		menu.aMenu = aVenda.Count*0.1f;
		menu2.aMenu = aVenda.Count*0.1f;
	}



	void mostraItens()
	{
		if(aVenda.Count>0)
		{

			
			
			menu = G.AddComponent<Menu>();
			menu.posXalvo = 0.01f;
			menu.posYalvo = 0.01f;


			menu.skin = skin;
			menu.lMenu = 0.3f;
			
			menu.destaque = destaque;
			menu.sobraAbaixo = 0.35f;
			
			
			menu2 = G.AddComponent<Menu>();
			menu2.posXalvo = 0.31f;
			menu2.posYalvo = 0.01f;


			menu2.skin = skin;
			menu2.lMenu = 0.15f;
			
			menu2.destaque = destaque;
			menu2.sobraAbaixo = 0.35f;

			opcoesMenu();
			
			mL = G.AddComponent<mensagemEmLuta>();
			mL.posX = 0.5f;
			mL.posY = 0.01f;
			mL.tempoDeFuga = 0;
			mL.emY = true;
			mL.mensagem = "CRISTAIS: \r\n "+H.cristais;

			mL2 = G.AddComponent<mensagemEmLuta>();
			mL2.posX = 0.57f;
			mL2.posY = 0.52f;
			mL2.lCaixa = 0.4f;
			mL2.tempoDeFuga = 0;
			mL2.positivo = true;
			mL2.mensagem = info[(int)(aVenda[0].nomeItem)];
		}
	}

	void conversaNoShop()
	{
		cam.enabled = false;
		estado = "iniciouConversa";
		mens = G.AddComponent<mensagemBasica>();
		mens.posX = 0.01f;
		mens.posY = 0.68f;
		mens.mensagem  = conversa[0];
		mens.skin = skin;

		mB.podeAndar = false;
		mIT2.enabled = false;


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