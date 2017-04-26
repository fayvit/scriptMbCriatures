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
    private float tempoDecorido = 0;
    private string[] frasesDeArmagedom = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.frasesDeArmagedom).ToArray();

    private const float TEMPO_DE_CURA = 2.5F;


    private enum fasesDoArmagedom
    {
        emEspera,
        mensInicial,
        escolhaInicial,
        esperandoEscolha,
        curando,
        fraseDeCurado
    }
    // Use this for initialization
    void Start()
    {

    }

    public void Inicia(Sprite foto = null)
    {
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
                string[] t = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.primeiroArmagedom).ToArray();
                if (dispara.UpdateDeTextos(t, fotoDoNPC)
                    ||
                    dispara.IndiceDaConversa > t.Length - 2
                    )
                {
                    dispara.Dispara(t[t.Length - 1], fotoDoNPC);
                    LigarMenu();
                    fase = fasesDoArmagedom.escolhaInicial;
                }
            break;
            case fasesDoArmagedom.escolhaInicial:
                
                if (dispara.LendoMensagem()!=DisparaTexto.FasesDaMensagem.mensagemCheia)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        dispara.Toque();
                    }
                }
                else
                    fase = fasesDoArmagedom.esperandoEscolha;
            break;
            case fasesDoArmagedom.curando:
                print("um");
                tempoDecorido += Time.deltaTime;
                if (tempoDecorido > TEMPO_DE_CURA || Input.GetMouseButtonDown(0))
                {
                    fase = fasesDoArmagedom.fraseDeCurado;
                    dispara.ReligarPaineis();
                    dispara.Dispara(frasesDeArmagedom[0],fotoDoNPC);
                }
            break;
            case fasesDoArmagedom.fraseDeCurado:
                if (dispara.LendoMensagem() != DisparaTexto.FasesDaMensagem.mensagemCheia)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        dispara.Toque();
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        dispara.ReligarPaineis();
                        string[] tt = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.primeiroArmagedom).ToArray();
                        dispara.Dispara( tt[tt.Length - 1], fotoDoNPC);
                        LigarMenu();
                        fase = fasesDoArmagedom.escolhaInicial;
                    }
                }
            break;
        }
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
        for (int i = 0; i < manager.Dados.criaturesAtivos.Count; i++)
        {
            if (i < Vs.Length)
            {
                animaVida2 = Instantiate(animaVida, Vs[i], Quaternion.identity);
                Destroy(animaVida2, 1);
            }
        }

    }

    public void BotaoCurar()
    {
        ApagarMenu();
        InstanciaVisaoDeCura();
        GameController.g.Manager.Dados.TodosCriaturesPerfeitos();
        GameController.g.HudM.AtualizaHudHeroi();
    
        fase = fasesDoArmagedom.curando;
        dispara.DesligarPaineis();
        tempoDecorido = 0;
    }

    public void BotaoVoltarAoJogo()
    {
        GameController g = GameController.g;
        AndroidController.a.LigarControlador();

        g.Manager.AoHeroi();
        g.HudM.ligarControladores();
        fase = fasesDoArmagedom.emEspera;
        dispara.DesligarPaineis();
        gameObject.SetActive(false);
    }
}
