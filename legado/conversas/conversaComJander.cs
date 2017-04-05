using UnityEngine;
using System.Collections;

public class conversaComJander : MonoBehaviour {


	private conversaEmJogo cJ;
	private faseDaConversa fase = faseDaConversa.inicial;
	private Menu menu;

	private enum faseDaConversa
	{
		inicial,
		escolhas
	}

	void Start()
	{
		cJ = GetComponent<conversaEmJogo>();
	}

	void Update()
	{
		if(cJ.mensagemAtual == cJ.numeroDeMensagens-1 && fase == faseDaConversa.inicial)
		{
			cJ.evento = true;
			variaveisChave.shift["falouComJander"] = true;
		}

		if(!variaveisChave.shift["falouComJander"]  && fase == faseDaConversa.inicial && cJ.mens)
		{
			if(cJ.mensagemAtual!=1)
				cJ.mens.title = "\t\t Guto Jander";
			else
				cJ.mens.title = "<color=cyan>\t Cesar Corean</color>";
		}else if(cJ.mens)
			if(cJ.mens.title.Trim()==string.Empty )
				cJ.mens.title = "\t\t Guto Jander";

		if(cJ.evento)
		{

			bool acao = Input.GetButtonDown("acao");

			//bool menuEAux = false;
			switch(fase)
			{
			case faseDaConversa.inicial:
				if(encontros.botoesPrincipais())
				{
					fase = faseDaConversa.escolhas;
					cJ.mens.entrando = false;
					menu = Camera.main.gameObject.AddComponent<Menu>();
					menu.setaDetalhes("opcoesDeJander",
					                  bancoDeTextos.falacoes[heroi.lingua]["perguntasParaOPrefeito"].ToArray(),
					                  0.4f,0.2f,0.59f,0.6f
					                  );

				}
			break;
			case faseDaConversa.escolhas:
				if(Input.GetButtonDown("acaoAlt"))
					if(menu.dentroOuFora()>-1)
						acao = true;

				if(acao)
					opcoesDoMenu();
			break;
			}

		}

		if(Input.GetButtonDown("paraCriature") && menu && !cJ.evento)
		{
			menu.fechaJanela();
			cJ.atualizaIndiceDeConversa("prefeitoDeJadme2");

		}
	}

	void opcoesDoMenu()
	{
		switch(menu.escolha)
		{
		case 0:
			cJ.atualizaIndiceDeConversa("oPorQueDeJander",0);

		break;
		case 1:
			cJ.atualizaIndiceDeConversa("liderNotavel",0);
		break;
		case 2:
			cJ.atualizaIndiceDeConversa("maquinaDePropaganda",0);
		break;
		case 3:
			cJ.atualizaIndiceDeConversa("democraciaDeJander",0);
		break;
		case 4:
			cJ.atualizaIndiceDeConversa("possoMeJuntarAJander",0);
		break;
		case 5:
			cJ.finalisaConversa();
			cJ.atualizaIndiceDeConversa("prefeitoDeJadme2",0);
			menu.fechaJanela();
		break;
		}

		cJ.mensagemAtual = 0;
		menu.entrando = false;
		if(menu.escolha!=5)
			cJ.mens.entrando = true;
		cJ.evento = false;

		fase = faseDaConversa.inicial;
	}
}
