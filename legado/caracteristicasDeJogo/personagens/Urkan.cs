using System;
using UnityEngine;

[System.Serializable]

public class Urkan:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.psicose,0,1),
		new nivelGolpe(1,nomesGolpes.garra,0,0.25f),
		new nivelGolpe(2,nomesGolpes.bolaPsiquica,0,1),
		new nivelGolpe(8,nomesGolpes.teletransporte,0,1.25f),
	};
	
	
	public Urkan(uint nivel = 1)
	{
		psiquico carac = new psiquico ();
		
		Nome = "Urkan";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Psiquico.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "Esqueleto/Bone/Bone_001/Bone_002/Bone_003/Bone_004";

		colisores[nomesGolpes.garra] = new colisor("Esqueleto/Bone/Bone_001/Bone_002/Bone_002_R/Bone_002_R_001/Bone_002_R_002",
		                                 new Vector3(0.18f,0,0),
		                                 new Vector3(-0.525f,-0.057f,-0.015f));

		/*****************
		* 
				personalizaçao das taas de evoluçao individual do Criature
				a soma deve ser 1 
				
			*********************
		*
		*/
				
				
		cAtributos[0].Taxa = 0.20f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.22f;	//pontos de Energia
		cAtributos[2].Taxa = 0.24f;	//pontos de Poder
		cAtributos[3].Taxa = 0.17f;	//pontos de Força
		cAtributos[4].Taxa = 0.17f;	//pontos de Defesa
		
		
		/***************************************************************************/

		
		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;
		
		velocidadeAndando = 5f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
