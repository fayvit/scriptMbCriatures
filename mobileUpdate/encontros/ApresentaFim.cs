using UnityEngine;
using System.Collections;

public class ApresentaFim
{
    private bool apresentouFim = false;
    private bool ligouMensagemDeFim = false;
    private float contadorDeTempo = 0;

    private CreatureManager criatureDoJogador;
    private CreatureManager inimigoDerrotado;
    private AplicadorDeCamera cam;

    private const float TEMPO_PARA_MOSTRAR_VITORIA = 1.3f;
    private const float TEMPO_PARA_FECHAR_APRESENTA_FIM = 10;

    public ApresentaFim(CreatureManager criatureDoJogador,CreatureManager inimigoDerrotado,AplicadorDeCamera cam)
    {
        this.criatureDoJogador = criatureDoJogador;
        this.inimigoDerrotado = inimigoDerrotado;
        this.cam = cam;
    }
    

    void ColocaCameraEmPOsicao()
    {
        
        float alturaParaCamera = criatureDoJogador.Mov.Controle.height;
        //Deve verificar o tipo de movimentação da camera
        cam.transform.position = (criatureDoJogador.transform.position
            + 8 * criatureDoJogador.transform.forward
            + (5 + alturaParaCamera) * Vector3.up);
        cam.transform.LookAt(criatureDoJogador.transform);

    }

    public bool EstouApresentando()
    {
        contadorDeTempo += Time.deltaTime;
        if (contadorDeTempo > TEMPO_PARA_MOSTRAR_VITORIA)
        {
            if (!apresentouFim)
            {
                ColocaCameraEmPOsicao();
                cam.InicializaCameraExibicionista(criatureDoJogador.transform, criatureDoJogador.Mov.Controle.height);
                GameController.g.HudM.DesligaContainerDoInimigo();
                apresentouFim = true;
            }
            else
            {
                if (!ligouMensagemDeFim)
                {
                    Atributos A = inimigoDerrotado.MeuCriatureBase.CaracCriature.meusAtributos;
                    PainelMensCriature.p.AtivarNovaMens(
                        string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.apresentaFim),
                        criatureDoJogador.MeuCriatureBase.NomeID,
                        (int)((float)A.PV.Maximo / 2),
                        A.PV.Maximo), 20);
                    ligouMensagemDeFim = true;
                }
                else if (Input.GetMouseButtonDown(0) || contadorDeTempo > TEMPO_PARA_FECHAR_APRESENTA_FIM)
                {
                    PainelMensCriature.p.EsconderMensagem();
                    return false;
                }

            }
        }
        return true;
    }
}
