﻿public static class PegaUmGolpeG2
{

    public static GolpeBase RetornaGolpe(nomesGolpes nome)
    {
        GolpeBase retorno;
        switch (nome)
        {
            case nomesGolpes.rajadaDeAgua:
                retorno = new RajadaDeAguaG2();
            break;

            case nomesGolpes.tapa:
                retorno = new TapaG2();
            break;

            case nomesGolpes.laminaDeFolha:
                retorno = new LaminaDeFolhaG2();
            break;

            case nomesGolpes.garra:
                retorno = new GarraG2();
            break;


            default:
                retorno = new GolpeBase(new ContainerDeCaracteristicasDeGolpe());
            break;
        }
        return retorno;
    }
}