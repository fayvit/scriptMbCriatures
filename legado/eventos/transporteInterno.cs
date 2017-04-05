using UnityEngine;
using System.Collections;

public class transporteInterno : MonoBehaviour {

	public Vector3 posAlvo;
	public Color corDoFade = Color.black;
	public int rotacaoAlvo = 1;

	private bool iniciou = false;
	private faseDoTransporte fase;
	private pretoMorte p;
	private float tempoDeCorrido = 0;
	private Transform T;

	private movimentoBasico mB;
	private encontros e;

	private enum faseDoTransporte
	{
		iniciando,
		retornando
	}
	// Use this for initialization
	protected void Start () {
		e = GameObject.Find("Terrain").GetComponent<encontros>();
	}

	protected virtual void iniciandoTransporte()
	{
		p.entrando = false;
		T.position = posAlvo;
		if(rotacaoAlvo!=1)
			T.rotation = Quaternion.Euler(0,rotacaoAlvo,0);



		movimentoBasico.pararFluxoHeroi(true,false);
		fase = faseDoTransporte.retornando;
		tempoDeCorrido = 0;
		Destroy(GameObject.Find("CriatureAtivo"));
		T.GetComponent<movimentoBasico>().adicionaOCriature();

		if(e)
		{
			e.zeraPosAnterior();
			e.enabled = true;
		}
	}

	protected virtual void terminandoOTransporte()
	{
		movimentoBasico.retornarFluxoHeroi();
		iniciou = false;
		fase = faseDoTransporte.iniciando;
		tempoDeCorrido = 0;
	}
	
	// Update is called once per frame
	protected void Update () {
		if(iniciou)
			{
			tempoDeCorrido+=Time.deltaTime;

			switch(fase)
			{
			case faseDoTransporte.iniciando:
				if(tempoDeCorrido>1.5f)
				{
					if(e)
						e.enabled = false;
					iniciandoTransporte();
				}
			break;
			case faseDoTransporte.retornando:
				if(tempoDeCorrido>1)
				{
					terminandoOTransporte();
				}
			break;
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag=="Player" && !heroi.emLuta  && !iniciou)
		{
			iniciou = true;
			if(e)
				e.enabled = false;
			movimentoBasico.pararFluxoHeroi(true,false,true,false);
			p = gameObject.AddComponent<pretoMorte>();
			p.cor = corDoFade;
			T = col.transform;
		}

		if(col.tag=="Criature" && !heroi.emLuta)
		{
			mudeCena.evitaCriatureAvancarNoTrigger(col);
		}
	}
}
