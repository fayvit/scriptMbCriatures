using UnityEngine;
using System.Collections;

public class verificaTrocaMens : MonoBehaviour {
	public string indiceDaConversa = "bomDia";

	[HideInInspector] public mensagemBasica mens;
	[HideInInspector] public int mensagemAtual = 0;

	protected bool invocando;
	protected string[] essaConversa;

	public void facaTrocaMens()
	{
		if(Input.GetButtonDown("acao")||Input.GetButtonDown("acaoAlt") || Input.GetButtonDown("menu e auxiliar"))
		{
			if(!invocando){
				mens.entrando = false;
				Invoke("proximaMens",0.15f);
				invocando  = true;
			}
		}
	}
	
	public void proximaMens()
	{
		
		if(mensagemAtual+1<essaConversa.Length)
		{
			mensagemAtual++;
			mens.mensagem = essaConversa[mensagemAtual];
			mens.entrando = true;
		}else
			finalisaConversa();
		
		invocando = false;
	}

	public virtual void finalisaConversa()
	{
		
		movimentoBasico.retornarFluxoHeroi();
		mens.fechaJanela();
		mensagemAtual = 0;
	}
}
