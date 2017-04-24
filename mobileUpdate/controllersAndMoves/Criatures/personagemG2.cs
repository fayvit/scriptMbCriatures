using UnityEngine;
using System.Collections.Generic;

public static class personagemG2
{
    public static CriatureBase RetornaUmCriature(nomesCriatures nome)
    {
        CriatureBase retorno;
        switch (nome)
        {
            case nomesCriatures.Xuash:
                retorno = XuashG2.Criature;
            break;
            case nomesCriatures.Florest:
                retorno = FlorestG2.Criature;
            break;
            case nomesCriatures.PolyCharm:
                retorno = PolyCharmG2.Criature;
            break;
            case nomesCriatures.Arpia:
                retorno = ArpiaG2.Criature;
            break;
            case nomesCriatures.Iruin:
                retorno = IruinG2.Criature;
            break;
            case nomesCriatures.Urkan:
                retorno = UrkanG2.Criature;
            break;
            default:
                retorno = new CriatureBase();
            break;
        }

        return retorno;
    }
    /*
    public static Dictionary<nomesCriatures, CriatureBase> Criatures = new Dictionary<nomesCriatures, CriatureBase>()
    { {
        nomesCriatures.Xuash,
        new CriatureBase()
        {
            NomeID = nomesCriatures.Xuash,
            CaracCriature = new CaracteristicasDeCriature()
            {
                meusTipos = new nomeTipos[1] { nomeTipos.Agua},
                distanciaFundamentadora = 0.01f,
                meusAtributos = {
                    PV = { Taxa = 0.19f,},
                    PE = { Taxa = 0.21f},
                    Ataque = { Taxa = 0.19f},
                    Defesa = { Taxa = 0.22f},
                    Poder = { Taxa = 0.19f}
                },
                contraTipos = tipos.AplicaContraTipos(nomeTipos.Agua)
            },
            GerenteDeGolpes = new GerenciadorDeGolpes()
            {
                listaDeGolpes = new List<GolpePersonagem>()
                {

                    new GolpePersonagem()
                    {
                        NivelDoGolpe = 1,
                        ModPersonagem = 0,
                        Colisor = new colisor("Arma__o/Tronco/pescoco/Cabeca/BocaD"),
                        Nome = nomesGolpes.rajadaDeAgua,
                        TaxaDeUso = 1,
                        DistanciaEmissora = 0.5f
                    },
                    new GolpePersonagem()
                    {
                        Nome = nomesGolpes.tapa,
                        NivelDoGolpe = 1,
                        Colisor = new colisor("Arma__o/Tronco/ombroD/BracoD1/BracoD2/punhoD",
                                          new Vector3(0,0,0),
                                          new Vector3(-0.26f,-0,0)),
                        TaxaDeUso = 0.5f
                    },new GolpePersonagem()
                    {
                        NivelDoGolpe = 2,
                        ModPersonagem = 0,
                        Colisor = new colisor("Arma__o/Tronco/pescoco/Cabeca/BocaD"),
                        Nome = nomesGolpes.turboDeAgua,
                        TaxaDeUso = 1.25f,
                        DistanciaEmissora = 0.5f
                    }
                }
            },
            Mov = new CaracteristicasDeMovimentacao()
            {
                velocidadeAndando = 5,
                caracPulo = new CaracteristicasDePulo()
                {
                    alturaDoPulo = 2f,
                    tempoMaxPulo = 1,
                    velocidadeSubindo = 5,
                    velocidadeDescendo = 20,
                    velocidadeDuranteOPulo = 4,
                    amortecimentoNaTransicaoDePulo = 1.2f
                }
            }
        }
        },//final do Xuash
        {
        nomesCriatures.FlorestR,
        new CriatureBase()
        {
            NomeID = nomesCriatures.FlorestR,
            alturaCamera = 4,
            distanciaCamera = 5.5f,
            alturaCameraLuta = 6,
            distanciaCameraLuta = 4.5f,
            CaracCriature = new CaracteristicasDeCriature()
            {
                meusTipos = new nomeTipos[1] { nomeTipos.Planta},
                distanciaFundamentadora = 0.2f,
                meusAtributos = {
                    PV = { Taxa = 0.195f,},
                    PE = { Taxa = 0.205f},
                    Ataque = { Taxa = 0.21f},
                    Defesa = { Taxa = 0.21f},
                    Poder = { Taxa = 0.18f}
                },
                contraTipos = tipos.AplicaContraTipos(nomeTipos.Planta)
            },
            GerenteDeGolpes = new GerenciadorDeGolpes()
            {
                listaDeGolpes = new List<GolpePersonagem>()
                {

                    new GolpePersonagem()
                    {
                        NivelDoGolpe = 1,
                        ModPersonagem = 0,
                        Colisor = new colisor("Arma__o/corpo"),
                        Nome = nomesGolpes.laminaDeFolha,
                        AcimaDoChao = 0.5f,
                        TaxaDeUso = 1,
                        DistanciaEmissora = 0.5f
                    },
                    new GolpePersonagem()
                    {
                        Nome = nomesGolpes.garra,
                        NivelDoGolpe = 1,
                        Colisor = new colisor("Arma__o/corpo/quadrilD/pernaD1/pernaD2/peD/",
                                          new Vector3(0,0,0.3f),
                                          new Vector3(0,0.48f,-0.62f)),
                        TaxaDeUso = 0.5f
                    }
                }
            },
            Mov = new CaracteristicasDeMovimentacao()
            {
                velocidadeAndando = 5,
                caracPulo = new CaracteristicasDePulo()
                {
                    alturaDoPulo = 2f,
                    tempoMaxPulo = 1,
                    velocidadeSubindo = 5,
                    velocidadeDescendo = 20,
                    velocidadeDuranteOPulo = 4,
                    amortecimentoNaTransicaoDePulo = 1.2f
                }
            }
        }
        },//final do FlorestR
        {
        nomesCriatures.PolyCharm,
        new CriatureBase()
        {
            NomeID = nomesCriatures.PolyCharm,
            alturaCamera = 4,
            distanciaCamera = 5.5f,
            alturaCameraLuta = 6,
            distanciaCameraLuta = 4.5f,
            CaracCriature = new CaracteristicasDeCriature()
            {
                meusTipos = new nomeTipos[1] { nomeTipos.Planta},
                distanciaFundamentadora = 0.2f,
                meusAtributos = {
                    PV = { Taxa = 0.195f,},
                    PE = { Taxa = 0.205f},
                    Ataque = { Taxa = 0.21f},
                    Defesa = { Taxa = 0.21f},
                    Poder = { Taxa = 0.18f}
                },
                contraTipos = tipos.AplicaContraTipos(nomeTipos.Planta)
            },
            GerenteDeGolpes = new GerenciadorDeGolpes()
            {
                listaDeGolpes = new List<GolpePersonagem>()
                {

                    new GolpePersonagem()
                    {
                        NivelDoGolpe = 1,
                        ModPersonagem = 0,
                        Colisor = new colisor("Arma__o/corpo"),
                        Nome = nomesGolpes.laminaDeFolha,
                        AcimaDoChao = 0.5f,
                        TaxaDeUso = 1,
                        DistanciaEmissora = 0.5f
                    },
                    new GolpePersonagem()
                    {
                        Nome = nomesGolpes.garra,
                        NivelDoGolpe = 1,
                        Colisor = new colisor("Arma__o/corpo/quadrilD/pernaD1/pernaD2/peD/",
                                          new Vector3(0,0,0.3f),
                                          new Vector3(0,0.48f,-0.62f)),
                        TaxaDeUso = 0.5f
                    }
                }
            },
            Mov = new CaracteristicasDeMovimentacao()
            {
                velocidadeAndando = 5,
                caracPulo = new CaracteristicasDePulo()
                {
                    alturaDoPulo = 2f,
                    tempoMaxPulo = 1,
                    velocidadeSubindo = 5,
                    velocidadeDescendo = 20,
                    velocidadeDuranteOPulo = 4,
                    amortecimentoNaTransicaoDePulo = 1.2f
                }
            }
        }
        },//final do PolyCharm
        {
        nomesCriatures.Florest,
        new CriatureBase()
        {
            NomeID = nomesCriatures.Florest,
            alturaCamera = 4,
            distanciaCamera = 5.5f,
            alturaCameraLuta = 6,
            distanciaCameraLuta = 4.5f,
            CaracCriature = new CaracteristicasDeCriature()
            {
                meusTipos = new nomeTipos[1] { nomeTipos.Planta},
                distanciaFundamentadora = 0.01f,
                meusAtributos = {
                    PV = { Taxa = 0.195f,},
                    PE = { Taxa = 0.205f},
                    Ataque = { Taxa = 0.21f},
                    Defesa = { Taxa = 0.21f},
                    Poder = { Taxa = 0.18f}
                },
                contraTipos = tipos.AplicaContraTipos(nomeTipos.Planta)
            },
            GerenteDeGolpes = new GerenciadorDeGolpes()
            {
                listaDeGolpes = new List<GolpePersonagem>()
                {

                    new GolpePersonagem()
                    {
                        NivelDoGolpe = 1,
                        ModPersonagem = 0,
                        Colisor = new colisor("Arma__o/corpo"),
                        Nome = nomesGolpes.laminaDeFolha,
                        AcimaDoChao = 0.5f,
                        TaxaDeUso = 1,
                        DistanciaEmissora = 0.5f
                    },
                    new GolpePersonagem()
                    {
                        Nome = nomesGolpes.garra,
                        NivelDoGolpe = 1,
                        Colisor = new colisor("Arma__o/corpo/quadrilD/pernaD1/pernaD2/peD/",
                                          new Vector3(0,0,0.3f),
                                          new Vector3(-0.33f,0.48f,-0.38f)),
                        TaxaDeUso = 0.5f
                    },
                    new GolpePersonagem()
                    {
                        Nome = nomesGolpes.furacaoDeFolhas,
                        NivelDoGolpe = 2,
                        Colisor = new colisor("Arma__o/corpo"),
                        DistanciaEmissora = 1f,
                        AcimaDoChao = 0.15f,
                        TaxaDeUso = 1.25f
                    }
                }
            },
            Mov = new CaracteristicasDeMovimentacao()
            {
                velocidadeAndando = 5,
                caracPulo = new CaracteristicasDePulo()
                {
                    alturaDoPulo = 2f,
                    tempoMaxPulo = 1,
                    velocidadeSubindo = 5,
                    velocidadeDescendo = 20,
                    velocidadeDuranteOPulo = 4,
                    amortecimentoNaTransicaoDePulo = 1.2f
                }
            }
        }
        }//Final do Florest
    };*/
}
