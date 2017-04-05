using System;
using UnityEngine;


[System.Serializable]
public class Marak:Criature {
	
	public  readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.garra,0,0.25f),
		new nivelGolpe(1,nomesGolpes.chifre,0,1),
		new nivelGolpe(2,nomesGolpes.sobreSalto,0,1),
		new nivelGolpe(5,nomesGolpes.anelDoOlhar,0,1.25f),
		new nivelGolpe(7,nomesGolpes.olharParalisante,0,0.05f),
	};
	
	
	public Marak(uint nivel = 1)
	{
		normal carac = new normal ();
		Nome = "Marak";
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Normal.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "Arma__o/corpo3/corpo2/corpo1/pescoco/cabeca/bocaC";

		colisores[nomesGolpes.chifre] = new colisor("Arma__o/corpo3/corpo2/corpo1/pescoco/cabeca/",
		                                  new Vector3(0,0,6.79f),
		                                  new Vector3(-0.6522f,-0.0274f,-0.914f));
		colisores[nomesGolpes.garra] = new colisor("Arma__o/corpo3_R/",
		                                 new Vector3(0,0,0.3f),
		                                 new Vector3(-0.331f,-0.344f,-0.192f));
		colisores[nomesGolpes.sobreSalto] = new colisor("Arma__o/corpo3/",
		                                 new Vector3(0,0,1.2f),
		                                 new Vector3(-0.365f,0.113f,-0.325f));

		cAtributos [0].Maximo = 12;
		cAtributos [0].Corrente = 12;
		cAtributos [0].Basico = 12;
		
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