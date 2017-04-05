using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class conversaComMalucoDosInsetosFora : conversaComAramisFora {

	protected override void iniciandoContraTreinador()
	{
		iniciaLutaContraOMaluco(gameObject,transform);
	}
	
	public static void iniciaLutaContraOMaluco(GameObject G,Transform T)
	{
		encontroDeTreinador edT = G.AddComponent<lutaContraMalucoDosInsetos>();
		edT.encontraveis = new List<encontravelTreinador>()
		{
			new encontravelTreinador(nomesCriatures.Iruin,10,1),
			new encontravelTreinador(nomesCriatures.Izicuolo,10,1),
			new encontravelTreinador(nomesCriatures.Baratarab,10,1),
			new encontravelTreinador(nomesCriatures.Escorpion,10,1)
		};
		edT.tTreinador = T;
		edT.nomeDoTreinador = "Maluco dos Insetos";
	}
}
