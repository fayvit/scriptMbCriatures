using System;
using UnityEngine;

[System.Serializable]
public class Iruin:Criature {

	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.gosmaDeInseto,0,1),
		new nivelGolpe(1,nomesGolpes.chicoteDeCalda,0,0.75f),
		new nivelGolpe(2,nomesGolpes.gosmaAcida,0,1),
		new nivelGolpe(8,nomesGolpes.multiplicar,0,1.25f),

	};


	public Iruin(uint nivel = 1)
	{
		inseto caracC = new inseto ();

		Nome = "Iruin";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Inseto.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracC._caracTipo[cnt].Mod;
		}

		emissor = "Esqueleto/gomo1/cabeca";

		colisores[nomesGolpes.chicoteDeCalda] = new colisor("Esqueleto/gomo2/gomo3/rabo",
		                                  new Vector3(0,0,0),
		                                  new Vector3(-0.444f,0,0f));


		
		cAtributos [0].Maximo = 12;
		cAtributos [0].Corrente = 12;
		cAtributos [0].Basico = 12;

		apiceDoPulo = 1.5f;
		velocidadeNoAr = 2f;
		velocidadeCaindo = 5f;

		velocidadeAndando = 5.5f;

		distanciaFundamentadora = 0.15f;

		velocidadeDeRotacaoParado = 1.51f;
		velocidadeDeRotacao = 2f;

		alturaCamera = 5f;
		distanciaCamera = 7f;

		Golpes = golpesAtivos (nivel,listaGolpes);  incrementaNivel(nivel);

		listaDeGolpes = listaGolpes;
	}
}
