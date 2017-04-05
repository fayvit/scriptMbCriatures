using UnityEngine;
using System.Collections;

public class abreCanoDeEsgoto : eventoComGolpe {

	public string chaveDoCano;
	public GameObject aSerDestruido;
	public Transform pos1Camera;
	public MeshCollider meshTransporte;

	private pretoMorte p;
	private bool iniciou = false;
	private float contadorDeTempo = 0;
	private faseDaAnima fase = faseDaAnima.iniciando;
	private Transform tCamera;
	private movimentoBasico mBcri;

	private enum faseDaAnima
	{
		iniciando,
		colocaParticulas,
		destruaAsBarras,
		retornaMovimento
	}

	// Use this for initialization
	void Start () {
		if(variaveisChave.shift[chaveDoCano])
		{

			if(aSerDestruido)
				Destroy(aSerDestruido);

			/*
				O a ser destruido tambem tem esse script
				o ativa trigger esta abaixo para nao ser chamado no aSerDestruido
				so ser chamado no tudo do esgoto
			 */

			ativaTriggerTransporte();

			Destroy(this);
		}
	
	}

	public static void posicionaCamera(Transform tCamera,Vector3 pos,Quaternion Q,pretoMorte p,
	                                   out float t)
	{
		tCamera.position = pos;
		tCamera.rotation = Q;
		p.entrando = false;
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(iniciou)
		{
			contadorDeTempo+=Time.deltaTime;

			switch(fase)
			{
			case faseDaAnima.iniciando:
				if(contadorDeTempo>2)
				{
					posicionaCamera(tCamera,pos1Camera.position,pos1Camera.rotation,p,out contadorDeTempo);
					fase = faseDaAnima.colocaParticulas;
				}
			break;
			case faseDaAnima.colocaParticulas:
				if(contadorDeTempo>1)
				{
					Destroy(
					Instantiate(
						elementosDoJogo.el.retorna("particulasDoCano"),
						aSerDestruido.transform.position,
						Quaternion.identity),2.5f);

					contadorDeTempo = 0;
					fase = faseDaAnima.destruaAsBarras;
				}
			break;
			case faseDaAnima.destruaAsBarras:
				if(contadorDeTempo>2.5)
				{
					ativaTriggerTransporte();
					variaveisChave.shift[chaveDoCano] = true;
					aSerDestruido.GetComponent<MeshRenderer>().enabled = false;
					fase = faseDaAnima.retornaMovimento;
					contadorDeTempo = 0;
				}
			break;
			case faseDaAnima.retornaMovimento:
				if(contadorDeTempo>1f)
				{
					movimentoBasico.retornaFluxoCriature();
					Destroy(aSerDestruido);
					Destroy(this);
				}
			break;
			}
		}
	
	}

	void ativaTriggerTransporte()
	{
		meshTransporte.enabled = true;
	}

	public override void disparaEvento(nomesGolpes nomeDoGolpe)
	{

		if((nomeDoGolpe==nomesGolpes.sabreDeAsa
		   ||
		   nomeDoGolpe==nomesGolpes.sabreDeBastao
		   ||
		   nomeDoGolpe==nomesGolpes.sabreDeEspada
		   ||
		   nomeDoGolpe==nomesGolpes.sabreDeNadadeira
		   )
		   &&
		   !variaveisChave.shift[chaveDoCano]
		   &&
		   !heroi.emLuta
		   )
		{
			mBcri = GameObject.Find("CriatureAtivo").GetComponent<movimentoBasico>();
			mBcri.enabled = false;
			alternancia.focandoHeroi();
			movimentoBasico.pararFluxoCriature();
			movimentoBasico.pararFluxoHeroi();
			tCamera = Camera.main.transform;
			p = gameObject.AddComponent<pretoMorte>();
			iniciou = true;
		}else if(variaveisChave.shift[chaveDoCano])
			Destroy(this);
	}
}
