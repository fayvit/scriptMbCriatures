using UnityEngine;
using System.Collections;

public class morteEmLuta : alternancia {
	//public GameObject Inimigo;
	public Criature oMOrto;
//	public GameObject criature;
	public heroi H;
	public int passoDaMorte = 0;

	private mensagemEmLuta mensL;

	private GameObject aCamera;
	private GameObject Terra;
	private mensagemBasica mensB;
	private Menu quemEntra;
	private int janelaDetroca;
	private vidaEmLuta[] vidas;
	private string[] falacoes;
	private GUISkin skin;

	// Use this for initialization
	void Start () {
		//Inimigo = GameObject.Find("CriatureAtivo");
		//IA = Inimigo.GetComponent<IA_inimigo>();

		H = GameObject.FindWithTag("Player").GetComponent<heroi>();
		aCamera = GameObject.Find("Main Camera");
		Terra = GameObject.Find("Terrain");
		skin = elementosDoJogo.el.skin;
		if(IA)
		{
			IA.podeAtualizar = false;
			IA.paraMovimento();
		}

		//troquei a variavel Criature por gameObject

		movimentoBasico mB =  gameObject.GetComponent<movimentoBasico>();
		if(mB)
			mB.podeAndar = false;
		falacoes = bancoDeTextos.falacoes[heroi.lingua]["encontros"].ToArray();
		Invoke("mensagemDeMorto",1);

	}

	public IA_inimigo Ia
	{
		set{IA = value;}
		get{return IA;}
	}

	void perguntaQuemEntra()
	{
		mensL.fechaJanela();
		passoDaMorte = 2;
		
		vidas = Terra.GetComponents<vidaEmLuta>();
		foreach(vidaEmLuta vida in vidas)
			vida.entrando = false;
		
		mensB = Terra.AddComponent<mensagemBasica> ();
		mensB.mensagem =falacoes[0];
		mensB.skin = skin;
		mensB.destaque = aCamera.GetComponent<menuInTravel2>().destaque;
		mensB.title = "";
		mensB.posY = 0.68f;
		
		quemEntra = Terra.AddComponent<Menu>();
		quemEntra.aMenu = 0.1f*H.criaturesAtivos.Count;
		string[] opcoes = H.nomesCriaturesHeroi();
		quemEntra = quemEntra.detalhesBase(quemEntra,"QuemEntra",opcoes,mensB.skin , mensB.destaque);
		janelaDetroca = 0;

		mostraOSelecionado(aCamera,H.criaturesAtivos[(int)quemEntra.escolha],(int)quemEntra.escolha);

	}
	
	void mensagemDeMorto()
	{
		focandoHeroi();
		mensL = aCamera.AddComponent<mensagemEmLuta>();
		mensL.mensagem = oMOrto.Nome+ falacoes[1];
		mensL.tempoDeFuga = 0;
		passoDaMorte = 1;
	}

	void finalizaComDerrota()
	{
		mensL.fechaJanela();
		vidas = Terra.GetComponents<vidaEmLuta>();
		foreach(vidaEmLuta vida in vidas)
			vida.fechaJanela();

		mensB = Terra.AddComponent<mensagemBasica>();
		mensB.posY = 0.68f;
		mensB.mensagem = falacoes[3];
		mensB.skin = skin;

	
		passoDaMorte = 5;
	}

	void fechaTuto()
	{
		if(mensB != null)
			mensB.fechaJanela();

		if(quemEntra != null)
			quemEntra.fechaJanela();

		deslizaOuFecha(aCamera,(int)quemEntra.escolha);
	}

	void mostraVidasEmLuta()
	{
		foreach(vidaEmLuta vida in vidas)
			vida.entrando = true;
	}

	void coloqueEleEmCampo()
	{
		passoDaMorte = 4;
		fechaTuto();
		mostraVidasEmLuta();
		H.criatureSai = (int)quemEntra.escolha;
		GameObject.FindGameObjectWithTag("Player").AddComponent<alternanciaEmLuta>();

	}

	void perguntaVivo()
	{
		passoDaMorte = 3;
		if(H.criaturesAtivos[(int)quemEntra.escolha].cAtributos[0].Corrente>0)
			coloqueEleEmCampo();
		else
		{
			quemEntra.entrando = false;
			quemEntra.podeMudar = false;
			mensB.entrando = false;
			mensL = aCamera.AddComponent<mensagemEmLuta>();
			mensL.mensagem = H.criaturesAtivos[(int)quemEntra.escolha].Nome+
				falacoes[2];
		}
	}

	void voltaOMenuEMensagem()
	{
		mensL.fechaJanela();
		mensB.entrando = true;
		quemEntra.entrando = true;
		quemEntra.podeMudar = true;
		passoDaMorte = 2;
	}
	
	// Update is called once per frame
	void Update () {
		bool acao = Input.GetButtonDown("acao");
		switch(passoDaMorte)
		{
		case 1:

			if(mensL != null)
			{



				if(
					Input.GetButtonDown("acao") 
				   || Input.GetButtonDown("acaoAlt") 
				   || Input.GetButtonDown("menu e auxiliar")
				   || Input.GetButtonDown("gatilho")
				   )
				{
					if(H.alguemTaVivo())
						perguntaQuemEntra();
					else
						finalizaComDerrota();
				}
			}
		break;
		case 2:
			if(janelaDetroca != quemEntra.escolha)
			{
				deslizaOuFecha(aCamera,(int)quemEntra.escolha);
				mostraOSelecionado(aCamera,H.criaturesAtivos[(int)quemEntra.escolha],(int)quemEntra.escolha);
				janelaDetroca = (int)quemEntra.escolha;
			}

			if(Input.GetButtonDown("acaoAlt")&& quemEntra.dentroOuFora()>-1)
				acao = true;
			

			if(acao||Input.GetButtonDown("gatilho"))
				perguntaVivo();

			
		break;
		case 3:
			if(Input.GetButtonDown("acaoAlt") 
			   ||
				Input.GetButtonDown("acao") 
				|| Input.GetButtonDown("menu e auxiliar")
				|| Input.GetButtonDown("gatilho")
				)
			{
				if(mensL!= null)
				{
					voltaOMenuEMensagem();
				}
			}

			if(mensL == null)
			{
				voltaOMenuEMensagem ();
			}
		break;
		case 4:
			Destroy(this,1);
		break;
		case 5:
			if(Input.GetButtonDown("acaoAlt") 
			    || Input.GetButtonDown("acao") 
				|| Input.GetButtonDown("menu e auxiliar")
				||Input.GetButtonDown("gatilho")
				)
			{
				mensB.fechaJanela();
				passoDaMorte = 6;
			}
		break;
		case 6:
				gameObject.AddComponent<pretoMorte>();
				passoDaMorte = -1;
				Invoke("acendaAsLuzes",2.5f);
		break;
		case 7:
			variaveisChave.executaChavesDeViagemNaMorte(H);
			heroi.emLuta = false;
			H.devoltaParaOArmagedom();
			Destroy(this);
		break;
		
		}

		acao = false;
	}

	void acendaAsLuzes()
	{
		GetComponent<pretoMorte>().entrando = false;
		encontros e = Terra.GetComponent<encontros>();
		if(e)
			e.voltarParaPasseio();
		//Invoke("depoisDeAcender",0.5f);
		passoDaMorte = 7;
	}
}
