using UnityEngine;
using System.Collections;

[System.Serializable]
public class Chifre:golpe{
	public Chifre()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Chifre";
		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lançado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 0.5f;
		tempoDestroy = 1;
		
	}
}

