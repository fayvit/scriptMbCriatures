//using UnityEngine;
using System.Collections;

[System.Serializable]
public class energiaDeGarras:golpe{
	public energiaDeGarras() 
	{
		Nome = "Energia de Garras";

		Tipo = nomeTipos.Normal.ToString ();
		CaracGolpe = caracGolpe.especialComParalisia;

		Basico = 10;
		Corrente = 10;
		Maximo = 20;

		TempoReuso = 20f;
		UltimoUso = -20f;

		DistanciaDeEmissao = 0.5f;

		tempoMoveMin = 1;
		tempoMoveMax = 1.5f;
		tempoDestroy = 2.5f;
		
		CustoPE = 2;
	}
}

