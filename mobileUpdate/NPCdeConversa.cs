using UnityEngine;
using System.Collections;

[System.Serializable]
public class NPCdeConversa
{
    [SerializeField]private Transform[] pontosAlvo;
    [SerializeField]private ChaveDeTexto chaveDaConversa = ChaveDeTexto.bomDia;

    [SerializeField]protected Sprite fotoDoNPC;

    protected EstadoDoNPC estado = EstadoDoNPC.parado;
    protected string[] conversa;

    private Transform meuTransform;
    private Transform destrutivel;
    private SigaOLider siga;
    
    private Vector3 alvo = Vector3.zero;
    private float tempoParado = 0.5f;
    private float contadorDeTempo = 0;

    private const float TEMPO_MAX_PARADO = 20;
    private const float TEMPO_MIN_PARADO = 8;
    protected enum EstadoDoNPC
    {
        caminhando,
        parado,
        conversando
    }
    
    public void Start(Transform T)
    {
        meuTransform = T;
        conversa = bancoDeTextos.RetornaListaDeTextoDoIdioma(chaveDaConversa).ToArray();
        //tempoParado = Random.Range(TEMPO_MIN_PARADO, TEMPO_MAX_PARADO);
 
        if (siga == null)
        {
            siga = new SigaOLider(T, 0.75f ,2);
        }

        if (pontosAlvo==null)
            pontosAlvo = new Transform[1] { T };
    }

    // Update is called once per frame
    public virtual bool Update()
    {
        switch (estado)
        {
            case EstadoDoNPC.parado:
                contadorDeTempo += Time.deltaTime;
                if (contadorDeTempo > tempoParado)
                {
                    alvo = pontosAlvo[Random.Range(0, pontosAlvo.Length)].position;
                    contadorDeTempo = 0;
                    estado = EstadoDoNPC.caminhando;
                }
            break;
            case EstadoDoNPC.caminhando:
                siga.Update(alvo);
                if (Vector3.Distance(alvo, meuTransform.position) < 2)
                {
                    siga.PareAgora();
                    estado = EstadoDoNPC.parado;
                    tempoParado = Random.Range(TEMPO_MIN_PARADO, TEMPO_MAX_PARADO);
                }
            break;
            case EstadoDoNPC.conversando:
                AplicadorDeCamera.cam.FocarPonto(5);
                if (GameController.g.HudM.DisparaT.UpdateDeTextos(conversa, fotoDoNPC))
                {
                    FinalizaConversa();
                    return true;
                }
            break;
        }

        return false;
    }

    protected void FinalizaConversa()
    {
        estado = EstadoDoNPC.parado;
        meuTransform.rotation = Quaternion.LookRotation(-Vector3.forward);
        MonoBehaviour.Destroy(destrutivel.gameObject);
        GameController.g.HudM.ligarControladores();
        AndroidController.a.LigarControlador();
    }

    public void IniciaConversa(Transform Destrutivel)
    {
        destrutivel = Destrutivel;
        siga.PareAgora();
        GameController.g.HudM.DisparaT.IniciarDisparadorDeTextos();
        estado = EstadoDoNPC.conversando;
    }
}
