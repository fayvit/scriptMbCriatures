using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class encontroDeTreinador : encontros {
	
	private bool lutou;
	private float tempoDecorrido = 0;
	private Animator aDoTreinador;
	private faseDoEncontroTreinador fase = faseDoEncontroTreinador.iniciando;
	private animaEnvia aE;
	private animaTroca aT;
	private int indiceDoProx = 0;
	private string[] textos;

	protected Vector3 posInicialTreinador;
	protected encontros e;

	public List<encontravelTreinador> encontraveis;
	public Transform tTreinador;
	public string nomeDoTreinador;

	private enum faseDoEncontroTreinador
	{
		estadoNulo = -1,
		iniciando,
		quantosVaiUsar,
		rivalLancaCriature,
		fechaMens,
		apresentaInimigo,
		lutaIniciada,
		umaVitoriaEmLuta,
		trocandoDeCriature,
		morreuEmLuta,
		finalDaLuta
	}

	new void Start()
	{

		e = GameObject.Find("Terrain").GetComponent<encontros>();
		if(e)
			e.enabled = false;
		heroi.contraTreinador = true;
		base.Start();
		posHeroi = tHeroi.position;
		aDoTreinador = tTreinador.GetComponent<Animator>();
		posInicialTreinador = tTreinador.position;

		textos = bancoDeTextos.falacoes[heroi.lingua]["encontrosTreinador"].ToArray();
	}

	new void Update()
	{
		tempoDecorrido+=Time.deltaTime;

		switch(fase)
		{
		case faseDoEncontroTreinador.iniciando:

			iniciaEncontro();
			tempoDecorrido = 0;
			fase = faseDoEncontroTreinador.quantosVaiUsar;

		break;
		case faseDoEncontroTreinador.quantosVaiUsar:
			if(tempoDecorrido>1)
			if(!mens)
			{
				alternancia.olharEmLuta(tTreinador);
				mens = Camera.main.gameObject.AddComponent<mensagemBasica>();
				mens.mensagem = string.Format(textos[0],encontraveis.Count);
			}else
			{
				if(botoesPrincipais())
				{
					mens.fechaJanela();
					fase = faseDoEncontroTreinador.rivalLancaCriature;
					tempoDecorrido = 0;
				}
			}
		break;
		case faseDoEncontroTreinador.rivalLancaCriature:
			if(tempoDecorrido>0.15f)
			{
				mens = Camera.main.gameObject.AddComponent<mensagemBasica>();
				mens.mensagem = textos[1];
				enviaOProximo();
				fase = faseDoEncontroTreinador.fechaMens;
				tempoDecorrido = 0;
			}
		break;
		case faseDoEncontroTreinador.fechaMens:
			if(tempoDecorrido>2)
			{
				Inimigo = GameObject.Find("inimigo");
				inimigoUC = nomeieETransformEmCriature(Inimigo);
				fase = faseDoEncontroTreinador.apresentaInimigo;
				mens.fechaJanela();
			}
		break;
		case faseDoEncontroTreinador.apresentaInimigo:
			apresentaAdversario();
		break;
		case faseDoEncontroTreinador.lutaIniciada:
			if(X!= null)
				verifiqueVida();
			else
				if(GameObject.Find("CriatureAtivo"))
					X=GameObject.Find("CriatureAtivo");
		break;
		case faseDoEncontroTreinador.umaVitoriaEmLuta:
			vitoriaNaLuta();
		break;
		case faseDoEncontroTreinador.trocandoDeCriature:
			if(!aT)
			{
				mens.entrando = false;
				aDoTreinador.SetBool("envia",true);
				foiApresentado = false;
				enviaOProximo();
				tempoDecorrido = 0;
				mens.mensagem = textos[2];
				Invoke("voltaMens",0.15f);
				fase = faseDoEncontroTreinador.fechaMens;
			}
		break;
		case faseDoEncontroTreinador.morreuEmLuta:
			morreuEmLuta();
		break;
		case faseDoEncontroTreinador.finalDaLuta:
			finalDeLuta();
		break;
		}

		passoDoEncontro();
	}

	protected override void passoDePassarDeNivel()
	{
		passoDaAnimaInicial = 10;
		fase = faseDoEncontroTreinador.estadoNulo;
	}

	protected override void passoAposAMorte()
	{
		passoDaAnimaInicial = 8;
		fase = faseDoEncontroTreinador.estadoNulo;
	}

	protected override void passoDepoisDoInicio()
	{
		fase = faseDoEncontroTreinador.lutaIniciada;
		passoDaAnimaInicial = -1;
	}


	void voltaMens()
	{
		mens.entrando = true;
	}

	protected override void OPassoDepoisDaVitoria()
	{
		passoDaAnimaInicial = -1;
		if(encontraveis.Count>indiceDoProx)
		{
			apresentouFim = false;
			alternancia.olharEmLuta(tTreinador);
			fase = faseDoEncontroTreinador.trocandoDeCriature;
			mens = Camera.main.gameObject.AddComponent<mensagemBasica>();
			mens.mensagem = encontraveis[indiceDoProx-1].nome+" volte!!";
			aT = gameObject.AddComponent<animaTroca>();
			aT.alvo = "inimigo";
			aT.meuHeroi = tTreinador.gameObject;
		}else
		{
			fase = faseDoEncontroTreinador.finalDaLuta;
		}
	}

	protected virtual void finalDeLuta()
	{
		e.enabled = true;
		heroi.contraTreinador = false;
		voltarParaPasseio();
		Destroy(this);
	}

	protected override void umaVitoria()
	{
		passoDaAnimaInicial = -1;
		interrompeFluxoDeLuta();
		fase = faseDoEncontroTreinador.umaVitoriaEmLuta;
	}

	protected override void umaDerrota()
	{
		passoDaAnimaInicial = -1;
		fase = faseDoEncontroTreinador.morreuEmLuta;
		interrompeFluxoDeLuta();
	}

	protected override void bugDoNivel1()
	{
		//		print(nivelDeEncontrado);
		//if(encontraveis[indiceDoProx-1].nivelFixo>1)
		//{
			inimigoUC.X = new cCriature(encontraveis[indiceDoProx-1].nome,(uint)encontraveis[indiceDoProx-1].nivelFixo).criature();
			//inimigoUC.X.cAtributos[0].Corrente = 1;
			IA = Inimigo.AddComponent<IA_inimigo>();
			IA.remendoDeBug();
		//}
	}

	protected override void iniciaApresentaInimigo()
	{
		apresentaInimigo enemy = gameObject.AddComponent<apresentaInimigo>();

		enemy.nomeTreinador = nomeDoTreinador;
		enemy.eTreinador = true;
		
		enemy.inimigo = inimigoUC.criature();
	}

	protected override void depoisDeTerminarAApresentacao()
	{
		passoDaAnimaInicial = -1;
		comecaLuta();
		aDoTreinador.SetBool("chama",false);
		aDoTreinador.SetBool("envia",false);
	}

	void enviaOProximo()
	{
		aDoTreinador.SetBool("chama",true);
		aE = gameObject.AddComponent<animaEnvia>();
		aE.oInstanciado = encontraveis[indiceDoProx].nome;
		indiceDoProx++;
		aE.oQEnvia = tTreinador.gameObject;
		melhoraPos melhorP = new melhoraPos();
		if(indiceDoProx<=1 || !X)
			aE.posCriature = melhorP.novaPos(melhorP.posEmparedado(posHeroi+5*tHeroi.forward,tTreinador.position));
		else
			aE.posCriature = melhorP.novaPos(melhorP.posEmparedado(
				X.transform.position+5*X.transform.forward,tTreinador.position));

	}

	void colocaTreinadorRivalNaPosicaoDoEncontro()
	{
		melhoraPos melhorP = new melhoraPos();

		tTreinador.position = melhorP.novaPos(melhorP.posEmparedado(posHeroi+40*tHeroi.forward,tTreinador.position));

		tTreinador.gameObject.AddComponent<gravidadeGambiarra> ();
		
	}

	void iniciaEncontro()
	{
		animacaoDeEncontro();
		adicionaCilindroEncontro();

		
		colocaOHeroiNaPOsicaoDeEncontro();

		colocaTreinadorRivalNaPosicaoDoEncontro();

		alteraPosDoCriature();
		alternanciaParaCriature();
		
		impedeMovimentoDoCriature();
		
		luta = true;
	
	}


}

[System.Serializable]
public struct encontravelTreinador
{
	public nomesCriatures nome;
	public int nivelFixo;
	public int tipo;
	[HideInInspector]
	public bool derrotado;

	public encontravelTreinador(nomesCriatures nome,int nivel,int tipoDeEncontro)
	{
		this.nome =  nome;
		this.nivelFixo = nivel;
		this.tipo = tipoDeEncontro;
		this.derrotado = false;
	}
}