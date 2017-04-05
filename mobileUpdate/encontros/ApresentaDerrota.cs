using UnityEngine;
using System.Collections;

public class ApresentaDerrota
{
    private float contadorDeTempo = 0;
    private string[] textos;

    private FaseDaDerrota fase = FaseDaDerrota.emEspera;
    private CharacterManager manager;
    private CreatureManager inimigoDerrotado;

    private const float TEMPO_PARA_MOSTRAR_MENSAGEM_INICIAL = 0.25F;

    private enum FaseDaDerrota
    {
        emEspera,
        abreMensagem,
        esperandoFecharMensagemDeDerrota,
        entrandoUmNovo
    }

    public ApresentaDerrota(CharacterManager manager, CreatureManager inimigoDerrotado)
    {
        this.manager = manager;
        this.inimigoDerrotado = inimigoDerrotado;
        textos = bancoDeTextos.RetornaTextoDoIdioma(ChaveDeTexto.apresentaDerrota).ToArray();
        fase = FaseDaDerrota.abreMensagem;
    }

    public void Update()
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

                    }
                }
            break;
            case FaseDaDerrota.entrandoUmNovo:

            break;
        }
    }

    public void AoEscolherUmCriature(int qual)
    {

    }
}
