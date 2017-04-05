using UnityEngine;
using System.Collections;

[System.Serializable]
public class olharMal:golpe{
	public olharMal()
	{
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 1;
		Corrente = 1;
		Maximo = 8;
		TempoReuso = 7f;
		UltimoUso = -7f;
		Nome = "Olhar Mal";
		DistanciaDeEmissao = 0.5f;
		CustoPE = 4;

		CaracGolpe = caracGolpe.projetil;
	}
}

