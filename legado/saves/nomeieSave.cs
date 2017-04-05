using UnityEngine;
using System.Collections;

public class nomeieSave : abaixoDeMenu {
	private string nomeSave;
	private string[] textos;

	public menuInTravel2 m2;
	// Use this for initialization
	void Start () {
		nomeSave = "Save";
		textos = bancoDeTextos.falacoes[heroi.lingua]["nomeieSave"].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		deslizar();
		GUI.depth = 0;
		Rect R = new Rect(posXrr,posYrr,lCr,aCr);

		GUILayout.BeginArea(R);

		R = new Rect(0,0,lCr,aCr);
		GUI.Box(R,"",skin.box);

		R = new Rect(0.03f*lCr,0.01f*Screen.height,0.94f*lCr,0.25f*aCr);
		GUI.Label(R,textos[0],skin.label);

		R = new Rect(0.03f*lCr,0.05f*Screen.height,0.94f*lCr,0.25f*aCr);
		GUI.Label(R,textos[1]);

		R = new Rect(0.03f*lCr,0.27f*aCr,0.94f*lCr,0.25f*aCr);
		//GUI.SetNextControlName("MyTextField");
		nomeSave = GUI.TextField(R,nomeSave,skin.textField);
		//GUI.FocusControl("MyTextField");

		R = new Rect(0.03f*lCr,0.55f*aCr,0.45f*lCr,0.25f*aCr);
		if(GUI.Button(R,textos[2],skin.button))
			fechaJanela();

		R = new Rect(0.03f*lCr,0.8f*aCr,0.45f*lCr,0.25f*aCr);
		GUI.Label(R,textos[3]);

		R = new Rect(0.52f*lCr,0.8f*aCr,0.45f*lCr,0.25f*aCr);
		GUI.Label(R,textos[4]);



		R = new Rect(0.52f*lCr,0.55f*aCr,0.45f*lCr,0.25f*aCr);
		if(GUI.Button(R,textos[5],skin.button))
			acaoDoBotaoSalvar();
		


		GUILayout.EndArea();
	}

	public void acaoDoBotaoSalvar()
	{
		fechaJanela();
		jogoParaSalvar.corrente = new jogoParaSalvar();
		if(nomeSave.Trim() =="")
			nomeSave = textos[6];
		jogoParaSalvar.corrente.nomeSave = nomeSave;
		m2.salveOCorrente();
	}
}
