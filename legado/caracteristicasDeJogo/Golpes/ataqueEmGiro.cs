using UnityEngine;
using System.Collections;

[System.Serializable]
public class ataqueEmGiro:golpe{
	public ataqueEmGiro()
	{
		
		Tipo = nomeTipos.Normal.ToString ();
		Basico = 4;
		Corrente = 4;
		TempoReuso = 5.75f;
		UltimoUso = -6f;
		Maximo = 10;
		Nome = "Ataque em Giro";
		TempoNoDano = 0.25f;  //Tempo que o inimigo permanece na animacao de Dano
		RepulsaoDoDano = 55f; // forca com que o inimigo e lançado longe durante o golpe
		CaracGolpe = caracGolpe.colisao;
		tempoMoveMin = 0.25f;
		tempoMoveMax = 2f;
		tempoDestroy = 1;
		
	}

	private Criature Y;

	public override void Start(movimentoBasico mB,
	                           IA_inimigo IA,Transform T,Animator A,acaoDeGolpe aG)
	{

		base.Start(mB,IA,T,A,aG);
		Y = aG.GetComponent<umCriature>().criature();
		acaoDeGolpeRegenerate.impactoBasico(nomeID.ToString(),
		                                   mB,IA,T,A);

	}


	public override void Update()
	{

		tempoDecorrido+=Time.deltaTime;
		if(!procurouAlvo)
			alvoProcurado = acaoDeGolpeRegenerate.procureUmBomAlvo(T.gameObject);
		
		if(tempoDecorrido>tempoMoveMin && !addView)
		{
			acaoDeGolpeRegenerate.adicionaOColisor (aG,T,tempoDecorrido,nomeID,"umCuboETrailMaior",tempoDestroy);	
			addView = true;
		}

		if(((int)(10*tempoDecorrido))%1==0)
		{
			aG.facaDestroy(
			aG.facaInstantiate(
				elementosDoJogo.el.retorna("poeiraAoVento"),
				T.position,
				Quaternion.identity
				),2);
		}
		
		float sinal = 1;
		Vector3 dir = T.forward;
		if(tempoDecorrido<tempoMoveMax && tempoDecorrido>tempoMoveMin)
		{
			if(alvoProcurado)
			{
				if(Vector3.Angle(dir,alvoProcurado.position-T.position)>100)
					sinal = -1;
				dir =   Vector3.Slerp(dir,sinal*(alvoProcurado.position-T.position),0.9f*Time.deltaTime);
				Quaternion.LookRotation(
					Vector3.ProjectOnPlane(dir,Vector3.up)
					);
			}
			
			if(!controle)
				controle = T.GetComponent<CharacterController>();
			controle.Move(55*T.forward*Time.deltaTime+Vector3.down * Y.gravidade);
		}
		
		if(tempoDecorrido>tempoDestroy&& !retorno)
		{
			aG.fimDaAcaoGolpe();
		}

	}
}

