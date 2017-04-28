using UnityEngine;
using System.Collections;

public class AtivadorDeBotao : MonoBehaviour
{

   [SerializeField]private GameObject btn;
    private bool estaNoTrigger = false;

    protected float DISTANCIA_PARA_ACIONAR = 4.6f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        if (GameController.g)
            if (GameController.g.Manager)
                if (Vector3.Distance(GameController.g.Manager.transform.position, transform.position) < DISTANCIA_PARA_ACIONAR
                    &&
                    estaNoTrigger
                    &&
                    GameController.g.Manager.Estado == EstadoDePersonagem.aPasseio
                    )
                {
                    btn.SetActive(true);
                }
                else
                {
                    btn.SetActive(false);
                }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            estaNoTrigger = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            estaNoTrigger = false;
        }
    }
}
