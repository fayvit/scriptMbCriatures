using UnityEngine;
using System.Collections;

public class chegouNaArenaDeDrag : transporteInterno {

	public MeshRenderer[] meshs;
	public Material materialNovo;
	public Transform[] posCamera;

	private int cont = 0;
	private float tempoDecamera = 0;
	private fasesDaChegada estado = fasesDaChegada.preChegada;
	private Transform tCamera;
	private conversaEmJogo cJ;

	private enum fasesDaChegada
	{
		preChegada = -1,
		iniciando,
		comecaConversa
	}

	// Use this for initialization
	new void Start () {
		base.Start();
		variaveisChave.vericaAutoKey("chegouNaArenaDeDrag");
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();

		switch(estado)
		{
		case fasesDaChegada.iniciando:
			if(cont<7)
			{
				tempoDecamera +=Time.deltaTime;
				tCamera.position = Vector3.Slerp(tCamera.position,posCamera[cont+1].position,Time.deltaTime);
				tCamera.rotation = Quaternion.Slerp(tCamera.rotation,posCamera[cont+1].rotation,Time.deltaTime);

				if(Vector3.Distance(tCamera.position,posCamera[cont+1].position)<3f || tempoDecamera>2f)
				{
					if(cont!=6)
					{
						cont++;
						tempoDecamera = 0;
					}else if(Vector3.Distance(tCamera.position,posCamera[cont+1].position)<3f)
					{
						cont++;
						tempoDecamera = 0;
					}
				}
			}else
			{
				estado = fasesDaChegada.comecaConversa;
				cJ = gameObject.AddComponent<conversaEmJogo>();
				cJ.indiceDaConversa = "chegouNaArenaDeDrag";
				mudaTitulo mT = gameObject.AddComponent<mudaTitulo>();
				mT.mT = new mudaTitulo.mudeTitulo[3]
				{
					new mudaTitulo.mudeTitulo{titulo = "Sonia Water",indice = 0,espacosTab = 5},
					new mudaTitulo.mudeTitulo{titulo = "<color=cyan>Cesar Corean</color>",indice=2,espacosTab=2},
					new mudaTitulo.mudeTitulo{titulo = "Sonia Water",indice = 3,espacosTab = 5}
				};
				if(!cJ.mens)
					cJ.mens = gameObject.AddComponent<mensagemBasica>();
				cJ.colocaIndiceZero();
				cJ.mens.entrando = true;

			}
		break;
		case fasesDaChegada.comecaConversa:
			tCamera.position = Vector3.Slerp(tCamera.position,posCamera[cont+1].position,0.5f*Time.deltaTime);
			tCamera.rotation = Quaternion.Slerp(tCamera.rotation,posCamera[cont+1].rotation,0.5f*Time.deltaTime);
			if(cJ.mensagemAtual<cJ.numeroDeMensagens-1)
			{
				if(encontros.botoesPrincipais())
				{
					cJ.facaTrocaMens();
				}

			}else
			{
				if(encontros.botoesPrincipais())
				{
					cJ.finalisaConversa();
					base.terminandoOTransporte();
					estado = fasesDaChegada.preChegada;
					variaveisChave.shift["chegouNaArenaDeDrag"] = true;
				}
			}
		break;
		}
	}

	protected override void terminandoOTransporte()
	{
		if(estado==fasesDaChegada.preChegada && !variaveisChave.shift["chegouNaArenaDeDrag"])
		{
			estado = fasesDaChegada.iniciando;
			tCamera = Camera.main.transform;
			movimentoBasico.pararFluxoHeroi();
			tCamera.position = posCamera[0].position;
			tCamera.rotation = posCamera[0].rotation;
		}else if(variaveisChave.shift["chegouNaArenaDeDrag"])
		{
			base.terminandoOTransporte();
		}
	}

	protected override void iniciandoTransporte()
	{
		Material[] M = new Material[2]{meshs[0].materials[0],materialNovo};
		meshs[0].materials = M;
		meshs[1].materials = M;
		base.iniciandoTransporte();
	}
}
