using UnityEngine;
using System.Collections;

/// <summary>
/// Classe responsavel pela animação de uso de item e envio de criatures
/// </summary>
public class AnimaBraco
{
    private EstadoDoAnimaBraco estado = EstadoDoAnimaBraco.manipulandoCamera;
    private EstadoDoAnimaEnvia estadoEnvia = EstadoDoAnimaEnvia.iniciaAnimacao;
    private AplicadorDeCamera mCamera;
    private CharacterManager manager;
    private AnimadorHumano animador;
    private GameObject luz;
    private GameObject raio;
    private GameObject C;
    private GameObject alvo;
    private Vector3 posCriature = Vector3.zero;
    private float tempoDecorrido = 0;

    private const float VELOCIDADE_DE_MOVIMENTO_DE_CAMERA = 0.7F;
    private const float TEMPO_DA_PRIMEIRA_ANIMACAO = 1.05F;
    private const float TEMPO_PARA_INSTANCIAR_PARTICULA_CHAO = 0.5F;
    private const float TEMPO_PARA_FINALISAR_RAIO = 0.25F;
    private const float TEMPO_DE_REDUCAO_DE_ESCALA = 1f;
    private const float VELOCIDADE_MINIMA_PARA_MOVIMENTO_DE_CAMERA = 5;

    private const float TEMPO_DA_ANIMA_ENVIA = 3.75F;
    private const float TEMPO_PARA_INSTANCIAR_CRIATURE = 1F;

    public AnimaBraco(CharacterManager manager, Transform alvo)
    {
        mCamera = MonoBehaviour.FindObjectOfType<AplicadorDeCamera>();
        mCamera.InicializaCameraExibicionista(manager.transform, 2.5f);
        this.manager = manager;
        animador = manager.Mov.Animador;
        manager.transform.rotation = Quaternion.LookRotation(
            Vector3.ProjectOnPlane(alvo.position - manager.transform.position, Vector3.up)
            );
        this.alvo = alvo.gameObject;
        PosCriature = alvo.position;
    }

    private enum EstadoDoAnimaEnvia
    {
        iniciaAnimacao,
        animaEnvia,
        Instancia,
        AumentaEscala,
        finalizaEnvia
    }

    private enum EstadoDoAnimaBraco
    {
        manipulandoCamera,
        animaTroca,
        AnimandoTroca,
        InsereRaioDeLuva,
        DiminuiEscalaDoCriature,
        TerminaORaio,
        AnimaBracoFinalizado
    }

    public Vector3 PosCriature
    {
        set { posCriature = value; }
    }

    public bool AnimaEnvia(
        CriatureBase oInstanciado = null,
        string nomeDoGameObject = "")
    {
        tempoDecorrido += Time.deltaTime;
        switch (estadoEnvia)
        {
            case EstadoDoAnimaEnvia.iniciaAnimacao:
                tempoDecorrido = 0;
                animador.AnimaEnvia();
                estadoEnvia = EstadoDoAnimaEnvia.animaEnvia;
                break;
            case EstadoDoAnimaEnvia.animaEnvia:
                if (tempoDecorrido > TEMPO_DA_ANIMA_ENVIA)
                {
                    luz = ParticulasDeSubstituicao.InsereParticulaDaLuva(manager.gameObject, false);
                    raio = ParticulasDeSubstituicao.InsereParticulaDoRaio(posCriature, manager.gameObject, false);
                    estadoEnvia = EstadoDoAnimaEnvia.Instancia;
                    tempoDecorrido = 0;
                }
                break;
            case EstadoDoAnimaEnvia.Instancia:
                if (tempoDecorrido > TEMPO_PARA_INSTANCIAR_CRIATURE)
                {
                    if (oInstanciado == null && manager != null)
                        oInstanciado = manager.Dados.criaturesAtivos[0];

                    C = elementosDoJogo.el.retorna(oInstanciado.NomeID);
                    posCriature = MelhoraInstancia.ProcuraPosNoMapa(posCriature);
                    C = (GameObject)MonoBehaviour.Instantiate(C, posCriature, Quaternion.identity);

                    if (nomeDoGameObject == "" && manager != null)
                        InicializadorDoJogo.InsereCriatureEmJogo(C, manager);

                    C.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    ParticulasDeSubstituicao.ParticulaSaiDaLuva(posCriature);

                    tempoDecorrido = 0;
                    estadoEnvia = EstadoDoAnimaEnvia.AumentaEscala;
                }
                break;
            case EstadoDoAnimaEnvia.AumentaEscala:
                if (C.transform.localScale.sqrMagnitude < 2.5f)
                {
                    C.transform.localScale = Vector3.Lerp(C.transform.localScale, new Vector3(1, 1, 1), 4 * Time.deltaTime);
                    C.transform.position = posCriature;
                }
                else
                {
                    C.transform.localScale = new Vector3(1, 1, 1);
                    estadoEnvia = EstadoDoAnimaEnvia.finalizaEnvia;
                    tempoDecorrido = 0;
                }
                break;
            case EstadoDoAnimaEnvia.finalizaEnvia:

                if (tempoDecorrido < TEMPO_PARA_FINALISAR_RAIO)
                {
                    ParticulasDeSubstituicao.ReduzVelocidadeDoRaio(raio);
                }
                else
                {
                    MonoBehaviour.Destroy(raio);
                    MonoBehaviour.Destroy(luz);
                    return false;
                }
                break;
        }
        return true;
    }

