using UnityEngine;
using System.Collections;

public class AplicadorDeCamera : MonoBehaviour
{
    public static AplicadorDeCamera cam;

    [SerializeField]private CameraBasica basica;
    [SerializeField]private CameraDeLuta cDeLuta;
    [SerializeField]private CameraExibicionista cExibe;

    private EstiloDeCamera estilo = EstiloDeCamera.passeio;
    private enum EstiloDeCamera
    {
        passeio,
        luta,
        mostrandoUmCriature,
        focandoPonto
    }

    public CameraBasica Basica
    {
        get { return basica; }
    }
    // Use this for initialization
    void Start()
    {
        cam = this;
        basica.Start(transform);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (estilo)
        {
            case EstiloDeCamera.passeio:
                basica.Update();
            break;
            case EstiloDeCamera.luta:
                cDeLuta.Update();
            break;
            case EstiloDeCamera.mostrandoUmCriature:
                cExibe.MostrandoUmCriature();
            break;
        }
    }

    public void FocarBasica(Transform T,float altura,float distancia)
    {
        basica.NovoFoco(T,altura,distancia);
        estilo = EstiloDeCamera.passeio;
    }

    public void InicializaCameraExibicionista(Transform focoComCharacterController)
    {
        InicializaCameraExibicionista(focoComCharacterController, 
            focoComCharacterController.GetComponent<CharacterController>().height);
    }

    public void InicializaCameraExibicionista(Transform doFoco, float altura, bool contraParedes = false)
    {
        if (cExibe != null)
            cExibe.OnDestroy();
        cExibe = new CameraExibicionista(transform, doFoco, altura,contraParedes);
        estilo = EstiloDeCamera.mostrandoUmCriature;
    }    

    public void InicializaCameraDeLuta(CreatureManager alvo,Transform inimigo)
    {
        cDeLuta.Start(transform,alvo.transform,alvo.MeuCriatureBase.alturaCameraLuta,alvo.MeuCriatureBase.distanciaCameraLuta);
        cDeLuta.T_Inimigo = inimigo;
        estilo = EstiloDeCamera.luta;
    }

    public bool FocarPonto(float velocidadeDeFoco,float distancia = 6)
    {
        estilo = EstiloDeCamera.focandoPonto;
        return cExibe.MostrarFixa(velocidadeDeFoco,distancia);
    }
}
