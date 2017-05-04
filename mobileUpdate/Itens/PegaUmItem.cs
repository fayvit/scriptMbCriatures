using UnityEngine;
using System.Collections;

public class PegaUmItem
{
    public static MbItens Retorna(nomeIDitem nomeItem, int estoque = 1)
    {
        MbItens retorno = new MbItens(new ContainerDeCaracteristicasDeItem());
        switch (nomeItem)
        {
            case nomeIDitem.maca:
                retorno = new MbMaca(estoque);
            break;
            case nomeIDitem.cartaLuva:
                retorno = new MbCartaLuva(estoque);
            break;
        }
        return retorno;
    }
}
