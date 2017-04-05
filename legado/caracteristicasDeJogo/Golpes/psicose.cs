using UnityEngine;
using System.Collections;

[System.Serializable]
public class psicose:golpe{
	public psicose()
	{

		Tipo = nomeTipos.Psiquico.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Psicose";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 1;
	}
}

