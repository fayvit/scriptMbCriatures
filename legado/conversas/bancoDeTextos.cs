using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bancoDeTextos{

    public static readonly Dictionary<idioma, Dictionary<ChaveDeTexto, List<string>>> falacoesComChave
    = new Dictionary<idioma, Dictionary<ChaveDeTexto, List<string>>>() {
        { idioma.pt_br,
            ListaDeTextosPT_BR.Txt
        }
    };

    public static readonly Dictionary<string,Dictionary<string,List<string>>> falacoes 
	= new Dictionary<string, Dictionary<string,List<string>>>()
		{
		{"pt-br",
			new Dictionary<string,List<string>>(){
				{"bomDia", new List<string>()
					{
						"bom dia pra você",
						"bom dia pra você",
						"bom diaaaaaaaaaaa....",
						"bom dia pra você"
					}},
				{"pagarOuNao",new List<string>()
					{
						"Eu pago para inicar a luta",
						"Talvez mais tarde"
					}},
				{"ive1",new List<string>()
					{
						"Se você seguir para oeste daqui você chegará ao <color=yellow>rio Mariinque.</color>",
						"Assim que você ultrapassar as montanhas logo verá a<color=yellow>Torre da Vida Eterna</color>",
						"No alto da torre fica o castelo do imperador",
						"Certeza que é lá que você quer ir?"
					}},
				{"ive2",new List<string>()
					{
						"Bem-vindo a cidade de <color=yellow>Ive</color>",
						"Nossa cidade sempre foi próspera devido a rota comercial que liga a cidade de <color=yellow>Afarenga</color> dentro do vulcão do outro lado do rio Mariinque,",
						"à cidade de <color=yellow>Ofawing</color> que fica além da ferrovida de <color=yellow>Jadme</color>.",
						"Mas parece que os ventos não sopram a favor da nossa cidade",
						"Alguns anos atrás <color=orange>Logan</color> mandou fechar a ferrovia de Jadme",
						"Isso reduziu o fluxo de viajantes, pois não poderiam mais chegar a Ofawing por essa rota",
						"E há pouco tempo um deslizamento fechou a entrada do vulcão que dava acesso a Afarenga",
						"Nossa rota comercial está indo de mal a pior."
					}},
				{"ive3",new List<string>()
					{
						"No meio do <color=yellow>rio Mariinque</color> existe uma plataforma de extração de petróleo.",
						"A <color=yellow>Petrolífera</color> é responsável pelo abastecimento de combustível de várias planícies de Orion",
						"Mas ultimamente eles atravessam sérios problemas.",
						"Alguns compartimentos da petrolífera foram tomados por Criatures <color=orange>Iziculos</color>.",
						"Iziculos são pequenos criatures insetos cortadores que gostam de viver em lugares úmidos e escuros",
						"carregam um bastão e com esse bastão podem aprender habilidades cortantes fortes o suficiente para cortar barras de aço",
						"Eu acho que a Petrolífera está em sérios apuros"
					}},
				{"ive4",new List<string>()
					{
						"Os esgotos que correm por baixo dessa planície são o abrigo de Criatures asquerosos.",
						"Viajantes que utilizaram a estrada leste da <color=yellow>Fortaleza</color> sempre tem histórias para contar sobre insetos que saiam das tubulações de esgoto por aqueles lados.",
						"Em vista desse problema, a administração pública da <color=yellow>Garra Governamental</color> colocou grades nos tubos de esgoto para os Criatures não sairem de lá",
						"Mas isso não resolveu completamente o problema",
						"Alguns criatures que carregam bastões pode utilizar a habilidade <color=cyan>Sabre de Bastão</color> e com ela cortar as barras de isolamento do esgoto",
						"A Garra Governamental está sempre repondo as grades do esgoto, mas de tempos em tempos aparece uma nova abertura provocada por Criatures."
					}},
				{"ive5",new List<string>()
					{
						"Atracado nas margens do <color=yellow>rio Mariinque</color> está o <color=yellow>Cruzador de Guerra </color>.",
						"O cruzador de guerra é um navio construido para defender o continente de Yoro das invasões dos outros continentes.",
						"Com o prolongar dos tempos de paz, o Cruzador se tornou pouco útil para questões de defesa territorial.",
						"Então os militares resolveram abrir o Cruzador para visitação por 100 CRISTAIS.",
						"Eles querem nos enganar dizendo que é para a população conhecer os aparelhos de segurança que nos protegem, mas eu acredito que estão mesmo é querendo ganhar uns trocos",
						"Possivelmente estão passando por uma crise financeira já que mantém um equipamento de guerra precisando de manutenção e praticamente sem utilidade."
					}},
				{"ive6",new List<string>()
					{
						"A tecnologia <color=cyan>Armagedom</color> foi criada a algumas décadas pelo próprio imperador <color=orange>Logan</color> quando ele era estudante da universidade no deserto da predominância.",
						"Com Armagedom's podemos transportar nossos itens de um Armagedom para outro nas várias sedes que estão espalhadas por Orion.",
						"Isso é fascinaste!!",
						"Tudo isso utilizando da energia única fornecida por um mineral bastante encontrado em Orion: as <color=cyan>gemas Laranges</color>.",
						"Depois de Logan, muitos cientistas trabalharam em aprimoramentos para Armagedom.",
						"A massa possível de ser transportada foi ampliada e o sistema de comunicação entre Armagedom's evoluiu muito desde Logan",
						"mas a maior contribuição da tecnologia Armagedom, sem sombra de duvidas, foi feita por um jovem cientista e atual milhonário: <color=orange>Jack Bandit</color>","a invenção dele foi, nada mais nada menos que, a <color=cyan>Luva de Guarde</color>.",
						"Com a luva de Guarde podemos carregar nossos itens dentro de uma Gema Larange posicionada em nossas luvas.",
						"E a coisa mais surpreendente das luvas de Guarde é a capacidade de carregar um certo número de Criatures vivos",
						"Não é à toa que todo mundo em Orion é obrigado a utilizar Luvas de Guarde"
					}},
				{"ive7",new List<string>()
					{
						"Se você seguir por entre as montanhas do leste você chegará até a cidade de <color=yellow>Hadjek</color>.",
						"Hadjek é passagem obrigatória para todos os viajantes que seguem o destino de <color=yellow>Jadme</color>.",
						"No deserto de Jadme existe uma pirâmide bastante curiosa. Dizem os mais velhos que ela é na verdade um templo para <color=cyan>Turabá</color>, o deus dos Mistérios.",
						"O <color=orange>capitão Aramis</color> foi enviando numa missão dentro da pirâmide.",
						"Eu desconfio que ele está procurando algum sacerdote de Turabá lá dentro. Seria a busca da revelação sobre o mistério do comportamento atípico do imperador?"
					}},
				{"ive8",new List<string>()
					{
						"No fundo do rio Mariinque os clérigos de <color=cyan>Drag</color> construiram uma arena para o deus das águas.",
						"O responsável pela <color=yellow>arena de Drag</color> é <color=orange>Omar Water</color>.",
						"Dizem as lendas de Orion, que após o desvio do curso do rio Mariinque para a construção da represa, Drag invocou seus seguidores para a construção de monumentos no fundo do rio.",
						"Pela vontade de Drag, o novo rio, o rio desviado de seu curso, se tornou mais profundo e mais largo que o anterior.",
						"Algumas gerações passaram desde o acontecido e então Omar chegou para ficar a frente da arena",
						"Dizem que ele e sua esposa ouviram a própria voz de Drag lhes delegando a responsabilidade de reger a arena do Rio Mariinque ",
						"Eu sou muito cética com relação a religiões, acredito que essas histórias só reforçam o mito dos deuses para manter seus seguidores."
					}},
				{"ive9",new List<string>()
					{
						"O caminho para o castelo do imperador, a <color=yellow>Torre da Vida Eterna</color>, é fechada pelo acordo dos deus de Orion em proteger o imperador que é o responsável por levar seu povo a prosperidade",
						"No entando, os deuses não deram ao imperador uma proteção inabalável",
						"Pela vontade dos deuses, um cidadão de Orion que possuir oito dos medalhões dos deuses pode abrir os portões da Torre da Vida Eterna e subir a torre para encontrar com o imperador",
						"Para ganhar os medalhões dos deuses só existe uma maneira: Procurar as arenas dos deuses e desafiar seus regentes para uma luta entre Criatures",
						"Vencendo um regente de arena, na arena de um deus, você pode ganhar o medalhão desse Deus.",
						"Os deuses deram essa possibilidade para que um cidadão digno pudesse destituir um imperador não digno",
						"Mas eu acho que eles esqueceram da parte que o imperador lidera um exercito!!"
					}},
				{"ive10",new List<string>()
					{
						"A <color=yellow>Represa</color> que fica a leste da cidade de <color=yellow>Infinity</color> é responsável pelo abastecimento de água da maioria das planícies de Orion, ela abastece todas as planícies de Yoro.",
						"No rio Mariinque, existe uma grande <color=yellow>tubulação</color> fechada por um registro. Esses tubos se prolongam muito por Orion.",
						"Talvez por dentro das tubulações você consiga chegar a planícies que não são acessíveis viajando por terra.",
						"O controle dos registros das tubulações de Orion ficam na sede da <color=yellow>Garra Governamental</color>."
					}},
				{"ive11",new List<string>()
				{
					"O caminho para a cidade de <color=yellow>Afarenga</color> foi obstruído por um deslizamento de terra há algum tempo.",
					"O exercito do imperador <color=orange>Logan</color> em conjunto com as seções de serviços públicos da <color=yellow>Garra Governamental</color> estão se mobilizando para desobstruir o caminho",
					"De acordo com as noticias que correm em Orion, o general <color=orange>Potus Ramos</color> da Fortaleza Stealer já tem a disposição dele uma quantidade de explosivos suficiente para a realizar a tarefa",
					"O que impede o serviço é um impasse entre as entidades imperialistas de Orion, o exército liderado por Ramos espera mão de obra da Garra Governamental e a Garra Governamental espera que a mão de obra seja aplicada pelo exercito",
					"Como o material está com o General Ramos, talvez ele só precise delegar essa função a alguém de confiança",
					"Você não quer se candidatar?"
				}},
				{"ive12",new List<string>()
				{
					" A história da construção da <color=yellow>fortaleza Stealer </color> é uma história muito antiga e que passa de geração para geração.",
					" Por isso muitas versões tem informações que se desencontram.",
					" Os mais velhos contam que o nome da fortaleza \" Stealer\" é em homenagem ao Criature de mesmo nome,",
					" pois a floresta em volta da fortaleza era cheia desses Criatures",
					" Porém, os Stealer\'s lançavam Relampagos contra os viajantes que atravessavam a floresta",
					" Por esse motivo, desde a construção da fortaleza passando pelo tempo de atividade militar dela, Stealers foram caçados e exterminados.",
					"Hoje não existem mais Stealers na floresta da fortaleza.",
					"Curioso que o Criature que deu nome a fortaleza foi exterminado justamente por causa da existencia da fortaleza",
					"Algumas pessoas dizem ter visto Criatures Eletricos na floresta da Fortaleza, mas a maioria das pessoas não acreditam nesses boatos",
					"As pessoas que repetem isso normalmente ganham fama de mentirosas."
				}},
				{"armagedomDeInfinity",new List<string>()
				{
					"Olá estranho!!\r\n Bem vindo ao Armagedom de Infinity.\r\n No que posso te ajudar?",
					"Não há nenhum Criature seu guardado no Armagedom no momento."
				}},
				{"opcoesDeArmagedom1",new List<string>()
				{
					"Curar Criatures","Seus Criatures no Armagedom","Cancela"
				}},
				{"falasDeArmagedom",new List<string>()
				{
					" Você retirou <color=yellow>",
					"</color> Nível: ",
					" do seu grupo de Criature e inseriu <color=yellow>"
				}},
				{"Shop1",new List<string>()
				{
					"Olá Estranho!! Eu tenho excelentes mercadorias para você",
					"Muito obrigado por sua visita e volte sempre à nossa loja.",
					"<color=red>OPS!!</color>\r\n Você não tem dinheiro suficiente para comprar esse item",
					"Ao observar pela forma como você está vestido, acredito que você não se interessaria por esse item.",
					"Insisto! Esse item não é para você. Espero que não me questione mais",
					"Ja te disse... Esse item não é para você",
					"Rapaz... Você é insistente ein... Tudo bem, se você quer tanto assim pode leva-lo",
					"Cesar Corean recebe a <color=cyan>Estatua Misteriosa</color>",
					"Excelente compra!! Estranho.\r\n Gostaria de levar mais alguma coisa estranho?"
				}},
				{"hospital",new List<string>()
				{
					"Olá Estranho!! Eu posso curar os seus Criatures feridos.\r\n Você gostaria de cura-los por ",
					" Cristais",
					"Você não tem Cristais suficiente no momento. Mas não se preocupe estaremos aqui prontos para cumprir o juramento médico assim que você conseguir a quantia necessária",
					"Ao que me parece a saúde de seus Criatures está perfeita. Você está de parabéns pelo bom trabalho em cuidar de seus Criatures",
					"Espero ve-lo novamente, estranho!!"
				}},
				{"igreja",new List<string>()
				{
					"Olá Estranho!! Eu posso fazer uma garrafada arretada que pode acordar seus Criatures desmaiados.\r\n Gostaria de aplicar em algum de seus Criatures??",
					" O Criature que tu me apontaste não está desmaiado. Ele não precisa de uma garrafada para despertar",
					"A garrafada para esse Criature custa ",
					" Cristais",
					"Espero ve-lo novamente, estranho!!",
					"Se tu não tens recursos terá de consegui-los para me pagar",
					"O seu Criature ",
					" está acordado e com ",
					" pontos de Vida"
				}},
				{"mensLuta",new List<string>()
				{
					"Você não pode usar esse item nesse momento.",
					"Cesar Corean usa ",
					"{0} não precisa usar esse item nesse momento"
				}},
				{"encontros",new List<string>()
				{
					"Qual Criature saira para continuar a batalha?",
					" foi derrotado ",
					" esta desmaiado e  não pode continuar a luta",
					"Todos os Criatures de Cesar Corean foram derrotados. \r\n\r\n Cesar Corean deve agora retornar ao Armagedom para renovar as energias de seus Criatures e voltar para sua aventura",
					"<color=red>OPS!</color> \r\n Você não tem PE suficiente."
				}},
				{"encontrosTreinador",new List<string>()
				{
					"Nessa luta eu irei usar {0} Criatures",
					"meu primeiro Criature será...",
					"meu proximo Criature será..."
				}},
				{"tentaCapturar",new List<string>()
				{
					" resistiu a tentativa de Captura.",
					"A luva de guarde de Cesar Corean so pode carregar ",
					"Então: ",
					" Nível ",
					"foi enviado para o ",
					"Cesar Corean conseguiu capturar um "
				}},
				{"menuPausa",new List<string>()
				{"Retornar ao Jogo",
				 "Botões",
				 "Voltar ao Título",
				 "Fechar o Jogo"
				}},
				{"semHadjek",new List<string>()
				{
					"Esse é o caminho para a cidade de <color=yellow>Hadjek</color>",
					"Porém, nessa versão ALPHA esse mapa ainda não foi implementado"
				}},
				{"semMariinque",new List<string>()
				{
					"Esse é o caminho para o <color=yellow>Rio Mariinque</color>",
					"Porém, nessa versão ALPHA esse mapa ainda não foi implementado"
				}},
				{"entradinha",new List<string>()
				{
					"Então... . É você que veio juntar-se a  nós?",
					"Sinto que há algo errado com o rumo que as coisas estão tomando e isso não me deixa em paz para seguir o rumo natural da minha vida.",
					"Por isso decidi me juntar a vocês",
					"Nós estamos tentando abrir a <color=yellow>Torre da Vida Eterna</color> e encarar <color=orange>Logan</color> para mudar o destino de Orion",
					"O caminho para isso é muito longo e muito difícil, você precisa de muita determinação para percorrer todo o caminho",
					"Nós estamos apenas no meio do caminho um tanto quanto sem rumo mas já temos algumas lições para tirar da nossa trajetória.",
					"Rapaz, todos os que querem fazer uma tarefa difícil tem um começo.\r\n E só quem já está no meio do caminho sabe como é dificil começar.",
					"Por isso vamos te ajudar",
					"Vou te indicar o caminho do <color=yellow>Armagedom de Infinity</color>, lá você poderá pegar um CRIATURE e iniciar sua jornada"
				}},
				{"apresentaFim",new List<string>()
				{
					" venceu!!",
					" pela vitoria ",
					" recebeu",
					"<color=#FFD700> pontos de experiencia.</color>",
					"e",
					" recebeu ",
					"<color=#FF4500> CRISTAIS</color>",
					" conseguiu ",
					"alcançar o ",
					"<color=yellow> Nivel ",
					"</color>",
					" aprendeu:",
					"Tempo de Reuso: ",
					"s\r\n Ataque Basico: ",
					"\r\n Custo de PE: ",
					" pode Aprender:",
					" <color=orange>Para isso deve esquecer um ataque!!</color> "
				}},
				{"encontrosScript",new List<string>()
				{
					" <color=orange>Não aprender</color> ",
					"Qual Golpe {0} esquecerá para aprender <color=yellow>{1}</color>",
					" esqueceu ",
					" não aprendeu ",
					" O Criature {0} deixou <color=cyan>{1}</color>"
				}},
				{"Hadjek1",new List<string>()
				{
					"Hoje os mais jovens reclamam que a mão do imperador está ficando cada vez mais pesada",
					"Dizem que o imperador está numa fase de restrições dos direitos individuais",
					"Dizem que muitos são presos e/ou agredidos pelos guardas imperiais",
					"Eu acredito que quem está sendo preso ou apanhando é porque é vagabundo mesmo",
					"Vejam só...\r\n Eu que sou um homem de bem não tenho nada do que me queixar sobre império de <color=orange>Logan</color> e da ação da <color=orange>Garra Governamental</color>",
					"Eu sou dono de alguns imóveis que estão alugados e com o dinheiro do aluguel pago os impostos e levo minha vida modesta",
					"Quem apanhou dos soldados do império é porque é vagabundo e quer viver sem trabalhar",
					"Eu quero mais é que o império de Logan dure por mais longos anos e esses revolucionarioszinhos sustentados por mamãe vão parar no presidio de <color=yellow>Cyzor</color>"
				}},
				{"Hadjek2",new List<string>()
				{
					"Bem-Vindo a cidade de <color=yellow>Hadjek</color> forasteiro!!",
					"Até bem pouco tempo, nós recebiamos turistas e estudiosos que vinham conhecer nossa água.",
					"As historias que passam de geração para geração é que nossas aguas tem propriedades medicinais porque são uma benção dada por <color=cyan>Ananda</color> Deusa da pureza e das vírtudes humanas",
					"Nenhum cientista que viajou da universidade no deserto da Predôminancia até aqui conseguiu concluir nada sobre a agua de Hadjek",
					"Todos eles sempre concluem que nossa água é comum, igual a água de qualquer Oasis no deserto",
					"Mas cientistas são céticos e talvez por isso não consigam aceitar a grandeza que é a benção de um Deus sobre a vida das pessoas menos afortunadas."
				}},
				{"Hadjek3",new List<string>()
				{
					"Tenho muito medo de seguir para o Norte",
					"O caminho entre a cidade de <color=yellow>Hadjek</color> e a cidade de <color=yellow>Jadme</color> se tornou um lugar perigoso",
					"Alguns bandidos que fugiram dos trabalhos forçados nas minas de <color=yellow>AxeOdion</color> encontraram esconderijos entre as montanhas do deserto",
					"Suspeita-se que reunem-se no esgoto",
					"Esse grupo de criminosos se auto proclama <color=orange>Tatus Peçonhentos</color> e costumam abordar viajantes no caminho de Jadme",
					"Se for para o Norte tome muito cuidado"
				}},
				{"Hadjek4",new List<string>()
				{
					"A norte daqui existe uma grande <color=yellow>Piramide.</color> Alguns mais idosos dizem que é um Templo para <color=cyan>Turabá</color> o Deus dos Mistérios",
					"Porém, poucos tentam entrar na piramide por causa das armadilhas e dos cachorros mumia",
					"Sim!! Cachorros mumia, eu não estou brincando com você! Sou uma pessoa muito séria",
					"Na verdade eles são Criatures do tipo gás.",
					"Nesses últimos anos com o surto de agressividade dos Criatures, eles começaram a sair da pirâmide e atacar viajantes que passam próximos",
					"Tenho medo deles, mumias me lembram morte e morte me lembra fantasmas. Não quero ser uma pessoa assombradas por entidades de outros mundos."
				}},
				{"Hadjek5",new List<string>()
				{
					"Sempre fui um grande devoto dos deuses de Orion e admiro muito <color=cyan>Turabá</color> o deus dos mistérios",
					"Quando viajo para <color=yellow>Jadme</color> sempre desvio um pouco a minha rota para a <color=yellow>Piramide</color> para orar em honra a Turabá",
					"Nunca entrei na piramide, sempre tive vontade de encontrar o sacerdote de Turabá que vive lá dentro",
					"Você deve estar se perguntando por que eu nunca entrei lá, e a verdade é, eu nunca achei que escaparia das armadilhas da piramide sem me ferir",
					"Sempre tive medo até de morrer no percurso. Com esse medo a idade foi chegando e agora mesmo que tenha vontade não tenho mais energia para encarar os desafios da piramide",
					"E existe mais uma complicação: A porta da piramide sempre esteve aberta e convidativa para quem quisesse adentra-la",
					"mas nas últimas viagens que fiz até lá a porta estava fechada",
					"além disso a estatua que ficava na frente da porta da piramide desapareceu, dizem que foi obra dos <color=orange>Tatus Peçonhentos</color>.",
					"Parece que a estatua foi roubada e vendida para um mercador mercenário de <color=yellow>Jadme</color>",
					"Hoje em dia se faz tudo por dinheiro não é?",
					"Eu gostaria de ver novamente a estatua na frente da piramide....\r\n Espero que consiga... "
				}},
				{"Hadjek6",new List<string>()
				{
					"Eu conheci pessoalmente o capitão <color=orange>Atos Aramis</color>. E te digo uma coisa rapaz:",
					"Posso ter sido uma das últimas pessoas que o viu",
					"Ele foi enviado numa missão ultrasecreta dentro da piramide e passou por aqui a caminho de lá",
					"Eu o vi partir de <color=yellow>Hadjek</color>, ele rumou para a piramide, já fazem vários dias. Desde então, ninguém mais o viu",
					"Não quero ser agoro de ninguém, mas...",
					"Todos já pensam no pior",
					"Eu sei que uma curiosidade lhe corroi.\r\n Eu sei porque também me corroeria.\r\n Somos humanos e sucestiveis a curiosidades não é?",
					"A duvida que pode lhe deixar aflito é: Qual era a missão ultrasecreta que levou Atos Aramis até a piramide?",
					"Hora... É ultrasecreta... ninguém deve saber!!",
					"Pois bem...\r\n Eu sei!!",
					"Tudo bem vou te contar. \r\n Ele me contou antes de partir na direção da piramide",
					"Mas te peço uma coisa ein...\r\n Não conte para mais ninguém!",
					"É o seguinte... \r\n Os militares já desconfiam da sanidade do imperador",
					"Sim... da sanidade!! Tanto o exercito quanto a <color=orange>Garra Governamental</color> tem recebido ordens estranhas do imperador",
					"A obcessão do imperador por <color=cyan>Gemas Laranjes</color> preocupa muito as entidades imperialistas",
					"Então... Atos Aramis foi tentar encontrar o Sacerdote dos mistérios para que todos tenham uma luz nos caminhos de Orion",
					"Aparentemente, os militares vão tentar tomar o poder caso sejam convencidos da insanidade do imperador",
					"Isso me assusta!! Não asusta você?"
				}},
				{"Hadjek7",new List<string>()
				{
					"Estou vendo que você está se aventurando a ser um treinador de Criatures",
					"Como bom treinador que você deve ser já deve saber que alguns tipos de Criatures são mais fortes lutando contra um tipo especifico",
					"Se você vai segui viagem pelo deserto é bom saber que os tipos água e planta são fortes contra os tipos pedra e terra",
					"outra coisa importante que você deve saber é que água é forte contra veneno",
					" e veneno é forte contra voadores e insetos.",
					" guarde bem essas informações, com certeza elas lhe serão úteis!!"
				}},
				{"Hadjek8",new List<string>()
				{
					"Pelos Deuses!!! Você veio cobrar os impostos de novo!!",
					"Não eu não vim, não sou um cobrador de impostos",
					"Você não devia dar esse susto nas pessoas! Você não deveria sair abordando as pessoas vestido desse jeito.",
					"Só essa sua roupa me causa calafrios.",
					"Estamos sendo muito abusados pelos impostos do império.\r\n Eu não entendo por que quem tem mais do que precisa ter quase sempre se convence que não tem o bastante",
					"Essa semana dois foram levados pelo império. Não puderam mais pagar os altos impostos para os imperialistas.",
					"Foram transformados em mão de obra para as minerações de <color=yellow>AxeOdion</color>.\r\n Esse é o destino de quem não pode pagar:  Tornar-se mão de obra escrava para essa obcessão por <color=cyan>Gemas Laranges</color>",
					"E se você continuar andando por ai vestido desse jeito vai acabar indo para lá também"
				}},
				{"Hadjek9",new List<string>()
				{
					"Você já andou de trem?",
					"É muito bom andar de trem.\r\n Podemos assistir o mundo passando pela janela do trem",
					"É quase como se assistissimos uma programação de televisão",
					"É uma pena que a televisão ainda tenha melhores programas que o mundo real passando na janela do trem.",
					"Em <color=yellow>Jadme</color> existe uma ferrovia que liga a cidade até o deserto de <color=yellow>Ofawing</color>.",
					"No deserto de Ofawing fica o prédio <color=yellow>sede da Garra Governamental</color>.",
					"Talvez você queira fazer uma viagem de trem para visitar a Garra Governamental"
				}},
				{"Hadjek10",new List<string>()
				{
					"O prefeito da cidade de <color=yellow>Jadme</color> é um politico muito habilidoso e um dos poucos líderes institucionais que é conhecidamente hostil aos imperialistas",
					"O prefeito de Jadme tem ideias muito assustadoras que incluem acabar com o império.",
					"Em Orion nós sempre vivemos sobre o regime imperialista. O imperador sempre foi o responsável por dar a última palavra nas decisões que envolviam uma grande parcela da população",
					"Não consigo imaginar uma forma de organização social que não seja a imperialista.",
					"O prefeito de Jadme diz que o ideal era que o líder máximo de um continente, estado, principado, país ou até cidade fosse colocado em votação para aprovação da população.",
					"Diz também que as pessoas deveriam escolher seus líderes de tempos em tempos.",
					"Eu acho isso absurdo! O império sempre esteve ai cuidando da Yoro de Orion. É assim que nascemos conhecendo o mundo, isso não pode ser mudado assim de uma hora pra outra",
					"Os apoiadores dessa ideia a chamam de Democracia.\r\n Eu não consigo imaginar um mundo organizado dessa forma."
				}},
				{"Hadjek11",new List<string>()
				{
					"O imperador mandou fechar a <color=yellow>ferrovia de Jadme</color> já faz algum tempo",
					"Isso mudou a rotina das cidades que ficam nessa região de Orion",
					"Muitos empregos eram mantidos pela funcionalidade da ferrovia",
					"Depois de fechada a ferrovia, muitas pessoas ficaram sem trabalhar, outras, como é o caso dos comerciantes, tiveram sua remuneração reduzida pela queda no fluxo de clientes.",
					"Isso trouxe muita tristeza e depressão para os trabalhadores, principalmente os de Jadme e especialmente um trabalhador",
					"<color=orange>Salmo Sadol</color> !!\r\n Ele era o maquinista do trem que fazia a rota Jadme / Ofawing",
					"Depois do fim de seu emprego como maquinista, teve dificuldades pra encontrar outra ocupação. Com o agravamento das dívidas, ele se entregou a bebedeira e sua esposa o abandonou.",
					"Dizem que ela mudou para a casa de parentes numa cidade  ao Norte do vulcão com seu filho pequeno.",
					"Hoje Salmo Sadol é sempre encontrado caido bebado em algum canto da cidade de Jadme. As pessoas que o conhecem dizem que ficou louco e não fala mais coisa com coisa",
					"História triste não?"
				}},
				{"Hadjek12",new List<string>()
				{
					"Em Orion, os responsáveis por escrever os pergaminhos mágicos vendidos nos Shopings são os sacerdotes de <color=cyan>Log</color>",
					"Log, é o deus do conhecimento e da sabedoria. Durante toda uma era de ouro, seus sacerdotes eram muito respeitados e admirados em Orion",
					"Ainda hoje é parecido, mas ... \r\n as vendas de pergaminhos trazem  a desconfiança das pessoas sobre os sacerdotes de Log.",
					"Na verdade... \r\n Ao sacerdote de Log",
					"<color=orange>Baltasar Gladist</color> é o último sacerdote em atividade do deus Log",
					"Os sacerdotes de Log normalmente são muito idosos e nesses últimos anos, a maioria deles veio a falecer.",
					"Milenarmente eles passam de geração para geração a arte de escrever os pergaminhos que podem ser utilizados em conjunto com os Criatures,",
					"mas foi Baltazar quem tornou a venda de pergaminhos um grande negocio rentável impulsionado pela popularização das luvas de Guarde",
					"Curiosamente Baltazar é relativamente jovem em relação aos outros clérigos de Log",
					"Ele aparenta ter por volta de 35~40 anos.",
					"Dizem que ele vive numa luxuosa mansão próxima da cidade de <color=yellow>Cyzor</color>.",
					"Não me parece atitude digna de um sacerdote sagrado se entregar as tentações da riqueza. O que você acha?"
				}},
				{"Hadjek13",new List<string>()
				{
					"<color=orange>Guto Jander</color> é o prefeito da cidade que fica do outro lado do deserto,<color=yellow>Jadme</color>",
					"Sujeitinho Sórdido",
					"Ele está encabeçando um movimento de desestabilizações do nosso amado império liderado por <color=orange>Logan</color>",
					"Na minha luva de guarde recebi várias reportagens falando de ideias que pretendem arruinar o nosso modo de viver em Orion",
					"Eles chamam essa ideia de democracia, dizem que o povo deve estar no poder para decidir por ele mesmo qual caminho tomar",
					"Mas na verdade, o que eles não dizem é que esses lideres nessa chamada democracia serão eles mesmos",
					"O atual prefeito de Jadme pretende acender ao poder ele mesmo e os seus",
					"Hipócritas de uma figa!!"
				}},
				{"prefeitoDeJadme",new List<string>()
				{
					"Seja muito bem vindo a cidade de Jadme estranho!! Meu nome é <color= orange>Guto Jander </color> sou o prefeito da cidade",
					"Olá... Eu sou <color=cyan>Cesar Corean</color>, nas cidades em que passei falam muito de você",
					" Imagino que sim ... Sou um dos poucos líderes em Orion que aponta uma alternativa ao império de <color=orange>Logan</color>",
					" Por causa das minhas ideias de democracia o império e seus simpatizantes colocam toda a maquina de propaganda que tem a disposição para tentar destruir a  minha imagem politica.",
					" Mas a queda do império é inevitável",
					" Eles podem até esmagar uma flor, mas jamais poderão deter a primavera"
				}},
				{"prefeitoDeJadme2",new List<string>()
				{
					" Por causa das minhas ideias de democracia o império e seus simpatizantes colocam toda a maquina de propaganda que tem a disposição para tentar destruir a  minha imagem politica.",
					" Mas a queda do império é inevitável",
					" Eles podem até esmagar uma flor, mas jamais poderão deter a primavera"
				}},
				{"perguntasParaOPrefeito",new List<string>()
				{
					" Por que você está contra o império?",
					" Como você se tornou um líder politico tão notável em Orion?",
					" O que é a maquina de propaganda do império?",
					" O que é a democracia?",
					" Eu posso me juntar a vocês?",
					" <color=orange>Terminar a conversa</color>"
				}},
				{"oPorQueDeJander",new List<string>()
				{
					" Moro em Jadme desde jovem... \r\n Ví o fechamento da ferrovia e o desespero dos desempregados",
					" Depois de um tempo os desempregados foram levados para se tornarem mão de obra escrava nas minas de <color=yellow>AxeOdion</color>",
					" Meus pais foram levados...",
					" Depois de um tempo eu soube do acidente... ",
					" Um desmoronamento matou um grupo de trabalhadores nas minas do imperador",
					" Meus pais estavam entre eles",
					" Desde então trabalhei entre as pessoas de Jadme para mudar a nossa realidade",
					" E mudar a nossa realidade é mudar tudo o que o império de Logan representa. Ou seja, precisamos inicialmente derrubar o império"
				}},
				{"liderNotavel",new List<string>()
				{
					" Agradeço pelo adjetivo de notável.",
					" O fato do meu nome ser conhecido em Orion se deve principalmente à minha objeção ao império de <color=orange>Logan</color>",
					" Na maioria das cidades deste continente os prefeitos são indicados pelo imperador.",
					" Apenas em algumas cidades a população vota para dar reconhecimento ao prefeito que geralmente não tem candidato de oposição",
					" Isso acontecia em Jadme também",
					" Mas a insatisfação das pessoas de Jadme com o império, principalmente pelo fechamento da ferrovia fez com que o aparecimento de uma oposição fosse natural",
					" Então eu assumi esse destino que foi imposto a minha frente, me candidatei e venci as eleições para prefeito",
					" Desde então tenho mostrado resistencia aos impostos abusivos e novas prisões para a escravidão",
					" E o que mais preocupa o Imperador são as ideias de democracia"
				}},
				{"maquinaDePropaganda",new List<string>()
				{
					"A maquina de propaganda do império é a forma como o imperador controla a opinião pública",
					" As <color=cyan>Luvas de Guarde</color> que eu e você usamos nesse momento se tornaram itens de uso obrigatorio, primeiro em Yoro e depois em toda a Orion",
					" Elas tem muitas utilidades como você deve saber. Uma dessas é transmitir informações editadas por canais autorizados",
					" O imperador é quem cede autorização para que informações sejam transmitidas",
					" A consequencia disso é que as informações são sempre transmitidas para serem favoráveis ao império",
					" Isso acontece tanto nas regiões dominadas por Logan, quanto nas que estão além de Yoro",
					" O controle da informação faz com que as revoltas contra as injustiças sejam entendidas como terrorismo ou baderna",
					" Se você não tomar cuidado com as informações que chegam a sua luva de Guarde...",
					" ...a sua luva de Guarde fará você amar os opressores e odiar os oprimidos"
				}},
				{"democraciaDeJander",new List<string>()
				{
					" Democracia é uma palavra que etimologicamente quer dizer poder ao povo",
					" Nossa corrente democratica quer o fim do império e que as intituições públicas/governamentais sejam coordenadas por comites populares",
					" O próprio povo a frente da administração de todo o coletivo",
					" Queremos o fim do poder centralizado e o fim de um império, país ou nação impondo-se sobre todo e qualquer povo",
					" Não podemos mais continuar sendo escravos dos imperialistas e aceitar isso como se não houvesse alternativa",
					" Temos que ser uma alternativa para nossos próprios destinos. E as ideias de democracia são essa alternativa."
				}},
				{"possoMeJuntarAJander",new List<string>()
				{
					" Se você treme de indignação perante uma injustiça no mundo, então somos companheiros",
					" O seu caminho tem uma direção voltada ao confronto e o movimento democrata está numa rota politica organizada",
					" Chegará uma hora que nossos caminhos irão se juntar para derrotar Logan.",
					" Por enquanto seu objetivo é juntar oito dos medalhões dos deuses, abrir a torre da vida eterna e derrotar Logan.",
					" Nós lhe daremos todo o apoio politico que precisar."
				}},
				{"Jadme1",new List<string>()
				{
					"Seja muito bem vindo a cidade de <color=yellow>Jadme</color>.",
					"Eu amo muito essa cidade! \r\n E poderia amar mais se não fosse um bebado vagabundo que fica se esgueirando na parte escura da cidade",
					"Tem um desocupado que me incomoda muito, ele se chama <color=orange>Salmo Sadol</color> era o maquinista do trem que levava a <color=yellow>Ofawing</color>.",
					"Depois da desativação da ferrovia algum tempo atrás ele não quis mais saber de trabalhar",
					"Esse tipo de gente me da nojo!!"
				}},
				{"Jadme2",new List<string>()
				{
					"Depois de atravessar o <color=yellow>Rio Mariinque</color> você pode encontrar a entrada do vulcão que é o caminho para a cidade de <color=yellow>Afarenga</color>",
					"Dentro do vulcão, ao norte de Afarenga, existe uma grande <color=yellow>Carvoaria</color>",
					"Nós de Jadme tinhamos muitas relações comerciais com o pessoal da carvoaria",
					"Foi uma lástima o fechamento da ferrovia."
				}},
				{"Jadme3",new List<string>()
				{
					"Ao norte de <color=yellow>Afarenga</color>, a cidade do vulcão, existe um curioso caminho de pontes que formam uma especie de Labirinto",
					"Esse caminho de pontes é conhecido por muitos como <color=yellow>O Segredo dos Sóis</color>",
					"Esse nome é devido a um mecanismo que pode mudar a direção para onde algumas pontes estão apontando. A chave que dispara esse mecanismo tem o formato de um Sol.",
					"O Segredo dos Sóis é o caminho para a <color=cyan>Arena de Laurense</color> o deus da força e da coragem",
					"Na Arena de Laurense você pode ganhar o medalhão da forja que representa o Deus da força."
				}},
				{"Jadme4",new List<string>()
				{
					"<color=orange>Guto Jander</color> é um heroi para nós de <color=yellow>Jadme</color>. \r\n Ele assumiu a cidade numa época muito conturbada, com vários problemas causados pelo fechamento da ferrovia",
					"Ele parecia um iluminado. Com seu discurso feroz contra o império e a proposta de cada povo ser o senhor de seu destino",
					"Eu adimiro muito o prefeito de Jadme e sua teoria da Democracia"
				}},
				{"Jadme5",new List<string>()
				{
					"Tem um sujeitinho meio pirado da cabeça que costumar dormir embaixo do viaduto do trem",
					"Eu sou novo na cidade, mas os mais velhos dizem que ele ficou louco depois que a esposa o abandonou",
					"Ele está sempre jogado em algum canto da cidade mesmo ele tendo uma casa por aqui.",
					"Tentei conversar com ele uma vez, mas ele não fala coisa com coisa.",
					"Começa a misturar histórias de trêm com alienigenas. É uma pena... ",
					"Um pobre homem, jovém e cheio de energia, assim afastado das suas capacidades mentais."
				}},
				{"Jadme6",new List<string>()
				{
					"Dentro do vulcão, ao norte da cidade de <color=yellow>Afarenga</color> fica a <color=yellow>Arena de Laurense</color>",
					"O clérigo de Laurense responsável pela arena é <color=orange>Drooper Hooligan</color>",
					"Ele é conhecido por ser um sujeito acido e altamente leal ao imperador <color=orange>Logan</color>",
					"sua especialidade são Criatures do tipo fogo",
					"Para ganhar o medalhão da forja, que homenageia Laurense, você deve derrotar Drooper numa batalha entre Criatures."
				}},
				{"Jadme7",new List<string>()
				{
				"Desde de o surgimento de <color=cyan>Armagedom</color> muitas coisas mudaram em Orion",
					"Ainda me lembro como se fosse ontem, as primeiras transmissões de informação pelos Armagedom's",
					"Hoje em dia os jornais impressos estão quase desaparecendo, naquela época eles eram unanimidade para que pudessemos nos informar sobre o que ocorria em Yoro e em todo Orion",
					"Hoje em dia com o advento das <color=cyan>Luvas de Guarde</color> não precisamos mais parar em frente a uma conexão com Armagedom para recebermos informações,",
					"podemos simplesmente usar nossas luvas de guarde para nos conectar às redes de informação disponivel, ler e assistir as noticias do mundo",
					"Mas junto com o poder de acesso a informação que veio com Armagedom nasceu também uma grande sombra pairando sobre os caminhos de Orion",
					"Para transmitir informação pela rede Armagedom era necessário uma licença expedida pelos imperialistas",
					"Para receber a licença dos imperialistas era necessário ser simpático ao império",
					"Graças a isso pouca informação critica ao império é disseminada por via de Armagedom",
					"<color=orange>Logan</color> e a administração da <color=orange>Garra Governamental</color> controlam quase todos os canais de transmissão de informação disponiveis",
					"Existe um canal controlado por <color=orange>Jack Bandit</color> o inventor das Luva de Guarde e das cartas Luva mas ele também é simpático aos imperialistas.",
					"Assim eles controlam a opinião publica",
					"Afinal ... Quem controla a opinião publicada, controla a opinião pública"
				}},
				{"Salmo1",new List<string>()
				{
					"Você veio me acompanhar?",
					"Pegue... Tome um gole você também",
					"Não vim beber com você. Fiquei sabendo que você é o maquinista do Trêm",
					"Eu era... Bons tempos aqueles...",
					"Minha alegria era quando o trem já estava chegando... \r\n Vinha Chegando na estação...",
					"Era o trem das 11 horas,\r\n O último na minha mão",
					"Tudo acabou quando eu o vi. Aquela luz",
					"parecia um sujeitinho esquisito.\r\n",
					"Acho que ele era alienigena",
					"Eu vi ele descendo do céu",
					"Essa desordem.. Eu sabia que isso iria acontecer.",
					"Ele desceu acima da <color=yellow>Torre da Vida Eterna</color>"
				}},
				{"Salmo2",new List<string>()
				{
					"Rapaz, andam dizendo por ai que fiquei louco",
					"Andam dizendo por ai que eu não bato bem. ",
					"Andam dizendo por ai que eu sou um estorvo para a sociedade",
					"Mas eu digo uma coisa rapaz:",
					"A arte de ser um louco é jamais cometer a loucura de ser um sujeito normal."
				}},
				{"Salmo3",new List<string>()
				{
					"Eu gostava muito de andar de trêm. Saldades S2",
					"Isso é bom Salmo. Por que preciso que você me leve para <color=yellow>Ofawing</color>",
					"Acho que eu não aguento te carregar nas costas daqui até lá não...\n\r Acho que estou muito bebado pra isso",
					"Não!!! Você está maluco? O que eu quero é que você me leve de trêm",
					"Eu tenho um segredo pra te contar!!!",
					"Faz alguns anos ...",
					"O imperador proibiu as viagens de trem na Ferrovia de Jadme",
					"Eu sei disso, mas preciso chegar até lá e me disseram que você é um dos poucos com conhecimento tecnico para operar o trêm",
					"Agora eu me emocionei ein... Nunca alguem combinou  as palavras conhecimento tecnico com a minha pessoa antes",
					"Vou até desenterrar uma garrafa de bebida que escondi aqui na areia pra comemorar isso",
					"Assim que eu lembrar onde enterrei a garrafa",
					"Como será que os cães fazem pra se lembrar?",
					"Então você  vai me ajudar com o trêm?",
					"Posso tentar , mas antes você precisa me arranjar uma boa quantidade de carvão",
					"É o combustivél do trêm!!",
					"Se eu não bebi de mais e minha memória ainda não foi destruída, acho que traziam isso da cidade de <color=yellow>Afarenga</color>",
					"Então vá até Afarenga compre uma boa quantidade de carvão e traga pra mim. Então eu irei te levar para Ofawing."
				}},
				{"Salmo4",new List<string>()
				{
					"Tudo bem, eu te ajudo a chegar a <color=yellow>Ofawing</color> de trêm",
					"Mas eu preciso que você vá para <color=yellow>Afarenga</color> compre e traga uma boa quantidade de carvão para abastecer o trêm"
				}},
				{"mustafAefik",new List<string>()
				{
					" Ola estranho!! Não é comum eu receber visitas por aqui",
					" Quem é você?",
					" Meu nome é <color=orange>Mustaf Aefik</color>, sou o sacerdote de <color=cyan>Turabá</color> o deus dos mistérios",
					" Posso sentir que há um deus em teu coração. Mas você duvida se esse deus ainda olha por ti e teme que ele não esteja satisfeito com você",
					" Eu vim aqui pelo capitão Aramis, preciso da condecoração que só ele pode me dar",
					" Foi um mistério você coincidir de procura-lo aqui e me encontrar",
					" Também é um misterio o teu destino. Se você for em frente muitos deuses olharão para você",
					" Por enquanto deve se concentrar na sua tarefa de encontrar o capitão, mas logo terá contato com grandes deuses",
					" Espere um momento, se você é um sacerdote de um deus deve ter um medalhão dele para me dar",
					" Apenas clérigos regentes de arena podem lhe dar medalhões dos Deuses",
					" Esses são mistérios que voce ainda terá de descobrir",
					" Consiga a condecoração com o capitão que está dentro da piramide e siga o seu destino"
				}},
				{"AtosAramis",new List<string>()
				{
					" Vejam só... Surge alguém no meio desse breu!",
					" Estou procurando pelo capitão <color=orange>Atos Aramis</color>",
					" Sou eu... Quem é você? E por que está a minha procura?",
					" Sou Cesar Corean, preciso conversar com o Corenel <color=orange>Potus Ramos</color>, mas antes preciso de duas condecorações militares",
					" Me disseram que você poderiam me dar uma condecoração das duas que eu preciso",
					" Você é um sujeitinho muito valente Cesar Corean. Atravessar essa pirâmide não é pra qualquer um!!",
					" Aqueles Escorpions e Escorpireys me deram muita dor de cabeça!!",
					" Mas para receber a condecoração Alpha você deve me derrotar numa batalha de Criatures",
					" Você está pronto para me enfrentar??"
				}},
				{"AramisConversado",new List<string>()
				{
					" Para receber a condecoração Alpha você deve me derrotar numa batalha de Criatures",
					" Você está pronto para me enfrentar??"
				}},
				{"AramisNoMOmentoDaDerrota",new List<string>()
				{
					" Você é um treinador bastante habilidoso Cesar Corean. Faz honra ao mérito de receber a minha condecoração militar",
					" Cesar Corean recebe a <color=cyan>condecoração Alpha</color>",
					" Se você quer mesmo encontrar com o general <color=orange>Potus Ramos</color> na <color=yellow>Fortaleza de Infinity</color>",
					" Vá até lá com as condecorações Alpha e Beta que você conseguirá o que quer",
					" Boa sorte em sua missão soldado!!!"
				}},
				{"AramisDepoisDeDerrotado",new List<string>()
				{
					" Você é um treinador bastante habilidoso Cesar Corean. Faz honra ao mérito de receber a minha condecoração militar"
				}},
				{"conversaNaRepresa",new List<string>()
				{
					" Essa é a grande represa da Yoro de Orion.",
					" Ela é responsável pelo abastecimento de [agua de grande parte das planícies de Orion ",
					" Passamos por alguns problemas desde a ascensão das <color=cyan>gemas laranges</color> e as obcessões do imperador",
					" Uma grande parte das minas de Gemas ficam próximas à cidade de <color=yellow>AexeOdion</color> que fica ás margens do rio atrás da represa",
					" E a poluição das minas está contaminando a nossa água",
					" Parece mesmo que <color=orange>Logan</color> realmente enlouqueceu.",
					" Infelizmente não podemos deixar você entrar. A represa é administrada pela <color=yellow>Garra Governamental</color>",
					" Sem a permissão deles, você não pode entrar."
				}},
				{"manutencaoDasTubulacoes",new List<string>()
				{
					"Essa é a porta utilizada pela equipe de manutenção para entrar nas tubulações submersas no rio",
					"Para abrir essa porta eles tem um cartão magnetico que foi expedido pela <color=yellow>Garra Governamental</color>"
				}},
				{"entradaDaPetrolifera",new List<string>()
				{
					"Parece que um dos operarios da Petrolifera começou a se sentir sozinho e para suprir sua solidão começou a criar insetos.",
					"Porém... Os insetos começaram a se multiplicar e se espalharam por toda a petrolifera",
					"A situação ficou critica quando o cara arrumou alguns pergaminhos que ensinam a habilidade Sabre para os Criatures que podem aprender",
					"Depois de ensinar essa habilidade para alguns <color=cyan>Iziculos</color> eles começaram a cortar o metal da Petrolifera",
					"Não sabemos o que fazer com esse problema!!"
				}},
				{"euBemQueAviseiPetrolifera",new List<string>()
				{
					"Olá Rapaz!! Eu sou um trabalhador da Petrolifera. \r\n Você que veio nos ajudar com o maluco dos insetos?",
					"Estou com muito medo de continuar aqui!! Os insetos cortaram muitas vigas de metal na petrolifera.",
					"Ocorreram muitos acidentes, partes do piso afundaram por falta de sustentação.",
					"Se você vai continuar por ai tome muito cuidado com onde você pisa!!"
				}},
				{"malucoDosINsetos",new List<string>()
				{
					"Você foi enviado por eles não é...??",
					"Do que você está falando",
					"Você foi enviado por aqueles que odeiam os meus insetos para eliminá-los e acabar comigo também não é...?",
					"Então você é o maluco que está ensinando os Insetos a cortarem o metal da Petrolifera?",
					"Os insetos são os únicos que me fazem companhia desde que fiquei confinado a trabalhar nesses porões",
					"Eu só preciso que você me de o <color=cyan>pergaminho de Sabre</color> com o qual você ensina os insetos cortarem metal",
					"Eu jamais lhe entregarei o pergaminho de Sabre sem lutar",
					"Você está preparado para me enfrentar?"
				}},
				{"MalucoConversado",new List<string>()
				{
					"Eu jamais lhe entregarei o pergaminho de Sabre sem lutar",
					"Você está preparado para me enfrentar?"
				}},
				{"MalucoNoMOmentoDaDerrota",new List<string>()
				{
					"Não posso acreditar que você derrotou os meus bebes!!",
					"Oh vida! Oh Deus! Oh azar!!",
					"Pobre de mim que não posso nem mesmo treinar insetos para me fazer companhia...",
					"Pois bem... Se é o desejo geral dos operarios e eu não tenho culhão para vencer uma simples batalha eu me rendo",
					"Pegue o meu <color=cyan>Pergaminho de Sabre</color>",
					"Vou ficar aqui confiando que você dará um bom uso para o pergaminho de sabre e terá um forte e poderoso inseto cortador no seu time de Criatures"
				}},
				{"malucoDepoisDeDerrotado",new List<string>()
				{
					"VOu ficar aqui confiando que você dará um bom uso para o pergaminho de sabre e terá um forte e poderoso inseto cortador no seu time de Criatures"
				}},
				{"entrarNoCruzador",new List<string>()
				{
					"O Cruzador de Guerra está aberto para visitações.",
					" Gostaria de fazer uma visita ao cruzador de guerra por <color=cyan>100 Cristais</color>?"
				}},
				{"entraNoCruzadorRespostas",new List<string>()
				{
					"Esperamos que aprecie a visita",
					"Parece que você não tem dinheiro suficiente",
					"Esperamos poder ve-lo em breve, estranho!!"
				}},
				{"sairDoCruzador",new List<string>()
				{
					"Essa escada é a saída do Cruzador.",
					"Se sair agora terá de pagar entrada novamente.",
					"Tem certeza que já viu tudo o que queria ver?"
				}},
				{"cruzadorOsMelhoresPassarao",new List<string>()
				{
					"Sinto muito te informar rapaz, mas por aqui só os melhores passarão"
				}},
				{"capitaoEspinhaDePeixe",new List<string>()
				{
					"Hey!!! Quem é você?",
					"Ah!! Já sei. Você deve ser mais um dos visitantes do Cruzador que se perdeu.",
					"Provavelmente ficou com medo de algum Baratarab que vive se esgueirando por ai e se separou dos outros turistas.",
					"Não!! Estou procurando o Capitão conhecido como <color=orange>Espinha de Peixe</color>.",
					"Pois bem estranho... Eu sou o Capitão Espinha de Peixe e você quem é? E o que quer de mim?",
					"Meu nome é Cesar Corean.",
					" Preciso falar com o General <color=orange>Potus Ramos</color> da <color=yellow>Fortaleza Stealer</color>, mas me disseram que antes devo conseguir duas condecorações militares.",
					"E que que eu poderia conseguir uma delas com você",
					"Parece que eu tenho um desafiante... Você deve saber que para conseguir a minha condecoração militar você deve me derrotar numa batalha entre Criatures não é mesmo?",
					"Você está preparado para me enfrentar?"
				}},
				{"EspinhaDePeixeNoMOmentoDaDerrota",new List<string>()
				{
					"Parabens Cesar Corean você me venceu numa luta honrada",
					"Consigo ver em você um grande potencial como treinador de Criatures",
					"Você merece receber a minha <color=cyan>Condecoração Beta</color>.",
					" Se você quer mesmo encontrar com o general <color=orange>Potus Ramos</color> na <color=yellow>Fortaleza de Stealer</color> de Infinity",
					" Vá até lá com as condecorações Alpha e Beta que você conseguirá o que quer",
					" Boa sorte em sua missão marujo!!!"
				}},
				{"CapitaoEspinhaDePeixeDepoisDeDerrotado",new List<string>()
				{
					" Se você quer mesmo encontrar com o general <color=orange>Potus Ramos</color> na <color=yellow>Fortaleza de Stealer</color> de Infinity",
					" Vá até lá com as condecorações Alpha e Beta que você conseguirá o que quer",
					" Boa sorte em sua missão marujo!!!"
				}},
				{"EspinhaDePeixeConversado",new List<string>()
				{
					" Para receber a condecoração Beta você deve me derrotar numa batalha de Criatures",
					" Você está pronto para me enfrentar??"
				}},
				{"riquinhaDoEsgoto",new List<string>()
				{
					"Olá Estranho! Você também é um treinador de Criatures em busca do Medalhão do oceano?",
					"Eu entrei aqui para procurar o caminho da <color=yellow>Arena de Drag</color> o deus das águas,...",
					"Mas fiquei muito animada com a quantidade de báus com 2 Cristais que encontrei.",
					"Se continuar assim, mesmo que não consiga o medalhão de Drag sairei daqui feliz, pois sairei muito rica!!"
				}},
				{"guardaFortalezaComAsCondecoracoes",new List<string>()
				{
					"Quer dizer que você conseguiu as duas condecorações militares?",
					"Realmente você faz honra ao mérito para entrar na fortaleza",
					"Tome cuidado ao entrar! General <color=orage>Potus Ramos</color> colocou algumas armadilhas para previnir invasões",
					"Boa Sorte"
				}},
				{"portaFortalezaAberta",new List<string>()
				{
					"Boa Sorte e tome cuidado dentro da Fortaleza"
				}},
				{"guardaFortaleza",new List<string>()
				{
					"Não é permitida a entrada de civis na Fortaleza",
					"O general <color=orange>Potus Ramos</color> abre uma exceção apenas para civis que possuem duas condecorações de honra ao mérito"
				}},
				{"fortaleza1",new List<string>()
				{
					"Para previnir a invação de adversários o general <color=orange>Potus Ramos</color> mandou instalar armadilhas por toda a fortaleza",
					"Existe um caminho que leva até o General, mas só os militares sabem ao certo."
				}},
				{"fortaleza2",new List<string>()
				{
					"O general <color=orange>Potus Ramos</color> instalou armadilhas em diversos locais do segundo andar da fortaleza",
					"Quando você pisa nelas você cai no andar inferior",
					"Mas eu descobri que os Criatures do tipo Psiquico podem aprender uma habilidade chamada pressentimento que pode identificar as armadilhas",
					"Mais uma vez o dia pode ser salvo por um Criature super poderoso."
				}},
				{"potusRamosTrigger",new List<string>()
				{
					"Ei!!! Quem é você? Como conseguiu chegar até aqui?",
					"Meu nome é Cesar Corean, eu tenho as condecorações militares do <color=orange>Capitão Atos Aramis</color> e do <color=orange>Capitão Espinha de Peixe</color>",
					"Vim falar com o <color=orange>General Potus Ramos</color>",
					"Pois bem Cesar Corean! Eu sou o General Potus Ramos",
					"Me entusiasma saber que você é um cidadão que fez honra ao merito de receber duas condecorações militares.",
					"Então me diga... O que quer de mim",
					"Preciso chega a cidade de <color=yellow>Afarenga</color> dentro do vulcão, mas um deslizamento fechou a passagem que da acesso a cidade",
					"Me disseram que você tem o equipamento necessário para desobstruir o caminho",
					"O departamento de materiais da <color=yellow>Garra Governamental</color> deixou aqui na fortaleza o equipamento para desobstruir a passagem de Afarenga",
					"São explosivos que necessitam de alguma pericia para serem manuseados",
					"Estamos num impasse por causa desse material. Eu não concordo em fornecer meus homens para realizar a tarefa de desobstruir o caminho de Afarenga.",
					"A Garra Governamental não aceita enviar homens deles nem contratar alguém.",
					"Apenas por isso a passagem continua obstruida.",
					"Vim até aqui para me oferecer para realizar a tarefa",
					"Você é corajoso rapaz, mas ainda não sei se devo confiar em você",
					"Façamos um trato: Se você me derrotar numa luta entre Criatures eu lhe entrego o equipamento",
					"Você está pronto para me enfrentar?"
				}},
				{"PotusRamosConversado",new List<string>()
				{
					"Você é corajoso rapaz, mas ainda não sei se devo confiar em você",
					"Façamos um trato: Se você me derrotar numa luta entre Criatures eu lhe entrego o equipamento",
					"Você está pronto para me enfrentar?"
				}},
				{"PotusRamosDepoisDeDerrotado",new List<string>()
				{
					"Você é corajoso rapaz!!",
					"Pois bem...",
					"Confio a você a tarefa de desobstruir a passagem de <color=yellow>Afarenga</color>",
					"Não me decepcione!!"
				}},
				{"PotusRamosMomentoDerrota",new List<string>()
				{
					"Você realmente é um bom treinador de Criatures Cesar Corean.",
					"Vou confiar a você a tarefa de desobstruir a passagem de Afarenga",
					"Leve com você os <color=cyan>Explosivos</color>",
					"Não me decepcione Rapaz!"
				}},
				{"chegouNaArenaDeDrag",new List<string>()
				{
					"Olá Estranho!! Meu nome é <color=orange>Sonia Water</color> sou uma clériga do deus das águas <color=cyan>Drag</color>",
					"Você está na Arena de Drag",
					"Meu nome é Cesar Corean, eu vim para conseguir o medalhão de Drag",
					"Você é corajoso de vir até aqui, provavelmente você passou por grandes dificuldades no caminho.",
					"Pois bem... Para ganhar o medalhão das águas você deve enfrentar o clérigo regente da arena...",
					"Ele é o meu marido, <color=orange>Omar Water</color>",
					"Para se inscrever numa disputa dentro da Arena você deve pagar a taxa de inscrição nas atividades de arena no valor de 750 Cristais",
					"Se estiver preparado para enfrentar Omar é só se aproximar dele."
				}},
				{"SoniaWaterAntesDaVitoria",new List<string>()
				{
					"Se estiver preparado para enfrentar Omar é só se aproximar dele."
				}},
				{"SoniaWaterDepoisDaVitoria",new List<string>()
				{
					"Você parece ser uma pessoa muito honrada Cesar Corean.",
					"Podemos perceber que a sua determinação para ganhar o medalhão das águas tem por trás um objetivo maior",
					"Você pretende juntar os medalhões para encarar <color=orange>Logan</color> não é mesmo?",
					"Nós também estamos preocupados com a situação que ocorre em Orion imposta pelo imperador",
					"Se você está mesmo tentando juntar oito dos medalhões dos deuses acredito que deve viajar para <color=yellow>Afarenga</color>.",
					"Lá existe uma Arena para o Deus <color=cyan>Laurense</color> da coragem",
					"Boa sorte na sua jornada pelos caminhos do universo."
				}},
				{"OmarWaterAntesDaLuta",new List<string>()
				{
					"Então tenho um desafiante?",
					"Você veio aqui em busca do medalhão das águas do Deus <color=cyan>Drag</color>?",
					"Saiba que eu não vou amolecer a luta para você",
					"Para me enfrentar você deve pagar a taxa de inscrição nos eventos de arena que aqui tem o valor de 750 Cristais.",
					"Você vai pagar agora?"
				}},
				{"OmarNoMomentoDaDerrota",new List<string>()
				{
					"Meus parabens Cesar Corean, você me venceu e merece receber o Medalhão das Aguas de Drag",
					" Nós clérigos de Drag acreditamos que os rios, mares e oceanos são o corpo de Drag",
					"Como partes de um deus jamais podem ser violados!",
					"Mas as pessoas já esqueceram da importancia que as águas ou mesmo os deuses tem em suas vidas.",
					"Receba o <color=cyan>Medalhão das Aguas</color> e o carregue com você para lembra-lo do respeito que devemos ter com a água do nosso mundo",
					"Eu sei que você planeja entrar na <color=yellow>Torre da Vida Eterna</color> encarar <color=orange>Logan</color>",
					"Como cidadão de Orion e como Clérigo das águas eu acredito que Logan deve ser detido",
					"E se você tem determinação para isso depoisto em você as minhas esperanças",
					"Dentro do vulcão de <color=yellow>Afarenga</color> você pode encontrar a <color=cyan>Arena de Laurense</color> o Deus da Força e da Coragem",
					"Lá você pode ganhar o <color=cyan>medalhão da Forja</color> com o clérigo regente <color=orange>Drooper Hooligan</color>",
					"Que os deuses te acompanhem nos caminhos do Universo"
				}},
				{"OmarDepoisDeDerrotado",new List<string>()
				{
					"Como cidadão de Orion e como Clérigo das águas eu acredito que Logan deve ser detido",
					"E se você tem determinação para isso depoisto em você as minhas esperanças",
					"Dentro do vulcão de <color=yellow>Afarenga</color> você pode encontrar a <color=cyan>Arena de Laurense</color> o Deus da Força e da Coragem",
					"Lá você pode ganhar o <color=cyan>medalhão da Forja</color> com o clérigo regente <color=orange>Drooper Hooligan</color>",
					"Que os deuses te acompanhem nos caminhos do Universo"
				}},

				{"semDimDim",new List<string>()
				{
					"Parece que você não tem dinheiro suficiente"
				}},
				{"trancaRua",new List<string>()
				{
					"parece que o mundo acabou aqui"
				}},
				{"parteFunda",new List<string>()
				{
					"<color=yellow>OPS!!</color> \r\n É melhor tomar cuidado para não cair na parte profunda do rio"
				}},
				{"menuPreJogo",new List<string>()
				{
					"Novo Jogo","Carrega Jogo","Fechar o Jogo"
				}},
				{"mitPrincipal",new List<string>()
				{
					"Status","Itens","Suporte","Organizaçao","Salvar"
				}},
				{"mitOrg",new List<string>()
				{
					"Criatures","Golpes","Itens Rapidos"
				}},
				{"mitSoltos",new List<string>()
				{
					"<color=orange>novo Save</color>",
					"O criature ",
					" esta desmaiado e não pode caminhar ao teu lado",
					"Esse Criature não tem nenhuma habilidade de Suporte",
					"Você nao tem nenhum item no momento.",
					"CRISTAIS: \r\n ",
					"O processo de save foi realizado",
					"Você não tem outros Criatures para Organizar"
				}},
				{"painelStatus",new List<string>()
				{
					"Tipo:   ",
					"tempo de Reaçao: ",
					"Status:     ",
					"     Nv: ",
					"PV : ",
					"PE : ",
					"Poder : ",
					"Forca : ",
					"Defesa : ",
					"Nivel : "
				}},
				{"nomeieSave",new List<string>()
				{
					"Escolha um nome para seu Save",
					"Click na caixa de Texto",
					"cancela",
					"Click no botao ou press ESC no teclado",
					"Click no botao para confirmar o SAVE",
					"confirma",
					"não nomeado"
				}},
				{"itens",new List<string>()
				{
					"Voce não pode usar esse item nesse momento.",
					"Ele não precisa usar esse item nesse momento.",
					"O criature {0} está desmaiado e não pode usar esse item nesse momento.",//O {0} será substituito pelo nome do Criature
					"Somente Criatures do tipo "," podem usar esse item",
					"O criature {0} não pode usar o item {1} pois ele já sabe o golpe {2}",
					"O Criature {0} não pode aprender o golpe {1}",
					"{0} não usou o item {1}",
					"Tem certeza que deseja usar o item {0} ?",
					" Cesar Corean não pode usar esse item nesse local",
                    "{0} não precisa usar esse item nesse momento",
                    "Você não pode usar itens pelo menu enquanto estiver em luta"
				}},
				{"apresentaInimigo",new List<string>()
				{
					"Voce encontrou um ",
					"</color> nivel: ",
					"PV: ",
					"PE: ",
					" O treinador {0} vai utilizar um",
				}},
				{"listaDeItens",new List<string>()
				{
					/*ID==0*/"Maçã", "Burguer", "Carta Luva",
					"Gasolina","Água Tônica",/*ID==5*/"Regador","Estrela","Quartzo","Adubo",
					"Seiva",/*ID==10*/"Inseticida","Aura","Repolho com Ovo","Ventilador","Pilha",
					/*ID==15*/"Gelo Seco","Pergaminho de Fuga","Segredo","Estatua Misteriosa",
					"Cristais","Pergaminho de Perfeição","Antidoto","Amuleto da Coragem","Tônico",/*ID = 24*/
					"Perg. Rajada de Agua","Pergaminho de Saída","Condecoração Alpha","Pergaminho de Armagedom","Pergaminho de Sabre","Perg. da Gosma de Inceto",
					"Perg. GosmaAcida","Perg.Multiplicar","Perg. Ventânia",
					"Perg. Ventos Cortantes","Perg. Olhar Paralisante","Perg.Olhar Mal","Condecoração Beta","Perg. do Furacão de Folhas","Explosivos","Medalhão das Águas"
				}},
                {"listaDeGolpes",new List<string>()
                {
                    "Rajada de Agua","Turbo de Agua","Bola de Fogo","Rajada de Fogo","Lamina de Folha",
                    "Furacão de Folhas","Chifre","Tapa","Garra","Chicote de mão","Dentada","Bico","Ventânia",
                    "Ventos Cortantes","Gosma de Inseto","Gosma Acida","Chicote de Calda","Halter","Eletricidade",
                    "Eletricidade Concentrada","Agulha Venenosa","Onda Venenosa","Chute","Espada","Sobre Salto",
                    "Cascalho","Pedregulho","Rajada de Terra","Energia de Garras","Vingança da Terra","Psicose",
                    "Hidro Bomba","Bola Psiquica","Toste Ataque","Tempestade de Folhas",
                    "Chuva Venenosa","Multiplicar","Tempestade Eletrica","Avalanche","Anel do Olhar",
                    "Olhar Mal","Cortina de Terra","Teletransporte","Sobrevoo","Olhar Paralisante",
                    "Bomba de Gás","Rajada de Gás","Cortina de fumaça","Bastão","Sabre de Asas","Sabre de Bastão",
                    "Sabre de Nadadeira","Sabre de Espadas","Tesoura","Ataque em giro"
                }},
				{"shopInfoItem",new List<string>()
				{
					" Maçã recupera 10 PV de um Criature",
					" Burguer recupera 40 PV de um Criature",
					" Carta Luva é usada para tentar capturar novos Criatures",
					" Gasolina recupera 40 PE de um Criature do tipo Fogo",
					" Água Tônica recupera 40 PE de um Criature do tipo Água",
					" Regador recupera 40 PE de um Criature do tipo Planta",
					" Estrela recupera 40 PE de um Criature do tipo Normal",
					" Quartzo recupera 40 PE de um Criature do tipo Pedra",
					" Adubo recupera 40 PE de um Criature do tipo Terra",
					" Seiva recupera 40 PE de um Criature do tipo Inseto",
					" Inseticida recupera 40 PE de um Criature do tipo Inseto",
					" Aura recupera 40 PE de um Criature do tipo Psiquico",
					" Repolho com Ovo recupera 40 PE de um Criature do tipo Gás",
					" Ventilador recupera 40 PE de um Criature do tipo Voador",
					" Pilha recupera 40 PE de um Criature do tipo Eletrico",
					" Gelo Seco recupera 40 PE de um Criature do tipo Gelo",
					" Quando lido esse pergaminho invoca uma magia para expulsar o oponente da luta ",
					" Um item muito suspeito encostado no fundo da loja",
					" Uma estatua feita de pedra amarelada em pose imponente",
					" É o dim dim do jogo",
					" Quando lido esse pergaminho o criature alvo recupera totalmente os PVs e os PEs além de remover os status negativos ",
					" O Antidoto cura Criatures que estão envenenados ",
					" O Amuleto devolve a coragem para Criatures amedrontados ",
					" O Tônico cura Criatures paralisados",
					" O pergaminho de Rajada de Agua ajuda um Criature do tipo Agua a aprender o golpe Rajada de Agua",
					" Pode ser usado em lugares fechado para te teletransportar para fora",
					" A condecoração que Cesar Corean recebeu do Capitão Atos Aramis.",
					" O pergaminho de Armagedom te teletransporta para o último Armagedom que você entrou. Você precisa estar em local aberto",
					"O pergaminho de Sabre ajuda um Criature a aprender o golpe Sabre",
					" O pergaminho da Gosma de Inseto ajuda um Criature Inseto a aprender o golpe Gosma de Inseto",
					" O pergaminho da Gosma Acida ajuda um Criature Inseto a aprender o golpe Gosma Acida",
					" O pergaminho do Multiplicar insetos ajuda um Criature Inseto a aprender o golpe Multiplicar",
					" O pergaminho da Ventânia ajuda um Criature Voador a aprender o golpe Ventânia",
					" O pergaminho dos Ventos Cortantes ajuda um Criature Voador a aprender o golpe Ventos Cortantes",
					" O pergaminho do Olhar Paralisante ajuda um Criature a aprender o golpe Olhar Paralisante",
					" O pergaminho do Olhar Mal ajuda um Criature a aprender o golpe Olhar Mal",
					" A condecoração que Cesar Corean recebeu do Capitão Espinha de Peixe.",
					" O pergaminho do Furacão de Folhas pode ensinar o golpe Furacão de Folhas para um Criature do tipo Planta",
					"Os Explosivos necessários para desobstruir o caminho para Afarenga",
					"O medalhão das Águas do Deus Drag conseguido com Omar Water"
				}},
				{"entradinhaPlus",new List<string>()
				{
					"Ele Chegou!",
					"Então... . É você que veio juntar-se a  nós?",
					"Olá! Eu sou <color=orange>Cesar Corean</color>.\r\n Sinto que há algo errado com o rumo que as coisas estão tomando e isso não me deixa em paz para seguir o caminho natural da minha vida.",
					"Por isso decidi me juntar a vocês",
					"Meu nome é <color=orange> Caesar Palace</color>. Sou o líder do levante popular contra o imperador que começou na <color=yellow>cidade de Infinity</color>",
					"Os dois que estão comigo são importantes membros da resistencia ao império",
					"Esse é <color=orange>Lance Lutz</color>. Lance é um importante estudioso formado na universidade da predominância",
					"É um sociologo, cientista social e pessoa muito influente entre os pensadores e movimentos sociais de Orion",
					"Esse é <color=orange>Random Hooligan</color>. Ele é membro de uma tradicional familia aristocratica de Orion. Seu irmão é um clérigo da coragem e regente de uma arena de Criatures.",
					"Nós estamos tentando abrir a <color=yellow>Torre da Vida Eterna</color> e encarar <color=orange>o imperador Logan</color> para mudar o destino de Orion",
					"O caminho para isso é muito longo e muito difícil, você precisa de muita determinação para percorrer todo o caminho",
					"Nós estamos apenas no meio do caminho um tanto quanto sem rumo mas já temos algumas lições para tirar da nossa trajetória.",
					"Rapaz, todos os que querem fazer uma tarefa difícil tem um começo.\r\n E só quem já está no meio do caminho sabe como é dificil começar.",
					"Por isso vamos te ajudar",
					"Vou te indicar o caminho do <color=yellow>Armagedom de Infinity</color>, lá você poderá pegar um CRIATURE e iniciar sua jornada",
					"Venha Conosco!",
					"Vamos nos dividir agora!",
					"Lance está indo para a cidade <color=yellow>Ofawing</color> conversar com nossa base social proxima das administrações governamentais",
					"Hooligan irá para <color=color>Afarenga</color> organizar as massas religiosas que estão insatisfeitas com o imperio",
					"Você continua comigo, estamos indo para a cidade de <color=yellow>Infinity</color>.",
					"Por enquanto vou passar um dos meus Criatures para a sua luva, essa caverna é perigosa e é bom que você se defenda.",
					"Venha comigo.",
					"Continue me seguindo!! Estamos perto do tunel que leva a <color=yellow>Infinity</color>",
					"Quem é ele?",
					"Cesar Corean, vou precisar que você me devolva os Criatures. \r\n Faça isso e continue em frente. Esse caminho te levará até a cidade de Infinity",
					"Ele é perigoso?",
					"Esse é <color=orange>Glark Ganovan</color>, ele é responsável por caçar, prender e/ou eliminar os inimigos do império.",
					"Então...\n\r Você é o famoso Caesar... Ratos como você sempre podem ser encontrados no subterrânio",
					"Vá Corean. Você deve contar para os outros sobre esse encontro, caso eu não consiga.",
					"Não posso te deixar enfrenta-lo sozinho",
					"Não me entrego sem lutar!!",
					"Você não terá tempo para lutar!!"
				}},
				{"tuto",new List<string>()
				{
					"Seu CRIATURE FelixCat sofreu um dano alto! Você pode usar uma maçã para recuperar seus pontos de Vida",
					"nao use esse item ainda",
					"Vampire ficou com apenas 1 ponto de Vida, você pode tentar captura-lo. Selecione o item <color=cyan>Carta Luva</color>",
					"Utilize a Energia de Garras",
					"Selecione a Carta Luva utilizando:",
					"Pressione para usar a Carta Luva",
					"Muito Bem Cesar Corean. Você capturou um novo Criature"
				}},
				{"entradinha_elaborada",new List<string>()
				{
					"Cesar Corean sobreviveu à queda...",
					"... mas Caesar não teve a mesma sorte.",
					"Foi esmagado pelas pedras que desmoronaram",
					"Ainda na ponte Caesar disse a Cesar que a cidade de Infinity estava próxima.",
					"E em Infinity, Corean poderia pegar um Criature no Armagedom para iniciar sua trajetoria em direção de abrir a <color=yellow>Torre da Vida Eterna</color> e confrontar o imperador <color=orange>Logan</color>",
					"Cesar Corean então segue em direção a <color=yellow>Infinity</color>"
				}},
				{"estatuaMisteriosa",new List<string>()
				{
					"Cesar Corean coloca a estatua misteriosa na base a frente da pirâmide",
					"A porta da Pirâmide se abre",
					"Parece a base de uma estatua",
					"Então é a estatua que mantém a porta aberta"
				}},
				{"bau",new List<string>()
				{
					"Você encontrou um báu. Quer abri-lo?",
					"O báu está vazio",
					"Dentro do báu Cesar Corean consegue <color=cyan>{0} {1}</color>"
				}},
				{"status",new List<string>()
				{
					"<color=orange>Atenção</color>\r\n Seu Criature {0} desmaiou por envenenamento",
					"Seu Criature {0} sofreu {1} PV de dano por envenenamento",
					"O criature Inimigo sofreu {0} PV de dano por envenenamento"
				}},
				{"movimentoBasico",new List<string>()
				{
					"O uso de item está recarregando. Próximo uso de item em {0}",
					"Golpe em tempo de recarga. \r\n{0}\r\n até o próximo uso. ",
					"{0} esta desmaiado e nao pode sair para continuar a luta"
				}},
				{"encerraAlpha0.0.1",new List<string>()
				{
					"Aqui é o ponto final da Versão Alpha 0.1.0.",
					"Se você chegou até aqui isso me deixa bastante feliz porque você deve ter gostado muito do jogo para alcançar esse ponto",
					"A entrada do vulcão é o caminho para a cidade de <color=yellow>Afarenga</color> que fica na direção da <color=cyan>Arena de Laurense</color>",
					"Você deve se lembrar da introdução do jogo: <color=orange>Random Hooligan</color> viajou para Afarenga para mobilizar a base religiosa em torno da cidade",
					"O irmão de Random Hooligan,<color=orange>Drooper Hooligan</color> é o clérigo da coragem regente responsável pela arena",
					"Você deve ter encontrado durante a sua jornada <color=orange>Salmo Sadol</color> o maquinista do trêm que levava para a cidade de <color=yellow>Ofawing</color>",
					"A carvoaria que fornecia o combustivel para a ferrovia de Jadme fica dentro do vulcão próxima da cidade de Afarenga",
					"Com o carvão Salmo Sadol poderá te levar para a cidade de Ofawing",
					"Lembre-se também da introdução: <color=orange>Lance Lutz</color> foi para Ofawing mobilizar as bases sociais perto da cidade de Ofawing",
					"Ofawing é a cidade mais proxima da sede da <color=yellow>Garra Governamental</color> o orgão responsável por gerenciar todas as entidades publicas do império",
					"Muito ainda está por fazer no projeto <color=#ff8a8d>Criatures de Orin</color> e para ajudar o projeto a continuar visite a página no Facebook e curta ela se ainda não curtiu",
					"Esse jogo está sendo criado até o momento por <color=#ff8a8d>Ivan Fayvit</color>",
					"Espero que estejam apreciando <color=#ff8a8d>Criatures de Orion</color>"
				}},
				{"ive",new List<string>()
				{
					
				}}
				
			}
		},
		{"en-google",
			new Dictionary<string,List<string>>(){
				{"bomDia", new List<string>()
					{
						"Good Morning to you",
						"Good Morning to you",
						"Good Morning ",
						"Good Morning to you"
					}},
				{"infinity1", new List<string>()
					{
						"The south of here there is a town called Ive",
						"There are some stores",
						"Maybe you'll find something that interests you there"
					}},
				{"infinity2", new List<string>()
					{
						"What's with this outfit boy?",
						"who are you trying to fool?",
						"If the <color=yellow> government claw </color> get dressed so you do not even want to know what will make you"
					}},
				{"infinity3", new List<string>()
					{
						"If you head south from here, in a small mountain in the middle of the valley, you can see the <color=yellow> Stealer fortress </color>",
						"A long time ago, even before <color=orange> Logan </color> become the emperor, this plain was the bed of the river Mariinque",
						"As the river Mariinque had wide and deep bed, and besides, flows into the sea",
						"It was an open door for the conquerors of other continents,that landed here in the heart of our continent Yoro",
						"The Stealer Fortress was built to defend Yoro from this type of attack,",
						"Today it has became one more a base at the service of the imperialists."
					}},
				{"infinity4", new List<string>()
					{
						"The legends of Orion say that the emperor is one chosen from the Gods themselves to lead his people in the universe paths.",
						"And the <color=yellow> Tower of Eternal Life </color> is the proof of that,",
						"The Tower of Eternal Life is a fortress that was closed by the choice of the Gods of Orion",
						"Apparently, there are only two ways to enter the Tower",
						"The first is to have the permission of the emperor himself,",
						"The second way is joining eight medallions of the Gods",
						"Joining eight of medallions of the gods and putting the medallions on the front panel of Eternal Life Tower the door will open,",
						"At least that is what they say !! I know of no possessor of eight medallions of the Gods. The most I have ever seen with a single person were five.",
					}},
				{"infinity5", new List<string>()
					{
						"Following to the west of the city Ive you will meet with the River Mariinque",
						"After the construction of the dam the river's course was changed. \r \n The change in the course of the river angered God <color=cyan> Drag </color>, the waters of God.",
						"To give a lesson to the mortals who played god changing the course of a work of nature, Drag caused the New River Mariinque was even deeper than the last and its margin even wider.",
						"In the depth of the river the followers of Drag built a divine arena",
						"In the <color=yellow> divine Arena Drag </color> you can get the medallion of the waters."
					}},
				{"infinity6",new List<string>()
					{
					"Welcome stranger, here is the city of <color=yellow> Infinity </color>",
					"This city is known for being the starting point for many adventurers",
					"You may have heard of Alpha coach, Beta coach and Epsolon Coach, haven't you??",
					"No I haven't",
					"Not really?",
					"At least you must have heard of Criature tamers of Atilio:. Dantas, Boni, Grids and Lara",
					"No I Haven't !! ?? !! For Gods sake In what world do you live?",
					"Are you realy a citizen of Orion?"
					}},
				{"infinity7",new List<string>()
					{
						"You're going out on a journey across the plains of Infinity?",
						"Don't you know that the Criatures are angry and are attacking travelers?",
						"You are trusting that their Criatures can defend you from Criatures scattered across the plains?",
						"Is best for you not to get out from Infinity !! Trust me !!",
						"You will not want to be hit by Marak!",
						"It will not able to sit for several days !!"
					}},
				{"infinity8",new List<string>()
					{
						"The Emperor <color=orange> Logan </color> for many years (almost all of its empire) was a righteous man and led the people of Yoro Orion to prosperity",
						"A couple of years ago the course of the empire changed.",
						"The obsession with <color=cyan> Laranges gems </color> took Logan to adopt slavery as labor in the mines,",
						"Most of the prisoners were taken to the mine <color=yellow> AxeOdion </color>, bandits, robbers, murderers, all types of criminal.",
						"But that didn't fulfilled the emperor greed.",
						"He increased the collection of taxes in the cities of the empire. \r\n This led citizens to misery, which led them to prison, and later, some were taken to forced labor in the mines.",
						"So the emperor could more slaves.",
						"I'm afraid that one day my time come !!"
					}},
				{"infinity9",new List<string>()
					{
						"In the predominance of the desert there is a great University. \r\n In it there are large renowned scholars in Orion",
						"While most people believe that the sudden greed that sparked the Emperor in recent years has mystical origins. \r\n The social scientists at the University has another explanation,",
						"They say we noticed that the emperor greed just now because we are going through a time of intensification of class struggles",
						"The elite of the empire increasingly want <color=cyan> Laranges gems </color> and other precious stones, this causes a growing demand for primary hand work",
						"The need for labor led the empire to adopt slavery. And these unpopular measures led the lower classes to organize against the tyranny of the empire.",
						"They tell you: \n \r The history of mankind until the present day is the history of class struggle.",
						"I do not quite understand about it, but it makes a lot of sense when we hear a scholar talking about.",
					}},
				{"infinity10",new List<string>()
					{
						"You want to enter the <color=yellow> Tower of Eternal Life </color>? And face <color=orange> Logan </color> to question the evils of slavery and greed he shoots against us?",
						"I can not say anything more than that: You are a dreamer.",
						"I know you're not the only and is not difficult to imagine dreaming along with you for a world that is fair",
						"But we need to take our lives, we have our jobs, our bills, our families. I can not really just go out in the world squaring off against an emperor who leads an army.",
						"But if you really want to embark on a search for medallions and face Logan, I have a tip to give you",
						"There is a way to the arena of <color=cyan> Drag </color> from the sewage pipes.",
						"East of the <color=yellow> Stealer  fortress </color> you can find a huge departure from the sewers",
						"I believe that this is the first course that you should take."
					}},
				{"infinity11",new List<string>()
					{
						"The person responsible for <color=yellow> Stealer  fortress </color> is the general <color=orange> Potus Ramos </color>. Below him in the military hierarchy of the fortress are two captains",
						"One is known as <color=orange> Captain Herringbone </color>. Currently the Herringbone captain is fulfilling its mission of taking care of the <color=yellow> War Cruiser </color> that is coming to Mariinque river. ",
						"The other is the <color=orange> Captain Atos Aramis </color> that was sent to a mission inside the <color=yellow> pyramid </color> which is in the desert <color=yellow> Jadme </color> ",
						"Both captains carry decorations that deliver citizens who do honor to the substance. \n\r Citizens who have the decorations of the Herringbone Captain and captain Aramis has free access to enter the fortress."
					}},
				{"infinity12",new List<string>()
					{
						"Today all children are born playing with the technologies offered by <color=cyan> Armageddon </color>.",
						"but was not always like !! \n \r In my time not all used the <color=cyan> Store gloves </color>",
						"The invention of <color=orange> Jack Bandit </color> changed the way people relate and even the way we live in Orion.",
						"Later came the <color=cyan>Gloves Card</color>. \r \n Small letters when embedded in the glove Save increase the power of <color=cyan> Laranje Gem </color>.",
						"This increase in power is used by collectors/Criatures coaches to trap new Criatures",
						"You already imprisoned one Criature using a Glove Card??"
					}},
				{"infinity12respostas",new List<string>()
					{
						"To help you in your first catch I have something for you. \r\n <color=yellow> 5 </color> glove card",
						"It's exciting to be a catch right?",
						"Strange ... It seems to me that you only have this Criature who is walking behind you,",
						"You rascal right? Are you trying to trick me !!",
						"I hope you can capture many Criatures. \r \n Good luck on your journey"
					}},
				{"pagarOuNao",new List<string>()
					{
						"I paid for starting the fight",
						"Maybe later"
					}},
				{"simOuNao",new List<string>()
					{
						"Yes",
						"No"
					}},
				{"ive1",new List<string>()
					{
						"If you go west of here you will arrive at <color=yellow> Mariinque river. </color>",
						"Once you go over the mountains will soon see the <color=yellow> Tower of Eternal Life </color>",
						"On top of the tower stands the castle of the emperor",
						"Sure that's where you want to go?"
					}},
				{"ive2",new List<string>()
					{
						"Welcome to the city of <color=yellow> Ive </color>",
						"Our city has always been prosperous due to the trade route connecting the city of <color=yellow> Afarenga </color> inside the volcano across the river Mariinque,",
						"the city of <color=yellow> Ofawing </color> which is beyond the railway of <color=yellow> Jadme </color>.",
						"But it seems that the winds blow does not blow in our city favor,",
						"A few years ago <color=orange> Logan </color> ordered the closing of the railway Jadme",
						"This reduced the flow of travelers, as they could no longer reach Ofawing by this route,",
						"And recently a landslide closed the volcano entrance that led to the Afarenga",
						"Our trade route has gone from bad to worse."
					}},
				{"ive3",new List<string>()
					{
						"In the middle of the <color=yellow> river Mariinque </color> there is an oil-drilling platform.",
						"The <color=yellow> Oil-drilling platform </color> is responsible for fueling several plains of Orion",
						"But lately they go through serious problems.",
						"Some compartments of oil were taken by Criatures <color=orange> Iziculos </color>.",
						"Iziculos are small insects criatures cutters who like to live in damp, dark places",
						"carry a bat and the bat can learn powerful skills sharp enough to cut steel bars",
						"I think the Oil is in serious trouble",
					}},
				{"ive4",new List<string>()
					{
						"The sewers that run beneath this plain are home for disgusting Criatures.",
						"Travellers who used the east road of the <color=yellow> Fortress </color> always have stories to tell about insects that leave the sewer pipes in those parts.",
						"In view of this problem, the public administration of <color=yellow> Government Claw </color> put bars in sewer pipes for Criatures not come out of there,",
						"But that does not completely solve the problem,",
						"Some criatures bearing canes can use the ability <color=cyan> Cane Sabre </color> and with it cut the sewer isolation bars",
						"The Claw Government is always replacing the sewer grates, but from time to time appears a new opening caused by Criatures."
					}},
				{"ive5",new List<string>()
					{
						"Moored on the banks of <color=yellow> river Mariinque </color> is the <color=yellow> War Cruiser </color>.",
						"The cruiser war is a ship built to defend the continent of Yoro invasions of other continents.",
						"With the extend of peacetime, the Cruiser became less useful for territorial defense issues.",
						"So the military decided to open the Cruiser for visitation by 100 CRYSTALS.",
						"They want to fool us saying it's for the people to know the safety devices that protect us, but I believe they are the same is wanting to earn some change",
						"Possibly are going through a financial crisis as it keeps a war equipment needing maintenance and virtually useless."
					}},
				{"ive6",new List<string>()
					{
						"The technology <color=cyan> Armagedom </color> was created a few decades by the emperor himself <color=orange> Logan </color> when he was a student of the university in the desert of predominance.",
						"With Armageddon's we carry our items a Armageddon to another in the various offices that are scattered Orion.",
						"This is fascinating !!",
						"All this using only the energy provided by a mineral found in very Orion: the <color=cyan> Laranges gems </color>.",
						"After Logan, many scientists worked on improvements for Armageddon.",
						"The possible mass being transported was expanded and the communication system between Armageddon's evolved much since Logan",
						"But the greatest contribution of Armagedom technology, without a doubt, was made by a young scientist and current millionaire: <color=orange> Jack Bandit </color>", "his invention was nothing more nor less than the <color=cyan> Store Glove </color>. ",
						"With the glove Store we carry our items within a Larange Gem positioned in our gloves.",
						"And the most amazing thing of Save gloves is the ability to upload a number of live Criatures",
						"No wonder everyone in Orion is required to use Store gloves "
					}},
				{"ive7",new List<string>()
					{
						"If you follow through the eastern mountains you will come to the city of <color=yellow> Hadjek </color>.",
						"Hadjek is obligatory passage for all travelers who follow the target <color=yellow> Jadme </color>.",
						"In Jadme desert there is a rather curious pyramid. They say the older she is actually a temple to <color=cyan> Turabá </color>, the god of the Mysteries.",
						"The <color=orange> Captain Aramis </color> was sending a mission inside the pyramid.",
						"I suspect he is looking for some Turabá priest there. It would be the search of the revelation of the mystery of the unusual behavior of the emperor?"
					}},
				{"ive8",new List<string>()
					{
						"At the bottom of the river Mariinque clerics <color=cyan> Drag </color> built an arena for the god of the waters.",
						"The person responsible for <color=yellow> arena Drag </color> is <color=orange> Omar Water </color>.",
						"They say the legends of Orion, which after switch travel Mariinque river to the dam's construction, Drag invoked his followers to build monuments on the river bottom.",
						"By the will of Drag, the New River, the river diverted from its course, became deeper and wider than the previous one.",
						"A few generations have passed since the incident and then Omar is here to stay ahead of the arena",
						"They say he and his wife heard the voice of Drag them delegating the responsibility of governing the arena of Rio Mariinque",
						"I am very skeptical about religion, I believe these stories only reinforce the myth of the gods to keep their followers."
					}},
				{"ive9",new List<string>()
					{
						"The path to the castle of the emperor, the <color=yellow> Tower of Eternal Life </color>, is closed by the agreement of the god Orion to protect the emperor who is responsible for lead your people to prosperity",
						"However, the gods did not give the emperor unwavering protection,",
						"By the will of the gods, a citizen of Orion that have eight medallions of the gods can open the gates of the Tower of Eternal Life and climb the tower to meet the emperor",
						"To gain the medallions of the gods only one way: Find the arenas of the gods and challenge their rulers for a fight between Criatures",
						"Win one arena regent, in the arena of a god, you can make the medallion of God.",
						"The gods gave the chance for a decent citizen could dismiss one not worthy emperor",
						"But I think they forgot the part that the emperor leads an army !!"
					}},
				{"ive10",new List<string>()
					{
						"The <color=yellow> Dam </color> that is east of the city of <color=yellow> Infinity </color> is responsible for the water supply of most plains of Orion, it supplies all the plains of Yoro. ",
						"In Mariinque river, there is a <color=yellow> pipe </color> closed by a record. These tubes extend much for Orion.",
						"Maybe inside the pipes you can reach the plains that are not accessible traveling by land.",
						"The control of records of pipes Orion are at the headquarters of <color=yellow> Government Claw </color>."
					}},
				{"ive11",new List<string>()
				{
					"The road to the city of <color=yellow> Afarenga </color> has been blocked by a landslide in a while.",
					"The emperor's army <color=orange> Logan </color> together with the utility sections of <color=yellow> Government Claw </color> are mobilizing to clear the way",
					"According to the news flowing in Orion, General <color=orange> Potus Ramos </color> Fortress Stealer already has his disposal a sufficient quantity of explosives to carry out the task",
					"What prevents the service is a standoff between the imperialist entities Orion, the army led by Ramos expects labor of Governmental and Governmental Claw Claw expects the labor is applied by the army",
					"As the material is with General Ramos, maybe he needs only delegate that responsibility to someone you trust",
					"You do not want to apply?"
				}},
				{"ive12",new List<string>()
				{
					"The history of the construction of the <color=yellow> Stealer fortress </color> is very old and passing from generation to generation.",
					"So many versions have information that do not agree.",
					"The elders say that the name of the fortress \" Stealer \" is named after the eponymous Criature,",
					"Because the forest around the fortress was full of these Criatures",
					"However, the Stealer \'s cast lightning against travelers crossing the forest",
					"Therefore, since the construction of the fortress through the military uptime her Stealers were rounded up and exterminated.",
					"Today there are more Stealers in forest fortress.",
					"Curious that Criature who named the fortress was destroyed precisely because of the existence of the fortress",
					"Some people say they have seen electric Criatures in forest Fortress, but most people do not believe these rumors,",
					"People who say this usually are lying to gain fame."
				}},
				{"armagedomDeInfinity",new List<string>()
				{
					"Hello stranger !! \r \n Welcome to Infinity of Armagedom. \r \n How can I help you?",
					"There is no Criature of your saved at Armagedom at the time."
				}},
				{"opcoesDeArmagedom1",new List<string>()
				{
					"Heal Criatures ", "Your Criatures at Armagedom ", "Cancel"
				}},
				{"falasDeArmagedom",new List<string>()
				{
					"You withdrew <color=yellow>",
					"</color> Level: ",
					" Criature of your group and entered <color=yellow>"
				}},
				{"Shop1",new List<string>()
				{
					"Hello Stranger !! I have excellent goods to you,",
					"Thank you for your visit and come back to our store.",
					"<color=red> OPS !! </color> \r \n You do not have enough money to buy this item",
					"By watching the way you're dressed, I believe that you will not be interested in this item.",
					"I insist! This item is not for you. I hope you do not question me anymore,",
					"I told you ... This item is not for you",
					"Boy ... I'm insistent ein ... Okay, if you want that much can take it",
					"Cesar Corean receives the <color=cyan> Mysterious Statue </color>",
					"Excellent purchase !! Strange. \r \n Would you like to take any more strange thing?",
				}},
				{"hospital",new List<string>()
				{
					"Hello Stranger !! I can heal their wounded Criatures. \r \n Would you like to cure them by",
					"Crystals",
					"You do not have enough crystals at the time. But do not worry we are here ready to meet the medical oath so you get the amount needed",
					"It seems to me the health of their Criatures is perfect. You are to be congratulated for good work in caring for their Criatures",
					"I hope to see him again, weird !!"
				}},
				{"igreja",new List<string>()
				{
					"Hello Stranger !! I can make a mixture of herbs that can wake your Criatures passed out. \r \n Would you like to apply for any of your Criatures ??",
					"The Criature that you apontaste me is not passed out. He does not need a garrafada to awaken",
					" A cost mixture for this Criature ",
					" Crystals ",
					" I hope to see him again, weird !! ",
					" If you have no resources will have to get them to pay me ",
					" Your Criature ",
					" Awake and ",
					" Life points "
				}},
				{"mensLuta",new List<string>()
				{
					"You can not use this item at this time.",
					"Cesar Corean uses ",
					"{0} does not need to use this item at this time"
				}},
				{"encontros",new List<string>()
				{
					"What Criature go out to continue the battle?",
					" Was defeated ",
					" Fainted and this can not continue the fight, ",
					"All Criatures of Cesar Corean were defeated. \r \n \r \n Cesar Corean must now return to Armageddon to renew the energies of their Criatures and return to your adventure",
					"<color=red>OPS!</color> \r\n You do not have EP Enough ."
				}},
				{"encontrosTreinador",new List<string>()
					{
						"In this fight I will use {0} Criatures", 
						"Criature will be my first ...",
						"My next Criature will be ..."
					}},
				{"tentaCapturar",new List<string>()
				{
					" Resisted the attempt to capture. ",
					" The glove save Cesar Corean so can carry, ",
					" Then: ",
					" Level ",
					" was sent to ",
					" Cesar Corean managed to capture a "
				}},
				{"menuPausa",new List<string>()
				{"Return to Game",
				"Buttons",
				"Back to the Title",
				"Closing the Game"
				}},
				{"semHadjek",new List<string>()
				{
					"This is the path to the city of <color=yellow> Hadjek </color>",
					"However, this version ALPHA this map is not yet implemented"
				}},
				{"semMariinque",new List<string>()
				{
					"This is the path to the <color=yellow>  Mariinque River</color>",
					"However, this version ALPHA this map is not yet implemented"
				}},
				{"entradinha",new List<string>()
				{
					"So .... It is you who came to join us?",
					"I feel there is something wrong with the way things are going and it does not leave me alone to follow the natural course of my life.",
					"So I decided to join you,",
					"We are trying to open the <color=yellow> Tower of Eternal Life </color> and face <color=orange> Logan </color> to change the Orion destination",
					"The road to it is very long and very difficult, you need a lot of determination to go all the way",
					"We're only halfway somewhat aimlessly but we already have some lessons to take our history.",
					"Boy, all they want to do a difficult task has a beginning. \r \n And who is now only halfway know how difficult start.",
					"So we'll help you,",
					"I'll show the way the <color=yellow> Infinity Armagedom </color>, there you can catch a CRIATURE and start your journey"
				}},
				{"apresentaFim",new List<string>()
				{
					" Won !! ",
					" The victory ",
					" Received ",
					" <color=#FFD700> experience points. </color> ",
					" and ",
					" Received ",
					" <color=#FF4500> CRYSTALS </color> ",
					" Could ",
					" achieve ",
					" <color=yellow> Level ",
					" </color> ",
					" Learned ",
					" Reuse time: ",
					" s \r \n Basico Attack: ",
					" \r \n PE Cost: ",
					" Can Learn: ",
					" <color=orange> To this must forget an attack !! </color>",
				}},
				{"encontrosScript",new List<string>()
				{
					"<color=orange> Not learning </color>",
					"What Attack {0} forget to learn <color=yellow> {1} </color>",
					" Forgot ",
					"	Not learned	",
					" The Criature {0} has left <color=cyan>{1}</color>"
				}},
				{"Hadjek1",new List<string>()
				{
					"Today the younger complain that the hand of the Emperor is getting heavier",
					"They say that the emperor is in a phase of restrictions of individual rights",
					"They say that many are arrested and/or beaten by imperial guards",
					"I believe that anyone who is arrested or being beaten is because it's the same bum",
					"Look at ... \r \n I I'm a good man I have nothing to complain about on Empire <color=orange> Logan </color> and Action <color=orange> Government Claw </color> ",
					"I own a few properties that are rented and the rent money paid taxes and take my modest life",
					"Who picked up the empire's soldiers is because it's bum and wants to live without working",
					"I want more than the Logan empire lasts for longer years and these litle revolucionary supported by Mom will stop at the presidio of <color=yellow> Cyzor </color>"
				}},
				{"Hadjek2",new List<string>()
				{
					"Welcome to the city of <color=yellow> Hajek </color> stranger !!", 
					"Until recently, we were receiving tourists and scholars who came to know our water.", 
					"The stories that pass from generation to generation is that our waters have medicinal properties because they are a blessing given by <color=cyan> Ananda </color> Goddess of purity and human virtues ",
					" No scientist who traveled from university in the desert of dominance thus far managed to conclude anything about the water Hadjek ",
					" they always conclude that our water is common, like water from any Oasis in the desert ",
					" But scientists are skeptical and perhaps why can not accept the greatness that is the blessing of God on life of those less fortunate. "
				}},
				{"Hadjek3",new List<string>()
				{
					"I'm too scared to move to the North",
					"The road between the city of <color=yellow> Hadjek </color> and the city of <color=yellow> Jadme </color> has become a dangerous place",
					"Some bandits who fled forced labor in the mines of <color=yellow> AxeOdion </color> found hiding in the mountains of the desert",
					"It is suspected that flock to the sewer",
					"This group of criminals itself proclaims <color=orange> Armadillos Venomous </color> and usually address travelers on the road of Jadme",
					"If you go to the North be very careful"
				}},
				{"Hadjek4",new List<string>()
				{
					"The north of here there is a great <color=yellow> Piramide. </color> Some older say it is a temple to <color=cyan> Turabá </color> the God of Mysteries",
					"However, few try to enter the pyramid because of the traps and the mummy dogs",
					"Yes !! Mummy Dogs, I'm not playing with you! I am a very serious person",
					"In fact it is Criatures type of gas.",
					"In recent years with the aggressive outbreak of Criatures, they began to exit the pyramid and attack travelers passing close",
					"I'm afraid of them, mummies remember remind me of death and death ghosts me. I do not want to be a person haunted by entities from other worlds."
				}},
				{"Hadjek5",new List<string>()
				{
					"I've always been a great devotee of the gods of Orion and admire <color=cyan> Turabá </color> God's mysteries",
					"When I travel to <color=yellow> Jadme </color> always a little deviation my route to <color=yellow> Pyramid </color> to pray in honor of Turabá",
					"I've never been in the pyramid, I always wanted to find Turabá priest who lives there",
					"You must be wondering why I never went there, and the truth is, I never thought I would escape the pyramid traps without hurting me",
					"I've always been afraid to die en route. With this fear age was coming and now that you will not have more energy to face the challenges of the pyramid",
					"And there's another complication: The pyramid door has always been open and welcoming to anyone who wanted it enters",
					"but in recent trips I made there the door was closed",
					"Furthermore the statue that stood in the door of the pyramid disappeared, they say it was the work of <color=orange> Armadillos Venomous </color>.",
					"It seems that the statue was stolen and sold to a mercenary merchant <color=yellow> Jadme </color>",
					"Nowadays everything is done for money is not it?",
					"I like to see again the statue in front of the pyramid .... \r \n I hope you can ..."
				}},
				{"Hadjek6",new List<string>()
				{
					"I personally met the captain <color=orange> Atos Aramis </color> And I tell you a guy thing:.", 
					"I may have been one of the last people who saw", 
					"He was sent a ultrasecret mission inside the pyramid and came by the way there ",
					" I saw him from <color=yellow> Hadjek </color>, he headed for the pyramid, it's been several days. Since then, no one else saw ",
					" I do not want Agoro be anyone, but ... ",
					" Everyone already think the worst ",
					" I know a curiosity erodes it. \r \n I know because I also erode. \r \n We are human and not susceptible the curiosities ? is ",
					" The doubts that can leave you anxious is: What was the ultrasecret mission that led Atos Aramis to the pyramid ",
					" Time ... is ultrasecret ... no one should know !! ",
					" Well?. .. \r \n I know !! ",
					" All right I'll tell you. \r \n He told me before leaving in the direction of the pyramid ",
					" But I ask you something ein ... \r \n No tell anyone else! ",
					" The thing is ... \r \n The military already wary of the health of the emperor ",
					" Yes ... of sanity !! Both the army as a <color=orange> Government Claw </color> has received strange orders of the Emperor ",
					" The obsession of the Emperor by <color=cyan> Laranjes Gems </color> concerned very imperialist entities ",
					" So ... Atos Aramis was trying to find the priest of the mysteries so that everyone has a light in Orion paths ",
					" Apparently, the military will try to seize power if they are convinced of the insanity of the emperor ",
					" It scares me !! No scares you? "
				}},
				{"Hadjek7",new List<string>()
				{
					"I see that you are venturing be a Criatures Trainer",
					"As good trainer you should probably know that some types of Criatures are stronger fighting a specific type",
					"If you will follow trip through the desert is good to know that the water and plant types are strong against types stone and earth",
					"Another important thing you should know is that water is strong against poison",
					"And poison is strong against flying and insects.",
					"Keep this information well, surely they will serve you !!"
				}},
				{"Hadjek8",new List<string>()
				{
					"By the Gods !!! You came to collect the new taxes !!",
					"No I did not come, I am not a tax collector",
					"You should not take that scare the people! You should not leave addressing people dress that way.",
					"Only that your clothes causes me chills.",
					"We are being very abused by the taxes of the empire. \r \n I do not understand why those who have more than you need to have almost always been convinced that there is enough",
					"This week two were taken by the empire. They could not longer pay high taxes for the imperialists.",
					"They were turned into labor for the mining of <color=yellow> AxeOdion </color> \r \n This is the fate of those who can not afford:. Becoming slave labor for this obsession by <color=cyan> Laranges Gems </color> ",
					"And if you keep walking around dressed like that will end up going there too"
				}},
				{"Hadjek9",new List<string>()
				{
					"Have you ever ridden a train?",
					"It's great to ride a train. \r \n We can watch the world through the train window",
					"It's almost like assistissimos a TV programming",
					"It's a shame that television still has the best programs that the real world through the train window.",
					"In <color=yellow> Jadme </color> there is a railway that connects the city to the desert <color=yellow> Ofawing </color>.",
					"In Ofawing desert is the building <color=yellow> headquarters of the Government Claw </color>.",
					"You might want to take a train trip to visit the Government Claw"
				}},
				{"Hadjek10",new List<string>()
				{
					"The mayor of <color=yellow> Jadme </color> is a very skilled politician and one of the few institutional leaders that is notoriously hostile to the imperialists",
					"The Mayor of Jadme has very frightening ideas including end the empire . ",
					" At Orion we always live on the imperialist regime. The Emperor has always been responsible for giving the final say in decisions involving a large part of the population ",
					" I can not imagine a form of social organization other than the imperialist . ",
					" The Mayor of Jadme says that the ideal was the top leader of a continent, state, estate, country or even city was put to a vote for approval of the population. ",
					" It also says that people should choose their leaders from time to time. ",
					" I find this absurd! The empire was always there taking care of Yoro Orion. This is how we are born knowing the world, that can not be changed so an hour to another ",
					" The supporters of this idea They call it Democracy. \r \n I can not imagine a world organized that way. "
				}},
				{"Hadjek11",new List<string>()
				{
					"The emperor sent close the <color=yellow> Jadme railway </color> for some time", 
					"That changed the routine of the cities that are in this Orion region", "Many jobs were maintained by the railroad functionality", 
					"After closing the railroad, many people were out of work, others, such as traders, have had their pay reduced by the drop in customer traffic.", "That brought a lot of sadness and depression for workers, especially the Jadme and especially a worker ",
					" <color=orange> Salmo Sadol </color> !! \r \n He was the driver of the train that was the route Jadme/Ofawing ",
					" After the end of his job as a machinist, had difficulties to find another occupation. With the worsening of the debt, he surrendered drunkenness and his wife left him. ",
					" They say she moved in with relatives in a town north of the volcano with her little son. ",
					" Today Salmo Sadol is always found fallen drunk in some corner of the city of Jadme. People who know him say he was crazy and no longer speaks making sense ",
					" Sad story right? "
				}},
				{"Hadjek12",new List<string>()
				{
					"In Orion, responsible for writing the magic scrolls sold in malls are the priests of <color=cyan> Log </color>",
					"Log, is the god of knowledge and wisdom. Throughout an era of gold, their priests were very respected and admired in Orion",
					"It is still like that, but ... \r \n scrolls sales bring distrust of those on the log priests.",
					"Actually ... \r \n In Log priest",
					"<color=orange> Baltasar Gladist </color> is the last priest in Log God's activity",
					"Log Priests are usually very old and in recent years, most of them died.",
					"Millennia they pass from generation to generation the art of writing the scrolls can be used in conjunction with Criatures",
					"But it was Baltazar who made the sale of scrolls a large profitable business driven by the popularity of Keep gloves",
					"Interestingly Baltazar is relatively young compared to other Log clerics",
					"It appears to be about 35 ~ 40 years.",
					"They say he lives in a luxurious mansion near the city of <color=yellow> Cyzor </color>.",
					"I do not think attitude worthy of a holy priest to give the temptations of wealth. What do you think?"
				}},
				{"Hadjek13",new List<string>()
				{
					"<color=orange> Guto Jander </color> is the mayor of the city that is across the desert, <color=yellow> Jadme </color>",
					"Nasty little guy",
					"He is spearheading a movement destabilization of our beloved empire led by <color=orange> Logan </color>",
					"In my sleeve store I received several reports talking about ideas that aim to ruin our way of living in Orion",
					"They call this idea of democracy, say the people should be in power to decide for themselves which path to take",
					"But in reality, what they do not say is that these leaders that democracy will call themselves",
					"The current mayor of Jadme want light to power itself and its",
					"Hypocrites of a fig !!"
				}},
				
				{"prefeitoDeJadme",new List<string>()
				{
					"A warm welcome to the city of Jade strange !! My name is <color=orange> Guto Jander </color> I am the mayor",
					"Hello ... I'm <color=cyan> Cesar Corean </color > in the cities in which I spent speak highly of you ",
					" I suppose so ... I am one of the few leaders in Orion pointing an alternative to empire <color=orange> Logan </color> ",
					" Because of my ideas of democracy the empire and its supporters put all the propaganda machine that has the willingness to try to destroy my political image. ",
					" but the fall of the empire is inevitable ",
					" they can even crush a flower, but never will stop the spring "
				}},
				{"prefeitoDeJadme2",new List<string>()
				{
					"Because of my ideas of democracy the empire and its supporters put all the propaganda machine that has the willingness to try to destroy my political image.",
					"But the fall of the empire is inevitable",
					"They can even crush a flower, but can never stop the spring"
				}},
				{"perguntasParaOPrefeito",new List<string>()
				{
					"Why are you against the empire?",
					"How did you become a political leader so remarkable in Orion?",
					"What is the empire's propaganda machine?", "What is democracy?",
					"I can I join you? ",
					" <color=orange> End Conversation </color> "
				}},
				{"oPorQueDeJander",new List<string>()
				{
					"I live in Jade from young ... \r \n I saw the closing of the railroad and the desperation of the unemployed,",
					"After a while the unemployed were taken to become slave labor in the mines of <color=yellow> AxeOdion </color> ",
					" My parents were taken ... ",
					" After a while I learned of the accident ... ",
					" a landslide killed a group of workers in the mines of the emperor ",
					" My parents were among them ",
					" Since then worked among people Jadme to change our reality ",
					" E change our reality is changing all that Logan empire is. that is, we must first overthrow the empire "
				}},
				{"liderNotavel",new List<string>()
				{
					"I thank the remarkable adjective.",
					"The fact that my name be known in Orion is mainly due to my objection to the rule of <color=orange> Logan </color>",
					"In most cities of this continent mayors are appointed by the emperor.",
					"Only in some cities people vote to give recognition to the mayor usually has no opposition candidate",
					"This happened in Jadme also",
					"But the dissatisfaction of the people of Jadme with the empire, mainly by closing the railway caused the emergence of an opposition was natural",
					"So I assumed that destination that was in front of me tax, I applied and won the mayoral elections",
					"Since then I have shown resistance to abusive taxes and new prisons to slavery",
					"What most concerns the Emperor are the ideas of democracy"
				}},
				{"maquinaDePropaganda",new List<string>()
				{
					"The empire's propaganda machine is how the emperor controls public opinion",
					"The <color=cyan> Save gloves </color> you and I use that time have become items of compulsory use, first in Yoro and then throughout Orion",
					"They have many uses as you may know. One of these is to broadcast information issued by authorized channels",
					"The emperor is who gives permission for information to be transmitted",
					"The consequence of this is that the information is always transmitted to be favorable to the empire",
					"This happens both in the regions dominated by Logan, as in that are beyond Yoro",
					"The control of information causes revolts against injustice are seen as terrorism or riot",
					"If you're not careful with the information coming your glove Store ...",
					"... Your glove Store will make you love the oppressors and the oppressed hate"
				}},
				{"democraciaDeJander",new List<string>()
				{
					"Democracy is a word that etymologically say power to the people",
					"Our democratic current or the end of the empire and that public/government intitutions are coordinated by popular committees",
					"The very people the head of the administration of the entire collective",
					"We want the end of centralized power and the end of an empire, country or nation imposing itself on any and all people",
					"We can no longer remain slaves of the imperialists and accept it as if there was no alternative",
					"We must be an alternative to our own destinies. And the ideas of democracy are that alternative."
				}},
				{"possoMeJuntarAJander",new List<string>()
				{
					"If you tremble with indignation at injustice in the world, then we are companions",
					"Your path has turned towards the confrontation and the democratic movement is an organized political route",
					"There will come a time that our paths will join to defeat Logan.",
					"For now your goal is to bring together eight of the medallions of the gods, open the tower of eternal life and defeat Logan.",
					"We will give you all the political support you need."
				}},
				{"Jadme1",new List<string>()
				{
					"A warm welcome to the city of <color=yellow> Jadme </color>",
					"I love very much this town! \r\n And could love more if it was not a vagabond drunk who is sneaking around in the dark part of town ",
					" has an unoccupied that bothers me a lot, it is called <color=orange> Salmo Sadol </color> was the engineer of the train carrying the <color=yellow> Ofawing </color>. ",
					" After the the railroad disabling some time ago he did not want to learn to work ",
					" This kind of people from me sick !! "
				}},
				{"Jadme2",new List<string>()
				{
					"After crossing the <color=yellow> Mairinque River</color> you can find the Volcano entry that is the way to the city of <color=yellow> Afarenga </color>",
					"Inside the volcano, north of Afarenga, there is a <color=yellow> Carvoaria </color> ",
					" We of Jadme we had many commercial relations with the staff of charcoal"," It was a shame the closure of the railway. "
				}},
				{"Jadme3",new List<string>()
				{
					"North of <color=yellow> Alvarenga </color>, the city the volcano, there is a curious way bridges that form a kind of labyrinth",
					"This way bridges is known by many as <color=yellow> The secret Suns </color> ",
					" this name is because of a mechanism that can change the direction in which some bridges are pointing. the key that triggers this mechanism has the shape of a sun. ",
					" The Secret of the Suns is the path to the <color=cyan> Laurense Arena </color> god of strength and courage ",
					" In Laurense Arena you can earn medallion forge representing the God of force. "
				}},
				{"Jadme4",new List<string>()
				{
					"<color=orange> Guto Jander </color> is a hero for us <color=yellow> Jadme </color>. \r \n He took over the town in a very troubled time with various problems caused by the closing of the railroad ",
					"He seemed enlightened. With his ferocious tirade against the empire and the proposal of each people to be the master of his destiny",
					"I very adimiro Mayor Jadme and his theory of Democracy"
				}},
				{"Jadme5",new List<string>()
				{
					"There's a fellow flown through the head that usually sleeping underneath the train overpass", 
					"I'm new in town, but the elders say that he went crazy after his wife left him",
					"He's always played somewhere the city even though he had a house here. ",
					" I tried to talk to him once, but he speaks not making sense. ",
					" It starts to mix stories by train with aliens. it's a shame ... ",
					" a poor man, young and full of energy, thus relieved of his mental abilities. "
				}},
				{"Jadme6",new List<string>()
				{
					"Inside the volcano, north of the city of <color=yellow> Afarenga </color> is <color=yellow> Laurense Arena </color>",
					"The Laurense cleric responsible for the arena is <color=orange> Drooper Hooligan </color>",
					"He is known to be a subject acid and highly loyal to the emperor <color=orange> Logan </color>",
					"Your specialty is Criatures fire type",
					"To win the medallion of the forge, which honors Laurense, you must defeat in a battle between Criatures Drooper"
				}},
				{"Jadme7",new List<string>()
				{
					"Since the emergence of <color=cyan> Armageddon </color> many things have changed in Orion",
					"I still remember like it was yesterday, the first transmissions of information by Armageddon's",
					"Today the newspapers are almost disappearing, at that time they were unanimously so we could inform about what was happening in Yoro and around Orion",
					"Nowadays with the advent of <color=cyan> Gloves Stores</color> no longer need to stand in front of a connection to Armageddon to receive information",
					"We can simply use our gloves to keep it to connect to the available information networks, reading and watching the news of the world",
					"But along with the power to access the information that came with Armageddon was also born a big shadow hanging over the Orion paths",
					"To transmit information through the network Armageddon one license issued by the imperialists was necessary",
					"To receive the license of the imperialists had to be friendly to the Empire",
					"Thanks to that little information critical to the empire is disseminated via Armageddon",
					"<color=orange> Logan </color> and the administration of <color=orange> Government Claw </color> control almost all information transmission channels available",
					"There is a controlled channel by <color=orange> Jack Bandit </color> the inventor of Keep glove and the letters glove but he is also sympathetic to the imperialists.",
					"So they control public opinion",
					"After all ... Who controls the published opinion, control public opinion"
				}},
				{"Salmo1",new List<string>()
				{
					"You come with me?",
					"Take ... Take a sip you also",
					"I did not come drink with you. I heard you are the engineer of the train",
					"I was ... Good times ...",
					"My joy was when the train was coming ... \r \n Vine Arriving at the station ...",
					"It was the train of 11 hours, \r \n The last in my hand",
					"It was all over when I saw him. That light",
					"seemed an odd fellow. \r \n",
					"I think he was alien",
					"I saw him coming down from heaven",
					"This disorder .. I knew this would happen.",
					"He came up <color=yellow> Tower of Eternal Life </color>"
				}},
				{"Salmo2",new List<string>()
				{
					"Boy, are saying out there that I was crazy",
					"They go out there saying that I do not hit well.",
					"They go out there saying that I am a burden to society",
					"But I say one guy thing",
					"The art of being a madman is never commit the folly of being a normal guy."
				}},
				{"Salmo3",new List<string>()
				{
					"I would love to walk by train. Miss S2",
					"This is good Psalm. Why do I need you to take me to <color=yellow> Ofawing </color>",
					"I think I can not stand carry you back here there not ... \n \r I think I'm too drunk for that ",
					" No !!! Are you crazy? What I want is that you take me by train ",
					" I have a secret to tell you! !! ",
					" A few years ago ... ",
					" The Emperor forbade the train travel in Railroad Jadme ",
					" I know that, but I need to get up there and tell me you're one of the few with technical knowledge to operate the train, ",
					" Now I was touched me ein ... Never someone combined the technical knowledge word with myself before, ",
					" I'm going to dig up a bottle of drink that hid in the sand here to celebrate it ",
					" As soon as I remember where you buried the bottle ",
					" How is it that dogs do to remember? ",
					" So will you help me with the train? ",
					" I can try, but first you need to get me a good amount of coal ",
					" and fuel TRAIN !! ",
					" If I had not drank even more and destroyed my memory, I think it brought the city of <color=yellow> Afarenga </color> ",
					" Then go to buy a Afarenga good amount of charcoal and bring to me. Then I will take you Ofawing. "
				}},
				{"Salmo4",new List<string>()
				{
					"All right, I'll help you get the <color=yellow> Ofawing </color> by train",
					"But I need you to go to <color=yellow> Afarenga </color> buy and bring a good amount of coal to supply the train"
				}},
				{"mustafAefik",new List<string>()
				{
					"Hello stranger !! No I often have visitors here",
					" Who are you?",
					"My name is <color=orange> Mustaf Aefik </color>, I am the priest of <color=cyan> Turabá </color> God's mysteries",
					"I can feel that there is a God in your heart. But if you doubt that God still watches over you and fears that he is not pleased with you",
					"I came here by Aramis captain, I need honor that only he can give me",
					"It was a mystery you match demand it here and find me",
					"It also is a mystery your destination. If you are in front of many gods will look for you",
					"For now should focus on its task of finding the captain, but soon will have contact with the great gods",
					"Wait a minute, if you are a priest of God must have his medallion to give me",
					"Only clerics regents arena can give you medallions of the Gods",
					"These are mysteries that you will still have to find out",
					"Get the decoration with the captain what is inside the pyramid and follow your destiny"
				}},
				{"AtosAramis",new List<string>()
				{
					"Look at ... appears someone in the middle of this pitch!",
					"I'm looking for Captain <color=orange> Atos Aramis </color>",
					"It's me ... Who are you? And why are you looking for me?",
					"I'm Cesar Corean, need to talk to the Corenel <color=orange> Potus Ramos </color>, but rather need two military decorations",
					"I was told you could give me a medal of the two that I need",
					"You are a very brave fellow Cesar Corean. Going through this pyramid is not for everyone !!",
					"Those Escorpions and Escorpireys gave me a lot of headaches !!",
					"But to receive the award Alpha you must defeat me in battle Criatures",
					"Are you ready to take me ??"
				}},
				{"AramisConversado",new List<string>()
				{
					"To receive the award Alpha you must defeat me in battle Criatures",
					"Are you ready to take me ??"
				}},
				{"AramisNoMOmentoDaDerrota",new List<string>()
				{
					"You are a very skilled coach Cesar Korean. It Hons received my military decoration",
					"Cesar Corean receives the <color=cyan> decoration Alpha </color>",
					"If you really want to meet with General <color=orange> Potus Ramos </color> in <color=yellow> Infinity Fortress </color> ",
					" Go up there with the decorations Alpha and Beta you get what you want "," Good luck in your soldier mission !!! "
				}},
				{"AramisDepoisDeDerrotado",new List<string>()
				{
					"You are a very skilled coach Cesar Corean. It Hons received my military decoration"
				}},
				{"conversaNaRepresa",new List<string>()
				{
					"That's the big dam Yoro Orion.",
					"She is responsible for supplying large proportion of water from the plains of Orion",
					"We went through some problems since the rise of <color=cyan> laranges gems </color> and obsessions of the emperor",
					"Much of the gems mines are close to the city of <color=yellow> AexeOdion </color> which is on the banks of the river behind the dam",
					"And the pollution of mines is contaminating our water",
					"It does look like <color=orange> Logan </color> really mad.",
					"Unfortunately we can not let you in. The dam is managed by <color=yellow> Government Claw </color>",
					"Without their permission, you can not enter."
				}},
				{"manutencaoDasTubulacoes",new List<string>()
				{
					"This is the port used by maintenance personnel to enter the pipes submerged in the river",
					"To open this door they have a magnetic card that was issued by <color=yellow> Government Claw </color>"
				}},
				{"entradaDaPetrolifera",new List<string>()
				{
					"It seems that one of the operatives of Petrolifera started to feel alone and to meet his loneliness began to create insects.",
					"But ... The insects began to multiply and spread throughout the oil",
					"The situation became critical when the guy packed some scrolls that teach Sabre ability to Criatures they can learn",
					"After teaching this skill to some <color=cyan> Iziculos </color> they started cutting the metal of Petrolifera",
					"We do not know what to do with this problem !!"
				}},
				{"euBemQueAviseiPetrolifera",new List<string>()
				{
					"Hello Boys !! I am a worker of Petrolifera. In which you came to help us with crazy insects?", 
					"I'm too scared to stay here !! Insects cut many metal beams in the oil. ",
					"there have been many accidents, floor parts sunk for lack of support. ",
					" If you will go out there be very careful where you step !! "
				}},
				{"malucoDosINsetos",new List<string>()
				{
					"You were sent by them is not ... ??",
					"What are you talking about",
					"You were sent by those who hate my insects to eliminate them and finish me is not ...?",
					"So you're the crazy that is teaching the insects to cut the metal from Petrolifera?",
					"Insects are the ones who make me company since it was confined to work in these cellars",
					"I just need you to me of the <color=cyan> Sabre scroll </color> with which you teach the metal cut insects",
					"I would never deliver him the Sabre scroll without a fight",
					"Are you prepared to face me?"
				}},
				{"MalucoConversado",new List<string>()
				{
					"I would never deliver him the Sabre parchment without a fight",
					"Are you prepared to face me?"
				}},
				{"MalucoNoMOmentoDaDerrota",new List<string>()
				{
					"I can not believe you beat my babies !!",
					"Oh life! Oh God! Oh unlucky !!",
					"Poor me I can not even train insects to keep me company ...",
					"Well ... If it is the general desire of operatives and I do not have the balls to win a single battle I surrender",
					"Take my <color=cyan> Sabre Scroll </color>",
					"I'll stay here trusting that you will make a good use for saber parchment and will have a strong and powerful insect cutter to your team Criatures"
				}},
				{"malucoDepoisDeDerrotado",new List<string>()
				{
					"I'll stay here trusting that you will make a good use for saber parchment and will have a strong and powerful insect cutter to your team Criatures"
				}},
				{"entrarNoCruzador",new List<string>()
				{
					"The War Cruiser is open for visitation.",
					"I would like to pay a visit to the cruiser war by <color=cyan> 100 crystals </color>?"
				}},
				{"entraNoCruzadorRespostas",new List<string>()
				{
					"We hope you enjoy the view",
					"Looks like you do not have enough money",
					"We hope to see you soon, weird !!"
				}},
				{"sairDoCruzador",new List<string>()
				{
					"This ladder is the way out of the cruiser.",
					"If you quit now you have to pay entrance again.",
					"Are you sure you've seen all I wanted to see?"
				}},
				{"cruzadorOsMelhoresPassarao",new List<string>()
				{
					"I'm sorry to inform you boy, but here only the best will"
				}},
				{"capitaoEspinhaDePeixe",new List<string>()
				{
					"Hey !!! Who are you?",
					"Ah !! I know. You should be more of the cruiser visitors who are lost.",
					"Probably got scared some Baratarab who lives sneaking around and separated from other tourists.",
					"No !! I'm looking for Captain known as <color=orange> Fishbone </color>.",
					"Well strange ... I'm Captain Fishbone and who are you? And what do you want from me?",
					"My name is Cesar Corean.",
					"I need to speak with General <color=orange> Potus Ramos </color> of <color=yellow> Fortaleza Stealer </color>, but told me that before I get two military decorations.",
					"And that I could get one with you",
					"It seems I have a challenging ... You should know that to get my military decoration you must defeat me in a battle between Criatures is not it?",
					"Are you prepared to face me?"
				}},
				{"EspinhaDePeixeNoMOmentoDaDerrota",new List<string>()
				{
					"Congratulations Cesar Corean you beat me in honorable fight",
					"I can see in you a great potential as a coach Criatures",
					"You deserve to receive my <color=cyan> Decoration Beta </color>.",
					"If you want even meet with general <color=orange> Potus Ramos </color> in <color=yellow> Stealer of Fortaleza </color> Infinity ",
					" Go up there with the decorations Alpha and Beta you get what you want ",
					"Good luck in your mission sailor !!!"
				}},
				{"CapitaoEspinhaDePeixeDepoisDeDerrotado",new List<string>()
				{
					"If you really want to meet with General <color=orange> Potus Ramos </color> in <color=yellow> Stealer of Fortaleza </color> Infinity",
					"Go up there with the decorations Alpha and Beta you get what you want",
					"Good luck in your mission sailor !!!"
				}},
				{"EspinhaDePeixeConversado",new List<string>()
				{
					"To receive the military decoration Beta you must defeat me in battle Criatures",
					"Are you ready to take me ??"
				}},
				{"riquinhaDoEsgoto",new List<string>()
				{
					"Hello Stranger! You're also a Criatures trainer in search of the ocean medallion?", "I got here to find the path of <color=yellow> Drag Arena </color> god of the waters ...", 
					"But I was very excited about the amount of chests with 2 crystals I found.",
					"If this keeps up, even if you can not medallion Drag leaving here happy because it will leave very rich !!"
				}},
				{"guardaFortalezaComAsCondecoracoes",new List<string>()
				{
					"So you got the two military decorations?",
					"Really you do honor to the merit to enter the fortress",
					"Be careful when entering! General <color=orage> Potus Ramos </color> put some traps to prevent invasions",
					"Good luck"
				}},
				{"portaFortalezaAberta",new List<string>()
				{
					"Good luck and be careful in the Fortress"
				}},
				{"guardaFortaleza",new List<string>()
				{
					"No civilian input is allowed in Fortaleza",
					"General <color=orange> Potus Ramos </color> makes an exception only for civilians who have two medals of honor"
				}},
				{"fortaleza1",new List<string>()
				{
					"To prevent opponents invasion of General <color=orange> Potus Ramos </color> had installed traps throughout the fortress",
					"There is a path leading up to the general, but only the military know for sure."
				}},
				{"fortaleza2",new List<string>()
				{
					"General <color=orange> Potus Ramos </color> installed traps in various locations on the second floor of the fortress",
					"When you step on them you fall downstairs",
					"But I discovered that the Psychic type Criatures can learn a skill called presentiment that can identify the pitfalls",
					"Once again the day can be saved by a super powerful Criature."
				}},
				{"potusRamosTrigger",new List<string>()
				{
					"Hey !!! Who are you? How did you get here?",
					"My name is Cesar Corean, I have the military decorations of <color=orange> Captain Atos Aramis </color> and <color=orange> Captain Fishbone </color>",
					"I came to talk to the <color=orange> General Potus Ramos </color>",
					"Well Cesar Corean! I am the General Potus Ramos",
					"And it excites me to know that you are a citizen who did honor to merit receiving two military decorations.",
					"So tell me ... What do you want from me",
					"I need to reach the city of <color=yellow> Afarenga </color> inside the volcano, but a slip closed the passage of access to city",
					"I was told that you have the necessary equipment to clear the way",
					"The materials department at <color=yellow> Governmental Claw </color> left here in the fortress equipment to clear the passage of Afarenga",
					"It explosives requiring some expertise to be handled,",
					"We are at an impasse because of this stuff. I do not agree to provide my men to accomplish the task of clearing the way Afarenga.",
					"The Claw Government does not accept send them men or hire someone.",
					"Just so the passage continues obstructed.",
					"I came here to offer me to accomplish the task",
					"Are you brave boy, but do not know if I still trust you",
					"Let's make a deal: If you defeat me in a fight between Criatures I give you the equipment",
					"Are you ready to face me?"
				}},
				{"PotusRamosConversado",new List<string>()
				{
					"Are you brave boy, but do not know if I still trust you",
					"Let's make a deal: If you defeat me in a fight between Criatures I give you the equipment",
					"Are you ready to face me?"
				}},
				{"PotusRamosDepoisDeDerrotado",new List<string>()
				{
						"Are you brave boy !!",
						"Well ...",
						"I entrust to you the task of clearing the passage of <color=yellow> Afarenga </color>",
						"Do not let me down!!"
				}},
				{"PotusRamosMomentoDerrota",new List<string>()
				{
					"You really are a good trainer Creatures Cesar Korean.",
					"I will entrust to you the task of clearing the passage of Afarenga",
					"Take with you the <color=cyan> Explosives </color>",
					"Do not let me boy! "
				}},
				{"chegouNaArenaDeDrag",new List<string>()
				{
					"Hello Stranger !! My name is <color=orange> Sonia Water</color> am a priestess of the god of the waters <color=cyan> Drag </color>", 
					"You are in the Drag Arena", 
					"My name is Cesar Corean I came to get the medallion Drag ",
					" You are brave to come here, you probably had a hard time on the way. ",
					" well ... to win the medallion water you must face the ruler of cleric arena ... ",
					" He's my husband, <color=orange> Omar Water </color> ",
					" to enroll in a dispute within the Arena you must pay the registration fee in the arena of activities amounting to 750 crystals ",
					" If you are prepared to face Omar just approach him. "
				}},
				{"SoniaWaterAntesDaVitoria",new List<string>()
				{
					"If you are prepared to face Omar just approach him."
				}},
				{"SoniaWaterDepoisDaVitoria",new List<string>()
				{
					"You seem to be a very honorable person Cesar Corean.",
					"We can see that his determination to win the waters of the medallion is behind a larger goal",
					"Do you intend to join the medallions to face <color=orange> Logan </color> is not it? ",
					" We are also concerned about the situation that occurs in Orion imposed by the emperor "," If you're really trying to put together eight of the medallions of the gods believe must travel to <color=yellow> Afarenga </color>. ",
					" there exists a God Arena for the <color=cyan> Laurense </color> courage "," Good luck on your journey along the paths of the universe. "
				}},
				{"OmarWaterAntesDaLuta",new List<string>()
				{
					"So I have a challenger?",
					"You came here in search of the medallion of the God waters <color=cyan> Drag </color>?",
					"Know that I will not soften the fight for you",
					"To me face you must pay the registration fee in the arena of events here is worth 750 crystals.",
					"You'll pay now?"
				}},
				{"OmarNoMomentoDaDerrota",new List<string>()
				{
					"My congratulations Cesar Corean, I won and deserves to receive the Medallion of Drag Waters",
					"We Drag clerics believe that the rivers, seas and oceans are the Body Drag",
					"How parts of a god can never be violated ! ",
					" But people have forgotten the importance that the waters or even the gods have in their lives. ",
					" Get the <color=cyan> Medallion of Waters </color> and carry it with you to remind you of respect that we must have with the water of our world ",
					" I know that you plan to enter the <color=yellow> Tower of Eternal Life </color> face <color=orange> Logan </color> ",
					" As a citizen of Orion and how Cleric water I believe that Logan should be detained ",
					" And if you have determination to this depoisto you my hopes ",
					" Inside the Volcano <color=yellow> Afarenga </color> you can find the <color=cyan> Laurense Arena </color> the God of Strength and Courage ",
					" There you can win the <color=cyan> Medallion Forge </color> with the cleric conductor <color=orange> Drooper Hooligan </color> ",
					" The gods go with you in the ways of the universe "
				}},
				{"OmarDepoisDeDerrotado",new List<string>()
				{
					"As a citizen of Orion and how Cleric water I believe that Logan must be stopped",
					"And if you have determination to this depoisto you my hopes,]",
					"Inside the Volcano <color=yellow> Afarenga </color> you can find the <color=cyan> Laurense Arena </color> the God of Strength and Courage",
					"There you can win the <color=cyan> Medallion Forge </color> with the cleric conductor <color=orange> Drooper Hooligan </color>",
					" The gods go with you in the ways of the universe "
				}},
				{"semDimDim",new List<string>()
				{
					"It looks like you do not have enough money"
				}},
				{"trancaRua",new List<string>()
				{
					"It seems that the world is over here"
				}},
				{"parteFunda",new List<string>()
				{
						"<color=yellow> OPS !! </color> \r \n It is better to be careful not to fall into the deep part of the river"
				}},
				{"menuPreJogo",new List<string>()
				{
					"New Game","Load Game","Exit"
				}},
				{"mitPrincipal",new List<string>()
				{
					"Status","Items","Support","Organization","Save"
				}},
				{"mitOrg",new List<string>()
				{
					"Criatures","Attacks","Items"
				}},
				{"mitSoltos",new List<string>()
				{
					"<color=orange>new Save</color>",
					"The criature ",
					" this unconscious and can not walk beside you",
					"This Criature has no ability Support",
					"You do not have any items right now.",
					"CRYSTALS: \r\n ",
					"The save process was carried out",
					"You do not have to organize other Creatures"
				}},
				{"painelStatus",new List<string>()
				{
					"Type:   ",
					"reaction time ",
					"Status: ",
					" Lv ",
					"LP : ",
					"EP : ",
					"Power : ",
					"Force : ",
					"Defense : ",
					"Level "
				}},
				{"nomeieSave",new List<string>()
				{
					"Choose a name for your Save",
					"Click in the text box",
					"cancels",
					"Click the button or press ESC on the keyboard",
					"Click the button to confirm the SAVE",
					"confirms",
					"unnamed"
				}},
				{"itens",new List<string>()
				{
					"You can not use this item at this time.",
					"He did not need to use this item at this time.",
					"You can not use this item at this time.",
					"Only Criatures the Type","can use this item ",
					" The Criature {0} can not use the item {1} because he already knows the {2} attack ",
					" The Criature {0} can not learn {1} attack ",
					" {0} did not use the item {1} ",
					" Are you sure you want to use the item {0}? ",
					" Cesar Corean can not use this item in this location "
				}},
				{"apresentaInimigo",new List<string>()
				{
					"You found a ",
					"</color> level: ",
					"LP: ",
					"EP: ",
					"{0} trainer will use a"
				}},
				{"listaDeItens",new List<string>()
				{
					/*ID==0*/"Apple", "Burguer", "Grove Card",
					"Gasoline", "tonic water", /* ID == 5 */ "Watering", "Star", "Quartz", "Fertilizant",
					"Sap", /* ID == 10 */ "insecticide", "Aura", "cabbage with egg", "Fan", "battery",
					/* ID == 15 */ "Dry Ice", "Perg. Escape", "Secret", "Mysterious Statue",
					"Crystals", "Perg. Perfection", "Antidote", "Courage Charm", "tonic", /* ID = 24 */
					"Perg. Bust of Water", "Exit Scroll", "Citations Alpha", "Armageddon Scroll", "Perg. Sabre", "Perg. Insect Ooze",
					"Perg. Acid Ooze", "Perg. Multiply", "Perg. Gale",
					"Perg. Winds Cutting", "Perg. Look Paralyzing", "Perg.Look Evil", "Citations Beta", "Perg. Leaves Hurricane",
					"Explosives", "Medallion of the Waters"
				}},
				{"shopInfoItem",new List<string>()
					{
						"Apple recovers 10 PV of a Creature",
						"Burger recovers 40 PV a Criature",
						"Glove Card is used to try to capture new Criatures",
						"Gasoline recovers 40 PE a Criature Fire-type",
						"Tonic Water recovers 40 PE a Criature Water-type ",
						" Watering recovers 40 PE of a plant type Criature ",
						" Star recovers 40 PE a Criature Normal-type ",
						" Quartz recovers 40 PE a Criature Stone-type ",
						" Fertilizer recovers 40 PE a Criature Earth-type ",
						" Sap recovers 40 PE a Criature the Insect ",
						" Insecticide recovers 40 PE a Criature the Insect ",
						" Aura recovers 40 PE a Criature the Psychic type ",
						"cabbage with egg recovers 40 PE of a gas type Criature",
						"Fan recovers 40 PE a Criature the Flying type",
						"battery recovers 40 PE a Criature the Eletrico type",
						"Dry Ice recovers 40 PE a Criature Ice type ",
						" When you read this scroll invokes a spell to expel the fighting opponent ",
						" A very suspicious item leaning on Store fund ",
						" A statue made of yellow stone in imposing pose ",
						" It's the dim dim the game ",
						" When you read this scroll the target criature fully recovers PVs and PEs and removes negative status ",
						" The Criatures healing Antidoto who are poisoned ",
						" The Amulet returns the courage to Criatures frightened ",
						" The tonic cure Criatures paralyzed ",
						" Agua Gust of parchment help a Criature type Agua to learn Gust coup de Agua ",
						" can be used in closed places to teleport you out ",
						" The award that Cesar Corean received from Captain Atos Aramis. ",
						" Armageddon scroll teleports you to the last Armageddon you entered. You need to be in the open ",
						" Sabre parchment helps a Criature to learn Sabre blow ",
						" Parchment of Goop Insect helps a Criature Insect learn the Goop blow Bug ",
						" The scroll of Goop Acida help one Criature Insect learn the Goop blow Acid ",
						" The parchment Multiply insects helps a Criature Insect learn the Multiply blow ",
						" The scroll of the wind helps a Criature Flying learn the wind blow ",
						" The scroll of the Winds Cutters helps a Criature Flying to learn the coup Winds Cutting ",
						" The parchment look Paralysing helps a Criature to learn Look Paralysing blow ",
						" The parchment look hardly helps a Criature to learn Look Mal blow ",
						" The award that Cesar Corean received from Captain Fishbone. ",
						" The leaves of Hurricane parchment can teach Sheets Hurricane blow to a plant type Criature ",
						" The explosives needed to clear the way for Afarenga ",
						" The locket Waters God Drag achieved with Omar Water "
				}},
				{"listaDeGolpes",new List<string>()
				{
					"Burst Water","Water Turbo","Fire Ball","Burst of Fire","Leaf Blade",
					"Leaves Hurricane","Horn","Slap","Claw","Whip Hand","Bite","Beak","Gale","Winds Cutting","Insect Ooze","Acid Ooze","Tail Whip","Halter","Electricity",
					"Concentrated Electricity","Poison needle","Poison Wave","Kick","Sword","Jumping Up","Gravel","Boulder","Burst of Earth","Energy of Claws","Earth Revenge","Psychosis","Hydro Bomb","Psychic Ball","Toast Attack","Leaf Storm",
					"Poison Rain","Multiply","Electrical Storm","Avalanche","Ring of Look",
					"Look Evil","Earth Curtain","Teleportation","Overflight","Look Paralysing",
					"Gas Bomb","Burst of Gas","Smokescreen","Rod","Wing Sabre","Rod Sabre","Fin Sabre","Sword Sabre","Scissors","Spin Attack"
				}},
				{"entradinhaPlus",new List<string>()
				{
					"He arrived!",
					"So .... Are you come join us?",
					"Hello! I am <color=orange> Cesar Corean </color>. \r \n I feel there is something wrong with the way things are going and it does not leave me alone to follow the natural path of my life. ",
					"So I decided to join you",
					"My name is <color=orange> Caesar Palace </color>. I'm the leader of the popular uprising against the emperor who started the <color=yellow> Town Infinity </color>",
					"The two who are with me are important members of resistance to the empire",
					"This is <color=orange> Lance Lutz </color>. Lance is an important scholar trained at the University of predominance",
					"It is a sociologist, a social scientist and very influential person among the thinkers and social movements of Orion",
					"This is <color=orange> Random Hooligan </color>. He is a member of a traditional aristocratic family of Orion. His brother is a clergyman of courage and conductor of a Criatures arena.",
					"We are trying to open the <color=yellow> Tower of Eternal Life </color> and face <color=orange> Emperor Logan </color> to switch the Orion destination",
					"The way this is too long and too hard, you need a lot of determination to go all the way",
					"We're only halfway somewhat aimlessly but we have to take some lessons of our history.",
					"Boy, all they want to do a difficult job has a start. \r \n And who is now only halfway know how difficult start.",
					"So we will help you",
					"I'll show the way the <color=yellow> Armageddon of Infinity </color>, there you can catch a CRIATURE and start your journey",
					"Come with us!",
					"We split now!",
					"Lance is going to the city <color=yellow> Ofawing </color> talk to our next social base of the government administrations",
					"Hooligan will to <color=color> Afarenga </color> organize the religious masses who are dissatisfied with the empire",
					"You still with me, we are going to the city of <color=yellow> Infinity </color>.",
					"For now I'll spend my Criatures to your grove, this cave is dangerous and it is good that you defend.",
					"Come with me.",
					"Keep following me !! We are near the tunnel leading to <color=yellow> Infinity </color>",
					"Who is he?",
					"Cesar Corean, I need you to give me the Criatures. \r \n Do this and keep going. This path will take you to the city of Infinity",
					"He's dangerous?",
					"This is <color=orange> Glark Ganovan </color>, he is responsible for hunting, arresting and/or eliminate the enemies of the empire.",
					"So ... \n \r You are the famous Caesar ... Rats as you can always be found in subterrânio",
					"Go Corean. You should tell others about this meeting if I can not.",
					"I can not let you face it alone",
					"Do not surrender without a fight !!",
					"You will not have time to fight !!"
				}},
				{"tuto",new List<string>()
					{
						"Your Criature Felix Cat suffered a high damage! You can use an apple to retrieve their point of Life",
						"not use this item yet",
						"Vampire was left with only one point of life, you can try catching it. Select item <color=cyan> Glove Card</color> ",
						" use the Energy of Claws ",
						" Select the Glove Card using: ",
						" Press to use the Glove Card",
						" Very Well Cesar Corean You captured a new Criature "
					}},
				{"entradinha_elaborada",new List<string>()
				{
						"Cesar Corean survived the fall ...",
						"... but Caesar was not so lucky.",
						"It was crushed by the rocks that collapsed",
						"Still on the bridge Caesar told Cesar that Infinity city was near. ",
						" in Infinity, Corean could take a Criature at Armageddon to start their trajectory toward opening the <color=yellow> Tower of Eternal Life </color> and confront the emperor <color=orange> Logan </color> ",
						" Cesar Corean then heads towards the <color=yellow> Infinity </color> "
				}},
				{"estatuaMisteriosa",new List<string>()
				{
					"Cesar Corean put the mysterious statue at the base of the front of the pyramid",
					"The Pyramid door opens", 
					"It seems the base of a statue",
					"So is the statue that keeps the door open"
				}},
				{"bau",new List<string>()
				{
					"You found a chest. Do you want to open it?",
					"The chest is empty",
					"Inside the chest Cesar Corean can <color=cyan> {0} {1} </color>"
				}},
				{"status",new List<string>()
				{
					"<color=orange> Warning </color> \r \n Your Creature {0} passed by poisoning",
					"Your Criature {0} suffered {1} PV damage by poisoning", 
					"The Enemy criature suffered {0} PV damage by poisoning "
				}},
				{"movimentoBasico",new List<string>()
				{
					"The use of item is charging. Next use item in {0}", 
					"cooldown in Blow. \r \n {0} \r \n until the next use.",
					"{0} this fainted andYou can not go out to continue the fight "
				}},
				{"encerraAlpha0.0.1",new List<string>()
				{
					
					"This is the end point of the Alpha version 0.1.0.",
					"If you get here it makes me very happy because you must be very liked the game to reach that point",
					"The entrance to the volcano is the path to the city of <color=yellow> Afarenga </color> which is in the direction of <color=cyan> Laurense Arena </color>",
					"You must remember the introduction of the game: <color=orange> Random Hooligan </color> traveled to Afarenga to mobilize religious grounds around town",
					"The brother of Random Hooligan, <color=orange> Drooper Hooligan </color> is the courage of the ruling cleric responsible for the arena",
					"You must have met during his journey <color=orange> Salmo Sadol </color> the engineer of the train leading to the city of <color=yellow> Ofawing </color>",
					"The charcoal that provided the fuel for Jadme railway is inside the volcano near the city of Afarenga",
					"With coal Psalm Sadol can take you to the city of Ofawing",
					"Remember also the introduction: <color=orange> Lance Lutz </color> Ofawing was to mobilize the social bases near the town of Ofawing",
					"Ofawing is the nearest city headquarters of the <color=yellow> Governmental Claw</color> the organ responsible for managing all public entities of the empire",
					"Much remains to be done in the project <color=#ff8a8d> Criatures Orin </color> and to help the project continue to visit the Facebook page and short it does not likes",
					"This game is being created to date by <color=#ff8a8d> Ivan Fayvit </color>",
					"I hope you're enjoying <color=#ff8a8d> Criatures Orion </color>"
				}},
				{"ive",new List<string>()
				{
				
				}}
				
			}
		}
	};

	public static void verificaChaves(string primeiro,string segundo)
	{
		if(falacoes.ContainsKey(primeiro)&&falacoes.ContainsKey(segundo))
		{
			Dictionary<string,List<string>>.KeyCollection keys = falacoes[primeiro].Keys;

			foreach(string k in keys)
			{
				if(falacoes[segundo].ContainsKey(k))
				{
					if(falacoes[segundo][k].Count!=falacoes[primeiro][k].Count)
					{
						Debug.Log("As listas de mensagem no indice "+k+" tem tamanhos diferentes");
					}
				}else
				{
					Debug.Log("A lista "+segundo+" nao contem a chave: "+k);
				}
			}
		}else
		{
			Debug.Log("Ele nao contem alguma das chaves");
		}
	}

    public static void VerificaChavesFortes(idioma primeiro,idioma segundo)
    {
        if (falacoesComChave.ContainsKey(primeiro) && falacoesComChave.ContainsKey(segundo))
        {
            Dictionary<ChaveDeTexto, List<string>>.KeyCollection keys = falacoesComChave[primeiro].Keys;

            foreach (ChaveDeTexto k in keys)
            {
                if (falacoesComChave[segundo].ContainsKey(k))
                {
                    if (falacoesComChave[segundo][k].Count != falacoesComChave[primeiro][k].Count)
                    {
                        Debug.Log("As listas de mensagem no indice " + k + " tem tamanhos diferentes");
                    }
                }
                else
                {
                    Debug.Log("A lista " + segundo + " nao contem a chave: " + k);
                }
            }
        }
        else
        {
            Debug.Log("Ele nao contem alguma das chaves");
        }
    }

    public static List<string> RetornaListaDeTextoDoIdioma(ChaveDeTexto chave)
    {
        return falacoesComChave[heroi.linguaChave][chave];
    }

    public static string RetornaFraseDoIdioma(ChaveDeTexto chave)
    {
        return falacoesComChave[heroi.linguaChave][chave][0];
    }

    /*
	public Dictionary<string,Dictionary<string,int>> nome 
	= new Dictionary<string, Dictionary<string,int>>()
		{{"nome",
			new Dictionary<string,int>(){{"nome2",1}} }};
*/
}

public enum idioma
{
    pt_br,
    en_google
}

public enum ChaveDeTexto
{
    apresentaInimigo,
    usoDeGolpe,
    apresentaFim,
    apresentaDerrota,
    criatureParaMostrador,
    passouDeNivel,
    naoPodeEssaAcao,
    jogoPausado,
    selecioneParaOrganizar,
    emQuem,
    aprendeuGolpe,
    tentandoAprenderGolpe,
    precisaEsquecer,
    certezaEsquecer,
    naoQueroAprenderEsse,
    aprendeuGolpeEsquecendo,
    foiParaArmagedom,
    primeiroArmagedom,
    frasesDeArmagedom,
    simOuNao,
    //bom dia
    bomDia,
        //Infinity
    infinity1,
    infinity2,
    infinity3,
    infinity4,
    infinity5,
    infinity6,
    infinity7,
    infinity8,
    infinity9,
    infinity10,
    infinity11,
    infinity12,
    infinity12respostas,
    shopBasico,
    frasesDeShoping,
    comprarOuVender,
    textosParaQuantidadesEmShop
}