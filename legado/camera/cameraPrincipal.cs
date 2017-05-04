using UnityEngine;
using System.Collections;

public class cameraPrincipal : MonoBehaviour {

	public Transform cameraP;

	public bool luta = false;
	public bool iniciou = true;
	public float velocidadeMaxFoco = 10f;
	public float distancia  = 7.0f;
	public float altura = 3.0f;
	public float velCamLuta  = 2;

	private Transform alvo;
	private Transform Inimigo;

	private bool focar = false;
//	private bool doMovimento = false;

	private float x = 0.0f;
	private float y = 0.0f;
	private float xSpeed = 250.0f;
	private float ySpeed = 120.0f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	private float escalA;




	void Start()
	{
		if(!cameraP && Camera.main)
		{
			cameraP = Camera.main.transform;
		}
		
		//if(!luta){
			alvo = transform;
			focar = true;
			if(!cameraP) {
				enabled = false;	
			}


			
			Vector3 angles = transform.eulerAngles;
			x = angles.y;
			y = angles.x;
			
			escalA = GetComponent<CharacterController>().height;
			

		//}else
		//{
		//	cameraP.position = transform.position-3*transform.forward+5*Vector3.up;
		//}
	}

	void LateUpdate () { 
		if(!pausaJogo.pause){
			//if(luta)
			//{
			//	apliqueCameraDeLuta();
			//}else
			//{			
			//	adaptadaDoQueVemNoUnity();
			//}

			if(luta && Input.GetButton("menu e auxiliar"))
			{
				focoDeLuta();
			}else
				adaptadaDoQueVemNoUnity();
		}
	}

	void focoDeLuta()
	{
		if(Inimigo == null)
			Inimigo = GameObject.Find("inimigo").transform;

		Vector3 direcaoDaVisao 
			= Vector3.ProjectOnPlane(Inimigo.position-transform.position,Vector3.up);

		Quaternion alvoQ = Quaternion.LookRotation(direcaoDaVisao+
		                                           altura/10*Vector3.down);
		
		x = Mathf.LerpAngle(x,alvoQ.eulerAngles.y,velocidadeMaxFoco*  Time.deltaTime);
		y = Mathf.LerpAngle(y,alvoQ.eulerAngles.x,velocidadeMaxFoco*Time.deltaTime);
		
		
		
		if(Mathf.Abs(x-alvoQ.eulerAngles.y)%360<5&&Mathf.Abs(y-alvoQ.eulerAngles.x)%360<15f)
			focar = false;

		Quaternion rotation = Quaternion.Euler(y, x, 0);
		
		Vector3 position = rotation * (new Vector3(0.0f, 0.0f, -distancia)) + alvo.position
			+(escalA+altura/8)*Vector3.up;
		
		cameraP.rotation = Quaternion.Lerp(cameraP.rotation,
							rotation,
		                                   50*Time.deltaTime);
		
		cameraP.position = Vector3.Lerp(cameraP.position,
		                                position,
		                                50*Time.deltaTime);

		contraParedes(cameraP,alvo,escalA);

	}





	void adaptadaDoQueVemNoUnity()
	{
		
		if (alvo) {
			
			if (Input.GetButton ("centraCamera")) {
				focar = true;
			}


			
			/*
			if(tag=="Criature")
			{
				if(Input.GetAxis("Horizontal")!=0
				   ||
				   Input.GetAxis("Vertical")<0)
					focar = false;
			}*/
			
			
			
			if(focar)
			{
				Quaternion alvoQ = Quaternion.LookRotation(transform.forward+
				                                          altura/10*Vector3.down);

				x = Mathf.LerpAngle(x,alvoQ.eulerAngles.y,velocidadeMaxFoco*  Time.deltaTime);
				y = Mathf.LerpAngle(y,alvoQ.eulerAngles.x,velocidadeMaxFoco*Time.deltaTime);
				
				
				float paraContinha = Mathf.Min(Mathf.Abs(x-alvoQ.eulerAngles.y),Mathf.Abs(360-Mathf.Abs(x-alvoQ.eulerAngles.y)));
				/*
				print("eulerangle Y "+alvoQ.eulerAngles.y);
				print("valor de X "+x);
				print("diferença entre X e QY "+(x-alvoQ.eulerAngles.y));
				print("valor Absoluto da Diferença "+Mathf.Abs((x-alvoQ.eulerAngles.y)));
				print("diferença modulo 360 "+((x-alvoQ.eulerAngles.y)%360));*/

				if(/*Mathf.Abs(x-alvoQ.eulerAngles.y)*/paraContinha%360<5&&Mathf.Abs(y-alvoQ.eulerAngles.x)%360<15)
					focar = false;
				
				//print("anguloX "+paraContinha%360+" : y "+Mathf.Abs(y-alvoQ.eulerAngles.x)%360);
				
			}
			
			
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			
			Vector3 position = rotation * (new Vector3(0.0f, 0.0f, -distancia)) + alvo.position;

		//	if(iniciou)
		//	{
		//		iniciou = false;
				cameraP.rotation = rotation;
				
				cameraP.position = position+escalA*Vector3.up;
		/*	}else
			{
				cameraP.rotation = Quaternion.Lerp(cameraP.rotation,
				                                   rotation,
				                                   25*Time.deltaTime);
				
				cameraP.position = Vector3.Lerp(cameraP.position,
				                                position+escalA*Vector3.up,
				                                25*Time.deltaTime);
			}*/
			
			contraParedes(cameraP,alvo,escalA);
		}
	}

