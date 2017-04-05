using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class escolhaInicial : MonoBehaviour {

	public GUISkin skin;
	public Texture2D[] texturaSacana;
	public Transform[] iniciaisModelos;


	private Vector3[] posicoesAlvo = new Vector3[4];

	private readonly List<List<string>> iniciais = new List<List<string>>()
	{new List<string>()
		{
			"<color=yellow>Florest</color>:\r\n Criature do tipo Planta",
			"Lamina de Folha\r\n tipo: Planta",
			"Garra\r\n tipo: Normal"

		},
	new List<string>()
		{
			"<color=yellow>PolyCharm</color>:\r\n Criature do tipo Fogo",
			"Bola de Fogo\r\n tipo: Fogo",
			"Garra\r\n tipo: Normal"
				
		},
	new List<string>()
		{
			"<color=yellow>Xuash</color>:\r\n Criature do tipo Agua",
			"Rajada de Agua\r\n tipo: Agua",
			"Tapa\r\n tipo: Normal"
				
		}};
	private tituloDaEscolha tit;
	private CriatureDaEscolhaInicial criI;

	private float testeDeEixo = 0;
	private int escolha = 0;

	// Use this for initialization
	void Start () {
		tit = gameObject.AddComponent<tituloDaEscolha>();
		tit.skin = skin;
		criI = gameObject.AddComponent<CriatureDaEscolhaInicial>();
		criI.skin = skin;
		criI.texturaSacana = texturaSacana;
		criI.textosDaki = iniciais[0].ToArray();
		for(int i=0;i<iniciaisModelos.Length;i++)
		{
			posicoesAlvo[i] = iniciaisModelos[i].position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		escolha = mudaDestaque(escolha,3);

		//if(escolha == 0)
		//{
		int X;
		for(int i=0;i<3;i++){
			X = (2*escolha+i)%3;
			print(X);
		iniciaisModelos[i].position = 
				Vector3.Lerp(iniciaisModelos[i].position,posicoesAlvo[X],5*Time.deltaTime);
		}

		if(Input.GetButtonDown("acaoAlt") ||Input.GetButtonDown("acao")|| Input.GetButtonDown("Submit"))
		{
			escolheEsse();
		}
		//}
	
	}

	void escolheEsse()
	{
		GameObject.Find("meLeveComVoce").GetComponent<leveAEscolhaInicial>().escolha = escolha;
		GameObject.Find("Canvas").GetComponentInChildren<Text>().enabled = true;
		Application.LoadLevel("planicieDeInfinity");
	}

	void voltaTit()
	{
		criI.textosDaki=iniciais[escolha].ToArray();
		criI.escolhido = escolha;
		criI.entrando = true;
	}



	public int mudaDestaque(int dest,int escol)
	{
		float v = Input.GetAxisRaw ("Horizontal");
		if(v>0f &&testeDeEixo==0){
			if(dest<escol-1)
				dest++;
		else
			dest = 0;
			criI.entrando = false;
			Invoke("voltaTit",0.5f);
		}
		if(v<0f && testeDeEixo == 0){
			if(dest>0)
				dest--;
		else
			dest = (int)escol-1;
			criI.entrando = false;
			Invoke("voltaTit",0.5f);
		}
		testeDeEixo = v;
		
		
		return dest;
		
	}

}
