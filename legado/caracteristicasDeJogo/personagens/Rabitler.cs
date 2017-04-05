using System;
using UnityEngine;

[System.Serializable]
public class Rabitler:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.dentada,-1,0.25f),
		new nivelGolpe(1,nomesGolpes.cascalho,0,1),
		new nivelGolpe(2,nomesGolpes.pedregulho,0,1),
		new nivelGolpe(8,nomesGolpes.avalanche,0,1.25f),
	};
	
	
	public Rabitler(uint nivel = 1)
	{
		pedra caracC = new pedra ();
		
		Nome = "Rabitler";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Pedra.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "Arma__o/corpoBase/corpoP/bracoD/maoD";
		/*
		distanciaEmissora["Furacão de Folhas"] = 2.75f;
		distanciaEmissora["Lamina De Folha"] = 0.75f;
		*/

		
		colisores[nomesGolpes.dentada] = new colisor("Arma__o/corpoBase/corpoP/pescoco/cabeca",
		                                          new Vector3(0,0f,0),
		                                          new Vector3(-0.449f,0.135f,-0.37f));
		colisores[nomesGolpes.avalanche] = new colisor("Arma__o/corpoBase/corpoP/pescoco/cabeca",
		                                             new Vector3(0,0f,0),
		                                             new Vector3(0,0,0));



		
		/*		*****************
		 * 
			personalizaçao das taxas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */
		
		
		cAtributos[0].Taxa = 0.17f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.17f;	//pontos de Energia
		cAtributos[2].Taxa = 0.17f;	//pontos de Poder
		cAtributos[3].Taxa = 0.22f;	//pontos de Força
		cAtributos[4].Taxa = 0.27f;	//pontos de Defesa
		
		
		/***************************************************************************/

		apiceDoPulo = 1.7f;
		velocidadeNoAr = 1.9f;
		velocidadeCaindo = 3.95f;
		
		velocidadeAndando = 6f;
		
		distanciaFundamentadora = 0.2f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;
		
		//alturaCamera = 1.2f;
		//distanciaCamera = 4f;
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);
		
		listaDeGolpes = listaGolpes;
	}
}
