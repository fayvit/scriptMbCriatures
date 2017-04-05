using UnityEngine;
using System.Collections;

public class vidaEmLuta : abaixoDeMenu {
	
	public Criature doMenu;
	public string nomeVida;
	public bool negativo;
	public bool minhaLuta;


	public int n ;


	private GUIStyle label1;
	private GUIStyle label2;
	private elementosDoJogo elementos;
	private heroi H;

	//public float gambiarraParaIntLerp;

	// Use this for initialization
	void Start () {
		int multiplicador = negativo?-1:1;
		lCaixa = 0.25f;
		aCaixa = 0.2f;
		skin = elementosDoJogo.el.skin;
		posYrr  = 2*multiplicador*Screen.height;

		label1 = new GUIStyle(skin.label);
		label1.font = skin.box.font;
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 18;

		label2 = new GUIStyle (skin.label);
		label2.fontSize = 16;

		if(minhaLuta)
		{
			H = GameObject.FindWithTag("Player").GetComponent<heroi>();
			elementos = elementosDoJogo.el;
		}


	}
	
	// Update is called once per frame
	void Update () {

	//	posXr = posX * Screen.width;
	//	posYr = posY * Screen.height;


		/*
		if(entrando && posYrr!= posYr)
			posYrr = Mathf.Lerp(posYrr,posYr,tempoDeMenu*Time.deltaTime);

		if(!entrando && posYrr!=2*Screen.height)
			posYrr = Mathf.Lerp(posYrr,2*Screen.height,tempoDeMenu*Time.deltaTime);
			*/
	}

	public void alteraCor(Color cor)
	{
		if(label2!= null)
		{
			label2.normal.textColor = cor;
			label2.active .textColor = cor;
			label2.hover.textColor = cor;

			label1.normal.textColor = cor;
			label1.active .textColor = cor;
			label1.hover.textColor = cor;
		}
	}

	void janelinha(int janela)
	{



		GUILayout.Label(doMenu.Nome+" \t"+
		                bancoDeTextos.falacoes[heroi.lingua]["painelStatus"][9]
		                +doMenu.mNivel.Nivel,label1);


		Rect R = new Rect (0.02f*lCr,0.23f*aCr,0.9f*lCr,0.9f*aCr);



		GUI.Label(R,doMenu.cAtributos[0].Nome+": "+doMenu.cAtributos[0].Corrente+" / "+doMenu.cAtributos[0].Maximo,label2);


		float multiplicador = (float)((double)doMenu.cAtributos [0].Corrente / (double)doMenu.cAtributos [0].Maximo);

		R = new Rect (0.05f*lCr,0.5f*aCr,0.9f*lCr*multiplicador,0.05f*aCr);	
		GUIStyle verm = new GUIStyle (skin.label);
		Texture2D vermelha = new Texture2D (10, 10);
		for(int i=0;i<20;i++)
			for(int j=0;j<20;j++)
				vermelha.SetPixel (i,j,new Color(0.9f,0.1f,0));
		vermelha.Apply ();
		verm.normal.background = vermelha;
		GUI.Label (R,"",verm);

		R = new Rect (0.05f*lCr+0.9f*lCr*multiplicador,0.5f*aCr,0.9f*lCr*(1-multiplicador),0.05f*aCr);	
		GUIStyle transp = new GUIStyle (skin.label);
		Texture2D transparente = new Texture2D (10, 10);
		for(int i=0;i<20;i++)
			for(int j=0;j<20;j++)
				transparente.SetPixel (i,j,new Color(0.7f,0.7f,0.7f,0.25f));
		transparente.Apply ();
		transp.normal.background = transparente;
		GUI.Label (R,"",transp);

		R = new Rect (0.02f*lCr,0.55f*aCr,0.9f*lCr,0.9f*aCr);
		
		GUI.Label(R,doMenu.cAtributos[1].Nome+": "+doMenu.cAtributos[1].Corrente+" / "+doMenu.cAtributos[1].Maximo,label2);

		multiplicador = (float)((double)doMenu.cAtributos [1].Corrente / (double)doMenu.cAtributos [1].Maximo);
		
		R = new Rect (0.05f*lCr,0.82f*aCr,0.9f*lCr*multiplicador,0.05f*aCr);	
		GUIStyle azul = new GUIStyle (skin.label);
		Texture2D az = new Texture2D (20, 20);
		for(int i=0;i<20;i++)
			for(int j=0;j<20;j++)
				az.SetPixel (i,j,new Color(0.15f,0.7f,0.16f));
		az.Apply ();
		azul.normal.background = az;
		GUI.Label (R,"",azul);



		R = new Rect (0.05f*lCr+0.9f*lCr*multiplicador,0.82f*aCr,0.9f*lCr*(1-multiplicador),0.05f*aCr);	
		GUI.Label (R,"",transp);

	}