    public static bool contraParedes(Transform cameraP, Vector3 alvo, float escalA, bool suave = false)
    {
        RaycastHit raioColisor;

        Debug.DrawLine(cameraP.position, alvo + escalA * Vector3.up, Color.blue);


        

        if (Physics.Linecast(alvo + escalA * Vector3.up, cameraP.position, out raioColisor, 9))
        {
            Debug.DrawLine(cameraP.position, raioColisor.point, Color.red);

            if (raioColisor.transform.tag != "Player"
               &&
               raioColisor.transform.tag != "Criature"
               &&
               raioColisor.transform.tag != "desvieCamera"
               )
            {
                if (suave)
                {
                    cameraP.position = Vector3.Lerp(cameraP.position,
                        raioColisor.point + cameraP.forward * 0.2f, 12 * Time.deltaTime);
                }
                else
                    cameraP.position = //Vector3.Lerp(cameraP.position,
                        raioColisor.point + cameraP.forward * 0.2f;
                //           50*Time.deltaTime);
                //					doMovimento = true;

                return true;
            }

        }
        return false;
    }

    public static bool contraParedes(Transform cameraP,Transform alvo,float escalA, bool suave = false)
	{
        Debug.DrawLine(alvo.position + 2 * Vector3.up, alvo.position -
                       Vector3.Project(alvo.position - cameraP.position, alvo.forward) + 2 * Vector3.up,
                       Color.green);
        return contraParedes(cameraP,alvo.position,escalA,suave);
	}
	

	static float ClampAngle (float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}

	void apliqueCameraDeLuta()
	{
		if(Inimigo == null)
			Inimigo = GameObject.Find("inimigo").transform;
		
		Vector3 direcaoDaVisao = Inimigo.position-transform.position;
		
		if(Vector3.Distance(transform.position,Inimigo.position)>3)
		{
			direcaoDaVisao = new Vector3(direcaoDaVisao.x,0,direcaoDaVisao.z);
			direcaoDaVisao = direcaoDaVisao.normalized;
		}else
		{
			direcaoDaVisao = cameraP.forward;
		}
		
		if (Input.GetButton ("centraCamera")) {
			focar = true;
			velCamLuta = 5;
		}
		
		
		
		if(!focar){
			if(Vector3.Angle(direcaoDaVisao,cameraP.forward)>90)
				direcaoDaVisao = -direcaoDaVisao;
		}
		Vector3 posAlvo = transform.position-direcaoDaVisao*10+Vector3.up*3;

		
		if(Vector3.Distance(posAlvo,cameraP.position)<0.5f){
			focar = false;
			velCamLuta = 2;
		}
		
		float escala = GetComponent<CharacterController>().height;
		
		
		Vector3 X = new Vector3 (transform.position.x, transform.position.y + escala, transform.position.z);
		
		
		cameraP.rotation = Quaternion.Lerp(cameraP.rotation,Quaternion.LookRotation(direcaoDaVisao),velCamLuta*Time.deltaTime);
		
		RaycastHit raioColisor = new RaycastHit();
		if (Physics.Linecast (X, posAlvo ,out raioColisor,9)) {
			Debug.DrawLine(posAlvo,raioColisor.point,Color.red );
			
			if(raioColisor.transform.tag != "Player" 
			   && 
			   raioColisor.transform.tag != "Criature" 
			   &&
			   raioColisor.transform.tag != "desvieCamera"
			   )
			{
				cameraP.position = raioColisor.point+cameraP.forward*0.2f;
				//doMovimento = true;
			}
			
		}else
			cameraP.position = Vector3.Lerp(cameraP.position,posAlvo,velCamLuta *Time.deltaTime);
		
	}

	public bool Focar
	{
		get{return focar;}
		private set{}
	}
}