using UnityEngine;
using System.Collections;

public class caindoNaArmadilhaChao : MonoBehaviour {

	public Vector3 posAlvo;
	public string nomePrefab = "caindoNaArmadilhaChao";

	private bool iniciou = false;
	private Animator animator;
	private movimentoBasico mB;
	private pretoMorte p;
	private float tempoDecorrido = 0;
	private fasesDaQueda fase = fasesDaQueda.animaInicial;

	private sigaOLider siga;
	private UnityEngine.AI.NavMeshAgent nav;

	private enum fasesDaQueda
	{
		animaInicial,
		colocouPretoMorte,
		tiraPretoMorte,
		levantando
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(iniciou)
		{
			tempoDecorrido+=Time.deltaTime;
			switch(fase)
			{
			case fasesDaQueda.animaInicial:
				if(tempoDecorrido<0.5f)
				{
					mB.transform.position -= 5*Vector3.up*Time.deltaTime;
				}else
				{
					tempoDecorrido = 0;
					p = gameObject.AddComponent<pretoMorte>();
					fase = fasesDaQueda.colocouPretoMorte;
				}
			break;
			case fasesDaQueda.colocouPretoMorte:
				if(tempoDecorrido>1f)
				{
					animator.Play("damage_25");
					p.entrando = false;
					fase = fasesDaQueda.tiraPretoMorte;
					mB.transform.position = posAlvo;
				}
			break;
			case fasesDaQueda.tiraPretoMorte:
				if(mB.noChao(mB.Y.distanciaFundamentadora))
				{
					animator.Play("getup_20_p");
					Transform T = GameObject.Find("CriatureAtivo").transform;
					nav = T.GetComponent<UnityEngine.AI.NavMeshAgent>();
					siga = T.GetComponent<sigaOLider>();
					siga.enabled = false;
					nav.enabled = false;
					T.position = posAlvo;
					fase = fasesDaQueda.levantando;
				}
			break;
			case fasesDaQueda.levantando:
				if(tempoDecorrido>0.25f)
				{
					movimentoBasico.retornarFluxoHeroi();
					iniciou = false;
					fase = fasesDaQueda.animaInicial;
					nav.enabled = true;
					siga.enabled = true;
				}
			break;
			}

		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag=="Player" && !heroi.emLuta && !iniciou)
		{
			iniciou = true;
			movimentoBasico.pararFluxoHeroi(true,false);
			mB = col.GetComponent<movimentoBasico>();
			animator = col.GetComponent<Animator>();
			Destroy(
			Instantiate(
				elementosDoJogo.el.retorna(nomePrefab),
				col.transform.position,
				Quaternion.identity
				),5);


			animator.Play("damage_25_2");
		}
	}
}
