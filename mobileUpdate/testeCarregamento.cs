using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class testeCarregamento : MonoBehaviour
{
    [SerializeField]private Image img;
    private float tempo = 0;
    private bool podeIr = false;
    private AsyncOperation[] a2;
    private SaveDates S;

    private const float tempoMin = 1;
    // Use this for initialization
    void Start()
    {
        
        SceneManager.LoadSceneAsync("comunsDeFase",LoadSceneMode.Additive);
        S = new LoadAndSaveGame().Load(0);
        if (S == null)
        {
            a2 = new AsyncOperation[1];
            a2[0] = SceneManager.LoadSceneAsync("MbInfinity", LoadSceneMode.Additive);
        }
        else
        {
            
            a2 = new AsyncOperation[S.VariaveisChave.CenasAtivas.Count];
            for (int i = 0; i < a2.Length; i++)
            {
                a2[i] = SceneManager.LoadSceneAsync(S.VariaveisChave.CenasAtivas[i].ToString(), LoadSceneMode.Additive);
            }
        }
        Time.timeScale = 0;
        SceneManager.sceneLoaded += SetarCenaPrincipal;
    }

    void SetarCenaPrincipal(Scene scene, LoadSceneMode mode)
    {
        if (S != null)
        {
            if (scene.name == S.VariaveisChave.CenaAtiva.ToString())
            {
                podeIr = true;
                InvocarSetScene(scene);
                SceneManager.sceneLoaded -= SetarCenaPrincipal;

                CharacterManager manager = GameController.g.Manager;
                AplicadorDeCamera.cam.transform.position = S.Posicao + new Vector3(0, 12, -10);//new Vector3(483, 12f, 745);
                manager.transform.position = S.Posicao;//new Vector3(483,1.2f,755);  
                manager.transform.rotation = S.Rotacao;
                GameController.g.ReiniciarContadorDeEncontro();
                Destroy(manager.CriatureAtivo.gameObject);
                manager.Dados = S.Dados;
                manager.InserirCriatureEmJogo();
                manager.CriatureAtivo.transform.position = S.Posicao + new Vector3(0, 0, 1);//new Vector3(483, 1.2f, 756);

                GameController.g.MyKeys = S.VariaveisChave;
            }
        }else
        if (scene.name != "comunsDeFase")
        {
            podeIr = true;
            InvocarSetScene(scene);
            SceneManager.sceneLoaded -= SetarCenaPrincipal;

            
            CharacterManager manager = GameController.g.Manager;
            AplicadorDeCamera.cam.transform.position = new Vector3(483, 12f, 745);
            manager.transform.position = new Vector3(483,1.2f,755);  
            GameController.g.ReiniciarContadorDeEncontro();          
            Destroy(manager.CriatureAtivo.gameObject);
            manager.InserirCriatureEmJogo();
            manager.CriatureAtivo.transform.position = new Vector3(483, 1.2f, 756);
            
        }
    }

    static IEnumerator setarScene(Scene scene)
    {
        yield return new WaitForSeconds(0.5f);
        InvocarSetScene(scene);
    }

    public static void InvocarSetScene(Scene scene)
    {
        Debug.Log(scene.name);
        if (!SceneManager.SetActiveScene(scene))
            GameController.g.StartCoroutine(setarScene(scene));
        Debug.Log("nomeAtiva: " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.fixedDeltaTime;

        float progresso = 0;

        for (int i = 0; i < a2.Length; i++)
        {
            progresso += a2[i].progress;
        }

        progresso /= a2.Length;

        img.fillAmount = Mathf.Min(progresso,tempo/tempoMin,1);

        if (podeIr && tempo >= tempoMin)
        {
            SceneManager.UnloadSceneAsync("testeCarregamento");
            Time.timeScale = 1;
        }
    }
}
