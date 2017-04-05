using UnityEngine;
using System.Collections;

public class HUDGolpes : HUDLuta {
	
	private golpe[] G;
	private Criature criature;
	private GameObject criatureAtivo;

	void Start () {
		skin = elementosDoJogo.el.skin;
		destaque = elementosDoJogo.el.destaque;
		coisas = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		criatureAtivo = GameObject.Find("CriatureAtivo");
		criature = criatureAtivo.GetComponent<umCriature>().criature();
		posX = 0.28f;
		posY = 0.78f;
		aCaixa = 0.15f;
		lCaixa = 0.45f;

		posYrr = 2*Screen.height;

	}

	// Update is called once per frame
	void Update () {


		verificaFuga();
	}

	void OnGUI()
	{

		/*
		if(criatureAtivo!=null){
		if(criature != null)//.Golpes;)
		{
			G = criature.Golpes;
		}else{
			criature = criatureAtivo.GetComponent<umCriature>().criature();
				if(criature.Golpes!= null)
					G = criature.Golpes
			}*/

		if(criatureAtivo!=null){
			if(criature!= null)//.Golpes;)
			{
				//criature = criatureAtivo.GetComponent<umCriature>().criature();
				G = criature.Golpes;
			}else
				G = null;

		if(G!=null){

		deslizar();

		
		Rect R = new Rect(posXrr,posYrr,lCr,aCr+0.06f*Screen.height);
		

		


		GUILayout.BeginArea(R);



		//GUI.Box(new Rect(0,0,lCr,aCr),"",skin.box);
		GUI.Box(new Rect(0,aCr,lCr,0.06f*Screen.height),"",skin.box);
		
		tempStyle = new GUIStyle(skin.label);
		tempStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(0,aCr,lCr,0.06f*Screen.height),
				          golpe.nomeEmLinguas(G[criature.golpeEscolhido]),tempStyle);
		
		float ladoQuadrado = Mathf.Min(0.1f*Screen.width,aCr-0.02f*Screen.height);
		for(int i=0;i<4;i++)
		{
			R = new Rect(
				0.01f*Screen.width+0.11f*Screen.width*i,
				0.01f*Screen.height,
				ladoQuadrado,
				ladoQuadrado);
			GUI.Box(R,"",(criature.golpeEscolhido != i )?   skin.box  :   destaque.box);

		if(G.Length>i){
						if(G[i].UltimoUso > Time.time -  G[i].TempoReuso)
						{
							tempStyle = new GUIStyle((criature.golpeEscolhido != i )? skin.box : destaque.box);
							tempStyle.fontSize = 12;
							R = new Rect(
								0.01f*Screen.width+0.11f*Screen.width*i,
								0.01f*Screen.height+1.05f*ladoQuadrado,
								ladoQuadrado,
								0.03f*Screen.height
								);
							GUI.Box(R,
							        (comandos.mostradorDeTempo(-Time.time+G[i].UltimoUso+G[i].TempoReuso))
							        ,tempStyle);
						}
			tempStyle = new GUIStyle((criature.golpeEscolhido != i )? skin.box : destaque.box);


			texturaSacana = coisas.retornaMini(G[i].Nome,"golpe");
			tempStyle.normal.background  = texturaSacana;
			tempStyle.hover.background = texturaSacana;
			tempStyle.active .background = texturaSacana;


			R = new Rect(
				0.02f*Screen.width+0.11f*Screen.width*i,
				0.02f*Screen.height,
				ladoQuadrado - 0.02f*Screen.width,
				ladoQuadrado - 0.02f*Screen.width);
			GUI.Box(R,"",tempStyle);


			}
		}

		GUILayout.EndArea();
		}
	}else
		posYrr = 2*Screen.height;
		criatureAtivo = GameObject.Find("CriatureAtivo");
		criature = criatureAtivo.GetComponent<umCriature>().criature();
	}
}
