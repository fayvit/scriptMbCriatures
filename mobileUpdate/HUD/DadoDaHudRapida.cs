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

    public void SetarDados(DadosDoPersonagem dados,int indice,TipoDeDado tipo,System.Action<int> ao)
    {
        aoClique += ao;
        switch (tipo)
        {
            case TipoDeDado.item:
                imgDoDado.texture = elementosDoJogo.el.RetornaMini(dados.itens[indice].ID);
                txtDoDado.text = item.nomeEmLinguas(dados.itens[indice].ID);
                quantidade.text = dados.itens[indice].Estoque.ToString();
            break;
            case TipoDeDado.golpe:
                nomesGolpes nomeG = dados.criaturesAtivos[0].GerenteDeGolpes.meusGolpes[indice].Nome;
                containerDaQuantidade.SetActive(false);
                imgDoDado.texture = elementosDoJogo.el.RetornaMini(nomeG);
                txtDoDado.text = golpe.nomeEmLinguas(nomeG);
            break;
            case TipoDeDado.criature:
                containerDaQuantidade.SetActive(false);
                imgDoDado.texture = elementosDoJogo.el.RetornaMini(dados.criaturesAtivos[indice+1].NomeID);
                txtDoDado.text = dados.criaturesAtivos[indice+1].NomeEmLinguas;
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
