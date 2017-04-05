using UnityEngine;
using System.Collections;

public class salmoSadol : MonoBehaviour {

	private conversaEmJogo cJ;
	private movimentoBasico mB;
	private bool indicouAtualizacao = false;
	// Use this for initialization
	void Start () {
		cJ = GetComponent<conversaEmJogo>();
		mB = GameObject.FindWithTag("Player").GetComponent<movimentoBasico>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cJ.mensagemAtual==1&&!indicouAtualizacao)
			indicouAtualizacao = true;

		if(indicouAtualizacao&&mB.podeAndar)
			mudeConversa();


		switch(cJ.indiceDaConversa)
		{
		case "Salmo1":
			if(cJ.mens!=null){
			if(cJ.mensagemAtual== 2)
				cJ.mens.title = "\t\t <color=cyan>Cesar Corean</color>";
			else
				cJ.mens.title = "\t\t\t Salmo Sadol";
			}
		break;
		case "Salmo3":
			if(cJ.mens!=null){

			if(cJ.mensagemAtual== 1
			   ||
			   cJ.mensagemAtual==3
			   ||
			   cJ.mensagemAtual==7
			   ||
			   cJ.mensagemAtual==12)
				cJ.mens.title = "\t\t <color=cyan>Cesar Corean</color>";
			else
				cJ.mens.title = "\t\t\t Salmo Sadol";
			}
		break;
		default:
			if(cJ.mens!=null)
				cJ.mens.title = "\t\t\t Salmo Sadol";
		break;
		}
	}

	void mudeConversa()
	{
		indicouAtualizacao = false;

		variaveisChave.contadorChave["vezesConversadasComSadol"]++;

		int qual = variaveisChave.contadorChave["vezesConversadasComSadol"]%3;

		if(qual==2 && !variaveisChave.shift["primeraConversaChaveComSadol"])
		{
			cJ.indiceDaConversa = "Salmo3";
			variaveisChave.shift["primeraConversaChaveComSadol"] = true;
		}else if(qual == 2 &&variaveisChave.shift["primeraConversaChaveComSadol"])
		{
			cJ.indiceDaConversa = "Salmo4";
		}else
		{
			cJ.indiceDaConversa = "Salmo"+(qual+1).ToString();
		}



		cJ.atualizaIndiceDeConversa();

	}
}
