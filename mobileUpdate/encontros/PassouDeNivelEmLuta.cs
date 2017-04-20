using UnityEngine;
using System.Collections;

public class PassouDeNivelEmLuta
{
    private float contadorDeTempo = 0;
    private int indiceParaEsquecer = 0;
    private CriatureBase oNivelado;
    private GolpePersonagem gp;
    private FasesDoPassouDeNivel fase = FasesDoPassouDeNivel.mostrandoNivel;

    private enum FasesDoPassouDeNivel
    {
        emEspera,
        mostrandoNivel,
        aprendeuGolpe,
        tentandoAprender,
        painelAprendeuGolpeAberto,
        finalizar
    }
    public PassouDeNivelEmLuta(CriatureBase oNivelado)
    {
        this.oNivelado = oNivelado;
        PainelMensCriature.p.AtivarNovaMens(
            string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.passouDeNivel),
            oNivelado.NomeEmLinguas,
            oNivelado.CaracCriature.mNivel.Nivel)
            , 20);
    }

    public bool Update()
    {
        switch (fase)
        {
            case FasesDoPassouDeNivel.mostrandoNivel:
                if (Input.GetMouseButtonDown(0))
                {
                    PainelMensCriature.p.EsconderMensagem();

                    gp = oNivelado.GerenteDeGolpes.VerificaGolpeDoNivel(
                        oNivelado.NomeID,oNivelado.CaracCriature.mNivel.Nivel
                        );

                    if (gp.Nome != nomesGolpes.nulo)
                    {
                        contadorDeTempo = 0;
                        AprendoOuTentoAprender();
                    }
                    else
                    {
                        return true;
                    }
                }
            break;
            case FasesDoPassouDeNivel.aprendeuGolpe:
                contadorDeTempo += Time.deltaTime;
                if (contadorDeTempo > 0.5f)
                {
                    PainelMensCriature.p.AtivarNovaMens(
                        string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.aprendeuGolpe),
                        oNivelado.NomeEmLinguas,
                        GolpeBase.NomeEmLinguas(gp.Nome))
                        , 30
                        );
                    GameController.g.HudM.P_Golpe.Aciona(PegaUmGolpeG2.RetornaGolpe(gp.Nome));
                    fase = FasesDoPassouDeNivel.painelAprendeuGolpeAberto;
                }
            break;
            case FasesDoPassouDeNivel.painelAprendeuGolpeAberto:
                if (Input.GetMouseButtonDown(0))
                {
                    fase = FasesDoPassouDeNivel.finalizar;
                }
            break;
            case FasesDoPassouDeNivel.tentandoAprender:
                contadorDeTempo += Time.deltaTime;
                if (contadorDeTempo > 0.5f)
                {
                    PainelMensCriature.p.AtivarNovaMens(
                        string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.tentandoAprenderGolpe),
                        oNivelado.NomeEmLinguas,
                        GolpeBase.NomeEmLinguas(gp.Nome))
                        , 24
                        );
                    HudManager hudM = GameController.g.HudM;
                    hudM.P_Golpe.Aciona(PegaUmGolpeG2.RetornaGolpe(gp.Nome));
                    hudM.H_Tenta.Aciona(oNivelado.GerenteDeGolpes.meusGolpes.ToArray(),gp.Nome,
                        string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.precisaEsquecer),oNivelado.NomeEmLinguas)
                        ,QualGolpeEsquecer);
                    fase = FasesDoPassouDeNivel.emEspera;
                }
            break;
            case FasesDoPassouDeNivel.finalizar:
                PainelMensCriature.p.EsconderMensagem();
                GameController.g.HudM.P_Golpe.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    void QualGolpeEsquecer(int indice)
    {
        /*observo que o indice é relacionado com os irmãos dentro do GameObject 
            pq originalmente foi construida para um painel responsivo
            que tinha um elemento desligado que era duplicado de acordo com o número de itens
        */

        indiceParaEsquecer = indice;
        
        if (indiceParaEsquecer < 4)
        {
            GameController.g.HudM.Confirmacao.AtivarPainelDeConfirmacao(EsquecerEsseGolpe, VoltarAsOpcoesDeEsquecer,
                string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.certezaEsquecer),
                oNivelado.GerenteDeGolpes.meusGolpes[indice].NomeEmLinguas(), GolpeBase.NomeEmLinguas(gp.Nome))
                );  
        }
        else if (indiceParaEsquecer == 4)
        {
            GameController.g.HudM.Confirmacao.AtivarPainelDeConfirmacao(NaoQueroAprenderEsse, VoltarAsOpcoesDeEsquecer,
                string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.naoQueroAprenderEsse),
                oNivelado.NomeEmLinguas, GolpeBase.NomeEmLinguas(gp.Nome))
                );            
        }

        BtnsManager.DesligarBotoes(GameController.g.HudM.H_Tenta.gameObject);
    }

    void NaoQueroAprenderEsse()
    {
        BtnsManager.ReligarBotoes(GameController.g.HudM.H_Tenta.gameObject);
        GameController.g.HudM.H_Tenta.Finalizar();
        fase = FasesDoPassouDeNivel.finalizar;
    }

    void EsquecerEsseGolpe()
    {
        
        BtnsManager.ReligarBotoes(GameController.g.HudM.H_Tenta.gameObject);
        GameController.g.HudM.H_Tenta.Finalizar();

        PainelMensCriature.p.EsconderMensagem();
        GameController.g.StartCoroutine(MensDeGolpeTrocado());
    }

    IEnumerator MensDeGolpeTrocado()
    {
        yield return new WaitForSeconds(0.5f);

        PainelMensCriature.p.AtivarNovaMens(
                        string.Format(bancoDeTextos.RetornaFraseDoIdioma(ChaveDeTexto.aprendeuGolpeEsquecendo),
                        oNivelado.NomeEmLinguas,
                        oNivelado.GerenteDeGolpes.meusGolpes[indiceParaEsquecer].NomeEmLinguas(),
                        GolpeBase.NomeEmLinguas(gp.Nome))
                        , 30
                        );

        oNivelado.GerenteDeGolpes.meusGolpes[indiceParaEsquecer] = PegaUmGolpeG2.RetornaGolpe(gp.Nome);

        fase = FasesDoPassouDeNivel.painelAprendeuGolpeAberto;
    }

    void VoltarAsOpcoesDeEsquecer()
    {
        BtnsManager.ReligarBotoes(GameController.g.HudM.H_Tenta.gameObject);
    }

    void AprendoOuTentoAprender()
    {
        if (oNivelado.GerenteDeGolpes.meusGolpes.Count < 4)
        {
            fase = FasesDoPassouDeNivel.aprendeuGolpe;
            oNivelado.GerenteDeGolpes.meusGolpes.Add(PegaUmGolpeG2.RetornaGolpe(gp.Nome));
        }
        else
        {
            fase = FasesDoPassouDeNivel.tentandoAprender;
        }
    }
}