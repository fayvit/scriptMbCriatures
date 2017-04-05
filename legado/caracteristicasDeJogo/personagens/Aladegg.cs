using System;
using UnityEngine;

[System.Serializable]
public class Aladegg:Criature {

	public readonly nivelGolpe[] listaGolpes = {

		/* Golpes aprendiveis apenas com pergaminhos */
		
		new nivelGolpe(-1,nomesGolpes.sabreDeAsa,0,1),
		
		/*********************************************/

		new nivelGolpe(1,nomesGolpes.chute,0,0.5f),
		new nivelGolpe(1,nomesGolpes.ventania,0,1),
		new nivelGolpe(2,nomesGolpes.ventosCortantes,0,0.5f),
		new nivelGolpe(8,nomesGolpes.sobreVoo,0,1),
		new nivelGolpe(12,nomesGolpes.olharParalisante,0,0.05f),
		new nivelGolpe(14,nomesGolpes.anelDoOlhar,0,0.5f),

	};


	public Aladegg(uint nivel = 1)
	{
		voador caracC = new voador ();

		Nome = "Aladegg";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Voador.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "esqueleto/corpo";

		colisores[nomesGolpes.chute] = new colisor("esqueleto/corpo/coxaD/pernaD/peD",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.11f,-0,0.244f));
		colisores[nomesGolpes.sobreVoo] = new colisor("esqueleto/corpo/coxaD/pernaD/peD",
		                                           new Vector3(0,0,0),
		                                           new Vector3(-0.11f,-0,0.244f));


		
		cAtributos [0].Maximo = 16;
		cAtributos [0].Corrente = 16;
		cAtributos [0].Basico = 16;

		apiceDoPulo = 1.75f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 5.5f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 6f;
		distanciaCamera = 8f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
