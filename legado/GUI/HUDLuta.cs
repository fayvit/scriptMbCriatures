using UnityEngine;
using System.Collections;

public class HUDLuta : abaixoDeMenu {

	public GUISkin destaque;

	public float tempoDeFuga = 10;
	
	protected float tempoAcumulado = 0;
	protected elementosDoJogo coisas;
	protected GUIStyle tempStyle;
	protected Texture2D texturaSacana;

	public void zeraTempo()
	{
		entrando = true;
		tempoAcumulado = 0;
	}

	protected void verificaFuga()
	{
		tempoAcumulado += Time.deltaTime;
		
		
		if(tempoAcumulado> tempoDeFuga && tempoDeFuga>0)
		{
			entrando = false;
			if(tempoAcumulado>tempoDeFuga+1)
				Destroy(this);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
