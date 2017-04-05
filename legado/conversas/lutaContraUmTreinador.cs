using UnityEngine;
using System.Collections;

public class lutaContraUmTreinador : lutaContraAramis {

	public nomeIDitem recompensa;
	public int quantidadeDeRecompensas = 1;

	protected override void recompensaDaVitoria()
	{
		shopBasico.adicionaItem(recompensa,
		                        GameObject.FindWithTag("Player").GetComponent<heroi>(),
		                        quantidadeDeRecompensas);	
	}

	protected override void atualizaChaves()
	{
		// Aramis ja inicia com suas chaves finais
		// Essas funçao sera utilizados por treinadores que herdam esse comportamento

	}
}
