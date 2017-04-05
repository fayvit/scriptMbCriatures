using System;
using UnityEngine;

[System.Serializable]
//using UnityEngine;
public class FelixCat:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.garra,5,0.25f),
		new nivelGolpe(1,nomesGolpes.energiaDeGarras,0,1)
	};
	


	public FelixCat(uint nivel = 1)
	{
		psiquico carac = new psiquico ();
		
		Nome = "FelixCat";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Psiquico.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "metarig";

		colisores[nomesGolpes.garra] = new colisor("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_04_R",
		                                 new Vector3(0,0,0),
		                                 new Vector3(-0.705f,0.041f,0.003f));

		colisores[nomesGolpes.energiaDeGarras] = new colisor("metarig/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/palm_04_R",
		                                 new Vector3(0,0,0),
		                                 new Vector3(-0.705f,0.041f,0.003f));
		
		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;
		
		velocidadeAndando = 3f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 2f;
		distanciaCamera = 6f;
		
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
