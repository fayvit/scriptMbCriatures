using UnityEngine;
using System.Collections;

public class iniciaConversa2 : MonoBehaviour {

	[SerializeField]
	private entradinhaDoJogoPlus ePlus;
	private bool jaIniciou = false;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player" &&!jaIniciou)
		{
			ePlus.IniciaConversa2();
			jaIniciou = true;
		}
	}
}
