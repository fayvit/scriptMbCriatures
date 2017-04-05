using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraExibicionista
{
    [SerializeField]private Transform transform;
    [SerializeField]private Transform foco;
    [SerializeField]private float alturaDoPersonagem;

    private Transform baseDeMovimento;

    public CameraExibicionista(Transform daCamera,Transform doFoco,float altura)
    {
        transform = daCamera;
        foco = doFoco;
        alturaDoPersonagem = altura;
        baseDeMovimento = (new GameObject()).transform;
        baseDeMovimento.position = daCamera.position;
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
}