using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UmaOpcaoDeMenu : MonoBehaviour
{
    [SerializeField]private Text textoOpcao;
    private System.Action<int> acao;

    protected Text TextoOpcao
    {
        get { return textoOpcao; }
        set { textoOpcao = value; }
    }

    protected System.Action<int> Acao
    {
        get { return acao; }
        set { acao = value; }
    }

    public virtual void SetarOpcao(System.Action<int> acaoDaOpcao,string txtDaOpcao)
    {
        Acao += acaoDaOpcao;
        TextoOpcao.text = txtDaOpcao;
    }

    public void FuncaoDoBotao()
    {
        Acao(transform.GetSiblingIndex() - 1);
    }
}
