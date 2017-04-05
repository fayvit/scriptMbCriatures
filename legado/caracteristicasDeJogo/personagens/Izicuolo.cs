using System;
using UnityEngine;

[System.Serializable]
public class Izicuolo:Criature {

	public readonly nivelGolpe[] listaGolpes = {

		/* Golpes para aprender com pergaminhos */

		new nivelGolpe(-1,nomesGolpes.sabreDeBastao,0,1),

		/************************************************/

		new nivelGolpe(1,nomesGolpes.gosmaDeInseto,0,1),
		new nivelGolpe(1,nomesGolpes.bastao,0,0.75f),
		new nivelGolpe(2,nomesGolpes.gosmaAcida,0,1),
		new nivelGolpe(8,nomesGolpes.multiplicar,0,1.25f),

	};


	public Izicuolo(uint nivel = 1)
	{
		inseto caracC = new inseto ();

		Nome = "Izicuolo";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Inseto.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "Arma__o/Corpo/";

		acimaDoChao[nomesGolpes.gosmaAcida] = 0.1f;
		acimaDoChao[nomesGolpes.gosmaDeInseto] = 0.1f;

		colisores[nomesGolpes.bastao] = new colisor("Arma__o/Corpo/bracoD/punhoD/punhoD_001",
		                                 new Vector3(0,0,0),
		                                 new Vector3(0.382f,-0.192f,0.509f));

		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 5.5f;

		distanciaFundamentadora = 0.15f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 3.5f;
		distanciaCamera = 6f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
