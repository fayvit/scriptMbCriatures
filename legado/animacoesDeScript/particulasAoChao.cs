using UnityEngine;
using System.Collections;

public class particulasAoChao : MonoBehaviour {

	public string aoChao = "impactoAoChao";
	public bool destruir = true;
	public float repetir = 0.25f;
	private elementosDoJogo elementos;
	// Use this for initialization
	void Start () {
		elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		Invoke("impactoAoChao",0.15f);
	}

	void impactoAoChao()
	{
		GameObject G = elementos.retorna(aoChao);
		Vector3 pos = Vector3.zero;
		RaycastHit ray = new RaycastHit();
		if(Physics.Raycast(transform.position,Vector3.down,out ray))
		{
			pos = ray.point;
		}else if(Physics.Raycast(transform.position,Vector3.up,out ray))
		{
			pos = ray.point;
		}
		G = Instantiate(G,pos,Quaternion.identity) as GameObject;
		if(destruir)
			Destroy(G,1.75f);
		Invoke("impactoAoChao",repetir);
	}

	void OnCollisionEnter(Collision emQ)
	{
		foreach(ContactPoint P in emQ.contacts)
		{
		
			if(Vector3.Angle(P.normal,Vector3.up)<15 && emQ.gameObject.tag!="Criature")
			{

				GameObject G = (GameObject)Instantiate(
					elementos.retorna(aoChao),
					P.point,
					Quaternion.identity
					);

				Destroy(G,0.5f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
