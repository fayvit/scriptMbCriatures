using UnityEngine;
using System.Collections;

[System.Serializable]
public class laminaDeFolha:golpe{

	public laminaDeFolha()
	{
		
		Tipo = nomeTipos.Planta.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Lamina De Folha";
		DistanciaDeEmissao = 2.25f;
		CaracGolpe = caracGolpe.projetil;	
		CustoPE = 1;
		tempoMoveMax = 0.75f;

		/*
		tipo = "basico";
		nomeProjetil = "laminaDeFolha";
		impacto = "impactoDeFolhas";
		velocidadeDoAtaque = 14;
		*/
	}

}

