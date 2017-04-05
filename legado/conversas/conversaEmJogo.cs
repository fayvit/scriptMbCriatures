using UnityEngine;
using System.Collections;

public class conversaEmJogo : verificaTrocaMens {


	[HideInInspector] public bool evento = false;

	public float distanciaDeFala = 3;
	public bool olheAoFalar = true;
	
	protected Transform tHeroi;
	protected bool iniciou;

	private movimentoBasico mB;
	private GUISkin skin;
	private menuInTravel2 mIT2;
	private caminheAteOAlvo caminhada;
	private bancoDeTextos bTex;




	// Use this for initialization

	public int numeroDeMensagens
	{
		get{return essaConversa.Length;}
	}

	public void colocaIndiceZero()
	{
		atualizaIndiceDeConversa();
		mens.mensagem = essaConversa[0];
	}



	void Start () {
		mIT2 = GameObject.Find("Main Camera").GetComponent<menuInTravel2>();
		skin = mIT2.skin;
		caminhada = GetComponent<caminheAteOAlvo>();
		tHeroi = GameObject.FindWithTag("Player").transform;
		mB = tHeroi.GetComponent<movimentoBasico>();
		atualizaIndiceDeConversa();

	}
	
	// Update is called once per frame
	void Update () {
		if((tHeroi.position-transform.position).sqrMagnitude<100)

		if(!evento){
		if(
			(tHeroi.position-transform.position).sqrMagnitude<distanciaDeFala
		   && !iniciou
		   && mB.enabled == true
		   && mB.podeAndar == true
		   )
		{
			if(mB.podeAndar)
			{
				if((Input.GetButtonDown("acao")||Input.GetButtonDown("acaoAlt")) && mens == null)
				{
					iniciaConversa();
					iniciou = true;
				}
			}
		}else if(iniciou){

			if(Input.GetButtonDown("paraCriature"))
				finalisaConversa();

				facaTrocaMens();
		}
		}
	}

	public override void finalisaConversa()
	{

		mIT2.enabled = true;
		if(caminhada)
			caminhada.enabled = true;
		mens.fechaJanela();
		iniciou = false;
		Invoke("unitySacana",0.25f);
		mensagemAtual = 0;
	}
	


	void unitySacana()
	{
		mB.podeAndar = true;
	}





	void iniciaConversa()
	{
		mB.podeAndar = false;
		mIT2.enabled = false;
		if(caminhada)
			caminhada.pareACaminhada();

		if(olheAoFalar)
		{
			Vector3 olhe = new Vector3((tHeroi.position - transform.position).x,
		                           0,
		                           (tHeroi.position - transform.position).z);
			transform.rotation = Quaternion.LookRotation(olhe);
			tHeroi.rotation  = Quaternion.LookRotation(-olhe);
		}
		mens = gameObject.AddComponent<mensagemBasica>();
		mens.mensagem = essaConversa[0] ;
		mensagemAtual = 0;
		mens.skin = skin;
		mens.posY  = 0.68f;

	}

	public void atualizaIndiceDeConversa(string novoIndice,int numIndice)
	{
		atualizaIndiceDeConversa(novoIndice);
		mens.mensagem = essaConversa[numIndice];
	}

	public void atualizaIndiceDeConversa(string novoIndice)
	{
		indiceDaConversa = novoIndice;
		atualizaIndiceDeConversa();
	}

	public void atualizaIndiceDeConversa()
	{
		essaConversa = bancoDeTextos.falacoes[heroi.lingua][indiceDaConversa].ToArray();
	}
}
