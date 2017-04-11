using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]private Text cristais;
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

    public void PausarJogo()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        pausaJogo.pause = true;            
        PainelMensCriature.p.AtivarNovaMens("Jogo Pausado",30);
        GameController.g.HudM.DesligaControladores();
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

    public void CriaturesStatus()
    {

    }

    public void ItensPainel()
    {

    }

    public void VoltarAoTitulo()
    {

    }
}
