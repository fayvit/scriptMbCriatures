using UnityEngine;
using System.Collections;

public class lutaContraMalucoDosInsetos : lutaContraAramis {

	protected override void recompensaDaVitoria()
	{
		GameObject.FindWithTag("Player")
			.GetComponent<heroi>().itens.Add(new item(nomeIDitem.pergSabre));
	}

	protected override void atualizaChaves()
	{
		chaveDaVitoria = "lutouComMalucoDosInsetos";
		chaveConversaDaVitoria = "MalucoNoMOmentoDaDerrota";
	}

}
