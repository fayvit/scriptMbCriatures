using UnityEngine;
using System.Collections;

public class abaixoDeMenu : alternanciaEmLuta {

	public float posX = 0.6f;
	public float posY = 0.3f;
	public float aCaixa = 0.4f;
	public float lCaixa = 0.38f;

	public bool entrando = true;
	
	public GUISkin skin;
	
	protected float posXr;
	protected float posYr;
	protected float aCr;
	protected float lCr;
	protected float posXrr = Screen.width*2;
	protected float posYrr = Screen.height*1.5f;

	protected int qualBox = -1;


	protected float tempoDeMenu = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	protected void saidaDoMouseDoBox(Rect R)
	{
		if(!R.Contains(Event.current.mousePosition)&&qualBox>-1)
			qualBox=-1;
		
		//print(!R.Contains(Event.current.mousePosition));
		
	}
	
	protected bool entradaDoMouseNoBox(Rect R,int esseBox)
	{
		if(R.Contains(Event.current.mousePosition)&&qualBox!=esseBox){
//			print("QUALBOC: "+qualBox+" : "+esseBox);
			qualBox = esseBox;

			return true;
			
		}
		else
			return false;
	}

	protected void deslizar(bool emY = true,bool positivo = true)
	{
		int multiplicador = positivo?1:-1;
		if(emY)
		{
			if(entrando && posYrr != posYr)
				posYrr = Mathf.Lerp(posYrr,posYr,tempoDeMenu*Time.deltaTime);
			
			if(!entrando && posYrr != 2*multiplicador*Screen.height)
				posYrr = Mathf.Lerp(posYrr,2*multiplicador*Screen.height,Time.deltaTime);

			posXrr = posXr;
		}else
		{

			if(entrando && posXrr != posXr)
				posXrr = Mathf.Lerp(posXrr,posXr,tempoDeMenu*Time.deltaTime);
			
			if(!entrando && posXrr != 2*multiplicador*Screen.width)
				posXrr = Mathf.Lerp(posXrr,2*multiplicador*Screen.width,Time.deltaTime);
			
			posYrr = posYr;
		}


		posXr = posX*Screen.width;
		aCr = aCaixa*Screen.height;
		posYr = posY*Screen.height;
		lCr = lCaixa*Screen.width;
	}

	public void fechaJanela()
	{
		entrando = false;
		Destroy (this, 0.25f);
	}
}
