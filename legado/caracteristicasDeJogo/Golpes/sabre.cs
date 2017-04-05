using UnityEngine;
using System.Collections;

[System.Serializable]
public class sabre:golpe{
	public sabre()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Sabre";
		DistanciaDeEmissao = 1.15f;
		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lançado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 0.65f;
		tempoDestroy = 1;
		
	}
}

