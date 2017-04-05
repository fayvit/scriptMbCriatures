using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rioMariinque: encontros {
	
	private readonly List<List<encontravel>> secaoEncontravel = new List<List<encontravel>>()
	{new List<encontravel>()// indice zero
		{

			new encontravel(nomesCriatures.Arpia,  	   1.1f,  5,8,1),
			new encontravel(nomesCriatures.Estrep,     1.4f,  5,8,1),
			new encontravel(nomesCriatures.Iruin,      1.0f,  5,8,1),
			new encontravel(nomesCriatures.Escorpion,  1.5f,  5,8,1),
			new encontravel(nomesCriatures.Escorpirey, 1.25f, 5,8,1),
			new encontravel(nomesCriatures.Fajin,      1.0f,  5,8,1),
			new encontravel(nomesCriatures.Abutre,     0.5f,  5,8,1),
			new encontravel(nomesCriatures.Marak,      0.5f,  5,8,1),
			new encontravel(nomesCriatures.Babaucu,    1.5f,  5,8,1),
			new encontravel(nomesCriatures.Nedak,      0.25f, 5,8,1),

		}
	};
	
	protected override List<encontravel> listaEncontravel()
	{
		return secaoEncontravel[IndiceDoLocal()];
	}
	
	
	int IndiceDoLocal()
	{
		return 0;
	}


	protected override bool lugarSeguro(){

		bool seguro;
		if(
			(posHeroi.x>1550.5
		 &&
		 posHeroi.x<1744.8
		 &&
		 posHeroi.z>792.5
		 &&
		 posHeroi.z<903.6)

			)
			seguro = true;
		else
			seguro = false;

		return seguro;

	}
}
