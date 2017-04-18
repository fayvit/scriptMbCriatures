using UnityEngine;
using System.Collections;

public static class GolpeDeProjetilBasico  {

	public static Vector3 ataqueEmissor(
		movimentoBasico mB,
		IA_inimigo IA,
		Transform T,
		out Vector3 posInicial,
		Animator A,golpe G,Criature Y){
		
		acaoDeGolpeRegenerate.paraliseNoTempo (mB,IA);
		Vector3 forwardInicial = T.forward;
		posInicial = useOEmissor (Y,G,T);
		acaoDeGolpeRegenerate.anime ("emissor",A);
		return forwardInicial;
	}

	public static Vector3 useOEmissor(Criature Y,golpe G,Transform T)
	{
		
		float maisEmissao = 0;
		float acimaDoChao = 0;
		if(Y.distanciaEmissora!=null)
			if(Y.distanciaEmissora.ContainsKey(G.nomeID))
				maisEmissao = Y.distanciaEmissora[G.nomeID];
		
		if(Y.acimaDoChao!=null)
			if(Y.acimaDoChao.ContainsKey(G.nomeID))
				acimaDoChao = Y.acimaDoChao[G.nomeID];
		
		Vector3 posInicial = T.Find(Y.emissor).position
			+T.forward*(G.DistanciaDeEmissao+maisEmissao)
				+Vector3.up*acimaDoChao;

		return posInicial;
	}

	public static void ColocaAddView(
		Vector3 posInicial,Vector3 forwardInicial,Criature Y,golpe G,Transform T,
		string tipo,float tempoDeAtraso,acaoDeGolpe aG,string nomeProjetil,float velocidade,
		string impacto = "impactoComum",float tempoDeGolpe = 10,float tempoDeScript = 2)
	{
		if(tempoDeAtraso>0)
			useOEmissor(Y,G,T);
		GameObject KY = aG.instancieEDestrua (posInicial,forwardInicial, nomeProjetil,tempoDeGolpe,tempoDeScript);
		
		
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
			projD.alvo = (aG.gameObject.name=="inimigo")?GameObject.Find("CriatureAtivo"):GameObject.Find("inimigo");
			proj = projD;
		break;
		}
		
		proj.velocidadeProjetil = velocidade;
		proj.noImpacto = impacto;
		proj.dono = aG.gameObject;
	}

}
