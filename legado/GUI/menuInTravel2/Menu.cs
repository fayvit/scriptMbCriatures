using UnityEngine;
using System.Collections;

public class Menu : abaixoDeMenu {

	public float posXalvo = 0;
	public float posYalvo = 0;
	public float lMenu = 0.1f;
	public float aMenu = 0.1f;
	//public float aOpcao = 0.01f;
	public string[] opcoes;
	public uint limiteOpcoes = 0;
	public float tempoDeFuga = 3f;
	public bool podeMudar = true;
	public uint escolha = 0;
	public float maxHeight;
	public float sobraAbaixo = 0;
	
	public GUISkin destaque;

	protected string nome = "";
	protected float testeDeEixo = 0f;
	
	
	protected int deslocamentoMenu = 0;
	protected float deslizador = 0;

	float larg;

	void Start () {
		posXr = -Screen.width;
	}
	
	// Update is called once per frame
	void Update () {

		if (entrando && posX != posXr)
						posXr = Mathf.Lerp (posXr, posX, tempoDeMenu * Time.deltaTime);

		if(!entrando && posXr != -Screen.width)
			posXr = Mathf.Lerp (posXr, -Screen.width, (tempoDeFuga) * Time.deltaTime);

		if(podeMudar&& !pausaJogo.pause)
		{
			escolha = mudaDestaque(escolha,opcoes.Length);
		}
	}

	public Menu detalhesBase(Menu menu,string nome,string[] opcoes, GUISkin SSkin, GUISkin DDestaque )
	{
		menu.opcoes = opcoes;
		menu.posXalvo = 0.22f;
		menu.lMenu = 0.2f;	
		menu.Nome = nome;
		menu.skin = SSkin;
		menu.destaque = DDestaque;
		return menu;
	}

	public void setaDetalhes(string nome,string[] opcoes,float posXalvo,float posYalvo,float lMenu,float aMenu)
	{
		this.opcoes = opcoes;
		this.posXalvo = posXalvo;
		this.posYalvo = posYalvo;
		this.lMenu = lMenu;	
		this.aMenu = aMenu;	
		this.Nome = nome;
		this.skin = elementosDoJogo.el.skin;
		this.destaque = elementosDoJogo.el.destaque;
	}



	void OnGUI()
	{
		maxHeight = (0.99f-posYalvo - sobraAbaixo)*Screen.height;
		larg = lMenu * Screen.width;
		float alt = aMenu * Screen.height;
		float altOpcao = (alt - (opcoes.Length+1)*5f)/opcoes.Length;

		posX = posXalvo * Screen.width;
		posY = posYalvo * Screen.height;	
		/*doScroll = 
			GUI.BeginScrollView(new Rect(posXr,posY,larg+0.03f*Screen.width,maxHeight),
			         doScroll,
		            new Rect(posXr,posY,larg,alt));
		GUI.Box (new Rect(posXr,posY,larg,alt),"",skin.box);

		for(int i=0;i<opcoes.Length;i++)
		{
			GUI.Box (new Rect(posXr +5f ,posY+(5f +altOpcao)*i+5f,larg - 10f,altOpcao), opcoes[i],(escolha == i) ? destaque.box : skin.box);
		}

		GUI.EndScrollView();*/

		Rect R = new Rect(posXr,posY,larg+0.03f*Screen.width,maxHeight);
		GUILayout.BeginArea(R);
		R.x = 0;R.y = 0;
		saidaDoMouseDoBox(R);

		deslizador = Mathf.Lerp(deslizador,-deslocamentoMenu*(altOpcao+5f),2*Time.deltaTime);
		GUI.Box (new Rect(0,deslizador ,larg,alt),"",skin.box);
		
		for(int i=0;i<opcoes.Length;i++)
		{
			R = new Rect(5f ,
			             (5f +altOpcao)*i +deslizador +5f,
			             larg - 10f,
			             altOpcao);
			GUI.Box (R, opcoes[i],(escolha == i) ? destaque.box : skin.box);
			//if(R.Contains(Event.   current.mousePosition ))
			//	escolha = (uint)i;
			//if(podeMudar)
			//	print(i+" : "+entradaDoMouseNoBox(R,i));
			if(entradaDoMouseNoBox(R,i)&&podeMudar)
				escolha = (uint)i;
		}

		if((altOpcao+5f)*(escolha-deslocamentoMenu+1) > maxHeight)
		{
			deslocamentoMenu++;
		}

		if((altOpcao+5f)*(escolha-deslocamentoMenu) < 0)
		{
			deslocamentoMenu--;
		}
		GUILayout.EndArea();
	}

	public int dentroOuFora()
	{
//		Rect R = new Rect(posXr,posY,larg+0.03f*Screen.width,maxHeight);
		
		if(qualBox>-1)
			escolha = (uint)qualBox;

		return qualBox;
	}

	public uint mudaDestaque(uint dest,int escol)
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
			dest = (uint)escol-1;
		testeDeEixo = v;
		
		
		return dest;
		
	}

	public string Nome
	{
		get{return nome;}
		set{nome = value;}
	}
}
