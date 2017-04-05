using UnityEngine;
using System.Collections;

public class centralizaEGiraCamera : MonoBehaviour {

	public Transform T;
	public float velocidadeDeCamera = 0.5f;

	// Use this for initialization
	void Start () {
		Camera.main.transform.position = T.position + 5*T.forward+3*Vector3.up;
		Camera.main.transform.LookAt(T);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(T)
			Camera.main.transform.RotateAround (T.position,Vector3.up,velocidadeDeCamera);
	}
}
