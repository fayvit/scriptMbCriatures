using UnityEngine;
using System.Collections;

public class tomaDano1 : MonoBehaviour {


	public Vector3 direcaoDoDano = Vector3.back;
	public float forcaDoDano = 3f;
	public float tempoNoDano = 0.25f;
	public float solavanco = 12f;
	public bool vivo;

	public float tempoDeDano = 0;
	private CharacterController controle;
	private float alturaAtual;
	private float alturaDoDano;


	private Vector3 posicaoInicial = Vector3.zero;
	private Vector3 direcao = Vector3.zero;

	Animator animator ;




	// Use this for initialization
	void Start () {
		controle = GetComponent<CharacterController> ();
		alturaAtual = transform.position.y;
		alturaDoDano = alturaAtual;
		posicaoInicial = transform.position;
		transform.rotation = Quaternion.LookRotation (-direcaoDoDano);
		cancelaAcao();
		animator = GetComponent<Animator>();
		if(vivo)
			animator.CrossFade("dano1",0);

	}


	
	// Update is called once per frame
	void Update () {
		GetComponent<umCriature>().ataqueComPulo = false;

		tempoDeDano += Time.deltaTime;
		alturaAtual = transform.position.y;
		direcao = Vector3.zero;
		if(alturaAtual<alturaDoDano+0.5f){
			direcao += 12*Vector3.up;
		}
		if ((transform.position - posicaoInicial).sqrMagnitude < solavanco)
						direcao += forcaDoDano*direcaoDoDano;

		controle.Move (direcao*Time.deltaTime);

		if(tempoDeDano>tempoNoDano)
		{


			if(GetComponent<movimentoBasico>())// && GetComponents<tomaDano1>().Length == 1)
			{
				if(GetComponent<umCriature>().criature().cAtributos[0].Corrente>0)
						GetComponent<movimentoBasico>().podeAndar = true;
			}
			else if(GetComponent<IA_inimigo>())// && GetComponents<tomaDano1>().Length == 1)
			{
				GetComponent<IA_inimigo>().retornaIA();

			}
			//if(GetComponents<tomaDano1>().Length == 1)// nao sei bem o pq disso -  provavelmente e pela rajada de agua do Xuash
				animator.SetBool("dano1",false);
			Destroy(this);
		}
	}

	void cancelaAcao()
	{
		if(GetComponent<acaoDeGolpe>())
			GetComponent<acaoDeGolpe>().ativa = new pegaUmGolpe(nomesGolpes.cancelado).OGolpe();
	}
}
