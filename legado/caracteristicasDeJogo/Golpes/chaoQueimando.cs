using UnityEngine;
using System.Collections;

public class chaoQueimando : MonoBehaviour {
	private float tempoQueimando	;

	public float tempoMin = 5;
	public float tempoMax = 10;

	public nomeTipos tipoImune = nomeTipos.Fogo;
	public string noImpacto = "impactoDeFogo";

	void Start()
	{
		tempoQueimando = Random.Range(5,10);

		Destroy(gameObject,tempoQueimando);
	}

	void OnTriggerEnter(Collider emQ)
	{
		if(emQ.tag=="Criature" || emQ.tag == "Player")
		{
			bool dano = true;
			bool deFogo = false;
			if(emQ.tag=="Criature")
			{
				string[] Tipos =  emQ.transform.GetComponent<umCriature>().criature().meusTipos;
				for(int i=0;i<Tipos.Length;i++)
				{
					if(Tipos[i]==tipoImune.ToString())
					{
						dano = false;
						deFogo = true;
					}
				}
			}else
				dano = false;

			if(!deFogo){
				GameObject G = elementosDoJogo.el.retorna(noImpacto);
				G = (GameObject)Instantiate(G,emQ.transform.position,Quaternion.identity );

				Destroy(G,0.75f);
			}

			if(dano){
				acaoDeGolpe aG = gameObject.AddComponent<acaoDeGolpe>();
				aG.ativa = new golpe();
				aG.tomaDanoUm(emQ.transform);
			}

			if(!deFogo)
				Destroy(gameObject);
		}
	}
}