using System;
using UnityEngine;

[System.Serializable]
public class Wisks:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.tapa,0,1),
		new nivelGolpe(1,nomesGolpes.cabecada,0,0.75f),
		new nivelGolpe(2,nomesGolpes.sobreSalto,0,1),
		new nivelGolpe(7,nomesGolpes.olharParalisante,0,0.25f),
		new nivelGolpe(8,nomesGolpes.anelDoOlhar,0,1),

	};
	
	
	public Wisks(uint nivel = 1)
	{
		normal caracC = new normal ();
		
		Nome = "Wisks";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Normal.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "esqueleto/corpo_001/coluna/pescoco/cabeca";
		
		colisores[nomesGolpes.cabecada] = new colisor("esqueleto/corpo_001/coluna/pescoco/cabeca",
		                                    new Vector3(0,0f,0),
		                                    new Vector3(-0.644f,-0.495f,0.048f));
		colisores[nomesGolpes.tapa] = new colisor("esqueleto/corpo_001/coluna/anteBracoD/bracoD/maoD",
		                                new Vector3(0,0,0),
		                                new Vector3(-0.26f,-0,0));
		colisores[nomesGolpes.sobreSalto] = new colisor("esqueleto/corpo_001/",
		                                      new Vector3(0,0,1.2f),
		                                      new Vector3(-0.365f,0.113f,-0.325f));
		
		
		/*
		cAtributos [0].Maximo = 12;
		cAtributos [0].Corrente = 12;
		cAtributos [0].Basico = 3;
		*/
		
		/*		*****************
		 * 
			personalizaçao das taas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */
		
		
		cAtributos[0].Taxa = 0.22f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.18f;	//pontos de Energia
		cAtributos[2].Taxa = 0.26f;	//pontos de Poder
		cAtributos[3].Taxa = 0.17f;	//pontos de Força
		cAtributos[4].Taxa = 0.17f;	//pontos de Defesa
		
		
		/***************************************************************************/
		
		
		apiceDoPulo = 1.4f;
		velocidadeNoAr = 1.9f;
		velocidadeCaindo = 4.75f;
		
		velocidadeAndando = 5.5f;
		
		distanciaFundamentadora = 0.2f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;
		
		//alturaCamera = 1.2f;
		//distanciaCamera = 4f;
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);
		
		listaDeGolpes = listaGolpes;
	}
}
