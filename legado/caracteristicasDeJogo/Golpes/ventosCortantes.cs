using UnityEngine;
using System.Collections;

[System.Serializable]
public class ventosCortantes:golpe{
	public ventosCortantes()
	{

		Tipo = nomeTipos.Voador.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 2.9f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Ventos Cortantes";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

