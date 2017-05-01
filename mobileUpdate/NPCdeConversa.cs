using UnityEngine;
using System.Collections;

[System.Serializable]
public class NPCdeConversa
{
    [SerializeField]private Transform[] pontosAlvo;
    [SerializeField]private ChaveDeTextoAntiga chaveDaConversa = ChaveDeTextoAntiga.bomDia;
    [SerializeField]private Sprite fotoDoNPC;

    private Transform meuTransform;
    private Transform destrutivel;
    private SigaOLider siga;
    private EstadoDoNPC estado = EstadoDoNPC.parado;
    private Vector3 alvo = Vector3.zero;
    private string[] conversa;
    private float tempoParado = 0;
    private float contadorDeTempo = 0;

    private const float TEMPO_MAX_PARADO = 2;
    private const float TEMPO_MIN_PARADO = 1;
    private enum EstadoDoNPC
    {
        caminhando,
        parado,
        conversando
    }
    
    public void Start(Transform T)
    {
        meuTransform = T;
        conversa = bancoDeTextos.falacoes[heroi.lingua][chaveDaConversa.ToString()].ToArray();
        tempoParado = Random.Range(TEMPO_MIN_PARADO, TEMPO_MAX_PARADO);

        if (siga == null)
        {
            siga = new SigaOLider(T,0.75f,2);
        }

        if (pontosAlvo.Length == 0)
            pontosAlvo = new Transform[1] { T };
    }

    // Update is called once per frame
    public bool Update()
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
                    estado = EstadoDoNPC.parado;
                    meuTransform.rotation = Quaternion.LookRotation(-Vector3.forward);
                    MonoBehaviour.Destroy(destrutivel.gameObject);
                    GameController.g.HudM.ligarControladores();
                    AndroidController.a.LigarControlador();
                    return true;
                }
            break;
        }

        return false;
    }

    public void IniciaConversa(Transform Destrutivel)
    {
        destrutivel = Destrutivel;
        siga.PareAgora();
        GameController.g.HudM.DisparaT.IniciarDisparadorDeTextos();
        estado = EstadoDoNPC.conversando;
    }
}
