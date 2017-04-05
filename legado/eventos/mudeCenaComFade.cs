using UnityEngine;
using System.Collections;

public class mudeCenaComFade : transporteInterno {

	public string nomeCena;
	public int olhePraLa = 0;

	protected override void iniciandoTransporte()
	{
		GameObject G = new GameObject();
		
		mudeCena mudador = G.AddComponent<mudeCena>();
		DontDestroyOnLoad(G);
		mudador.nomeCena = nomeCena;
		mudador.posicao = posAlvo;
		mudador.olhePraLa = olhePraLa;
		mudador.guardeValoresEMudeDeCena();
	}
}
