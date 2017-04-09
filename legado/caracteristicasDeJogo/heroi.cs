using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class heroi:MonoBehaviour{

	public string nome = "Cesar Corean";
	public List<Criature> criaturesAtivos = new List<Criature>();
	public List<Criature> criaturesArmagedados = new List<Criature>();
	public List<item> itens = new List<item>();
	public uint cristais = 1021;
	public int criatureSai = 1;
	public int itemAoUso = 0;
	public int maxCarregaveis = 5;
	public float tempoDoUltimoUsoDeItem = -100;
	public float intervaloParaUsarItem = 30;
	public static float tempoNoJogo = 0;
	public static string lingua= "pt-br";
    public static idioma linguaChave = idioma.pt_br;
    public static bool contraTreinador = false;
	public static bool emLuta = false;
	public static entreiPor ondeEntrei = new entreiPor("",Vector3.zero);
	public static List<string> chavesDaViagem = new List<string>();
	public UltimoArmagedom ultimoArmagedom = new UltimoArmagedom
		{
			nomeCena= "planicieDeInfinity",
			V = new float[3]{601.8f,0.08f,1333f}
		};

	public void Awake()
	{
		if(Application.loadedLevelName!=ondeEntrei.nomeDaEntrada)
			ondeEntrei = new entreiPor("", Vector3.zero);

		tempoDoUltimoUsoDeItem = -intervaloParaUsarItem;
		variaveisChave.particularidadesDeCaregamento();

		bancoDeTextos.verificaChaves("pt-br","en-google");

		contraTreinador = false;
		emLuta = false;

		Criature  P = null;

		P = new cCriature  (nomesCriatures.Baratarab).criature ();
		//P.cAtributos[0].Corrente = 20;
		//P.mNivel.XP = 149;

		//P.mNivel.simulaPassaNivel(P.cAtributos);
		criaturesAtivos.Add(P);


		P = new cCriature (nomesCriatures.Oderc,8).criature ();
		//P.cAtributos[0].Corrente = 0;
		criaturesAtivos.Add(P);
		P = new cCriature (nomesCriatures.Cracler,4).criature ();
		criaturesAtivos.Add(P);

		P = new cCriature (nomesCriatures.Nedak,4).criature ();

		criaturesAtivos.Add(P);

		P = new cCriature (nomesCriatures.Baratarab,8).criature ();

		criaturesAtivos.Add(P);


	

		P = new cCriature (nomesCriatures.Marak).criature ();
		
		criaturesArmagedados.Add(P);

		P = new cCriature (nomesCriatures.Escorpion).criature ();
		
		criaturesArmagedados.Add(P);

		P = new cCriature (nomesCriatures.Aladegg).criature ();
		
		criaturesArmagedados.Add(P);

		P = new cCriature (nomesCriatures.Babaucu,2).criature ();
		
		criaturesArmagedados.Add(P);
	

		criatureSai = 1;


		itens.Add (new item(nomeIDitem.maca){estoque = 20});
		itens.Add (new item(nomeIDitem.cartaLuva){estoque = 3});
		itens.Add (new item(nomeIDitem.pergArmagedom){estoque = 7});
		itens.Add (new item(nomeIDitem.pergSabre){estoque = 5});
		itens.Add (new item(nomeIDitem.pergSaida){estoque = 5});
		itens.Add (new item(nomeIDitem.pergGosmaDeInseto){estoque = 8});
		itens.Add (new item(nomeIDitem.pergGosmaAcida){estoque = 8});
		itens.Add (new item(nomeIDitem.pergMultiplicar){estoque = 7});
		itens.Add (new item(nomeIDitem.estatuaMisteriosa){estoque = 1});

	
		//itens [0].estoque = 1;
	

		/*
		itens.Add(new item(nomeIDitem.pergaminhoDePerfeicao));

		itens.Add(new item(nomeIDitem.gasolina));
		itens.Add(new item(nomeIDitem.aguaTonica));
		itens.Add(new item(nomeIDitem.regador));
		itens.Add(new item(nomeIDitem.quartzo));
		itens.Add(new item(nomeIDitem.adubo));
		itens.Add(new item(nomeIDitem.seiva));
		itens.Add(new item(nomeIDitem.inseticida));
		itens.Add(new item(nomeIDitem.pilha));
		itens.Add(new item(nomeIDitem.estrela));
		itens.Add(new item(nomeIDitem.geloSeco));
		itens.Add(new item(nomeIDitem.aura));
		itens.Add(new item(nomeIDitem.ventilador));
		itens.Add(new item(nomeIDitem.repolhoComOvo));
		itens.Add(new item(nomeIDitem.estatuaMisteriosa));

		itens.Add(new item(nomeIDitem.pergaminhoDeFuga));
		itens[itens.Count-1].estoque = 10;

		itens.Add (new item (nomeIDitem.cartaLuva));
		itens[itens.Count-1].estoque = 10;
		*/


	}

	public void limpaTodasAsVariaveis()
	{
		criaturesAtivos = new List<Criature>();
		criaturesArmagedados = new List<Criature>();
		itens = new List<item>();
		cristais = 0;
	}

	public bool alguemTaVivo()
	{
		bool retorno = false;
		for(int i=0;i<criaturesAtivos.Count;i++)
		{
			if(criaturesAtivos[i].cAtributos[0].Corrente>0)
				retorno = true;
		}
		
		return retorno;
	}

	void encheTodoMundo()
	{
		for(int i=0;i<criaturesAtivos.Count;i++)
		{
			criaturesAtivos[i].cAtributos[0].Corrente = criaturesAtivos[i].cAtributos[0].Maximo;
			criaturesAtivos[i].cAtributos[1].Corrente = criaturesAtivos[i].cAtributos[1].Maximo;
			acaoDeItem2.retiraStatusTemporario(i,tipoStatus.todos,this);
		}

		for(int i=0;i<criaturesAtivos.Count;i++)
		{
			criaturesAtivos[i].cAtributos[0].Corrente = criaturesAtivos[i].cAtributos[0].Maximo;
			criaturesAtivos[i].cAtributos[1].Corrente = criaturesAtivos[i].cAtributos[1].Maximo;
		}
	}

	public void devoltaParaOArmagedom()
	{
		heroi.chavesDaViagem = new List<string>();
		if(Application.loadedLevelName == ultimoArmagedom.nomeCena)
		{
			transform.position = ultimoArmagedom.posHeroi;
			transform.rotation = Quaternion.identity;
			Transform T = GameObject.Find("CriatureAtivo").transform;

			Animator animator = T.GetComponent<Animator>();
			animator.SetBool("cair",false);
			animator.Play("padrao");
			encheTodoMundo();
			T.position = ultimoArmagedom.posHeroi;
		}else
		{
			GameObject G = new GameObject();

			mudeCena mudador = G.AddComponent<mudeCena>();
			DontDestroyOnLoad(G);
			mudador.nomeCena = ultimoArmagedom.nomeCena;
			mudador.posicao = ultimoArmagedom.posHeroi;
			encheTodoMundo();
			mudador.guardeValoresEMudeDeCena();

		}
	}


	public string[] nomesCriaturesHeroi()
	{
		string[] opcoes;
		opcoes = new string[criaturesAtivos.Count];
		for(int i=0;i<criaturesAtivos.Count;i++)
		{
			opcoes[i] = criaturesAtivos[i].Nome;
		}

		return opcoes;
	}
}

[System.Serializable]
public struct UltimoArmagedom
{
	public string nomeCena;
	public float[] V;

	public Vector3 posHeroi
	{
		private set{}
		get{
			Vector3 V2 = new Vector3(V[0],V[1],V[2]);
			return V2;}
	}
}

/*

estrutura criada para guardar o local por onde o heroi entrou 
no labirinto

especial para ser usada em conjunto com pergaminho de Saida

 */
[System.Serializable]
public struct entreiPor
{
	public string nomeDaEntrada;
	private float[] posEntrada;

	public entreiPor(string nomeDaEntrada,Vector3 pos)
	{
		this.nomeDaEntrada = nomeDaEntrada;
		posEntrada = new float[3];
		posEntrada[0] = pos.x;
		posEntrada[1] = pos.y;
		posEntrada[2] = pos.z;
	}

	public Vector3 PosEntrada
	{
		get{return new Vector3(posEntrada[0],posEntrada[1],posEntrada[2]);}
		set{posEntrada[0] = value.x;
			posEntrada[1] = value.y;
			posEntrada[2] = value.z;}
	}
}