using UnityEngine;
using System.Collections;

public class CriatureDaEscolhaInicial : abaixoDeMenu {
	public Texture2D[] texturaSacana;
	public string[] textosDaki;
	public int escolhido = 0;
	// Use this for initialization
	void Start () {
		posX = 0.65f;
		posY = 0.2f;
		aCaixa = 0.65f;
		lCaixa = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		deslizar(false);

		Rect R = new Rect(posXrr,posYrr,lCr,aCr);
		GUI.Box(R,"",skin.box);
		R = new Rect(
			posXrr+0.01f*Screen.width,
			posYrr+0.01f*Screen.height,
			lCr-0.02f*Screen.width,
			0.1f*Screen.height
			);
		GUI.Box(R,textosDaki[0],skin.box);

		R = new Rect(
			posXrr+0.01f*Screen.width,
			posYrr+0.12f*Screen.height,
			lCr-0.02f*Screen.width,
			0.1f*Screen.height
			);

		GUIStyle tempStyle = new GUIStyle(skin.label);

		tempStyle.fontSize = 18;

		GUI.Label(R,"Golpes: ",tempStyle);

		float noMeuQuadrado = Mathf.Min(0.2f*Screen.height,lCr/2-0.04f*Screen.width);

		R = new Rect(
			posXrr+0.01f*Screen.width,
			posYrr+0.23f*Screen.height,
			noMeuQuadrado,
			noMeuQuadrado
			);

		GUI.Box(R,"",skin.box);

		R = new Rect(
			posXrr+0.02f*Screen.width,
			posYrr+0.24f*Screen.height,
			noMeuQuadrado-0.02f*Screen.width,
			noMeuQuadrado-0.02f*Screen.width
			);

		tempStyle = new GUIStyle();

		tempStyle.normal.background  = texturaSacana[0+2*escolhido];
		tempStyle.hover.background = texturaSacana[0+2*escolhido];
		tempStyle.active .background = texturaSacana[0+2*escolhido];
		
		GUI.Box(R,"",tempStyle);

		R = new Rect(
			posXrr+0.02f*Screen.width+noMeuQuadrado,
			posYrr+0.23f*Screen.height,
			lCr - noMeuQuadrado- 0.03f*Screen.width,
			noMeuQuadrado
			);

		GUI.Label(R,textosDaki[1],skin.label);

		R = new Rect(
			posXrr+0.01f*Screen.width,
			posYrr+0.24f*Screen.height+noMeuQuadrado,
			noMeuQuadrado,
			noMeuQuadrado
			);
		
		GUI.Box(R,"",skin.box);


		
		R = new Rect(
			posXrr+0.02f*Screen.width,
			posYrr+0.25f*Screen.height+noMeuQuadrado,
			noMeuQuadrado-0.02f*Screen.width,
			noMeuQuadrado-0.02f*Screen.width
			);

		tempStyle = new GUIStyle();
		
		tempStyle.normal.background  = texturaSacana[1+2*escolhido];
		tempStyle.hover.background = texturaSacana[1+2*escolhido];
		tempStyle.active .background = texturaSacana[1+2*escolhido];
		
		GUI.Box(R,"",tempStyle);

		R = new Rect(
			posXrr+0.02f*Screen.width+noMeuQuadrado,
			posYrr+0.24f*Screen.height+noMeuQuadrado,
			lCr - noMeuQuadrado- 0.03f*Screen.width,
			noMeuQuadrado
			);
		
		GUI.Label(R,textosDaki[2],skin.label);
	}
}
