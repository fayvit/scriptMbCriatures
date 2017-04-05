using UnityEngine;
using System.Collections;

public class mensagemEmLuta : HUDLuta {
	public string mensagem ="teste";
	public bool emY = false;
	public bool positivo = false;



	void Awake()
	{
		posX = 0.01f;
		posY = 0.6f;

		aCaixa = 0.15f;
		lCaixa = 0.3f;
	}
	// Use this for initialization


	void Start () {

		if(!positivo && !emY)
			posXrr = -2*Screen.width; 
		else if (positivo && !emY)
			posXrr = 2*Screen.width; 

        if(skin==null)
		    skin = elementosDoJogo.el.skin;
	}
	
	// Update is called once per frame
	void Update () {
		verificaFuga();
	}

	public string padraoItem(string nome)
	{
		return nome+" nao precisa usar esse Item no momento";
	}

	public void fechador()
	{
		mensagemEmLuta[] mensS =  
			GetComponents<mensagemEmLuta>();
		foreach(mensagemEmLuta M in mensS)
			M.fechaJanela();

	}

	void OnGUI()
	{

		deslizar(emY,positivo);
		Rect R = new Rect(posXrr,posYrr,lCr,aCr);
		GUILayout.BeginArea (R);

		R = new Rect(0,0,lCr,aCr);
		GUI.Box(R,"",skin.box);

		R = new Rect(0.01f*Screen.width,
		                  0.01f*Screen.height,
		                  lCr - 0.02f*Screen.width,
		                  aCr - 0.02f*Screen.height);

		tempStyle = new GUIStyle(skin.label);
		tempStyle.alignment = TextAnchor.MiddleLeft;
		GUI.Label(R,mensagem,tempStyle);

		GUILayout.EndArea();
	}
}
