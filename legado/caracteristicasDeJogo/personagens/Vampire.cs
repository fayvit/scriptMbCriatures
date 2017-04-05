using System;
using UnityEngine;

[System.Serializable]
//using UnityEngine;
public class Vampire:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.energiaDeGarras,0,1),
		new nivelGolpe(1,nomesGolpes.garra,5,0.25f)
	};
	
	
	
	public Vampire(uint nivel = 1)
	{
		voador carac = new voador ();
		
		Nome = "Vampire";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Voador.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "metarig";
		
		colisores[nomesGolpes.garra] = new colisor("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_02_R",
		                                 new Vector3(0,0,0),
		                                 new Vector3(-0.125f,0.011f,0.022f));
		
		colisores[nomesGolpes.energiaDeGarras] = new colisor("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_02_R",
		                                           new Vector3(0,0,0),
		                                           new Vector3(-0.705f,0.041f,0.003f));


		/*		*****************
		 * 
			personalizaçao das taas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */
		
		
		cAtributos[0].Taxa = 0.22f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.17f;	//pontos de Energia
		cAtributos[2].Taxa = 0.22f;	//pontos de Poder
		cAtributos[3].Taxa = 0.19f;	//pontos de Força
		cAtributos[4].Taxa = 0.20f;	//pontos de Defesa
		
		
		/***************************************************************************/
		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;
		
		velocidadeAndando = 5.5f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;
		
		alturaCamera = 2f;
		distanciaCamera = 6f;
		
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);
		
		listaDeGolpes = listaGolpes;
	}
}
