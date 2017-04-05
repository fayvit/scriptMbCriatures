using System;
using UnityEngine;


[System.Serializable]
public class Babaucu:Criature {
	
	public  readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.dentada,0,0.5f),
		new nivelGolpe(1,nomesGolpes.chicoteDeMao,0,0.5f),
		new nivelGolpe(2,nomesGolpes.sobreSalto,0,0.5f),
		new nivelGolpe(7,nomesGolpes.olharMal,0,0.25f),
		new nivelGolpe(8,nomesGolpes.anelDoOlhar,0,0.25f)
	};
	
	
	public Babaucu(uint nivel = 1)
	{
		normal carac = new normal ();
		Nome = "Babauçu";
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Normal.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "";//"Arma__o/corpo3/corpo2/corpo1/pescoco/cabeca/bocaC";


		acimaDoChao[nomesGolpes.olharMal] = 0.35f;
		acimaDoChao[nomesGolpes.anelDoOlhar] = 0.4f;


		colisores[nomesGolpes.chicoteDeMao] = new colisor("esqueleto/corpo/preBracoD/bracoD1/bracoD2/bracoD3/bracoD4",
		                                  new Vector3(0,0,0f),
		                                  new Vector3(-0.2f,0.53f,-0.13f));

		colisores[nomesGolpes.dentada] = new colisor("esqueleto/corpo/",
		                                        new Vector3(0,0,0.3f),
		                                   new Vector3(-0.2f,0f,0.723f));

		colisores[nomesGolpes.sobreSalto] = new colisor("esqueleto/corpo/",
		                                      new Vector3(0,0,1.2f),
		                                      new Vector3(-0.365f,0.113f,-0.325f));

		/*
		colisores["garra"] = new colisor("Arma__o/corpo3_R/",
		                                 new Vector3(0,0,0.3f),
		                                 new Vector3(-0.365f,0.113f,-0.325f));*/

		
		cAtributos [0].Maximo = 10;
		cAtributos [0].Corrente = 10;
		cAtributos [0].Basico = 10;
		
		apiceDoPulo = 1.5f;
		velocidadeNoAr = 8f;
		velocidadeCaindo = 5f;
		
		velocidadeAndando = 5f;
		
		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

	
		
		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
		
	}
}