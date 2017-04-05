using UnityEngine;
using System.Collections;

[System.Serializable]
public class rajadaDeFogo:golpe{
	public rajadaDeFogo()
	{

		Tipo = nomeTipos.Fogo.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 3.2f;
		UltimoUso = -2f;
		Maximo = 10;
		Nome = "Rajada de Fogo";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

