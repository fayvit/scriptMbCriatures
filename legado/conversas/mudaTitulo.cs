using UnityEngine;
using System.Collections;

[RequireComponent(typeof(conversaEmJogo))]
public class mudaTitulo : MonoBehaviour {

	[System.Serializable]
	public class mudeTitulo
	{
		public string titulo;
		public int indice;
		public int espacosTab;
	}

	public mudeTitulo[] mT;

	// Use this for initialization
	private conversaEmJogo cJ;
	void Start () {
		cJ = GetComponent<conversaEmJogo>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cJ.mens!=null)
		{
			string espacos = "";
			for(int i=0;i<mT.Length;i++)
			{
				if(cJ.mensagemAtual==mT[i].indice)
				{
					for(int j=0;j<mT[i].espacosTab;j++)
						espacos+="\t ";
					cJ.mens.title = espacos+mT[i].titulo;
				}
			}

		}
	}
}
