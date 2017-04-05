using UnityEngine;
using System.Collections;

public class conversaDeDistancia : verificaTrocaMens {

	public Transform posCamera;
	public string chaveDaConversa;

	private Transform oEncostado;
	private bool iniciar;
	private float tempoDecorrido = 0;
	private pretoMorte p;
	private faseDaConversa fase = faseDaConversa.iniciando;


	private enum faseDaConversa
	{
		iniciando,
		mensagemAberta,
	}

	// Use this for initialization
	void Start () {
		essaConversa = bancoDeTextos.falacoes[heroi.lingua][chaveDaConversa].ToArray();
	}
	
	// Update is called once per frame
	void Update () {

		if(iniciar)
		{

			tempoDecorrido+=Time.deltaTime;

			switch(fase)
			{
			case faseDaConversa.iniciando:
				if(tempoDecorrido>1)
				{
					Camera.main.transform.position = posCamera.position;
					Camera.main.transform.rotation = posCamera.rotation;
					oEncostado.position = transform.position+6*transform.forward;
					fase = faseDaConversa.mensagemAberta;
					mens = Camera.main.gameObject.AddComponent<mensagemBasica>();
					mens.mensagem = essaConversa[0];
					p.entrando = false;
				}
			break;
			case faseDaConversa.mensagemAberta:
				if(encontros.botoesPrincipais())
				{
					facaTrocaMens();
				}
			break;
			}
		}
	
	}

	public override void finalisaConversa()
	{
		movimentoBasico.retornarFluxoHeroi();
		mens.fechaJanela();
		iniciar = false;
		fase = faseDaConversa.iniciando;
		mensagemAtual = 0;
		tempoDecorrido = 0;
	}

	void OnTriggerEnter(Collider col)
	{
		if(!heroi.emLuta)
		{
			if(col.tag == "Player" )
			{
				iniciar = true;
				movimentoBasico.pararFluxoHeroi();
				p = gameObject.AddComponent<pretoMorte>();
				oEncostado = col.transform;
			}

			if(col.tag=="Criature")
				mudeCena.evitaCriatureAvancarNoTrigger(col);
		}
	}
}
