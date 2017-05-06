using UnityEngine;
using System.Collections;

[System.Serializable]
public class NPCdasCartaLuva : NPCdeConversa
{
    private DisparaTexto dispara;
    private EstadoDoCartaLuva estadoInterno = EstadoDoCartaLuva.emEspera;
    private enum EstadoDoCartaLuva
    {
        emEspera,
        pergunta,
        esperandoResposta,
        respondendo,
    }
    public override bool Update()
    {
        if (estadoInterno == EstadoDoCartaLuva.emEspera)
        {
            if (estado == EstadoDoNPC.conversando
                && GameController.g.HudM.DisparaT.IndiceDaConversa == conversa.Length - 1
                )
            {
                estadoInterno = EstadoDoCartaLuva.pergunta;
                return UpdateInterno();
            }
            else
                return base.Update();
        }else
            return UpdateInterno();
    }

    bool UpdateInterno()
    {
        if(dispara==null)
            dispara = GameController.g.HudM.DisparaT;

        switch (estadoInterno)
        {
            case EstadoDoCartaLuva.pergunta:
                HudManager hudM = GameController.g.HudM;
                dispara.Dispara(conversa[conversa.Length - 1], fotoDoNPC);
                hudM.Menu_Basico.IniciarHud(qualOpcao,bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.simOuNao).ToArray());
                estadoInterno = EstadoDoCartaLuva.esperandoResposta;
            break;
            case EstadoDoCartaLuva.esperandoResposta:
                dispara.LendoMensagemAteOCheia();
            break;
            case EstadoDoCartaLuva.respondendo:
                if (!dispara.LendoMensagemAteOCheia())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        estadoInterno = EstadoDoCartaLuva.emEspera;
                        GameController.g.HudM.MostrarItem.DesligarPainel();
                        dispara.DesligarPaineis();
                        FinalizaConversa();
                        return true;
                    }
                }
            break;
        }

        return false;
    }

    void qualOpcao(int opcao)
    {
        GameController g = GameController.g;
        DadosDoPersonagem dados = g.Manager.Dados;
        CriatureBase[] criatures = dados.CriaturesAtivos.ToArray();
        int indiceDaResposta = -1;

        estadoInterno = EstadoDoCartaLuva.respondendo;
        

        switch (opcao)
        {
            case 0:
                if (criatures.Length > 1)
                {
                    indiceDaResposta = 1;
                }
                else
                {
                    indiceDaResposta = 2;
                }
            break;
            case 1:
                if (criatures.Length > 1)
                {
                    indiceDaResposta = 3;
                }
                else if (dados.TemItem(nomeIDitem.cartaLuva)<=0)
                {
                    dados.AdicionaItem(nomeIDitem.cartaLuva, 5);
                    g.HudM.MostrarItem.IniciarPainel(nomeIDitem.cartaLuva, 5);
                    indiceDaResposta = 0;
                }
                else
                {
                    indiceDaResposta = 4;
                }
            break;
        }

        g.HudM.DisparaT.IniciarDisparadorDeTextos();
        g.HudM.Menu_Basico.FinalizarHud();
        g.HudM.DisparaT.Dispara(bancoDeTextos.RetornaListaDeTextoDoIdioma(ChaveDeTexto.infinity12respostas)[indiceDaResposta],fotoDoNPC);
    }
}