    public bool AnimaTroca(
        bool eItem = false
        )
    {
        GameObject gerente = manager.gameObject;
        tempoDecorrido += Time.deltaTime;
        switch (estado)
        {
            case EstadoDoAnimaBraco.manipulandoCamera:
                if (mCamera.FocarPonto(VELOCIDADE_DE_MOVIMENTO_DE_CAMERA
                    * Mathf.Max(Vector3.Distance(gerente.transform.position, alvo.transform.position),
                    VELOCIDADE_MINIMA_PARA_MOVIMENTO_DE_CAMERA)))
                    estado = EstadoDoAnimaBraco.animaTroca;
                break;
            case EstadoDoAnimaBraco.animaTroca:
                animador.AnimaTroca();
                estado = EstadoDoAnimaBraco.AnimandoTroca;
                tempoDecorrido = 0;
                break;
            case EstadoDoAnimaBraco.AnimandoTroca:
                if (tempoDecorrido > TEMPO_DA_PRIMEIRA_ANIMACAO)
                {
                    luz = ParticulasDeSubstituicao.InsereParticulaDaLuva(gerente, true);
                    raio = ParticulasDeSubstituicao.InsereParticulaDoRaio(posCriature, gerente);
                    estado = EstadoDoAnimaBraco.InsereRaioDeLuva;
                    tempoDecorrido = 0;
                }
                break;
            case EstadoDoAnimaBraco.InsereRaioDeLuva:
                if (tempoDecorrido > TEMPO_PARA_INSTANCIAR_PARTICULA_CHAO && alvo.transform.localScale.sqrMagnitude > 0.01f)
                {
                    ParticulasDeSubstituicao.ParticulaSaiDaLuva(alvo.transform.position);
                    if (!eItem)
                        estado = EstadoDoAnimaBraco.DiminuiEscalaDoCriature;
                    else
                    {
                       // mCamera.BomFoco = false;
                        estado = EstadoDoAnimaBraco.TerminaORaio;
                    }
                    tempoDecorrido = 0;
                }
                break;
            case EstadoDoAnimaBraco.DiminuiEscalaDoCriature:
                if (tempoDecorrido < TEMPO_DE_REDUCAO_DE_ESCALA)
                {
                    alvo.transform.localScale = Vector3.Lerp(alvo.transform.localScale, Vector3.zero, 2 * Time.deltaTime);
                }
                else
                {
                    estado = EstadoDoAnimaBraco.TerminaORaio;
                    tempoDecorrido = 0;
                }
                break;
            case EstadoDoAnimaBraco.TerminaORaio:
                if (tempoDecorrido < TEMPO_PARA_FINALISAR_RAIO)
                {
                    if (!eItem)
                        MonoBehaviour.Destroy(alvo);

                    ParticulasDeSubstituicao.ReduzVelocidadeDoRaio(raio);
                }
                else if (!eItem)
                {
                    MudarParaAnimaBracoFinalizado();
                    return false;
                }

                if (eItem)
                {
                    if (mCamera.FocarPonto(VELOCIDADE_DE_MOVIMENTO_DE_CAMERA *
                        Mathf.Max(Vector3.Distance(gerente.transform.position, alvo.transform.position),
                    VELOCIDADE_MINIMA_PARA_MOVIMENTO_DE_CAMERA)))
                    {
                        MudarParaAnimaBracoFinalizado();
                        return false;
                    }
                }
                break;
            case EstadoDoAnimaBraco.AnimaBracoFinalizado:
                return false;
                //break;
        }
        return true;
    }

    void MudarParaAnimaBracoFinalizado()
    {
        MonoBehaviour.Destroy(raio);
        MonoBehaviour.Destroy(luz);
        estado = EstadoDoAnimaBraco.AnimaBracoFinalizado;
    }
}
