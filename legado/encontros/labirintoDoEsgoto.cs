using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class labirintoDoEsgoto: encontros {

	private readonly List<List<encontravel>> secaoEncontravel = new List<List<encontravel>>()
	{new List<encontravel>()// indice zero
		{
			new encontravel(nomesCriatures.Estrep,    1f,    7,10,1),
		/*
			new encontravel(nomesCriatures.Izicuolo,    1f,    9,13,1),
			new encontravel(nomesCriatures.Cabecu,      1f,    9,13,1),
			new encontravel(nomesCriatures.Baratarab,   1.75f, 9,13,1),
			new encontravel(nomesCriatures.Escorpion,   1.47f, 9,13,1),
			new encontravel(nomesCriatures.Escorpirey,  1f,    9,13,1),
			new encontravel(nomesCriatures.Oderc,       0.5f,  9,13,1),
			new encontravel(nomesCriatures.Abutre,      0.5f,  9,13,1),
			new encontravel(nomesCriatures.Cracler,     0.5f,  9,13,1),
			new encontravel(nomesCriatures.Iruin,       1.75f, 9,13,1),
			new encontravel(nomesCriatures.Babaucu,     0.5f,  9,13,1),
			new encontravel(nomesCriatures.Rocketler,   0.02f, 9,13,1),
			new encontravel(nomesCriatures.Flam,        0.01f, 9,13,1),*/

		}
	};

	public static void entreiPor(List<saidaDeCaverna> verifiqueSaida,Vector3 V)
	{
			int entreiPelaSaida = 0;
			float ultimaDistancia = Vector3.Distance(verifiqueSaida[0].entrada,V);
			for(int i=1;i < verifiqueSaida.Count;i++)
			{
				if(Vector3.Distance(verifiqueSaida[i].entrada,V)<ultimaDistancia)
				{
					ultimaDistancia = Vector3.Distance(verifiqueSaida[i].entrada,V);
					entreiPelaSaida = i;
				}
			}



			verifiqueSaida[entreiPelaSaida] = 
			new saidaDeCaverna{
				cenaAlvo = verifiqueSaida[entreiPelaSaida].cenaAlvo,
				posAlvo = verifiqueSaida[entreiPelaSaida].posAlvo,
				rotacaoAlvo = verifiqueSaida[entreiPelaSaida].rotacaoAlvo,
				entreiPorAqui = true,
				entrada = verifiqueSaida[entreiPelaSaida].entrada
			};


			heroi.ondeEntrei = new entreiPor(Application.loadedLevelName,V);



	}

	new void Start()
	{
		saidas = new List<saidaDeCaverna>(){

			new saidaDeCaverna{
				cenaAlvo = "planicieDeJadme",
				posAlvo = new Vector3(1720f,103.57f,957),
				rotacaoAlvo = -90,
				entreiPorAqui = false,
				entrada = new Vector3(2541,773,1289)
			},
			new saidaDeCaverna{
				cenaAlvo = "planicieDeInfinity",
				posAlvo = new Vector3(-799f,3.97f,2464.2f),
				rotacaoAlvo = 90,
				entreiPorAqui = false,
				entrada = new Vector3(1861,773,1920)
			},
			new saidaDeCaverna{
				cenaAlvo = "rioMariinque",
				posAlvo = new Vector3(1644.8f,0.35f,1300),
				rotacaoAlvo = 180,
				entreiPorAqui = false,
				entrada = new Vector3(2077,773,2724)
			}};


		base.Start();

		Invoke("verifiqueEntrada",0.1f);


	}

	void verifiqueEntrada()
	{
		if(heroi.ondeEntrei.nomeDaEntrada!=Application.loadedLevelName)
		{
			entreiPor(saidas,tHeroi.position);
		}else
			entreiPor(saidas,heroi.ondeEntrei.PosEntrada);
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

		bool seguro = false;
		/*
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
	;*/
		return seguro;
	}
}
