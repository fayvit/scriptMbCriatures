using UnityEngine;
using System.Collections;

public class PassouDeNivelEmLuta
{
    private float contadorDeTempo = 0;
    private CriatureBase oNivelado;
    private GolpePersonagem gp;
    private FasesDoPassouDeNivel fase = FasesDoPassouDeNivel.mostrandoNivel;

    private enum FasesDoPassouDeNivel
    {
        mostrandoNivel,
        aprendeuGolpe,
        tentandoAprender,
        painelAprendeuGolpeAberto
    }
    public PassouDeNivelEmLuta(CriatureBase oNivelado)
    {
        this.oNivelado = oNivelado;
        PainelMensCriature.p.AtivarNovaMens(
            string.Format(bancoDeTextos.RetornaTextoDoIdioma(ChaveDeTexto.passouDeNivel)[0],
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
                        oNivelado.NomeEmLinguas + " aprendeu o golpe <color=yellow>" + GolpeBase.NomeEmLinguas(gp.Nome) + "</color>", 20
                        );
                    fase = FasesDoPassouDeNivel.painelAprendeuGolpeAberto;
                }
            break;
            case FasesDoPassouDeNivel.painelAprendeuGolpeAberto:
                if (Input.GetMouseButtonDown(0))
                {
                    PainelMensCriature.p.EsconderMensagem();
                    return true;
                }
            break;
        }
        return false;
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

        }
    }
}