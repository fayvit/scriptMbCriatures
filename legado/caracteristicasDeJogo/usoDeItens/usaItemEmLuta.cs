using UnityEngine;
using System.Collections;

public class usaItemEmLuta : acaoDeItem2{
	
	private float contador;
	private float maximo;


	private movimentoBasico mB;
	private GameObject C;

	private string[] mensagens;
	private animandoCaptura animaCap;
	private animaPergFuga animaPfuga;

	// Use this for initialization
	void Start () {
		elementos = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ();
		H = GetComponent<heroi>();

		if(H.itens.Count>H.itemAoUso)
		{
			nomeItem = H.itens[H.itemAoUso].ID;
		}else
		{
			nomeItem = nomeIDitem.generico;
		}
		C = GameObject.Find("CriatureAtivo");
		mensagens = bancoDeTextos.falacoes[heroi.lingua]["mensLuta"].ToArray();



		switch(nomeItem)
		{
		case nomeIDitem.maca:
		case nomeIDitem.burguer :
			itemDeRecuperacao();
		break;
		case nomeIDitem.pergaminhoDePerfeicao :
			itemPerfeicao();
		break;
		case nomeIDitem.antidoto:
		case nomeIDitem.amuletoDaCoragem:
		case nomeIDitem.tonico:
			usaItemAntiStatus();
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
			verificaUsoDeItemDePE();
		break;
		case nomeIDitem.pergaminhoDeFuga :
			if(heroi.emLuta && !heroi.contraTreinador)
			{
				animaBraco(true);
				acaoAtual = "animandoPergFuga";
			}else
				mensagemDuranteALuta(mensagens[0]);

		break;
		case nomeIDitem.cartaLuva:
			if(heroi.emLuta && !heroi.contraTreinador)
				acaoDeCaptura();
			else
			{
				mensagemDuranteALuta(mensagens[0]);
				acaoAtual = "finalisaSemUsar";
			}
		break;
		case nomeIDitem.generico :
			acaoAtual = "finalisaSemUsar";
		break;
		default:
			mensagemDuranteALuta(mensagens[0]);
			acaoAtual = "finalisaSemUsar";
		break;
		}
	
	}

	void aplicaPerfeicao()
	{
		animaUsaItem(0,"perfeicao");
		estadoPerfeito(H.criaturesAtivos[0],0);

		acaoAtual = "animandoCura";
		tempoDeMenu = 0;

	}

	void itemPerfeicao()
	{
		Criature C = H.criaturesAtivos[0];
		atributos[] aH = C.cAtributos;
		if((aH[0].Corrente<aH[0].Maximo
		    ||
		    aH[1].Corrente<aH[1].Maximo)
		   &&
		   aH[0].Corrente>0
		   )
		{
			animaBraco();
			tempoDeMenu = 0;
			acaoAtual = "animandoPergPerf";
		}else{
			mensagemDuranteALuta(
				string.Format(mensagens[2],
			              H.criaturesAtivos[0].Nome));
			acaoAtual = "finalisaSemUsar";
		}


	}

	void usaItemAntiStatus()
	{
		bool eleTemStatus = false;
		switch(nomeItem)
		{
		case nomeIDitem.antidoto:
			eleTemStatus = (bool) C.GetComponent<envenenado>();
		break;
		case nomeIDitem.amuletoDaCoragem:
			eleTemStatus = (bool) C.GetComponent<amedrontado>();
		break;
		case nomeIDitem.tonico:
			eleTemStatus = (bool) C.GetComponent<paralisado>();
		break;
		}

		if(eleTemStatus)
		{
			animaBraco();
			acaoAtual="usandoAntiStatus";
		}else
		{
			mensagemDuranteALuta(
				string.Format(mensagens[2],
				H.criaturesAtivos[0].Nome));
			acaoAtual = "finalisaSemUsar";
			print(gameObject);
		}
	}

