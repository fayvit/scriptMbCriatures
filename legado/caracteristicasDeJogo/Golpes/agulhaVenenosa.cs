using UnityEngine;
using System.Collections;

[System.Serializable]
public class agulhaVenenosa:golpe{
	public agulhaVenenosa()
	{
		Tipo = nomeTipos.Veneno.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Agulha Venenosa";
		DistanciaDeEmissao = 0.5f;
		CustoPE = 1;

		CaracGolpe = caracGolpe.projetil;
	}
}

