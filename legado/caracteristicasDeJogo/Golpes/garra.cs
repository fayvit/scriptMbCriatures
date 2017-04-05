using UnityEngine;
using System.Collections;

[System.Serializable]
public class garra:golpe{
	public garra()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 1;
		Corrente = 1;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Garra";
		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lançado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.35f;
		tempoMoveMax = 0.5f;
		tempoDestroy = 1;
		
	}
}

