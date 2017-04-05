using UnityEngine;
using System.Collections;

public class abreEntradaVulcao : MonoBehaviour {

	public GameObject pedrasNoCaminho;
	public Transform pos1Camera;
	public Collider meshTransporte;

	private heroi H;
	private float tempoDecorrido =0;
	private bool iniciou = false;
	private faseDaAnima fase;
	private pretoMorte p;
	private Transform tCamera;
	private Animator A;


	// Use this for initialization
	void Start () {
		H = GameObject.FindWithTag("Player").GetComponent<heroi>();
		variaveisChave.vericaAutoKey("vulcaoAberto");
		tCamera = Camera.main.transform;

		if(variaveisChave.shift["vulcaoAberto"])
		{
			pedrasNoCaminho.SetActive(false);
			Destroy(this);
		}
	}

	private enum faseDaAnima
	{
		iniciando,
		colocaParticulas,
		destruaAsPedras,
		retornaMovimento
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(H.transform.position,transform.position)<11 
		   &&
		   shopBasico.temItem(nomeIDitem.explosivos,H)>-1
		   &&
		   !pausaJogo.pause
		   &&
		   !heroi.emLuta
		   &&
		   !iniciou
		   )
		{
			if(Input.GetButtonDown("acao") || Input.GetButtonDown("acaoAlt"))
			{
				acaoDeItem2.retiraItem(nomeIDitem.explosivos,1,H);
				iniciou = true;
				p = gameObject.AddComponent<pretoMorte>();
				movimentoBasico.pararFluxoHeroi();
				H.transform.rotation = Quaternion.LookRotation(Vector3.right);
				A = H.GetComponent<Animator>();
				A.SetFloat("velocidade",3);
			}
		}

		if(iniciou)
		{
			tempoDecorrido+=Time.deltaTime;
			switch(fase)
			{
			case faseDaAnima.iniciando:
				if(tempoDecorrido>2)
				{
					A.SetFloat("velocidade",0);
					abreCanoDeEsgoto.posicionaCamera(
						tCamera,pos1Camera.position,pos1Camera.rotation,p,out tempoDecorrido);
					fase = faseDaAnima.colocaParticulas;
				}

			break;
			case faseDaAnima.colocaParticulas:
				if(tempoDecorrido>1)
				{
					Destroy(
						Instantiate(
						elementosDoJogo.el.retorna("particulasAbreVulcao"),
						transform.position,
						Quaternion.identity),2.5f);
					
					tempoDecorrido = 0;
					fase = faseDaAnima.destruaAsPedras;
				}
			break;
			case faseDaAnima.destruaAsPedras:
				if(tempoDecorrido>2.5)
				{
					ativaTriggerTransporte();
					variaveisChave.shift["vulcaoAberto"] = true;
					pedrasNoCaminho.SetActive(false);
					fase = faseDaAnima.retornaMovimento;
					tempoDecorrido = 0;
				}
			break;
			case faseDaAnima.retornaMovimento:
				if(tempoDecorrido>1f)
				{
					movimentoBasico.retornarFluxoHeroi();

					Destroy(this);
				}
			break;
			}
		}
	}

	void ativaTriggerTransporte()
	{
		meshTransporte.enabled = true;
	}
}
