using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mudeCena : MonoBehaviour {

	public Vector3 posicao;
	public string nomeCena;
	public float olhePraLa;


	private string cenaAtual;
	private heroi H;

	/*
		variaveis la de baixo
	 */

	private bool adicionou = false;
	private List<item> itensAqui;
	private List<Criature> ativosAqui;
	private List<Criature> armagedadosAqui;
	private uint cristaisAqui;
	private float tempoNoJogo;
	private int oqSai;
	private int oqUsa;
	private UltimoArmagedom ultArm;

	/*--------------------------------------*/

	// Use this for initialization
	void Start () {
		cenaAtual = Application.loadedLevelName;

	}

	public void guardeValoresEMudeDeCena()
	{
		
		GameObject G = GameObject.FindWithTag("Player");
		H = G.GetComponent<heroi>();
		
		itensAqui =  H.itens ;
		ativosAqui =  H.criaturesAtivos;
		armagedadosAqui =  H.criaturesArmagedados;
		cristaisAqui = H.cristais;
		oqSai = H.criatureSai;
		oqUsa = H.itemAoUso;
		ultArm = H.ultimoArmagedom;
		
		
		print(Time.time+"um");
		

		Application.LoadLevel(nomeCena);
	}

	void coloqueOsValoresGuardados()
	{
		GameObject G = GameObject.FindWithTag("Player");
		if(G)
		{
		encontros e = GameObject.Find("Terrain").GetComponent<encontros>();
		if(e)
			e.enabled = false;
		

			H = G.GetComponent<heroi>();

			G.transform.rotation = Quaternion.Euler(0,olhePraLa,0);
			G.transform.position = posicao;
			
			H.itens = itensAqui  ;
			H.criaturesAtivos = ativosAqui;
			H.criaturesArmagedados = armagedadosAqui ;
			H.cristais = 	cristaisAqui;
			H.criatureSai = oqSai;
			H.itemAoUso = oqUsa;
			H.ultimoArmagedom = ultArm;
		

			Destroy(GameObject.Find("CriatureAtivo"));
			//zeraUltimoUso(H);
			G.GetComponent<movimentoBasico>().adicionaOCriature();
			print("2: "+Time.time);
			
			if(e)
			{
				e.zeraPosAnterior();
				e.enabled = true;
			}
		}else
			Debug.LogWarning("O GameObject do heroi nao foi encontrado");

	}
	
	// Update is called once per frame
	void Update () {
		string ahVah = Application.loadedLevelName;

		if(ahVah==nomeCena&&!adicionou)
		{
			//print("colocandoValores");
			coloqueOsValoresGuardados();
			variaveisChave.particularidadesDeCaregamento();
			adicionou = true;
		}

		if(Application.loadedLevelName!=cenaAtual&&adicionou)
		{
			//print("me destrui");
			Destroy(gameObject);
		}
	
	}

	public static void evitaCriatureAvancarNoTrigger(Collider col)
	{
		col.GetComponent<alternancia>().retornaAoHeroi();
		Destroy(col.gameObject);
		GameObject.FindWithTag("Player")
			.GetComponent<movimentoBasico>().adicionaOCriature();
	}

	void OnTriggerEnter(Collider col)
	{
		if(!heroi.emLuta)
		{
			if(col.tag=="Player" && Application.loadedLevelName==cenaAtual)
			{
				DontDestroyOnLoad(gameObject);
				guardeValoresEMudeDeCena();
			}

			if(col.tag == "Criature")
			{
				evitaCriatureAvancarNoTrigger(col);
			}
		}
	}
}
