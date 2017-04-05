using UnityEngine;
using System.Collections;

public class HUDItens : HUDLuta {
	heroi H;
	// Use this for initialization
	void Start () {
		posX = 0.01f;
		posY = 0.01f;
		aCaixa = 0.1f;
		lCaixa = 0.85f;
		posYrr = -2*Screen.height;

		skin = elementosDoJogo.el.skin;
		destaque = elementosDoJogo.el.destaque;
		coisas = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		
		H = GameObject.FindGameObjectWithTag("Player").GetComponent<heroi>();
	
	}
	
	// Update is called once per frame
	void Update () {
		verificaFuga();
	}
	float deslizador = 0;
	int deslocamentoMenu = 0;

	void OnGUI()
	{
		deslizar(true,false);
		Rect R = new Rect(posXrr,posYrr,lCr,aCr+40);
		GUILayout.BeginArea(R);


		//R = new Rect(0,0,lCr,0.5f*Screen.width);
		//GUI.Box(R,"teste",skin.box);



		float quadrado = Mathf.Min(0.0745f*Screen.width, aCr-0.02f*Screen.height);
		float noMeuQuadrado = (0.0745f*Screen.width< aCr-0.02f*Screen.height)
			?
				0.0545f*Screen.width
				:
				aCr-0.04f*Screen.height;


		deslizador = Mathf.Lerp(deslizador,-deslocamentoMenu*(0.0845f*Screen.width),2*Time.deltaTime);

		for(int i=0; i<H.itens.Count;i++)
		{
			R = new Rect(0.01f*Screen.width+i*(0.0845f*Screen.width)+deslizador,
			             0.01f*Screen.height,
			             quadrado,
			             quadrado);
			GUI.Box(R,"",(H.itemAoUso!=i )? skin.box : destaque.box);

			if(i<H.itens.Count)
			{
				tempStyle = new GUIStyle(skin.box);
				texturaSacana = coisas.retornaMini(H.itens[i].nome,"itens");
				tempStyle.normal.background = texturaSacana;
				tempStyle.hover.background = texturaSacana;
				tempStyle.active.background = texturaSacana;
				
				R = new Rect(0.015f*Screen.width+i*(0.0845f*Screen.width)+deslizador,
				             0.015f*Screen.height,
				             noMeuQuadrado,
				             noMeuQuadrado);
				GUI.Box(R,"",tempStyle);

				R = new Rect((i)*(0.0845f*Screen.width)+noMeuQuadrado+deslizador,
				             0.015f*Screen.height+noMeuQuadrado,
				             35,35);
				GUI.Box(R,H.itens[i].estoque.ToString(),skin.box);
			}
		}

		if((0.0845f*Screen.width)*(H.itemAoUso-deslocamentoMenu+1) > lCr)
		{
			deslocamentoMenu++;
		}
		
		if((0.0845f*Screen.width)*(H.itemAoUso-deslocamentoMenu) < 0)
		{
			deslocamentoMenu--;
		}

		GUILayout.EndArea();

		tempStyle = new GUIStyle(skin.box);

		tempStyle.fontSize = 14;
		//tempStyle.alignment = TextAnchor.MiddleLeft;
		R = new Rect(posXrr,posYrr+aCr+21,0.125f*Screen.width,0.05f*Screen.height);
		GUI.Box(R,item.nomeEmLinguas(H.itens[H.itemAoUso].ID),tempStyle);
	}
}
