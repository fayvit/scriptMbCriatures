using UnityEngine;
using System.Collections;

[System.Serializable]
public class rajadaDeAgua:golpe{
	public rajadaDeAgua()
	{

		Tipo = nomeTipos.Agua.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Rajada De Agua";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 1;
	}
}

