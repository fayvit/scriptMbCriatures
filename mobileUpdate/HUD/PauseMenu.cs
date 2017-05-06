using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private Text cristais;
    [SerializeField]private PainelStatus pStatus;
    [SerializeField]private PainelDeItens pItens;
    
    public static IEnumerator VoltaTextoPause()
    {
        yield return new WaitForSecondsRealtime(2);
        if (pausaJogo.pause)
            PainelMensCriature.p.AtivarNovaMens(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.jogoPausado), 30);
    }

    void OnEnable()
    {
        cristais.text = "Cristais:\t\t " + GameController.g.Manager.Dados.cristais;
    }
    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void ReligarBotoes()
    {
        BtnsManager.ReligarBotoes(gameObject);
    }

    public void ReligarBotoesDoPainelDeItens()
    {
        pItens.AtualizaHudDeItens();
        BtnsManager.ReligarBotoes(pItens.gameObject);
    }

    public void PausarJogo()
    {
        
        gameObject.SetActive(true);
        Time.timeScale = 0;
        pausaJogo.pause = true;
        PainelMensCriature.p.AtivarNovaMens(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.jogoPausado), 30);
        GameController.g.HudM.DesligaControladores();
        GameController.g.HudM.MenuDeI.FinalizarHud();
        AndroidController.a.DesligarControlador();
        
    }

    public void VoltarAoJogo()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        pausaJogo.pause = false;                
        PainelMensCriature.p.EsconderMensagem();
        GameController.g.HudM.ligarControladores();
        AndroidController.a.LigarControlador();
    }

    public void BotaoCriature()
    {
        pStatus.gameObject.SetActive(true);
    }

    public void BotaoItens()
    {
        BtnsManager.DesligarBotoes(gameObject);
        pItens.Ativar(ReligarBotoes);
    }

    public void VoltarAoTitulo()
    {
        pausaJogo.pause = false;
        SceneManager.LoadScene("testeCarregamento");
    }
}
