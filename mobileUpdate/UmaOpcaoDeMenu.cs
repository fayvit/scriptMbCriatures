using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UmaOpcaoDeMenu : MonoBehaviour
{
    [SerializeField]private Text textoOpcao;
    private System.Action<int> acao;
    

    public void SetarOpcao(System.Action<int> acaoDaOpcao,string txtDaOpcao)
    {
        acao += acaoDaOpcao;
        textoOpcao.text = txtDaOpcao;
    }

    public void FuncaoDoBotao()
    {
        acao(transform.GetSiblingIndex() - 1);
    }
}
