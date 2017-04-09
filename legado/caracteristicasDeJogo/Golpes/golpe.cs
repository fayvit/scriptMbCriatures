using UnityEngine;

[System.Serializable]

public class golpe: pontosBasicos{

	[SerializeField]private string _tipo;
	[SerializeField]private string _nome;

	[SerializeField]private uint custoPE;
	[SerializeField]private float tempoReuso;
	[SerializeField]private float ultimoUso;
	[SerializeField]private float _repulsaoDoDano;
	[SerializeField]private float _tempoNoDano;
	[SerializeField]private float distanciaDeEmissao;

	public caracGolpe CaracGolpe;
	public float taxaDeUso = 1;
	public float mod = 0;
	public nomesGolpes nomeID;

	public float tempoMoveMin = 0.25f;
	public float tempoMoveMax = 0.5f;
	public float tempoDestroy = 1;

	public golpe()
	{
		_tipo = "";
		_nome = "";
		Basico = 1;
		Corrente = 1;
		Maximo = 3;
		custoPE = 0;
		tempoReuso = 1f;
		ultimoUso = 0f;
		_repulsaoDoDano = 3f;
		_tempoNoDano = 0.25f;
		distanciaDeEmissao = 0;
		nomeID = nomesGolpes.nulo;
	}



	public float DistanciaDeEmissao
	{
		get{return distanciaDeEmissao;}
		set{distanciaDeEmissao = value;}
	}

	public float RepulsaoDoDano
	{
		get{return _repulsaoDoDano;}
		set{_repulsaoDoDano = value;}
	}

	public float TempoNoDano
	{
		get{return _tempoNoDano;}
		set{_tempoNoDano = value;}
	}

	public string Nome
	{
		get{return _nome;}
		set{_nome = value;}
	}

	public string Tipo
	{
		get{return _tipo;}
		set{_tipo = value;}
	}

	public float TempoReuso
	{
		get{return tempoReuso;}
		set{tempoReuso = value;}
	}

	public float UltimoUso
	{
		get{return	ultimoUso;}
		set{ultimoUso = value;}
	}

	public uint CustoPE
	{
		get{return custoPE;}
		set{custoPE = value;}
	}


	[System.NonSerialized]protected bool procurouAlvo = false;
	[System.NonSerialized]protected bool addView = false;
	[System.NonSerialized]protected bool retorno = false;
	[System.NonSerialized]protected float tempoDecorrido = 0;

	[System.NonSerialized]protected Transform alvoProcurado;
	[System.NonSerialized]protected Transform T;
	[System.NonSerialized]protected acaoDeGolpe aG;
	[System.NonSerialized]protected CharacterController controle;
	//[System.NonSerialized]protected movimentoBasico mB;
	//[System.NonSerialized]protected IA_inimigo IA;
	//[System.NonSerialized]protected Animator A;

	public virtual void Start(movimentoBasico mB,
	                           IA_inimigo IA,Transform T,Animator A,acaoDeGolpe aG)
	{
		//this.mB = mB;
		//this.IA = IA;
		this.T = T;
		//this.A = A;
		this.aG = aG;

		procurouAlvo = false;
		addView = false;
		tempoDecorrido = 0;
		retorno = false;


	}

	public virtual void Update()
	{
		aG.fimDaAcaoGolpe();
		aG.facaDestroy(aG);
	}

    public static string nomeEmLinguas(nomesGolpes nomeGolpe)
    {
        return bancoDeTextos.falacoes[heroi.lingua]["listaDeGolpes"][(int)nomeGolpe];
    }

    public static string nomeEmLinguas(golpe nomeGolpe)
	{

		//		Debug.Log(itemX.ID);
		if(heroi.lingua!="pt-br")
			return bancoDeTextos.falacoes[heroi.lingua]["listaDeGolpes"][(int)nomeGolpe.nomeID];
		else
			return nomeGolpe.Nome;
	}

}

public enum caracGolpe
{
	projetil,
	colisao,
	colisaoComPow,
	area,
	suporte,
	projetilPerseguidor,
	especialComParalisia,
	hitNoChao

}


