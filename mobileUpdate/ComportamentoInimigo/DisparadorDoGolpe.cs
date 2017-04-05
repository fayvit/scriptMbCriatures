using UnityEngine;
using System.Collections;

public class DisparadorDoGolpe
{

    public static bool Dispara(CriatureBase meuCriatureBase,GameObject gameObject)
    {
        Atributos A = meuCriatureBase.CaracCriature.meusAtributos;
        GerenciadorDeGolpes ggg = meuCriatureBase.GerenteDeGolpes;
        IGolpeBase gg = ggg.meusGolpes[ggg.golpeEscolhido];

        if (gg.UltimoUso + gg.TempoDeReuso < Time.time && A.PE.Corrente >= gg.CustoPE)
        {
            AplicadorDeGolpe aplG = gameObject.AddComponent<AplicadorDeGolpe>();
            A.PE.Corrente -= gg.CustoPE;
            gg.UltimoUso = Time.time;
            aplG.esseGolpe = gg;


            return true;
        }
        else
            return false;
    }
}
