using UnityEngine;
using System.Collections;

[System.Serializable]
public class sobreVoo:golpe{
	public sobreVoo()
	{

		Tipo = nomeTipos.Voador.ToString ();
		Basico = 7;
		Corrente = 7;
		TempoReuso = 7f;
		UltimoUso = -7f;
		Maximo = 14;
		Nome = "Sobre Voo";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.colisaoComPow;
		CustoPE = 1;

		TempoNoDano = 0.75f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 85f;


		tempoMoveMin = 1f;
		tempoMoveMax = 1.75f;
		tempoDestroy = 2.35f;
	}
}

