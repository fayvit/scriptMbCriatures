using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class encontroDeTuto : encontros {
	
	public UnityEngine.AI.NavMeshAgent navCaesar;
	public Animator aCaesar;

	private bool encontrou;
	private bool lutou;



	protected override bool lugarSeguro()
	{
		if(encontrou && !lutou)
		{
			lutou = true;
			return false;
		}
		else
		{
			return true;
		}
	}

	protected override List<encontravel> listaEncontravel()
	{
		List<encontravel> L = new List<encontravel>(){new encontravel(nomesCriatures.Vampire,1.1f,       20,21,1)};
		return L;
	}

	void OnTriggerEnter(Collider col)
	{

		if(col.gameObject.tag == "Player" && this.enabled)
		{

			if(!encontrou)
			{
				proxEncontro = 0;
				encontrou = true;
				navCaesar.Stop();
				aCaesar.SetFloat("velocidade",0);
				aCaesar.transform.position+=40*Vector3.right;
			}
		}
	}
}
