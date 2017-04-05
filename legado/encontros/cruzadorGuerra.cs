using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cruzadorGuerra: encontros {
	
	private readonly List<List<encontravel>> secaoEncontravel = new List<List<encontravel>>()
	{new List<encontravel>()// indice zero
		{
			new encontravel(nomesCriatures.Marak,      1f,    7,10,1),
			new encontravel(nomesCriatures.Cabecu,     1f,    7,10,1),
			new encontravel(nomesCriatures.Baratarab,  1.75f, 7,10,1),
			new encontravel(nomesCriatures.Escorpion,  1.47f, 7,10,1),
			new encontravel(nomesCriatures.Escorpirey, 1f,    7,10,1),
			new encontravel(nomesCriatures.Fajin,      0.5f,  7,10,1),
			new encontravel(nomesCriatures.Aladegg,    0.5f,  7,10,1),
			new encontravel(nomesCriatures.Oderc,      0.5f,  7,10,1),
			new encontravel(nomesCriatures.Babaucu,    1.75f, 7,10,1),
			new encontravel(nomesCriatures.Iruin,      0.5f,  7,10,1),
			new encontravel(nomesCriatures.Flam,       0.01f, 7,10,1),
			new encontravel(nomesCriatures.Urkan,      0.02f, 7,10,1),
			new encontravel(nomesCriatures.Nedak,      0.02f, 7,10,1),
			new encontravel(nomesCriatures.Nessei,     0.02f, 7,10,1),
		}
	};

	new void Start()
	{
		saidas.Add(
			new saidaDeCaverna{
			cenaAlvo = "rioMariinque",
			posAlvo = new Vector3(1170.69f,50.93f,819.26f),
			rotacaoAlvo = 0,
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
			(posHeroi.x>3529.8
		 &&
		 posHeroi.x<3608.3
		 &&
		 posHeroi.z>3473.2
		 &&
		 posHeroi.z<3528.9)
			||
			(posHeroi.x>2685
		 &&
		 posHeroi.x<2755
		 &&
		 posHeroi.z>2500
		 &&
		 posHeroi.z<2566.8)
			||
			(
			posHeroi.x<2680
			&&
			posHeroi.z<2120
			&&
			posHeroi.x>2620
			&&
			posHeroi.z>2078
			)
		)
			seguro = true;
		else
			seguro = false;
		return seguro;
	}
}
