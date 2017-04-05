using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class interiorDaPiramide: encontros {
	
	private readonly List<List<encontravel>> secaoEncontravel = new List<List<encontravel>>()
	{new List<encontravel>()// indice zero
		{
		
			new encontravel(nomesCriatures.Rocketler,  1f,    7,10,1),
			new encontravel(nomesCriatures.Cabecu,     1f,    7,10,1),
			new encontravel(nomesCriatures.Baratarab,  1.75f, 7,10,1),
			new encontravel(nomesCriatures.Escorpion,  1.47f, 7,10,1),
			new encontravel(nomesCriatures.Escorpirey, 1f,    7,10,1),
			new encontravel(nomesCriatures.Fajin,      0.5f,  7,10,1),
			new encontravel(nomesCriatures.Abutre,     0.5f,  7,10,1),
			new encontravel(nomesCriatures.Oderc,      0.5f,  7,10,1),
			new encontravel(nomesCriatures.DogMour,    1.75f, 7,10,1),
			new encontravel(nomesCriatures.Croc,       0.5f,  7,10,1),
			new encontravel(nomesCriatures.Flam,       0.01f, 7,10,1),
			new encontravel(nomesCriatures.Urkan,      0.02f, 7,10,1),
		}
	};

	new void Start()
	{
		saidas.Add(
			new saidaDeCaverna{
			cenaAlvo = "planicieDeJadme",
			posAlvo = new Vector3(902.61f,100,1161.9f),
			rotacaoAlvo = -90,
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
	
	protected override bool lugarSeguro(){
		bool seguro;
		if(
			(posHeroi.x>401.6
		 &&
		 posHeroi.x<666.82
		 &&
		 posHeroi.z>158.55
		 &&
		 posHeroi.z<310.54)
			||
			(posHeroi.x>1500
		 &&
		 posHeroi.x<1765.3
		 &&
		 posHeroi.z>184.1
		 &&
		 posHeroi.z<337)
			)
			seguro = true;
		else
			seguro = false;
		return seguro;
	}
}
