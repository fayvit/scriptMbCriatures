using System;
using UnityEngine;

[System.Serializable]

public class DogMour:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.bombaDeGas,0,1),
		new nivelGolpe(1,nomesGolpes.garra,0,0.25f),
		new nivelGolpe(2,nomesGolpes.rajadaDeGas,0,1),
		new nivelGolpe(7,nomesGolpes.cortinaDeFumaca,0,1.25f)
	};
	
	
	public DogMour(uint nivel = 1)
	{
		gas carac = new gas ();
		
		Nome = "Dog Mour";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Gas.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "Esqueleto/Bone/Bone_001/Bone_002/Bone_003/Bone_004/Bone_005";

		colisores[nomesGolpes.garra] = new colisor("Esqueleto/Bone/Bone_001/Bone_002/Bone_002_R/Bone_002_R_001/Bone_002_R_002",
		                                 new Vector3(0.18f,0,0),
		                                 new Vector3(-0.525f,-0.057f,-0.015f));
		colisores[nomesGolpes.tosteAtaque] = new colisor("Esqueleto/Bone",
		                                           new Vector3(0f,0,0),
		                                           new Vector3(0f,0f,-0f));

		/*****************
		* 
				personalizaçao das taas de evoluçao individual do Criature
				a soma deve ser 1 
				
			*********************
		*
		*/
				
				
		cAtributos[0].Taxa = 0.18f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.22f;	//pontos de Energia
		cAtributos[2].Taxa = 0.25f;	//pontos de Poder
		cAtributos[3].Taxa = 0.18f;	//pontos de Força
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
