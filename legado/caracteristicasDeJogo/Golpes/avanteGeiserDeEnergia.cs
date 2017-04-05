using UnityEngine;
using System.Collections;

public class avanteGeiserDeEnergia : MonoBehaviour {
	
	public int final = 0;
	public Vector3 direcao;
	public Vector3 pos;
	public string quem;
	public acaoDeGolpe aG;

	private float velocidadeDeUltimaSubida = 2;
	private float tempoDeUltimaSubida = 0.5f;
	private float velocidadeSubindo = 15;
	private float tempoDeSubida = 2;
	private float contadorDeTempo = 0;
	private float velocidadeNeutra = 5;
	private float tempoDeAnimaGolpe = 3;
	private Transform adversario;
	private Animator animatorEnemy;
	private CharacterController controle;
	private umCriature umCdele;
	private Vector3 forwardInicial;
	private Vector3 rightInicial;



	// Use this for initialization
	void Start () {
		if(quem=="CriatureAtivo")
		{
			GameObject G = GameObject.Find("inimigo");
			if(G)
				adversario = G.transform;
		}else if(quem == "inimigo")
		{
			GameObject G = GameObject.Find("CriatureAtivo");
			if(G)
				adversario = G.transform;
		}

		if(adversario){
			forwardInicial = adversario.forward;
			rightInicial = adversario.right;
			animatorEnemy = adversario.GetComponent<Animator>();
			if(final==1){
				controle = adversario.GetComponent<CharacterController>();
				umCdele = adversario.GetComponent<umCriature>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		contadorDeTempo+=Time.deltaTime;
		transform.localScale = Vector3.Lerp(transform.localScale,new Vector3(1,1,1),Time.deltaTime);
		if(contadorDeTempo<tempoDeAnimaGolpe)
		{

			if(adversario)
			{
				transform.position = 
					(tempoDeAnimaGolpe - contadorDeTempo)/tempoDeAnimaGolpe*pos
						+contadorDeTempo/tempoDeAnimaGolpe*adversario.position;

				if(contadorDeTempo>tempoDeAnimaGolpe/2)
				{
					cameraAoAlvo();
					
				}
			}else
			{
				transform.position += velocidadeNeutra*direcao*Time.deltaTime;
			}
		}else
		{
			if(adversario && final<2)
			{
				Animator animatorEnemy = adversario.GetComponent<Animator>();

				Destroy(
					Instantiate(
						elementosDoJogo.el.retorna("impactoDeEnergia"),
						transform.position,
						Quaternion.identity
					),
					1
					);
				animatorEnemy.Play("dano2");
				animatorEnemy.SetBool("dano1",true);
				animatorEnemy.Play("dano1");

				if(final==1)
				{
					transform.localScale = Vector3.zero;
					final = 2;
					Destroy(
						Instantiate(
						elementosDoJogo.el.retorna("encontro"),
						transform.position,
						Quaternion.identity
						),
						1
						);
				}else if(final ==0)
					Destroy(gameObject);
			}else if(final<2)
			{
				if(final==1)
					aG.retornaLutaParalisada();
				Destroy(gameObject);
			}else if(final == 2)
			{
				umCdele.enabled = false;
				adversario.Rotate(1000*Time.deltaTime,0,0);
				controle.Move((Vector3.up-adversario.forward)*velocidadeSubindo*Time.deltaTime);
				cameraAoAlvo();
				if(contadorDeTempo > tempoDeAnimaGolpe+tempoDeSubida)
					final = 3;
			}else if(final ==3)
			{
				aG.calculaDano(adversario);
				adversario.rotation = Quaternion.LookRotation(forwardInicial);
				animatorEnemy.Play("dano2");
				animatorEnemy.SetBool("dano1",true);
				animatorEnemy.Play("dano1");
				final = 4;
			}else if (final==4)
			{
				controle.Move(Vector3.up*velocidadeDeUltimaSubida*Time.deltaTime);
				if(contadorDeTempo > tempoDeAnimaGolpe+ tempoDeSubida + tempoDeUltimaSubida)
				{

					umCdele.enabled = true;
					final = 5;
				}
			}else if(final==5)
			{
				if(controle.isGrounded)
				{
					animatorEnemy.SetBool("dano1",false);
					if(umCdele.X.cAtributos[0].Corrente>0)
						aG.retornaLutaParalisada();
					else
					{
						GameObject.Find(quem).GetComponent<Animator>().SetBool("atacando",false);
						animatorEnemy.SetBool("cair",true);
					}
					Destroy(gameObject);
				}
			}
		}
	}

	private void cameraAoAlvo()
	{
		Transform daCamera = Camera.main.transform;
		//Transform T = transform.Find(C.osso);
		Vector3 posAlvoCam = adversario.position+5*forwardInicial+Vector3.up*3-rightInicial*2;
		
		daCamera.position = Vector3.Lerp(daCamera.position,posAlvoCam,Time.deltaTime*3);
		daCamera.rotation = Quaternion.Lerp(
			daCamera.rotation,
			Quaternion.LookRotation(adversario.position-daCamera.position),
			3*Time.deltaTime
			);
	}
}
