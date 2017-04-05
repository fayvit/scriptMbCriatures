using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraDeLuta
{
    [SerializeField]private Transform tInimigo;
    [SerializeField]private Transform alvo;
    [SerializeField]private float altura = 3;
    [SerializeField]private float velocidadeMaxFoco = 10f;
    [SerializeField]private float distancia = 7.0f;
    [SerializeField]private float escalA = 1;

    private float x = 0;
    private float y = 0;

    private Transform transform;

    public Transform T_Inimigo
    {
        get { return tInimigo; }
        set { tInimigo = value; }
    }
    // Use this for initialization
    public void Start(Transform aCamera,Transform alvo,float altura, float distancia)
    {
        transform = aCamera;
        this.alvo = alvo;

        this.altura = altura;
        this.distancia = distancia;
        /*
        Vector3 angles = alvo.eulerAngles;
        x = angles.y;
        y = angles.x;
        */

        escalA = alvo.GetComponent<CharacterController>().height;
    }

    // Update is called once per frame
    public void Update()
    {
        if (tInimigo && alvo && transform)
            focoDeLuta();
        else
            Debug.LogAssertion("transforms não setados corretamente, inimigo = " + tInimigo + ", alvo= " + alvo + ", camera = " + transform);
    }

    void focoDeLuta()
    {
        //if (tInimigo == null)
          //  tInimigo = GameObject.Find("inimigo").transform;

        Vector3 direcaoDaVisao
            = Vector3.ProjectOnPlane(tInimigo.position - transform.position, Vector3.up);

        Quaternion alvoQ = Quaternion.LookRotation(direcaoDaVisao +
                                                   altura / 10 * Vector3.down);

        x = Mathf.LerpAngle(x, alvoQ.eulerAngles.y, velocidadeMaxFoco * Time.deltaTime);
        y = Mathf.LerpAngle(y, alvoQ.eulerAngles.x, velocidadeMaxFoco * Time.deltaTime);



       // if (Mathf.Abs(x - alvoQ.eulerAngles.y) % 360 < 5 && Mathf.Abs(y - alvoQ.eulerAngles.x) % 360 < 15f)
         //   focar = false;

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 position = rotation * (new Vector3(0.0f, 0.0f, -distancia)) + alvo.position
            + (escalA + altura / 8) * Vector3.up;

        transform.rotation = Quaternion.Lerp(transform.rotation,
                            rotation,
                                           50 * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position,
                                        position,
                                        50 * Time.deltaTime);

         contraParedes(transform, alvo, escalA);

    }

    public static void contraParedes(Transform cameraP, Transform alvo, float escalA, bool suave = false)
    {
        RaycastHit raioColisor;
        Debug.DrawLine(cameraP.position, alvo.position + escalA * Vector3.up, Color.blue);


        Debug.DrawLine(alvo.position + 2 * Vector3.up, alvo.position -
                       Vector3.Project(alvo.position - cameraP.position, alvo.forward) + 2 * Vector3.up,
                       Color.green);

        if (Physics.Linecast(alvo.position + escalA * Vector3.up, cameraP.position, out raioColisor, 9))
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
                        raioColisor.point + cameraP.forward * 0.2f, 25 * Time.deltaTime);
                }
                else
                    cameraP.position = //Vector3.Lerp(cameraP.position,
                        raioColisor.point + cameraP.forward * 0.2f;
                //           50*Time.deltaTime);
                //					doMovimento = true;
            }

        }
    }
}
