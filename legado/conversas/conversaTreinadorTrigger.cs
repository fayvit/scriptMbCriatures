using UnityEngine;
using System.Collections;

public class conversaTreinadorTrigger : conversaComAramis {

	public mudancasDeTitulos[] mudaTitulos;
	public bool autoKey = false;

	[System.Serializable]
	public struct mudancasDeTitulos
	{
		public int indiceDaMudanca;
		public string aMudanca;
		public int quantosTabs;
	}

	protected override void Start()
	{
		if(autoKey)
			variaveisChave.vericaAutoKey(variavelChave);

		trocaTitulo.Clear();
		string sDoTitulo;
		for(int i=0;i<mudaTitulos.Length;i++)
		{
			sDoTitulo = string.Empty;
			for(int j=0;j<mudaTitulos[i].quantosTabs;j++)
			{
				sDoTitulo+="\t";
			}
			trocaTitulo.Add(mudaTitulos[i].indiceDaMudanca,sDoTitulo+mudaTitulos[i].aMudanca);
		}

		base.Start();
	}
	
	protected override void iniciaLutaComTreinador()
	{
		tConversador.GetComponent<conversaTreinadorFora>().iniciaLutaContraTreinador();
	}
}
