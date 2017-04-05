using UnityEngine;
using System.Collections;

[System.Serializable]
public class gosmaAcida:golpe{
	public gosmaAcida()
	{

		Tipo = nomeTipos.Inseto.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 2.5f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Gosma Acida";
		DistanciaDeEmissao = 0.25f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

