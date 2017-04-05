using System;
using UnityEngine;

[System.Serializable]
public class Baratarab:Criature {

	public readonly nivelGolpe[] listaGolpes = {

		/* Golpes para aprender com pergaminhos */

		new nivelGolpe(-1,nomesGolpes.ventania,0,1),
		new nivelGolpe(-1,nomesGolpes.ventosCortantes,0,1),

		/*************************************************/

		new nivelGolpe(1,nomesGolpes.gosmaDeInseto,0,1),
		new nivelGolpe(1,nomesGolpes.cabecada,-1,0.75f),
		new nivelGolpe(2,nomesGolpes.gosmaAcida,0,1),
		new nivelGolpe(6,nomesGolpes.olharParalisante,0,1),
		new nivelGolpe(8,nomesGolpes.multiplicar,0,1.25f),
		new nivelGolpe(9,nomesGolpes.sobreVoo,0,1),

	};


	public Baratarab(uint nivel = 1)
	{
		inseto caracC = new inseto ();

		Nome = "Baratarab";

		meusTipos = new String[2];
		meusTipos [0] = nomeTipos.Inseto.ToString();
		meusTipos [1] = nomeTipos.Voador.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "Arma__o/Bone_001/Bone/Bone_002";

		colisores[nomesGolpes.cabecada] = new colisor("Arma__o/Bone_001/Bone/Bone_002",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.283f,0.014f,-0.245f));
		colisores[nomesGolpes.sobreVoo] = new colisor("Arma__o/Bone_001/Bone/",
		                                              new Vector3(0,0,0),
		                                              new Vector3(-0.163f,0.017f,0.139f));
		/*		*****************
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

		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 5.5f;

		distanciaFundamentadora = 0.15f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 3.5f;
		distanciaCamera = 6f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
