using UnityEngine;
using System.Collections;

[System.Serializable]
public class eletricidadeConcentrada:golpe{
	public eletricidadeConcentrada()
	{

		Tipo = nomeTipos.Eletrico.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3.3f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Eletricidade Concentrada";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		tempoMoveMax = 4;

		CustoPE = 2;
	}
}

