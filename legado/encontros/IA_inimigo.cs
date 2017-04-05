using UnityEngine;
using System.Collections;

public class IA_inimigo : comandos {
	
	public bool podeAtualizar = false;
	
	public Criature C;
	
	
	private float roletaDeGolpes = 0;
	//private acaoDeGolpe aG;
	protected Transform alvo;
	protected float coolDown;
	private sigaOLider siga;
	private UnityEngine.AI.NavMeshAgent nav;
	private Criature criatureAlvo;
	
	
	
	// Use this for initialization
	void Start () {
		controle = GetComponent<CharacterController> ();
		animator = GetComponent<Animator>();
		animator.SetBool("noChao",true);
		remendoDeBug();
		
		
	}
	
	public void remendoDeBug()
	{
		C = GetComponent<umCriature>().X;
		//		print("nivel IA: "+C.mNivel.Nivel);
		defineAlvo();
		C.golpeEscolhido = proximoGolpe();	
		
		for(int i=0;i<C.Golpes.Length;i++)
		{
			roletaDeGolpes += C.Golpes[i].taxaDeUso;
		}
	}

	void afastamento()
	{
		if(alvo && C!= null)
		{
			transform.forward = Vector3.Lerp(transform.forward,alvo.forward+alvo.right,5*Time.deltaTime);
			transform.rotation = Quaternion.LookRotation(transform.forward);
			controle.Move(transform.forward*C.velocidadeAndando*Time.deltaTime);
			animator.SetFloat("velocidade",5*controle.velocity.magnitude);
		}
		
		if(coolDown<10)
		{
			C.golpeEscolhido = proximoGolpe();
		}
	}
	
	
	protected virtual int proximoGolpe()
	{
		//bool foi = false;
		float roleta = Random.Range(0,roletaDeGolpes);
		float sum = 0;
		int retorno = -1;
		//while(!foi){
		for(int i=0;i<C.Golpes.Length;i++)
		{
			
			sum += C.Golpes[i].taxaDeUso;
			
			
			if(roleta<=sum && retorno==-1)
				retorno = i;
		}
		
		
		retorno =  retorno==-1?0:retorno;
		if(C.Golpes[retorno].UltimoUso >= Time.time -  C.Golpes[retorno].TempoReuso)
			for(int i=0;i<C.Golpes.Length;i++)
		{
			if(C.Golpes[i].UltimoUso < Time.time -  C.Golpes[i].TempoReuso)
				retorno = i;
		}
		
		//}
		
		return retorno==-1?0:retorno;
	}
	
	protected void procureColisao()
	{
		//golpe gg = new golpe();
		bool foi = false;
		for(int i=0;i<C.Golpes.Length;i++)
		{
			if(C.Golpes[i].CustoPE==0)
			{
				//gg = C.Golpes[i];
				foi = true;
				C.golpeEscolhido = i;
			}
		}
		
		if(foi)
		{
			coolDown = 0;
			//aplicabilidadeDeGolpe(C);
			/*
			aplicaGolpe(gg,transform.Find(C.emissor).position
			            +transform.forward*C.Golpes[C.golpeEscolhido].DistanciaDeEmissao );
			            */
		}else
		{
			aumentaPE();
		}
	}
	
	void aumentaPE()
	{
		C.cAtributos[1].Corrente = C.cAtributos[1].Maximo;
	}
	
	
	protected virtual void disparador()
	{
		
		coolDown = C.tempoReacaoCorrente;
		
		Vector3 olhe = alvo.position - transform.position;
		olhe = new Vector3(olhe.x,0,olhe.z);
		transform.rotation = Quaternion.LookRotation(olhe);
		if(C.Golpes[C.golpeEscolhido].CustoPE<=C.cAtributos[1].Corrente){
			
			
			aplicaGolpe(C);
			/*
		aplicaGolpe(C.Golpes[C.golpeEscolhido],transform.Find(C.emissor).position
		            +transform.forward*C.Golpes[C.golpeEscolhido].DistanciaDeEmissao );
		            */
		}else{
			procureColisao();
		}
		C.golpeEscolhido = proximoGolpe();	
	}
	
	// Update is called once per frame
	protected void Update () {
		if(!pausaJogo.pause){
			coolDown-=Time.deltaTime;
			
			
			if(alvo != null 
			   && 
			   podeAtualizar 
			   &&  
			   coolDown < 0
			   && 
			   C.cAtributos[0].Corrente>0
			   &&
			   (
				noChao(C.distanciaFundamentadora+0.5f) 
				||
				C.Golpes[C.golpeEscolhido].CaracGolpe == caracGolpe.colisaoComPow
				||
				C.Golpes[C.golpeEscolhido].CaracGolpe == caracGolpe.colisao)
			   )
			{		
				if(criatureAlvo.cAtributos[0].Corrente>0 ){
					golpe GG = C.Golpes[C.golpeEscolhido];
					//print(GG.CaracGolpe+" : "+GG.Nome);
					if(GG.CaracGolpe == caracGolpe.colisao )
					{
						if(statusTemporarioBase.contemStatus(tipoStatus.amedrontado,C)>-1)
						{
							afastamento();
						}else
						//print((alvo.position-transform.position).magnitude+" : "+(GG.tempoMoveMax-GG.tempoMoveMin));
						if((alvo.position-transform.position).magnitude
						   > 
						   18f*(GG.tempoMoveMax-GG.tempoMoveMin)
						   )
						{
							retornaOMovimento();
							
						}else{
							if(siga != null){
								siga.enabled = false;
								if(nav == null)
									
									nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
								
								nav.enabled = false;
								
								animator.SetFloat("velocidade",0);
							}
							
							disparador();
							
						}
					}else{
						disparador();
					}
				}
				
				
			}else if( C.cAtributos[0].Corrente<=0 && GameObject.Find("CriatureAtivo"))
			{
				paraMovimento();
				animator.CrossFade("cair",0);
			}
			else if(!podeAtualizar)// essas linhas estavam comentadas, descomentei para corrigir o Bug que fazia 
				paraMovimento();// o inimigo atacar mesmo tomando dano (nao sei se contribuiu para a soluçao)
			else if(GameObject.Find("CriatureAtivo"))
				defineAlvo();
		}
	}
	
	public void retornaOMovimento()
	{
		if(nav == null){
			nav = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
			nav.speed = C.velocidadeAndando;
		}

		nav.enabled = true;

		if(statusTemporarioBase.contemStatus(tipoStatus.paralisado,C)>-1)
			nav.speed = C.velocidadeAndando/5;
		
		if(siga == null)
			siga = gameObject.AddComponent<sigaOLider>();

		siga.enabled = true;
		
		
		if(!GameObject.Find("CriatureAtivo"))
			siga.lider = transform;
		else
			siga.lider = alvo;
		
	}
	
	public void interrompeIA()
	{
		podeAtualizar = false;
		paraMovimento();
		coolDown = C.tempoReacaoCorrente;
	}
	
	public void retornaIA()
	{
		podeAtualizar = true;
		//retornaOMovimento();
		if(coolDown<0.5f)
			coolDown += 1;
	}
	
	public void paraMovimento()
	{
		
		if(siga!= null)
			Destroy(siga);//siga.enabled = false;
		if(nav!= null)
			Destroy(nav);//nav.enabled = false;
		
		
		//auxAnimator.parametrosPadroes(animator);
	}
	
	public void defineAlvo()
	{
		alvo = GameObject.Find("CriatureAtivo").transform;
		criatureAlvo = alvo.GetComponent<umCriature>().criature();
	}
	
}