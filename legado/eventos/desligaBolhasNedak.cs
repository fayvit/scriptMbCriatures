using UnityEngine;
using System.Collections;

public class desligaBolhasNedak : MonoBehaviour {

	public GameObject[] Bolhas;

	private umCriature umC;

	// Use this for initialization
	void Start () {
		umC = GetComponent<umCriature>();
	}
	
	// Update is called once per frame
	void Update () {
		if(umC.X.cAtributos[0].Corrente<=0)
		{
			foreach(GameObject G in Bolhas)
				G.SetActive(false);
		}else if(!Bolhas[0].activeSelf && umC.X.cAtributos[0].Corrente>0)
			foreach(GameObject G in Bolhas)
				G.SetActive(true);
	
	}
}
