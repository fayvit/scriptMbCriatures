using UnityEngine;
using System.Collections;

[System.Serializable]
public class gosmaDeInseto:golpe{
	public gosmaDeInseto()
	{
		
		Tipo = nomeTipos.Inseto.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Gosma de Inseto";
		DistanciaDeEmissao = 0.25f;
		CaracGolpe = caracGolpe.projetil;	
		CustoPE = 1;

		tempoMoveMax = 0.75f;
		
	}
}

