using UnityEngine;
using System.Collections;

public class pauseBase : abaixoDeMenu{
	/*
	public float posX = 0.4f;
	public float posY = 0.2f;
	public float larg = 0.2f;
	public float alt = 0.1f;

	protected float posXr = -Screen.width;
	protected float posXrr;
	protected float posYrr;
	protected float posYr;


	protected float largr;
	protected float altr;
	protected float tempoDePause = 0;
	protected float altBox;
	protected string[] opcoes = new string[4];
	*/

	protected new void deslizar(bool emY = true,bool positivo = true)
	{
		int multiplicador = positivo?1:-1;
		if(emY)
		{
			if(entrando && posYrr != posYr)
				posYrr = Mathf.Lerp(posYrr,posYr,tempoDeMenu);
			
			if(!entrando && posYrr != 2*multiplicador*Screen.height)
				posYrr = Mathf.Lerp(posYrr,2*multiplicador*Screen.height,1);
			
			posXrr = posXr;
		}else
		{
			
			if(entrando && posXrr != posXr)
				posXrr = Mathf.Lerp(posXrr,posXr,tempoDeMenu);
			
			if(!entrando && posXrr != 2*multiplicador*Screen.width)
				posXrr = Mathf.Lerp(posXrr,2*multiplicador*Screen.width,0.05f);
			
			posYrr = posYr;
		}
		
		
		posXr = posX*Screen.width;
		aCr = aCaixa*Screen.height;
		posYr = posY*Screen.height;
		lCr = lCaixa*Screen.width;
	}
}
