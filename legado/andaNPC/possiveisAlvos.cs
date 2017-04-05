using UnityEngine;
using System.Collections;

public class possiveisAlvos: MonoBehaviour {
	public Transform[] alvos;

	public Transform sorteiaAlvo()
	{
		int sorteado = Mathf.RoundToInt(Random.Range(0,alvos.Length));
		return alvos[sorteado];
	}
}