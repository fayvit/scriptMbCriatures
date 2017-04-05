using UnityEngine;
using System.Collections;

[System.Serializable]
public class chicoteDeMao:golpe{
	public chicoteDeMao()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 1;
		Corrente = 1;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Chicote de Mão";
		TempoNoDano = 0.35f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lansado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 0.75f;
		tempoDestroy = 1f;
		
	}
}

