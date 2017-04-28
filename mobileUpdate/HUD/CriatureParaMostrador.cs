using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CriatureParaMostrador : MonoBehaviour
{
    [SerializeField]private RawImage imgDoCriature;
    [SerializeField]private Text txtPV;
    [SerializeField]private Text txtPVnum;
    [SerializeField]private Text txtPE;
    [SerializeField]private Text txtPEnum;
    [SerializeField]private Text nomeCriature;
    [SerializeField]private Text txtNivel;
    [SerializeField]private Text txtNivelNum;
    [SerializeField]private Text txtStausLabel;
    [SerializeField]private Text txtListaDeStatus;

    protected System.Action<int> cliqueDoPersonagem;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void QueroColocarEsse()
    {
        if (cliqueDoPersonagem != null)
            cliqueDoPersonagem(transform.GetSiblingIndex() - 1);
        else
            Debug.LogError("A função hedeira nã foi setada corretamente");
    }

    void DeVoltaAoMenu()
    {
        BtnsManager.ReligarBotoes(transform.parent.gameObject);
    }

    public virtual void FuncaoDoBotao()
    {
        BtnsManager.DesligarBotoes(transform.parent.gameObject);

        if (int.Parse(txtPVnum.text.Split('/')[0]) > 0)
        {
            GameController.g.HudM.Confirmacao.AtivarPainelDeConfirmacao(QueroColocarEsse, DeVoltaAoMenu,
                string.Format(bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.criatureParaMostrador)[0], nomeCriature.text)
                );
            //if (cliqueDoPersonagem != null)
            //    cliqueDoPersonagem(transform.GetSiblingIndex() - 1);
        }
        else
        {
            GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(DeVoltaAoMenu,
                string.Format(bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.criatureParaMostrador)[1], nomeCriature.text)
                );
        }
    }

    public void SetarCriature(CriatureBase C,System.Action<int> ao)
    {
        cliqueDoPersonagem += ao;

        Atributos A = C.CaracCriature.meusAtributos;

        imgDoCriature.texture = elementosDoJogo.el.RetornaMini(C.NomeID);
        nomeCriature.text = C.NomeEmLinguas;
        txtNivelNum.text = C.CaracCriature.mNivel.Nivel.ToString();
        txtPVnum.text = A.PV.Corrente+" / "+A.PV.Maximo;
        txtPEnum.text = A.PE.Corrente + " / " + A.PE.Maximo;
        txtListaDeStatus.text = "";

        if (A.PV.Corrente <= 0)
        {
            Text[] txtS = GetComponentsInChildren<Text>();

            for (int i = 1; i < txtS.Length - 2; i++)
                txtS[i].color = Color.gray;

            txtS[0].color = new Color(1, 1, 0.75f);

            txtListaDeStatus.text = "derrotado";
        }
        else
            txtListaDeStatus.text = "preparado";
    }
}
