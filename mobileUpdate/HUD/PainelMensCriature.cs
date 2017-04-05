using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PainelMensCriature : MonoBehaviour
{
    [SerializeField]private Text textoDaMensagem;

    private float tempoDeFuga = 0;
    private float contadorDeTempo = 0;

    public static PainelMensCriature p;
    // Use this for initialization

    void Start()
    {
        p = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        contadorDeTempo += Time.deltaTime;
        if (contadorDeTempo > tempoDeFuga && tempoDeFuga > 0)
            gameObject.SetActive(false);
    }

    public void AtivarNovaMens(string mensagem,int fontSize,float tempoDeFuga = 0)
    {
        gameObject.SetActive(true);
        textoDaMensagem.text = mensagem;
        textoDaMensagem.fontSize = fontSize;
        this.tempoDeFuga = tempoDeFuga;
        contadorDeTempo = 0;
    }

    public void EsconderMensagem()
    {
        gameObject.SetActive(false);
    }
}
