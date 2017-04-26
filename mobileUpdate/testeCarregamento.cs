using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class testeCarregamento : MonoBehaviour
{
    [SerializeField]private Image img;
    private float tempo = 0;
    private bool podeIr = false;
    private AsyncOperation a2;

    private const float tempoMin = 1;
    // Use this for initialization
    void Start()
    {
        
        SceneManager.LoadSceneAsync("comunsDeFase",LoadSceneMode.Additive);
        a2 = SceneManager.LoadSceneAsync("Infinity1", LoadSceneMode.Additive);
        Time.timeScale = 0;
        SceneManager.sceneLoaded += SetarCenaPrincipal;
    }

    void SetarCenaPrincipal(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "comunsDeFase")
        {
            podeIr = true;
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
        Debug.Log(scene.name);
        if (!SceneManager.SetActiveScene(scene))
            GameController.g.StartCoroutine(setarScene(scene));
        Debug.Log("nomeAtiva: " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.fixedDeltaTime;

        img.fillAmount = Mathf.Min(a2.progress,tempo/tempoMin,1);

        if (podeIr && tempo >= tempoMin)
        {
            SceneManager.UnloadSceneAsync("testeCarregamento");
            Time.timeScale = 1;
        }
    }
}
