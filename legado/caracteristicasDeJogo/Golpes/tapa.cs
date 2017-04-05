using UnityEngine;
using System.Collections;

[System.Serializable]
public class tapa:golpe{
	public tapa()
	{
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 1;
		Corrente = 1;
		TempoReuso = 1.75f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Tapa";
		TempoNoDano = 0.25f;
		RepulsaoDoDano = 45f;
		CaracGolpe = caracGolpe.colisao;

		/*
			POR ENQUANTO IMPORTANTE PARA 
			GOLPES DE IMPACTO
		 */

		tempoMoveMin = 0.74f;
		tempoMoveMax = 1f;
		tempoDestroy = 1.2f;

		/*
			HEHEHE
		 */
	}
}

