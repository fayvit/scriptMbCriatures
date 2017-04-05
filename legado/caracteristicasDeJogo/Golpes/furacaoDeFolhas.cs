using UnityEngine;
using System.Collections;

[System.Serializable]
public class furacaoDeFolhas:golpe{
	public furacaoDeFolhas()
	{

		Tipo = nomeTipos.Planta.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Furacão de Folhas";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1f;

		/*
		tipo = "rigido";
		nomeProjetil = "furacaoDeFolhas";
		impacto = "impactoDeFolhas";
		velocidadeDoAtaque = 10;
		tempoDeGolpe = 6;
		*/
	}
}

