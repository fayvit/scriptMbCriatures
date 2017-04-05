using UnityEngine;
using System.Collections;

[System.Serializable]
public class anelDoOlhar:golpe{
	public anelDoOlhar()
	{

		Tipo = nomeTipos.Normal.ToString ();
		Basico = 8;
		Corrente = 8;
		TempoReuso = 5.3f;
		UltimoUso = -5.3f;
		Maximo = 16;
		Nome = "Anel do Olhar";
		DistanciaDeEmissao = 0.5f;
		CaracGolpe = caracGolpe.projetil;
		CustoPE = 2;

		tempoMoveMax = 1.25f;
	}
}

