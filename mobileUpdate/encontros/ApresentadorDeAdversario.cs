using UnityEngine;
using System.Collections;

public class ApresentadorDeAdversario
{
    private bool foiApresentado = false;
    private bool painelAberto = false;
    private CreatureManager inimigo;

    public ApresentadorDeAdversario(CreatureManager inimigo)
    {
        this.inimigo = inimigo;
    }

    public bool Apresenta(float contadorDeTempo,AplicadorDeCamera cam)
    {
        if (contadorDeTempo > 0.5f)
            if (!foiApresentado)
            {
                cam.transform.position = (inimigo.transform.position + 8 * inimigo.transform.forward + 5 * Vector3.up);
                cam.transform.LookAt(inimigo.transform);
                cam.InicializaCameraExibicionista(inimigo.transform, inimigo.GetComponent<CharacterController>().height);
                foiApresentado = true;
            }
            else
            {
                
                //cam.transform.RotateAround(inimigo.transform.position, Vector3.up, 15 * Time.deltaTime);
                if (!painelAberto)
                {
                    painelAberto = true;
                   // bugDoNivel1();

                    iniciaApresentaInimigo();
                }
                else   if (Input.GetMouseButtonDown(0) || contadorDeTempo>10)
                {
                    PainelMensCriature.p.EsconderMensagem();
                    return true;
                }
            }

        return false;
    }

    protected virtual void iniciaApresentaInimigo()
    {
        CriatureBase C = inimigo.MeuCriatureBase;
        PainelMensCriature.p.AtivarNovaMens(
            string.Format(
            bancoDeTextos.falacoesComChave[heroi.linguaChave][ChaveDeTexto.apresentaInimigo][0],
            C.NomeID, C.G_XP.Nivel, C.CaracCriature.meusAtributos.PV.Corrente,
            C.CaracCriature.meusAtributos.PE.Corrente),30
            );
    }
}
