using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuCarrega : MonoBehaviour {

	public GUISkin skin;
	public GUISkin destaque;

	private Menu menu;
	private Menu menu2 = null;
	private string situacao = "primeiraEscolha";

	private bool acao  = false;
	private bool menuEAux = false;
	private bool acaoAlt = false;
	private RectTransform doPainel;
	private bool entrandoPainel=true;
	private GameObject canvas3;


	// Use this for initialization


	void Start () {
        //GameJolt.UI.Manager.Instance.ShowSignIn();
        variaveisChave.valoresDefault();
		doPainel =GameObject.Find("Canvas2/Panel").GetComponent<RectTransform>();
		canvas3 = GameObject.Find("Canvas3");
		menu = gameObject.AddComponent<Menu>();
		menu.posXalvo = 0.2f;
		menu.posYalvo = 0.33f;
		menu.aMenu = 0.37f;
		menu.lMenu = 0.2f;
		atualizaTextos();
		menu.skin = skin;
		menu.destaque = destaque;
	}

	public void atualizaTextos()
	{
		menu.opcoes = bancoDeTextos.falacoes[heroi.lingua]["menuPreJogo"].ToArray();
	}

	void vejaOPainel()
	{
		Vector2 V = doPainel.anchoredPosition;
		if(entrandoPainel)
		{
			V.y = Mathf.Lerp(V.y,-52.82507f,Time.deltaTime*15f);
			doPainel.anchoredPosition = V;
		}else
		{
			V.y = Mathf.Lerp(V.y,2*Screen.height,Time.deltaTime);
			doPainel.anchoredPosition = V;
		}
	}
	
	// Update is called once per frame
	void Update () {

		vejaOPainel();

		if(Application.loadedLevelName == "saveAndLoad"){

		if(Input.GetKeyDown(KeyCode.Return)
		   ||
		   Input.GetButtonDown("acao"))
			acao = true;

		acaoAlt = Input.GetButtonDown("acaoAlt");

		if(Input.GetButtonDown("menu e auxiliar")
		   ||
		   Input.GetKeyDown(KeyCode.Escape)
		   ||
		   Input.GetKeyDown(KeyCode.Backspace)
		   )
			menuEAux = true;


			switch(situacao)
			{
			case "primeiraEscolha":
				primeiraEscolha();
			break;
			case "menuCarrega":
				escolhaDeCarregamento();
			break;
			}
		
		}

		acao = false;
		menuEAux = false;


	}

	void escolhaDeCarregamento()
	{
		if(menuEAux)
		{
			menu2.fechaJanela();
			situacao = "primeiraEscolha";
			menu.entrando = true;
			menu.podeMudar = true;

			entrandoPainel = true;
			canvas3.SetActive(true);
		}

		if(acaoAlt)
		{
			if(menu2.dentroOuFora()>-1)
				acao = true;
			else
			{
				menu2.fechaJanela();
				situacao = "primeiraEscolha";
				menu.entrando = true;
				menu.podeMudar = true;

				entrandoPainel = true;
				canvas3.SetActive(true);
			}
		}

		if(acao)
		{
			jogoParaSalvar.corrente = saveGame.savedGames[(int)menu2.escolha];
			GameObject.Find("meuCarregador").GetComponent<meLeveComVC>().carregar = true;

			GameObject.Find("Canvas").GetComponentInChildren<Text>().enabled = true;
			Destroy(menu2);
			//Application.LoadLevel("planicieDeInfinity");

			if(jogoParaSalvar.corrente.shift!=null)
				variaveisChave.aplicaShifts();

			if(jogoParaSalvar.corrente.contadorChave!=null)
				variaveisChave.aplicaContadores();

			Application.LoadLevel(jogoParaSalvar.corrente.nomeCena);
		}

	}

	void primeiraEscolha()
	{
		switch(menu.escolha)
		{
		case 0:
			if(acaoAlt&&menu.dentroOuFora()>-1)
				acao = true;
			if(acao)
			{
				GameObject.Find("Canvas").GetComponentInChildren<Text>().enabled = true;
				Destroy(menu);
				Application.LoadLevel("Entradinha2");
			}
			break;
		case 1:
			if(acaoAlt&&menu.dentroOuFora()>-1)
				acao = true;
			if(acao)
				if(menu2 == null)
			{
				saveGame.Load();
				if(saveGame.savedGames.Count>0)
				{
				entrandoPainel = false;
				canvas3.SetActive(false);
				//	acao = false;

					menu.podeMudar = false;
					menu.entrando = false;
					menu2 = gameObject.AddComponent<Menu>();
					menu2.posXalvo = menu.posXalvo;
					menu2.posYalvo = 0.01f;
					menu2.aMenu = 0.1f*saveGame.savedGames.Count;
					menu2.lMenu = menu.lMenu;
					menu2.opcoes = saveGame.jogosSalvos().ToArray();
					menu2.skin = skin;
					menu2.destaque = destaque;

					situacao = "menuCarrega";
				}else
				{
					mensagemEmLuta mL =  Camera.main.gameObject.GetComponent<mensagemEmLuta>();
					if(mL)
						mL.fechador();
					mL = Camera.main.gameObject.AddComponent<mensagemEmLuta>();
                    mL.skin = skin;
					mL.posX = 0.67f;
					mL.positivo  = true;
					mL.mensagem = "nao foram encontrados jogos salvos";
				}
			}

			
			break;
		case 2:
			if(acaoAlt&&menu.dentroOuFora()>-1)
				acao = true;
			if(acao)
			{
				Application.Quit();
			}
		break;
		}
	}


	/*
			public Vector2 scrollPosition = Vector2.zero;
			void OnGUI() {
				scrollPosition = GUI.BeginScrollView(new Rect(10, 300, 100, 100), scrollPosition, new Rect(0, 0, 220, 200));
				GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
				GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
				GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
				GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
				GUI.EndScrollView();
			}
			*/
		



}
