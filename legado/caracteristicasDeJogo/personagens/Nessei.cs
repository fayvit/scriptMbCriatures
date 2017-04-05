using System;
using UnityEngine;

[System.Serializable]
public class Nessei:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.chicoteDeCalda,1,0.25f),
		new nivelGolpe(1,nomesGolpes.rajadaDeAgua,3,1),
		new nivelGolpe(2,nomesGolpes.turboDeAgua,3,1),
		new nivelGolpe(8,nomesGolpes.hidroBomba,3,1.5f)
	};
	
	
	public Nessei(uint nivel = 1)
	{
		agua caracC = new agua ();
		
		Nome = "Nessei";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Agua.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "esqueleto/centro/c1/c2/c3/cabeca/bocaB";

		tempoDeInstancia[nomesGolpes.rajadaDeAgua] = 0.25f;
		tempoDeInstancia[nomesGolpes.turboDeAgua] = 0.15f;
		

		
		colisores[nomesGolpes.chicoteDeCalda] = new colisor("esqueleto/centroReverso/r1/r2/r3/rabo",
		                                          new Vector3(0,0f,0),
		                                          new Vector3(-0.093f,0.135f,-0.37f));
		colisores[nomesGolpes.hidroBomba] = new colisor("esqueleto/centroReverso",
		                                                    new Vector3(0,0f,0),
		                                                    new Vector3(0,0,-0.66f));



		
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
		
		alturaCamera = 6f;
		distanciaCamera = 8f;
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);
		
		listaDeGolpes = listaGolpes;
	}
}
