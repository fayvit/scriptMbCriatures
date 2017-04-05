using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class encontros : MonoBehaviour {
	protected Transform tHeroi;
	protected Vector3 posHeroi;
	protected Vector3 posAnterior;
	protected string[] textinhos;

	[SerializeField]
	private float andado = 0f;
	protected int passoDaAnimaInicial = 0;
	protected bool luta = false;
	protected bool foiApresentado = false;
	protected bool apresentouFim = false;
	protected GameObject oHeroi;
	protected movimentoBasico heroiMB;
	protected encontravel encontrado;
	protected mensagemBasica mens;


	private float contadorDeTempo = 0f;
	private float escala;
	private morteEmLuta dead;
	protected apresentaFim fim;
	private Menu menu;


	protected GameObject X = null;
	protected GameObject Inimigo = null;
	protected umCriature inimigoUC;
	protected umCriature meuCriatureUC;
	protected IA_inimigo IA;

	private bool aprendendoGolpeFora = false;

	public float minEncontro = 100f;// valores de Infinity
	public float maxEncontro = 400f;
	public float proxEncontro = 300f;
	[HideInInspector]
	public List<saidaDeCaverna> saidas = new List<saidaDeCaverna>();



	private golpe golpeAprendido;
	
	public void zeraPosAnterior()
	{
		if(!tHeroi)
			tHeroi = GameObject.FindWithTag("Player").transform;
		posAnterior = tHeroi.position;
		posHeroi = tHeroi.position;
		andado = 0;
	}

	// Use this for initialization
	protected void Start () {
		textinhos = bancoDeTextos.falacoes[heroi.lingua]["encontrosScript"].ToArray();
		oHeroi = GameObject.FindGameObjectWithTag("Player");
		tHeroi = oHeroi.transform;
		posAnterior = tHeroi.position;
		heroiMB = tHeroi.GetComponent<movimentoBasico>();
		proxEncontro = SorteiaPassosParaEncontro ();
	}

	// Update is called once per frame
	protected void Update () {
		if(!pausaJogo.pause){
			if(!luta )
				posHeroi = tHeroi.position;

			if(!heroiMB)
				heroiMB = tHeroi.GetComponent<movimentoBasico>();

			if(!lugarSeguro()&& !luta && heroiMB.noChao(heroiMB.Y.distanciaFundamentadora))
			{
				andado += (posHeroi - posAnterior).magnitude;
			}


			if(!luta && andado>=proxEncontro)
			{
				print(andado+" : "+proxEncontro);
				proxEncontro = SorteiaPassosParaEncontro();
				//			int paraEncontrado = Random.Range(0,10);
				encontrado = criatureEncontrado();
				encontroPadrao();
				andado = 0;
			}
			
			posAnterior = posHeroi;
			
			passoDoEncontro ();
			
			
			Debug.DrawRay (posHeroi-40f*tHeroi.forward,1000f*Vector3.up,Color.yellow);
		}
	}

	protected virtual bool lugarSeguro()
	{
		return true;
	}

	protected virtual List<encontravel> listaEncontravel()
	{
		return new List<encontravel>();
	}

	encontravel criatureEncontrado()
	{
		List<encontravel> encontraveis = listaEncontravel();//secaoEncontravel[IndiceDoLocal()];
		float maiorAleatorio = 0;
		for(int i=0;i<encontraveis.Count;i++)
		{
			maiorAleatorio+=encontraveis[i].taxa;
		}
		//		print(maiorAleatorio);
		float roleta = Random.Range(0,maiorAleatorio);
		//		print(roleta);
		float sum = 0;
		int retorno = -1;
		for(int i=0;i<encontraveis.Count;i++)
		{
			sum += encontraveis[i].taxa;
			
			if(roleta<=sum && retorno==-1)
				retorno = i;
		}
		
		return encontraveis[retorno];
	}

	protected bool relativoAReta(float x1,float z1,float x2,float z2,bool maior,float x,float z )
	{
		bool retorno = false;
		
		if(z<(z2-z1)/(x2-x1)*(x-x1)+z1)
		{
			if(maior)
				retorno = false;
			else
				retorno = true;
		}else if (z>(z2-z1)/(x2-x1)*(x-x1)+z1)
		{
			if(maior)
				retorno = true;
			else
				retorno = false;
		}
		
		return retorno;
	}

	protected void passoDoEncontro()
	{
		//Debug.DrawRay(tHeroi.position,10*Vector3.up,Color.white);
		switch(passoDaAnimaInicial)
		{
		case 1:

			truqueDeCamera();
			//print("no passo 1 "+ inimigoUC.X.mNivel.Nivel);
		break;
		case 2:
			apresentaAdversario();

		break;
		case 3:
			comecaLuta();
		break;
		case 4:
			if(X!= null)
				verifiqueVida();
			else
				if(GameObject.Find("CriatureAtivo"))
					X=GameObject.Find("CriatureAtivo");
		break;
		case 5:
			vitoriaNaLuta();
		break;
		case 6:
			voltarParaPasseio();
		break;
		case 7:
			morreuEmLuta();
		break;
		case 8:
			if(dead!=null)
				if(dead.passoDaMorte==4)
					passoDaAnimaInicial = 9;
		break;
		case 9:
			if(GameObject.FindWithTag("Player").GetComponent<animaEnvia>())
				passoDepoisDoInicio();
		break;
		case 10:
			elePassouDeNivel();
		break;
		case 11:
			bool acao = Input.GetButtonDown("acao");

			if(Input.GetButtonDown("acaoAlt")&&menu.dentroOuFora()>-1)
				acao = true;

			if(acao)
				descarteGolpe();

		break;
		case 12:
			if(botoesPrincipais())
			{
				mens.fechaJanela();
				fim.conteudo = "aprendeuEsse";
				fim.aprendeuEsse = golpeAprendido;
				passoDaAnimaInicial = 10;
				fim.entrando = true;
			}
		break;
		case 13:
			if(botoesPrincipais())
			{
				mens.fechaJanela();
				fim.fechaJanela();
				if(!aprendendoGolpeFora)
					OPassoDepoisDaVitoria();
				else
				{
					voltaParaUsandoItem();
				}
			}
		break;
		}
	}

	private void descarteGolpe()
	{
		mens.entrando = false;
		passoDaAnimaInicial = 0;

		Criature X = fim.vencedor;
		nomesGolpes nomeGolpe = golpeAprendido.nomeID;


		if(menu.escolha!=4)
		{
			mens.mensagem = X.Nome+textinhos[2]+
				golpe.nomeEmLinguas(X.Golpes[menu.escolha]);
			X.Golpes[menu.escolha] = new pegaUmGolpe(nomeGolpe).OGolpe();
			X.Golpes[menu.escolha].Basico += (uint)X.verificaNovoGolpe().mod;
			X.Golpes[menu.escolha].Corrente += (uint)X.verificaNovoGolpe().mod;
			X.Golpes[menu.escolha].Maximo += (uint)(2*X.verificaNovoGolpe().mod);
			Invoke("volteMens",0.15f);
		}else
		{
			mens.mensagem = X.Nome+textinhos[3]+
				new pegaUmGolpe(nomeGolpe).OGolpe().Nome;
			Invoke("preparaVoltaPasseio",0.15f);
		}

		menu.fechaJanela();
	}

	private void preparaVoltaPasseio()
	{
		mens.entrando = true;
		passoDaAnimaInicial = 13;

	}

	private void volteMens()
	{
		mens.entrando = true;
		passoDaAnimaInicial = 12;
	}

	public static bool botoesPrincipais()
	{
		return (Input.GetButtonDown("acao")
		        ||
		        Input.GetButtonDown("acaoAlt")
		        ||
		        Input.GetButtonDown("menu e auxiliar"));
	}

	public void aprendeuGolpeForaDoEncontro(Criature C,nivelGolpe novoGolpe)
	{
		if(!fim)
		{
			fim = gameObject.AddComponent<apresentaFim>();
			fim.vencedor = C;
			fim.derrotado = C;
			fim.fecharML = false;
		}

		aprendendoGolpeFora = true;

		aprendizadoDeGolpe(novoGolpe);
	}

	void aprendizadoDeGolpe(nivelGolpe novoGolpe)
	{

		golpeAprendido = new pegaUmGolpe(novoGolpe.nome).OGolpe();
		if(fim.vencedor.Golpes.Length< 4)
		{
			List<golpe> G = new List<golpe>();
			G.AddRange(fim.vencedor.Golpes);
			G.Add(new pegaUmGolpe(novoGolpe.nome).OGolpe());
			G[G.Count-1].Basico += (uint)novoGolpe.mod;
			G[G.Count-1].Corrente += (uint)novoGolpe.mod;
			G[G.Count-1].Maximo += (uint)(2*novoGolpe.mod);
			fim.vencedor.Golpes = G.ToArray();
			fim.conteudo = "aprendeuEsse";
			fim.aprendeuEsse = G[G.Count-1];
			Invoke("aprendeuGolpe",0.15f);
			fim.entrando = false;
			passoDaAnimaInicial = 0;
		}else
		{
			
			fim.conteudo = "podeAprender";
			fim.aprendeuEsse = golpeAprendido;
			Invoke("podeAprenderEsse",0.15f);
			fim.entrando = false;
			passoDaAnimaInicial = 0;
		}
	}

	void voltaParaUsandoItem()
	{
		passoDaAnimaInicial = 0;
		Camera.main.GetComponent<acaoDeItem2>().finalisaAprendeGolpe();
	}

	private void elePassouDeNivel()
	{
		if(fim)
		{
			switch(fim.conteudo)
			{
			case "pontinhos":
				if(botoesPrincipais())
				{
					fim.entrando = false;
					Invoke("fimPassouDeNivel",0.15f);
					fim.conteudo = "deNivel";
					passoDaAnimaInicial = 0;
				}
			break;
			case "deNivel":
				if(botoesPrincipais())
				{
					
					
					nivelGolpe novoGolpe = fim.vencedor.verificaNovoGolpe();
					if(novoGolpe.nivel == fim.vencedor.mNivel.Nivel
					   &&
					   novoGolpe.nome!=nomesGolpes.nulo)
					{

						aprendizadoDeGolpe(novoGolpe);

					}else
					{
						fim.fechaJanela();

						if(!aprendendoGolpeFora)
							OPassoDepoisDaVitoria();
						else						
							voltaParaUsandoItem();

						
					}
				}
			break;
			case "aprendeuEsse":
				if(botoesPrincipais())
				{
					fim.fechaJanela();

					if(!aprendendoGolpeFora)
						OPassoDepoisDaVitoria();
					else
						voltaParaUsandoItem();


				}
			break;
			case "podeAprender":
				if(botoesPrincipais())
				{
					fim.entrando = false;
					passoDaAnimaInicial = 11;
					menu = gameObject.AddComponent<Menu>();

					string[] opcoes = new string[5];
					for(int i=0;i<4;i++)
						opcoes[i] = golpe.nomeEmLinguas(fim.vencedor.Golpes[i]);

					opcoes[4] = textinhos[0];
					menu.opcoes = opcoes;
					menu.posXalvo = 0.7f;
					menu.posYalvo = 0.1f;
					menu.aMenu = 0.1f*opcoes.Length;
					menu.lMenu = 0.2f;
					menu.skin = fim.skin;
					menu.Nome = "responde";
					menu.destaque = elementosDoJogo.el.destaque;

					mens = gameObject.AddComponent<mensagemBasica>();
					mens.posX = 0.01f;
					mens.posY = 0.68f;
					mens.mensagem  = string.Format(textinhos[1],fim.vencedor.Nome,
					                               golpe.nomeEmLinguas(golpeAprendido));
					mens.skin = fim.skin;
				}
			break;
			}


		}


	}

	private void podeAprenderEsse()
	{
		fim.entrando = true;
		passoDaAnimaInicial = 10;
	}

	private void fimPassouDeNivel()
	{
		fim.entrando = true;
		passoDaAnimaInicial = 10;
	}

	private void aprendeuGolpe()
	{
		fim.entrando = true;
		passoDaAnimaInicial = 10;
	}

	public virtual void voltarParaPasseio()
	{
		tHeroi.position = posHeroi;
		Camera.main.transform.position = tHeroi.position - tHeroi.forward * 5+Vector3.up*2;
		Camera.main.transform.LookAt (tHeroi.transform);

		if(!X)
			X = GameObject.Find("CriatureAtivo");

		X.GetComponent<movimentoBasico> ().podeAndar = true;
		X.GetComponent<alternancia> ().retornaAoHeroi ();
		luta = false;
		apresentouFim = false;
		foiApresentado = false;
		heroi.emLuta = false;
		if(Inimigo != null)
			Destroy (Inimigo);
		Destroy (GameObject.Find ("cilindroEncontro"));
		passoDaAnimaInicial = 0;
		GameObject terra = name == "Terrain"?gameObject:GameObject.Find("Terrain");
		if(terra.GetComponent<vidaEmLuta>())
		{
			vidaEmLuta[] Vs = terra.GetComponents<vidaEmLuta>();
			foreach(vidaEmLuta v in Vs)
				v.fechaJanela();
		}
		//Resources.UnloadAsset(Inimigo);
		System.GC.Collect();
		Resources.UnloadUnusedAssets();
	}

	void recebePontosDaVitoria()
	{
	
		Criature vencedor = X.GetComponent<umCriature> ().criature ();
		uint derrotadoM = inimigoUC.criature ().cAtributos[0].Maximo;
		heroi H = oHeroi.GetComponent<heroi> ();
		vencedor.mNivel.XP+= (uint)Mathf.Round((float)((double)derrotadoM / (double)2));
		if(vencedor.mNivel.verificaPassaNivel(vencedor.cAtributos))
		{
			passoDePassarDeNivel();
		}
		H.cristais += derrotadoM;
	}

	protected virtual void passoDePassarDeNivel()
	{
		passoDaAnimaInicial = 10;
	}

	protected void vitoriaNaLuta()
	{
		Camera cameraP = Camera.main;
		contadorDeTempo += Time.deltaTime;
		if(contadorDeTempo>2f)
			if(!apresentouFim)
		{
			Animator animator = X.GetComponent<Animator> ();

			animator.SetFloat ("velocidade", 0);
			escala = X.GetComponent<CharacterController>().height;
			cameraP.transform.position = (X.transform.position + 8 * X.transform.forward+(5+escala)*Vector3.up);
			cameraP.transform.LookAt(X.transform);
			apresentouFim = true;
			GameObject terra = name == "Terrain" ? gameObject:GameObject.Find("Terrain");
			vidaEmLuta[] v = terra.GetComponents<vidaEmLuta>();
			foreach(vidaEmLuta v1 in v)
				v1.fechaJanela();
		}else
		{
			cameraP.transform.RotateAround(X.transform.position,Vector3.up,15*Time.deltaTime);
			cameraPrincipal.contraParedes(cameraP.transform,X.transform,escala,true);
			if(!fim){
				// coloquei para que um morto nao vença a luta
				IA.paraMovimento();// coloquei para que um morto nao ande ate o advesario
				fim = gameObject.AddComponent<apresentaFim>();
				fim.vencedor = X.GetComponent<umCriature>().criature();
				fim.derrotado = inimigoUC.criature();
				recebePontosDaVitoria();

			}else
				
				if(botoesPrincipais() || contadorDeTempo>10f)
			{
				if(fim)
					fim.fechaJanela();

				OPassoDepoisDaVitoria();

			}
		}

	}

	protected virtual void OPassoDepoisDaVitoria()
	{
		passoDaAnimaInicial = 6;
	}

	protected void interrompeFluxoDeLuta()
	{
		X.GetComponent<movimentoBasico> ().enabled = false;
		X.GetComponent<cameraPrincipal>().enabled = false;
	}


	protected virtual void umaVitoria()
	{
		passoDaAnimaInicial = 5;
		interrompeFluxoDeLuta();
	}

	protected virtual void umaDerrota()
	{
		passoDaAnimaInicial = 7;
		interrompeFluxoDeLuta();
	}

	protected void verifiqueVida()
	{
		Criature M = inimigoUC.criature();

		if(!meuCriatureUC)
			meuCriatureUC = X.GetComponent<umCriature> ();

		Criature X1 = meuCriatureUC.criature();
		contadorDeTempo = 0;

		if(M.cAtributos[0].Corrente<=0&&X1.cAtributos[0].Corrente>0){
			umaVitoria();
		}

		if(X1.cAtributos[0].Corrente<=0)
			umaDerrota();

	}

	protected void morreuEmLuta()
	{
		contadorDeTempo+=Time.deltaTime;
		if(contadorDeTempo>0.25f){
			Criature X1 = X.GetComponent<umCriature>().criature();
			dead =  X.GetComponent<morteEmLuta>();
			if(!dead)
				dead = X.AddComponent<morteEmLuta>();

			X.AddComponent<gravidadeGambiarra>();
			//dead.Inimigo = Inimigo;
			dead.Ia = IA;
			//dead.criature = X;
			dead.oMOrto = X1;

			passoAposAMorte();


		}
	}

	protected virtual void passoAposAMorte()
	{
		passoDaAnimaInicial = 8;
	}

	protected virtual void passoDepoisDoInicio()
	{
		passoDaAnimaInicial = 4;
	}

	protected void comecaLuta()
	{
		GameObject terra = name == "Terrain"?gameObject:GameObject.Find("Terrain");
		IA.podeAtualizar = true;

		vidaEmLuta w = terra.AddComponent<vidaEmLuta> ();
		w.doMenu = inimigoUC.criature();
		w.nomeVida = "inimigo";
		w.posX = 0.01f;
		w.posY = 0.78f;
		w.n = 1;

		Camera.main.transform.position = X.transform.position - X.transform.forward * 5+Vector3.up*2;
		Camera.main.transform.LookAt (X.transform);

		cameraPrincipal cameraP = X.GetComponent<cameraPrincipal> ();
		cameraP.luta = true;
		cameraP.enabled = true;

		movimentoBasico mB = X.GetComponent<movimentoBasico> ();
		mB.podeAndar = true;
		mB.enabled = true;

		passoDepoisDoInicio();


		vidaEmLuta v = terra.AddComponent<vidaEmLuta> ();
		v.minhaLuta = true;
		v.doMenu = X.GetComponent<umCriature>().criature ();
		v.nomeVida = "meuCriature";
		v.n = 2;
		v.posX = 0.74f;
		v.posY = 0.78f;

	}

	protected virtual void bugDoNivel1()
	{
		int nivelDeEncontrado = nivelandoEncontrado(encontrado);
		
		if(nivelDeEncontrado>1)
		{
			inimigoUC.X = new cCriature(encontrado.nome,(uint)nivelDeEncontrado).criature();

			IA.remendoDeBug();
		}



	}

	protected void truqueDeCamera()
	{
		contadorDeTempo += Time.deltaTime;
		if (contadorDeTempo > 0.5f) {

			cameraPrincipal cameraP = X.GetComponent<cameraPrincipal> ();
			cameraP.enabled = false;
			passoDaAnimaInicial = 2;
			contadorDeTempo = 0;
		}
	}

	protected void apresentaAdversario()
	{

		Camera cameraP = Camera.main;
		contadorDeTempo += Time.deltaTime;


		if(contadorDeTempo> 0.5f)
		if(!foiApresentado){
			cameraP.transform.position = (Inimigo.transform.position + 8 * Inimigo.transform.forward+5*Vector3.up);
			cameraP.transform.LookAt(Inimigo.transform);
			foiApresentado = true;
		}else
		{
			cameraP.transform.RotateAround(Inimigo.transform.position,Vector3.up,15*Time.deltaTime);
			if(!GetComponent<apresentaInimigo>()){
				bugDoNivel1();

				/*
					Gambiarra pra tirar o bug do inimigo caindo do chao


				if(Inimigo.transform.position.y - X.transform.position.y>5)
				{
					Vector3 V = Inimigo.transform.position;
					Inimigo.transform.position = new melhoraPos().novaPos(
						new Vector3(V.x,X.transform.position.y+2,V.z)
						);
				}

				/******************************************/


				iniciaApresentaInimigo();
			}else

				if(Input.GetButtonDown("acaoAlt") ||Input.GetButtonDown("acao") || Input.GetButtonDown("menu e auxiliar") || contadorDeTempo>10f)
			{
				apresentaInimigo E = GetComponent<apresentaInimigo>();
				E.fechaJanela();
				depoisDeTerminarAApresentacao();
			}
		}
	}

	protected virtual void iniciaApresentaInimigo()
	{
		apresentaInimigo enemy = gameObject.AddComponent<apresentaInimigo>();

		enemy.inimigo = inimigoUC.criature();
	}

	protected virtual void depoisDeTerminarAApresentacao()
	{
		passoDaAnimaInicial = 3;
	}

	Vector3 emBuscaDeUmaBoaPosicao(Vector3 pontoInicial,float PQP,string terreno = "Terrain")
	{
		Vector3 retorno = pontoInicial;
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast (pontoInicial+PQP*Vector3.up,-Vector3.up,out hit))
		{
			if(hit.transform.name ==  terreno){
				retorno = hit.point + 2f*Vector3.up;
				print("raio ~subindo");
			}
		}else if(Physics.Raycast (pontoInicial-PQP*Vector3.up,Vector3.up,out hit))
			if(hit.transform.name == terreno){
				retorno = hit.point + 2f*Vector3.up;
			print("raio ~descendo");
		}
		return retorno;
	}

	Vector3 novaPos()
	{
		RaycastHit hit = new RaycastHit();
		string nomeDoTerreno = "Terrain";
		if(Physics.Raycast(posAnterior,Vector3.down,out hit))
		{
			nomeDoTerreno = hit.collider.name;
		}
		Vector3 retorno = posHeroi - 40f * tHeroi.forward;
		retorno = new melhoraPos().posEmparedado(retorno,posHeroi);
		float saoSalvador = tHeroi.GetComponent<CharacterController>().height;
		retorno = emBuscaDeUmaBoaPosicao(retorno,saoSalvador,nomeDoTerreno );

		return retorno;
	}

	protected void adicionaCilindroEncontro()
	{
		GameObject cilindro = elementosDoJogo.el.retorna ("cilindroEncontro");
		Object cilindro2 = Instantiate (cilindro,posHeroi,Quaternion.identity);
		cilindro2.name = "cilindroEncontro";
	}

	protected void alteraPosDoCriature()
	{
		if(!X)
			X = GameObject.Find("CriatureAtivo");
		
		X.transform.position = posHeroi;//new melhoraPos().novaPos(posHeroi,X.transform.lossyScale.y);
		X.transform.rotation = tHeroi.rotation ;
	}

	protected void alternanciaParaCriature()
	{

		alternancia a = X.GetComponent<alternancia> ();
		a.aoCriature ();
	}

	protected void impedeMovimentoDoCriature()
	{
		movimentoBasico mB = X.GetComponent<movimentoBasico> ();
		mB.podeAndar = false;
	}

	protected void paraAnimatorDoCriature()
	{
		Animator animator = X.GetComponent<Animator> ();
		
		
		animator.SetFloat ("velocidade", 0);
	}

	protected void colocaOHeroiNaPOsicaoDeEncontro()
	{
		tHeroi.position = novaPos ();//40f * tHeroi.forward;
		
		
		oHeroi.AddComponent<gravidadeGambiarra> ();
	}

	protected GameObject setaInimigo()
	{
		GameObject M = elementosDoJogo.el.criature (encontrado.nome.ToString());
		
		Vector3 instancia = posHeroi + 10 * tHeroi.forward;
		/*
		RaycastHit hit = new RaycastHit ();
			if(Physics.Linecast(posHeroi,posHeroi+10*tHeroi.forward,out hit))
		{
			instancia = hit.point+Vector3.up;
		}*/
		melhoraPos melhoraPF = new melhoraPos();
		
		instancia = melhoraPF.posEmparedado(instancia,posHeroi);
		
		instancia = melhoraPF.novaPos(instancia,M.transform.lossyScale.y);
		
		GameObject InimigoX = Instantiate (M,instancia,Quaternion.identity) as GameObject;

		return InimigoX;
	}

	protected umCriature nomeieETransformEmCriature(GameObject InimigoX)
	{
		InimigoX.name = "inimigo";
		umCriature inimigoUCX = InimigoX.GetComponent<umCriature>();
		return inimigoUCX;
	}

	protected void colocaIAPadrao()
	{
		if(!variaveisChave.shift["HUDItens"])
			IA = Inimigo.AddComponent<IA_inimigo>();
		else
			IA = Inimigo.AddComponent<IA_paraTutu>();
	}

	protected void animacaoDeEncontro()
	{
		heroi.emLuta = true;
		GameObject anima = elementosDoJogo.el .retorna ("encontro");

		Object anima1 = Instantiate (anima,posHeroi,Quaternion.identity);
		Destroy (anima1, 2);
	}

	void encontroPadrao()
	{
		animacaoDeEncontro();
		adicionaCilindroEncontro();
		alteraPosDoCriature();
		alternanciaParaCriature();

		colocaOHeroiNaPOsicaoDeEncontro();

		impedeMovimentoDoCriature();

		luta = true;

		Inimigo = setaInimigo();
		//Inimigo.transform.position = emBuscaDeUmaBoaPosicao(Inimigo.transform.position,1 );

		inimigoUC =  nomeieETransformEmCriature(Inimigo);

		colocaIAPadrao();

		passoDaAnimaInicial = 1;

	}

	private int nivelandoEncontrado(encontravel encontrado)
	{
		int retorno = 0;
		switch(encontrado.tipo)
		{
			case 0:
				// a fazer (relativo a primeira fase)
				retorno = 1;
			break;
			case 1:
				retorno = Random.Range(encontrado.nivelMin,encontrado.nivelMax+1);
			break;
		}

		return retorno;
	}

	protected float SorteiaPassosParaEncontro()
	{
		return Random.Range (minEncontro, maxEncontro);
	}
}

public struct saidaDeCaverna
{
	public string cenaAlvo;
	public Vector3 posAlvo;
	public int rotacaoAlvo;
	public bool entreiPorAqui;
	public Vector3 entrada;
}