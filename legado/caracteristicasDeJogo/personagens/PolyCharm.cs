using System;
using UnityEngine;

[System.Serializable]

public class PolyCharm:Criature {
	
	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.bolaDeFogo,0,1),
		new nivelGolpe(1,nomesGolpes.garra,0,0.25f),
		new nivelGolpe(2,nomesGolpes.rajadaDeFogo,0,1),
		new nivelGolpe(8,nomesGolpes.tosteAtaque,0,1.25f),

		/* Golpes para aprender com pergaminhos */
		
		new nivelGolpe(-1,nomesGolpes.olharParalisante,0,1),
		
		
		/************************************************/
	};
	
	
	public PolyCharm(uint nivel = 1)
	{
		fogo carac = new fogo ();
		
		Nome = "PolyCharm";
		
		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Fogo.ToString();
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = carac._caracTipo[cnt].Mod;
		}
		
		emissor = "Arma__o_001/coluna1/coluna2/coluna3/pescoco/cabeca/boca";

		colisores[nomesGolpes.garra] = new colisor("Arma__o_001/coluna1/pernaD/peD/",
		                                 new Vector3(0.18f,0,0),
		                                 new Vector3(-0.94f,0,-0.26f));
		colisores[nomesGolpes.tosteAtaque] = new colisor("Arma__o_001/coluna1",
		                                           new Vector3(0f,0,0),
		                                           new Vector3(0,0,0));
		
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
