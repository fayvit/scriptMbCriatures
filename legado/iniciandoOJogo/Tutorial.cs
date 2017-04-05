
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public bool entrando = true;
	public RectTransform[] painel;
	public Transform pontoParaEnsinarACamera;
	public Transform CoreanTransform;
	public Transform tCaesar;
	public entradinhaDoJogoPlus ePlus;
	public heroi H;

	private bool iniciou = false;
	private bool entendeu = false;
	private bool ensinouMaca = false;
	private bool invocando = false;
	private bool tempoLimitado = true;
	private bool jaFocou;
	private int mensagemAtual = 0;
	private int qual = 0;
	private float contadorDeTempo = 0;
	private float tempoDestaAcao = 0;
	private estouEnsinando ensinando = estouEnsinando.movimentoCorrerEPulo;
	private mensagemBasica mens;
	private mensagemEmLuta mL;
	private string[] mensDeTuto;
	private movimentoBasico mB;
	private cameraPrincipal cam;
	private IA_paraTutu IA2;


	// Use this for initialization

	private enum estouEnsinando
	{
		movimentoCorrerEPulo,
		camera,
		usarCriature,
		atacar,
		usarMaca,
		mudaItem,
		usarGatilhoDoItem,
		outroGolpe,
		usaEnergiaDeGarras,
		capturar,
		usarCartaLuva,
		queroEnsinarTrocarDeCriature,
		trocarCriature,
		botaoTrocarCriature,
		estadoNulo
	}

	public void EnsineAUsarMaca()
	{
		ensinando = estouEnsinando.usarMaca;
	}

	public void ensinaUsarCriature()
	{
		qual = 2;
		renovandoMensagem();
		ensinando = estouEnsinando.usarCriature;
		painel[0].anchoredPosition = new Vector2(painel[0].anchoredPosition.x,-300);
	}

	//void Iniciou(){
	public void Iniciou () {
		iniciou = true;
		contadorDeTempo = 0;
	}

	public void iniciandoAposTrocarCriature()
	{
		issoAiDaqui();
	}

	void issoAiDaqui()
	{
		entrando = false;
		tempoDestaAcao = 0;
		painel[0].anchoredPosition = new Vector2(painel[0].anchoredPosition.x,-300);
		GameObject.Find("encontreEle").GetComponent<encontroDeTuto>().enabled = false;
	}

	public void iniciandoAposEncontro()
	{

		ensinando = estouEnsinando.queroEnsinarTrocarDeCriature;
		issoAiDaqui();
		if(!mens)
		{
			mens = gameObject.AddComponent<mensagemBasica>();
		}
	}

	void Start()
	{
		mensDeTuto = bancoDeTextos.falacoes[heroi.lingua]["tuto"].ToArray();
	}

	void desliza(RectTransform rt)
	{
		Vector2 posAlvo = Vector2.zero;
		if(entrando)
		{
			posAlvo = new Vector2(rt.anchoredPosition.x,0);
			rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition,posAlvo,5*Time.deltaTime);
		}else
		{
			posAlvo = new Vector2(rt.anchoredPosition.x,-300);
			rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition,posAlvo,5*Time.deltaTime);
		}

	}

	void desliza2(RectTransform rt,bool entrando,int dir = 1)
	{
		Vector2 posAlvo = Vector2.zero;
		if(entrando)
		{
			posAlvo = new Vector2(0,rt.anchoredPosition.y);
			rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition,posAlvo,5*Time.deltaTime);
		}else
		{
			posAlvo = new Vector2(-500*dir,rt.anchoredPosition.y);
			rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition,posAlvo,5*Time.deltaTime);
		}
		
	}

	void renovandoMensagem()
	{
		painel[qual-1].anchoredPosition = new Vector2(painel[qual-1].anchoredPosition.x,-300);
		contadorDeTempo = 0;
		entendeu = false;
		tempoDestaAcao = 0;
		entrando = true;
	}

	void trocaMensagem()
	{
		if(Input.GetButtonDown("acaoAlt") ||Input.GetButtonDown("acao") || Input.GetButtonDown("menu e auxiliar"))
		{
			if(!invocando){
				mens.entrando = false;
				Invoke("proximaMens",0.15f);
				invocando  =true;
			}
		}
	}

	Vector3 focoNoCaesar()
	{
		Vector3 posAlvo = tCaesar.position+4*tCaesar.forward+2*Vector3.up;
		transform.position = Vector3.Lerp(transform.position, posAlvo,5*Time.deltaTime);
		transform.rotation = Quaternion.Lerp(
			transform.rotation,
			Quaternion.LookRotation(tCaesar.position-transform.position),
			5*Time.deltaTime);

		return posAlvo;
	}

	void proximaMens()
	{
		mensagemAtual++;
		switch(mensagemAtual)
		{
		case 1:
			qual+= 2;
			entrando = true;
			ePlus.habilitaAlternador();
			ensinando = estouEnsinando.estadoNulo;
		break;
		case 3:
			ensinando = estouEnsinando.usarCartaLuva;
			mens.entrando = false;
			qual = 5;
			painel[5].GetComponentInChildren<Text>().text = mensDeTuto[4];
			painel[6].GetComponentInChildren<Text>().text = mensDeTuto[5];
			entrando = true;
			shopBasico.adicionaItem(nomeIDitem.maca,H);
			shopBasico.adicionaItem(nomeIDitem.cartaLuva,H);
		break;
		default:
			if(mensagemAtual< mensDeTuto.Length)
			{
				mens.mensagem = mensDeTuto[mensagemAtual];
				mens.entrando = true;
			}
		break;
		}
		
		invocando = false;
	}

	public void removeEsbranquicado()
	{
		painel[4].gameObject.SetActive(false);
		entrando = false;
	}

	public void UsarGatilhoDoItem()
	{
		ensinando  =estouEnsinando.usarGatilhoDoItem;
	}
	
	public void vejaQualMens(int ensinamento = (int)estouEnsinando.estadoNulo)
	{
		if(qual == 5)
		{
			entrando = false;
			//print((estouEnsinando)0);
			StartCoroutine(mens6(6,0.15f,(estouEnsinando)ensinamento));
			//Invoke("mens6",0.15f);
		}else if(qual == 10)
		{
			entrando = false;
			StartCoroutine(mens6(11,0.15f,(estouEnsinando)ensinamento));
		}
	}
	
	public void useAEnergiaDeGarras()
	{
		painel[7].anchoredPosition = new Vector2(-500,painel[7].anchoredPosition.y);
		jaFocou = false;
		painel[4].gameObject.SetActive(true);
		variaveisChave.shift["TrocaGolpes"] = false;
		ensinando = estouEnsinando.outroGolpe;
		cam.enabled = false;
		mB.enabled = false;
	}
	
	IEnumerator mens6(int qualMensagem,float tempo,estouEnsinando ensinamento)
	{
		yield return new WaitForSeconds(tempo);
		if(ensinando== ensinamento)
		{
			qual = qualMensagem;
			entrando = true;
		}
	}
	// Update is called once per frame
	void Update () {
		contadorDeTempo+=Time.deltaTime;
		if(iniciou)
		{
			desliza(painel[qual]);

			if((contadorDeTempo>25 || tempoDestaAcao>5)&&tempoLimitado)
			{
				entrando = false;
				//qual++;
			}
			switch(ensinando)
			{
			case estouEnsinando.movimentoCorrerEPulo:
				if(Mathf.Abs(Input.GetAxis("Horizontal"))>0 
				   || Mathf.Abs(Input.GetAxis("Vertical"))>0
				   ||Input.GetButtonDown("Correr"))
				{
					entendeu = true;
				}

				if(Vector3.Distance(CoreanTransform.position,pontoParaEnsinarACamera.position)<3)
				{
					qual = 1;
					ensinando = estouEnsinando.camera;
					renovandoMensagem();
				}
			break;
			case estouEnsinando.camera:
				if(Input.GetAxis("Mouse Y")!=0 || Input.GetAxis("Mouse X")!=0 || Input.GetButtonDown("centraCamera"))
				{
					entendeu = true;
				}
			break;
			case estouEnsinando.usarCriature:
				if(Input.GetButtonDown("paraCriature"))
				{
					painel[qual].anchoredPosition = new Vector2(painel[qual].anchoredPosition.x,-300);
					qual++;
					ensinando = estouEnsinando.atacar;
				}
			break;
			case estouEnsinando.atacar:
				if(Input.GetButtonDown("acao"))
				{
					entendeu = true;
				}

				if(Input.GetButtonDown("paraCriature"))
				{
					entrando = false;
				}
			break;
			case estouEnsinando.usarMaca:
				if(!ensinouMaca)
				{
					if(!IA2)
						IA2 = GameObject.Find("inimigo").GetComponent<IA_paraTutu>();
					IA2.enabled = false;
					tCaesar.position = CoreanTransform.position+CoreanTransform.right;
					tCaesar.rotation = CoreanTransform.rotation;
					painel[4].gameObject.SetActive(true);
					GameObject G =  GameObject.Find("CriatureAtivo");
					cam = G.GetComponent<cameraPrincipal>();
					mB = G.GetComponent<movimentoBasico>();
					cam.enabled = false;
					mB.enabled = false;
					vidaEmLuta[] vS =  GameObject.Find("Terrain").GetComponents<vidaEmLuta>();
					print("vida em luta: "+vS.Length);
					foreach(vidaEmLuta v in vS)
					{
						v.entrando = false;
					}
					ensinouMaca = true;

				}
				//Vector3 posAlvo = focoNoCaesar();

				if(Vector3.Distance(focoNoCaesar(),transform.position)<0.3f)
				{
					transform.rotation = Quaternion.LookRotation(tCaesar.position-transform.position);
					ensinando = estouEnsinando.mudaItem;
					mens = gameObject.AddComponent<mensagemBasica>();
					mens.posY = 0.67f;
					mens.skin = elementosDoJogo.el.skin;
					mens.destaque = elementosDoJogo.el.destaque;
					mens.mensagem = mensDeTuto[0];
					H.criaturesAtivos[0].cAtributos[0].Corrente--;
					tempoLimitado = false;
				}
			break;
			case estouEnsinando.mudaItem:
				trocaMensagem();				
			break;
			case estouEnsinando.usarGatilhoDoItem:
				if(Input.GetButtonDown("menu e auxiliar"))
					jaFocou = true;
				desliza2(painel[7],!jaFocou);

				if(!IA2)
					IA2 = GameObject.Find("inimigo").GetComponent<IA_paraTutu>();
				if(mB.enabled&&mB.podeAndar)
					IA2.enabled = true;
				/*
				if(!mB.enabled&&!mB.podeAndar&&!IA2.enabled)
				{
					//print("por aqui");
					useAEnergiaDeGarras();
					IA2.enabled = false;
				}
				*/


			break;
			case estouEnsinando.outroGolpe:
				desliza2(painel[8],true);
				if(Input.GetButtonDown("trocaGolpe"))
				{

					mB.criatureVerificaTrocaGolpe();
				}

				if(H.criaturesAtivos[0].golpeEscolhido==1)
				{
					jaFocou = true;
					if(Input.GetButtonDown("acao"))
					{
						mB.aplicaGolpe(H.criaturesAtivos[0]);
						ensinando = estouEnsinando.usaEnergiaDeGarras;
						jaFocou = false;
					}
				}else if(Input.GetButtonDown("acao"))
				{
					if(mL)
						mL.fechador();
					mL = gameObject.AddComponent<mensagemEmLuta>();
					mL.posY = 0.01f;
					mL.mensagem = mensDeTuto[3];
					mensagemAtual = 3;
				}



				desliza2(painel[9],jaFocou,-1);


			break;
			case estouEnsinando.usaEnergiaDeGarras:
				desliza2(painel[8],false);
				desliza2(painel[9],false,-1);

				if(mB){
				if(mB.enabled && mB.podeAndar)
				{
					ensinando = estouEnsinando.capturar;
					heroi.contraTreinador = false;
					mB.enabled = false;
					cam.enabled = false;
					GameObject Inimigo = GameObject.Find("inimigo");
					IA_paraTutu IA =  Inimigo.GetComponent<IA_paraTutu>();
					IA.enabled = false;
					IA.paraMovimento();
					Inimigo.GetComponent<umCriature>().X.cAtributos[0].Corrente = 1;
				}
				}else
					ensinando = estouEnsinando.estadoNulo;
			break;

			case estouEnsinando.capturar:
				if(Vector3.Distance(focoNoCaesar(),transform.position)<0.3f)
				{
					transform.rotation = Quaternion.LookRotation(tCaesar.position-transform.position);
					vidaEmLuta[] vS =  GameObject.Find("Terrain").GetComponents<vidaEmLuta>();
					foreach(vidaEmLuta v in vS)
					{
						v.entrando = false;
					}
					
					mens.entrando = true;
					mens.mensagem = mensDeTuto[2];
					mensagemAtual = 2;
				}

				trocaMensagem();
			break;
			case estouEnsinando.usarCartaLuva:

				if(!Input.GetButtonDown("gatilho"))
					mB.criatureScroll();
				else if(H.itemAoUso==4&&!Input.GetButton("Correr"))
				{
					GameObject.Find("CriatureAtivo").GetComponent<movimentoBasico>().criatureScroll();
					ensinando = estouEnsinando.queroEnsinarTrocarDeCriature;
					removeEsbranquicado();

				}else if(!Input.GetButton("Correr"))
				{
					if(mL)
						mL.fechador();
					mL = gameObject.AddComponent<mensagemEmLuta>();					
					mL.mensagem = mensDeTuto[1];
				}
				
				if(H.itemAoUso==4)
					vejaQualMens((int)estouEnsinando.usarCartaLuva);
			break;
			case estouEnsinando.queroEnsinarTrocarDeCriature:
				if(!heroi.emLuta)
				{
					mB = H.GetComponent<movimentoBasico>();
					mB.enabled = false;
					variaveisChave.shift["HUDItens"] = true;
					ensinando = estouEnsinando.trocarCriature;
					mens.entrando = true;
					mens.mensagem = mensDeTuto[6];
					mensagemAtual = 6;
				}
			break;
			case estouEnsinando.trocarCriature:
				if(encontros.botoesPrincipais())
				{
					mens.entrando = false;
					ensinando = estouEnsinando.botaoTrocarCriature;
					qual = 10;
					entrando = true;
					variaveisChave.shift["HUDCriatures"] = false;
					jaFocou = false;
				}
			break;
			case estouEnsinando.botaoTrocarCriature:
				mB.criatureScroll();

				if(!jaFocou)
				if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HUDCriatures>())
				{
					vejaQualMens((int)estouEnsinando.botaoTrocarCriature);
					jaFocou = true;
				}

				if(Input.GetButton("Correr")&&Input.GetButtonDown("gatilho"))
				{
					ensinando =  estouEnsinando.estadoNulo;
					entrando = false;
					variaveisChave.shift["HUDItens"] = false;
					variaveisChave.shift["alternaParaCriature"] = false;
					variaveisChave.shift["trocaGolpes"] = false;

					ePlus.maisDoCaesar();
				}
			break;
			}


			if(entendeu)
			{
				tempoDestaAcao+=Time.deltaTime;
			}

		}


	}


}
