using UnityEngine;
using System.Collections;

public class iniciaCenaFinal : MonoBehaviour {
	

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag=="Criature")
		{
			col.GetComponent<alternancia>().retornaAoHeroi();
			Camera.main.GetComponent<entradinhaDoJogoPlus>().faseAteCenaFinal();
		}

		if(col.gameObject.tag=="Player")
		{
			Camera.main.transform.GetComponent<entradinhaDoJogoPlus>().encontroComGlark();
			gameObject.SetActive(false);
		}
	}
}
