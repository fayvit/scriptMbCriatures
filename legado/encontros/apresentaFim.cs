using UnityEngine;
using System.Collections;

public class apresentaFim : abaixoDeMenu {

	public Criature vencedor;
	public Criature derrotado;
	public string conteudo = "pontinhos";
	public golpe aprendeuEsse = new golpe();
	public bool fecharML = true;

	private string[] conversa;




	// Use this for initialization
	void Start () {
		skin = elementosDoJogo.el.skin;
		conversa = bancoDeTextos.falacoes[heroi.lingua]["apresentaFim"].ToArray();
		focandoHeroi(fecharML);// Apesar do nome isso apenas recolhe todos os HUDS de luta
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

	void daJanela(int janela)
	{
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.2f*aCr);

		GUIStyle label1 = new GUIStyle (skin.label);
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 20;
		GUI.Label (R, vencedor.Nome+conversa[0],label1);
		R = new Rect (0.01f*lCr,0.21f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,conversa[1]+vencedor.Nome+conversa[2],label1);


		float aux = (float)((double)derrotado.cAtributos [0].Maximo / (double)2);

		R = new Rect (0.01f*lCr,0.35f*aCr,lCr,0.2f*aCr);

		GUI.Label(R,aux+conversa[3],label1);


		R = new Rect (0.01f*lCr,0.51f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,conversa[4],label1);

		R = new Rect (0.01f*lCr,0.7f*aCr,lCr,0.2f*aCr);
		heroi H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();
		GUI.Label(R,H.nome+conversa[5],label1);

		R = new Rect (0.01f*lCr,0.85f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,derrotado.cAtributos[0].Maximo+conversa[6] ,label1);
	}

	void janelaPassou(int janela)
	{
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.2f*aCr);
		
		GUIStyle label1 = new GUIStyle (skin.label);
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 20;
		GUI.Label (R, vencedor.Nome+conversa[7],label1);
		R = new Rect (0.01f*lCr,0.21f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,conversa[8],label1);
		
		R = new Rect (0.01f*lCr,0.35f*aCr,lCr,0.2f*aCr);
		
		GUI.Label(R,conversa[9]+vencedor.mNivel.Nivel+conversa[10],label1);

	}

	void janelaAprendeu(int janela)
	{
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.2f*aCr);
		
		GUIStyle label1 = new GUIStyle (skin.label);
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 20;
		GUI.Label (R, vencedor.Nome+conversa[11],label1);

		R = new Rect(0.02f*lCr,0.22f*aCr,0.5f*aCr,0.5f*aCr);
		GUI.Box(R,"",skin.box);

		R = new Rect(0.03f*lCr,0.23f*aCr,0.48f*aCr,0.48f*aCr);
		GUIStyle tempStyle = new GUIStyle(skin.box);

		Texture2D textura = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>()
			.retornaMini(aprendeuEsse.Nome,"golpe");
		tempStyle.normal.background = textura;
		tempStyle.hover.background = textura;
		tempStyle.active.background = textura;

		GUI.Box(R,"",tempStyle);

		R = new Rect(0.52f*aCr,0.22f*aCr,lCr-0.52f*aCr,0.25f*aCr);

		GUI.Label(R,"<color=yellow>"+
		          golpe.nomeEmLinguas(aprendeuEsse)+"</color>",label1);

		R = new Rect(0.6f*aCr,0.5f*aCr,lCr-0.6f*aCr,0.25f*aCr);
		GUI.Label(R,conversa[12]+
			aprendeuEsse.TempoReuso+conversa[13]+
				aprendeuEsse.Basico+conversa[14]+
		          aprendeuEsse.CustoPE,skin.label);

		/*
		R = new Rect (0.01f*lCr,0.21f*aCr,lCr,0.2f*aCr);
		GUI.Label(R," pela vitoria "+vencedor.Nome+" recebeu",label1);
		
		
		float aux = (float)((double)derrotado.cAtributos [0].Maximo / (double)2);
		
		R = new Rect (0.01f*lCr,0.35f*aCr,lCr,0.2f*aCr);
		
		GUI.Label(R,aux+"<color=#FFD700> pontos de experiencia.</color>",label1);
		
		
		R = new Rect (0.01f*lCr,0.51f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,"e",label1);
		
		R = new Rect (0.01f*lCr,0.7f*aCr,lCr,0.2f*aCr);
		heroi H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();
		GUI.Label(R,H.nome+" recebeu ",label1);
		
		R = new Rect (0.01f*lCr,0.85f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,derrotado.cAtributos[0].Maximo+"<color=#FF4500> CRISTAIS</color>" ,label1);
		*/
	}

	void janelaPodeAprender(int janela)
	{
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.2f*aCr);
		
		GUIStyle label1 = new GUIStyle (skin.label);
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 20;
		GUI.Label (R, vencedor.Nome+conversa[15],label1);
		
		R = new Rect(0.02f*lCr,0.22f*aCr,0.5f*aCr,0.5f*aCr);
		GUI.Box(R,"",skin.box);
		
		R = new Rect(0.03f*lCr,0.23f*aCr,0.48f*aCr,0.48f*aCr);
		GUIStyle tempStyle = new GUIStyle(skin.box);
		
		Texture2D textura = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>()
			.retornaMini(aprendeuEsse.Nome,"golpe");
		tempStyle.normal.background = textura;
		tempStyle.hover.background = textura;
		tempStyle.active.background = textura;
		
		GUI.Box(R,"",tempStyle);
		
		R = new Rect(0.52f*aCr,0.22f*aCr,lCr-0.52f*aCr,0.25f*aCr);
		
		GUI.Label(R,"<color=yellow>"+
		          golpe.nomeEmLinguas(aprendeuEsse)+"</color>",label1);
		
		R = new Rect(0.6f*aCr,0.5f*aCr,lCr-0.6f*aCr,0.25f*aCr);
		GUI.Label(R, conversa[12]+
		          aprendeuEsse.TempoReuso+conversa[13]+
		          aprendeuEsse.Basico+conversa[14]+
		          aprendeuEsse.CustoPE,skin.label);

		R = new Rect(0.02f*lCr,0.72f*aCr,lCr,0.25f*aCr);
		GUI.Label(R,conversa[16],label1);
	}

	void OnGUI()
	{
		Rect R = new Rect(posXrr,posYr,lCr,aCr);
		GUILayout.BeginArea (R);
		switch(conteudo)
		{
		case "pontinhos":
			GUILayout.Window (0,R,daJanela,"",skin.box);
		break;
		case "deNivel":
			GUILayout.Window (0,R,janelaPassou,"",skin.box);
		break;
		case "aprendeuEsse":
			GUILayout.Window (0,R,janelaAprendeu,"",skin.box);
		break;
		case "podeAprender":
			GUILayout.Window (0,R,janelaPodeAprender,"",skin.box);
		break;
		}
		GUILayout.EndArea ();
	}
}
