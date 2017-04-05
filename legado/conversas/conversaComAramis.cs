using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class conversaComAramis : conversaComMustaf {
	
	protected Dictionary<int,string> trocaTitulo = new Dictionary<int, string>()
	{
		{1,"\t\t\t <color=cyan>Cesar Corean</color>"},
		{2,""},
		{3,"\t\t\t <color=cyan>Cesar Corean</color>"},
		{5,"\t\t Atos Aramis"}
	};

	private Menu menu;

	private faseDaConversa estado = faseDaConversa.iniciando;

	protected enum faseDaConversa
	{
		iniciando,
		aproximandoDoMustaf,
		respostaDeConfornto
	}

	// Use this for initialization
	protected virtual void Start () {
		essaConversa = bancoDeTextos.falacoes[heroi.lingua][indiceDaConversa].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if(iniciou)
		{
			tempoDecorrido+=Time.deltaTime;

			switch(estado)
			{
			case faseDaConversa.iniciando:
				if(tempoDecorrido>2)
				{
					tCam.position = posCam1.position;
					tCam.rotation = posCam1.rotation;
					p.entrando = false;
					estado = faseDaConversa.aproximandoDoMustaf;
					tHeroi.LookAt(tConversador,Vector3.up);
					mens = tCam.gameObject.AddComponent<mensagemBasica>();
					mens.mensagem = essaConversa[0];

				}
			break;
			case faseDaConversa.aproximandoDoMustaf:
				CoreanAndaParaPerto();
				cameraLerp(posCam2);
				if(mensagemAtual+1<essaConversa.Length)
				{
					facaTrocaMens();
					verificaTrocaTitulo(trocaTitulo);
				}else
				{
					facaTrocaMens();
					estado = faseDaConversa.respostaDeConfornto;
					menu = tCam.gameObject.AddComponent<Menu>();
					menu.setaDetalhes("somOuNaoAramis",
					                  bancoDeTextos.falacoes[heroi.lingua]["simOuNao"].ToArray(),
					                  0.7f,0.4f,0.25f,0.2f);
				}
			break;
			case faseDaConversa.respostaDeConfornto:

				bool acao = Input.GetButtonDown("acao");
				if(Input.GetButtonDown("acaoAlt"))
					if(menu.dentroOuFora()>-1)
						acao = true;


				if(acao)
				{
					if(menu.escolha == 0)// isso e um sim
					{
						iniciaLutaComTreinador();
						encerraEste();

					}else
					{
						if(e)
							e.enabled = true;
						movimentoBasico.retornarFluxoHeroi();

						encerraEste();
					}
				}
				aHeroi.SetFloat("velocidade",0);

			break;
			}
		}
	
	}

	protected virtual void iniciaLutaComTreinador()
	{
		conversaComAramisFora.iniciaLutaContraAramis(gameObject,tConversador);
	}

	void encerraEste()
	{
		iniciou = false;
		estado = faseDaConversa.iniciando;
		mens.fechaJanela();
		menu.fechaJanela();
	}
}
