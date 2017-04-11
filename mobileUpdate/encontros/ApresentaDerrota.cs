using UnityEngine;
using System.Collections;

public class ApresentaDerrota
{
    private float contadorDeTempo = 0;
    private string[] textos;

    private FaseDaDerrota fase = FaseDaDerrota.emEspera;
    private CharacterManager manager;
    private CreatureManager inimigoDerrotado;
    private ReplaceManager replace;

    private const float TEMPO_PARA_MOSTRAR_MENSAGEM_INICIAL = 0.25F;

    private enum FaseDaDerrota
    {
        emEspera,
        abreMensagem,
        esperandoFecharMensagemDeDerrota,
        entrandoUmNovo
    }

    public enum RetornoDaDerrota
    {
        atualizando,
        voltarParaPasseio,
        deVoltaAoArmagedom
    }

    public ApresentaDerrota(CharacterManager manager, CreatureManager inimigoDerrotado)
    {
        this.manager = manager;
        this.inimigoDerrotado = inimigoDerrotado;
        textos = bancoDeTextos.RetornaTextoDoIdioma(ChaveDeTexto.apresentaDerrota).ToArray();
        fase = FaseDaDerrota.abreMensagem;
    }

    public RetornoDaDerrota Update()
    {
        switch (fase)
        {
            case FaseDaDerrota.abreMensagem:
                contadorDeTempo += Time.deltaTime;
                if (contadorDeTempo > TEMPO_PARA_MOSTRAR_MENSAGEM_INICIAL)
                {
                    PainelMensCriature.p.AtivarNovaMens(string.Format(textos[0],
                        manager.CriatureAtivo.MeuCriatureBase.NomeEmLinguas),30);
                    fase = FaseDaDerrota.esperandoFecharMensagemDeDerrota;
                }
            break;
            case FaseDaDerrota.esperandoFecharMensagemDeDerrota:
                if (Input.GetMouseButtonDown(0))
                {
                    PainelMensCriature.p.EsconderMensagem();
                    if (manager.Dados.TemCriatureVivo())
                    {
                        PainelMensCriature.p.AtivarNovaMens(textos[1], 20);
                        GameController.g.HudM.EntraCriatures.IniciarEssaHUD(manager.Dados,AoEscolherUmCriature);
                        fase = FaseDaDerrota.emEspera;
                    }
                    else
                    {
                        // Aqui vamos de volta para o armagedom
                    }
                }
            break;
            case FaseDaDerrota.entrandoUmNovo:
                if (replace.Update())
                {
                    manager.AoCriature(inimigoDerrotado);
                    GameController.g.HudM.AtualizeHud (manager, inimigoDerrotado.MeuCriatureBase);
                    fase = FaseDaDerrota.emEspera;
                    return RetornoDaDerrota.voltarParaPasseio;
                }
            break;
        }

        return RetornoDaDerrota.atualizando;
    }

    public void AoEscolherUmCriature(int qual)
    {
        manager.Dados.criatureSai = qual;
        fase = FaseDaDerrota.entrandoUmNovo;        
        replace = new ReplaceManager(manager,manager.CriatureAtivo.transform,FluxoDeRetorno.criature);
        GameController.g.HudM.EntraCriatures.FinalizarHud();
        PainelMensCriature.p.EsconderMensagem();
    }
}
