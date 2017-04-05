using UnityEngine;
using System.Collections;

public class gambiarraBugDoChao : MonoBehaviour {
	/*
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		print("um");
		RaycastHit ray = new RaycastHit();
		if(Physics.Raycast(hit.point,Vector3.up,out ray))
		{
			print(ray.transform.name);
			if(ray.transform.name=="Terrain")
			{
				hit.transform.position = ray.point+2*Vector3.up;
			}
		}
	}
	*/

	void OnTriggerEnter(Collider hit)
	{
//		print(hit.transform.name);
		if(hit.transform.name!="Cilindro"
		   &&
		   hit.transform.name!="Cilindro_001"
		   &&
		   hit.transform.name!="Terrain"
		   &&
		   hit.tag!="souUmaGambiarra"
		   ){
		RaycastHit ray = new RaycastHit();
		if(Physics.Raycast(hit.transform.position+5*Vector3.up,10*Vector3.up,out ray))
		{
//		print(ray.transform.name);

				hit.gameObject.transform.position = new melhoraPos().novaPos( ray.point+5*Vector3.up);
		}
	}
	}
}
