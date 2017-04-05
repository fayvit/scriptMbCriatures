using UnityEngine;
using System.Collections;

public class pausaJogo : MonoBehaviour {
	GameObject Quem;
	movimentoBasico mB;
	cameraPrincipal cam;
	bool emMovimento;
	bool menuAtivo;
	bool camAtiva;
	public static bool pause = false;
	menuInTravel2 mIT2;
	public GUISkin skin;
	GUISkin destaque;
//	float tempoDePause = 0;
	string[] opcoes;
	menuDePausa mP;
	string menuAtivoNome;
	bool menuAberto;
	botoes B;
	bool botoesAberto = false;

	void OnApplicationFocus(bool focusStatus) {
#if !UNITY_EDITOR
		if(!focusStatus && !pausaJogo.pause)
		{
			pausando();
		}
#endif
	}
	// Use this for initialization
	void Start () {
		mIT2 = GameObject.Find("Main Camera").GetComponent<menuInTravel2>();
		//skin = mIT2.skin;
		destaque = mIT2.destaque;
		opcoes = bancoDeTextos.falacoes[heroi.lingua]["menuPausa"].ToArray();
	}

	void menusAbertos()
	{
		Menu[] menus = GetComponents<Menu>();
		foreach(Menu menu in menus)
			if(menu.podeMudar==true)
		{
			menuAtivoNome = menu.Nome;
			menu.podeMudar = false;
			menuAberto = true;
		}else
			menuAberto = false;

		if(menus.Length==0)
			menuAberto = false;

	}

	void pausando()
	{
		menusAbertos();
		//tempoDePause = 0.5f;
		Quem = GameObject.Find("CriatureAtivo");
		Time.timeScale = 0;
		if(Quem){
			if(!Quem.GetComponent<movimentoBasico>())
				Quem = GameObject.FindWithTag("Player");
		}else
			Quem = GameObject.FindWithTag("Player");
		
		mB = Quem.GetComponent<movimentoBasico>();
		if(mB.enabled == true && mB.podeAndar==true)
		{
			mB.enabled = false;
			emMovimento = true;
		}else
			emMovimento = false;

		if(mIT2.enabled == true)
		{
			mIT2.enabled = false;
			menuAtivo = true;
		}else
			menuAtivo = false;

		cam = Quem.GetComponent<cameraPrincipal>();
		if(cam.enabled == true)
		{
			cam.enabled = false;
			camAtiva = true;
		}else
			camAtiva = false;
		pause = true;
		mP = gameObject.AddComponent<menuDePausa>();
		mP.opcoes = opcoes;
//		mP.tempoDeM
		mP.posX = 0.4f;
		mP.posY = 0.2f;
		mP.lCaixa = 0.2f;
		mP.aCaixa = 0.1f;
		mP.skin = skin;
		mP.destaque = destaque;
	}

	void despausando()
	{
		if(menuAberto){
			print(menuAtivoNome);
			mIT2.retornaMenu(menuAtivoNome).podeMudar = true;
		}
		mP.fechaJanela();
		if(emMovimento)
			mB.enabled = true;

		if(menuAtivo)
			mIT2.enabled = true;

		if(camAtiva)
			cam.enabled = true;

		Time.timeScale = 1;

		pause = false;

		if(B!= null)
			B.fechaJanela();

		botoesAberto = false;

	}

	void apareceBotoes()
	{
		B = gameObject.AddComponent<botoes>();
		B.posX = 0.02f;
		B.posY = 0.1f;
		B.aCaixa = 0.8f;
		B.lCaixa = 0.96f;
		B.skin = skin;
		botoesAberto = true;
		mP.podeMudar = false;
	}
	
	// Update is called once per frame
	void Update () {
		bool acao = Input.GetButtonDown("acao");
		bool menuEAux = Input.GetButtonDown("menu e auxiliar");
		bool acaoAlt = Input.GetButtonDown("acaoAlt");
		if(Input.GetButtonDown("Submit") && !pause)
		{
			pausando();
		}else

		if(Input.GetButtonDown("Submit") && pause)
		{
			despausando();
		}else if((acao||acaoAlt)&& pause && !botoesAberto)
		{
			if(acaoAlt)
			{
				if(mP.dentroOuFora()>-1)
					
					acao = true;
				else
					despausando();
			}

			if(acao){
			switch(mP.escolha)
			{
				case 0:
					despausando();
				break;
				case 1:
					apareceBotoes();
				break;
				case 2:
					Application.LoadLevel(0);
					pausaJogo.pause = false;
					Time.timeScale = 1;
				break;
				case 3:
					Application.Quit();
				break;
			}
			}
		}else if((acao||menuEAux||acaoAlt)&& pause && botoesAberto)
		{
			botoesAberto = false;
			if(B!= null)
				B.fechaJanela();
			mP.podeMudar = true;
		}

		acao = false;
		menuEAux = false;

		if(pause)
		{
			System.GC.Collect();
			Resources.UnloadUnusedAssets();
		}
	
	}



	//void OnGUI()
	//{
		/*
		if(pause)
		{
			posXr = posX*Screen.width;
			posYr = posY*Screen.height;
			altr = alt*Screen.height;
			largr = larg*Screen.width;
			posXrr = Mathf.Lerp(posXrr,posXr,0.1f);
			altBox = opcoes.Length*altr+(opcoes.Length+1)*0.01f*Screen.height;
		}else if(!pause && tempoDePause>0)
		{
			tempoDePause-=Time.deltaTime;
			posXrr = Mathf.Lerp(posXrr,-Screen.width,0.05f);
		}

		if(tempoDePause>0)
		{
			GUI.Box(new Rect(posXrr,posYr,largr,altBox),"teste",skin.box);
			for(int i=0;i<opcoes.Length;i++)
			{
				Rect R = new Rect(posXrr+0.01f*Screen.width,
				                  posYr+0.01f*Screen.height+i*(altr+0.01f*Screen.height),				                 
				                  largr-0.02f*Screen.width,
				                  altr);
					GUI.Box(R,opcoes[i],escolha==i? destaque.box : skin.box);
			}
		}
		*/
	//}
}
