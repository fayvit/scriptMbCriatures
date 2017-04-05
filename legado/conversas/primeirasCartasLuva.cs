using UnityEngine;
using System.Collections;

public class primeirasCartasLuva : MonoBehaviour {
	public int indiceDoEvento = -1	;
	public string indiceDaConversa = "bomDia";
	private conversaEmJogo cJ;
	private Menu menu;
	private string[] simOuNao;
	private string[] essaConversa;
	private GUISkin skin;
	private GUISkin destaque;
	private bool acao = false;
	private bool menuEAux = false;
	private string estado = "inicial";
	private heroi H;
	private int indiceDaMinhaMens = -1;
	private bool invocando = false;
	// Use this for initialization
	void Start () {
		H = GameObject.FindWithTag("Player").GetComponent<heroi>();
		cJ = GetComponent<conversaEmJogo>();
		simOuNao = bancoDeTextos.falacoes[heroi.lingua]["simOuNao"].ToArray();
		essaConversa = bancoDeTextos.falacoes[heroi.lingua][indiceDaConversa].ToArray();
		menuInTravel2 T = Camera.main.transform.GetComponent<menuInTravel2>();
		skin = T.skin;
		destaque = T.destaque;

	}

	void perguntaInicial()
	{
		switch(menu.escolha)
		{
		case 0:
			if(H.criaturesAtivos.Count>1)
				indiceDaMinhaMens = 1;
			else
				indiceDaMinhaMens = 2;
		break;
		case 1:
			if(H.criaturesAtivos.Count<=1 && shopBasico.temItem(nomeIDitem.cartaLuva,H)<=-1)
			{
				indiceDaMinhaMens = 0;
				for(int i=0;i<5;i++)
					shopBasico.adicionaItem(nomeIDitem.cartaLuva,H);
			}else if(H.criaturesAtivos.Count>1)
				indiceDaMinhaMens = 3;
			else
				indiceDaMinhaMens = 4;

			
		break;
		}

		menu.fechaJanela();
		estado = "";
		if(!invocando){
			cJ.mens.entrando = false;
			Invoke("proxMens",0.15f);
			invocando  =true;
		}
	}

	void proxMens()
	{
		cJ.mens.mensagem = essaConversa[indiceDaMinhaMens];
		cJ.mens.entrando = true;
		invocando = false;
		estado = "porFinalizar";
	}
	
	// Update is called once per frame
	void Update () {
		if(cJ.mensagemAtual == indiceDoEvento)
		{
			if(cJ.evento == false){
				cJ.evento = true;
				menu = gameObject.AddComponent<Menu>();
				menu.aMenu = 0.2f;
				menu.lMenu = 0.2f;

				menu.opcoes = simOuNao;
				menu.posXalvo = 0.7f;
				menu.posYalvo = 0.4f;
				menu.skin = skin;
				menu.Nome = "responde";
				menu.destaque = destaque;
			}


			acao = Input.GetButtonDown("acao");

			menuEAux = Input.GetButtonDown("menu e auxiliar");
			bool acaoAlt = Input.GetButtonDown("acaoAlt");
			switch(estado)
			{
			case "inicial":
				if(acaoAlt && menu.dentroOuFora()>-1  )
					acao = true;

				if(acao)
					perguntaInicial();
			break;
			case "porFinalizar":
				if(acao|| menuEAux||acaoAlt){
					cJ.evento = false;
					cJ.finalisaConversa();
					cJ.mensagemAtual = 0;
					estado = "inicial";
				}
			break;
			}

			acao = false;
			menuEAux = false;
		}
	
	}
}
