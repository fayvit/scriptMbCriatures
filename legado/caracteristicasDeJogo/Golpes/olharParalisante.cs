using UnityEngine;
using System.Collections;

[System.Serializable]
public class olharParalisante:golpe{
	public olharParalisante()
	{
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 1;
		Corrente = 1;
		Maximo = 2;
		TempoReuso = 7f;
		UltimoUso = -7f;
		Nome = "Olhar Paralisante";
		DistanciaDeEmissao = 0.5f;
		CustoPE = 4;

		CaracGolpe = caracGolpe.projetil;
	}
}

