using UnityEngine;
using System.Collections;

/// <summary>
/// Classe responsavel pelo uso da maçã
/// </summary>
public class MbMaca : MbItens
{
    private CreatureManager CriatureAlvoDoItem;
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
        Manager = dono.GetComponent<CharacterManager>();
        CriatureAlvoDoItem = Manager.CriatureAtivo;
        if (ItemQuantitativo.UsaItemDeRecuperacao(CriatureAlvoDoItem.MeuCriatureBase) && RetirarUmItem(Manager, this, 1))
        {
            InicializacaoComum(dono);
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

    void InicializacaoComum(GameObject dono)
    {
        
        TempoDecorrido = 0;

        Manager.Estado = EstadoDePersonagem.parado;
        Manager.CriatureAtivo.Estado = CreatureManager.CreatureState.parado;
        Manager.Mov.Animador.PararAnimacao();

        if (GameController.g.estaEmLuta)
            GameController.g.InimigoAtivo.Estado = CreatureManager.CreatureState.parado;

        Cam = MonoBehaviour.FindObjectOfType<AplicadorDeCamera>();



        AnimaB = new AnimaBraco(Manager, Manager.CriatureAtivo.transform);

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
