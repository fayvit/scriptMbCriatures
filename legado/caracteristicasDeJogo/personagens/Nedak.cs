using System;
using UnityEngine;

[System.Serializable]
public class Nedak:Criature {

	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.rajadaDeAgua,0,1),
		new nivelGolpe(1,nomesGolpes.cabecada,0,0.5f),
		new nivelGolpe(2,nomesGolpes.turboDeAgua,0,1),
		new nivelGolpe(8,nomesGolpes.hidroBomba,0,1.25f),

		/* Golpes para aprender com pergaminhos */
		

		
		
		/************************************************/
	};


	public Nedak(uint nivel = 1)
	{

		agua caracAgua = new agua ();

		Nome = "Nedak";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Agua.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracAgua._caracTipo[cnt].Mod;
		}

		/*
		 * Nedak tem fraqueza especial contra Eletricidade 
		 * e e forte excepcionalmente contra veneno
		 */
		contraTipos[9].Mod = 0.1f;//Veneno
		contraTipos[7].Mod = 2f;//Eletrico

		distanciaEmissora[nomesGolpes.rajadaDeAgua] = 0.2f;
		acimaDoChao[nomesGolpes.rajadaDeAgua] = -0.2f;

		emissor = "Arma__o/Bone";
		colisores[nomesGolpes.cabecada] = new colisor("Arma__o/Bone",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.627f,-0,0.152f));
		colisores[nomesGolpes.hidroBomba] = new colisor("Arma__o/Bone",
		                                          new Vector3(0,0,0),
		                                          new Vector3(-0.26f,-0,0));

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
