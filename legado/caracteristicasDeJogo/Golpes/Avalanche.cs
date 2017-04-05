using UnityEngine;
using System.Collections;

[System.Serializable]
public class Avalanche:golpe{
	public Avalanche()
	{

		Tipo = nomeTipos.Pedra.ToString ();
		Basico = 7;
		Corrente = 7;
		TempoReuso = 7f;
		UltimoUso = -7f;
		Maximo = 14;
		Nome = "Avalanche";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.colisao;
		CustoPE = 3;

		TempoNoDano = 0.75f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f;

		tempoMoveMax = 1.25f;
	}
}

