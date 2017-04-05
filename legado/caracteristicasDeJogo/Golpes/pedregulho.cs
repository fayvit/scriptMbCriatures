using UnityEngine;
using System.Collections;

[System.Serializable]
public class pedregulho:golpe{
	public pedregulho()
	{

		Tipo = nomeTipos.Pedra.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3.4f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Pedregulho";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

