using UnityEngine;
using System.Collections;

public class apresentaCaptura : abaixoDeMenu {
	
	public Criature oCapturado;
	public int fase = 1;

	private string[] falas;

	//public elementosDoJogo elementos;


	/*
	public float posX = 0.6f;
	public float posY = 0.3f;
	public float aCaixa = 0.4f;
	public float lCaixa = 0.38f;
	
	public GUISkin skin;
	
	private float posXr;
	private float posYr;
	private float aCr;
	private float lCr;
	private float posXrr = Screen.width*2;*/
	
	// Use this for initialization
	void Start () {
		skin = elementosDoJogo.el.skin;
		falas = bancoDeTextos.falacoes[heroi.lingua]["tentaCapturar"].ToArray();
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
	
	void daJanela1(int janela)
	{
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.3f*aCr);
		
		GUIStyle label1 = new GUIStyle (skin.label);
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 20;
		GUI.Label (R, falas[5],label1);
		R = new Rect (0.01f*lCr,0.31f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,"<color=yellow>"+oCapturado.Nome+"</color>",label1);
		
		R = new Rect (0.01f*lCr,0.45f*aCr,lCr,0.2f*aCr);
		
		GUI.Label(R,falas[3]+oCapturado.mNivel.Nivel,label1);
		
		/*
		R = new Rect (0.01f*lCr,0.51f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,"e",label1);
		
		R = new Rect (0.01f*lCr,0.7f*aCr,lCr,0.2f*aCr);
		heroi H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();
		GUI.Label(R,H.nome+" recebeu ",label1);
		
		R = new Rect (0.01f*lCr,0.85f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,derrotado.cAtributos[0].Maximo+"<color=#FF4500> CRISTAIS</color>" ,label1);
		*/
	}

	void daJanela2(int janela)
	{
		int nCriatures = gameObject.GetComponent<heroi>().maxCarregaveis;
		GUILayout.Box ("",skin.label);
		Rect R = new Rect (0.01f*lCr,0.01f*aCr,lCr,0.3f*aCr);
		
		GUIStyle label1 = new GUIStyle (skin.label);
		label1.alignment = TextAnchor.UpperCenter;
		label1.fontSize = 20;
		GUI.Label (R, falas[1],label1);
		R = new Rect (0.01f*lCr,0.31f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,"<color=yellow>"+nCriatures+"</color> Criatures",label1);
		
		R = new Rect (0.01f*lCr,0.45f*aCr,lCr,0.2f*aCr);
		
		GUI.Label(R,falas[2]+oCapturado.Nome+falas[3] +oCapturado.mNivel.Nivel,label1);
		

		R = new Rect (0.01f*lCr,0.53f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,falas[4],label1);

		R = new Rect (0.01f*lCr,0.61f*aCr,lCr,0.2f*aCr);
		//heroi H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();
		GUI.Label(R," Armagedom ",label1);
		/*
		R = new Rect (0.01f*lCr,0.85f*aCr,lCr,0.2f*aCr);
		GUI.Label(R,derrotado.cAtributos[0].Maximo+"<color=#FF4500> CRISTAIS</color>" ,label1);
		*/
	}

	void mensArmagedom()
	{
		entrando = true;
		fase = 3;
	}
	
	void OnGUI()
	{
		Rect R = new Rect(posXrr,posYr,lCr,aCr);
		GUILayout.BeginArea (R);
		switch(fase)
		{
			case 1:
		
				GUILayout.Window (0,R,daJanela1,"",skin.box);
		
			break;
			case 2:
				entrando = false;
				Invoke("mensArmagedom",0.15f);

			break;
			case 3:
				GUILayout.Window (0,R,daJanela2,"",skin.box);
			break;
			case 4:
				fechaJanela();
			break;
		}

		GUILayout.EndArea ();
	}
}
