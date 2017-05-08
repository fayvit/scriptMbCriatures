using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PainelQuantidadesParaShop : MonoBehaviour
{

    [SerializeField]private Text labelCristais;
    [SerializeField]private Text mensagem;
    [SerializeField]private Text quantidadeTXt;
    [SerializeField]private Text valorAPagar;
    [SerializeField]private Text labelValorAPagar;
    [SerializeField]private Text infos;
    [SerializeField]private Text labelDoBotaoComprar;

    private int quantidade = 1;
    private bool comprar;
    private MbItens esseItem;
    private DadosDoPersonagem dados;
    private string[] textos = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.textosParaQuantidadesEmShop).ToArray();

    public bool Comprar
    {
        get { return comprar; }
    }
    void ReligarBotoes()
    {
        BtnsManager.ReligarBotoes(gameObject);
        BtnsManager.ReligarBotoes(GameController.g.HudM.Botaozao.gameObject);
    }

    void AtualizaQuantidade(int quantidade,int valor)
    {
        this.quantidade = quantidade;
        quantidadeTXt.text = quantidade.ToString();
        valorAPagar.text = (quantidade*valor).ToString();
    }

    void DesligaBotoes()
    {
        BtnsManager.DesligarBotoes(gameObject);
        BtnsManager.DesligarBotoes(GameController.g.HudM.Botaozao.gameObject);
    }

    void VerificaMais(int tanto)
    {
        if (comprar)
        {
            if ((quantidade + tanto) * esseItem.Valor > dados.cristais)
            {
                DesligaBotoes();
                GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(ReligarBotoes,
                    string.Format(textos[7], dados.cristais / esseItem.Valor, item.nomeEmLinguas(esseItem.ID))
                    );
                AtualizaQuantidade(dados.cristais / esseItem.Valor,esseItem.Valor);
            }
            else
            {
                AtualizaQuantidade(quantidade+tanto,esseItem.Valor);
            }
        }
        else
        {
            if (quantidade + tanto > dados.TemItem(esseItem.ID))
            {
                DesligaBotoes();
                GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(ReligarBotoes,
                    string.Format(textos[8], dados.TemItem(esseItem.ID), item.nomeEmLinguas(esseItem.ID))
                    );
                AtualizaQuantidade(dados.TemItem(esseItem.ID), esseItem.Valor / 4);
            }
            else
            {
                AtualizaQuantidade(quantidade+tanto,esseItem.Valor/4);
            }
        }
    }

    void VerificaMenos(int tanto)
    {
        if (comprar)
        {
            if (quantidade - tanto < 0)
            {
                DesligaBotoes();
                GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(ReligarBotoes, textos[9]);
                AtualizaQuantidade(1, esseItem.Valor);
            }
            else
                AtualizaQuantidade(quantidade - tanto, esseItem.Valor);
        }
        else
        {
            if (quantidade - tanto < 0)
            {
                DesligaBotoes();
                GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(ReligarBotoes, textos[10]);
                AtualizaQuantidade(1, esseItem.Valor/4);
            }
            else
                AtualizaQuantidade(quantidade - tanto, esseItem.Valor/4);
        }
    }

    public void IniciarEssaHud(MbItens itemAlvo,bool comprar = true)
    {
        this.comprar = comprar;
        gameObject.SetActive(true);
        esseItem = itemAlvo;
        dados = GameController.g.Manager.Dados;
        quantidade = 1;

        labelCristais.text = textos[0] + dados.cristais;
        mensagem.text = string.Format( comprar ? textos[3] : textos[4],item.nomeEmLinguas(itemAlvo.ID));
        infos.text = bancoDeTextos.falacoes[heroi.lingua]["shopInfoItem"][(int)(itemAlvo.ID)];
        quantidadeTXt.text = quantidade.ToString();

        valorAPagar.text = (itemAlvo.Valor/(comprar?1:4)).ToString();
        labelValorAPagar.text = comprar ? textos[1] : textos[2];
        labelDoBotaoComprar.text = comprar ? textos[5] : textos[6];
    }

    public void BotaoMaisUm()
    {
        VerificaMais(1);
    }

    public void BotaoMaisDez()
    {
        VerificaMais(10);
    }

    public void BotaoMenosUm()
    {
        VerificaMenos(1);
    }

    public void BotaoMenosDez()
    {
        VerificaMenos(10);
    }

    public void BotaoComprar()
    {
        if (comprar)
        {
            if (dados.cristais >= quantidade * esseItem.Valor)
            {
                dados.AdicionaItem(esseItem.ID, quantidade);
                dados.cristais -= quantidade * esseItem.Valor;
                gameObject.SetActive(false);
            }
            else
            {
                DesligaBotoes();
                GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(ReligarBotoes,
                    string.Format(textos[7], dados.cristais / esseItem.Valor, item.nomeEmLinguas(esseItem.ID))
                    );
                AtualizaQuantidade(dados.cristais / esseItem.Valor, esseItem.Valor);
            }
        }
        else
        {
            if (quantidade <= dados.TemItem(esseItem.ID))
            {
                MbItens.RetirarUmItem(GameController.g.Manager, esseItem, quantidade, FluxoDeRetorno.armagedom);
                dados.cristais += (quantidade * esseItem.Valor / 4);
                gameObject.SetActive(false);
            }
            else
            {
                DesligaBotoes();
                GameController.g.HudM.UmaMensagem.ConstroiPainelUmaMensagem(ReligarBotoes,
                    string.Format(textos[8], dados.TemItem(esseItem.ID), item.nomeEmLinguas(esseItem.ID))
                    );
                AtualizaQuantidade(dados.TemItem(esseItem.ID), esseItem.Valor / 4);
            }
        }
    }
}