using UnityEngine;
using System.Collections;

[System.Serializable]
public class cortinaDeTerra:golpe{
	public cortinaDeTerra()
	{

		Tipo = nomeTipos.Terra.ToString ();
		Basico = 7;
		Corrente = 7;
		TempoReuso = 7f;
		UltimoUso = -7f;
		Maximo = 14;
		Nome = "Cortina de Terra";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.hitNoChao;
		CustoPE = 3;

		TempoNoDano = 0.75f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f;


		tempoMoveMin = 2;
		tempoMoveMax = 2.25f;
	}
}

