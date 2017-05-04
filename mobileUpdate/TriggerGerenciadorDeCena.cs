using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TriggerGerenciadorDeCena : MonoBehaviour
{
    public bool ligar = false;
    public NomesCenas[] cenasAlvo;
    public NomesCenas cenaAtivaNoDesligar = NomesCenas.MbInfinity;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (ligar)
                LigaCenas();
            else
                DesligaCenas();
        }
    }

    void LigaCenas()
    {
        for (int i = 0; i < cenasAlvo.Length; i++)
        {
            if (!SceneManager.GetSceneByName(cenasAlvo[i].ToString()).isLoaded)
            {
                SceneManager.LoadSceneAsync(cenasAlvo[i].ToString(), LoadSceneMode.Additive);
                SceneManager.sceneLoaded += SetarCenaPrincipal;
            }
        }
    }

    void DesligaCenas()
    {
        for (int i = 0; i < cenasAlvo.Length; i++)
        {
            if (SceneManager.GetSceneByName(cenasAlvo[i].ToString()).isLoaded)
            {
                SceneManager.UnloadSceneAsync(cenasAlvo[i].ToString());
                SceneManager.sceneUnloaded += SetarCenaPrincipalNoDescarregamento;
            }
        }
    }

    void SetarCenaPrincipalNoDescarregamento(Scene cena)
    {
        Scene cenaParaAtivars = SceneManager.GetSceneByName(cenaAtivaNoDesligar.ToString());
        GameController.g.MyKeys.RemoverCenaAtiva(cena);
        if (cenaParaAtivars.isLoaded)
        {
            InvocarSetScene(cenaParaAtivars);
        }
        else {
            Debug.LogWarning("A cena escolhida para ativa não está carregada");
        }
    }

    static void SetarCenaPrincipal(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "comunsDeFase")
        {
            GameController.g.MyKeys.AdicioneCenaAtiva(scene);
            InvocarSetScene(scene);
            SceneManager.sceneLoaded -= SetarCenaPrincipal;
        }
    }

    static IEnumerator setarScene(Scene scene)
    {
        yield return new WaitForSeconds(0.5f);
        InvocarSetScene(scene);
    }
    public static void InvocarSetScene(Scene scene)
    {
        //Debug.Log(scene.name);
        if (!SceneManager.SetActiveScene(scene))
            GameController.g.StartCoroutine(setarScene(scene));
        Debug.Log("nomeAtiva: " + SceneManager.GetActiveScene().name);
    }
}

public enum NomesCenas
{
    MbInfinity,
    MbFlorestaOesteDeInfinity,
    MbFlorestaLesteDeInfinity
}
