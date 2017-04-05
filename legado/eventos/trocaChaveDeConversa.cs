using UnityEngine;
using System.Collections;

public class trocaChaveDeConversa : MonoBehaviour {

	private conversaEmJogo cJ;

	public string chaveDeMudanca;
	public string chaveDaNovaConversa;

	// Use this for initialization
	void Start () {
		cJ = GetComponent<conversaEmJogo>();
	}
	
	// Update is called once per frame
	void Update () {
		if(variaveisChave.shift.ContainsKey(chaveDeMudanca))
			if(variaveisChave.shift[chaveDeMudanca] && cJ.indiceDaConversa!=chaveDaNovaConversa)
				cJ.atualizaIndiceDeConversa(chaveDaNovaConversa);

	}
}
