using System;
using UnityEngine;

[System.Serializable]
public class Xuash:Criature {

	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.rajadaDeAgua,0,1),
		new nivelGolpe(1,nomesGolpes.tapa,0,0.5f),
		new nivelGolpe(2,nomesGolpes.turboDeAgua,0,1),
		new nivelGolpe(8,nomesGolpes.hidroBomba,0,1.25f),
		new nivelGolpe(15,nomesGolpes.olharMal,0,0.05f),

		/* Golpes para aprender com pergaminhos */
		

		
		
		/************************************************/
	};


	public Xuash(uint nivel = 1)
	{

		agua caracAgua = new agua ();

		Nome = "Xuash";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Agua.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracAgua._caracTipo[cnt].Mod;
		}

		emissor = "Arma__o/Tronco/pescoco/Cabeca/BocaD";
		colisores[nomesGolpes.tapa] = new colisor("Arma__o/Tronco/ombroD/BracoD1/BracoD2/punhoD",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.26f,-0,0));
		colisores[nomesGolpes.hidroBomba] = new colisor("Arma__o/Tronco",
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
