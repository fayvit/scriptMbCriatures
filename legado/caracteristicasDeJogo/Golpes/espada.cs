using UnityEngine;
using System.Collections;

[System.Serializable]
public class espada:golpe{
	public espada()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.4f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Espada";
		TempoNoDano = 0.35f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lansado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 0.75f;
		tempoDestroy = 1f;
		
	}
}

