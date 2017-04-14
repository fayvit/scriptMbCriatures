using UnityEngine;
using System.Collections;

public class PegaUmItem
{
    public static MbItens Retorna(nomeIDitem nomeItem, int estoque)
    {
        MbItens retorno = new MbItens(new ContainerDeCaracteristicasDeItem());
        switch (nomeItem)
        {
            case nomeIDitem.maca:
                retorno = new MbMaca(estoque);
            break;
        }
        return retorno;
    }
}
