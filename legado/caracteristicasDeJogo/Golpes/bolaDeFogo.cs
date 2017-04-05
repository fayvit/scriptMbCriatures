using UnityEngine;
using System.Collections;

[System.Serializable]
public class bolaDeFogo:golpe{
	public bolaDeFogo()
	{
		Tipo = nomeTipos.Fogo.ToString ();
		Basico = 2;
		Corrente = 2;
		TempoReuso = 1.2f;
		UltimoUso = -2f;
		Maximo = 8;
		Nome = "Bola De Fogo";
		DistanciaDeEmissao = 0.5f;
		CustoPE = 1;
		CaracGolpe = caracGolpe.projetil;
	}
}

