using System;
using UnityEngine;

[System.Serializable]
public class Estrep:Criature {

	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.agulhaVenenosa ,0,1),
		new nivelGolpe(1,nomesGolpes.ataqueEmGiro,0,0.75f),
		new nivelGolpe(2,nomesGolpes.ondaVenenosa,0,1),
		new nivelGolpe(8,nomesGolpes.chuvaVenenosa,0,1.25f),
		new nivelGolpe(13,nomesGolpes.olharMal,0,0.1f),

		/* Golpes para aprender com pergaminhos */
		
		new nivelGolpe(-1,nomesGolpes.multiplicar,0,1),

		
		/************************************************/

	};


	public Estrep(uint nivel = 1)
	{
		veneno caracC = new veneno ();

		Nome = "Estrep";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Veneno.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}



		emissor = "Arma__o/Bone";

		distanciaEmissora[nomesGolpes.ondaVenenosa] = 0.75f;

		colisores[nomesGolpes.chicoteDeCalda] = new colisor("Arma__o/Corpo/rabo1/rabo2/rabo3/rabo4/ferrao",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.463f,0.169f,-0.502f));
		colisores[nomesGolpes.chuvaVenenosa] = new colisor();
		colisores[nomesGolpes.ataqueEmGiro] = new colisor("",Vector3.zero,new Vector3(0,0.5f,0.5f));


		
		cAtributos [0].Maximo = 12;
		cAtributos [0].Corrente = 12;
		cAtributos [0].Basico = 3;


		/*		*****************
		 * 
			personalizaçao das taas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */


		cAtributos[0].Taxa = 0.25f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.17f;	//pontos de Energia
		cAtributos[2].Taxa = 0.17f;	//pontos de Poder
		cAtributos[3].Taxa = 0.24f;	//pontos de Força
		cAtributos[4].Taxa = 0.17f;	//pontos de Defesa


		/***************************************************************************/


		apiceDoPulo = 1.4f;
		velocidadeNoAr = 1.9f;
		velocidadeCaindo = 4.75f;

		velocidadeAndando = 5.5f;

		distanciaFundamentadora = 0.2f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 4f;
		distanciaCamera = 5f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
