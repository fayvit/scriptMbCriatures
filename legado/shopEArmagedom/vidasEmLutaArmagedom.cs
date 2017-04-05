using UnityEngine;
using System.Collections;

public class vidasEmLutaArmagedom : MonoBehaviour {

	public heroi H;
	public bool segundos = false;//os menus de vida que aparecem na segunda açao
	public HUDArmagedom hudA;
	public bool fechaSegundos = false;

	private int ultimaEscolha = -1;
	private int segundaEscolha = -1;
	private GameObject aCamera;
	private bool atualizacao = true;

	// Use this for initialization
	void Start () {
		aCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void deslizaOuFecha(GameObject G)
	{
		vidaEmLuta[] vidas = G.GetComponents<vidaEmLuta> ();
		foreach(vidaEmLuta vida in vidas )
			if(vida.n == H.criatureSai)
				Destroy(vida);
		else
			vida.fechaJanela();
	}

	public void trocando()
	{
		segundos = false;
		deslizaOuFecha(aCamera);
		segundaEscolha = -1;
		ultimaEscolha = -1;
		deslizaOuFecha(gameObject);
		atualizacao = false;
	}

	public void voltadoATrocar()
	{
		atualizacao = true;
	}

	public void fechaEsse()
	{
		deslizaOuFecha(gameObject);
		atualizacao = false;
		Destroy(this,1);
	}

	void OnGUI()
	{
		if(atualizacao){
		if(ultimaEscolha!= H.criatureSai)
		{
			deslizaOuFecha(gameObject);
			vidaEmLuta w  = gameObject.AddComponent<vidaEmLuta>();
			w.doMenu = H.criaturesAtivos[H.criatureSai];
			w.nomeVida = "escolha"+H.criatureSai.ToString();
			w.posX = 0.01f;
			w.posY = 0.78f;
			w.n = H.criatureSai;

			ultimaEscolha = H.criatureSai;
		}

		if(segundos == true && segundaEscolha!=hudA.escolha)
		{
			deslizaOuFecha(aCamera);
			vidaEmLuta w  = aCamera.AddComponent<vidaEmLuta>();
			w.doMenu = H.criaturesArmagedados[(int)hudA.escolha];
			w.nomeVida = "escolhaArmagedado"+hudA.escolha;
			w.posX = 0.35f;
			w.posY = 0.78f;
			w.n = (int)(hudA.escolha+H.criaturesAtivos.Count);
			
			segundaEscolha = (int)hudA.escolha;
		}

		if(fechaSegundos ==true){
			deslizaOuFecha(aCamera);
			fechaSegundos = false;
			segundaEscolha = -1;
			segundos = false;
		}
	}
	}
}
