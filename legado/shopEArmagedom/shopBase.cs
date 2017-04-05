using UnityEngine;
using System.Collections;

public class shopBase : MonoBehaviour {

	protected bool noLugar = false;
	protected bool acao = false;
	protected bool menuEAux = false;
	protected mensagemBasica mens;
	protected GUISkin skin;
	protected GUISkin destaque;
	protected menuInTravel2 mIT2;
	protected heroi H;
	protected movimentoBasico mB;
	protected Transform T;
	protected string[] conversa;
	protected string[] simOuNao;
	protected Menu menu;
	protected Menu menu2;
	protected mensagemEmLuta mL;
	protected string estado = "emEspera";
	protected cameraPrincipal cam;
	protected GameObject G;


	// Use this for initialization
	protected void Start () {
		G = GameObject.Find("Main Camera");
		//pJ = G.GetComponent<pausaJogo>();
		mIT2 = G.GetComponent<menuInTravel2>();
		T = GameObject.FindWithTag("Player").transform;
		mB = T.GetComponent<movimentoBasico>();
		cam = T.GetComponent<cameraPrincipal>();
		H = T.GetComponent<heroi>();
		skin = mIT2.skin;
		destaque = mIT2.destaque;
		simOuNao = bancoDeTextos.falacoes[heroi.lingua]["simOuNao"].ToArray();
	}

	protected void voltaAPasseio()
	{
		cam.enabled = true;
		mens.fechaJanela();
		if(menu2!= null)
			menu2.fechaJanela();
		menu.fechaJanela();
		mL.fechaJanela();
		mIT2.enabled = true;
		mB.podeAndar = true;
		estado = "emEspera";
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
