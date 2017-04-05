using UnityEngine;
using System.Collections;

public class conversaTreinadorArena : conversaTreinadorFora {

	private heroi H;
	private bool jaRespondeu = false;

	protected override void setaOpcoes(Menu menu)
	{
		menu.setaDetalhes("somOuNaoAramis",
		                  bancoDeTextos.falacoes[heroi.lingua]["pagarOuNao"].ToArray(),
		                  0.7f,0.4f,0.25f,0.2f);
	}
	
	protected override void respostaAfirmativa()
	{
		if(!jaRespondeu)
		{
			if(!H)
				H = GameObject.FindWithTag("Player").GetComponent<heroi>();
			if(H.cristais>=750)
			{
				H.cristais-=750;
				iniciandoContraTreinador();
				finalisaEsseEvento();
			}else
			{
				//cJ.atualizaIndiceDeConversa("semDimDim");
				cJ.mensagemAtual = -1;
				cJ.facaTrocaMens();
				jaRespondeu = true;
			}
		}else
		{
			if(encontros.botoesPrincipais())
			{
				finalisaEsseEvento();
			}
		}

	}
}
