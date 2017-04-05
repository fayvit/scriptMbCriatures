using UnityEngine;
using System.Collections;


[System.Serializable]
public class caracteristicasBasicas {

	public float velocidadeAndando = 1.0f;
	public float velocidadeCorrendo = 1.0f;
	public float gravidade  = 9.8f;

	/*
variaveis para a rotaçao
	 */
	public float velocidadeDeRotacao = 0.5f;
	public float velocidadeDeRotacaoParado = 1.0f;
	public float velocidadeDeRotacaoCorrendo = 0.25f;
	public float rot = 0.0f;
	/*
variaveis para os pulos
	 */
	public float apiceDoPulo = 1.2f;
	public float velocidadeCaindo = 7f;
	public float velocidadeNoAr = 4f;
	public float velocidadeSubindo = 5f;
	public float distanciaFundamentadora = 0.5f;

	/*
variaveis para a camera
	 */
	public float alturaCamera = 4f;
	public float distanciaCamera = 5.5f;
	public float velocidadeMaxAngular = 25f;

	public Vector3 apliqueGravidade(Vector3 movimentoVertical,Vector3 direcaoMovimento)
	{
		return movimentoVertical = Vector3.Lerp(movimentoVertical,
		                                 (direcaoMovimento * velocidadeAndando + Vector3.down * gravidade),
		                                 3*Time.deltaTime);

	}


}
