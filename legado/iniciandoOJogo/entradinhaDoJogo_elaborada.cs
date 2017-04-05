using UnityEngine;
using System.Collections;

public class entradinhaDoJogo_elaborada : MonoBehaviour {
	private string[] essaConversa;
	private bool invocando = false;
	private mensagemBasica mens;
	private int mensagemAtual;

	private pretoMorte p; 
	private bool finalisou = false;

	public GUISkin skin;
	// Use this for initialization
	void Start () {
//		skin = elementosDoJogo.el.skin;
		essaConversa = bancoDeTextos.falacoes[heroi.lingua]["entradinha_elaborada"].ToArray();
		mens = gameObject.AddComponent<mensagemBasica>();
		mens.mensagem = essaConversa[0] ;
		mensagemAtual = 0;
		mens.skin = skin;
		mens.posY  = 0.68f;
		//mens.title = "Caesar Palace";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("acaoAlt") ||Input.GetButtonDown("acao") || Input.GetButtonDown("menu e auxiliar"))
		{
			if(!invocando){
				mens.entrando = false;
				Invoke("proximaMens",0.15f);
				invocando  =true;
			}
		}
	}



	void finalisaConversa()
	{
		if(!finalisou){
		p = gameObject.AddComponent<pretoMorte>();
		mens.fechaJanela();
		//Destroy(this);
		Invoke("clareiaIsso",2);
			finalisou = true;
		}
	}

	void ligaAquilo()
	{
		escolhaInicial I =  GetComponent<escolhaInicial>();
		I.enabled = true;
		Destroy(this);
	}

	void clareiaIsso()
	{
		Transform T = Camera.main.transform;
		T.parent = GameObject.Find("camera2").transform;
		T.localPosition = Vector3.zero;
		T.localRotation = Quaternion.identity;
		p.entrando = false;
		Invoke("ligaAquilo",0.75f);
	}

	void proximaMens()
	{
		if(mensagemAtual+1<essaConversa.Length)
		{
			mensagemAtual++;
			mens.mensagem = essaConversa[mensagemAtual];
			mens.entrando = true;
		}else
			finalisaConversa();
		/*
		switch(mensagemAtual)
		{
		case 2:
		case 1:
			mens.title = "\t\t\t Cesar Corean";
		break;
		default:
			mens.title = "\t\t\t\t\t\t Caesar Palace";
		break;
		}*/

		invocando = false;
	}
}
