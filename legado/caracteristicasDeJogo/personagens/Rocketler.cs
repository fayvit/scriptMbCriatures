using System;
using UnityEngine;

[System.Serializable]
public class Rocketler:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.cabecada,-1,0.25f),
		new nivelGolpe(1,nomesGolpes.cascalho,0,1),
		new nivelGolpe(2,nomesGolpes.pedregulho,0,1),
		new nivelGolpe(6,nomesGolpes.olharMal,0,0.1f),
		new nivelGolpe(8,nomesGolpes.avalanche,0,1.25f),
		new nivelGolpe(11,nomesGolpes.sobreVoo,-1,0.25f),

		/*Golpes aprendiveis apenas com pergaminhos */

		new nivelGolpe(-1,nomesGolpes.gosmaDeInseto,-1,0.25f),
		new nivelGolpe(-1,nomesGolpes.gosmaAcida,-1,0.25f),
		new nivelGolpe(-1,nomesGolpes.multiplicar,-1,0.25f),
		new nivelGolpe(-1,nomesGolpes.ventania,-1,0.25f),
		new nivelGolpe(-1,nomesGolpes.olharParalisante,-1,0.25f),

		/*************************/
	};
	
	
	public Rocketler(uint nivel = 1)
	{
		pedra caracC = new pedra ();
		
		Nome = "Rocketler";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Pedra.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "Esqueleto/hips/spine/chest/upper_arm_R/forearm_R/hand_R";
		/*
		distanciaEmissora["Furacão de Folhas"] = 2.75f;
		distanciaEmissora["Lamina De Folha"] = 0.75f;
*/

		
		colisores[nomesGolpes.cabecada] = new colisor("Esqueleto/hips/spine/chest/neck/head",
		                                          new Vector3(-2.28f,0.96f,-1.41f),
		                                          new Vector3(-0.296f,0.401f,0.508f));
		colisores[nomesGolpes.avalanche] = new colisor("Esqueleto/hips/spine/chest/neck/head");
		                                             

	

		
		/*		*****************
		 * 
			personalizaçao das taxas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */

		cAtributos[(int)nomesAtributos.PV].Taxa = 0.2f;	//Pontos de Vida
		cAtributos[(int)nomesAtributos.PE].Taxa = 0.16f;	//pontos de Energia
		cAtributos[(int)nomesAtributos.Poder].Taxa = 0.16f;	//pontos de Poder
		cAtributos[(int)nomesAtributos.Forca].Taxa = 0.23f;	//pontos de Força
		cAtributos[(int)nomesAtributos.Defesa].Taxa = 0.25f;	//pontos de Defesa
		
		
		/***************************************************************************/

		apiceDoPulo = 3f;
		velocidadeNoAr = 2.2f;
		velocidadeCaindo = 8f;
		velocidadeSubindo  = 7;
		
		velocidadeAndando = 5f;
		
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
