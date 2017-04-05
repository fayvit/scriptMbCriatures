using UnityEngine;
using System.Collections;

public class desincronizandoVendedores : MonoBehaviour {

	public float tempoDeReinicio;
	private Animator animator;
	// Use this for initialization
	void Start () {
		Invoke("reinicio",tempoDeReinicio);
		animator = GetComponent<Animator>();
	}

	void reinicio()
	{
		animator.Play("chamaCriature");
		animator.Play("padrao");
		Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
