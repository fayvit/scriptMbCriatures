using UnityEngine;
using System.Collections;

[System.Serializable]
public class bombaDeGas:golpe{
	public bombaDeGas()
	{
		Tipo = nomeTipos.Gas.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Bomba de Gas";
		DistanciaDeEmissao = 0.5f;
		CustoPE = 1;
		CaracGolpe = caracGolpe.projetil;

		/*
		tipo = "basico";
		nomeProjetil = "bombaDeGas";
		impacto = "impactoDeGas";
		velocidadeDoAtaque = 14;
		*/
	}
}

