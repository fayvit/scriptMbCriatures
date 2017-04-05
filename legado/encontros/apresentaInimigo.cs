using UnityEngine;
using System.Collections;

public class apresentaInimigo : abaixoDeMenu {
	public Criature inimigo;

	public bool eTreinador = false;
	public string nomeTreinador;
	private string[] textos;

	
	// Use this for initialization
	void Start () {
		posXrr = Screen.width*2;
		tempoDeMenu = 15;
		skin = elementosDoJogo.el.skin;
		textos = bancoDeTextos.falacoes[heroi.lingua]["apresentaInimigo"].ToArray();
	
	}
	
	// Update is called once per frame
	void Update () {
		posXr = posX * Screen.width;
		posYr = posY * Screen.height;
		lCr = lCaixa * Screen.width;
		aCr = aCaixa * Screen.height; 

		if(entrando && posXrr != posXr)
			posXrr = Mathf.Lerp(posXrr,posXr,Time.deltaTime*tempoDeMenu);

		if(!entrando && posXrr != Screen.width*2)
			posXrr = Mathf.Lerp(posXrr,Screen.width*2,Time.deltaTime*tempoDeMenu);
	}

	void daJanela(int x)
	{
		GUIStyle label1 = new GUIStyle (skin.label);
		label1.fontSize = 24;
		label1.alignment = TextAnchor.UpperCenter;
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.2f*aCr);
		string esseTexto = eTreinador?
			string.Format(textos[4],nomeTreinador)
				:
				textos[0];
		GUI.Label (R, esseTexto, label1);
		R = new Rect (0.01f*lCr,0.12f*aCr,lCr,0.2f*aCr);
		GUI.Label (R, "<color=yellow>" + inimigo.Nome + textos[1] + inimigo.mNivel.Nivel,label1);
		R = new Rect (0.01f*lCr,0.32f*aCr,lCr,0.2f*aCr);
		GUI.Label (R, textos[2]+ inimigo.cAtributos [0].Corrente + " / " + inimigo.cAtributos [0].Maximo, label1);
			

		R = new Rect (0.1f*lCr,0.48f*aCr,0.8f*lCr,0.02f*aCr);
		GUIStyle verm = new GUIStyle (skin.box);
		Texture2D vermelha = new Texture2D (10, 10);
		for(int i=0;i<20;i++)
			for(int j=0;j<20;j++)
				vermelha.SetPixel (i,j,new Color(100,0,0));
		vermelha.Apply ();
		verm.normal.background = vermelha;
		GUI.Box (R,"",verm);

		R = new Rect (0.1f*lCr,0.58f*aCr,0.8f*lCr,0.2f*aCr);
		GUI.Label(R,textos[3]+inimigo.cAtributos[1].Corrente + " / "+inimigo.cAtributos[1].Maximo,label1);
		GUIStyle azul = new GUIStyle (skin.box);
		Texture2D az = new Texture2D (20, 20);
		for(int i=0;i<20;i++)
			for(int j=0;j<20;j++)
				az.SetPixel (i,j,new Color(0.15f,0.7f,0.16f));
		az.Apply ();
		azul.normal.background = az;
		R = new Rect (0.1f*lCr,0.74f*aCr,0.8f*lCr,0.02f*aCr);
		GUI.Box (R,"",azul);
	}

	void OnGUI()
	{
		Rect R = new Rect(posXrr,posYr,lCr,aCr);
		GUILayout.BeginArea (R);
			GUILayout.Window (0,R,daJanela,"",skin.box);
		GUILayout.EndArea ();
	}
}
