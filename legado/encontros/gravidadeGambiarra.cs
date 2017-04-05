using UnityEngine;
using System.Collections;

public class gravidadeGambiarra : MonoBehaviour {

	public CharacterController controle;
	// Use this for initialization
	void Start () {
		controle = GetComponent<CharacterController>();
		Destroy(this,5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		/*
		movimentoBasico mB = GetComponent<movimentoBasico> ();
		if (!mB.noChao (5f))
						transform.position -= Vector3.up * 9.8f;
				else
						Destroy (this);
	*/

		controle.Move(Vector3.down*9.8f*Time.deltaTime);

		if(controle.isGrounded)
		{
			GetComponent<Animator>().SetBool("noChao",true);
			Destroy(this);
		}
	}
}
