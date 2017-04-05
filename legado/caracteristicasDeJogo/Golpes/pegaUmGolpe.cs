using UnityEngine;
using System.Collections;

public class pegaUmGolpe{
	private golpe G;

	public pegaUmGolpe(nomesGolpes nome)
	{
		switch(nome)
		{
		case nomesGolpes.rajadaDeAgua:
			G = new rajadaDeAgua();
		break;
		case nomesGolpes.turboDeAgua:
			G = new turboDeAgua();
		break;
		case nomesGolpes.bolaDeFogo:
			G = new bolaDeFogo();
		break;
		case nomesGolpes.rajadaDeFogo:
			G = new rajadaDeFogo();
		break;
		case nomesGolpes.laminaDeFolha:
			G = new laminaDeFolha();
		break;
		case nomesGolpes.furacaoDeFolhas:
			G = new furacaoDeFolhas();
		break;
		case nomesGolpes.chifre:
			G = new Chifre();
		break;
		case nomesGolpes.tapa:
			G = new tapa();
		break;
		case nomesGolpes.garra:
			G = new garra();
		break;
		case nomesGolpes.chicoteDeMao:
			G = new chicoteDeMao();
		break;
		case nomesGolpes.dentada:
			G = new dentada();
		break;
		case nomesGolpes.bico:
			G = new bico();
		break;
		case nomesGolpes.ventania:
			G = new ventania();
		break;
		case nomesGolpes.ventosCortantes:
			G = new ventosCortantes();
		break;
		case nomesGolpes.gosmaDeInseto:
			G = new gosmaDeInseto();
		break;
		case nomesGolpes.gosmaAcida:
			G = new gosmaAcida();
		break;
		case nomesGolpes.chicoteDeCalda:
			G = new chicoteDeCalda();
		break;
		case nomesGolpes.cabecada:
			G = new cabecada();
		break;
		case nomesGolpes.eletricidade:
			G = new eletricidade();
		break;
		case nomesGolpes.eletricidadeConcentrada:
			G = new eletricidadeConcentrada();
		break;
		case nomesGolpes.agulhaVenenosa:
			G = new agulhaVenenosa();
		break;
		case nomesGolpes.ondaVenenosa:
			G = new ondaVenenosa();
		break;
		case nomesGolpes.chute:
			G = new chute();
		break;
		case nomesGolpes.espada:
			G = new espada();
		break;
		case nomesGolpes.sobreSalto:
			G = new sobreSalto();
		break;
		case nomesGolpes.cascalho:
			G = new cascalho();
		break;
		case nomesGolpes.pedregulho:
			G = new pedregulho();
		break;
		case nomesGolpes.rajadaDeTerra:
			G = new rajadaDeTerra();
		break;
		case nomesGolpes.energiaDeGarras:
			G = new energiaDeGarras();
		break;
		case nomesGolpes.vingancaDaTerra:
			G = new vingancaDaTerra();
		break;
		case nomesGolpes.psicose:
			G = new psicose();
		break;
		case nomesGolpes.hidroBomba:
			G = new hidroBomba();
		break;
		case nomesGolpes.bolaPsiquica:
			G = new bolaPsiquica();
		break;
		case nomesGolpes.tosteAtaque:
			G = new tosteAtaque();
		break;
		case nomesGolpes.tempestadeDeFolhas:
			G = new tempestadeDeFolhas();
		break;
		case nomesGolpes.chuvaVenenosa:
			G = new chuvaVenenosa();
		break;
		case nomesGolpes.multiplicar:
			G = new multiplicar();
		break;
		case nomesGolpes.tempestadeEletrica:
			G = new tempestadeEletrica();
		break;
		case nomesGolpes.avalanche:
			G = new Avalanche();
		break;
		case nomesGolpes.olharMal:
			G = new olharMal();
		break;
		case nomesGolpes.anelDoOlhar:
			G = new anelDoOlhar();
		break;
		case nomesGolpes.cortinaDeTerra:
			G = new cortinaDeTerra();
		break;
		case nomesGolpes.teletransporte:
			G = new Teletransporte();
		break;
		case nomesGolpes.olharParalisante:
			G = new olharParalisante();
		break;
		case nomesGolpes.sobreVoo:
			G = new sobreVoo();
		break;
		case nomesGolpes.bombaDeGas:
			G = new bombaDeGas();
		break;
		case nomesGolpes.rajadaDeGas:
			G = new rajadaDeGas();
		break;
		case nomesGolpes.cortinaDeFumaca:
			G = new cortinaDeFumaca();
		break;
		case nomesGolpes.bastao:
			G = new bastao();
		break;
		case nomesGolpes.sabreDeAsa:
			G = new sabre();
			G.Nome = "Sabre de Asa";
		break;
		case nomesGolpes.sabreDeNadadeira:
			G = new sabre();
			G.Nome = "Sabre de Nadadeira";
		break;
		case nomesGolpes.sabreDeEspada:
			G = new sabre();
			G.Nome = "Sabre de Espada";
		break;
		case nomesGolpes.sabreDeBastao:
			G = new sabre();
			G.Nome = "Sabre de Bastao";
		break;
		case nomesGolpes.tesoura:
			G  =new tesoura();
		break;
		case nomesGolpes.ataqueEmGiro:
			G  = new ataqueEmGiro();
		break;
		case nomesGolpes.nulo:
		case nomesGolpes.cancelado:
			G = new golpe();
		break;
		}

		G.nomeID = nome;
		G.TempoReuso = Mathf.Max(2.5f,G.TempoReuso);
	}

	public golpe OGolpe()
	{
		return G;
	}
}

public enum nomesGolpes
{
	cancelado = -2,
	nulo = -1,
	rajadaDeAgua,
	turboDeAgua,
	bolaDeFogo,
	rajadaDeFogo,
	laminaDeFolha,
	furacaoDeFolhas,
	chifre,
	tapa,
	garra,
	chicoteDeMao,
	dentada,
	bico,
	ventania,
	ventosCortantes,
	gosmaDeInseto,
	gosmaAcida,
	chicoteDeCalda,
	cabecada,
	eletricidade,
	eletricidadeConcentrada,
	agulhaVenenosa,
	ondaVenenosa,
	chute,
	espada,
	sobreSalto,
	cascalho,
	pedregulho,
	rajadaDeTerra,
	energiaDeGarras,
	vingancaDaTerra,
	psicose,
	hidroBomba,
	bolaPsiquica,
	tosteAtaque,
	tempestadeDeFolhas,
	chuvaVenenosa,
	multiplicar,
	tempestadeEletrica,
	avalanche,
	anelDoOlhar,
	olharMal,
	cortinaDeTerra,
	teletransporte,
	sobreVoo,
	olharParalisante,
	bombaDeGas,
	rajadaDeGas,
	cortinaDeFumaca,
	bastao,
	sabreDeAsa,
	sabreDeBastao,
	sabreDeNadadeira,
	sabreDeEspada,
	tesoura,
	ataqueEmGiro
}
