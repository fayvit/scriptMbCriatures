using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDCriatures : HUDLuta {

	protected List<Criature> criatures;
	protected heroi H;
	protected bool comMouse = false;
	protected int ondeMouseEsta = -1;
	public bool extraCriature = false;




	// Use this for initialization
	protected void Start () {
		tempoDeMenu = 7f;
		skin = elementosDoJogo.el.skin;
		destaque = elementosDoJogo.el.destaque;
		coisas = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();

		H = GameObject.FindGameObjectWithTag("Player").GetComponent<heroi>();

		criatures = H.criaturesAtivos;

		posX =0.87f;
		posY = 0.07f;
		aCaixa = 0.69f;
		lCaixa = 0.12f;

		//Debug.Log(skin+" : "+destaque);
	}
	
	// Update is called once per frame
	void Update () {
		verificaFuga();
	}

	void OnGUI()
	{
		deslizar(false);



		if(extraCriature)
			aCr += 0.17f*Screen.height;
	

		Rect R = new Rect(posXrr,posYrr,lCr,aCr);
		GUILayout.BeginArea(R);
		saidaDoMouseDoBox(R);

		//R = new Rect(0,0,lCr,aCr);
		//GUI.Box(R,"as",skin.box);

		float quadrado = Mathf.Min(lCr-0.02f*Screen.width,0.16f*Screen.height);
		float noMeuQuadrado = (lCr-0.02f*Screen.width<0.16f*Screen.height)
			?
				lCr-0.04f*Screen.width
			:
				0.14f*Screen.height;

		if(extraCriature)
		{
			R = new Rect(0.01f*Screen.width,
			             0.01f*Screen.height +(0.17f*Screen.height)*4,
			             quadrado,
			             quadrado);


			GUI.Box(R,"", (H.criatureSai != 0 ) ? skin.box : destaque.box);

			entradaDoMouseNoBox(R,criatures.Count);

			tempStyle = new GUIStyle(skin.box);
			texturaSacana = coisas.retornaMini(criatures[0].Nome,"criature" );
			tempStyle.normal.background = texturaSacana;
			tempStyle.hover.background = texturaSacana;
			tempStyle.active.background = texturaSacana;
			
			R = new Rect(0.015f*Screen.width,
			             0.02f*Screen.height +(0.17f*Screen.height)*4,
			             noMeuQuadrado,
			             noMeuQuadrado);
			GUI.Box(R,"",tempStyle);


		}

		for(int i=0;i<criatures.Count-1;i++)
		{
			R = new Rect(0.01f*Screen.width,
			             0.01f*Screen.height +(0.17f*Screen.height)*i,
			             quadrado,
			             quadrado);
			GUI.Box(R,"", (H.criatureSai != i+1 ) ? skin.box : destaque.box);

			entradaDoMouseNoBox(R,i);



			if(i<criatures.Count && criatures.Count>1)
			{
				tempStyle = new GUIStyle(skin.box);
				texturaSacana = coisas.retornaMini(criatures[i+1].Nome,"criature");
				tempStyle.normal.background = texturaSacana;
				tempStyle.hover.background = texturaSacana;
				tempStyle.active.background = texturaSacana;

				R = new Rect(0.015f*Screen.width,
				             0.02f*Screen.height +(0.17f*Screen.height)*i,
				             noMeuQuadrado,
				             noMeuQuadrado);
				GUI.Box(R,"",tempStyle);
			}
		}
		GUILayout.EndArea();

		R = new Rect(posXrr,posYrr-0.05f*Screen.height,lCr,0.05f*Screen.height);
		GUILayout.BeginArea(R);
		R = new Rect(0,0,lCr,0.05f*Screen.height);
		GUI.Box(R,"",skin.box);
		tempStyle = new GUIStyle(skin.label);
		tempStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label(R,
		          (H.criaturesAtivos.Count>1)
		          ?
		          criatures[H.criatureSai].Nome
		          :
		          "",tempStyle
		          );

		GUILayout.EndArea();

	}
}
