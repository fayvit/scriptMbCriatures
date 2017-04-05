using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraBasica{

    [SerializeField]private Transform alvo;
    [SerializeField]private float altura = 20;
    [SerializeField]private float distanciaHorizontal=20;
    [SerializeField]private float velocidadeDeCamera = 10;
    [SerializeField]private float distanciaAFrenteParaFoco = 2;

    private Transform transform;
    private Vector3 dirAlvo;
    private float velDeLerp = 1;
    

	// Use this for initialization
	public void Start (Transform T) {
        transform = T;
        if (!alvo)
        {
            GameObject doAlvo = GameObject.FindGameObjectWithTag("Player");
            if (doAlvo)
                alvo = doAlvo.transform;
        }

        dirAlvo = alvo.position-distanciaHorizontal*Vector3.forward+altura*Vector3.up;
        transform.position = dirAlvo;
            transform.LookAt(alvo.position+distanciaAFrenteParaFoco*Vector3.forward);
	}
	
	// Update is called once per frame
	public void Update () {
        dirAlvo = alvo.position-distanciaHorizontal*Vector3.forward+altura*Vector3.up;

        velDeLerp = velocidadeDeCamera*Mathf.Max(1,
            Vector3.Distance(dirAlvo,transform.position)/Mathf.Sqrt(Mathf.Pow(altura,2) + Mathf.Pow(distanciaHorizontal,2)
            ));

        transform.position = Vector3.Lerp(transform.position,
            dirAlvo
            , velDeLerp * Time.deltaTime);
        
	}

    public void MudarParaCameraDeLuta()
    {

    }

    public void NovoFoco(Transform alvo,float altura,float distancia)
    {
        this.altura = altura;
        this.distanciaHorizontal = distancia;
        this.alvo = alvo;

        transform.rotation = Quaternion.LookRotation(this.alvo.position + distanciaAFrenteParaFoco * Vector3.forward-
            (alvo.position - distanciaHorizontal * Vector3.forward + altura * Vector3.up));
    }
}
