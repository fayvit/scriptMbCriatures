using UnityEngine;
using System.Collections;

public class pergaminhoDeSaida : pergaminhoComTransporte {

	public saidaDeCaverna S;

	protected override void acaoDoItem()
	{
		GameObject G = new GameObject();
		
		mudeCena mudador = G.AddComponent<mudeCena>();
		DontDestroyOnLoad(G);
		mudador.nomeCena = S.cenaAlvo;
		mudador.posicao = S.posAlvo;
		mudador.olhePraLa = S.rotacaoAlvo;
		
		mudador.guardeValoresEMudeDeCena();
	}
	}
