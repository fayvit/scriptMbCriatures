[System.Serializable]
public class atributos : pontosBasicos {
	[UnityEngine.SerializeField]private string _name;
	public atributos()
	{
		_name = "";
		Basico = 1;
		Corrente = 1;
		Maximo = 1;
	}

	public uint padrao()
	{
		uint retorno = 1;
		switch(_name)
		{
		case "PV":
			retorno =  14;
		break;
		case "PE":
			retorno = 30;
		break;
		default:
			retorno = 1;
		break;
		}

		return retorno;
	}

	public string Nome
	{
		get{return _name;}
		set{_name = value;}
	}
}

public enum nomesAtributos
{
	PV,
	PE,
	Poder,
	Forca,
	Defesa
}
