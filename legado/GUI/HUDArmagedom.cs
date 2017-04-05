using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDArmagedom : Menu {

	public List<Criature> criatures;

	private GUIStyle tempStyle;
	private elementosDoJogo coisas;
	private string[] textos;

	// Use this for initialization
	void Start () {
		coisas = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		textos = bancoDeTextos.falacoes[heroi.lingua]["painelStatus"].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if(podeMudar && !pausaJogo.pause)
		{
			escolha = mudaDestaque(escolha,criatures.Count);
		}
	
	}
	void colocaOsAmiguinhos()
	{
		Rect R;
		Texture2D texturaMini;
		deslizador = Mathf.Lerp(deslizador,-deslocamentoMenu*0.17f*Screen.height,2*Time.deltaTime);
		float quadrado = Mathf.Min(lCr-0.02f*Screen.width,0.16f*Screen.height);
		float noMeuQuadrado = (lCr-0.02f*Screen.width<0.16f*Screen.height)
			?
				lCr-0.04f*Screen.width
				:
				0.14f*Screen.height;

		for(int i=0;i<criatures.Count;i++)
		{
			R = new Rect(0.01f*Screen.width,
			             0.01f*Screen.height+i*0.17f*Screen.height+deslizador,
			             quadrado,quadrado);
			GUI.Box(R,"",(escolha==i)?destaque.box:skin.box);

			R = new Rect(0.01f*Screen.width,
			             0.01f*Screen.height+i*0.17f*Screen.height+deslizador,
			             lCr-0.09f*Screen.width,quadrado);
			if(entradaDoMouseNoBox(R,i)&&podeMudar)
				escolha = (uint)i;

			R = new Rect(0.03f*Screen.width+quadrado,
			             0.01f*Screen.height+i*0.17f*Screen.height+deslizador,
			             lCr-(0.09f*Screen.width+quadrado),quadrado);
			GUI.Box(R,"",(escolha==i)?destaque.box:skin.box);

		
				tempStyle = new GUIStyle(skin.box);
				texturaMini = coisas.retornaMini(criatures[i].Nome,"criature" );
				tempStyle.normal.background = texturaMini;
				tempStyle.hover.background = texturaMini;
				tempStyle.active.background = texturaMini;
				
				R = new Rect(0.015f*Screen.width,
			             0.02f*Screen.height +(0.17f*Screen.height)*i+deslizador,
				             noMeuQuadrado,
				             noMeuQuadrado);
				GUI.Box(R,"",tempStyle);

			R = new Rect(0.04f*Screen.width+quadrado,
			             0.02f*Screen.height+i*0.17f*Screen.height+deslizador,
			             lCr-(0.15f*Screen.width+quadrado),0.25f*quadrado);

			GUI.Label(R,criatures[i].Nome+"\t"+
			          textos[9]
			          +"\t"+criatures[i].mNivel.Nivel,
			          (escolha==i)?destaque.label:skin.label);

			R = new Rect(0.04f*Screen.width+quadrado,
			             0.02f*Screen.height+i*0.17f*Screen.height+0.25f*quadrado+deslizador,
			             lCr-(0.15f*Screen.width+quadrado),0.25f*quadrado);

			GUI.Label(R,
			          textos[4]+criatures[i].cAtributos[0].Corrente+"/"+criatures[i].cAtributos[0].Maximo+"    -   "+
			          textos[5]+criatures[i].cAtributos[1].Corrente+"/"+criatures[i].cAtributos[1].Maximo+"   -    "+
			          "XP: "+criatures[i].mNivel.XP+"/"+criatures[i].mNivel.ParaProxNivel,
			          (escolha==i)?destaque.label:skin.label);

			R = new Rect(0.04f*Screen.width+quadrado,
			             0.02f*Screen.height+i*0.17f*Screen.height+0.5f*quadrado+deslizador,
			             lCr-(0.15f*Screen.width+quadrado),0.25f*quadrado);
			
			GUI.Label(R,
			          /*criatures[i].cAtributos[2].Nome*/textos[6]+criatures[i].cAtributos[2].Corrente+"    -   "+
			          /*criatures[i].cAtributos[3].Nome+": "*/textos[7]+criatures[i].cAtributos[3].Corrente+"    -   "+
			          /*criatures[i].cAtributos[4].Nome+": "*/textos[8]+criatures[i].cAtributos[4].Corrente,
			          (escolha==i)?destaque.label:skin.label);



		}

		if(0.17f*Screen.height*(escolha-deslocamentoMenu+1) > aCr)
		{
			deslocamentoMenu++;
		}
		
		if(0.17f*Screen.height*(escolha-deslocamentoMenu) < 0)
		{
			deslocamentoMenu--;
		}
		 
		if(criatures.Count>4){
			R = new Rect(lCr-0.05f*Screen.width,
			             0.03f*Screen.height,
			             0.03f*Screen.width,
			             0.03f*Screen.width);
			GUI.Box(R,"^",(escolha>0)?destaque.box:skin.box);
			
			R = new Rect(lCr-0.05f*Screen.width,
			             aCr-0.05f*Screen.width,
			             0.03f*Screen.width,
			             0.03f*Screen.width);
			GUI.Box(R,"v",(escolha<criatures.Count-1)?destaque.box :skin.box);
		}

	}

	void OnGUI()
	{
		deslizar(false,false);
		Rect R = new Rect(posXrr,posYrr,lCr,aCr);
		GUILayout.BeginArea(R);
		saidaDoMouseDoBox(R);

		R = new Rect(0,0,lCr,aCr);
		GUI.Box(R,"",skin.box);

		colocaOsAmiguinhos();
		GUILayout.EndArea();

	}
}
