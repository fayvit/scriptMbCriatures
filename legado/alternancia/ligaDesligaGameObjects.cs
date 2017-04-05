using UnityEngine;
using System.Collections;

public class ligaDesligaGameObjects : MonoBehaviour {

	private int numChild = 0;
	private Transform[] meusFilhos;
	private Transform tHeroi;

	public float distanciaParaDesligar = 500;
	// Use this for initialization
	void Start () {
		tHeroi = GameObject.FindWithTag("Player").transform;
		numChild = transform.childCount;
		meusFilhos = new Transform[numChild];
		for(int i=0;i<numChild;i++)
		{
			meusFilhos[i] = transform.GetChild(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<numChild;i++)
		{
			if(Vector3.Distance(meusFilhos[i].position,tHeroi.position)>distanciaParaDesligar)
			{
				meusFilhos[i].gameObject.SetActive(false);
			}else
				meusFilhos[i].gameObject.SetActive(true);
		}
	}
}
