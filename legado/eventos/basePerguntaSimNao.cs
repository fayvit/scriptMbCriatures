using UnityEngine;
using System.Collections;

public class basePerguntaSimNao : MonoBehaviour {

	public int indiceDoEvento = -1	;
	public string indiceDaConversa = "bomDia";

	protected int indiceDaMinhaMens = -1;
	
	private conversaEmJogo cJ;
	private Menu menu;
	private string[] simOuNao;
	private string[] essaConversa;
	private faseDaConversa fase = faseDaConversa.perguntaAberta;
	private bool invocando = false;
	
	private enum faseDaConversa
	{
		perguntaAberta,
		porFinalisar,
		faseNula
	}

	protected virtual void respondeuSim()
	{

	}

	protected virtual void respondeuNao()
	{

	}
	
	void perguntaInicial()
	{
		switch(menu.escolha)
		{
		case 0:
			respondeuSim();
		break;

		case 1:
			respondeuNao();			
		break;
		}
		
		menu.fechaJanela();
		fase = faseDaConversa.faseNula;
		if(!invocando){
			cJ.mens.entrando = false;
			Invoke("proxMens",0.15f);
			invocando  = true;
		}
	}

	void proxMens()
	{
		cJ.mens.mensagem = essaConversa[indiceDaMinhaMens];
		cJ.mens.entrando = true;
		invocando = false;
		fase = faseDaConversa.porFinalisar;

	}

	protected virtual void eventoFinalisador()
	{}
	
	
	// Use this for initialization
	void Start () {
		cJ = GetComponent<conversaEmJogo>();
		simOuNao = bancoDeTextos.falacoes[heroi.lingua]["simOuNao"].ToArray();
		essaConversa = bancoDeTextos.falacoes[heroi.lingua][indiceDaConversa].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		bool acao = Input.GetButtonDown("acao");
		bool acaoAlt = Input.GetButtonDown("acaoAlt");
		
		if(cJ.mensagemAtual == indiceDoEvento)
		{
			if(cJ.evento == false){
				cJ.evento = true;
				menu = gameObject.AddComponent<Menu>();
				menu.setaDetalhes("responde",simOuNao,0.7f,0.4f,0.2f,0.2f);
			}
			
			switch(fase)
			{
			case faseDaConversa.perguntaAberta:
				if(acaoAlt && menu.dentroOuFora()>-1  )
					acao = true;
				
				if(acao)
					perguntaInicial();
			break;
			case faseDaConversa.porFinalisar:
				if(encontros.botoesPrincipais()){
					cJ.evento = false;
					cJ.finalisaConversa();
					cJ.mensagemAtual = 0;
					fase = faseDaConversa.perguntaAberta;
					eventoFinalisador();
				}
			break;
			}
		}
	}
}
