using UnityEngine;
using System.Collections;

public class entradinhaDoJogoPlus : MonoBehaviour {

	private bool invocando = false;
	private bool finalisou = false;
	private int mensagemAtual;
	private string[] essaConversa;
	private heroi H;
	private float contadorDeTempo = 0;

	private faseDaEntrada fase;

	private Animator animatorDoCaesar;
	private Animator animatorDoLutz;
	private Animator animatorDoHooligan;
	private Animator animatorDoCorean;

	private pretoMorte p; 
	private cameraPrincipal cam;
	private movimentoBasico mB;
	private mensagemBasica mens;
	private animaEnvia aE;
	private Tutorial tuto;
	private mensagemEmLuta mL;


	public GUISkin skin;
	public Transform CaesarTransform;
	public Transform CoreanTransform;
	public Transform LutzTransform;
	public Transform HooliganTransform;
	public Transform GlarkTransform;
	public Transform NesseiTransform;
	public Transform[] posicoesDeCamera;

	public UnityEngine.AI.NavMeshAgent CaesarNavMesh;
	public UnityEngine.AI.NavMeshAgent LutzNavMesh;
	public UnityEngine.AI.NavMeshAgent HooliganNavMesh;
	public Transform[] posicoesNavMesh;

	public Collider colDaPonte;
	public Transform pedrasFInais;

	

	// Use this for initialization

	enum faseDaEntrada
	{
		jogoDeCameraInicial,
		focoNoCaesar,
		focoNoCorean,
		fala1Corean,
		fala2Caesar,
		assumindoOControle,
		iniciaConversa2,
		conversa2,
		vaoEmboraExcedentes,
		enviaCriature,
		esperaAlternar,
		comOCriature,
		ateOEncontro,
		habilitaAlternador,
		useiMaca,
		ultimoSigaCaesar,
		mensDoUltimoSigaCaesar,
		caesarAndandoFinal,
		encontroComGlark,
		giraProGlark,
		cameraParaGlar,
		voltaCameraProCorean,
		rajadaDeAgua,
		empurrandoParaQueda,
		QuedaFinal,
		estadoNulo

	}

	void Start () {
		string[] verdadeiros = new string[5]{"adiciona O Criature",
			"HUDItens",
			"HUDCriatures",
			"alternaParaCriature",
			"TrocaGolpes"};
		
		foreach(string i in verdadeiros)
		{
			variaveisChave.shift[i]=true;
		}

		transform.parent =posicoesDeCamera[0];
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		animatorDoCaesar = CaesarTransform.GetComponent<Animator>();
		animatorDoLutz = LutzTransform.GetComponent<Animator>();
		animatorDoCorean = CoreanTransform.GetComponent<Animator>();
		animatorDoHooligan = HooliganTransform.GetComponent<Animator>();

		fase = faseDaEntrada.jogoDeCameraInicial;
		//fase = faseDaEntrada.assumindoOControle;


		essaConversa = bancoDeTextos.falacoes[heroi.lingua]["entradinhaPlus"].ToArray();

		mens = gameObject.AddComponent<mensagemBasica>();
		mens.entrando = false;
		mens.mensagem = essaConversa[0] ;
		mensagemAtual = 0;
		mens.skin = skin;
		mens.posY  = 0.68f;
		mens.title = "";

		//assumaOControle();
		//faseDoEnviaCriature();
		//iniciandoAposEncontro();
		//iniciandoAposTrocarCriature();
	}

	void iniciandoAposTrocarCriature()
	{

		issoAi();
		tuto.iniciandoAposTrocarCriature();
	}

	void issoAi()
	{
		fase = faseDaEntrada.estadoNulo;
		Destroy(HooliganTransform.gameObject);
		Destroy(LutzTransform.gameObject);
		H = CoreanTransform.gameObject. AddComponent<heroi>();
		tuto.H = H;
		H.limpaTodasAsVariaveis();
		H.criaturesAtivos.Add(new cCriature(nomesCriatures.FelixCat,20).criature());
		H.criaturesAtivos.Add(new cCriature(nomesCriatures.Vampire,20).criature());
		CaesarNavMesh.Stop();
		//GameObject.Find("encontreEle").SetActive(false);
		
		Invoke("adicionaEle",0.25f);
		CaesarTransform.position = new melhoraPos().novaPos( CoreanTransform.position+Vector3.right,1);
	}

