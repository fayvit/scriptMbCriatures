using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class leveAEscolhaInicial : MonoBehaviour {
	public int escolha = 0;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "planicieDeInfinity")
		{
			nomesCriatures nomeCriature=nomesCriatures.Florest;
			nomeIDitem nomeItem = nomeIDitem.regador;

			if(escolha==0){
				nomeCriature = nomesCriatures.Florest;
				nomeItem = nomeIDitem.regador;
			}

			if(escolha==1){
				nomeCriature = nomesCriatures.PolyCharm;
				nomeItem = nomeIDitem.gasolina;
			}

			if(escolha == 2 ){
				nomeCriature = nomesCriatures.Xuash;
				nomeItem = nomeIDitem.aguaTonica;
			}

			Transform T = GameObject.FindWithTag("Player").transform;

			heroi H = T.GetComponent<heroi>();

			H.criaturesAtivos = new List<Criature>(){new cCriature (nomeCriature).criature ()};
			H.criaturesArmagedados = new List<Criature>();
			H.cristais = 0;
			H.itens = new List<item>(){new item(nomeIDitem.maca),new item(nomeItem)};
			H.itens [0].estoque = 10;
			H.itens[1].estoque = 5;

			pausaJogo.pause = false;
			variaveisChave.valoresDefault();

			Destroy(GameObject.Find("CriatureAtivo"));
			
			print(H.ultimoArmagedom.posHeroi);
			T.position = H.ultimoArmagedom.posHeroi;
			T.GetComponent<movimentoBasico>().adicionaOCriature();

			GameObject.Find("Terrain").GetComponent<encontros>().proxEncontro = 30;

			Destroy(gameObject);
		}
	}
}
