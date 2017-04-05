using System;
using UnityEngine;

[System.Serializable]
public class Onarac:Criature {

	public readonly nivelGolpe[] listaGolpes = {

		/* Golpes aprendiveis apenas com pergaminhos */
		
		new nivelGolpe(-1,nomesGolpes.sabreDeEspada,0,1),
		
		/********************************************/

		new nivelGolpe(1,nomesGolpes.chute,0,0.5f),
		new nivelGolpe(1,nomesGolpes.espada,0,1),
		new nivelGolpe(2,nomesGolpes.sobreSalto,0,0.5f),
		new nivelGolpe(7,nomesGolpes.olharParalisante,0,0.5f),
		new nivelGolpe(8,nomesGolpes.anelDoOlhar,0,0.5f),
	};


	public Onarac(uint nivel = 1)
	{
		normal caracC = new normal ();

		Nome = "Onarac";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Normal.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		/*
		emissor = "esqueleto/corpo";
*/
		colisores[nomesGolpes.chute] = new colisor("esqueleto/corpo/coxaD/pernaD/calcanharD",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.25f,0.034f,-0.339f));

		colisores[nomesGolpes.espada] = new colisor("esqueleto/corpo/anteBracoD/bracoD/maoD",
		                                 new Vector3(0,0,0),
		                                 new Vector3(-0.335f,-0.202f,0.147f));
		colisores[nomesGolpes.sobreSalto] = new colisor("esqueleto/corpo/",
		                                      new Vector3(0,0,1.2f),
		                                      new Vector3(-0.365f,0.113f,-0.325f));

		
		cAtributos [0].Maximo = 18;
		cAtributos [0].Corrente = 18;
		cAtributos [0].Basico = 18;

		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 5.5f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 3f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
