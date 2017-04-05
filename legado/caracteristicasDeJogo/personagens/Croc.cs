using System;
using UnityEngine;

[System.Serializable]
public class Croc:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.tapa,-1,0.25f),
		new nivelGolpe(1,nomesGolpes.cascalho,0,1),
		new nivelGolpe(2,nomesGolpes.pedregulho,0,1),
		new nivelGolpe(8,nomesGolpes.avalanche,0,1.25f),
	};
	
	
	public Croc(uint nivel = 1)
	{
		pedra caracC = new pedra ();
		
		Nome = "Croc";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Pedra.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_01_R";
		/*
		distanciaEmissora["Furacão de Folhas"] = 2.75f;
		distanciaEmissora["Lamina De Folha"] = 0.75f;
*/

		
		colisores[nomesGolpes.tapa] = new colisor("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_01_R",
		                                          new Vector3(0f,0.13f,1.26f),
		                                          new Vector3(-0.0776f,0.022f,-0.07f));
		colisores[nomesGolpes.avalanche] = new colisor("metarig/hips/spine/chest/neck/head");
	

		
		/*		*****************
		 * 
			personalizaçao das taxas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */

		cAtributos[(int)nomesAtributos.PV].Taxa = 0.21f;	//Pontos de Vida
		cAtributos[(int)nomesAtributos.PE].Taxa = 0.15f;	//pontos de Energia
		cAtributos[(int)nomesAtributos.Poder].Taxa = 0.16f;	//pontos de Poder
		cAtributos[(int)nomesAtributos.Forca].Taxa = 0.24f;	//pontos de Força
		cAtributos[(int)nomesAtributos.Defesa].Taxa = 0.24f;	//pontos de Defesa
		
		
		/***************************************************************************/

		apiceDoPulo = 1.5f;
		velocidadeNoAr = 1.5f;
		velocidadeCaindo = 8f;
		velocidadeSubindo  = 5;
		
		velocidadeAndando = 2.5f;
		
		distanciaFundamentadora = 0.2f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;
		
		//alturaCamera = 1.2f;
		//distanciaCamera = 4f;
		
		Golpes = golpesAtivos (nivel,listaGolpes);  
		incrementaNivel(nivel);
		
		listaDeGolpes = listaGolpes;
	}
}
