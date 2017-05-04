using UnityEngine;
using System.Collections.Generic;

public static class TextosChaveEmPT_BR
{
    public static Dictionary<ChaveDeTexto, List<string>> txt = new Dictionary<ChaveDeTexto, List<string>>()
            {
                {ChaveDeTexto.bomDia, new List<string>()
                    {
                        "bom dia pra você",
                        "bom dia pra você",
                        "bom diaaaaaaaaaaa....",
                        "bom dia pra você"
                    }},
                {
                    ChaveDeTexto.apresentaInimigo,new List<string>()
                    {
                        "Você encontrou um <color=orange>{0}</color> Nivel {1} \n\r PV: {2} \t\t\t PE: {3}"
                    }
                },
                {
                    ChaveDeTexto.usoDeGolpe,new List<string>()
                    {
                    "Golpe em tempo de recarga. \r\n{0}\r\n até o próximo uso. ",
                    "Não há pontos de energia suficientes para esse golpe"
                    }
                },
                {
                    ChaveDeTexto.apresentaFim,new List<string>()
                    {
                        @"{0} venceu, pela vitória {0} recebeu {1} 
                        <color=#FFD700> pontos de experiencia.</color> 
                        e Cesar Corean recebeu {2} <color=#FF4500> CRISTAIS</color>"
                    }
                },
                {
                    ChaveDeTexto.apresentaDerrota,new List<string>()
                    {
                        "{0} foi derrotado",
                        "Qual criature sairá para continuar a batalha?"
                    }
                },
                {
                    ChaveDeTexto.criatureParaMostrador,new List<string>()
                    {
                        "Você tem certeza que quer colocar <color=orange>{0}</color> para continuar a luta?",
                        "O criature {0} não está em condições para entrar na luta"
                    }
                },
                {
                    ChaveDeTexto.passouDeNivel,new List<string>()
                    {
                        "{0} conseguiu alcançar o <color=yellow>nível {1}</color>"
                    }
                },
                {
                    ChaveDeTexto.naoPodeEssaAcao,new List<string>()
                    {
                        "<color=orange>Seu personagem não está em condições de realizar essa ação</color>",
                        "<color=orange>O Criature {0} já está em campo</color>",
                        "<color=orange>Selecione um item antes de clicar no botão usar</color>"
                    }
                },
                {
                    ChaveDeTexto.jogoPausado,new List<string>()
                    {
                        "Jogo Pausado"
                    }
                },
                {
                    ChaveDeTexto.selecioneParaOrganizar,new List<string>()
                    {
                        "Selecione o item para ser reposicionado",
                        "Selecione o item para trocar de posição com {0}"
                    }
                },
                {
                    ChaveDeTexto.emQuem,new List<string>()
                    {
                        "<color=yellow>Em qual criature você irá usar o item {0}</color>"
                    }
                },
                {
                    ChaveDeTexto.aprendeuGolpe,new List<string>()
                    {
                        "{0} aprendeu o ataque <color=yellow>{1}</color>"
                    }
                },
                {
                    ChaveDeTexto.tentandoAprenderGolpe,new List<string>()
                    {
                       "{0} está tentando aprender o ataque <color=yellow>{1}</color>, mas para isso precisa esquecer um ataque."
                    }
                },
                {
                    ChaveDeTexto.precisaEsquecer,new List<string>()
                    {
                        "Qual ataque {0} irá esquecer?"
                    }
                },
                {
                    ChaveDeTexto.certezaEsquecer,new List<string>()
                    {
                        "Você tem certeza que deseja esquecer o ataque <color=yellow>{0}</color> para aprender o ataque <color=yellow>{1}</color>??"
                    }
                },
                {
                    ChaveDeTexto.naoQueroAprenderEsse,new List<string>()
                    {
                        "<color=orange>{0}</color> deixará de aprender o golpe <color=yellow>{1}</color>. Você está certo disso?"
                    }
                },
                {
                    ChaveDeTexto.aprendeuGolpeEsquecendo,new List<string>()
                    {
                        "<color=orange>{0}</color> esqueceu <color=yellow>{1}</color> e aprendeu <color=yellow>{2}</color>"
                    }
                },
                {
                    ChaveDeTexto.foiParaArmagedom,new List<string>()
                    {
                        "A luva de Guarde de <color=yellow>Cesar Corean</color> só pode carregar {0} Criatures. Então <color=orange>{1}</color> nivel {2} foi enviado para o Armagedom"
                    }
                },
                {
                    ChaveDeTexto.primeiroArmagedom,new List<string>()
                    {
                        "Olá Estranho!!\n\r Aqui é o Armagedom de Infinity.",
                        "Nos Armagedom's espalhados por Orion você pode curar seus Criatures.",
                        " Além disso pode substituir os criatures ativos por criatures que estão na sua reserva.",
                        "No que posso te ajudar estranho?"
                    }
                },
                {ChaveDeTexto.simOuNao,new List<string>()
                    {
                        "Sim",
                        "Não"
                    }},
                {
                    ChaveDeTexto.frasesDeArmagedom,new List<string>()
                    {
                        "Seus criatures estão curados, estranho!!",
                        "Me desculpe estranho, mas parece que não há criatures teus guardados no armagedom",
                        "Seus Criatures Armagedados",
                        "O criature <color=orange>{0}</color> nivel {1} entrou para o seu time",
                        "Seu time já tem o número máximo de Criatures. Para colocar <color=orange>{0}</color> nivel {1} no time você precisa retirar um Criature do seu time",
                        "Qual Criature sairá do seu time?",
                        "O Criature {0} nivel {1} entrou no seu time no lugar do Criature {2} nivel {3}"
                    }
                }
            };
}