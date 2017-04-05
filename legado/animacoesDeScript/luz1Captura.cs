using UnityEngine;
using System.Collections;

public class luz1Captura : MonoBehaviour {
	Light L;
	ParticleSystem P;
	// Use this for initialization
	void Start () {
		L = GetComponentInChildren<Light>();
		P = GetComponent<ParticleSystem>();
		Destroy(gameObject,1);
	}
	
	// Update is called once per frame
	void Update () {
		L.intensity = P.time*7;

	}
}
