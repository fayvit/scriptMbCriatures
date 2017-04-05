using UnityEngine;
using System.Collections;

public class menuDePausa : pauseBase {

	private float testeDeEixo = 0f;

	public bool podeMudar = true;
	public int escolha = 0;
	public string[] opcoes;
	public GUISkin destaque;

	// Use this for initialization
	void Start () {
		tempoDeMenu = 0.1f;
		posXrr = -Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if(podeMudar)
		{
			escolha = mudaDestaque(escolha,opcoes.Length);
		}
	}

	public int dentroOuFora()
	{
		//		Rect R = new Rect(posXr,posY,larg+0.03f*Screen.width,maxHeight);
		
		if(qualBox>-1)
			escolha = qualBox;
		
		return qualBox;
	}

	void OnGUI()
	{
		GUI.depth = -2;
		deslizar(false,false);
		Rect R = new Rect(posXrr,posYrr,lCr,aCr*opcoes.Length+(opcoes.Length+1)*0.01f*Screen.height);
		GUI.Box(R,"",skin.box);
		saidaDoMouseDoBox(R);
		for(int i=0;i<opcoes.Length;i++)
		{
			R = new Rect(posXrr+0.01f*Screen.width,
			                  posYrr+0.01f*Screen.height+i*(aCr+0.01f*Screen.height),				                 
			                  lCr-0.02f*Screen.width,
			                  aCr);
			if(entradaDoMouseNoBox(R,i)&&podeMudar)
				escolha = i;
			GUI.Box(R,opcoes[i],escolha==i? destaque.box : skin.box);
		}
	}

	public int mudaDestaque(int dest,int escol)
	{
		float v = Input.GetAxisRaw ("Vertical") ;
		if(v<0f &&testeDeEixo==0)
			if(dest<escol-1)
				dest++;
		else
			dest = 0;
		if(v>0f && testeDeEixo == 0)
			if(dest>0)
				dest--;
		else
			dest = escol-1;
		testeDeEixo = v;
		
		
		return dest;
		
	}
}
