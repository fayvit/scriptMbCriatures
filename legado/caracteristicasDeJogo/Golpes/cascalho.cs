using UnityEngine;
using System.Collections;

[System.Serializable]
public class cascalho:golpe{
	public cascalho()
	{

		Tipo = nomeTipos.Pedra.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Cascalho";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 1;
	}
}

