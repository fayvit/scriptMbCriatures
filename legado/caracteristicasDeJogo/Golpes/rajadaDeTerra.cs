using UnityEngine;
using System.Collections;

[System.Serializable]
public class rajadaDeTerra:golpe{
	public rajadaDeTerra()
	{

		Tipo = nomeTipos.Terra.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.7f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Rajada de Terra";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 1;

		tempoMoveMax = 1.25f;
	}

}

