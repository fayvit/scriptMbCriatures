using System;
using UnityEngine;

[System.Serializable]
public class Steal:Criature {

	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.eletricidade,0,1),
		new nivelGolpe(1,nomesGolpes.cabecada,0,1),
		new nivelGolpe(2,nomesGolpes.eletricidadeConcentrada,0,1),
		new nivelGolpe(8,nomesGolpes.tempestadeEletrica,0,1.25f),
	};


	public Steal(uint nivel = 1)
	{

		eletrico caracC = new eletrico ();

		Nome = "Steal";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Eletrico.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "metarig/hips/chest";

		colisores[nomesGolpes.cabecada] = new colisor("metarig/hips/chest/neck/head",
		                                  new Vector3(0,1.93f,2.43f),
		                                  new Vector3(-0.306f,-0.156f,-0.129f));
		colisores[nomesGolpes.tempestadeEletrica] = new colisor("metarig/hips");




		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 6f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		Golpes = golpesAtivos (nivel,listaGolpes);  


		incrementaNivel(nivel);


		listaDeGolpes = listaGolpes;
	}
}
