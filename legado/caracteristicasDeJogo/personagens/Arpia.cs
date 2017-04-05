using System;
using UnityEngine;

[System.Serializable]
public class Arpia:Criature {

	public readonly nivelGolpe[] listaGolpes = {

		/* Golpes aprendiveis apenas com pergaminhos */

		new nivelGolpe(-1,nomesGolpes.sabreDeAsa,0,1),

		/********************************************/

		new nivelGolpe(1,nomesGolpes.bico,0,1),
		new nivelGolpe(1,nomesGolpes.ventania,0,1),
		new nivelGolpe(2,nomesGolpes.ventosCortantes,0,1),
		new nivelGolpe(8,nomesGolpes.sobreVoo,0,0.75f),
	};


	public Arpia(uint nivel = 1)
	{
		voador caracC = new voador ();

		Nome = "Arpia";

		meusTipos = new String[2];
		meusTipos [0] = nomeTipos.Voador.ToString();
		meusTipos [1] = nomeTipos.Eletrico.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "Esqueleto/corpo1/corpo2/corpo3/pescoco/cabeca";

		colisores[nomesGolpes.bico] = new colisor("Esqueleto/corpo1/corpo2/corpo3/pescoco/cabeca",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.621f,-0,0.244f));
		colisores[nomesGolpes.sobreVoo] = new colisor("Esqueleto/corpo1/Bone_L",
		                                          new Vector3(0,0,0),
		                                          new Vector3(-0.81f,0.12f,-0.35f));


		
		cAtributos [0].Maximo = 8;
		cAtributos [0].Corrente = 8;
		cAtributos [0].Basico = 8;

		apiceDoPulo = 1.6f;
		velocidadeNoAr = 2.2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 6.2f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