	void iniciandoAposEncontro()
	{
		issoAi();
		tuto.iniciandoAposEncontro();

	}

	void adicionaEle()
	{
		mB.adicionaOCriature();
	}

	public void encontroComGlark()
	{

		pretoMorte p = gameObject.AddComponent<pretoMorte>();
		mB.enabled = false;
		cam.enabled = false;
		StartCoroutine(voltaDoPretoMorte(p));
	}

	IEnumerator voltaDoPretoMorte(pretoMorte p)
	{
		yield return new WaitForSeconds(2);
		transform.position = posicoesDeCamera[7].position;
		transform.rotation = posicoesDeCamera[7].rotation;
		CoreanTransform.position = new melhoraPos().novaPos(posicoesDeCamera[8].position);
		CoreanTransform.rotation = Quaternion.LookRotation(Vector3.left);
		CaesarNavMesh.enabled = false;
		CaesarTransform.position = new melhoraPos().novaPos(posicoesDeCamera[8].position-Vector3.right);
		CaesarTransform.rotation = Quaternion.LookRotation(Vector3.left);
		fase = faseDaEntrada.giraProGlark;
		animatorDoCorean.SetFloat("velocidade",0.5f);
		animatorDoCaesar.SetFloat("velocidade",0.5f);
		CaesarNavMesh.enabled = true;
		yield return new WaitForSeconds(0.5f);
		p.entrando = false;

		yield return new WaitForSeconds(1);

		animatorDoCorean.SetFloat("velocidade",0f);
		animatorDoCaesar.SetFloat("velocidade",0f);

		fase = faseDaEntrada.encontroComGlark;

		if(!mens)
			gameObject.AddComponent<mensagemBasica>();
		mens.entrando = true;
		mens.mensagem = essaConversa[23];
		mensagemAtual = 23;
		mens.title = "\t \t Cesar Corean";
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

	void finalisaConversa()
	{
		if(!finalisou){
		p = gameObject.AddComponent<pretoMorte>();
		mens.fechaJanela();
		//Destroy(this);
		Invoke("clareiaIsso",2);
			finalisou = true;
		}
	}

	void ligaAquilo()
	{
		escolhaInicial I =  GetComponent<escolhaInicial>();
		I.enabled = true;
		Destroy(this);
	}

	void clareiaIsso()
	{
		Transform T = Camera.main.transform;
		T.parent = GameObject.Find("camera2").transform;
		T.localPosition = Vector3.zero;
		T.localRotation = Quaternion.identity;
		p.entrando = false;
		Invoke("ligaAquilo",0.75f);
	}

	void faseDoEnviaCriature()
	{
		mensagemAtual=21;
		mens.mensagem = essaConversa[21];
		fase = faseDaEntrada.enviaCriature;
		H = CoreanTransform.gameObject. AddComponent<heroi>();
		tuto.H = H;
		H.limpaTodasAsVariaveis();
		H.criaturesAtivos.Add(new cCriature(nomesCriatures.FelixCat,20).criature());
		aE = gameObject.AddComponent<animaEnvia>();
		aE.posCriature = CoreanTransform.position-transform.forward*3;
		CoreanTransform.rotation = Quaternion.LookRotation(Vector3.right);
		aE.oInstanciado = nomesCriatures.FelixCat;
		animatorDoCorean.SetBool("chama",true);
	}

	void proximaMens()
	{
		if(
			mensagemAtual+1!=16 
			&& 
			mensagemAtual+1!=21 
			&& 
			mensagemAtual+1!=23
			&&
			mensagemAtual+1!=32
			&&
			mensagemAtual+1< essaConversa.Length)
		{
			mensagemAtual++;
			mens.mensagem = essaConversa[mensagemAtual];
			mens.entrando = true;
		}else if(mensagemAtual+1==16){
			assumaOControle();
			mensagemAtual++;
		}
		else if(mensagemAtual+1==21)
		{
			mensagemAtual++;
			faseDoEnviaCriature();
		}else if(mensagemAtual+1==23)
		{
			mensagemAtual++;
			CaesarNavMesh.destination = posicoesNavMesh[5].position;
			fase = faseDaEntrada.caesarAndandoFinal;
		}else if(mensagemAtual+1==32)
		{
			mens.entrando = false;
			mensagemAtual++;
			NesseiTransform.LookAt(CaesarTransform);
			Criature X = NesseiTransform.GetComponent<umCriature>().X;
			X.golpeEscolhido = 1;
			NesseiTransform.gameObject.AddComponent<comandos>().aplicaGolpe(X);
			fase = faseDaEntrada.rajadaDeAgua;
			contadorDeTempo = 0;
		}
		else{

			mensagemAtual++;
			mens.entrando = false;
		}
		//	finalisaConversa();



		switch(mensagemAtual)
		{
		case 2:
		case 3:
		case 23:
		case 29:
			mens.title = "\t\t\t Cesar Corean";
		break;
		case 25:
			mens.title = "\t\t\t Cesar Corean";
			gameObject.AddComponent<animaTroca>();
		break;
		case 26:
			mens.title = "\t\t\t\t\t\t Caesar Palace";
			animatorDoCorean.SetBool("chama",false);
			CoreanTransform.rotation = Quaternion.LookRotation(Vector3.back);
		break;
		case 27:
		case 31:
			fase = faseDaEntrada.cameraParaGlar;
			mens.title = "\t\t\t\t Glark";
		break;
		case 28:
			fase = faseDaEntrada.voltaCameraProCorean;
			mens.title = "\t\t\t\t\t\t Caesar Palace";
		break;
		default:
			if(mensagemAtual>3)
				mens.title = "\t\t\t\t\t\t Caesar Palace";
		break;
		}

		invocando = false;
	}

	void olhaPraMimPo(Transform olhe,Animator doOlhador,float onde = 1)
	{
		if(Vector3.Dot(olhe.forward,CoreanTransform.forward)>-0.95f)
		{
			doOlhador.SetBool("girando",true);
			doOlhador.SetFloat("direcao",onde);

			Vector3 olharAlvo = new Vector3(
				CoreanTransform.position.x-olhe.position.x,
				0,
				CoreanTransform.position.z-olhe.position.z);

			olhe.rotation = Quaternion.Lerp(
				olhe.rotation,
				Quaternion.LookRotation(olharAlvo),
				Time.deltaTime
				);

		}else
		{
			doOlhador.SetBool("girando",false);
			doOlhador.SetFloat("direcao",0);
		}
	}

	void mudaParent(Transform novoPai)
	{
		transform.parent = novoPai;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
	
	
	
	void andeAteOsPontos()
	{
		animatorDoCaesar.SetFloat("velocidade",CaesarNavMesh.velocity.magnitude);
		animatorDoHooligan.SetFloat("velocidade",HooliganNavMesh.velocity.magnitude);
		animatorDoLutz.SetFloat("velocidade",LutzNavMesh.velocity.magnitude);
		
		
		for(int i = 0;i<3;i++)
		{
			if(Vector3.Distance(CaesarTransform.position,posicoesNavMesh[i].position)<3
			   &&
			   Vector3.Distance(LutzTransform.position,posicoesNavMesh[i].position)<3
			   &&
			   Vector3.Distance(HooliganTransform.position,posicoesNavMesh[i].position)<3)
			{
				destinacao(i+1);
			}
		}
	}
	
	public void IniciaConversa2()
	{
		fase = faseDaEntrada.iniciaConversa2;
		mB.enabled = false;
		cam.enabled = false;
		mB.pararOHeroi();
		CoreanTransform.position = posicoesDeCamera[4].position;
		mudaParent(posicoesDeCamera[5]);
		tuto.entrando = false;
		variaveisChave.shift["alternaParaCriature"] = false;

	}
	
	void destinacao(int i)
	{
		if(i<3)
		{
			CaesarNavMesh.destination = posicoesNavMesh[i].position;
			HooliganNavMesh.destination = posicoesNavMesh[i].position;
			LutzNavMesh.destination = posicoesNavMesh[i].position;
		}else
			fase = faseDaEntrada.estadoNulo;
	}
	
	void assumaOControle()
	{
		animatorDoCaesar.SetFloat("direcao",0);
		animatorDoLutz.SetFloat("direcao",0);
		HooliganNavMesh.enabled = true;
		animatorDoHooligan.Play("padrao",0);
		destinacao(0);
		fase =  faseDaEntrada.assumindoOControle;
		//mens.entrando = false;
		transform.parent = null;
		animatorDoCorean.speed = 1;
		cam = CoreanTransform.gameObject.AddComponent<cameraPrincipal>();
		mB = CoreanTransform.gameObject.AddComponent<movimentoBasico>();
		tuto = GetComponent<Tutorial>();
		tuto.Iniciou();
		tuto.ePlus = this;
		//Tutorial tuto = gameObject.AddComponent<Tutorial>();
		
	}

	public void faseAteOEncontro()
	{
		if(fase == faseDaEntrada.comOCriature)
			fase = faseDaEntrada.ateOEncontro;
		
		mens.entrando = true;
		CaesarNavMesh.destination = posicoesNavMesh[4].position;
		variaveisChave.shift["alternaParaCriature"] = true;
	}

	void Update () {
		Vector3 posAlvo = Vector3.zero;
		switch(fase)
		{
		case faseDaEntrada.jogoDeCameraInicial:
			posAlvo = CaesarTransform.position+2.5f*Vector3.up-2*transform.right-6*transform.forward;
			transform.position = Vector3.Lerp(transform.position,posAlvo,Time.deltaTime);
			if(Vector3.Distance(posAlvo,transform.position)<0.5f)
			{
				fase = faseDaEntrada.focoNoCaesar;
				mens.entrando = true;
			}
		break;
		case faseDaEntrada.focoNoCaesar:
			transform.rotation = Quaternion.Lerp(
				transform.rotation,
				Quaternion.LookRotation(CaesarTransform.position-transform.position+Vector3.up),
				Time.deltaTime);

			olhaPraMimPo(CaesarTransform,animatorDoCaesar,-1);
			olhaPraMimPo(LutzTransform,animatorDoLutz);
			trocaMensagem();

			if(mensagemAtual==2)
			{
				fase = faseDaEntrada.focoNoCorean;
				mens.entrando = false;
				animatorDoCorean.SetFloat("velocidade",0.5f);
				animatorDoCorean.speed = 0.5f;
				CoreanTransform.position = posicoesDeCamera[2].position;/*new melhoraPos().novaPos(
					transform.position+Vector3.forward*9,1);*/
				posAlvo = new Vector3(transform.position.x-CoreanTransform.position.x,0,transform.position.z-CoreanTransform.position.z);
				CoreanTransform.rotation = Quaternion.LookRotation(posAlvo);
				transform.position-=1.5f*Vector3.up;
				animatorDoLutz.SetBool("girando",false);
				posAlvo = new Vector3(
					CoreanTransform.position.x-LutzTransform.position.x,
					0,
					CoreanTransform.position.z-LutzTransform.position.z);
				LutzTransform.rotation = Quaternion.LookRotation(posAlvo);
				animatorDoCaesar.SetBool("girando",false);
				posAlvo = new Vector3(
					CoreanTransform.position.x-CaesarTransform.position.x,
					0,
					CoreanTransform.position.z-CaesarTransform.position.z);
				CaesarTransform.rotation = Quaternion.LookRotation(posAlvo);
			}
		break;
		case faseDaEntrada.focoNoCorean:
			transform.LookAt(CoreanTransform);
			if(Vector3.Distance(transform.position,CoreanTransform.position)<5f)
			{
				animatorDoCorean.SetFloat("velocidade",0);
				mens.entrando = true;
				fase = faseDaEntrada.fala1Corean;
			}
		break;
		case faseDaEntrada.fala1Corean:
			trocaMensagem();
			if(mensagemAtual==4)
			{
				fase = faseDaEntrada.fala2Caesar;
				//mens.entrando = false;
				transform.position = CaesarTransform.position+CaesarTransform.forward*2+2f*Vector3.up;
				transform.LookAt(CaesarTransform.position+2*Vector3.up);
			}
		break;
		case faseDaEntrada.fala2Caesar:
			trocaMensagem();
			switch(mensagemAtual)
			{
			case 6:
			case 7:
				posAlvo = LutzTransform.position+LutzTransform.forward*2+1.5f*Vector3.up;
				transform.position = Vector3.Lerp(transform.position,posAlvo,Time.deltaTime);
			break;
			case 8:
				posAlvo = HooliganTransform.position
					+HooliganTransform.forward*2
						+1.2f*Vector3.up
						-HooliganTransform.right*2;
				transform.position = Vector3.Lerp(transform.position,posAlvo,Time.deltaTime);
				transform.LookAt(HooliganTransform.position+1.2f*Vector3.up);
			break;
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				CoreanTransform.position = posicoesDeCamera[3].position;
				posAlvo = posicoesDeCamera[1].position;
				transform.position = Vector3.Lerp(transform.position,posAlvo,2*Time.deltaTime);
				transform.rotation = Quaternion.Lerp(transform.rotation,posicoesDeCamera[1].rotation,Time.deltaTime);

			break;
			}
		break;
		case faseDaEntrada.assumindoOControle:
			andeAteOsPontos();
		break;
		case faseDaEntrada.iniciaConversa2:
			andeAteOsPontos();

			if(Vector3.Distance(CaesarTransform.position,posicoesNavMesh[2].position)<3
		   &&
		   Vector3.Distance(LutzTransform.position,posicoesNavMesh[2].position)<3
		   &&
		   Vector3.Distance(HooliganTransform.position,posicoesNavMesh[2].position)<3)
		{
				CaesarNavMesh.Stop();
				HooliganNavMesh.Stop();
				LutzNavMesh.Stop();

				Vector3 olharSegundo = new Vector3(CaesarTransform.position.x-CoreanTransform.position.x,
				                                   0,
				                                   CaesarTransform.position.z-CoreanTransform.position.z);
				CoreanTransform.rotation = Quaternion.LookRotation(olharSegundo);
				CaesarTransform.rotation = Quaternion.LookRotation(-olharSegundo);
				mensagemAtual = 16;
				mens.mensagem = essaConversa[mensagemAtual];
				fase = faseDaEntrada.conversa2;
		}
		break;
		case faseDaEntrada.conversa2:
			animatorDoCaesar.SetFloat("velocidade",0);
			animatorDoHooligan.SetFloat("velocidade",0);
			animatorDoLutz.SetFloat("velocidade",0);

			mens.entrando = true;
			trocaMensagem();
			if(mensagemAtual == 18)
			{
				fase = faseDaEntrada.vaoEmboraExcedentes;
				LutzNavMesh.destination = posicoesNavMesh[3].position;
				HooliganNavMesh.destination = posicoesNavMesh[3].position;
				mudaParent(posicoesDeCamera[6]);
				HooliganTransform.gameObject. AddComponent<destruaQUandoProximo>().local = posicoesNavMesh[3].position;
				LutzTransform.gameObject. AddComponent<destruaQUandoProximo>().local = posicoesNavMesh[3].position;
			}
		break;
		case faseDaEntrada.vaoEmboraExcedentes:
			if(HooliganTransform)
				animatorDoHooligan.SetFloat("velocidade",HooliganNavMesh.velocity.magnitude);
			if(LutzTransform)
				animatorDoLutz.SetFloat("velocidade",LutzNavMesh.velocity.magnitude);

			if(mensagemAtual+1==21)
			{
				mudaParent(posicoesDeCamera[5]);
			}
			trocaMensagem();
		break;
		case faseDaEntrada.enviaCriature:
			if(!aE)
			{
				animatorDoCorean.SetBool("chama",false);
				//mB.enabled = true;
				transform.parent = null;
				//cam.enabled = true;
				if(!tuto)
					tuto = GetComponent<Tutorial>();
				tuto.ensinaUsarCriature();
				tuto.ePlus = this;
				fase = faseDaEntrada.esperaAlternar;
			}
		break;
		case faseDaEntrada.esperaAlternar:
			if(Input.GetButtonDown("paraCriature"))
			{
				fase = faseDaEntrada.comOCriature;
				alternancia a = GameObject.Find("CriatureAtivo").GetComponent<alternancia>();
				a.aoCriature();
				if(LutzTransform)
					Destroy(LutzTransform.gameObject);

				if(HooliganTransform)
					Destroy(HooliganTransform.gameObject);
			}
		break;
		case faseDaEntrada.comOCriature:
			if(Input.GetButtonDown("paraCriature"))
			{
				faseAteOEncontro();
			}

		break;
		case faseDaEntrada.ateOEncontro:
			if(mensagemAtual==21)
			{
				//mens.entrando = true;
				trocaMensagem();
			}else
				mens.entrando = false;

			animatorDoCaesar.SetFloat("velocidade",CaesarNavMesh.velocity.magnitude);
		break;
		case faseDaEntrada.habilitaAlternador:

				if(!Input.GetButtonDown("gatilho"))
					mB.criatureScroll();
				else if(H.itemAoUso==3 && !Input.GetButton("Correr"))
				{
					GameObject.Find("CriatureAtivo").GetComponent<movimentoBasico>().criatureScroll();
					vidaEmLuta[] vS =  GameObject.Find("Terrain").GetComponents<vidaEmLuta>();
					foreach(vidaEmLuta v in vS)
					{
						v.entrando = true;
					}
					tuto.removeEsbranquicado();
					tuto.UsarGatilhoDoItem();
					fase = faseDaEntrada.useiMaca;
					heroi.contraTreinador = true;
				}else if(!Input.GetButton("Correr"))
				{
					if(mL)
						mL.fechador();
					mL = gameObject.AddComponent<mensagemEmLuta>();					
					mL.mensagem = bancoDeTextos.falacoes[heroi.lingua]["tuto"][1];
				}

			if(H.itemAoUso==3)
				tuto.vejaQualMens();

		break;
		case faseDaEntrada.ultimoSigaCaesar:
			contadorDeTempo+=Time.deltaTime;

			if(contadorDeTempo>3)
			{
				if(!mens)
					mens = gameObject.AddComponent<mensagemBasica>();
				mens.entrando = true;
				mensagemAtual = 22;
				mens.mensagem = essaConversa[22];
				fase = faseDaEntrada.mensDoUltimoSigaCaesar;
				//CaesarTransform.position = new melhoraPos().novaPos( CoreanTransform.position+Vector3.right,1);
			}
		break;
		case faseDaEntrada.mensDoUltimoSigaCaesar:
			trocaMensagem();
			animatorDoCaesar.SetFloat("velocidade",CaesarNavMesh.velocity.magnitude);
		break;
		case faseDaEntrada.caesarAndandoFinal:
			animatorDoCaesar.SetFloat("velocidade",CaesarNavMesh.velocity.magnitude);
		break;
		case faseDaEntrada.giraProGlark:
			Vector3 V = GlarkTransform.position-CoreanTransform.position;
			V = new Vector3(V.x,0,V.z);
			Quaternion Q = Quaternion.LookRotation(V);
			CoreanTransform.rotation = Quaternion.Lerp(CoreanTransform.rotation,Q,Time.deltaTime);
			V = GlarkTransform.position - CaesarTransform.position;
			V = new Vector3(V.x,0,V.z);
			Q = Quaternion.LookRotation(V);
			CaesarTransform.rotation = Quaternion.Lerp(CaesarTransform.rotation,Q,Time.deltaTime);
		break;
		case faseDaEntrada.encontroComGlark:
			trocaMensagem();
		break;
		case faseDaEntrada.cameraParaGlar:
			trocaMensagem();
			transform.position = Vector3.Lerp(transform.position,posicoesDeCamera[9].position,5*Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation,posicoesDeCamera[9].rotation,5*Time.deltaTime);
		break;
		case faseDaEntrada.voltaCameraProCorean:
			trocaMensagem();
			transform.position = Vector3.Lerp(transform.position,posicoesDeCamera[7].position,5*Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation,posicoesDeCamera[7].rotation,5*Time.deltaTime);
		break;
		case faseDaEntrada.rajadaDeAgua:
			contadorDeTempo+=Time.deltaTime;
			if(contadorDeTempo>0.75f)
			{
				transform.position = Vector3.Lerp(transform.position,posicoesDeCamera[7].position,5*Time.deltaTime);
				transform.rotation = Quaternion.Lerp(transform.rotation,posicoesDeCamera[7].rotation,5*Time.deltaTime);
			}

			if(contadorDeTempo>1.5f)
			{
				fase = faseDaEntrada.empurrandoParaQueda;
				transform.position = posicoesDeCamera[7].position;
				transform.rotation = posicoesDeCamera[7].rotation;
				animatorDoCaesar.Play("damage_25");
				animatorDoCorean.Play("damage_25");
				colDaPonte.enabled = false;
				CaesarNavMesh.enabled = false;
				contadorDeTempo = 0;
			}
		break;
		case faseDaEntrada.empurrandoParaQueda:
			contadorDeTempo+=Time.deltaTime;
			if(contadorDeTempo<1f)
			{
				CoreanTransform.position+=15*Vector3.forward*Time.deltaTime;
				CaesarTransform.position+=15*Vector3.forward*Time.deltaTime;
			}else
			{
				fase = faseDaEntrada.estadoNulo;
				p = gameObject.AddComponent<pretoMorte>();
				StartCoroutine(pretoMorteVoltaFInal());
			}

		break;
		case faseDaEntrada.QuedaFinal:
			contadorDeTempo+=Time.deltaTime;
			if(contadorDeTempo<2)
			{
				CaesarTransform.position+=Vector3.down*15*Time.deltaTime;
				CoreanTransform.position+=Vector3.down*15*Time.deltaTime;
				pedrasFInais.position+=Vector3.down*15*Time.deltaTime;

			}else
			{
				p = gameObject.AddComponent<pretoMorte>();
				Invoke("novaCena",2.75f);
			}
		break;
		}

	}

	void novaCena()
	{
		Application.LoadLevel("entradinha_copiaParaModificacoes");
	}

	IEnumerator pretoMorteVoltaFInal()
	{
		yield return new WaitForSeconds(1.5f);
		p.entrando = false;
		contadorDeTempo = 0;
		fase = faseDaEntrada.QuedaFinal;
		transform.position = posicoesDeCamera[10].position;
		transform.rotation = posicoesDeCamera[10].rotation;
		CaesarTransform.position = transform.position+25*Vector3.up;
		CoreanTransform.position = transform.position+25*Vector3.up+3*Vector3.right;
		pedrasFInais.position = transform.position+35*Vector3.up;
	}

	public void faseAteCenaFinal()
	{
		variaveisChave.shift["alternaParaCriature"] = true;
	}

	public void maisDoCaesar()
	{
		contadorDeTempo = 0;
		fase = faseDaEntrada.ultimoSigaCaesar;
	}


	public void habilitaAlternador()
	{
		H.itens.AddRange(new item[5]{
			new item(nomeIDitem.aguaTonica),
			new item(nomeIDitem.gasolina),
			new item(nomeIDitem.regador),
			new item(nomeIDitem.maca),
			new item(nomeIDitem.cartaLuva)});
		H.itens[3].estoque = 10;
		H.itens[0].estoque = 3;
		H.itens[2].estoque = 2;
		variaveisChave.shift["HUDItens"] = false;
		fase = faseDaEntrada.habilitaAlternador;
	}


}

