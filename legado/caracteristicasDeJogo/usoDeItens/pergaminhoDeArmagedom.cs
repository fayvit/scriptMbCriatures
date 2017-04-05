using UnityEngine;
using System.Collections;

public class pergaminhoDeArmagedom : pergaminhoComTransporte {

	public heroi H;
	private pretoMorte p;

	protected override void acaoDoItem()
	{
		p = gameObject.AddComponent<pretoMorte>();
		Invoke("voltaArmagedom",1);
	}

	private void voltaArmagedom()
	{
		H.devoltaParaOArmagedom();
		if(H.ultimoArmagedom.nomeCena==Application.loadedLevelName)
		{
			p.entrando = false;
			Invoke("voltaMalha",0.25f);
		}
	}

	private void voltaMalha()
	{
		SkinnedMeshRenderer[] sKs =  T.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach(SkinnedMeshRenderer sk in sKs)
			sk.enabled = true;

		T.GetComponent<CharacterController>().enabled = true;

		Destroy(GameObject.Find("CriatureAtivo"));

		T.GetComponent<movimentoBasico>().adicionaOCriature();



		movimentoBasico.retornarFluxoHeroi();


		Destroy(this);
	}


}
