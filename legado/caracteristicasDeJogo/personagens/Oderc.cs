using System;
using UnityEngine;

[System.Serializable]
public class Oderc:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.rajadaDeTerra,0,1),
		new nivelGolpe(1,nomesGolpes.chicoteDeCalda,0,1),
		new nivelGolpe(2,nomesGolpes.vingancaDaTerra,0,1),
		new nivelGolpe(8,nomesGolpes.cortinaDeTerra,0,1),
	};
	
	
	public Oderc(uint nivel = 1)
	{
		terra caracC = new terra ();
		
		Nome = "Oderc";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Terra.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}
		
		
		
		emissor = "esqueleto/centro/c1/c2/cabeca/bocaC";

		tempoDeInstancia[nomesGolpes.rajadaDeTerra] = 0.25f;
		tempoDeInstancia[nomesGolpes.vingancaDaTerra] = 0.15f;

		
		colisores[nomesGolpes.chicoteDeCalda] = new colisor("esqueleto/centroReverso/r1/r2/r3/rabo",
		                                          new Vector3(0,0f,0),
		                                          new Vector3(0.051f,0.254f,0.38f));

		colisores[nomesGolpes.garra] = new colisor("Arma__o/base/pernaD/peD1/peD2",
		                                   new Vector3(0,0f,0),
		                                   new Vector3(-0.156f,0.096f,-0.212f));



		
		/*		*****************
		 * 
			personalizaçao das taxas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */
		
		
		cAtributos[(int)nomesAtributos.PV].Taxa = 0.18f;	//Pontos de Vida
		cAtributos[(int)nomesAtributos.PE].Taxa = 0.18f;	//pontos de Energia
		cAtributos[(int)nomesAtributos.Poder].Taxa = 0.22f;	//pontos de Poder
		cAtributos[(int)nomesAtributos.Forca].Taxa = 0.24f;	//pontos de Força
		cAtributos[(int)nomesAtributos.Defesa].Taxa = 0.18f;	//pontos de Defesa
		
		
		/***************************************************************************/

		apiceDoPulo = 2.5f;
		velocidadeNoAr = 1.9f;
		velocidadeCaindo = 4.95f;
		
		velocidadeAndando = 5f;
		
		distanciaFundamentadora = 0.2f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;
		
		//alturaCamera = 1.2f;
		//distanciaCamera = 4f;
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);
		
		listaDeGolpes = listaGolpes;
	}
}
