using UnityEngine;
using System.Collections;

public class alternanciaEmLuta : alternancia {

	private Animator a;
	private Vector3 aux;
	private uint fase = 0;
	private heroi H;
	private GameObject Terra;
	private bool movendoComCriature;
	private bool invocou;

	protected void fechaVidaEmLuta()
	{
		if(Terra==null)
			Terra = GameObject.Find("Terrain");

		vidaEmLuta[] V = Terra.GetComponents<vidaEmLuta>();
		foreach(vidaEmLuta v in V)
			v.fechaJanela();
	}
	// Use this for initialization
	void Start () {
		H = GetComponent<heroi>();
		focandoHeroi();
		paralisaInimigo();
		Terra = GameObject.Find("Terrain");
		GameObject G = GameObject.Find("CriatureAtivo");
		statusTemporarioBase.statusAoGerente(G,H.criatureSai);
		aux = G.transform.position;

		movendoComCriature = (bool)G.GetComponent<movimentoBasico>();
		olharEmLuta();


		if(!movendoComCriature){
			movimentoBasico mB =  GetComponent<movimentoBasico>();
			mB.pararOHeroi();
			mB.enabled = false;
			menuInTravel2 mIT2 =  GameObject.Find("Main Camera").GetComponent<menuInTravel2>();
			if(mIT2)
				mIT2.enabled = false;
		}

		a = GetComponent<Animator>();
		a.SetBool("chama",true);

		gameObject.AddComponent<animaTroca>();



	}

	public static void pararOCriature(Transform T)
	{
		Animator animator = T.GetComponent<Animator>();
		animator.SetFloat("velocidade",0);
	}

	public static void pararOCriature(GameObject G,Animator animator)
	{
		animator.SetFloat("velocidade",0);
		pararOCriature(G);
	}

	public static void pararOCriature(GameObject G)
	{
		G.GetComponent<sigaOLider>().enabled = false;
		G.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GetComponent<animaTroca>()&& fase ==0)
		{
			//GameObject meuHeroi = GameObject.FindGameObjectWithTag("Player");
			//Animator animator = meuHeroi.GetComponent<Animator> ();
			a.SetBool("envia",true);
			
			animaEnvia E = gameObject.AddComponent<animaEnvia>();
			E.posCriature = aux;
			H = GetComponent<heroi>();
//			print(H.criatureSai);

			Criature aux2 = H.criaturesAtivos[0];
			H.criaturesAtivos [0] = H.criaturesAtivos [H.criatureSai];
			H.criaturesAtivos [H.criatureSai] = aux2;

			E.oInstanciado = H.criaturesAtivos[0].nomeID;

			vidaEmLuta[] V = Terra.GetComponents<vidaEmLuta>();
			foreach(vidaEmLuta v in V)
				if(v.nomeVida == "meuCriature")
					v.fechaJanela();


			fase = 1;
		}

		if(fase ==1 && GameObject.Find("CriatureAtivo"))
		{

			if(movendoComCriature){

			cameraPrincipal cam = null;
			GameObject G = GameObject.Find("CriatureAtivo");

	
				pararOCriature(G);

			if(!G.GetComponent<movimentoBasico>())
				G.AddComponent<movimentoBasico>();

			if(!G.GetComponent<cameraPrincipal>())
				cam = G.AddComponent<cameraPrincipal>();


			Criature X = G.GetComponent<umCriature>().criature();

			//if(GameObject.Find("inimigo")){

				vidaEmLuta v = Terra.AddComponent<vidaEmLuta> ();
				v.doMenu = X;
				v.minhaLuta = true;
				v.nomeVida = "meuCriature";
				v.n = 2;
				v.posX = 0.74f;
				v.posY = 0.78f;
			

			cam.altura = X.alturaCamera;
			cam.distancia = X.distanciaCamera;
			cam.yMinLimit = -20;
			
//			cam.velocidadeMaxAngular = X.velocidadeMaxAngular;

			if(GameObject.Find("inimigo"))
				cam.luta = true;

				Destroy(this);

			}else if(!invocou){
				Invoke("voltaHeroi",1);
				invocou = true;
			}
			a.SetBool("chama",false);
			a.SetBool("envia",false);
			if(IA !=  null){
				IA.podeAtualizar = true;
			}

		}
	}

	void voltaHeroi()
	{
		GetComponent<cameraPrincipal>().enabled = true;
		if(!GetComponent<movimentoBasico>().enabled)
			GetComponent<movimentoBasico>().enabled = true;
		menuInTravel2 mIT2 = GameObject.Find("Main Camera").GetComponent<menuInTravel2>();
		if(mIT2)
			mIT2.enabled = true;
		//a.CrossFade("padrao",0.25f);
		Destroy(this,1.1f);
	}
}