	void acaoDeCaptura()
	{
		nomeItem = nomeIDitem.cartaLuva;
		retiraItem (nomeItem,1,H);
		animaBraco(true);

		/*
		mensagemEmLuta mL =  gameObject.AddComponent<mensagemEmLuta>();
		mL.mensagem = mensagens[1]+item.nomeEmLinguas(nomeItem);
		*/

		mensagemDuranteALuta(mensagens[1]+item.nomeEmLinguas(nomeItem));
		acaoAtual = "animandoCartaLuva";
	}

	void itemDeRecuperacao(int qual = 0)
	{
		contador = H.criaturesAtivos[0].cAtributos[qual].Corrente;
		maximo = H.criaturesAtivos[0].cAtributos[qual].Maximo;
		if(contador<maximo)
			useItem();
		else{
			/*
			if(!maeCamera.GetComponent<mensagemEmLuta>())
				mensL = maeCamera.AddComponent<mensagemEmLuta>();
			else
			{
				maeCamera.GetComponent<mensagemEmLuta>().fechador();
				mensL = maeCamera.AddComponent<mensagemEmLuta>();
			}
			mensL.mensagem = mensL.padraoItem( H.criaturesAtivos[0].Nome);
			*/
			mensagemDuranteALuta(
				string.Format(mensagens[2],
			              H.criaturesAtivos[0].Nome));
			acaoAtual = "finalisaSemUsar";
		}
	}
	
	void animaBraco(bool inimigo = false)
	{
		mB = C.GetComponent<movimentoBasico>();
		if(mB)
			mB.enabled = false;
		else if(!heroi.emLuta){
			movimentoBasico mB2 = GameObject.FindWithTag("Player").GetComponent<movimentoBasico>();
			mB2.pararOHeroi();
			mB2.enabled = false;
			GameObject.Find("Main Camera").GetComponent<menuInTravel2>().enabled = false;
		}
		
		focandoHeroi();
		olharEmLuta();
		paralisaInimigo();
		animaTroca a = gameObject.AddComponent<animaTroca>();
		a.troca = false;
		a.alvo = inimigo?"inimigo":"CriatureAtivo";
		
		tempoDeMenu = 0;
	}

	void useItem()
	{

		switch(nomeItem)
		{
		case nomeIDitem.maca :
		
			animaBraco();

			acaoAtual = "animandoEnviaMaça";
			//acaoAtual
			//usandoMaca(0);

		break;
		case nomeIDitem.burguer :
			
			animaBraco();
			
			acaoAtual = "animandoEnviaBurguer";
			//acaoAtual
			//usandoMaca(0);
			
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
			animaBraco();
			acaoAtual="usandoMaisPE";
		break;
		}
	}

	void verificaUsoDeItemDePE()
	{
		esseUsaIsso e = verifiqueEsseUsaIsso(nomeItem,0);

		if(e.eleUsa)
		{
			itemDeRecuperacao(1);
		}else
		{
			string[] textos = bancoDeTextos.falacoes[heroi.lingua]["itens"].ToArray();
			acaoAtual = "finalisaSemUsar";
			mensagemDuranteALuta( textos[3]+ e.oTipo +textos[4]);
		}
	}

	public static void mensagemDuranteALuta(string essaMensagem)
	{
		GameObject maeCamera = Camera.main.gameObject;
		mensagemEmLuta mensL;
		if(!maeCamera.GetComponent<mensagemEmLuta>())
			mensL = maeCamera.AddComponent<mensagemEmLuta>();
		else
		{
			maeCamera.GetComponent<mensagemEmLuta>().fechador();
			mensL = maeCamera.AddComponent<mensagemEmLuta>();
		}
		mensL.mensagem = essaMensagem;//mensL.padraoItem( H.criaturesAtivos[0].Nome);
	
	}

	void itemRecuperacao(uint tanto,int onde = 0)
	{
		if(onde == 1)
			animaUsaItem(0,"animaPE");
		else
			animaUsaItem(0);

		if(contador+tanto<maximo)
			H.criaturesAtivos[0].cAtributos[onde].Corrente+=tanto;
		else
			H.criaturesAtivos[0].cAtributos[onde].Corrente
				=  H.criaturesAtivos[0].cAtributos[onde].Maximo;
		acaoAtual = "animandoCura";
		tempoDeMenu = 0;
	}

