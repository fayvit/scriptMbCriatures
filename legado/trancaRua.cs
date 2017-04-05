using UnityEngine;
using System.Collections;

public class trancaRua : MonoBehaviour {
	public string chaveMensagem = "trancaRua";
	private bool falouEDisse = false;
	private bool falando = false;
	private mensagemBasica mens;
	private movimentoBasico mB;
	private menuInTravel2 mIT2;
	private string mensagemDaqui;
	// Use this for initialization
	void Start () {
		mensagemDaqui = bancoDeTextos.falacoes[heroi.lingua][chaveMensagem][0];
		mIT2 = GameObject.Find("Main Camera").GetComponent<menuInTravel2>();
	}
	
	// Update is called once per frame
	void Update () {
		if(falando)
		{
			if(mens!=null)
				if(Input.GetButtonDown("acao")||Input.GetButtonDown("menu e auxiliar"))
				{
					mens.fechaJanela();
					if(mB!=null)
						mB.enabled = true;
					mIT2.enabled = true;
					falando = false;
				}
		}

	}

	void retornaFalouEDisse()
	{
		falouEDisse = false;
	}



	void  OnTriggerEnter(Collider hit)
	{
		//print(hit.gameObject.tag);
		if((hit.gameObject.tag == "Player"  || hit.gameObject.tag == "Criature")
		   &&
		   !falouEDisse
		   &&
		   hit.transform.name!="inimigo")
		{
			bool vai = true;
			if(hit.transform.name == "CriatureAtivo")
				if(GameObject.Find("inimigo"))
					vai = false;

			if(vai){
				falouEDisse = true;
				falando = true;
				mIT2.enabled = false;
				if(hit.gameObject.GetComponent<movimentoBasico>())
					mB = hit.gameObject.GetComponent<movimentoBasico>();
				mB.pararOHeroi();
				mB.enabled = false;
				mens = gameObject.AddComponent<mensagemBasica>();
				mens.posY = 0.68f;
				mens.skin = mIT2.skin;
				mens.mensagem = mensagemDaqui;
				Invoke("retornaFalouEDisse",30);
			}
		}
			//print("colidi2 "+hit.gameObject);
	}
}
