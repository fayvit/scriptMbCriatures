using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class linguagem : MonoBehaviour {

	private Transform[] img;
	private Vector3 scalaGrande;
	private menuCarrega mC;
	private Text Tx;
	// Use this for initialization
	void Start () {

		img = new Transform[transform.childCount];
		for(int i=0;i<transform.childCount;i++)
		{
			img[i] = transform.GetChild(i);
		}

		scalaGrande = img[0].localScale;

		mC = GameObject.Find("Main Camera").GetComponent<menuCarrega>();
		Tx = GameObject.Find("Canvas2/Panel/Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		float alt2 = movimentoBasico.alternador2();
		
		if( alt2==0 )
		{
			alt2 = movimentoBasico.alternador3();
		}
		
		if(alt2!=0)
		{
			trocaLinguaB();
		}

		if(heroi.lingua=="pt-br")
		{
			img[0].localScale = scalaGrande;
			img[1].localScale = 0.9f*scalaGrande;
			Tx.text = "Idioma";
		}else 
		if(heroi.lingua=="en-google")
		{
			img[1].localScale = scalaGrande;
			img[0].localScale = 0.9f*scalaGrande;
			Tx.text = "Language";
		}
	
	}

	void trocaLinguaB()
	{
		if(heroi.lingua=="pt-br")
			heroi.lingua = "en-google";
		else 
			heroi.lingua = "pt-br";

		mC.atualizaTextos();
	}

	public void trocaLingua(Transform target)
	{
		if(target==img[0]){
			heroi.lingua = "pt-br";

		}
		if(target==img[1]){
			heroi.lingua  = "en-google";

		}

		mC.atualizaTextos();
	}
}
