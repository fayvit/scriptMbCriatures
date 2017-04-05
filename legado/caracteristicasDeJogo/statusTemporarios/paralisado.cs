using UnityEngine;
using System.Collections;

public class paralisado : statusTemporarioSimples
{
	// Use this for initialization
	new void Start ()
	{
	
		esseStatus = tipoStatus.paralisado;

		nomeParticula =  "particulasParalisado";

		base.Start();	


	}
}
