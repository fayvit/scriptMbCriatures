using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShopManager
{
    [SerializeField]private MenuDeShop menuDeShop;
    [SerializeField]private PainelQuantidadesParaShop painelQuantidades;

    private Sprite fotoDoNPC;
    private DisparaTexto dispara;
    private MenuBasico menuBasico;
    private FasesDoShop fase = FasesDoShop.emEspera;
    private nomeIDitem[] itensAVenda;
    private string[] t = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.shopBasico).ToArray();
    private string[] frasesDeShoping = bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.frasesDeShoping).ToArray();

    private enum FasesDoShop
    {
        emEspera,
        iniciouConversaNoShop,
        escolhaInicial,
        esperandoEscolha,
        fraseDeVenda,
        fraseDeCompra,
        quantidadesAbertas
    }
    public void Update()
    {
        switch (fase)
        {
            case FasesDoShop.iniciouConversaNoShop:
                AplicadorDeCamera.cam.FocarPonto(2, 8);
                if (dispara.UpdateDeTextos(t, fotoDoNPC)
                    ||
                    dispara.IndiceDaConversa > t.Length - 2
                    )
                {
                    EntraFrasePossoAjudar();
                }
            break;
            case FasesDoShop.escolhaInicial:

                if (!dispara.LendoMensagemAteOCheia())
                {
                    fase = FasesDoShop.esperandoEscolha;
                    menuBasico.IniciarHud(ComprarVender,bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.comprarOuVender).ToArray());
                }
            break;
            case FasesDoShop.fraseDeVenda:
                if (!dispara.LendoMensagemAteOCheia())
                {
                    fase = FasesDoShop.esperandoEscolha;
                    string[] opcoes = new string[itensAVenda.Length];
                    for (int i = 0; i < itensAVenda.Length; i++)
                    {
                        opcoes[i] = itensAVenda[i].ToString();
                    }
                    menuDeShop.IniciarHud(OpcaoEscolhidaParaCompra,opcoes);
                    menuDeShop.SetActive(true);
                }
            break;
            case FasesDoShop.fraseDeCompra:
                if (!dispara.LendoMensagemAteOCheia())
                {
                    fase = FasesDoShop.esperandoEscolha;
                    List<string> opcoes2 = new List<string>();
                    List<MbItens> meusItens = GameController.g.Manager.Dados.Itens;

                    for (int i = 0; i < meusItens.Count; i++)
                    {
                        if (meusItens[i].Valor > 0)
                            opcoes2.Add(meusItens[i].ID.ToString());
                    }
                    menuDeShop.IniciarHud(false,OpcaoEscolhidaParaVenda,opcoes2.ToArray());
                    menuDeShop.SetActive(true);
                }
            break;
            case FasesDoShop.quantidadesAbertas:
                if (!painelQuantidades.gameObject.activeSelf)
                {
                    menuDeShop.FinalizarHud();
                    if (painelQuantidades.Comprar)
                    {
                        ComprarVender(0);
                    }
                    else
                        ComprarVender(1);
                }
            break;
        }
    }

    void ComprarVender(int i)
    {
        dispara.ReligarPaineis();
        if (i == 0)
        {            
            dispara.Dispara(frasesDeShoping[0], fotoDoNPC);
            fase = FasesDoShop.fraseDeVenda;
        }
        else if (i == 1)
        {
            dispara.Dispara(frasesDeShoping[1], fotoDoNPC);
            fase = FasesDoShop.fraseDeCompra;
        }

        BotaoZaoExterno btn = GameController.g.HudM.Botaozao;
        btn.FinalizarBotao();
        btn.IniciarBotao(VoltarParaAPerguntaInicial);

        menuBasico.FinalizarHud();
    }

    void EntraFrasePossoAjudar()
    {
        dispara.ReligarPaineis();
        dispara.Dispara(t[t.Length - 1], fotoDoNPC);
        fase = FasesDoShop.escolhaInicial;
    }

    public void IniciarShop(nomeIDitem[] itensAVenda,Sprite fotoDoNPC)
    {
        this.fotoDoNPC = fotoDoNPC;

        this.itensAVenda = itensAVenda;

        GameController.g.HudM.Botaozao.IniciarBotao(SairDoShop);
        
        fase = FasesDoShop.iniciouConversaNoShop;

        dispara = GameController.g.HudM.DisparaT;
        menuBasico = GameController.g.HudM.Menu_Basico;
        dispara.IniciarDisparadorDeTextos();
        
    }

    void DesligarQuantidades()
    {
        painelQuantidades.gameObject.SetActive(false);
        GameController.g.HudM.Botaozao.FinalizarBotao();
    }

    void OpcaoEscolhidaParaCompra(int qual)
    {
        painelQuantidades.IniciarEssaHud(PegaUmItem.Retorna(itensAVenda[qual]));
        BtnsManager.DesligarBotoes(menuDeShop.gameObjectDoMenu);
        GameController.g.HudM.Botaozao.FinalizarBotao();
        GameController.g.HudM.Botaozao.IniciarBotao(DesligarQuantidades);
        fase = FasesDoShop.quantidadesAbertas;
    }

    void OpcaoEscolhidaParaVenda(int qual)
    {
        painelQuantidades.IniciarEssaHud(PegaUmItem.Retorna(GameController.g.Manager.Dados.Itens[qual].ID),false);
        BtnsManager.DesligarBotoes(menuDeShop.gameObjectDoMenu);
        GameController.g.HudM.Botaozao.FinalizarBotao();
        GameController.g.HudM.Botaozao.IniciarBotao(DesligarQuantidades);
        fase = FasesDoShop.quantidadesAbertas;
    }

    void VoltarParaAPerguntaInicial()
    {
        BotaoZaoExterno btn = GameController.g.HudM.Botaozao;
        btn.FinalizarBotao();
        btn.IniciarBotao(SairDoShop);
        menuDeShop.FinalizarHud();
        menuBasico.FinalizarHud();
        EntraFrasePossoAjudar();
    }

    void SairDoShop()
    {
        GameController g = GameController.g;
        AndroidController.a.LigarControlador();
        fase = FasesDoShop.emEspera;
        menuBasico.FinalizarHud();
        menuDeShop.FinalizarHud();

        g.Manager.AoHeroi();
        g.HudM.ligarControladores();
        dispara.DesligarPaineis();
        g.HudM.Botaozao.FinalizarBotao();
        
    }
}
