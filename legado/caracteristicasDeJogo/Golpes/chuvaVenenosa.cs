using UnityEngine;
using System.Collections;

[System.Serializable]
public class chuvaVenenosa:golpe{
	public chuvaVenenosa()
	{

		Tipo = nomeTipos.Veneno.ToString ();
		Basico = 7;
		Corrente = 7;
		TempoReuso = 7f;
		UltimoUso = -7f;
		Maximo = 14;
		Nome = "Chuva Venenosa";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.colisao;
		CustoPE = 3;

		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f;

		tempoMoveMin = 0.15f;
		tempoMoveMax = 1.25f;

	}
}

