using UnityEngine;
using System.Collections;

[System.Serializable]
public class rajadaDeGas:golpe{
	public rajadaDeGas()
	{

		Tipo = nomeTipos.Gas.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3.2f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Rajada de Gas";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

