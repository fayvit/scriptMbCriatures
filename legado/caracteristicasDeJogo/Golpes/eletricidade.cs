using UnityEngine;
using System.Collections;

[System.Serializable]
public class eletricidade:golpe{
	public eletricidade()
	{

		Tipo = nomeTipos.Eletrico.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Eletricidade";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 1;
		tempoMoveMax = 2;
	}
}

