using UnityEngine;
using System.Collections;

public class ColisorDeDano : ColisorDeDanoBase
{
    void Start()
    {
        quaternionDeImpacto();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += velocidadeProjetil * transform.forward * Time.deltaTime;
    }

    void OnTriggerEnter(Collider emQ)
    {
        funcaoTrigger(emQ);
    }
}
