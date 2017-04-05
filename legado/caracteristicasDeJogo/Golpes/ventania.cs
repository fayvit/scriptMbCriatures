using UnityEngine;
using System.Collections;

[System.Serializable]
public class ventania:golpe{
	public ventania()
	{
		
		Tipo = nomeTipos.Voador.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Ventania";
		DistanciaDeEmissao = 0.75f;
		CaracGolpe = caracGolpe.projetil;	
		CustoPE = 1;

		tempoMoveMax = 0.75f;
	}
}

