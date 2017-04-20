using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class testeCarregamento : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
        SceneManager.LoadScene("comunsDeFase");
        SceneManager.LoadSceneAsync("Infinity1", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SetarCenaPrincipal;
    }

    static void SetarCenaPrincipal(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "comunsDeFase")
        {
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

    }
}
