using UnityEngine;
using System.Collections;

public class umCriature : MonoBehaviour {

	public Criature X;
	public nomesCriatures nomeCriature;
	public uint nivelCriature = 1;
	[HideInInspector]
	public bool ataqueComPulo = false;


	private Vector3 movimentoVertical = Vector3.zero;
	private movimentoBasico mB;
	private CharacterController controle;
	private UnityEngine.AI.NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		controle = GetComponent<CharacterController>();
		heroi H = GameObject.FindGameObjectWithTag ("Player").GetComponent<heroi> ();

		if(GetComponent<sigaOLider>()){
			X = H.criaturesAtivos [0]; 
			nomeCriature = X.nomeID;
			statusTemporarioBase.colocaStatus(gameObject,X.statusTemporarios);
			statusTemporarioBase.retiraStatusDoGerente(X);
		}
		else
			X = new cCriature (nomeCriature,nivelCriature).criature();


	}

	public Criature criature()
	{
		return X;
	}

	// Update is called once per frame
	void Update () {
		/*
		bool movimentando = false;
		
		if(name=="CriatureAtivo")
			if(nav == null)
			{
				nav = GetComponent<NavMeshAgent>();
			}else
			{
				movimentando = !nav.enabled;
			}
*/
		if(!GetComponent<movimentoBasico>()
		   &&
		   !ataqueComPulo
		   &&
		   (! Physics.Raycast (transform.position, Vector3.down, 0.01f/*X.distanciaFundamentadora*/)||name =="inimigo")
		   )
		{

			movimentoVertical = X.apliqueGravidade(movimentoVertical,Vector3.down);
			if(controle.enabled)
				controle.Move(movimentoVertical);
		}




		/*
	
		if(nav == null)
		{
			nav = GetComponent<NavMeshAgent>();
		}else
		{
			if(nav.enabled==true && !ataqueComPulo)
			{
				//movimentoVertical = X.apliqueGravidade(movimentoVertical,Vector3.down);
				//controle.Move(movimentoVertical);
			}
		}*/

	}

}
