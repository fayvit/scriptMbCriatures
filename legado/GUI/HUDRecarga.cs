using UnityEngine;
using System.Collections;

public class HUDRecarga : HUDLuta {

	public heroi H1;
	private GameObject criatureAtivo;
	private UnityEngine.AI.NavMeshAgent nav;

	void Start () {
		coisas = elementosDoJogo.el;
		skin = coisas.skin;
		destaque = coisas.destaque;

		posX = 0.01f;
		posY = 0.2f;
		aCaixa = 0.39f;
		lCaixa = 0.25f;

		posXrr = -2*Screen.width; 
		criatureAtivo = GameObject.Find("CriatureAtivo");
		nav = criatureAtivo.GetComponent<UnityEngine.AI.NavMeshAgent>();

	}

	// Update is called once per frame
	void Update () {
		if(nav)
		{
			if(nav.enabled)
				entrando = false;
			else
				entrando = true;
		}

		//verificaFuga();
	}

	void OnGUI()
	{
		bool retorno = false;

		deslizar(false,false);
		//GUI.Box(new Rect(posXrr,posYrr,lCr,aCr),"um teste",skin.box);
		Rect R;
		string mens;
		GUIStyle tempStyle = new GUIStyle(skin.label);
		GUIStyle tempStyle2 = new GUIStyle(skin.box);
		float quadradinho;
		tempStyle.alignment = TextAnchor.MiddleCenter;

		if(Time.time - H1.tempoDoUltimoUsoDeItem<H1.intervaloParaUsarItem  && heroi.emLuta)
		{
			R = new Rect(posXrr,posYrr,lCr,0.07f*Screen.height);
			mens = "Uso de item em tempo de Recarga "+comandos.mostradorDeTempo(
				H1.tempoDoUltimoUsoDeItem-(Time.time-H1.intervaloParaUsarItem));
			GUI.Box(R,"",skin.box);

			retorno = true;
			GUI.Label(R,mens,tempStyle);
		}

		golpe[] G = H1.criaturesAtivos[0].Golpes;
		for(int i=0;i<G.Length;i++)
		{
			if(G[i].UltimoUso -(Time.time-G[i].TempoReuso)>0)
			{
				R = new Rect(posXrr,posYrr+(0.08f+ 0.08f*i)*Screen.height,lCr,0.08f*Screen.height);
				mens = "Recarga \n\r "+comandos.mostradorDeTempo(
					G[i].UltimoUso -(Time.time-G[i].TempoReuso));
				GUI.Box(R,"",skin.box);
				retorno = true;

				quadradinho = Mathf.Min(0.06f*Screen.height,0.3f*lCr);

				R = new Rect(posXrr+0.01f*Screen.width,
				             posYrr+(0.09f+ 0.08f*i)*Screen.height,
				             quadradinho,
				             quadradinho);

				GUI.Box(R,"",skin.box);

				texturaSacana = coisas.retornaMini(G[i].Nome,"golpe");
				tempStyle2.normal.background  = texturaSacana;
				tempStyle2.hover.background = texturaSacana;
				tempStyle2.active .background = texturaSacana;



				R = new Rect(posXrr+0.01f*Screen.width+0.01f*quadradinho,
				             posYrr+(0.09f+ 0.08f*i)*Screen.height+0.01f*quadradinho,
				             0.98f*quadradinho,
				             0.98f*quadradinho);

				GUI.Box(R,"",tempStyle2);

				R = new Rect(posXrr+0.3f*lCr,posYrr+(0.09f+ 0.08f*i)*Screen.height,0.65f*lCr-0.02f*Screen.width,0.05f*Screen.height);
				GUI.Label(R,mens,tempStyle);
			}
		}

		if(!retorno)
		{
			fechaJanela();
		}
	}
}
