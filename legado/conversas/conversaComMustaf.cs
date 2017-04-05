using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class conversaComMustaf : conversaEmJogo {

	public Transform posCam1;
	public Transform tConversador;
	public Transform posCam2;

	public string variavelChave;



	private readonly Dictionary<int,string> trocaTitulo = new Dictionary<int, string>()
	{
		{1,"\t\t\t <color=cyan>Cesar Corean</color>"},
		{2,""},
		{3,"\t\t Mustaf Aefik"},
		{4,"\t\t\t <color=cyan>Cesar Corean</color>"},
		{5,"\t\t Mustaf Aefik"},
		{8,"\t\t\t <color=cyan>Cesar Corean</color>"},
		{9,"\t\t Mustaf Aefik"}
	};

	
	protected pretoMorte p;
	private faseDaConversa fase;
	protected Animator aHeroi;
	protected Transform tCam;
	protected encontros e;

	protected float tempoDecorrido = 0;

	protected enum faseDaConversa
	{
		iniciando,
		aproximandoDoMustaf,
		aumentandoNeblina,
		diminuindoNeblina
	}

	// Use this for initialization
	void Start () {
		essaConversa = bancoDeTextos.falacoes[heroi.lingua][indiceDaConversa].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if(iniciou)
		{
			tempoDecorrido+=Time.deltaTime;

			switch(fase)
			{
			case faseDaConversa.iniciando:
				if(tempoDecorrido>2)
				{
					tCam.position = posCam1.position;
					tCam.rotation = posCam1.rotation;
					p.entrando = false;
					fase = faseDaConversa.aproximandoDoMustaf;
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
					mens.fechaJanela();
					fase = faseDaConversa.aumentandoNeblina;
				}
			break;
			case faseDaConversa.aumentandoNeblina:
				aHeroi.SetFloat("velocidade",0);
				RenderSettings.fogStartDistance = Mathf.Lerp(RenderSettings.fogStartDistance,1,Time.deltaTime);
				RenderSettings.fogEndDistance = Mathf.Lerp(RenderSettings.fogEndDistance,2,Time.deltaTime);
				if(Mathf.Abs(RenderSettings.fogStartDistance-1)<0.1f &&Mathf.Abs(RenderSettings.fogEndDistance-2)<0.1f)
				{
					fase = faseDaConversa.diminuindoNeblina;
					tConversador.gameObject.SetActive(false);
				}
			break;
			case faseDaConversa.diminuindoNeblina:
				RenderSettings.fogStartDistance = Mathf.Lerp(RenderSettings.fogStartDistance,10,Time.deltaTime);
				RenderSettings.fogEndDistance = Mathf.Lerp(RenderSettings.fogEndDistance,40,Time.deltaTime);
				if(Mathf.Abs(RenderSettings.fogStartDistance-10)<0.1f &&Mathf.Abs(RenderSettings.fogEndDistance-40)<0.1f)
				{
					e.enabled = true;
					movimentoBasico.retornarFluxoHeroi();
					iniciou = false;
					fase = faseDaConversa.iniciando;
				}
			break;
			}
		}
	
	}

	protected void verificaTrocaTitulo(Dictionary<int,string> trocaTitulo)
	{
		if(trocaTitulo.ContainsKey(mensagemAtual))
		{
			mens.title = trocaTitulo[mensagemAtual];
		}
	}

	protected void cameraLerp(Transform novaPos)
	{
		if(Vector3.Distance(tCam.position,novaPos.position)>0.1f)
		{
			tCam.position = Vector3.Lerp(tCam.position,novaPos.position,Time.deltaTime);
			tCam.rotation = Quaternion.Lerp(tCam.rotation,novaPos.rotation,Time.deltaTime);
		}
	}

	protected void CoreanAndaParaPerto()
	{
		if(Vector3.Distance(tHeroi.position,tConversador.position)>4.5f)
			aHeroi.SetFloat("velocidade",0.9f);
		else
			aHeroi.SetFloat("velocidade",0);
	}



	protected void preparaIniciaConversa()
	{
		e = GameObject.Find("Terrain").GetComponent<encontros>();
		if(e)
			e.enabled = false;
		movimentoBasico.pararFluxoHeroi();
		p = gameObject.AddComponent<pretoMorte>();
		tCam = Camera.main.transform;
		tHeroi = GameObject.FindWithTag("Player").transform;
		aHeroi = tHeroi.GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(variaveisChave.shift[variavelChave])
			Destroy(gameObject);
		else
		{
			if(!iniciou && col.tag == "Player")
			{
				preparaIniciaConversa();
				Collider esseCol = GetComponent<Collider>();
				esseCol.enabled = false;
				esseCol.isTrigger = false;
				iniciou = true;
				variaveisChave.shift[variavelChave] = true;
			}else if(!iniciou && col.tag == "Criature" && !heroi.emLuta)
			{
				alternancia a  = col.GetComponent<alternancia>();
				if(a)
					a.retornaAoHeroi();
			}
		}

	}
}
