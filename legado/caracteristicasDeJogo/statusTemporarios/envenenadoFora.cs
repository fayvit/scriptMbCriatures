using UnityEngine;
using System.Collections;

public class envenenadoFora : envenenado {

	private movimentoBasico mB;

	// Use this for initialization
	void Start () {

		mB = GameObject.FindWithTag("Player").GetComponent<movimentoBasico>();
		esseStatus = tipoStatus.envenenado;
		textos = bancoDeTextos.falacoes[heroi.lingua]["status"].ToArray();
	}

	void informaQueMoreu()
	{
		mensagemEmLuta mL = Camera.main.gameObject.GetComponent<mensagemEmLuta>();
		
		if(mL)
			mL.fechador();
		
		mL = Camera.main.gameObject.AddComponent<mensagemEmLuta>();

		mL.mensagem = string.Format(textos[0],oAfetado.Nome);

		Destroy(this);

	}
	
	protected override void daDano()
	{
		if(!heroi.emLuta && mB.enabled && mB.podeAndar)
		{
			mensagemDeAplicaDanoEnvenenado("CriatureAtivo");
			acaoDeGolpe.aplicaDano(oAfetado,(int)forcaDoDano);
			if(oAfetado.cAtributos[0].Corrente<=0)
			{
				Invoke("informaQueMoreu",1);
			}

			tempoAcumulado = 0;
		}else
		{
			tempoAcumulado = 0;
		}
	}
}
