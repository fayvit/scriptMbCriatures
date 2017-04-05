using UnityEngine;
using System.Collections;

public class inimigoUsaItem : acaoDeItem2 {

	private movimentoBasico mB;
	private cameraPrincipal cam;


	// Use this for initialization
	void Start () {
		//textos = bancoDeTextos.falacoes[heroi.lingua]["itens"].ToArray();
		GameObject C = GameObject.Find("CriatureAtivo");

		mB = C.GetComponent<movimentoBasico>();
		mB.enabled = false;
		cam = C.GetComponent<cameraPrincipal>();
		cam.enabled = false;

		IA = GetComponent<IA_inimigo>();
		IA.paraMovimento();
		IA.podeAtualizar = false;
		IA.enabled = false;

		elementos = elementosDoJogo.el;


		acaoAtual = "comecouTudo";
		tempoDeMenu = 0;
	
	}

	void oQFazer()
	{
		switch(nomeItem)
		{
		case nomeIDitem.pergaminhoDePerfeicao:
			// tiNHA UM CONTRA TREINADOR AQUI... NAO SEI PQ
				animaUsaItem();
				restauraPerfeicao();
				

			break;
		}
	}

	void restauraPerfeicao()
	{
		umCriature umC = GetComponent<umCriature>();
		umC.X.cAtributos[0].Corrente = umC.X.cAtributos[0].Maximo;
		umC.X.cAtributos[1].Corrente = umC.X.cAtributos[1].Maximo;
	}

	protected void animaUsaItem(string animacao = "acaoDeCura1"){

			escondeTodosMenus();
			//tempoDeAcao = 0;
						
			giraCameraCriature(transform);
			acaoAtual = "animandoVida";
			instancieEDestrua(elementos.retorna (animacao),transform.position,1);
			

	}

	void retornaPadraoLuta()
	{
		//Animator animator = GetComponent<Animator>();
		//animator.SetBool("chama",false);
		Destroy(GetComponent<centralizaEGiraCamera>());

		if(IA)
		{
			IA.enabled = true;
			IA.retornaIA();
			IA.retornaOMovimento();
		}
		
		if(mB)
			mB.enabled = true;
		else if(!heroi.emLuta)
		{
			GameObject G = GameObject.FindWithTag("Player");
			G.GetComponent<movimentoBasico>().enabled = true;
			G.GetComponent<cameraPrincipal>().enabled = true;
			G.GetComponent<Animator>().CrossFade("padrao",0.5f);
			GameObject.Find("Main Camera").GetComponent<menuInTravel2>().enabled = true;
		}
		
		//cameraPrincipal cam = C.GetComponent<cameraPrincipal>();
		if(cam)
			cam.enabled = true;
	}
	
	// Update is called once per frame

	void Update () {
		tempoDeMenu+=Time.deltaTime;
		switch(acaoAtual)	
		{
		case "comecouTudo":
			if(tempoDeMenu>0.5f)
			{
				oQFazer();
			}
		break;
		case "animandoVida":
			if(tempoDeMenu>4f)
				acaoAtual = "finalisaUsaItem";
		break;
		case "finalisaUsaItem":
			retornaPadraoLuta();
			Destroy(this);
		break;
		}
	}

}
