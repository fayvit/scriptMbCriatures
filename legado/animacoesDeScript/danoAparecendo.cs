using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class danoAparecendo : MonoBehaviour {

	public int dano = 0;

	//private Text oTexto;
	private Vector3 posInicial;
	private bool aumenta = true;
	private Transform cam;
	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.zero;
		posInicial = transform.position;
		cam = GameObject.Find("Main Camera").transform;
		GetComponentInChildren<Text>().text = dano.ToString();
	}
	
	// Update is called once per frame
	void Update () {
//		print(cam.position);
		transform.LookAt(cam);

		if(aumenta){
		transform.localScale =  
			Vector3.Lerp(transform.localScale,new Vector3(0.005f,0.005f,0.005f),2*Time.deltaTime);


		transform.position = 
			Vector3.Lerp(transform.position,posInicial+2*Vector3.up,2*Time.deltaTime);

			if((transform.localScale-new Vector3(0.005f,0.005f,0.005f)).magnitude<0.001f)
				aumenta = false;
		}
		else
		{
			transform.localScale =  
				Vector3.Lerp(transform.localScale,Vector3.zero,4*Time.deltaTime);

			transform.position = 
				Vector3.Lerp(transform.position,posInicial+2*Vector3.up,2*Time.deltaTime);

			if(transform.localScale.magnitude<0.0001f)
				Destroy(gameObject);
		}

	}
}
