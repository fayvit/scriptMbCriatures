using UnityEngine;
using System.Collections;

[System.Serializable]
public class multiplicar:golpe{
	public multiplicar()
	{

		Tipo = nomeTipos.Inseto.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 7.1f;
		UltimoUso = -7f;
		Maximo = 10;
		Nome = "Multiplicar";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 4;

		tempoDestroy = 10;

		tempoMoveMax = 1.25f;
	}
}

