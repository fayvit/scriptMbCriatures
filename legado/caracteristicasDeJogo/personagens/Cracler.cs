using System;
using UnityEngine;

[System.Serializable]
public class Cracler:Criature {

	public readonly nivelGolpe[] listaGolpes = {
		new nivelGolpe(1,nomesGolpes.agulhaVenenosa,0,1),
		new nivelGolpe(4,nomesGolpes.bastao,0,0.5f),
		new nivelGolpe(4,nomesGolpes.tesoura,0,0.5f),
		new nivelGolpe(2,nomesGolpes.ondaVenenosa,0,1),
		new nivelGolpe(8,nomesGolpes.chuvaVenenosa,0,1.25f),

		/* Golpes para aprender com pergaminhos */
		
		new nivelGolpe(-1,nomesGolpes.sabreDeBastao,0,1),
		new nivelGolpe(-1,nomesGolpes.olharParalisante,-1,0.25f),
		
		/************************************************/

	};


	public Cracler(uint nivel = 1)
	{

		veneno caracAgua = new veneno ();

		Nome = "Cracler";

		meusTipos = new String[1];
		meusTipos [0] = nomeTipos.Veneno.ToString();

		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome = ((nomeTipos)cnt).ToString();
			contraTipos[cnt].Mod = caracAgua._caracTipo[cnt].Mod;
		}

		/*
		 * Cracler tem fraqueza especial contra Eletricidade 
		 * e e forte excepcionalmente contra veneno
		 */
		contraTipos[9].Mod = 0.1f;//Veneno
		contraTipos[7].Mod = 2f;//Eletrico


		tempoDeInstancia[nomesGolpes.agulhaVenenosa] = 0.01f;
		tempoDeInstancia[nomesGolpes.chuvaVenenosa] = 0.01f;

		emissor = "container/Arma__o/Bone/Bone_R/Bone_R_001";
		colisores[nomesGolpes.chuvaVenenosa] = new colisor();
		colisores[nomesGolpes.tesoura] = new colisor("container/Arma__o/Bone",
		                                  new Vector3(0,0,0),
		                                  new Vector3(0.148f,-0.012f,0.672f));
		colisores[nomesGolpes.bastao] = new colisor("container/Arma__o/Bone/Bone_001",
		                                            new Vector3(0,0,0),
		                                            new Vector3(0,0,0));

		/*		*****************
		 * 
			personalizaçao das taas de evoluçao individual do Criature
			a soma deve ser 1 

			*********************
		 *
		 */
		
		
		cAtributos[0].Taxa = 0.22f;	//Pontos de Vida
		cAtributos[1].Taxa = 0.17f;	//pontos de Energia
		cAtributos[2].Taxa = 0.22f;	//pontos de Poder
		cAtributos[3].Taxa = 0.19f;	//pontos de Força
		cAtributos[4].Taxa = 0.2f;	//pontos de Defesa
		
		
		/**********************************************/


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
