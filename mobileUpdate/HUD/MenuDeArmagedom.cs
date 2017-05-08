using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuDeArmagedom : MonoBehaviour
{
    [SerializeField]private GameObject doMenu;
    [SerializeField]private Image img;

    private fasesDoArmagedom fase = fasesDoArmagedom.emEspera;
    private DisparaTexto dispara;
    private Sprite fotoDoNPC;
    private ReplaceManager replace;
    private Transform casinhaDoArmagedom;
    private float tempoDecorido = 0;
    private int indiceDoSubstituido = -1;
    private string tempString = "";

    private string[] frasesDeArmagedom = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.frasesDeArmagedom).ToArray();
    private string[] t = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.primeiroArmagedom).ToArray();

    private const float TEMPO_DE_CURA = 2.5F;


    private enum fasesDoArmagedom
    {
        emEspera,
        mensInicial,
        escolhaInicial,
        esperandoEscolha,
        curando,
        fraseQueAntecedePossoAjudar,
        fazendoUmaTroca,
        mensDetrocaAberta
    }

    // Use this for initialization
    void Start()
    {

    }

    public void Inicia(Transform T,Sprite foto = null)
    {
        casinhaDoArmagedom = T;
        fotoDoNPC = foto;
        gameObject.SetActive(true);
        ApagarMenu();
        fase = fasesDoArmagedom.mensInicial;
        dispara = GameController.g.HudM.DisparaT;

        dispara.IniciarDisparadorDeTextos();
    }

    void Update()
    {
        switch (fase)
        {            
            case fasesDoArmagedom.mensInicial:
                AplicadorDeCamera.cam.FocarPonto(2,8);
                if (dispara.UpdateDeTextos(t, fotoDoNPC)
                    ||
                    dispara.IndiceDaConversa > t.Length - 2
                    )
                {
                    EntraFrasePossoAjudar();
                    LigarMenu();
                }
            break;
            case fasesDoArmagedom.escolhaInicial:

                if (!dispara.LendoMensagemAteOCheia())                
                    fase = fasesDoArmagedom.esperandoEscolha;
            break;
            case fasesDoArmagedom.curando:
                
                tempoDecorido += Time.deltaTime;
                if (tempoDecorido > TEMPO_DE_CURA || Input.GetMouseButtonDown(0))
                {
                    fase = fasesDoArmagedom.fraseQueAntecedePossoAjudar;
                    dispara.ReligarPaineis();
                    dispara.Dispara(frasesDeArmagedom[0],fotoDoNPC);
                }
            break;
            case fasesDoArmagedom.fraseQueAntecedePossoAjudar:
                if (!dispara.LendoMensagemAteOCheia())  
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        
                        LigarMenu();
                        EntraFrasePossoAjudar();
                    }
                }
            break;
            case fasesDoArmagedom.fazendoUmaTroca:
                if (replace.Update())
                {
                    GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(()=> {
                        VoltarDoEntraArmagedado();
                        fase = fasesDoArmagedom.esperandoEscolha;
                    }, tempString);
                    AplicadorDeCamera.cam.InicializaCameraExibicionista(casinhaDoArmagedom, 1);
                    fase = fasesDoArmagedom.mensDetrocaAberta;
                }
            break;
            case fasesDoArmagedom.mensDetrocaAberta:
                AplicadorDeCamera.cam.FocarPonto(2, 8);
            break;
        }
    }

    void EntraFrasePossoAjudar()
    {
        dispara.ReligarPaineis();
        dispara.Dispara(t[t.Length - 1], fotoDoNPC);
        fase = fasesDoArmagedom.escolhaInicial;
    }

    void ApagarMenu()
    {
        doMenu.SetActive(false);
        img.enabled = false;
    }

    void LigarMenu()
    {
        img.enabled = true;
        doMenu.SetActive(true);
    }

    void InstanciaVisaoDeCura()
    {
        CharacterManager manager = GameController.g.Manager;

        Vector3 V = manager.CriatureAtivo.transform.position;
        Vector3 V2 = manager.transform.position;
        Vector3 V3 = new Vector3(1, 0, 0);
        Vector3[] Vs = new Vector3[] { V, V2 + V3, V2 + 2 * V3, V2 - V3, V2 - 2 * V3, V2 + 3 * V2, V2 - 3 * V3 };
        GameObject animaVida = elementosDoJogo.el.retorna(DoJogo.acaoDeCura1);
        GameObject animaVida2;

        for (int i = 0; i < manager.Dados.CriaturesAtivos.Count; i++)
        {
            if (i < Vs.Length)
            {
                animaVida2 = Instantiate(animaVida, Vs[i], Quaternion.identity);
                Destroy(animaVida2, 1);
            }
        }

    }

    void EscolhidoDoArmagedom(int indice)
    {
        GameController g = GameController.g;
        DadosDoPersonagem dados = g.Manager.Dados;
        HudManager hudM = g.HudM;
        if (dados.CriaturesAtivos.Count < dados.maxCarregaveis)
        {
            CriatureBase C = dados.CriaturesArmagedados[indice];
            hudM.UmaMensagem.ConstroiPainelUmaMensagem(VoltarDoEntraArmagedado,
                string.Format(frasesDeArmagedom[3], C.NomeEmLinguas, C.CaracCriature.mNivel.Nivel)
                );
            dados.CriaturesArmagedados.Remove(C);
            dados.CriaturesAtivos.Add(C);
        }
        else
        {
            CriatureBase C = dados.CriaturesArmagedados[indice];
            indiceDoSubstituido = indice;
            hudM.UmaMensagem.ConstroiPainelUmaMensagem(MostraOsQueSaem,
                string.Format(frasesDeArmagedom[4], C.NomeEmLinguas, C.CaracCriature.mNivel.Nivel)
                );
            GameController.g.HudM.EntraCriaturesArmagedados.FinalizarHud();
        }
    }

    void MostraOsQueSaem()
    {
        PainelMensCriature.p.AtivarNovaMens(frasesDeArmagedom[5],30);
        GameController.g.HudM.EntraCriaturesArmagedados
            .IniciarEssaHUD(GameController.g.Manager.Dados.CriaturesAtivos.ToArray(), SubstituiArmagedado);
    }

    void SubstituiArmagedado(int indice)
    {
        GameController g = GameController.g;
        DadosDoPersonagem dados = g.Manager.Dados;
        CriatureBase temp = dados.CriaturesArmagedados[indiceDoSubstituido];

        dados.CriaturesArmagedados[indiceDoSubstituido] = dados.CriaturesAtivos[indice];
        dados.CriaturesAtivos[indice] = temp;

        tempString = string.Format(frasesDeArmagedom[6], temp.NomeEmLinguas, temp.CaracCriature.mNivel.Nivel,
                dados.CriaturesArmagedados[indiceDoSubstituido].NomeEmLinguas,
                dados.CriaturesArmagedados[indiceDoSubstituido].CaracCriature.mNivel.Nivel
                );

        if (indice == 0)
        {
            dados.CriatureSai = 0;
            g.HudM.EntraCriaturesArmagedados.FinalizarHud();
            PainelMensCriature.p.EsconderMensagem();
            replace = new ReplaceManager(g.Manager,g.Manager.CriatureAtivo.transform,FluxoDeRetorno.armagedom);
            fase = fasesDoArmagedom.fazendoUmaTroca;
        }
        else
        {
            g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(VoltarDoEntraArmagedado,tempString);
        }
    }

    public void VoltarDoEntraArmagedado()
    {
        LigarMenu();
        EntraFrasePossoAjudar();
        GameController.g.HudM.EntraCriaturesArmagedados.FinalizarHud();
        PainelMensCriature.p.EsconderMensagem();        
    }

    public void BotaoCriaturesArmagedados()
    {
        GameController g = GameController.g;
        ApagarMenu();
        dispara.DesligarPaineis();
        CriatureBase[] armagedados = g.Manager.Dados.CriaturesArmagedados.ToArray();
        if (armagedados.Length > 0)
        {
            g.HudM.EntraCriaturesArmagedados.IniciarEssaHUD(armagedados, EscolhidoDoArmagedom);
            PainelMensCriature.p.AtivarNovaMens(frasesDeArmagedom[2],30);
        }
        else
        {
            dispara.DesligarPaineis();
            dispara.ReligarPaineis();
            dispara.Dispara(frasesDeArmagedom[1], fotoDoNPC);
            fase = fasesDoArmagedom.fraseQueAntecedePossoAjudar;
        }
    }

    public void BotaoCurar()
    {
        ApagarMenu();
        InstanciaVisaoDeCura();

        GameController.g.Manager.Dados.TodosCriaturesPerfeitos();
        GameController.g.HudM.AtualizaHudHeroi();
    
        tempoDecorido = 0;
        dispara.DesligarPaineis();
        fase = fasesDoArmagedom.curando;
    }

    public void BotaoVoltarAoJogo()
    {
        GameController g = GameController.g;
        AndroidController.a.LigarControlador();

        g.Manager.AoHeroi();
        g.HudM.ligarControladores();
        dispara.DesligarPaineis();
        gameObject.SetActive(false);
        fase = fasesDoArmagedom.emEspera;
    }
}
