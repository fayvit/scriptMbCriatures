using UnityEngine;
using System.Collections;

public class envenenado : statusTemporarioBase {



	private Animator animator;

	private movimentoBasico mB;
	private movimentoBasico mBcriature;
	private UnityEngine.AI.NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		//H = GameObject.FindWithTag("Player").GetComponent<heroi>();
		mB = GameObject.FindWithTag("Player").GetComponent<movimentoBasico>();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();


		oAfetado = GetComponent<umCriature>().criature();

		esseStatus = tipoStatus.envenenado;



		colocaAParticulaEAdicionaEsseStatus("particulasEnvenenado");
		animator = GetComponent<Animator>();
		textos = bancoDeTextos.falacoes[heroi.lingua]["status"].ToArray();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();

		tempoAcumulado+=Time.deltaTime;

		if(tempoAcumulado>=tempoAteOProximoApply)
		{
			if(name=="inimigo")
			{
				if(!mBcriature)
				{
					GameObject G = GameObject.Find("CriatureAtivo");
					if(G)
						mBcriature = G.GetComponent<movimentoBasico>();
				}
				else
				if(mBcriature.podeAndar && mBcriature.enabled)
					daDano();
			}
			else if(mB)
				if(mB.enabled && mB.podeAndar)
					daDano();
				else if(nav)
					if(!heroi.emLuta && !nav.enabled)
					{
						daDano();
					}else if(heroi.emLuta)
					{
						if(!mBcriature)
							mBcriature = GetComponent<movimentoBasico>();

						if(mBcriature)
							if(mBcriature.enabled && mBcriature.podeAndar)
								daDano();

					}
		}

	}

	void voltaMove()
	{
		movimentoBasico mB = GetComponent<movimentoBasico>();
		if(mB)
			mB.enabled = true;
	}

	protected void mensagemDeAplicaDanoEnvenenado(string name)
	{
		mensagemEmLuta mL = Camera.main.gameObject.GetComponent<mensagemEmLuta>();
		
		if(mL)
			mL.fechador();
		
		mL = Camera.main.gameObject.AddComponent<mensagemEmLuta>();
		if(name=="CriatureAtivo")
			mL.mensagem = string.Format(textos[1],oAfetado.Nome,((int)forcaDoDano).ToString());
		else
			mL.mensagem = string.Format(textos[2],((int)forcaDoDano).ToString());
	}

	protected virtual void daDano()
	{
		mensagemDeAplicaDanoEnvenenado(gameObject.name);

		animator.Play("dano1");

		movimentoBasico mB = GetComponent<movimentoBasico>();
		if(mB)
		{
			mB.enabled = false;
			Invoke("voltaMove",1.5f);
		}

		acaoDeGolpe.mostraDano(elementosDoJogo.el,transform,(int)forcaDoDano);
		acaoDeGolpe.aplicaDano(oAfetado,(int)forcaDoDano);

		if(oAfetado.cAtributos[0].Corrente<=0 && name=="CriatureAtivo")
		{
			movimentoBasico.pararFluxoHeroi();

			animator.SetBool("cair",true);

			alternanciaEmLuta.pararOCriature(gameObject,animator);

			morteEmLuta dead =  GetComponent<morteEmLuta>();

			if(!dead)
				dead = gameObject.AddComponent<morteEmLuta>();
			dead.oMOrto = oAfetado;

			Destroy(particula.gameObject);
			tiraStatus(tipoStatus.envenenado,oAfetado.statusTemporarios );
			Destroy(this);

		}else
		{
			// colocar algo quando o inimigo morrer...?
		}

		tempoAcumulado = 0;
	}

	public override void destrua()
	{
		Destroy(particula.gameObject);
		Destroy(this);
	}
}
