using UnityEngine;
using System.Collections;

[System.Serializable]
public class dentada:golpe{
	public dentada()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.75f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Dentada";
		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lançado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 0.75f;
		tempoDestroy = 1;
		
	}
}

