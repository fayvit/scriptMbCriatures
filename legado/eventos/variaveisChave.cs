using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class variaveisChave {

	public static Dictionary<string,bool> shift = 
		new Dictionary<string,bool>()
		{
			{"comprouEstatuaPiramide",false},
			{"primeraConversaChaveComSadol",false},
			{"adiciona O Criature",false},
			{"HUDItens",false},
			{"HUDCriatures",false},
			{"alternaParaCriature",false},
			{"TrocaGolpes",false},
			{"comprouEstatuaDoAnubis",false},
			{"colocouEstatuaDoAnubis",false},
			{"falouComJander",false},
			{"falouComMustaf",false},
			{"falouComAramis",false},
			{"lutouComAramis",false},
			{"falouComMalucoDosInsetos",false},
			{"lutouComMalucoDosInsetos",false},
			{"abriuCanoDeInfinity",false},
			{"abriuCanoDeJadme",false},
			{"abriuCanoDeMariinque",false},

		// Separando Baus

			{"bauTeste",false},//colocar localizacao do Bau a frente
			{"interiorPiramide1",false},//piramide andar 1 corredor Sudoeste da entrada
			{"interiorPiramide2",false},//andar 1 primeiro corredor leste
			{"interiorPiramide3",false},// 908 - 95 - 1221
			{"interiorPiramide4",false},//922 - 95 - 1351
			{"interiorPiramide5",false},//922 - 95 - 1329
			{"interiorPiramide6",false},//798 - 95 - 1332
			{"interiorPiramide7",false},//615 - 95 - 1297
			{"interiorPiramide8",false},//1035 - 84 - 1285
			{"interiorPiramide9",false},//899 - 84 - 1420
			{"interiorPiramide10",false},//763 - 84 - 1114
			{"interiorPiramide11",false},//615 - 95 - 1317
			{"interiorPiramide12",false},//738 - 95 - 1437
			{"interiorPiramide13",false},//735 - 95 - 1437
			{"interiorPiramide14",false},//821 - 107 - 1457
			{"interiorPiramide15",false},//707 - 107 - 1395
			{"interiorPiramide16",false},//782 - 127 - 1081
			{"interiorPiramide17",false},//681 - 127 - 1180
			{"interiorPiramide18",false},//681 - 127 - 1186
			{"interiorPiramide19",false},//681 - 127 - 1194
			{"interiorPiramide20",false},//681 - 127 - 1200
			{"interiorPiramide21",false},//657 - 140 - 1293 Atras do Mustaf :1
			{"interiorPiramide22",false},//649 - 140 - 1293 Atras do Mustaf :2


			{"lutaDeCantoPiramideUrkan",false},
			{"lutaDeCantoPiramideIruin",false},
			{"lutaDeCantoPiramideFlam",false},
			{"lutaDeCantoPiramideOderc",false},
			{"lutaDeCantoPiramideEscorpirey",false},
			{"lutaDeCantoPiramideEscorpion",false},

		{"petrolifera1",false},//898 - 544 - 875 
		{"petrolifera2",false},//241.19 - 544.99 - 728 
		{"petrolifera3",false},//241.19 - 544.99 - 741
		{"petrolifera4",false},//770 - 544.99 - 31.47
		{"petrolifera5",false},//776 - 544.99 - 31.47
		{"petrolifera6",false},//782 - 544.99 - 31.47
		{"petrolifera7",false},//375. - 544.99 - 213.74
		{"petrolifera8",false},//-596 - 544.99 - 363.74
		{"petrolifera9",false},//-596 - 544.99 - 369
		{"petrolifera10",false},//-542.508 - 544.99 - 287.877
		{"petrolifera11",false},//-385.27 - 544.99 - 290.16 luta contra Nessei
		{"petrolifera12",false},//-385.27 - 544.99 - 290.16 luta contra Urkan
		{"petrolifera13",false},//14.9 - 544.99 - 70.2 luta contra Escorpirey->5 perg. Perf.
		{"petrolifera14",false},//-55.977 - 544.99 - 217.078
		{"petrolifera15",false},//14.53 - 544.99 - 832.87
		{"petrolifera16",false},//-681.65 - 544.99 - 1391.01
		{"petrolifera17",false},//-157 - 544.99 - 1025 // luta contra Cabeçu
		{"petrolifera18",false},//63 - 544.99 - 937 // luta contra Abutre
		{"petrolifera19",false},//-288.3 - 544.99 - 1105.1 // luta contra Fajin
		{"petrolifera20",false},//-107.9 - 544.99 - 1101 // luta contra Steal
		{"petrolifera21",false},//-22.708 - 544.99 - 1347.91 // 6 antidoto
		{"petrolifera22",false},//24.70359 - 544.99 - 1455.726 // 5 agua tonica
		{"petrolifera23",false},//1041.931 - 544.99 - 1768.296 // 3 perg Perfeicao
		{"petrolifera24",false},//843.24 - 544.99 - 1336.21 // 21 Cristais
		{"petrolifera25",false},//897.41 - 544.99 - 1345.63 // 2 pilhas
		{"petrolifera26",false},//241.1 - 544.99 - 1083.83 // 3 perg Fuga
		{"petrolifera27",false},//1006.8 - 544.99 - 1019.3 // luta contra Nessei
		
		};
	public static Dictionary<string,int> contadorChave = 
		new Dictionary<string,int >()
		{
			{"vezesConversadasComSadol",0},
			{"vezesTentandoComprarAnubis",0}
		};

	public static void valoresDefault()
	{
		List<string> k = new List<string>(shift.Keys);
		foreach(string s in k)
		{
			shift[s] = false;
		}

		k = new List<string>(contadorChave.Keys);
		foreach(string s in k)
		{
			contadorChave[s] = 0;
		}

		valoresDefaultDiferentes();
	}

	private static void valoresDefaultDiferentes()
	{

	}

	public static void chavesDeJadme()
	{
		if(variaveisChave.shift["comprouEstatuaDoAnubis"])
		{
			if(GameObject.Find("ShopDeJadme").GetComponent<shopBasico>().aVenda.Count>3)
				GameObject.Find("ShopDeJadme")
					.GetComponent<shopBasico>().aVenda.RemoveAt(3);
		}
		
		if(variaveisChave.shift["colocouEstatuaDoAnubis"])
		{
			GameObject.Find("baseDaEstatua").GetComponent<colocarEstatuaDoAnubis>().LigaEstatua();
			GameObject G = GameObject.Find("EntradaDaPiramide");
			if(G)
			{
				G.GetComponent<MeshCollider>().enabled = true;
				G.GetComponent<mudeCena>().enabled = true;
			}
		}
	}

	public static void aplicaShifts()
	{
		Dictionary<string,bool>.KeyCollection chaves = jogoParaSalvar.corrente.shift.Keys;
		
		foreach(string chave in chaves)
		{
			if(variaveisChave.shift.ContainsKey(chave))
			{
				variaveisChave.shift[chave] = jogoParaSalvar.corrente.shift[chave];
			}
		}
	}

	public static void aplicaContadores()
	{
		Dictionary<string,int>.KeyCollection chaveX = jogoParaSalvar.corrente.contadorChave.Keys;
		foreach(string chave in chaveX)
		{
			if(variaveisChave.contadorChave.ContainsKey(chave))
			{
				variaveisChave.contadorChave[chave] = jogoParaSalvar.corrente.contadorChave[chave];
			}
		}
	}

	static void chavesDaPiramide()
	{
		if(variaveisChave.shift["falouComMustaf"])
		{
			GameObject.Find("MUsta_provisorio").SetActive(false);
		}
	}

	static void abaixoOuAcimaDoRio()
	{
		Transform tHeroi = GameObject.FindWithTag("Player").transform;
		if(tHeroi.position.y<5)
		{
			GameObject G = GameObject.Find("capsulaEstadio") ;
			MeshRenderer mesh = G.GetComponent<MeshRenderer>();
			elementosDoJogo el = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
			Material[] M = new Material[2]{mesh.materials[0],el.materiais[2]};
			mesh.materials = M;
			GameObject.Find("capsulaEstadio").GetComponent<MeshRenderer>().materials = M;
			GameObject.Find("caminhoEstadio").GetComponent<MeshRenderer>().material = M[1];

			RenderSettings.fog = true;
		}
	}

	public static void particularidadesDeCaregamento()
	{
		switch(Application.loadedLevelName)
		{
		case "planicieDeJadme":
			chavesDeJadme();
		break;
		case "interiorDaPiramide":
			chavesDaPiramide();
		break;
		case "rioMariinque":
			abaixoOuAcimaDoRio();
		break;
		}
	}

	public static void vericaAutoKey(string chave)
	{
		if(!shift.ContainsKey(chave))
		{
			shift.Add(chave,false);
		}
	}

	private static void aplicaRetornoDeChave(string chave,heroi H)
	{

		switch(chave)
		{
		case "lutouComAramis":
			shift["lutouComAramis"] = false;
			shift["falouComAramis"] = false;
			H.itens.RemoveAt(
				shopBasico.temItem(
					nomeIDitem.condecoracaoAlpha,H
				));
		break;
		case "lutouComMalucoDosInsetos":
			if(H.itens.Contains(new item(nomeIDitem.pergSabre)))
			{
				shift["lutouComMalucoDosInsetos"] = false;
				shift["falouComMalucoDosInsetos"] = false;
				H.itens.RemoveAt( 
				   shopBasico.temItem(
					nomeIDitem.pergSabre,H
					));
			}
		break;
		case "lutouComCapitaoEspinhaDePeixe":
			shift["lutouComCapitaoEspinhaDePeixe"] = false;
			shift["falouComCapitaoEspinhaDePeixe"] = false;
			H.itens.RemoveAt(
				shopBasico.temItem(
				 nomeIDitem.condecoracaoBeta,H
				));
       	
			Debug.Log(H.itens.Contains(new item(nomeIDitem.condecoracaoBeta)));
		break;
		}

	}

	public static void executaChavesDeViagemNaMorte(heroi H)
	{
		for(int i=0;i<heroi.chavesDaViagem.Count;i++)
			aplicaRetornoDeChave(heroi.chavesDaViagem[i],H);
	}
}
