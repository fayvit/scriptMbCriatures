using System;
using UnityEngine;

[System.Serializable]
public class Serpente:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.chicoteDeCalda,0,0.25f),
		new nivelGolpe(1,nomesGolpes.laminaDeFolha,0,1),
		new nivelGolpe(2,nomesGolpes.furacaoDeFolhas,0,1),
		new nivelGolpe(8,nomesGolpes.tempestadeDeFolhas,0,1.25f),
	};
	
	
	public Serpente(uint nivel = 1)
	{
		normal caracC = new normal ();
		
		Nome = "Serpente";
		
		meusTipos = new String[2];
		meusTipos [0] = nomeTipos.Normal.ToString();
		meusTipos [1] = nomeTipos.Planta.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "esqueleto/centroReverso/r1/r2/r3/rabo";

		distanciaEmissora[nomesGolpes.furacaoDeFolhas] = 2.75f;
		distanciaEmissora[nomesGolpes.laminaDeFolha] = 0.75f;
		acimaDoChao[nomesGolpes.laminaDeFolha] = 0.45f;
		

		
		colisores[nomesGolpes.chicoteDeCalda] = new colisor("esqueleto/centroReverso/r1/r2/r3/rabo",
		                                          new Vector3(0,0f,0),
		                                          new Vector3(-0.093f,0.135f,-0.37f));
		colisores[nomesGolpes.tempestadeDeFolhas] = new colisor("esqueleto/centroReverso",
		                                                    new Vector3(0,0f,0),
		                                                    new Vector3(0,0,0));



		
		/*		*****************
		 * 
			personalizaçao das taxas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */
		
		
		cAtributos[0].Taxa = 0.19f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.21f;	//pontos de Energia
		cAtributos[2].Taxa = 0.26f;	//pontos de Poder
		cAtributos[3].Taxa = 0.17f;	//pontos de Força
		cAtributos[4].Taxa = 0.17f;	//pontos de Defesa
		
		
		/***************************************************************************/

		apiceDoPulo = 1.5f;
		velocidadeNoAr = 1.9f;
		velocidadeCaindo = 3.75f;
		
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
