using UnityEngine;
using System.Collections;

[System.Serializable]
/// <summary>
/// Classe responsavel pelo uso da maçã
/// </summary>
public class MbCartaLuva : MbItens
{
    [System.NonSerialized]private AnimandoCaptura animaCap;
    private bool captura;
    public MbCartaLuva(int estoque = 1) : base(new ContainerDeCaracteristicasDeItem(nomeIDitem.cartaLuva)
    {
        valor = 12
    }
        )
    {
        Estoque = estoque;
    }

    public override void IniciaUsoDeMenu(GameObject dono)
    {
        /*
        GameController.g.HudM.P_EscolheUsoDeItens.AtivarParaItem(EscolhiEmQuemUsar);
        PainelMensCriature.p.AtivarNovaMens(string.Format(
            bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.emQuem),
            item.nomeEmLinguas(ID)
            ), 26);
            */
    }

    public override bool AtualizaUsoDeMenu()
    {
        return false;
    }

    public override void IniciaUsoComCriature(GameObject dono)
    {
        IniciaUsoDaCarta(dono);
    }

    public override bool AtualizaUsoComCriature()
    {
        return AtualizaUsoDaCarta();
    }

    public override void IniciaUsoDeHeroi(GameObject dono)
    {
        IniciaUsoDaCarta(dono);
    }

    public override bool AtualizaUsoDeHeroi()
    {
        return AtualizaUsoDaCarta();
    }

    bool PodeUsar()
    {
        if (GameController.g.estaEmLuta)
            return true;

        return false;
    }

    private void IniciaUsoDaCarta(GameObject dono)
    {
        if (PodeUsar())
        {
            Manager = GameController.g.Manager;
            Estado = EstadoDeUsoDeItem.animandoBraco;
            RetirarUmItem(Manager, this, 1);
            InicializacaoComum(dono,GameController.g.InimigoAtivo.transform);
            
        }
        else
        {
            Estado = EstadoDeUsoDeItem.finalizaUsaItem;
            PainelMensCriature.p.AtivarNovaMens(bancoDeTextos.falacoes[heroi.lingua]["mensLuta"][0], 30, 7);
        }
    }

    bool ContinhaDeCaptura()
    {
        int vida = GameController.g.InimigoAtivo.MeuCriatureBase.CaracCriature.meusAtributos.PV.Corrente;

        bool retorno = false;


        if (vida == 2)
        {
            float x = Random.value;
            if (x > 0.75f)
                retorno = true;
            else
                retorno = false;
        }

        if (vida == 1)
        {
            float y = Random.value;
            if (y > 0.25f)
                retorno = true;
            else
                retorno = false;
        }

        return retorno;
    }

    private bool AtualizaUsoDaCarta()
    {

        switch (Estado)
        {
            case EstadoDeUsoDeItem.animandoBraco:
                if (!AnimaB.AnimaTroca(true))
                {
                    captura = ContinhaDeCaptura();
                    Estado = EstadoDeUsoDeItem.aplicandoItem;                    
                    animaCap = new AnimandoCaptura(captura);
                }
                break;
            case EstadoDeUsoDeItem.aplicandoItem:
                if (!animaCap.Update())
                {
                    if (captura)
                    {
                        GameController.g.RetornarParaFluxoDoHeroi();
                        Estado = EstadoDeUsoDeItem.nulo;
                    }
                    else
                    {
                        Manager.Mov.Animador.ResetaTroca();
                        Estado = EstadoDeUsoDeItem.finalizaUsaItem;
                    }

                    
                }
            break;
            case EstadoDeUsoDeItem.finalizaUsaItem:
            return false;
            //break;
            case EstadoDeUsoDeItem.nulo:
                Debug.Log("alcançou estado nulo para " + ID.ToString());
            break;
        }
        return true;
    }
}
