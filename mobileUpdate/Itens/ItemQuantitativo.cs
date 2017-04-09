using UnityEngine;
using System.Collections;

public class ItemQuantitativo
{
    public static bool UsaItemDeRecuperacao(CriatureBase meuCriature)
    {
        if (meuCriature.CaracCriature.meusAtributos.PV.Corrente < meuCriature.CaracCriature.meusAtributos.PV.Maximo)
            return true;
        else
            return false;
    }

    public static void RecuperaPV(Atributos meusAtributos, int tanto)
    {
        int contador = meusAtributos.PV.Corrente;
        int maximo = meusAtributos.PV.Maximo;

        if (contador + tanto < maximo)
            meusAtributos.PV.Corrente += tanto;
        else
            meusAtributos.PV.Corrente = meusAtributos.PV.Maximo;
    }
}
