using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotaoZaoExterno : MonoBehaviour
{
    [SerializeField]private Text txtDoBotao;

    private System.Action acao;

    public void IniciarBotao(System.Action acao,string labelDoBotao = "Voltar")
    {
        this.acao += acao;
        gameObject.SetActive(true);
        txtDoBotao.text = labelDoBotao;
    }
    public void FuncaoDoBotao()
    {
        if(acao!=null)
            acao();
    }

    public void FinalizarBotao()
    {
        gameObject.SetActive(false);
        acao = null;
    }
}
