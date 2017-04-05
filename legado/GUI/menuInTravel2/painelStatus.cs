using UnityEngine;
using System.Collections;

public class painelStatus : abaixoDeMenu {

	public Criature criature;
	private string[] textos;

	// Use this for initialization
	void Start () {
		textos = bancoDeTextos.falacoes [heroi.lingua]["painelStatus"].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if (entrando && posXrr != posXr)
				posXrr = Mathf.Lerp (posXrr, posXr, tempoDeMenu * Time.deltaTime);
		if (!entrando && posXrr != Screen.width*2)
			posXrr = Mathf.Lerp (posXrr, 2*Screen.width, tempoDeMenu * Time.deltaTime);
	
	}

	void funcaoJanela(int idJanela)
	{

		for (uint i=0; i<criature.meusTipos.Length; i++)
			GUI.Label (new Rect(posXrr+25f,posYr + 30f + 25 * (i),lmC,amC),
			           textos[0] +
			           criature.meusTipos [i],skin.label);

		
		for (uint i=0; i<criature.cAtributos.Length; i++) {
			GUI.Label (new Rect(posXrr+25f,posYr + 105f + 25 * (i+1),lmC,amC),
			           /*criature.cAtributos [i].Nome*/ textos[i+4] + " :   " +
			           criature.cAtributos [i].Corrente +
			           ((i == 0 || i == 1) ? " / " +
			 criature.cAtributos [i].Maximo : ""),skin.label);
		}

		/*
		GUI.Label (new Rect(posXrr+25f,posYr + 255,lmC,amC),
		           textos[1] + criature.tempoReacaoCorrente + " s",skin.label);
		           */
		
		GUI.Label (new Rect(posXrr+25f,posYr + 300f,lmC,amC),
		           "XP: " + criature.mNivel.XP + " / " + criature.mNivel.ParaProxNivel,skin.label
		           );

	}

	float lmC;
	float amC;

	void OnGUI()
	{
		posXr = posX * Screen.width;
		posYr = posY * Screen.height;
		aCr = aCaixa * Screen.height;
		lCr = lCaixa * Screen.width;


		lmC = 0.5f * lCr;
		amC = aCr * 0.1f;

		GUIStyle esseStyle = new GUIStyle (skin.box);
		esseStyle.alignment = TextAnchor.UpperCenter;

		Rect Aqui = new Rect (posXrr, posYr, lCr, aCr);


		GUI.Box (Aqui, textos[2] + criature.Nome + textos[3] +
		         criature.mNivel.Nivel, esseStyle);

		funcaoJanela (0);

		

	}
}
