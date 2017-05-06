using UnityEngine;
using System.Collections;

[System.Serializable]
/// <summary>
/// Classe responsavel pelo uso da maçã
/// </summary>
public class MbMaca : MbItens
{
    [System.NonSerialized]private CreatureManager CriatureAlvoDoItem;
    private const float TEMPO_DE_ANIMA_CURA_1 = 1.5f;

    public MbMaca(int estoque = 1) : base(new ContainerDeCaracteristicasDeItem(nomeIDitem.maca)
    {
        valor = 10
    }
        )
    {
        Estoque = estoque;
    }

    public override void IniciaUsoDeMenu(GameObject dono)
    {
        GameController.g.HudM.P_EscolheUsoDeItens.AtivarParaItem(EscolhiEmQuemUsar);
        PainelMensCriature.p.AtivarNovaMens(string.Format(
            bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.emQuem),
            item.nomeEmLinguas(ID)
            ), 26);
    }

    void EscolhiEmQuemUsar(int indice)
    {
        CharacterManager manager = GameController.g.Manager;
        CriatureBase C = manager.Dados.CriaturesAtivos[indice];
        Atributos A = C.CaracCriature.meusAtributos;

        if (ItemQuantitativo.UsaItemDeRecuperacao(C))
        {
            RetirarUmItem(manager, this, 1,FluxoDeRetorno.menuHeroi);
            ItemQuantitativo.AplicacaoDoItemComMenu(manager,C,TipoQuantitativo.PV,10);            
        }
        else if (A.PV.Corrente <= 0)
        {
            MensDeUsoDeItem.MensDeMorto(C.NomeEmLinguas);
        }
        else if (A.PV.Corrente >= A.PV.Maximo)
        {
            MensDeUsoDeItem.MensDeNaoPrecisaDesseItem(C.NomeEmLinguas);
        }
    }

    public override bool AtualizaUsoDeMenu()
    {
        return false;
    }

    public override void IniciaUsoComCriature(GameObject dono)
    {
        IniciaUsoDaMaca(dono);
    }

    public override bool AtualizaUsoComCriature()
    {
        return AtualizaUsoDaMaca();
    }

    public override void IniciaUsoDeHeroi(GameObject dono)
    {
        IniciaUsoDaMaca(dono);
    }

    public override bool AtualizaUsoDeHeroi()
    {
        return AtualizaUsoDaMaca();
    }

    private void IniciaUsoDaMaca(GameObject dono)
    {
        Manager = GameController.g.Manager;
        CriatureAlvoDoItem = Manager.CriatureAtivo;
        if (ItemQuantitativo.UsaItemDeRecuperacao(CriatureAlvoDoItem.MeuCriatureBase) && RetirarUmItem(Manager, this, 1))
        {
            InicializacaoComum(dono, Manager.CriatureAtivo.transform);
            Estado = EstadoDeUsoDeItem.animandoBraco;
        }
        else
        {
            Estado = EstadoDeUsoDeItem.finalizaUsaItem;
            if (!ItemQuantitativo.UsaItemDeRecuperacao(CriatureAlvoDoItem.MeuCriatureBase))
                PainelMensCriature.p.AtivarNovaMens(string.Format(
                    bancoDeTextos.falacoes[heroi.lingua]["mensLuta"][2], 
                    CriatureAlvoDoItem.MeuCriatureBase.NomeEmLinguas),30,5);
        }
    }

    private bool AtualizaUsoDaMaca()
    {
        
        switch (Estado)
        {
            case EstadoDeUsoDeItem.animandoBraco:
                if (!AnimaB.AnimaTroca(true))
                {
                    Estado = EstadoDeUsoDeItem.aplicandoItem;
                    Manager.Mov.Animador.ResetaTroca();
                    AuxiliarDeInstancia.InstancieEDestrua(DoJogo.acaoDeCura1,CriatureAlvoDoItem.transform.position, 1);
                }
            break;
            case EstadoDeUsoDeItem.aplicandoItem:
                TempoDecorrido += Time.deltaTime;
                if (TempoDecorrido > TEMPO_DE_ANIMA_CURA_1)
                {

                    ItemQuantitativo.RecuperaPV(CriatureAlvoDoItem.MeuCriatureBase.CaracCriature.meusAtributos, 10);
                    GameController.g.HudM.AtualizaHudHeroi(CriatureAlvoDoItem.MeuCriatureBase);
                    Estado = EstadoDeUsoDeItem.finalizaUsaItem;
                    return false;
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
