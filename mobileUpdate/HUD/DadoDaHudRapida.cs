using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DadoDaHudRapida : MonoBehaviour
{
    [SerializeField]private RawImage imgDoDado;
    [SerializeField]private Image daSelecao;
    [SerializeField]private Text txtDoDado;
    [SerializeField]private Text quantidade;
    [SerializeField]private GameObject containerDaQuantidade;

    private System.Action<int> aoClique;

    public Image DaSelecao
    {
        get { return daSelecao; }
        set { daSelecao = value; }
    }

    public void SetarGolpe(nomesGolpes nomeG)
    {
        containerDaQuantidade.SetActive(false);
        imgDoDado.texture = elementosDoJogo.el.RetornaMini(nomeG);
        txtDoDado.text = golpe.nomeEmLinguas(nomeG);
    }

    public void SetarAcao(System.Action<int> acao)
    {
        aoClique += acao;
    }

    public void LimparAcao()
    {
        aoClique = null;
    }

    public void SetarDados(DadosDoPersonagem dados,int indice,TipoDeDado tipo,System.Action<int> ao)
    {
        aoClique += ao;
        switch (tipo)
        {
            case TipoDeDado.item:
                imgDoDado.texture = elementosDoJogo.el.RetornaMini(dados.Itens[indice].ID);
                txtDoDado.text = item.nomeEmLinguas(dados.Itens[indice].ID);
                quantidade.text = dados.Itens[indice].Estoque.ToString();
            break;
            case TipoDeDado.golpe:
                nomesGolpes nomeG = dados.CriaturesAtivos[0].GerenteDeGolpes.meusGolpes[indice].Nome;
                SetarGolpe(nomeG);
            break;
            case TipoDeDado.criature:
                containerDaQuantidade.SetActive(false);
                imgDoDado.texture = elementosDoJogo.el.RetornaMini(dados.CriaturesAtivos[indice+1].NomeID);
                txtDoDado.text = dados.CriaturesAtivos[indice+1].NomeEmLinguas;
            break;
        }
    }

    public void FuncaoDoBotao()
    {
        aoClique(transform.GetSiblingIndex()-1);
    }
}

public enum TipoDeDado
{
    item,
    golpe,
    criature
}
