using System;
using UnityEngine;

[System.Serializable]
public class Florest:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.laminaDeFolha,0,1),
		new nivelGolpe(1,nomesGolpes.garra,0,0.25f),
		new nivelGolpe(2,nomesGolpes.furacaoDeFolhas,0,1),
		new nivelGolpe(9,nomesGolpes.tempestadeDeFolhas,0,1.25f)
	};
	
	
	public Florest(uint nivel = 1)
	{
		planta carac = new planta ();
		
		Nome = "Florest";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Planta.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "Arma__o/corpo";
		acimaDoChao[nomesGolpes.laminaDeFolha] = 0.5f;
		acimaDoChao[nomesGolpes.furacaoDeFolhas] = 0.15f;
		distanciaEmissora[nomesGolpes.furacaoDeFolhas] = 0.5f;

		colisores[nomesGolpes.garra] = new colisor("Arma__o/corpo/quadrilD/pernaD1/pernaD2/peD/",
		                                  new Vector3(0,0,0.3f),
		                                  new Vector3(0,0.48f,-0.62f));
		colisores[nomesGolpes.tempestadeDeFolhas] = new colisor("Arma__o/corpo",
		                                           new Vector3(0,0,0.3f),
		                                           new Vector3(0,0,0f));

		distanciaFundamentadora = 0.2f;
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
