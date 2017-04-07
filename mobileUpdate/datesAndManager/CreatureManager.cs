using UnityEngine;
using System.Collections;

public class CreatureManager : MonoBehaviour
{
    [SerializeField]private CreatureState estado = CreatureState.seguindo;
    [SerializeField]private Transform tDono;
    [SerializeField]private CriatureBase meuCriatureBase;
    [SerializeField]private IA_Base ia;
    [SerializeField]private MovimentacaoBasica mov;

    private AndroidController controle;
    
    public enum CreatureState
    {
        aPasseio,
        seguindo,
        morto,
        selvagem,
        aplicandoGolpe,
        emDano,
        emLuta,
        parado
    }

    public CriatureBase MeuCriatureBase
    {
        get { return meuCriatureBase; }
        set { meuCriatureBase = value; }
    }

    public Transform TDono
    {
        get { return tDono; }
        set { tDono = value; }
    }

    public CreatureState Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    public IA_Base IA
    {
        get { return ia; }
        set { ia = value; }
    }

    public MovimentacaoBasica Mov
    {
        get { return mov; }
    }


    public bool MudaAplicaGolpe()
    {
        bool retorno = false;
        if (estado == CreatureState.aPasseio || estado==CreatureState.emLuta ||estado==CreatureState.selvagem)
        {
            estado = CreatureState.aplicandoGolpe;
            retorno = true;
        }else
            Debug.LogError("estado indefinido");

        return retorno;
    }
    public bool LiberaMovimento(CreatureState esseEstado)
    {
        if (estado == esseEstado)
        {
            if (name == "CriatureAtivo")
                estado = GameController.g.estaEmLuta ? CreatureState.emLuta : CreatureState.aPasseio;
            else
                estado = CreatureState.selvagem;

            return true;
        }
        else
            return false;
    }

    // Use this for initialization
    void Start()
    {
        mov = null;
        ia.Start(this);
        //personagemG2.Start();
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case CreatureState.parado:
                if(mov!=null)
                    mov.AplicadorDeMovimentos(Vector3.zero, meuCriatureBase.CaracCriature.distanciaFundamentadora);
            break;
            case CreatureState.seguindo:
            case CreatureState.selvagem:
                ia.Update();
            break;
            case CreatureState.aPasseio:
            case CreatureState.emLuta:
                Vector3 dir = Vector3.zero;
                if (controle)
                {
                    dir = controle.ValorParaEixos();
                    if (estado == CreatureState.emLuta)
                        dir = direcaoInduzida(dir.x, dir.z);
                }

                if (mov == null)
                {
                    mov = new MovimentacaoBasica(
                       meuCriatureBase.Mov, new ElementosDeMovimentacao()
                       {
                           animador = new AnimadorHumano(GetComponent<Animator>()),
                           controle = GetComponent<CharacterController>(),
                           transform = transform
                       }
                        );

                    controle = FindObjectOfType<AndroidController>();
                }
                else
                {
                    mov.AplicadorDeMovimentos(dir, meuCriatureBase.CaracCriature.distanciaFundamentadora);
                }

                break;
        }
    }

    Vector3 direcaoInduzida(float h, float v)
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 retorno = cameraTransform.TransformDirection(Vector3.forward);
        retorno = Vector3.ProjectOnPlane(retorno, Vector3.up).normalized;
        retorno = v * retorno - h * (Vector3.Cross(retorno, Vector3.up));
        
        return retorno;
    }

    void AplicaGolpe()
    {
        Atributos A = MeuCriatureBase.CaracCriature.meusAtributos;
        IGolpeBase gg = meuCriatureBase.GerenteDeGolpes.meusGolpes[meuCriatureBase.GerenteDeGolpes.golpeEscolhido];
        
        if (!DisparadorDoGolpe.Dispara(meuCriatureBase,gameObject))
        {
            string[] textos = bancoDeTextos.RetornaTextoDoIdioma(ChaveDeTexto.usoDeGolpe).ToArray();
            if (gg.UltimoUso + gg.TempoDeReuso >= Time.time)
                PainelMensCriature.p.AtivarNovaMens(
                    string.Format(textos[0], comandos.mostradorDeTempo(gg.UltimoUso - (Time.time - gg.TempoDeReuso)))
                    , 25, 2);
            else if (A.PE.Corrente < gg.CustoPE)
                PainelMensCriature.p.AtivarNovaMens(textos[1], 25, 2);
        }
    }

    public void ComandoDeAtacar()
    {
        if (estado == CreatureState.aPasseio || estado == CreatureState.emLuta)
            AplicaGolpe();
    }

    public void IniciaPulo()
    {
        
        if (!meuCriatureBase.Mov.caracPulo.estouPulando && (estado == CreatureState.aPasseio ||estado==CreatureState.emLuta))
            mov._Pulo.IniciaAplicaPulo();
    }
}


