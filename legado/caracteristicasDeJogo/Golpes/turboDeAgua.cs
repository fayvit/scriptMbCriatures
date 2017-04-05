using UnityEngine;
using System.Collections;

[System.Serializable]
public class turboDeAgua:golpe{
	public turboDeAgua()
	{

		Tipo = nomeTipos.Agua.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3.1f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Turbo De Agua";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

