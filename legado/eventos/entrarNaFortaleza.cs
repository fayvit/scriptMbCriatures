using UnityEngine;
using System.Collections;

public class entrarNaFortaleza : MonoBehaviour {

	public int indiceDoEvento = -1;
	public Transform portaL;
	public Transform portaR;
	public Transform posCameraFortaleza;
	public Collider meshTransporte;

	private bool podeEventar = false;
	private float tempoDecorrido = 0;
	private GameObject gHeroi;
	private conversaEmJogo cJ;
	private heroi H;
	private pretoMorte p;
	private faseDaEntrada fase = faseDaEntrada.iniciando;


	private enum faseDaEntrada
	{
		iniciando,
		falaAberta,
		escurecendo,
		clareando

	}



	// Use this for initialization
	void Start () {
		cJ = GetComponent<conversaEmJogo>();
		gHeroi = GameObject.FindWithTag("Player");
		H = gHeroi.GetComponent<heroi>();

		if(shopBasico.temItem(nomeIDitem.condecoracaoAlpha,H)>-1
		   &&
		   shopBasico.temItem(nomeIDitem.condecoracaoBeta,H)>-1)
		{
			cJ.atualizaIndiceDeConversa("guardaFortalezaComAsCondecoracoes");
			podeEventar = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(podeEventar
		   &&
		   cJ.mensagemAtual == indiceDoEvento)
		{
			switch(fase)
			{
			case faseDaEntrada.iniciando:
				cJ.evento = true;
				fase =  faseDaEntrada.falaAberta;
			break;
			case faseDaEntrada.falaAberta:
				if(encontros.botoesPrincipais())
				{
					cJ.mens.entrando = false;
					fase = faseDaEntrada.escurecendo;
					p = gameObject.AddComponent<pretoMorte>();
					tempoDecorrido = 0;
				}
			break;
			case faseDaEntrada.escurecendo:
				tempoDecorrido+=Time.deltaTime;
				if(tempoDecorrido>1)
				{
					movimentoBasico.pararFluxoHeroi();
					Camera.main.transform.position = posCameraFortaleza.position;
					Camera.main.transform.rotation = posCameraFortaleza.rotation;
					fase = faseDaEntrada.clareando;
					p.entrando = false;
					tempoDecorrido = 0;
				}
			break;
			case faseDaEntrada.clareando:
				tempoDecorrido+=Time.deltaTime;
				if(tempoDecorrido>0.5f && tempoDecorrido<4)
				{
					portaL.position+=Vector3.right*2*Time.deltaTime;
					portaR.position-=Vector3.right*2*Time.deltaTime;

					if((int)(100*tempoDecorrido)%1==0)
					{
						for(int i=0;i<10;i++)
						{
							Destroy(
							Instantiate(
								elementosDoJogo.el.retorna("poeiraAoVento"),
								portaL.position-3.5f*Vector3.up+(i-6)*Vector3.right,
								Quaternion.identity
								),2);

							Destroy(
							Instantiate(
								elementosDoJogo.el.retorna("poeiraAoVento"),
								portaR.position-3.5f*Vector3.up+(i-6)*Vector3.right,
								Quaternion.identity
								),2);
						}
					}				
				}else if(tempoDecorrido>=4)
				{
					cJ.finalisaConversa();
					meshTransporte.enabled = true;
					cJ.evento = false;
					cJ.atualizaIndiceDeConversa("portaFortalezaAberta");
					movimentoBasico.retornarFluxoHeroi();
					podeEventar = false;
				}

			break;

			}
		}
	}
}
