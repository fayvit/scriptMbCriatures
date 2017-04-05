using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class acaoDeGolpe : MonoBehaviour {

	public uint impactos = 0;
	public nomesGolpes nomeParaCancelamento;
	public Vector3 emissor;
	public golpe ativa;

	private bool retorno = false;
	private bool procurouAlvo = false;
	private bool addView = false;
	private bool alcancouApiceDaAltura = false;
	private float tempoDecorrido = 0.0f;
	private uint raios = 0;
	private Vector3 posInicial = Vector3.zero;
	private Vector3 forwardInicial = Vector3.zero;
	private Transform alvoProcurado = null;
	private RaycastHit hit;
	private Animator animator;
	private Criature Y;
	private umCriature umC;
	private elementosDoJogo elementos;
	private List<string> animaAtiva = new List<string>();
	private List<Transform> projeteis = new List<Transform>();
	private CharacterController controle;
	

	public GameObject facaInstantiate(GameObject view,Vector3 deslColisor,Quaternion Q)
	{
		return (GameObject)Instantiate(view,deslColisor,Q);
	}

	public void facaDestroy(Object G,float tempo = 0)
	{
		Destroy(G,tempo);
	}
	// Use this for initialization
	void Start () {

		if(GetComponent<umCriature>())
			umC = GetComponent<umCriature>();
		if(umC)
			Y = umC.criature();
		animator = GetComponent<Animator> ();
		nomeParaCancelamento = ativa.nomeID;
		elementos = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ();
		switch(ativa.nomeID)
		{
		case nomesGolpes.rajadaDeAgua:
			ataqueRajadaDeAgua();
		break;
		case nomesGolpes.gosmaAcida:
		case nomesGolpes.ondaVenenosa:
		case nomesGolpes.turboDeAgua:
		case nomesGolpes.rajadaDeFogo:
		case nomesGolpes.ventania:
		case nomesGolpes.ventosCortantes:
		case nomesGolpes.eletricidade:
		case nomesGolpes.eletricidadeConcentrada:
		case nomesGolpes.gosmaDeInseto:
		case nomesGolpes.agulhaVenenosa:
		case nomesGolpes.cascalho:
		case nomesGolpes.pedregulho:
		case nomesGolpes.rajadaDeTerra:
		case nomesGolpes.vingancaDaTerra:
		case nomesGolpes.psicose:
		case nomesGolpes.bolaPsiquica:
		case nomesGolpes.anelDoOlhar:
		case nomesGolpes.olharMal:
		case nomesGolpes.olharParalisante:
		case nomesGolpes.rajadaDeGas:
		case nomesGolpes.laminaDeFolha:
		case nomesGolpes.bombaDeGas:
		case nomesGolpes.furacaoDeFolhas:
			ataqueEmissor();
		break;

		case nomesGolpes.sabreDeAsa:
		case nomesGolpes.sabreDeBastao:
		case nomesGolpes.sabreDeEspada:
		case nomesGolpes.sabreDeNadadeira:
			impactoBasico(ativa.nomeID.ToString());
			forwardInicial = transform.forward;
			useOEmissor();
		break;
		

		case nomesGolpes.multiplicar:
		case nomesGolpes.garra:
		case nomesGolpes.tapa:
		case nomesGolpes.chute:
		case nomesGolpes.chicoteDeMao:
		case nomesGolpes.espada:
		case nomesGolpes.chicoteDeCalda:
		case nomesGolpes.dentada:
		case nomesGolpes.bico:
		case nomesGolpes.cabecada:
		case nomesGolpes.sobreSalto:
		case nomesGolpes.hidroBomba:
		case nomesGolpes.tosteAtaque:
		case nomesGolpes.tempestadeDeFolhas:
		case nomesGolpes.tempestadeEletrica:
		case nomesGolpes.chifre:
		case nomesGolpes.avalanche:
		case nomesGolpes.bastao:
		case nomesGolpes.tesoura:
			impactoBasico(ativa.nomeID.ToString());
		break;

		case nomesGolpes.sobreVoo:
			instanciaVentoDano();
			impactoBasico(ativa.nomeID.ToString());
		break;

		case nomesGolpes.bolaDeFogo:
			ataqueBolaDeFogo();
		break;
		
		
		
		case nomesGolpes.energiaDeGarras:
			paralisaTudo();
		break;

		case nomesGolpes.cortinaDeTerra:
		case nomesGolpes.cortinaDeFumaca:
		case nomesGolpes.teletransporte:
			desapareceAntesDoHit();
		break;
		
	
		case nomesGolpes.chuvaVenenosa:
			posInicial = transform.position;
			Destroy(Instantiate(elementos.retorna("impulsoVenenoso"),transform.position,Quaternion.identity),3);
			impactoBasico("chuvaVenenosa");
		break;
		default:
			ativa.Start(GetComponent<movimentoBasico>(), GetComponent<IA_inimigo>(),
			            transform,animator,this);
		break;
		}
	
	}

	void Update () {
		tempoDecorrido+=Time.deltaTime;
		switch(ativa.nomeID)
		{
		case nomesGolpes.rajadaDeAgua:
			rajadaDeAguaAtiva();
		break;
		case nomesGolpes.turboDeAgua:
			projetilPadrao("rigido","turboDeAgua","impactoDeAgua",15,2);
		break;
		case nomesGolpes.bolaDeFogo:
			bolaDeFogoAtiva();
		break;
		case nomesGolpes.rajadaDeFogo:
			projetilPadrao("rigido","rajadaDeFogo","impactoDeFogo",25,2);
		break;
		case nomesGolpes.laminaDeFolha:
			projetilPadrao("basico","laminaDeFolha","impactoDeFolhas",14);//laminaDeFolhaAtiva();
		break;
		
		case nomesGolpes.furacaoDeFolhas:
			projetilPadrao("rigido","furacaoDeFolhas","impactoDeFolhas",10,6);
		break;

		case nomesGolpes.chifre:
			impactoAtivo(nomesGolpes.chifre,"umCuboETrail");
		break;
		case nomesGolpes.tapa:
			impactoAtivo(nomesGolpes.tapa,"umCuboETrail");
		break;
		case nomesGolpes.garra:
			impactoAtivo(nomesGolpes.garra,"tresCubos");
		break;
		case nomesGolpes.bico:
			impactoAtivo(nomesGolpes.bico,"umCuboETrail");
		break;
		case nomesGolpes.chute:
			impactoAtivo(nomesGolpes.chute,"umCuboETrail");
		break;
		case nomesGolpes.chicoteDeMao:
			ataqueComSalto(nomesGolpes.chicoteDeMao,"doisCubos","impactoAoChao");
		break;
		case nomesGolpes.chicoteDeCalda:
			//ataqueComSalto("chicoteDeCalda","cuboExtraTrail");
			impactoAtivo(nomesGolpes.chicoteDeCalda,"umCuboETrailMaior");
		break;
		case nomesGolpes.dentada:
			ataqueComSalto(nomesGolpes.dentada,"dentada");
		break;
		case nomesGolpes.ventania:
			projetilPadrao("basico","Ventania","impactoDeVento",14);
		break;
		case nomesGolpes.ventosCortantes:
			projetilPadrao("rigido","ventosCortantes","impactoDeVento",10,5);
		break;
		case nomesGolpes.cabecada:
			impactoAtivo(nomesGolpes.cabecada,"umCuboETrail");
		break;
		case nomesGolpes.gosmaDeInseto:
			projetilPadrao("basico","gosmaDeInseto","impactoDeGosma",9);
		break;
		case nomesGolpes.gosmaAcida:
			projetilPadrao("basico","gosmaAcida","impactoDeGosmaAcida",9);
		break;
		case nomesGolpes.eletricidade:
			eletricidadeAtiva();
		break;
		case nomesGolpes.eletricidadeConcentrada:
			eletricidadeConcentradaAtiva();
		break;
		case nomesGolpes.agulhaVenenosa:
			projetilPadrao("basico","agulhaVenenosa","impactoVenenoso",9);
		break;
		case nomesGolpes.ondaVenenosa:
			projetilPadrao("rigido","ondaVenenosa","impactoVenenoso",10,4);
		break;
		case nomesGolpes.espada:
			ataqueComSalto(nomesGolpes.espada,"doisCubos","impactoAoChao");
		break;
		case nomesGolpes.sobreSalto:
			ataqueComSalto(nomesGolpes.sobreSalto,"umCuboETrailMaior","sobreSalto");
		break;
		case nomesGolpes.cascalho:
			projetilPadrao("basico","Cascalho","impactoDePedra",14);//laminaDeFolhaAtiva();
		break;
		case nomesGolpes.pedregulho:
			projetilPadrao("rigido","Pedregulho","impactoDePedra",15,2);
		break;
		case nomesGolpes.rajadaDeTerra:
			projetilPadrao ("basico","rajadaDeTerra","impactoDeTerra",14);
		break;
		case nomesGolpes.energiaDeGarras:
			energiaDeGarrasAtiva();
		break;
		case nomesGolpes.vingancaDaTerra:
			projetilPadrao("rigido","vingancaDaTerra","impactoDeTerra",15);
		break;
		case nomesGolpes.psicose:
			projetilPadrao("direcional","psicose","impactoComum",15);
		break;
		case nomesGolpes.hidroBomba:
			ataqueComSalto("impactoDeAgua",nomesGolpes.hidroBomba,"aguaAoChao");
		break;
		case nomesGolpes.tosteAtaque:
			ataqueComSalto("impactoDeFogo",nomesGolpes.tosteAtaque,"fogoAoChao");
		break;
			
		case nomesGolpes.tempestadeEletrica:
			ataqueComSalto("impactoComum",nomesGolpes.tempestadeEletrica,"eletricidadeAoChao");
		break;
		case nomesGolpes.avalanche:
			ataqueComSalto("impactoDePedra",nomesGolpes.avalanche,"impactoDePedraAoChao");
		break;
		case nomesGolpes.tempestadeDeFolhas:
			ataqueComSalto("impactoDeFolhas",nomesGolpes.tempestadeDeFolhas);
		break;	
		case nomesGolpes.chuvaVenenosa:
			ataqueComSalto(true,nomesGolpes.chuvaVenenosa,false,"impactoVenenoso");
		break;
		case nomesGolpes.bolaPsiquica:
			projetilPadrao("rigido","bolaPsiquica","impactoComum",15,3);
		break;
		case nomesGolpes.multiplicar:
			multiplicarInsetos();
		break;
		case nomesGolpes.anelDoOlhar:
			projetilPadrao("rigido","impactoComum",20,3.5f);
		break;
		case nomesGolpes.olharMal:
			projetilPadrao("status","impactoDeMedo",15,3.5f);
		break;
		case nomesGolpes.olharParalisante:
			projetilPadrao("status","impactoComum",15,3.5f);
		break;
		case nomesGolpes.cortinaDeTerra:
			apareceComHitNoChao("impactoDeTerra");
		break;
		case nomesGolpes.cortinaDeFumaca:
			apareceComHitNoChao("impactoDeGas");
		break;
		case nomesGolpes.teletransporte:
			apareceComHitNoChao();
		break;
		case nomesGolpes.sobreVoo:
			sobreVooAtivo();
		break;
		case nomesGolpes.rajadaDeGas:
			projetilPadrao("rigido","rajadaDeGas","impactoDeGas",25,2);
		break;
		
		case nomesGolpes.bombaDeGas:
			projetilPadrao("basico","bombaDeGas","impactoDeGas",14);
		break;
		
		case nomesGolpes.bastao:
			impactoAtivo(nomesGolpes.bastao,"umCuboETrailMaior");
		break;
		case nomesGolpes.sabreDeAsa:
		case nomesGolpes.sabreDeBastao:
		case nomesGolpes.sabreDeEspada:
		case nomesGolpes.sabreDeNadadeira:
			projetilPadrao("basico","Sabre","impactoComum",0,0.45f);
		break;
		case nomesGolpes.tesoura:
			ataqueComSalto(nomesGolpes.tesoura,"umCuboETrailMaior","impactoAoChao");
		break;
		case nomesGolpes.cancelado:
			umC.ataqueComPulo = false;

			animator.SetBool("atacando",false);

			Y.cAtributos[1].Corrente+=ativa.CustoPE;

			opcoesDeCancelamento();

			Destroy(this,0.25f);
//			Debug.LogWarning("Cancelando um golpe generico[!!!]");
		break;
		default:
			ativa.Update();
		break;
		
		}
	}

	/*
	void ataqueEmGiroAtivo()
	{
		
		tempoDecorrido+=Time.deltaTime;
		if(!procurouAlvo)
			alvoProcurado = acaoDeGolpeRegenerate.procureUmBomAlvo(gameObject);
		
		if(tempoDecorrido>ativa.tempoMoveMin && !addView)
		{
			acaoDeGolpeRegenerate.adicionaOColisor (this,transform,tempoDecorrido,ativa.nomeID,"umCuboETrailMaior",ativa.tempoDestroy);	
			addView = true;
		}
		
		if(((int)(10*tempoDecorrido))%1==0)
		{
			facaDestroy(
				facaInstantiate(
				elementosDoJogo.el.retorna("poeiraAoVento"),
				transform.position,
				Quaternion.identity
				),2);
		}
		
		float sinal = 1;
		Vector3 dir = transform.forward;
		if(tempoDecorrido<ativa.tempoMoveMax && tempoDecorrido>ativa.tempoMoveMin)
		{
			if(alvoProcurado)
			{
				if(Vector3.Angle(dir,alvoProcurado.position-transform.position)>100)
					sinal = -1;
				dir =   Vector3.Slerp(dir,sinal*(alvoProcurado.position-transform.position),0.9f*Time.deltaTime);
				Quaternion.LookRotation(
					Vector3.ProjectOnPlane(dir,Vector3.up)
					);
			}
			
			if(!controle)
				controle = transform.GetComponent<CharacterController>();
			controle.Move(55*transform.forward*Time.deltaTime+Vector3.down * Y.gravidade);
		}
		
		if(tempoDecorrido>ativa.tempoDestroy&& !retorno)
		{
			fimDaAcaoGolpe();
		}
		
	}*/

	void opcoesDeCancelamento()
	{
		if(umC.X.cAtributos[0].Corrente>0)
		{
			switch(nomeParaCancelamento)
			{
			case nomesGolpes.energiaDeGarras:
				retornaLutaParalisada();
				Debug.LogWarning("O golpe "+nomeParaCancelamento.ToString()+" foi cancelado e a funçao luta paralisada chamada [atençao as inconsistencias]");
			break;
			case nomesGolpes.cortinaDeTerra:
			case nomesGolpes.cortinaDeFumaca:
			case nomesGolpes.teletransporte:
				apareceDesaparece(true);
				Debug.LogWarning("O golpe "+nomeParaCancelamento.ToString()+"[atençao para inconsistencias]");
				Destroy(this);
			break;
			case nomesGolpes.sobreVoo:
			break;
			}
		}
	}

	void instanciaVentoDano()
	{
			Instantiate(
				elementosDoJogo.el.retorna("subindoSobreVoo"),
				transform.position,
			Quaternion.identity);
	}

	void sobreVooAtivo()
	{
		if(tempoDecorrido<ativa.tempoMoveMin)
		{
			umC.ataqueComPulo = true;
			if(!controle)
				controle = GetComponent<CharacterController>();

			controle.Move(Vector3.up*Y.velocidadeSubindo*Time.deltaTime);
		}

		if(tempoDecorrido>ativa.tempoMoveMin && tempoDecorrido<ativa.tempoMoveMax)
		{
			if(!procurouAlvo)
				alvoProcurado = acaoDeGolpeRegenerate.procureUmBomAlvo(gameObject,100);

			if(!addView)
			{ 
			 acaoDeGolpeRegenerate.adicionaOColisor(this,transform,tempoDecorrido,
					nomesGolpes.sobreVoo,"umCuboETrailMaior",ativa.tempoDestroy,"impactoDeVento");
				addView = true;
			}

			Vector3 dir = transform.forward+0.5f*Vector3.down;

			if(alvoProcurado)
				dir = alvoProcurado.position - transform.position+0.5f*Vector3.down;

			controle.Move(dir*Y.velocidadeCaindo*3*Time.deltaTime);
		}

		if(tempoDecorrido>ativa.tempoDestroy&& !retorno)
		{
			fimDaAcaoGolpe();
		}
	}

	void apareceComHitNoChao(string noImpacto  = "impactoComum")
	{
		if(tempoDecorrido>ativa.tempoMoveMin && !addView )
		{
			addView = true;
			GameObject aAlvo = (gameObject.name=="CriatureAtivo")
				?
					GameObject.Find("inimigo")
					:
					GameObject.Find("CriatureAtivo");

			Transform alvo = (aAlvo!=null)?aAlvo.transform:null;

			Vector3 volta = transform.position;

			if(alvo!= null)
			{
				volta = alvo.position;

				bool b = alvo.GetComponent<Animator>().GetBool("noChao");
				bool c = alvo.GetComponent<CharacterController>().enabled;

				Destroy(
					Instantiate(
					elementos.retorna(noImpacto),
					alvo.position,
					Quaternion.identity),
					10);

				print(b+" : "+c);
				if(b && c)
					tomaDanoUm(alvo);
			}

			Destroy(
				Instantiate(
				elementos.retorna(ativa.nomeID.ToString()),
				volta,
				Quaternion.identity),
				10);



			transform.position = new melhoraPos().novaPos(volta);
			apareceDesaparece(true);

		


		}

		if(tempoDecorrido >ativa.tempoMoveMax && !retorno){
			liberaDoAtacando();
			Destroy(this,2);
		}
	}

	void apareceDesaparece(bool aparecer)
	{
		SkinnedMeshRenderer[] skinned =  GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach(SkinnedMeshRenderer sk in skinned)
		{
			sk.enabled = aparecer;
		}
		
		if(!controle)
			controle = GetComponent<CharacterController>();
		
		controle.enabled = aparecer;
	}

	void desapareceAntesDoHit()
	{
		paraliseNoTempo ();
		apareceDesaparece(false);

		Destroy(
			Instantiate(
			elementos.retorna(ativa.nomeID.ToString()),
			transform.position,
			Quaternion.identity),
			10);
	}


	void multiplicarInsetos()
	{
		float tempoDeAtraso = verifiqueAtrasoDeAnimacao();
		 if(!addView && tempoDecorrido>ativa.tempoMoveMin)
		{
			GameObject G = elementos.retorna(umC.nomeCriature.ToString(),"criature");
			Vector3 pos = Vector3.zero;
			for(int i=0;i<4;i++)
			{
				switch(i)
				{
				case 0:
					pos = transform.position+transform.forward+2*transform.right;
						
				break;
				case 1:

					pos = transform.position+transform.forward-2*transform.right;

				break;
				case 2:
					pos = transform.position-transform.forward+3*transform.right;

				break;
				case 3:
					pos = transform.position-transform.forward-3*transform.right;
				break;
				}

				G = Instantiate(G,new melhoraPos().novaPos(pos),transform.rotation) as GameObject;
				if(i==0)
				{
					G.layer = 8;
					comportamentoDoMultiplicado c =  G.AddComponent<comportamentoDoMultiplicado>();
					c.direcaoMovimento = pos - transform.position;
					c.velocidadeProjetil = Y.velocidadeAndando;
					c.dono = gameObject;
					c.tempoDestroy = 95f/100f*ativa.tempoDestroy;
					CapsuleCollider caps =  G.AddComponent<CapsuleCollider>();
					G.AddComponent<Rigidbody>();
					caps.isTrigger = true;
					if(!controle)
						controle = GetComponent<CharacterController>();
					caps.radius = 2*controle.radius;
					caps.height = controle.height;
//					print(procureUmBomAlvo(450));
					c.alvo = acaoDeGolpeRegenerate. procureUmBomAlvo(gameObject,450);
				}else
				{
					G.GetComponent<comportamentoDoMultiplicado>().direcaoMovimento = pos-transform.position;
				}
				Destroy(
					Instantiate(elementos.retorna("impactoDeGosma"),pos,Quaternion.identity),
					2);

			}
			addView = true;
		}

		if(tempoDecorrido >ativa.tempoMoveMax+tempoDeAtraso && !retorno){
			liberaDoAtacando();
		}
	}

	void energiaDeGarrasAtiva()
	{
		 
		Transform daCamera = Camera.main.transform;
		colisor C;
		Vector3 posAlvoCam = Vector3.zero;

		if(tempoDecorrido<ativa.tempoMoveMin)
		{
			if(!addView)
			{
				animator.Play("preparaEnergiaDeGarra",0);
				addView = true;
			}
			C = acaoDeGolpeRegenerate.pegueOColisor(nomesGolpes.energiaDeGarras,Y);
			if(C.osso =="erroColisor")
			{
				// corrigia a bugaiada
			}
			if(alvoProcurado)
				transform.rotation = Quaternion.Lerp(
					transform.rotation,
					Quaternion.LookRotation(
						new Vector3(
							alvoProcurado.position.x-transform.position.x,
							0,
							alvoProcurado.position.z-transform.position.z)),
					3*Time.deltaTime
					);
			Transform T = transform.Find(C.osso);
			posAlvoCam = T.position-transform.position;
			posAlvoCam = new Vector3(posAlvoCam.x,0,posAlvoCam.z)*2+T.position;
			daCamera.position = Vector3.Lerp(daCamera.position,posAlvoCam,Time.deltaTime*3);
			daCamera.LookAt(T);
		}else if(tempoDecorrido>ativa.tempoMoveMin && addView &&tempoDecorrido<ativa.tempoMoveMax)
		{
			addView = false;
			C = acaoDeGolpeRegenerate.pegueOColisor(nomesGolpes.energiaDeGarras,Y);
			GameObject G = elementosDoJogo.el.retorna("particulaDeEnergia");
			for(int i=0;i<4;i++)
				Destroy(
					Instantiate(G,transform.Find(C.osso).position-0.25f*i*Vector3.up,G.transform.rotation),
					1);
		}else if(tempoDecorrido>ativa.tempoMoveMin+0.5f && !addView)
		{

			animator.SetBool("atacando",true);
			addView = true;
		}else if(tempoDecorrido>ativa.tempoMoveMax && addView  &&  tempoDecorrido<ativa.tempoDestroy)
		{
			posAlvoCam = transform.position+5*transform.forward+Vector3.up*3+transform.right*2;
			daCamera.position = Vector3.Lerp(daCamera.position,posAlvoCam,Time.deltaTime*5);
			daCamera.LookAt(transform);
			float tempAux = ativa.tempoMoveMax+raios*(ativa.tempoDestroy-ativa.tempoMoveMax)/3;
			if(raios<3 && tempoDecorrido>tempAux)
			{
				GameObject G2 = elementosDoJogo.el.retorna("geiserDeEnergia");
				G2 = (GameObject)Instantiate(G2,transform.position+transform.forward,G2.transform.rotation);
				avanteGeiserDeEnergia avanteG =  G2.AddComponent<avanteGeiserDeEnergia>();
				avanteG.direcao = transform.forward;
				avanteG.pos = transform.position;
				avanteG.quem = transform.name;
				avanteG.aG = this;
				projeteis.Add(G2.transform);
				G2.transform.localScale = Vector3.zero;
				raios++;
				if(raios==3)
					avanteG.final = 1;
			}
		}else if(tempoDecorrido>ativa.tempoDestroy)
		{

		}
	}

	void paralisaTudo()// Utilizado para golpes onde o fluxo de jogo e interrompido
	{
		IA_inimigo IA;
		GameObject G;
		if(GetComponent<movimentoBasico>())
		{
			GetComponent<movimentoBasico>().enabled = false;
			G = GameObject.Find("inimigo");
			GetComponent<cameraPrincipal>().enabled = false;
			if(G){
				IA =  G.GetComponent<IA_inimigo>();
				IA.podeAtualizar = false;
				IA.paraMovimento();
				alvoProcurado = G.transform;
			}
		}else
		{
			IA= GetComponent<IA_inimigo>();
			IA.podeAtualizar = false;
			IA.paraMovimento();
			G = GameObject.Find("CriatureAtivo");
			G.GetComponent<movimentoBasico>().enabled = false;
			G.GetComponent<cameraPrincipal>().enabled = false;
			alvoProcurado = G.transform;
		}
	}

	public void retornaLutaParalisada()
	{
		IA_inimigo IA;
		GameObject G;
		if(GetComponent<movimentoBasico>())
		{
			GetComponent<movimentoBasico>().enabled = true;
			G = GameObject.Find("inimigo");
			GetComponent<cameraPrincipal>().enabled = true;
			if(G){
				IA =  G.GetComponent<IA_inimigo>();
				IA.enabled = true;
				IA.retornaOMovimento();
			}
		}else
		{
			IA= GetComponent<IA_inimigo>();
			IA.podeAtualizar = true;
			IA.paraMovimento();
			G = GameObject.Find("CriatureAtivo");
			G.GetComponent<movimentoBasico>().enabled = true;
			G.GetComponent<cameraPrincipal>().enabled = true;
		}

		liberaDoAtacando();
	
		Destroy(this);
	}

	private void liberaDoAtacando()
	{
		liberaMovimento();
		animator.SetBool("atacando",false);
		retorno = true;
	}

	private void verificaFimEletrico()
	{
		bool volta  = true;
		for(int i=0;i<projeteis.Count;i++)
			if(projeteis[i]!=null)
				volta = false;
		
		if(projeteis.Count==0)
			volta = false;
		
		if((tempoDecorrido >ativa.tempoMoveMax && !retorno)|| volta){
			aplicaFimEletrico();

		}
	}

	public void aplicaFimEletrico()
	{
		LightningBolt L;
		for(int i=0;i<projeteis.Count;i++)
			if(projeteis[i]!=null)
		{
			L = projeteis[i].GetComponentInChildren<projetilEletrico>().KXY.GetComponent<LightningBolt>();
				if(L)
			{
					Destroy(L);
				Destroy(L.gameObject);
			}
				Destroy(projeteis[i].gameObject);
			//projeteis[i].gameObject.SetActive(false);
		}



		liberaDoAtacando();
		Destroy(this);
	}

	private void eletricidadeConcentradaAtiva()
	{
		 
		posInicial += Vector3.up*0.25f;
		if(!addView){
			instanciaEletricidade(transform.forward+0.5f*Vector3.up,1);
			addView = true;
		}

		verificaFimEletrico();
	}

	private void instanciaEletricidade(Vector3 paraOnde,float tempoMax = 10)
	{
		GameObject KY = instancieEDestrua ("raioEletrico",5,5);
		Transform KXY =  KY.transform.GetChild(0);
		Destroy(KXY.gameObject,4.9f);
		KXY.parent = transform.Find(Y.emissor).transform;
		KXY.localPosition = Vector3.zero;
		projeteis.Add(KY.transform);
		projetilEletrico proj = KY.transform.GetChild(2).gameObject.AddComponent<projetilEletrico>();
		proj.KXY = KXY;
		proj.criatureAlvo = acaoDeGolpeRegenerate.procureUmBomAlvo(gameObject,350);
		proj.forcaInicial = paraOnde.normalized;
		proj.velocidadeProjetil = 9;
		proj.tempoMax = tempoMax;
		proj.noImpacto = "impactoEletrico";
		proj.dono = gameObject;
		addView = true;
	}
	
	private void eletricidadeAtiva()
	{
		 
		if(raios<5 && tempoDecorrido>(ativa.tempoMoveMin+raios*(ativa.tempoMoveMax-ativa.tempoMoveMin)/35))
		{
			float tempinho = ativa.tempoMoveMax-tempoDecorrido;
			switch(raios)
			{
			case 0:
				posInicial += Vector3.up*0.25f;
				instanciaEletricidade(transform.forward,tempinho);
			break;
			case 1:
				posInicial = transform.position+transform.right+5*Vector3.up;
				instanciaEletricidade(transform.right+Vector3.up+transform.forward,tempinho);
			break;
			case 2:
				posInicial = transform.position+transform.right+Vector3.up;
				instanciaEletricidade(transform.right+Vector3.up+transform.forward,tempinho);
			break;
			case 3:
				posInicial = transform.position-transform.right+5*Vector3.up;
				instanciaEletricidade(-transform.right+Vector3.up+transform.forward,tempinho);
				break;
			case 4:
				posInicial = transform.position-transform.right+Vector3.up;
				instanciaEletricidade(-transform.right+Vector3.up+transform.forward,tempinho);
			break;
			}

			raios++;

		} 

		bool volta  = true;
		for(int i=0;i<projeteis.Count;i++)
			if(projeteis[i]!=null)
				volta = false;

		if(projeteis.Count==0)
			volta = false;

		if((tempoDecorrido >ativa.tempoMoveMax && !retorno)|| volta){
			liberaDoAtacando();
			Destroy(this);
		}
	}
	
	void avanceEPareAbaixo(float distanciaDeParada = 1.75f)
	{
		if(!controle)
			controle = GetComponent<CharacterController>();

		float subindo = Y.gravidade;
		float velocidadeAvante = 25f;
		Vector3 V = Vector3.zero;
		if(!procurouAlvo)
			alvoProcurado = acaoDeGolpeRegenerate.procureUmBomAlvo(gameObject);

		if(alvoProcurado)
		{
			V = alvoProcurado.position;
			ajudaAtaque(alvoProcurado.gameObject);
		}
		
		if(((transform.position-V).magnitude>distanciaDeParada
		    && 
		    transform.position.y-posInicial.y<Y.apiceDoPulo
		    &&
		    !alcancouApiceDaAltura)
		   ||
		   tempoDecorrido>1.25f)
		{
			subindo = transform.name=="CriatureAtivo"? -11.5f:-33;			
		}else if((transform.position-V).magnitude<=distanciaDeParada )
		{
			velocidadeAvante = 0;
			alcancouApiceDaAltura = true;
		}else
		{
			alcancouApiceDaAltura = true;
		}
		
		controle.Move((velocidadeAvante*transform.forward+Vector3.down *subindo)*Time.deltaTime);
	}

	private void maisAltoQueOAlvo(Transform T)
	{
		umC.ataqueComPulo = true;
		if(!controle)
			controle = GetComponent<CharacterController>();

		/*
		float distanciaDeParada = 1.75f;

		float subindo = Y.gravidade;
*/
		float velocidadeAvante = 0;


		Vector3 V = Vector3.zero;

		Vector3 pontoAlvo = V+3*Vector3.up;

		if(T!=null)
		{
			V = T.position;
			pontoAlvo = V+3*Vector3.up+0.35f*(transform.position-T.position);
		}


		Vector3 direcaoDoSalto = T==null?transform.forward+0.4f*Vector3.up:pontoAlvo-transform.position;


		if(Vector3.Distance(pontoAlvo,transform.position)<0.1f
		   ||
		   Mathf.Abs(posInicial.y-transform.position.y)>4
		   )
		{
			alcancouApiceDaAltura = true;
		}

		if(alcancouApiceDaAltura)
		{
			velocidadeAvante = transform.name=="CriatureAtivo"?25f:20;
			Vector3 descendo = Vector3.down;
			if(transform.name!="CriatureAtivo" && T!= null)
			{
				descendo = descendo+8*(T.position-transform.position);
				descendo.Normalize();
				transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(descendo,Vector3.up));
			}
			controle.Move(descendo*velocidadeAvante*Time.deltaTime);
		}else
		{
			velocidadeAvante = transform.name=="CriatureAtivo"?25f:9;
			controle.Move(direcaoDoSalto*Time.deltaTime*velocidadeAvante);
		}


	}

	private void ataqueComSalto(bool instantaneo,nomesGolpes nomeColisor,bool parentearNoOsso = true,string noImpacto="impactoComum",string extra = "")
	{
		ataqueComSalto(nomeColisor,nomeColisor.ToString(),extra,1.75f,noImpacto,instantaneo,parentearNoOsso);
	}

	private void ataqueComSalto(string noImpacto,nomesGolpes nomeColisor,string extra = "")
	{
		ataqueComSalto(nomeColisor,nomeColisor.ToString(),extra,1.75f,noImpacto);
	}

	private void ataqueComSalto(nomesGolpes nomeColisor,string nomeTrail,
	                            string extra="",float distanciaPareAbaixo = 1.75f,
	                            string noImpacto = "impactoComum",
	                            bool instantaneo = false,
	                            bool parentearNoOsso  =true)
	{
		umC.ataqueComPulo = true;
		 
		if(!procurouAlvo)
			alvoProcurado = acaoDeGolpeRegenerate.procureUmBomAlvo(gameObject,100);

		if(extra=="")
			extra = ativa.nomeID.ToString();
		
		if(tempoDecorrido>ativa.tempoMoveMin && !addView)
		{
			impactoAoChao ao;
			acaoDeGolpeRegenerate.adicionaOColisor(this,transform,tempoDecorrido,
				nomeColisor,nomeTrail,ativa.tempoDestroy,noImpacto,parentearNoOsso);
			addView = true;
			switch(extra)
			{
			case "impactoAoChao":
			case "sobreSalto":
				ao = gameObject.AddComponent<impactoAoChao>();
				
			break;
			case "aguaAoChao":
				ao = gameObject.AddComponent<impactoAoChao>();
				ao.aoChao = "aguaImpactoAoChao";
			break;
			case "fogoAoChao":
				ao = gameObject.AddComponent<impactoAoChao>();
				ao.aoChao = "fogoImpactoAoChao";
			break;
			case "eletricidadeAoChao":
				ao = gameObject.AddComponent<impactoAoChao>();
				ao.aoChao = "eletricidadeAoChao";
			break;
			case "impactoDePedraAoChao":
				ao = gameObject.AddComponent<impactoAoChao>();
				ao.aoChao = "impactoDePedraAoChao";
			break;
			}

			if(!instantaneo)
				posInicial = transform.position;
			addView = true;
		}
		
		if((tempoDecorrido<ativa.tempoMoveMax && tempoDecorrido>ativa.tempoMoveMin)||instantaneo)
		{
			switch(extra)
			{
			case "sobreSalto":
			case "chuvaVenenosa":
			case "impactoDePedraAoChao":
				maisAltoQueOAlvo(alvoProcurado);
			break;
			case "aguaAoChao":
			case "fogoAoChao":
			case "eletricidadeAoChao":
				if(gameObject.name=="CriatureAtivo")
					maisAltoQueOAlvo(alvoProcurado);
				else
					avanceEPareAbaixo(distanciaPareAbaixo);
			break;
			default:
				avanceEPareAbaixo(distanciaPareAbaixo);
			break;
			}
		}
		
		if(tempoDecorrido>ativa.tempoDestroy && !retorno)
		{
			fimDaAcaoGolpe();
		}
	}
	

	public void interrompa()
	{
		for(int i=0;i<animaAtiva.Count;i++)
		{
			animator.SetBool(animaAtiva[i],false);
		}

		umC.ataqueComPulo = false;

		Destroy(this);
	}
	
	void impactoBasico(string impacto)
	{
		paraliseNoTempo();
		forwardInicial = transform.forward;
		anime(impacto);
	}

	/*
	colisor pegueOColisor(nomesGolpes nomeColisor)
	{
		colisor C = new colisor();
		Criature XX = GetComponent<umCriature>().criature();
		
		/*
			Quando e feito um saveGame o Criature e salvo em essencia como esta no script,
			isso inclui os colisores,
			se algum golpe for inserido apos esse save e um novo colisor for inserido
			o novo colisor nao aparece no jogo salvo

			Para corrigir isso inseri essa linha que questiona a existencia do colisor
		 *
		
		if(XX.colisores.ContainsKey(nomeColisor))
			C = XX.colisores[nomeColisor];
		else{
			Criature XXX = new cCriature(XX.nomeID).criature();
			
			/*
				Essa linha verifica a existencia do colisor no script desse Criature,
				se existir insere no criature que lançou o golpe
				se nao existir da uma mensagem de atençao
			 *
			
			if(XXX.colisores.ContainsKey(nomeColisor))
				XX.colisores.Add(nomeColisor,XXX.colisores[nomeColisor] );
			else{
				Debug.LogWarning("O Colisor com o nome \""+nomeColisor+"\" nao foi encontrado para "+XX.Nome);
				return new colisor("erroColisor");
			}
			
		}

		return C;
	}

	void adicionaOColisor(nomesGolpes nomeColisor,
	                      string nomeTrail,float tempoDestroy,
	                      bool parentearNoOsso,
	                      Quaternion Q = default(Quaternion),
	                      string noImpacto = "impactoComum")
	{
		adicionaOColisor(nomeColisor,nomeTrail,tempoDestroy,noImpacto,parentearNoOsso,Q);
	}

	void adicionaOColisor(nomesGolpes nomeColisor,
	                      float tempoDestroy,
	                      string noImpacto = "impactoComum",
	                      bool parentearNoOsso = true,
	                      Quaternion Q = default(Quaternion))
	{
		adicionaOColisor(nomeColisor,nomeColisor.ToString(),tempoDestroy,noImpacto,parentearNoOsso,Q);
	}

	void adicionaOColisor(nomesGolpes nomeColisor,
	                      string nomeTrail,float tempoDestroy,
	                      string noImpacto = "impactoComum",
	                      bool parentearNoOsso = true,
	                      Quaternion Q = default(Quaternion))
	{
		GameObject view = elementos.retornaColisor(nomeTrail);
//		print(nomeColisor);
		colisor C = acaoDeGolpeRegenerate.pegueOColisor(nomeColisor,Y);// = new colisor();

		if(C.osso=="erroColisor")
			return;

		GameObject view2 = Instantiate(view,C.deslColisor,Q) as GameObject;

		if(parentearNoOsso)
			view2.transform.parent = transform.Find(C.osso).transform;
		else
			view2.transform.parent = transform;
		
		view2.transform.localPosition = C.deslTrail;
		view2.transform.localRotation = view.transform.rotation;
		view2.GetComponent<BoxCollider>().center = C.deslColisor;
		view2.name = "colisor"+nomeColisor;
		
		
		/*
				PARA DESTUIR O COLISOR .
				QUANDO O GOLPE ERA INTERROMPIDO 
				O COLISOR PERMANECIA NO PERSONAGEM
			 *
		Destroy(view2,tempoDestroy-tempoDecorrido);


		/*************************************************************


		projetil proj = view2.AddComponent<projetil>();
		proj.velocidadeProjetil = 0f;
		proj.noImpacto = noImpacto;
		proj.dono = gameObject;
		//			proj.forcaDoDano = 25f;
		addView = true;
	}*/

	void impactoAtivo(nomesGolpes nomeColisor,string nomeTrail)
	{
		 
		if(!procurouAlvo)
			alvoProcurado = acaoDeGolpeRegenerate.procureUmBomAlvo(gameObject);
		
		if(tempoDecorrido>ativa.tempoMoveMin && !addView)
		{

			acaoDeGolpeRegenerate.adicionaOColisor(this,transform,tempoDecorrido,
				nomeColisor,nomeTrail,ativa.tempoDestroy);

			addView = true;
			
		}

		
		if(tempoDecorrido<ativa.tempoMoveMax && tempoDecorrido>ativa.tempoMoveMin)
		{
			if(((int)(tempoDecorrido*10))%2==0 &&alvoProcurado)
				ajudaAtaque(alvoProcurado.gameObject);

			if(!controle)
				controle = GetComponent<CharacterController>();
			controle.Move(25f*transform.forward*Time.deltaTime+Vector3.down * Y.gravidade);
		}
		
		if(tempoDecorrido>ativa.tempoDestroy&& !retorno)
		{
			fimDaAcaoGolpe();
		}

	}

	public void fimDaAcaoGolpe()
	{

		umC.ataqueComPulo = false;
		liberaDoAtacando();

		Destroy(this);
	}

	/*
	Transform procureUmBomAlvo(float distancia = 40)
	{
		GameObject[] criatures = GameObject.FindGameObjectsWithTag("Criature");
		GameObject alvo = null;
		Vector3 vendo = Vector3.zero;
		Vector3 c = Vector3.zero;
		List<GameObject> inimigosPerto = new List<GameObject>();



		foreach(GameObject criature in criatures)
		{
			if(criature != gameObject)
			{
				c = criature.transform.position;
				vendo = c - transform.position;



				if(vendo.sqrMagnitude < Mathf.Pow(distancia,2) )
					inimigosPerto.Add(criature);
			}
		}



		if(inimigosPerto.Count!=0)
		{
			GameObject deMelhorVisao = null;
			GameObject maisPerto = null;

			foreach(GameObject criature in inimigosPerto)
			{
				c =criature.transform.position;
				maisPerto = maisPerto !=null 
				?
					(c-transform.position).sqrMagnitude
						<
					(maisPerto.transform.position-transform.position).sqrMagnitude
					?
					criature
					:
					maisPerto
				:criature;

				deMelhorVisao = deMelhorVisao == null
					?
					criature
					:
					Vector3. Dot((c-transform.position).normalized,
						transform.forward)
						>
					Vector3.Dot(
							(deMelhorVisao.transform.position-transform.position)
							.normalized,
							transform.forward
							)
					?
					criature
					:
					deMelhorVisao;
			}



			if(deMelhorVisao == maisPerto
			   &&
			   Vector3.Dot(
				(deMelhorVisao.transform.position-transform.position).normalized,
			   transform.forward)>0)
			{
				alvo = Vector3.Dot((maisPerto.transform.position - 
				        transform.position).normalized,
				        transform.forward)>0.5
					? deMelhorVisao : null;
			}else
			{
				if((maisPerto.transform.position - transform.position)
				   .sqrMagnitude<25 &&
				   Vector3.Dot((maisPerto.transform.position - 
				     transform.position).normalized,
				     transform.forward)>0.5
				   )
					alvo = maisPerto;
				else
					alvo = Vector3.Dot((deMelhorVisao .transform.position - 
					         transform.position).normalized,
					         transform.forward )>0.5
						?deMelhorVisao : null ;
			}
		}

		procurouAlvo = true;


		ajudaAtaque(alvo);

		return alvo!=null  ?   alvo.transform   :   null;
	}*/

	void ajudaAtaque(GameObject alvo)
	{

		Vector3 gira = Vector3.zero;
		if(alvo != null){
			gira = alvo.transform.position - transform.position;

			gira.y = 0;
			transform.rotation = Quaternion.LookRotation(gira);

		}
	}

	void anime(string animacao)
	{
		animaAtiva.Add("atacando");
		animator.SetBool("atacando",true);
		animator.Play(animacao);
	}

	void ataqueEmissor(){
		
		paraliseNoTempo ();
		forwardInicial = transform.forward;
		useOEmissor ();
		anime ("emissor");
	}

	float verifiqueAtrasoDeAnimacao()
	{
		float atraso = 0;
		if(Y.tempoDeInstancia.ContainsKey(ativa.nomeID))
		{
			atraso = Y.tempoDeInstancia[ativa.nomeID];
		}
		return atraso;
	}

	
	void projetilPadrao(string tipo,string noImpacto,float velocidade,
	                    float tempoDeGolpe = 10,float tempoDeScript = 2)
	{
		projetilPadrao(tipo,ativa.nomeID.ToString(),noImpacto,velocidade,tempoDeGolpe,tempoDeScript);
	}

	void projetilPadrao(string tipo,string nomeProjetil,string impacto,
	                    float velocidade,float tempoDeGolpe = 10,float tempoDeScript= 2)
	{

		 
		float tempoDeAtraso = verifiqueAtrasoDeAnimacao();
		if(!addView && tempoDecorrido>ativa.tempoMoveMin+tempoDeAtraso)
		{
			if(tempoDeAtraso>0)
				useOEmissor();
			GameObject KY = instancieEDestrua (nomeProjetil,tempoDeGolpe,tempoDeScript);


			Iprojetil proj = null;
			switch(tipo)
			{
			case "rigido":
				proj = KY.AddComponent<projetilRigido>();
			break;
			case "basico":
				proj = KY.AddComponent<projetil>();
			break;
			case "status":
				proj = KY.AddComponent<projetilStatusExpansivel>();
			break;
			case "direcional":
				projetilDirecional projD = KY.AddComponent<projetilDirecional>();
				projD.alvo = (gameObject.name=="inimigo")?GameObject.Find("CriatureAtivo"):GameObject.Find("inimigo");
				proj = projD;
			break;
			}

			proj.velocidadeProjetil = velocidade;
			proj.noImpacto = impacto;
			proj.dono = gameObject;
			addView = true;
		}
		
		if(tempoDecorrido >ativa.tempoMoveMax+tempoDeAtraso && !retorno){
			liberaDoAtacando();
		}
	}

	void useOEmissor()
	{

		float maisEmissao = 0;
		float acimaDoChao = 0;
		if(Y.distanciaEmissora!=null)
			if(Y.distanciaEmissora.ContainsKey(ativa.nomeID))
				maisEmissao = Y.distanciaEmissora[ativa.nomeID];

		if(Y.acimaDoChao!=null)
			if(Y.acimaDoChao.ContainsKey(ativa.nomeID))
				acimaDoChao = Y.acimaDoChao[ativa.nomeID];
		
		posInicial = transform.Find(Y.emissor).position
			+transform.forward*(ativa.DistanciaDeEmissao+maisEmissao)
				+Vector3.up*acimaDoChao;
	}

	void paraliseNoTempo()
	{
		tempoDecorrido = 0.0f;
		if(GetComponent<movimentoBasico>())
			GetComponent<movimentoBasico>().podeAndar = false;
		else if(GetComponent<IA_inimigo>()){
			GetComponent<IA_inimigo>().interrompeIA();
		}
	}

	public GameObject instancieEDestrua(string nomeGolpe,float tempoDeGolpe ,float tempoDeScript)
	{

		GameObject golpeX =  elementos.retorna (nomeGolpe);

		golpeX = (GameObject)Instantiate( golpeX ,posInicial,Quaternion.LookRotation(forwardInicial) );

		Destroy(golpeX, tempoDeGolpe );
		Destroy(this, tempoDeScript);
		return golpeX;
	}

	public GameObject instancieEDestrua(Vector3 posInicial,Vector3 forwardInicial,string nomeGolpe,float tempoDeGolpe ,float tempoDeScript)
	{
		this.forwardInicial = forwardInicial;
		this.posInicial = posInicial;
		return instancieEDestrua(nomeGolpe,tempoDeGolpe,tempoDeScript);
	}

	void liberaMovimento()
	{
		if(GetComponent<movimentoBasico>())
			GetComponent<movimentoBasico>().podeAndar = true;
		else if(GetComponent<IA_inimigo>())
			GetComponent<IA_inimigo>().podeAtualizar = true;
	}

	void bolaDeFogoAtiva()
	{
		 
		if(tempoDecorrido >1 && !retorno){
			liberaDoAtacando();
		}
	}

	void ataqueBolaDeFogo()
	{
		useOEmissor ();
		paraliseNoTempo ();
		forwardInicial = transform.forward;
		GameObject KY = instancieEDestrua ("bolaDeFogo",2,2);
		projetil proj = KY.AddComponent<projetil>();
		proj.velocidadeProjetil = 10f;
		proj.dono = gameObject;
		proj.noImpacto = "impactoDeFogo";


	}

	IEnumerator intanciaComTempo(float tempo)
	{
		yield return new WaitForSeconds(tempo);
		useOEmissor();
		instancieEDestrua ("rajadaDeAgua",2,2);
	}

	void ataqueRajadaDeAgua()
	{
		ataqueEmissor ();

		if(Y.tempoDeInstancia.ContainsKey(nomesGolpes.rajadaDeAgua))
			StartCoroutine(intanciaComTempo(Y.tempoDeInstancia[nomesGolpes.rajadaDeAgua]));
		else
			instancieEDestrua ("rajadaDeAgua",2,2);
	}


	public void calculaDano(Transform T)
	{
		calculaDano(T,Y);
	}

	public void calculaDano_PokemonCalc(Transform T,Criature Y)
	{
		if(Y == null)
		{
			Y = new Criature();
		}
		Criature X = T.GetComponent<umCriature>().criature();


		float efetividade = 1;
		
		for (uint i=0;i<X.contraTipos.Length;i++)
		{
			if(ativa.Tipo.ToString() == X.contraTipos[i].Nome)
			{
				efetividade*=X.contraTipos[i].Mod;
			}
		}

		int variacao = Random.Range(85,101);
		int nivel  = (int)Y.mNivel.Nivel;
		int ataque = (ativa.CaracGolpe != caracGolpe.colisao )
			?
				(int)Y.cAtributos[2].Corrente
				:
				(int)Y.cAtributos[3].Corrente;
		float poderDoAtaque = ativa.Corrente+ativa.mod;

		int defesa = (int)X.cAtributos[4].Corrente;
		float danoX = (0.01f*efetividade*variacao*((0.2f*nivel+1)*ataque*poderDoAtaque/(25*defesa)));
		int dano = (int)danoX;

		print(defesa+" : "+efetividade+" : "+variacao+" : "+ataque+" : "+poderDoAtaque+" : "+" eu "+danoX);
		if(elementos==null)
			elementos = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ();
		
		GameObject visaoDeDano = elementos.retorna("visaoDeDano");
		visaoDeDano = (GameObject)Instantiate(visaoDeDano,T.position,Quaternion.identity);
		visaoDeDano.GetComponent<danoAparecendo>().dano = dano;
		
		if(X.cAtributos[0].Corrente-dano>0)
			X.cAtributos[0].Corrente -= (uint)dano;
		else
			X.cAtributos[0].Corrente = 0;
	}


	public void calculaDano(Transform T,Criature Y)
	{
		if(Y == null)
		{
			Y = new Criature();
		}
		Criature X = T.GetComponent<umCriature>().criature();
		//golpe golpeDeDano = resgataGolpe(ativa, Y);
		int dano;
		float multiplicador = 1;

		for (uint i=0;i<X.contraTipos.Length;i++)
		{
			if(ativa.Tipo.ToString() == X.contraTipos[i].Nome)
			{
				multiplicador*=X.contraTipos[i].Mod;
			}
		}

//		print (multiplicador+" :  tipo"+ativa.Tipo+ " : nome X"+X.Nome);
	

		int pod = (ativa.CaracGolpe != caracGolpe.colisao )
			?
				Mathf.RoundToInt (Y.cAtributos [2].Basico + (Y.cAtributos [2].Corrente - Y.cAtributos [2].Basico) * Random.Range(0.85f,1))
			:
				Mathf.RoundToInt (Y.cAtributos [3].Basico + (Y.cAtributos [3].Corrente - Y.cAtributos [3].Basico) * Random.Range(0.85f,1))	;


//		print(Y.cAtributos [2].Basico+" : "+ (Y.cAtributos [2].Corrente - Y.cAtributos [2].Basico).ToString()+" : "+pod);
//		print(Y.cAtributos [3].Basico+" : "+ (Y.cAtributos [3].Corrente - Y.cAtributos [3].Basico).ToString()+" : "+pod);


		dano = Mathf.Abs(Mathf.RoundToInt( multiplicador * (ativa.Corrente+ativa.mod+ pod)));

//		print(dano+" : "+multiplicador+" :  "+ativa.Corrente+" : "+ativa.mod);

		int defesa = Mathf.RoundToInt(X.cAtributos[4].Corrente*Random.value);

//		print(defesa);
		if(defesa<0.75f*dano)
			dano-=defesa;
		else
			dano = (int)(0.25f*dano)>0?(int)(0.25f*dano):1;

		if(dano>ativa.Maximo && multiplicador<=1)
			dano = (int)ativa.Maximo;

		if(elementos==null)
			elementos = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ();

		mostraDano(elementos,T,dano);

		aplicaDano(X,dano);
		print("O dano do GOlpe e "+dano);
		if(X.cAtributos[0].Corrente > 0 )
			aplicaStatus(T,X,ativa,Y);
	}

	public static void aplicaDano(Criature X,int dano)
	{
		if(X.cAtributos[0].Corrente-dano>0)
			X.cAtributos[0].Corrente -= (uint)dano;
		else
			X.cAtributos[0].Corrente = 0;
	}

	public static void mostraDano(elementosDoJogo elementos,Transform T, int dano)
	{
		GameObject visaoDeDano = elementos.retorna("visaoDeDano");
		visaoDeDano = (GameObject)Instantiate(visaoDeDano,T.position,Quaternion.identity);
		visaoDeDano.GetComponent<danoAparecendo>().dano = dano;
	}

	public static void aplicaStatus(Transform T,Criature X,golpe ativa,Criature Y)
	{
		int numStatus;


		switch(ativa.nomeID)
		{
		case nomesGolpes.agulhaVenenosa:
		case nomesGolpes.ondaVenenosa:
		case nomesGolpes.chuvaVenenosa:
			if(recebeStatus(X,ativa,Y))
			{
				envenenado e;
				numStatus = statusTemporarioBase.contemStatus(tipoStatus.envenenado,X);
				if(numStatus==-1)
				{
					e = T.gameObject.AddComponent<envenenado>();
					e.forcaDoDano = 2;
				}else
				{
					e = T.GetComponent<envenenado>();
					e.forcaDoDano++;
					e.tempoAteOProximoApply*=(14f/15f);
					X.statusTemporarios[numStatus].forcaDoDano++;
					X.statusTemporarios[numStatus].tempoAteOProximoApply*=(14f/15f);
				}
			}
		break;
		case nomesGolpes.olharMal:
			amedrontado a;
			numStatus = statusTemporarioBase.contemStatus(tipoStatus.amedrontado,X);
			if(numStatus == -1)
			{
			 	a = T.gameObject.AddComponent<amedrontado>();
				a.tempoAteOProximoApply = 37;
				a.oAfetado = X;
			}else
			{
				a = T.GetComponent<amedrontado>();
				a.tempoAteOProximoApply += 36;
			}
		break;
		case nomesGolpes.olharParalisante:
			paralisado p;
			numStatus = statusTemporarioBase.contemStatus(tipoStatus.paralisado,X);
			if(numStatus == -1)
			{
				p = T.gameObject.AddComponent<paralisado>();
				p.tempoAteOProximoApply = 30;
				p.oAfetado = X;
			}else
			{
				p = T.GetComponent<paralisado>();
				p.tempoAteOProximoApply += 25;
			}
			break;
		}
	}

	static bool recebeStatus(Criature X/*O que recebe o Status*/,golpe ativa,Criature Y)
	{
		bool retorno = false;
		switch(ativa.nomeID)
		{
		case nomesGolpes.agulhaVenenosa:
		case nomesGolpes.ondaVenenosa:
		case nomesGolpes.chuvaVenenosa:
			float ff = ativa.Corrente*
				Mathf.Max(1,
				          Random.Range(0.75f,1f)*Y.cAtributos[(int)nomesAtributos.Poder].Corrente-
				          Random.Range(0,0.75f)*X.cAtributos[(int)nomesAtributos.Defesa].Corrente);
			if(X.contraTipos[(int)nomeTipos.Veneno].Mod*ff+Random.Range(0,100)>80)
				retorno = true;
		break;
		}

		return retorno;
	}

	void testeDeVida(Transform Y,Animator Z)
	{
		float W = Y.GetComponent<umCriature> ().criature ().cAtributos [0].Corrente;
		if(W<=0)
		{
			Z.CrossFade("cair",0);
		}

	}

	public void paraliseAdversario(Transform meAjuda)
	{
		if(meAjuda.GetComponent<movimentoBasico>())
			meAjuda.GetComponent<movimentoBasico>().podeAndar = false;
		else if(meAjuda.GetComponent<IA_inimigo>())
			meAjuda.GetComponent<IA_inimigo>().podeAtualizar = false;
	}

	public void tomaDanoUm(Transform T = null)
	{

		//golpe G = resgataGolpe(ativa,Y);
		if (T == null)
				T = hit.transform;
		Transform meAjuda = T;
		Animator animatorEnemy = meAjuda.GetComponent<Animator>();
		animatorEnemy.Play("dano2");
		animatorEnemy.SetBool("dano1",true);
		animatorEnemy.Play("dano1");
		paraliseAdversario(meAjuda);
		tomaDano1 dano1 = meAjuda.gameObject.AddComponent<tomaDano1>();
		dano1.direcaoDoDano = transform.forward;
//		print(ativa.RepulsaoDoDano);
		dano1.solavanco = ativa.RepulsaoDoDano;
		dano1.forcaDoDano =0.5f*ativa.RepulsaoDoDano;
		dano1.tempoNoDano = ativa.TempoNoDano;

		if(impactos == 0)
			calculaDano(T,Y);
	
		testeDeVida (meAjuda,animatorEnemy);

		dano1.vivo = (meAjuda.GetComponent<umCriature>().criature().cAtributos[0].Corrente != 0);

	}

	void rajadaDeAguaAtiva()
	{
		if(!addView)
		{
			float tempoDeAtraso = 0;
			if(Y.tempoDeInstancia.ContainsKey(nomesGolpes.rajadaDeAgua))
				tempoDeAtraso = Y.tempoDeInstancia[nomesGolpes.rajadaDeAgua];
			tempoDecorrido-=tempoDeAtraso;
			addView = true;
		}

		 
		hit = new RaycastHit();
		if(tempoDecorrido>1 && !retorno){
			liberaDoAtacando();
		}
		if(tempoDecorrido>0){

			Vector3 ort = Vector3.Cross(forwardInicial,Vector3.up).normalized;
			
			float deslocadorInicial = tempoDecorrido>1?tempoDecorrido:1;
			float deslocadorFinal = tempoDecorrido<0.7f?tempoDecorrido:0.7f;
			Debug.DrawLine(posInicial+25*(deslocadorInicial-1)*forwardInicial,posInicial+forwardInicial*25*deslocadorFinal,Color.red);
			Debug.DrawLine(
				posInicial+25*(deslocadorInicial-1)*forwardInicial+0.25f*Vector3.up,
				posInicial+0.25f*Vector3.up+forwardInicial*25*deslocadorFinal,
				Color.red);
			Debug.DrawLine(
				posInicial+25*(deslocadorInicial-1)*forwardInicial-0.25f*Vector3.up,
				posInicial-0.25f*Vector3.up+forwardInicial*25*deslocadorFinal,
				Color.red);
			Debug.DrawLine(
				posInicial+25*(deslocadorInicial-1)*forwardInicial-0.25f*ort,
				posInicial-0.25f*ort+forwardInicial*25*deslocadorFinal,
				Color.red);

			if(Physics.Linecast(posInicial+25*(deslocadorInicial-1)*forwardInicial,posInicial+forwardInicial*25*tempoDecorrido,out hit)
			   ||
			   Physics.Linecast(
				posInicial+25*(deslocadorInicial-1)*forwardInicial-0.25f*Vector3.up,
				posInicial-0.25f*Vector3.up+forwardInicial*25*tempoDecorrido,
				out hit)
			   ||
			   Physics.Linecast(
				posInicial+25*(deslocadorInicial-1)*forwardInicial-0.25f*ort,
				posInicial-0.25f*ort+forwardInicial*25*tempoDecorrido,
				out hit)
			   ||
			   Physics.Linecast(
				posInicial+25*(deslocadorInicial-1)*forwardInicial+0.25f*ort,
				posInicial+0.25f*ort+forwardInicial*25*tempoDecorrido,
				out hit)

			   )
			{
				if( impactos%10==0){
					GameObject Golpe  = elementos.retorna ("impactoDeAgua");
					Object impacto = Instantiate(Golpe,hit.point,Quaternion.identity);
					Destroy(impacto,0.5f);
					if(hit.transform.GetComponent<umCriature>())
					{
					if(hit.transform.GetComponent<umCriature>().criature().cAtributos[0].Corrente>0)
					{
						tomaDanoUm();
					}
					}
				}
				impactos++;
			}
		}
	}
}
