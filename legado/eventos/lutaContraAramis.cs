using UnityEngine;
using System.Collections;

public class lutaContraAramis : encontroDeTreinador {

	public string chaveDaVitoria = "lutouComAramis";
	public string chaveConversaDaVitoria = "AramisNoMOmentoDaDerrota";

	private faseDaFinalisacao fase = faseDaFinalisacao.iniciando;
	private conversaEmJogo cJ;

	private enum faseDaFinalisacao
	{
		iniciando,
		primeirasMensagens
	}

	protected virtual void atualizaChaves()
	{
		// Aramis ja inicia com suas chaves finais
		// Essas funçao sera utilizados por treinadores que herdam esse comportamento

		chaveDaVitoria = "lutouComAramis";
		chaveConversaDaVitoria = "AramisNoMOmentoDaDerrota";
	}

	protected override void finalDeLuta()
	{
		switch(fase)
		{
		case faseDaFinalisacao.iniciando:

			atualizaChaves();

			tTreinador.position = posInicialTreinador;
			tHeroi.position = posHeroi;

			heroi.contraTreinador = false;
			//Invoke("olharEmLUtaAtrasado",0.5f);
			alternancia.olharEmLuta(tTreinador);
			cJ = tTreinador.GetComponent<conversaEmJogo>();
			variaveisChave.shift[chaveDaVitoria]  = true;
			cJ.evento = true;
			cJ.atualizaIndiceDeConversa(chaveConversaDaVitoria);
			cJ.mensagemAtual = 0;
			if(!cJ.mens)
			{
				cJ.mens = tTreinador.gameObject.AddComponent<mensagemBasica>();
				cJ.mens.mensagem = bancoDeTextos.falacoes[heroi.lingua][chaveConversaDaVitoria][0];
			}

			cJ.facaTrocaMens();
			fase = faseDaFinalisacao.primeirasMensagens;
			tHeroi.rotation = Quaternion.LookRotation(
				Vector3.ProjectOnPlane(-tHeroi.position+tTreinador.position,Vector3.up)
				);
			tTreinador.rotation = Quaternion.LookRotation(
				Vector3.ProjectOnPlane(tHeroi.position-tTreinador.position,Vector3.up)
				);
		break;
		case faseDaFinalisacao.primeirasMensagens:
			if(cJ.mens)
				cJ.facaTrocaMens();
			else
			{
				if(e)
					e.enabled = true;
				cJ.finalisaConversa();
				cJ.evento = false;
				voltarParaPasseio();
				recompensaDaVitoria();
				heroi.chavesDaViagem.Add(chaveDaVitoria);
				Destroy(this);
			}
		break;
		}
	}

	protected virtual void recompensaDaVitoria()
	{
		GameObject.FindWithTag("Player")
			.GetComponent<heroi>().itens.Add(new item(nomeIDitem.condecoracaoAlpha));

	}

}
