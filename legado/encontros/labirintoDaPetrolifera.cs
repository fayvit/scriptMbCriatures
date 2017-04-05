using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class labirintoDaPetrolifera: encontros {
	
	private readonly List<List<encontravel>> secaoEncontravel = new List<List<encontravel>>()
	{new List<encontravel>()// indice zero
		{
		
			new encontravel(nomesCriatures.Izicuolo,    1f,    7,10,1),
			new encontravel(nomesCriatures.Wisks,       1f,    7,10,1),
			new encontravel(nomesCriatures.Baratarab,   1.75f, 7,10,1),
			new encontravel(nomesCriatures.Escorpion,   1.47f, 7,10,1),
			new encontravel(nomesCriatures.Escorpirey,  1f,    7,10,1),
			new encontravel(nomesCriatures.Fajin,       0.5f,  7,10,1),
			new encontravel(nomesCriatures.Abutre,      0.5f,  7,10,1),
			new encontravel(nomesCriatures.Serpente,    0.5f,  7,10,1),
			new encontravel(nomesCriatures.Iruin,       1.75f, 7,10,1),
			new encontravel(nomesCriatures.Marak,       0.5f,  7,10,1),
			new encontravel(nomesCriatures.Xuash,       0.01f, 7,10,1),
			new encontravel(nomesCriatures.PolyCharm,   0.02f, 7,10,1),
		}
	};

	new void Start()
	{
		saidas.Add(
			new saidaDeCaverna{
			cenaAlvo = "rioMariinque",
			posAlvo = new Vector3(2531f,62.55f,1127.2f),
			rotacaoAlvo = 90,
			entreiPorAqui = true
		}
			);


		base.Start();
	}
	
	protected override List<encontravel> listaEncontravel()
	{
		return secaoEncontravel[IndiceDoLocal()];
	}
	
	
	int IndiceDoLocal()
	{
		return 0;
	}
	
	protected override bool lugarSeguro(){// Perto dos NPC nao ter encontros

		bool seguro;
		if(
			(posHeroi.x>573
		 &&
		 posHeroi.x<645.1
		 &&
		 posHeroi.z>1130
		 &&
		 posHeroi.z<1190)
			||
			(posHeroi.x>731.4
		 &&
		 posHeroi.x<805.4
		 &&
		 posHeroi.z>727
		 &&
		 posHeroi.z<773)
			)
			seguro = true;
		else
			seguro = false;
		return seguro;
	}
}
