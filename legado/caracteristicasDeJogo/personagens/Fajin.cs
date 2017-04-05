using System;
using UnityEngine;

[System.Serializable]
public class Fajin:Criature {

	public readonly nivelGolpe[] listaGolpes = {

		/* Golpes aprendiveis apenas com pergaminhos */
		
		new nivelGolpe(-1,nomesGolpes.sabreDeAsa,0,1),
		
		/*********************************************/

		new nivelGolpe(1,nomesGolpes.bico,0,0.75f),
		new nivelGolpe(1,nomesGolpes.ventania,0,0.75f),
		new nivelGolpe(2,nomesGolpes.ventosCortantes,0,1),
		new nivelGolpe(5,nomesGolpes.anelDoOlhar,0,1),
		new nivelGolpe(5,nomesGolpes.olharParalisante,0,0.1f),
		new nivelGolpe(8,nomesGolpes.sobreVoo,0,0.5f),


	};


	public Fajin(uint nivel = 1)
	{
		voador caracC = new voador ();

		Nome = "Fajin";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Voador.ToString();


		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "Esqueleto/corpo1/corpo2/corpo3/pescoco/cabeca";

		colisores[nomesGolpes.bico] = new colisor("Esqueleto/corpo1/corpo2/corpo3/pescoco/cabeca",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.21f,-0,0.505f));
		colisores[nomesGolpes.sobreVoo] = new colisor("Esqueleto/corpo1/Bone_L",
		                                              new Vector3(0,0,0),
		                                              new Vector3(-0.81f,0.12f,-0.35f));


	

		/*	*****************
		 * 
			personalizaçao das taas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */


		cAtributos[0].Taxa = 0.21f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.21f;	//pontos de Energia
		cAtributos[2].Taxa = 0.24f;	//pontos de Poder
		cAtributos[3].Taxa = 0.17f;	//pontos de Força
		cAtributos[4].Taxa = 0.17f;	//pontos de Defesa


		/***************************************************************************/

		apiceDoPulo = 1.6f;
		velocidadeNoAr = 2.2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 6.2f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
