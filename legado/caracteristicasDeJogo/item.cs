using UnityEngine;
using System.Collections;

[System.Serializable]
public class item {
	public string nome = "";
	public nomeIDitem ID;
	public bool usavel = true;
	public int acumulavel = 99;
	public int estoque = 1;
	public int valor = 10;


	
	public item(nomeIDitem nomeX)
	{
		ID = nomeX;
		switch(nomeX)
		{
		case nomeIDitem.maca:
			nome = "Maça";
			usavel = true;
			acumulavel = 99;
			estoque = 1;
		break;
		case nomeIDitem.burguer:
			nome = "Burguer";
			usavel = true;
			acumulavel = 99;
			estoque = 1;
			valor = 40;
		break;
		case nomeIDitem.cartaLuva:
			nome = "Carta Luva";
			usavel = true;
			acumulavel = 99;
			estoque = 1;
		break;
		case nomeIDitem.gasolina:
			nome = "Gasolina";
			valor = 40;
		break;
		case nomeIDitem.aguaTonica:
			nome = "Agua Tonica";
			valor = 40;
		break;
		case nomeIDitem.regador:
			nome = "Regador";
			valor = 40;
		break;
		case nomeIDitem.estrela:
			nome = "Estrela";
			valor = 40;
		break;
		case nomeIDitem.quartzo:
			nome = "Quartzo";
			valor = 40;
		break;
		case nomeIDitem.adubo:
			nome = "Adubo";
			valor = 40;
		break;
		case nomeIDitem.seiva:
			nome = "Seiva";
			valor = 40;
		break;
		case nomeIDitem.inseticida:
			nome = "Inseticida";
			valor = 40;
		break;
		case nomeIDitem.aura:
			nome = "Aura";
			valor = 40;
		break;
		case nomeIDitem.repolhoComOvo:
			nome = "Repolho com Ovo";
			valor = 40;
		break;
		case nomeIDitem.ventilador:
			nome = "Ventilador";
			valor = 40;
		break;
		case nomeIDitem.pilha:
			nome = "Pilha";
			valor = 40;
		break;
		case nomeIDitem.geloSeco:
			nome = "Gelo Seco";
			valor = 40;
		break;
		case nomeIDitem.pergaminhoDeFuga:
			nome = "Pergaminho de Fuga";
			valor = 200;
		break;
		case nomeIDitem.segredo:
			nome = "Segredo";
			usavel = false;
			acumulavel = 1;
			estoque = 1;
			valor = 500;
		break;
		case nomeIDitem.estatuaMisteriosa:
			nome = "Estatua Misteriosa";
			usavel = false;
			acumulavel = 1;
			estoque = 1;
			valor = 0;
		break;
		case nomeIDitem.cristais:
			nome = "Cristais";
			usavel = false;
			acumulavel = 0;
			estoque = 0;
			valor = 1;
		break;
		case nomeIDitem.pergaminhoDePerfeicao:
			nome = "Pergaminho de Perfeiçao";
			valor = 500;
		break;
		case nomeIDitem.antidoto:
			nome = "Antidoto";
		break;
		case nomeIDitem.amuletoDaCoragem:
			nome = "Amuleto da Coragem";
		break;
		case nomeIDitem.tonico:
			nome = "Tonico";
		break;
		case nomeIDitem.pergDeRajadaDeAgua:
			nome = "Pergaminho de Rajada de Agua";
			valor = 50;
		break;
		case nomeIDitem.pergSaida:
			nome = "Pergaminho de Saida";
			valor = 250;
		break;
		case nomeIDitem.condecoracaoAlpha:
			nome = "Condecoraçao Alpha";
			usavel = false;
			acumulavel = 1;
			estoque = 1;
			valor = 0;
		break;
		case nomeIDitem.pergArmagedom:
			nome = "Pergaminho de Armagedom";
			valor = 750;
		break;
		case nomeIDitem.pergSabre:
			nome = "Pergaminho de Sabre";
			valor = 755;
		break;
		case nomeIDitem.pergGosmaDeInseto:
			nome = "Pergaminho da Gosma de Inseto";
			valor = 50;
		break;
		case nomeIDitem.pergGosmaAcida:
			nome = "Pergaminho da Gosma Acida";
			valor = 100;
		break;
		case nomeIDitem.pergMultiplicar:
			nome = "Pergaminho do Multiplicar";
			valor = 500;
		break;
		case nomeIDitem.pergVentania:
			nome = "Pergaminho da Ventania";
			valor = 50;
		break;
		case nomeIDitem.pergVentosCortantes:
			nome = "Pergaminho dos Ventos Cortantes";
			valor = 100;
		break;
		case nomeIDitem.pergOlharParalisante:
			nome = "Pergaminho do Olhar Paralisante";
			valor = 1000;
		break;
		case nomeIDitem.pergOlharMal:
			nome = "Pergaminho do Olhar Mal";
			valor = 1000;
		break;
		case nomeIDitem.pergFuracaoDeFolhas:
			nome = "Pergaminho do Furacao de Folhas";
			valor = 100;
		break;
		case nomeIDitem.condecoracaoBeta:
			nome = "Condecoraçao Beta";
			usavel = false;
			acumulavel = 1;
			estoque = 1;
			valor = 0;
		break;
		case nomeIDitem.explosivos:
			nome = "Explosivos";
			usavel = false;
			acumulavel = 1;
			estoque = 1;
			valor = 0;
		break;
		case nomeIDitem.medalhaoDasAguas:
			nome = "Medalhao das Aguas";
			usavel = false;
			acumulavel = 1;
			estoque = 1;
			valor = 0;
		break;
		default:
//			Debug.Log("Item Default Carregado");
			nome = "parangaricotirimirroaro";
			usavel = false;
			acumulavel = 99;
			estoque = 1;
			valor = 0;
		break;
		}
	}

	public static string nomeEmLinguas(nomeIDitem nomeID)
	{
		item itemX = new item(nomeID);
//		Debug.Log(itemX.ID);
		return bancoDeTextos.falacoes[heroi.lingua]["listaDeItens"][(int)itemX.ID];
	}
}

public enum nomeIDitem
{
	generico = -1,
	maca,
	burguer,
	cartaLuva,
	gasolina,
	aguaTonica,
	regador,
	estrela,
	quartzo,
	adubo,
	seiva,
	inseticida,
	aura,
	repolhoComOvo,
	ventilador,
	pilha,
	geloSeco,
	pergaminhoDeFuga,
	segredo,
	estatuaMisteriosa,
	cristais,
	pergaminhoDePerfeicao,
	antidoto,
	amuletoDaCoragem,
	tonico,
	pergDeRajadaDeAgua,
	pergSaida,
	condecoracaoAlpha,
	pergArmagedom,
	pergSabre,
	pergGosmaDeInseto,
	pergGosmaAcida,
	pergMultiplicar,
	pergVentania,
	pergVentosCortantes,
	pergOlharParalisante,
	pergOlharMal,
	condecoracaoBeta,
	pergFuracaoDeFolhas,
	explosivos,
	medalhaoDasAguas
}
