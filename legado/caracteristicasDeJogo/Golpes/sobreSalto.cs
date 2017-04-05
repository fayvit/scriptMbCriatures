using UnityEngine;
using System.Collections;

[System.Serializable]
public class sobreSalto:golpe{
	public sobreSalto()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 3;
		Corrente = 3;
		TempoReuso = 1.75f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Sobre Salto";
		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lançado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 1.75f;
		tempoDestroy = 1;
		
	}
}

