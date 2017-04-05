using UnityEngine;
using System.Collections;

[System.Serializable]
public class ondaVenenosa:golpe{
	public ondaVenenosa()
	{

		Tipo = nomeTipos.Veneno.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Onda Venenosa";
		DistanciaDeEmissao = 0.75f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

