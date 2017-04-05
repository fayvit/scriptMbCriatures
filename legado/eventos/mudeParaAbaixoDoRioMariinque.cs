using UnityEngine;
using System.Collections;

public class mudeParaAbaixoDoRioMariinque : MonoBehaviour {

	public Material materialAbaixoDoRio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Application.loadedLevelName=="rioMariinque")
		{
			GameObject.Find("CilindroDasTubulacoes").GetComponent<MeshRenderer>().material = materialAbaixoDoRio;
			GameObject.Find("caminhoEstadio").GetComponent<MeshRenderer>().material = materialAbaixoDoRio;
			RenderSettings.fog = true;
			Destroy(gameObject);
		}else if(Application.loadedLevelName!="esgoto")
		{
			Destroy(gameObject);
		}
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag=="Player"&&Application.loadedLevelName=="esgoto" && !heroi.emLuta)
		{
			DontDestroyOnLoad(gameObject);

			GameObject G = new GameObject();
			
			mudeCena mudador = G.AddComponent<mudeCena>();
			DontDestroyOnLoad(G);
			mudador.nomeCena = "rioMariinque";
			mudador.posicao = new Vector3(1644.8f,0.35f,1300);
			mudador.olhePraLa = 180;
			mudador.guardeValoresEMudeDeCena();

		}else if(col.tag=="Criature" && !heroi.emLuta)
		{
			mudeCena.evitaCriatureAvancarNoTrigger(col);
		}
	}
}
