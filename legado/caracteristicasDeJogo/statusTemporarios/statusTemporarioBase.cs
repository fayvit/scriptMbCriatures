using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class statusTemporarioBase : MonoBehaviour {

	public float forcaDoDano = 1;
	public float tempoAteOProximoApply = 50;
	public tipoStatus esseStatus = tipoStatus.nulo;
	public Criature oAfetado;

	protected string[] textos;
	protected Transform particula;
	protected float tempoAcumulado = 0;


	public abstract void destrua();

	protected void Update()
	{
		if(particula)
		if(particula.localScale.x>1)
			particula.localScale = new Vector3(1,1,1);
	}

	protected void colocaAParticulaEAdicionaEsseStatus(string essaParticula)
	{
		particula = ((GameObject)Instantiate(elementosDoJogo.el.retorna(essaParticula),
		                                     Vector3.zero,Quaternion.identity)).transform;
		particula.parent = transform;
		particula.localPosition = Vector3.zero;
		particula.localRotation = Quaternion.identity;

		if(contemStatus(esseStatus,oAfetado)<=-1)
		{
			oAfetado.statusTemporarios.Add(new statusTemporario(forcaDoDano,tempoAteOProximoApply,esseStatus));
		}
	}

	public static void retiraComponenteStatus(tipoStatus esseStatus,GameObject G)
	{
		statusTemporarioBase[] osStatus = null;
		switch(esseStatus)
		{
		case tipoStatus.envenenado:
			osStatus = (statusTemporarioBase[])G.GetComponents<envenenado>();
		break;
		case tipoStatus.amedrontado:
			osStatus = (statusTemporarioBase[])G.GetComponents<amedrontado>();
		break;
		case tipoStatus.paralisado:
			osStatus = (statusTemporarioBase[])G.GetComponents<paralisado>();
		break;
		case tipoStatus.todos:
			osStatus = G.GetComponents<statusTemporarioBase>();
		break;
		}

		foreach(statusTemporarioBase sT in osStatus)
		{
			sT.destrua();
		}
	}

	public static void tiraStatus(tipoStatus tipo,List<statusTemporario> afetado)
	{
		if(afetado.Count>0)
		{
			List<statusTemporario> aTirar = new List<statusTemporario>();
			foreach(statusTemporario sT in afetado)
			{
				if(sT.esseStatus==tipo || tipo == tipoStatus.todos)
				{
					aTirar.Add(sT);
				}
			}

			for(int i=0;i<aTirar.Count;i++)
			{
				afetado.Remove(aTirar[i]);
			}
		}
	}

	public static void limpaStatus(Criature X,int i)
	{
//		List<statusTemporario> sT = X.statusTemporarios;

		statusTemporarioBase[] sTs;
		
		if(i==0)
		{
			GameObject G = GameObject.Find("CriatureAtivo");

			/*
			foreach(statusTemporario st in sT)
			{
				switch(st.esseStatus)
				{
				case tipoStatus.envenenado:
					
					envenenado e = G.GetComponent<envenenado> ();
					if(e)
						e.destrua();
					break;
				}
			}*/

			sTs = G.GetComponents<statusTemporarioBase>();
			foreach(statusTemporarioBase sTb in sTs)
			{
				sTb.destrua ();
			}

		}else
		{
			sTs = GameObject.Find("elementosDoJogo").GetComponents<statusTemporarioBase>();
			foreach(statusTemporarioBase sTb in sTs)
			{
				if(sTb.oAfetado == X)
				{
					Destroy(sTb);
				}
			}
		}
		
		X.statusTemporarios.Clear();
	}

	public static void statusAoGerente(GameObject G,int i)
	{
		Criature C = G.GetComponent<umCriature>().X;
		GameObject gerente = GameObject.Find("elementosDoJogo");
		foreach(statusTemporario sT in C.statusTemporarios )
		{
			switch(sT.esseStatus)
			{
			case tipoStatus.envenenado:
				envenenadoFora eF = gerente.AddComponent<envenenadoFora>();
				eF.oAfetado = C;
				eF.forcaDoDano = sT.forcaDoDano;
				eF.tempoAteOProximoApply = sT.tempoAteOProximoApply*2;
			break;
			case tipoStatus.amedrontado:
				amedrontado a = G.GetComponent<amedrontado>();
				a.atualizaTempoParaTroca();
				sT.tempoAteOProximoApply = a.tempoAteOProximoApply;
			break;
			case tipoStatus.paralisado:
				paralisado p = G.GetComponent<paralisado>();
				p.atualizaTempoParaTroca();
				sT.tempoAteOProximoApply = p.tempoAteOProximoApply;
			break;
			}
		}
	}

	public static void retiraStatusDoGerente(Criature C,tipoStatus tipo = tipoStatus.todos)
	{
		statusTemporarioBase[] sTs = GameObject.Find("elementosDoJogo").GetComponents<statusTemporarioBase>();

		foreach(statusTemporarioBase sT in sTs)
		{
			if(sT.oAfetado == C)
			{
				if(tipo == tipoStatus.todos)
					Destroy(sT);
				else
					if(tipo == sT.esseStatus)
						Destroy(sT);
			}
		}


	}

	public static void colocaStatus(GameObject G,List<statusTemporario> statusTemporarios)
	{
		if(statusTemporarios.Count > 0)
		{
			
			for(int i=0;i<statusTemporarios.Count;i++)
			{
				statusTemporarioBase st = null;
				switch(statusTemporarios[i].esseStatus)
				{
				case tipoStatus.envenenado:
					st =  G.AddComponent<envenenado>();
					break;
				case tipoStatus.amedrontado:
					st =  G.AddComponent<amedrontado>();
					break;
				case tipoStatus.paralisado:
					st =  G.AddComponent<paralisado>();
				break;
				}
				
				st.esseStatus = statusTemporarios[i].esseStatus;
				st.forcaDoDano = statusTemporarios[i].forcaDoDano;
				st.tempoAteOProximoApply = statusTemporarios[i].tempoAteOProximoApply;
			}
		}
	}

	public static int contemStatus(tipoStatus esseStatus,Criature X)
	{
		int retorno = -1;
		if(X.statusTemporarios.Count>0)
		{
			foreach(statusTemporario sT in X.statusTemporarios )
			{
				if(sT.esseStatus == esseStatus)
				{
					retorno = X.statusTemporarios.IndexOf(sT);
					
				}
			}
		}
		
		return retorno;
	}

}

public enum tipoStatus
{
	todos = -2,
	nulo = -1,
	envenenado,
	amedrontado,
	paralisado
}
