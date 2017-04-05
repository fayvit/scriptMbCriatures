using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class conversaTreinadorFora : conversaComAramisFora {

	public string nomeDoTreinador;
	public string chaveConversaDaVitoria;
	public nomeIDitem recompensa;
	public int quantidadeDeRecompensas = 1;
	[SerializeField]
	public List<encontravelTreinador> encontraveisDele;
	public bool autoKey = false;

	protected override void Start()
	{
		if(autoKey)
		{
			variaveisChave.vericaAutoKey(indiceDaLuta);
			variaveisChave.vericaAutoKey(indiceDaConversa);
		}

		base.Start();
	}


	protected override void iniciandoContraTreinador()
	{

		iniciaLutaContraTreinador();
	}
	
	public void iniciaLutaContraTreinador()
	{
		lutaContraUmTreinador edT = gameObject.AddComponent<lutaContraUmTreinador>();
		edT.encontraveis = encontraveisDele;
		edT.chaveDaVitoria = indiceDaLuta;
		edT.chaveConversaDaVitoria = chaveConversaDaVitoria;
		edT.tTreinador = transform;
		edT.nomeDoTreinador = nomeDoTreinador;
		edT.recompensa = recompensa;
		edT.quantidadeDeRecompensas = quantidadeDeRecompensas;
	}
}
