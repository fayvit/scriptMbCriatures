using UnityEngine;
using System.Collections;

public class destruaQUandoProximo : MonoBehaviour {
	public Vector3 local;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position,local)<3.5f)
			Destroy(gameObject);
	}
}
