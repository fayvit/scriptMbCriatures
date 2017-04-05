using UnityEngine;
using System.Collections;

[System.Serializable]
public class chute:golpe{
	public chute()
	{
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 1;
		Corrente = 1;
		TempoReuso = 1.75f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Chute";
		TempoNoDano = 0.25f;
		RepulsaoDoDano = 45f;
		CaracGolpe = caracGolpe.colisao;

		/*
			POR ENQUANTO IMPORTANTE PARA 
			GOLPES DE IMPACTO
		 */

		tempoMoveMin = 0.5f;
		tempoMoveMax = 0.75f;
		tempoDestroy = 1;

		/*
			HEHEHE
		 */
	}
}