	private Texture2D texturaSacana;
	private GUIStyle tempStyle;

	void OnGUI()
	{
		deslizar(true,!negativo);

		if(doMenu.statusTemporarios.Count>0)
		{
			Rect R2 = new Rect(posXrr,posYrr+aCr*(9f/10f),lCr,aCr/6);	
			GUILayout.BeginArea (R2);
			
			GUILayout.Window(8+n,R2,janelinha2,"",skin.box);
			GUILayout.EndArea ();
			
			
		}

		Rect R = new Rect (posXrr,posYrr,lCr,aCr);
		GUILayout.BeginArea (R);

		GUILayout.Window(n,R,janelinha,"",skin.box);
		GUILayout.EndArea ();

		if(minhaLuta)
		{
			float quadradinho = Mathf.Min(lCr/5,aCr/3);
			R = new Rect(posXrr+0.05f*lCr,posYrr-quadradinho,quadradinho,quadradinho);	
			GUI.Box(R,"",skin.box);

			tempStyle = new GUIStyle(skin.box);
			
			
			texturaSacana = elementos.retornaMini(
				H.criaturesAtivos[0].Golpes[H.criaturesAtivos[0].golpeEscolhido].Nome
				,"golpe");
			tempStyle.normal.background  = texturaSacana;
			tempStyle.hover.background = texturaSacana;
			tempStyle.active .background = texturaSacana;

			
			R = new Rect(
				posXrr+0.05f*lCr+0.01f*quadradinho,
				posYrr-quadradinho+0.01f*quadradinho,
				0.98f*quadradinho,
				0.98f*quadradinho);
			GUI.Box(R,"",tempStyle);

			R = new Rect(posXrr+0.25f*lCr,posYrr-quadradinho,quadradinho,quadradinho);	
			GUI.Box(R,"",skin.box);

			if(H.itens.Count>0&&H.itemAoUso<H.itens.Count){
				texturaSacana = elementos.retornaMini(
					H.itens[H.itemAoUso].nome
					,"itens");
				tempStyle.normal.background  = texturaSacana;
				tempStyle.hover.background = texturaSacana;
				tempStyle.active .background = texturaSacana;
			
			
				R = new Rect(
					posXrr+0.25f*lCr+0.01f*quadradinho,
					posYrr-quadradinho+0.01f*quadradinho,
					0.98f*quadradinho,
					0.98f*quadradinho);
				GUI.Box(R,"",tempStyle);
			}

			R = new Rect(posXrr+0.45f*lCr,posYrr-quadradinho,quadradinho,quadradinho);	
			GUI.Box(R,"",skin.box);

			if(H.criaturesAtivos.Count>1){
				texturaSacana = elementos.retornaMini(
					H.criaturesAtivos[H.criatureSai].Nome
					,"criature");
				tempStyle.normal.background  = texturaSacana;
				tempStyle.hover.background = texturaSacana;
				tempStyle.active .background = texturaSacana;
			
			
				R = new Rect(
					posXrr+0.45f*lCr+0.01f*quadradinho,
					posYrr-quadradinho+0.01f*quadradinho,
					0.98f*quadradinho,
					0.98f*quadradinho);
				GUI.Box(R,"",tempStyle);
			}


		}
	}

	void janelinha2(int janela)
	{
		GUILayout.Label("");

		Rect R = new Rect(0,0,aCr/6,aCr/6);	
		string labelDeStatus = doMenu.statusTemporarios[((int)Time.time)%doMenu.statusTemporarios.Count].esseStatus.ToString();
		GUI.Box(R,"",skin.box);
		R = new Rect(0.01f*(aCr/6),0.01f*(aCr/6),aCr/6,aCr/6);	
		texturaSacana = elementosDoJogo.el.retornaMini(
			labelDeStatus,
			"status");
		tempStyle = new GUIStyle(skin.box);
		tempStyle.normal.background  = texturaSacana;
		tempStyle.hover.background = texturaSacana;
		tempStyle.active .background = texturaSacana;
		GUI.Box(R,"",tempStyle);
		R = new Rect(1.5f*(aCr/6),0.01f*(aCr/6),lCr-1.05f*(aCr/6),aCr/6);
		GUI.Label(R,labelDeStatus,skin.label);
	}
}