	void itemCaptura()
	{
		GameObject T = GameObject.Find("inimigo");
		giraCameraCriature(T.transform);
		animaCap = T.AddComponent<animandoCaptura>();
		animaCap.G = T;

		acaoAtual = "tentandoCapturar";
	}


	void acaoPergFuga()
	{
		GameObject T = GameObject.Find("inimigo");
		giraCameraCriature(T.transform);
		animaPfuga = T.AddComponent<animaPergFuga>();
		animaPfuga.G = T;
		retiraItem(nomeItem,1,H);
		acaoAtual = "tentandoFugir";
	}

	void retornaPadraoLuta()
	{
		Animator animator = GetComponent<Animator>();
		animator.SetBool("chama",false);
		Destroy(GetComponent<centralizaEGiraCamera>());

		if(mB)
			mB.enabled = true;
		else if(!heroi.emLuta)
		{
			GameObject G = GameObject.FindWithTag("Player");
			G.GetComponent<movimentoBasico>().enabled = true;
			G.GetComponent<cameraPrincipal>().enabled = true;
			G.GetComponent<Animator>().CrossFade("padrao",0.5f);
			GameObject.Find("Main Camera").GetComponent<menuInTravel2>().enabled = true;
		}

		cameraPrincipal cam = C.GetComponent<cameraPrincipal>();
		if(cam)
			cam.enabled = true;
	}

	// Update is called once per frame

	tipoStatus statusRetiradoPorEsseItem()
	{
		tipoStatus tipo = tipoStatus.nulo;

		switch(nomeItem)
		{
		case nomeIDitem.antidoto:
			tipo = tipoStatus.envenenado;
		break;
		case nomeIDitem.amuletoDaCoragem:
			tipo = tipoStatus.amedrontado;
		break;
		case nomeIDitem.tonico:
			tipo = tipoStatus.paralisado;
		break;
		}

		return tipo;
	}


	void Update () {
		tempoDeMenu+=Time.deltaTime;
		switch(acaoAtual)
		{
		case "usandoAntiStatus":
			if(tempoDeMenu>2)
			{
				animaUsaItem(0,"animaPE");
				retiraStatusTemporario(0,statusRetiradoPorEsseItem(),H);
				acaoAtual = "animandoCura";
				tempoDeMenu = 0;
			}
		break;
		case "animandoEnviaMaça":
			if(tempoDeMenu>2){
				itemRecuperacao(10);
			}

		break;
	
		case "animandoEnviaBurguer":
			if(tempoDeMenu>2){
				itemRecuperacao(40);
			}
		break;

		case "animandoPergPerf":
			if(tempoDeMenu>2)
			{
				aplicaPerfeicao();
			}
		break;

		case "usandoMaisPE":
			if(tempoDeMenu>2)
			{
				itemRecuperacao(40,1);
			}
		break;
		case "animandoCartaLuva":
			if(tempoDeMenu>2){
				itemCaptura();
			}
		break;
		case "animandoCura":
			if(tempoDeMenu>2f)
			{
				if(GetComponent<vidaEmLuta>())
					GetComponent<vidaEmLuta>().fechaJanela();
				acaoAtual ="finalisaUsaItem";
			}
		break;

		case "animandoPergFuga":
			if(tempoDeMenu>2)
			{
				acaoPergFuga();
			}
		break;

		case "tentandoCapturar":
			acaoAtual = animaCap.estado;
		break;

		case "tentandoFugir":
			acaoAtual = animaPfuga.estado;
		break;

		case "finalisaComCaptura":
		case "finalisaSemUsar":
			Destroy(this);
		break;

		case "finalisaUsaItem":
			if(IA!= null)
			{
				IA.retornaOMovimento();
				IA.podeAtualizar = true;
			}
			retornaPadraoLuta();

			if(heroi.emLuta)
				H.tempoDoUltimoUsoDeItem = Time.time;

			if( nomeItem == nomeIDitem.cartaLuva)
				H.intervaloParaUsarItem = 30;
			else
				H.intervaloParaUsarItem = 20;
			Destroy(this);
		break;

		}
	}


}
