using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraExibicionista
{
    [SerializeField]private Transform transform;
    [SerializeField]private Transform foco;
    [SerializeField]private float alturaDoPersonagem;

    private Transform baseDeMovimento;
    private bool contraParedes = false;

    public void OnDestroy()
    {
        if(baseDeMovimento!=null)
            MonoBehaviour.Destroy(baseDeMovimento.gameObject);
    }

    public CameraExibicionista(Transform daCamera,Transform doFoco,float altura,bool contraParedes = false)
    {
        this.contraParedes = contraParedes;
        transform = daCamera;
        foco = doFoco;
        alturaDoPersonagem = altura;
        baseDeMovimento = (new GameObject()).transform;
        baseDeMovimento.position = daCamera.position;
        baseDeMovimento.name = "baseDeMovimentoExibicionista";
    }
    public void MostrandoUmCriature()
    {
        baseDeMovimento.RotateAround(foco.position, Vector3.up, 15 * Time.deltaTime);
        transform.RotateAround(foco.position, Vector3.up, 15 * Time.deltaTime);
        baseDeMovimento.position = Vector3.Lerp(baseDeMovimento.position, foco.position
            + 8 * (Vector3.ProjectOnPlane(baseDeMovimento.position-foco.position,Vector3.up).normalized)
            + (5 + alturaDoPersonagem) * Vector3.up,2*Time.deltaTime);

        baseDeMovimento.LookAt(foco);

        if (cameraPrincipal.contraParedes(baseDeMovimento, foco, alturaDoPersonagem, true))
        {
            cameraPrincipal.contraParedes(transform, foco, alturaDoPersonagem, true);
        } else
        {
            transform.position = baseDeMovimento.position;
            transform.rotation = baseDeMovimento.rotation;
        }
    }

    public bool MostrarFixa(float velocidadeDeFoco,float distancia = 6)
    {
        //Debug.Log(foco);
        Vector3 posAlvo = foco.position + foco.forward * distancia + Vector3.up * alturaDoPersonagem;
        Vector3 dirAlvo = foco.position - transform.position;
        if (transform)
        {
            transform.position = Vector3.Lerp(transform.position, posAlvo, velocidadeDeFoco * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(
                Vector3.Lerp(transform.forward, dirAlvo, velocidadeDeFoco * Time.deltaTime)
                );

            if(contraParedes)
                cameraPrincipal.contraParedes(transform, foco, alturaDoPersonagem, true);

            if (Vector3.Distance(transform.position, posAlvo) < 0.5f && Vector3.Distance(transform.forward, dirAlvo) < 7.5f)
                return  true;
        }
        else
            Debug.LogError("A camera não foi setada corretamente");

        return false;
    }
}