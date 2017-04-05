using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class acaoDeGolpeRegenerate  {

	public static void impactoBasico(string impacto,
	                                 movimentoBasico mB,
	                                 IA_inimigo IA,
	                                 Transform T,
	                                 Animator A)
	{
		paraliseNoTempo(mB,IA);
		//Vector3 forwardInicial = T.forward;
		anime(impacto,A);
	}

	public static void anime(string animacao,Animator A)
	{
		A.SetBool("atacando",true);
		A.Play(animacao);
	}

	public static void paraliseNoTempo(movimentoBasico mB,IA_inimigo IA)
	{
		if(mB)
			mB.podeAndar = false;
		else if(IA){
			IA.interrompeIA();
		}

	}

	public static Transform procureUmBomAlvo(GameObject esseObjeto,float distancia = 40)
	{
		GameObject[] criatures = GameObject.FindGameObjectsWithTag("Criature");
		GameObject alvo = null;
		Vector3 vendo = Vector3.zero;
		Vector3 c = Vector3.zero;
		List<GameObject> inimigosPerto = new List<GameObject>();
		Transform T = esseObjeto.transform;
		
		
		
		foreach(GameObject criature in criatures)
		{
			if(criature != esseObjeto)
			{
				c = criature.transform.position;
				vendo = c - T.position;
				
				
				
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
						(c-T.position).sqrMagnitude
						<
						(maisPerto.transform.position-T.position).sqrMagnitude
						?
						criature
						:
						maisPerto
						:criature;
				
				deMelhorVisao = deMelhorVisao == null
					?
						criature
						:
						Vector3. Dot((c-T.position).normalized,
						             T.forward)
						>
						Vector3.Dot(
							(deMelhorVisao.transform.position-T.position)
							.normalized,
							T.forward
							)
						?
						criature
						:
						deMelhorVisao;
			}
			
			
			
			if(deMelhorVisao == maisPerto
			   &&
			   Vector3.Dot(
				(deMelhorVisao.transform.position-T.position).normalized,
				T.forward)>0)
			{
				alvo = Vector3.Dot((maisPerto.transform.position - 
				                    T.position).normalized,
				                   T.forward)>0.5
					? deMelhorVisao : null;
			}else
			{
				if((maisPerto.transform.position - T.position)
				   .sqrMagnitude<25 &&
				   Vector3.Dot((maisPerto.transform.position - 
				             T.position).normalized,
				            T.forward)>0.5
				   )
					alvo = maisPerto;
				else
					alvo = Vector3.Dot((deMelhorVisao .transform.position - 
					                    T.position).normalized,
					                   T.forward )>0.5
						?deMelhorVisao : null ;
			}
		}
		
		//procurouAlvo = true;
		
		
		ajudaAtaque(alvo,T);
		
		return alvo!=null  ?   alvo.transform   :   null;
	}

	static void ajudaAtaque(GameObject alvo,Transform T)
	{
	
		Vector3 gira = Vector3.zero;
		if(alvo != null){
			gira = alvo.transform.position - T.position;
			
			gira.y = 0;
			T.rotation = Quaternion.LookRotation(gira);
			
		}
	}

	public static colisor pegueOColisor(nomesGolpes nomeColisor,Criature XX)
	{
		colisor C = new colisor();
		
		/*
			Quando e feito um saveGame o Criature e salvo em essencia como esta no script,
			isso inclui os colisores,
			se algum golpe for inserido apos esse save e um novo colisor for inserido
			o novo colisor nao aparece no jogo salvo

			Para corrigir isso inseri essa linha que questiona a existencia do colisor
		 */
		
		if(XX.colisores.ContainsKey(nomeColisor))
			C = XX.colisores[nomeColisor];
		else{
			Criature XXX = new cCriature(XX.nomeID).criature();
			
			/*
				Essa linha verifica a existencia do colisor no script desse Criature,
				se existir insere no criature que lançou o golpe
				se nao existir da uma mensagem de atençao
			 */
			
			if(XXX.colisores.ContainsKey(nomeColisor))
				XX.colisores.Add(nomeColisor,XXX.colisores[nomeColisor] );
			else{
				Debug.LogWarning("O Colisor com o nome \""+nomeColisor+"\" nao foi encontrado para "+XX.Nome);
				return new colisor("erroColisor");
			}
			
		}
		
		return C;
	}
	
	public static void adicionaOColisor(acaoDeGolpe aG,Transform T,float tempoDecorrido,
						  nomesGolpes nomeColisor,
	                      string nomeTrail,float tempoDestroy,
	                      bool parentearNoOsso,
	                      Quaternion Q = default(Quaternion),
	                      string noImpacto = "impactoComum")
	{
		adicionaOColisor(aG,T,tempoDecorrido,nomeColisor,nomeTrail,tempoDestroy,noImpacto,parentearNoOsso,Q);
	}
	
	public static void adicionaOColisor(acaoDeGolpe aG,Transform T,float tempoDecorrido,
	                      nomesGolpes nomeColisor,
	                      float tempoDestroy,
	                      string noImpacto = "impactoComum",
	                      bool parentearNoOsso = true,
	                      Quaternion Q = default(Quaternion))
	{
		adicionaOColisor(aG,T,tempoDecorrido,
		                 nomeColisor,nomeColisor.ToString(),
		                 tempoDestroy,noImpacto,parentearNoOsso,Q);
	}
	
	public static void adicionaOColisor(acaoDeGolpe aG,Transform T,float tempoDecorrido, nomesGolpes nomeColisor,
	                      string nomeTrail,float tempoDestroy,
	                      string noImpacto = "impactoComum",
	                      bool parentearNoOsso = true,
	                      Quaternion Q = default(Quaternion))
	{
		GameObject view = elementosDoJogo.el.retornaColisor(nomeTrail);
		//		print(nomeColisor);
		colisor C = pegueOColisor(nomeColisor,aG.GetComponent<umCriature>().X);// = new colisor();
		
		if(C.osso=="erroColisor")
			return;
		
		GameObject view2 = aG.facaInstantiate(view,C.deslColisor,Q);

		
		if(parentearNoOsso)
			view2.transform.parent = T.Find(C.osso).transform;
		else
			view2.transform.parent = T;
		
		view2.transform.localPosition = C.deslTrail;
		view2.transform.localRotation = view.transform.rotation;
		view2.GetComponent<BoxCollider>().center = C.deslColisor;
		view2.name = "colisor"+nomeColisor;
		
		
		/*
				PARA DESTUIR O COLISOR .
				QUANDO O GOLPE ERA INTERROMPIDO 
				O COLISOR PERMANECIA NO PERSONAGEM
			 */
		aG.facaDestroy(view2,tempoDestroy-tempoDecorrido);
		
		
		/*************************************************************/
		
		
		projetil proj = view2.AddComponent<projetil>();
		proj.velocidadeProjetil = 0f;
		proj.noImpacto = noImpacto;
		proj.dono = T.gameObject;
		//			proj.forcaDoDano = 25f;
		//addView = true;
	}

	public static float verifiqueAtrasoDeAnimacao(Criature Y,nomesGolpes nomeID)
	{
		float atraso = 0;
		if(Y.tempoDeInstancia.ContainsKey(nomeID))
		{
			atraso = Y.tempoDeInstancia[nomeID];
		}
		return atraso;
	}

	public static void liberaMovimento(movimentoBasico mB,IA_inimigo IA)
	{
		if(mB)
			mB.podeAndar = true;
		else if(IA)
			IA.podeAtualizar = true;
	}

	public static void liberaDoAtacando(movimentoBasico mB,IA_inimigo IA,Animator A,out bool retorno)
	{
		liberaMovimento(mB,IA);
		A.SetBool("atacando",false);
		retorno = true;
	}
}
