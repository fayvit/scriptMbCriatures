using UnityEngine;
using System.Collections;

public class alternancia : MonoBehaviour {

	protected IA_inimigo IA = null;
	
	
	protected void paralisaInimigo()
	{
		GameObject Inimigo = GameObject.Find("inimigo");
		if(Inimigo)
		{
			if(IA == null)
				IA = Inimigo.GetComponent<IA_inimigo>();
			if(Inimigo.GetComponent<acaoDeGolpe>())
				Inimigo.GetComponent<acaoDeGolpe>().ativa = new pegaUmGolpe(nomesGolpes.cancelado).OGolpe();

			desabilitaIA();
			Invoke("desabilitaIA",0.25f);
		}
	}

	void desabilitaIA()
	{
		if(IA)
		{
			IA.podeAtualizar = false;
			IA.paraMovimento();
		}else
			Debug.LogWarning("IA do inimigo nao encontrada para desabilitar");
	}

	protected void deslizaOuFecha(GameObject G,int escolha)
	{
		vidaEmLuta[] vidas = G.GetComponents<vidaEmLuta> ();
		foreach(vidaEmLuta vida in vidas )
			if(vida.n == escolha+3)
				Destroy(vida);
		else
			vida.fechaJanela();
	}

	protected void mostraOSelecionado(GameObject G,Criature C,int escolha = 1)
	{
		vidaEmLuta w = G.AddComponent<vidaEmLuta>();
		w.negativo = true;
		w.doMenu = C;
		w.nomeVida = "escolha"+escolha.ToString();
		w.posX = 0.74f;
		w.posY = 0.01f;
		
		w.n = (int)escolha+3;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public static void olharEmLuta(Transform HT)
	{
		/*
			CODIGO TEMPORARIO
		 */
		GameObject C = GameObject.Find("CriatureAtivo");

		cameraPrincipal cam = C.GetComponent<cameraPrincipal>();
		if(cam)
			cam.enabled = false;
		movimentoBasico mB = C.GetComponent<movimentoBasico>();
		
		if(mB)
			mB.enabled = false;
		
		HT.rotation = Quaternion.LookRotation(
			Vector3.ProjectOnPlane(C.transform.position-HT.position,Vector3.up));
		/*
			FIM DELE
		 */
		Transform T = Camera.main.transform;
		T.position = HT.position
			+7*HT.forward
				+4*Vector3.up;
		
		T.LookAt(HT);
	}

	protected void olharEmLuta()
	{
		Transform HT = GameObject.FindWithTag("Player").transform;
		olharEmLuta(HT);
	
	}

	public static void focandoHeroi(bool tambemML = true)
	{
		Transform CameraP = Camera.main.transform;

		if(CameraP.GetComponent<HUDGolpes>())
		{
			CameraP.GetComponent<HUDGolpes>().fechaJanela();
		}
		
		if(CameraP.GetComponent<HUDCriatures>())
		{
			CameraP.GetComponent<HUDCriatures>().fechaJanela();
		}

		if(CameraP.GetComponent<HUDItens>())
		{
			CameraP.GetComponent<HUDItens>().fechaJanela();
		}

		if(tambemML)
		if(CameraP.GetComponent<mensagemEmLuta>())
		{
			CameraP.GetComponent<mensagemEmLuta>().fechaJanela();
		}
	}

	public void retornaAoHeroi()
	{
		GameObject heroi = GameObject.FindGameObjectWithTag("Player");

		focandoHeroi();

		cameraPrincipal cam =  heroi.GetComponent<cameraPrincipal> ();
		cam.enabled = true;
		cam.iniciou = true;

		heroi.GetComponent<movimentoBasico> ().enabled = true;

		
		cameraPrincipal camera = GetComponent<cameraPrincipal> ();
		Destroy (camera);
		
		GetComponent<sigaOLider> ().enabled = true;
		GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;

		
		movimentoBasico meuMovedor = GetComponent<movimentoBasico> ();

		menuInTravel2 mIT2 = Camera.main.GetComponent<menuInTravel2>();
		if(mIT2)
			mIT2.enabled = true;



		vidaEmLuta v = GameObject.Find("Terrain") .GetComponent<vidaEmLuta> ();
		if(v)
			v.fechaJanela();


		Destroy (meuMovedor);
		GetComponent<Animator>().SetBool("noChao",true);
	}

	public void aoCriature()
	{
		if (!GetComponent<cameraPrincipal> () ) {
			//umCriature criature = GetComponent<umCriature>();

			GameObject heroiX = GameObject.FindGameObjectWithTag ("Player");
			heroiX.AddComponent<gravidadeGambiarra>();
			Criature X = heroiX.GetComponent<heroi>().criaturesAtivos[0];
			movimentoBasico mB = heroiX.GetComponent<movimentoBasico> ();

			mB.enabled = false;

			heroiX.GetComponent<cameraPrincipal> ().enabled = false;
			
			cameraPrincipal cameraP = gameObject.AddComponent<cameraPrincipal> ();
			//print(criature+" : "+criature.X+" : "+criature.X.alturaCamera);
			cameraP.altura = X.alturaCamera;
			cameraP.distancia = X.distanciaCamera;

			cameraP.yMinLimit = -20;
//			cameraP.velocidadeMaxAngular = X.velocidadeMaxAngular;

			if(GetComponent<sigaOLider> ())
				GetComponent<sigaOLider> ().enabled = false;
			if(GetComponent<UnityEngine.AI.NavMeshAgent> ())
					GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;

			
			gameObject.AddComponent<movimentoBasico> ();

			menuInTravel2 mIT2 = Camera.main.GetComponent<menuInTravel2>();
			if(mIT2)
				mIT2.enabled = false;

			if(! heroi.emLuta && !variaveisChave.shift["TrocaGolpes"]){
				vidaEmLuta v = GameObject.Find("Terrain") .AddComponent<vidaEmLuta> ();
				v.minhaLuta = true;
				v.doMenu = GetComponent<umCriature>().X;
				v.nomeVida = "meuCriature";
				v.n = 2;
				v.posX = 0.74f;
				v.posY = 0.78f;
			}
		}	
	}

	/*

	void OnMouseDown()
	{
		if(transform.name == "CriatureAtivo")
			aoCriature();
	}*/
}