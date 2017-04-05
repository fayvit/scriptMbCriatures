[System.Serializable]
public class pontosBasicos  {
	[UnityEngine.SerializeField]private uint basico;
	[UnityEngine.SerializeField]private uint corrente;
	[UnityEngine.SerializeField]private uint maximo;
	[UnityEngine.SerializeField]private float taxa;

	public pontosBasicos()
	{
		basico = 1;
		corrente = 1;
		maximo = 1;
		taxa = 0.2f;
	}

	public float Taxa
	{
		get{return taxa;}
		set{taxa = value;}
	}

	public uint Basico
	{
		get{return basico;}
		set{basico = value;}
	}

	public uint Corrente
	{
		get{return corrente;}
		set{corrente = value;}
	}

	public uint Maximo
	{
		get{return maximo;}
		set{maximo = value;}
	}
	/*
	private uint _poder;
	private uint _forca;
	private uint _XP;
	private uint _paraProxLevel;
	private uint _PV;
	private uint _maxPV;
	private uint _PE;
	private uint _maxPE;
	private uint _nv;
	private float _tempoBaseReacao;
	private float _tempoRealReacao;
	private float _modificadorNivel;

	public caracteristicasCriatures()
	{
		_poder = 1;
		_forca = 1;
		_XP = 0;
		_paraProxLevel = 40;
		_PV = 14;
		_maxPV = 14;
		_PE = 20;
		_maxPE = 20;
		_nv = 1;
		_tempoBaseReacao = 1.0f;
		_tempoRealReacao = 1.0f;
		_modificadorNivel = 1.25f;
	}

	public float ModificadorNivel
	{
		get{return _modificadorNivel;}
		set{_modificadorNivel = value;}
	}

	public uint Poder
	{
		get{return _poder;}
		set{_poder = value;}
	}

	public uint Forca
	{
		get{return _forca;}
		set{_forca = value;}
	}

	public uint XP
	{
		get{return _XP;}
		set{_XP = value;}
	}

	public uint ParaProxLevel
	{
		get{return _paraProxLevel;}
		set{_paraProxLevel = value;}
	}

	public uint PV
	{
		get{return _PV;}
		set{_PV = value;}
	}

	public uint MaxPV
	{
		get{return _maxPV;}
		set{_maxPV = value;}
	}

	public uint PE
	{
		get{return _PE;}
		set{_PE = value;}
	}

	public uint MaxPE
	{
		get{return _maxPE;}
		set{_maxPE = value;}
	}

	public uint Nv
	{
		get{return _nv;}
		set{_nv = value;}
	}

	public float TempoBaseReacao
	{
		get{return _tempoBaseReacao;}
		set{_tempoBaseReacao = value;}
	}

	public float TempoRealReacao
	{
		get{return _tempoRealReacao;}
		set{_tempoRealReacao = value;}
	}
*/

}
