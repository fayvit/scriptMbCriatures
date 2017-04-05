using UnityEngine;
using System.Collections;

public class impedeCriatureDePassar : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag=="Criature")
		{
			col.GetComponent<alternancia>().retornaAoHeroi();
			Camera.main.GetComponent<entradinhaDoJogoPlus>().faseAteOEncontro();
		}
	}
}
