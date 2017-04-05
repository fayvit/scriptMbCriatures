using UnityEngine;
using System.Collections;

public class statusTemporarioSimples : statusTemporarioBase {

	protected string nomeParticula;

	// Use this for initialization

	protected void Start () {
		
		if(oAfetado == null)
			oAfetado = GetComponent<umCriature>().X;
		
		colocaAParticulaEAdicionaEsseStatus(nomeParticula);
		
		
		
		
		//animator = GetComponent<Animator>();
		//textos = bancoDeTextos.falacoes[heroi.lingua]["status"].ToArray();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
		
		tempoAcumulado+=Time.deltaTime;
		
		if(tempoAcumulado>=tempoAteOProximoApply)
		{
			statusTemporarioBase.tiraStatus(esseStatus,oAfetado.statusTemporarios);
			destrua();
		}
		
	}
	
	public void atualizaTempoParaTroca()
	{
		tempoAteOProximoApply -= tempoAcumulado;
	}
	
	public override void destrua()
	{
		Destroy(particula.gameObject);
		Destroy(this);
	}


}
