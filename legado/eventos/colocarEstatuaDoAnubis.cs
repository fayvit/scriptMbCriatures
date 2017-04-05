using UnityEngine;
using System.Collections;

public class colocarEstatuaDoAnubis : MonoBehaviour {

	public GameObject estatua;
	public Transform portaDaPiramide;
	public Transform baseDaPorta;
	public MeshCollider coliderDoTransporte;
	public mudeCena paraAPiramide;

	private string[] mensagensDaQui;
	private estadoEstatuaAnubis estado = estadoEstatuaAnubis.estadoNulo;
	private mensagemBasica mens;
	private movimentoBasico mB;
	private menuInTravel2 mIT2;
	private cameraPrincipal cam;
	private bool podeAvancar = true;
	private GameObject col;
	// Use this for initialization

	public enum estadoEstatuaAnubis
	{
		mensagemDeColocando,
		abreAPorta,
		mensagemDePortaAbriu,
		olhouABase,
		estadoNulo
	}
	void Start () {
		col = GameObject.FindWithTag("Player");
		/*
		if(variaveisChave.shift["colocouEstatuaDoAnubis"])
			estatua.SetActive(true);
		else
			estatua.SetActive(false);
			*/

		mensagensDaQui = bancoDeTextos.falacoes[heroi.lingua]["estatuaMisteriosa"].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(col.transform.position,transform.position)<4)
		{
			CoreanProximo();
		}

		switch(estado)
		{
		case estadoEstatuaAnubis.mensagemDeColocando:
			if(encontros.botoesPrincipais()&&podeAvancar)
			{
				mens.entrando = false;
				estado = estadoEstatuaAnubis.abreAPorta;

			}
			podeAvancar = true;
		break;
		case estadoEstatuaAnubis.abreAPorta:
			variaveisChave.shift["colocouEstatuaDoAnubis"] = true;
			estatua.SetActive(true);
			coliderDoTransporte.enabled = true;
			paraAPiramide.enabled = true;

			/*
			Vector3 V = portaDaPiramide.position-4*Vector3.up;

			for(int i = 0;i<5;i++)
			{
				Destroy(Instantiate(
					elementosDoJogo.el.retorna("poeiraAoVento"),
					V+i*2*Vector3.forward,
					Quaternion.identity
					),2);
				Destroy(Instantiate(
					elementosDoJogo.el.retorna("poeiraAoVento"),
					V-i*2*Vector3.forward,
					Quaternion.identity
					),2);
			}
			if(Vector3.Angle(portaDaPiramide.up,Vector3.up)>1)
				portaDaPiramide.RotateAround(baseDaPorta.position,Vector3.forward,25*Time.deltaTime);
			else{*/

			if(!abrePortaInterna.estouAbrindoAPorta(portaDaPiramide,baseDaPorta))
			{
				estado = estadoEstatuaAnubis.mensagemDePortaAbriu;
				if(!mens)
					mens = gameObject.AddComponent<mensagemBasica>();
				
				mens.mensagem = mensagensDaQui[1];
				mens.entrando = true;
			}

		break;
		case estadoEstatuaAnubis.mensagemDePortaAbriu:
			if(encontros.botoesPrincipais()&&podeAvancar)
			{
				retornaPadraoJogo();

			}
			podeAvancar = true;
		break;
		case estadoEstatuaAnubis.olhouABase:
			if(encontros.botoesPrincipais()&&podeAvancar)
				retornaPadraoJogo();

			podeAvancar = true;
		break;
		}


	}

	void retornaPadraoJogo()
	{
		if(mens)
			mens.fechaJanela();

		if(!mB)
			mB = GameObject.FindWithTag("Player").GetComponent<movimentoBasico>();
		
		if(!cam)
			cam = GameObject.FindWithTag("Player").GetComponent<cameraPrincipal>();

		if(!mIT2)
			mIT2 = GameObject.FindWithTag("Main Camera").GetComponent<menuInTravel2>();


		mB.enabled = true;
		cam.enabled = true;
		mIT2.enabled = true;
		estado = estadoEstatuaAnubis.estadoNulo;
	}

	void padraoMensagem(GameObject col)
	{
		podeAvancar = false;

		if(!mens)
			mens = gameObject.AddComponent<mensagemBasica>();
		
		mIT2 = Camera.main.transform.GetComponent<menuInTravel2>();
		mIT2.enabled = false;

		cam = col.GetComponent<cameraPrincipal>();
		cam.enabled = false;
		mB.enabled = false;
		mB.pararOHeroi();
	}

	void CoreanProximo()
	{

		if(Input.GetButtonDown("acao"))
		{
			mB = col.GetComponent<movimentoBasico>();
			if(mB.enabled && mB.podeAndar)
			{
				if(!variaveisChave.shift["colocouEstatuaDoAnubis"])
				{
					heroi H = col.GetComponent<heroi>();
					if(shopBasico.temItem(nomeIDitem.estatuaMisteriosa,H)>-1)
					{
						estado = estadoEstatuaAnubis.mensagemDeColocando;
						padraoMensagem(col);
						mens.mensagem = mensagensDaQui[0];
						acaoDeItem2.retiraItem(nomeIDitem.estatuaMisteriosa,1,H);
					}else
					{
						padraoMensagem(col);
						mens.mensagem = mensagensDaQui[2];
						estado = estadoEstatuaAnubis.olhouABase;
					}
				}else
				{
					padraoMensagem(col);
					mens.mensagem = mensagensDaQui[3];
					estado = estadoEstatuaAnubis.olhouABase;
				}
			}
		}

	}

	public void LigaEstatua()
	{
		estatua.SetActive(true);
		portaDaPiramide.RotateAround(baseDaPorta.position,Vector3.forward,90);
	}
}