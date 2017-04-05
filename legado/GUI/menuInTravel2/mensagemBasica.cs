using UnityEngine;
using System.Collections;

public class mensagemBasica : abaixoDeMenu {
	public string mensagem;
	public string title = "";
	
	public GUISkin destaque;

	protected GUIStyle estiloTitulo;
	protected GUIStyle estiloTexto;

	private Vector2 sScroll=Vector2.zero;

	void Awake()
	{
		skin = elementosDoJogo.el.skin;
		destaque = elementosDoJogo.el.destaque;
		posY = 0.67f;
	}

	// Use this for initialization
	void Start () {
		posYr = posY * Screen.height;
		estiloTitulo = new GUIStyle (skin.box);
		estiloTexto = new GUIStyle (skin.label);
		estiloTexto.fontSize = 20;

		estiloTitulo.alignment = TextAnchor.UpperLeft;
		estiloTitulo.normal.textColor = Color.yellow;
		estiloTitulo.hover.textColor = Color.yellow;
		estiloTitulo.active.textColor = Color.yellow;
		estiloTitulo.focused.textColor = Color.yellow;


		if(title!= "")
			title = "\t\t\t\t\t\t" +title;
	}
	
	// Update is called once per frame
	void Update () {
		if(entrando && posYrr != posYr)
			posYrr = Mathf.Lerp (posYrr, posYr,tempoDeMenu*Time.deltaTime);

		if(!entrando && posYrr != Screen.height*1.5f)
			posYrr = Mathf.Lerp (posYrr, Screen.height*1.5f,tempoDeMenu*Time.deltaTime);
	}

	void OnGUI()
	{
		GUI.depth = -1;
		GUI.Box(new Rect(0.01f*Screen.width,posYrr,0.98f*Screen.width,0.3f*Screen.height),title, estiloTitulo );
		Rect R = new Rect (0.01f * Screen.width + 5f, posYrr + 35f, 0.98f * Screen.width - 10f, 0.3f * Screen.height - 40f);
		GUILayout.BeginArea (R);
		sScroll = GUILayout.BeginScrollView (sScroll,GUILayout.Width(R.width),GUILayout.Height(R.height));
		GUILayout.Label (mensagem,estiloTexto);
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();

	}
}
