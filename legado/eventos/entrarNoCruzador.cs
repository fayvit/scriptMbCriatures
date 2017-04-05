using UnityEngine;
using System.Collections;

public class entrarNoCruzador : basePerguntaSimNao {

	private heroi H;
	private bool vaiEntrar = false;

	protected override void respondeuSim()
	{
		if(!H)
			H = GameObject.FindWithTag("Player").GetComponent<heroi>();

		if(H.cristais>=100)
		{
			H.cristais-=100;
			indiceDaMinhaMens = 0;
			vaiEntrar = true;
		}else
			indiceDaMinhaMens = 1;
	}
	
	protected override void respondeuNao()
	{
		indiceDaMinhaMens = 2;
	}

	protected override void eventoFinalisador()
	{
		if(vaiEntrar)
		{
			GameObject G = new GameObject();
			
			mudeCena mudador = G.AddComponent<mudeCena>();
			DontDestroyOnLoad(G);
			mudador.nomeCena = "cruzadorDeGuerra";
			mudador.posicao = new Vector3(2668,546,2100);
			mudador.olhePraLa = -90;
			mudador.guardeValoresEMudeDeCena();
		}
	}


}
