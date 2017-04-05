using System;

public class fogo {
	
	public tipos[] _caracTipo ;
	
	public fogo()
	{
		_caracTipo = new tipos[Enum.GetValues (typeof(nomeTipos)).Length];
		umaCoisa ();
	}
	
	private void umaCoisa()
	{
		for(int cnt = 0; cnt < _caracTipo.Length; cnt++)
		{
			_caracTipo[cnt] = new tipos();
			_caracTipo[cnt].Nome= ((nomeTipos)cnt).ToString();
		}

		_caracTipo [0].Mod = 1.5f;//agua
		_caracTipo[1].Mod = 0.75f;//fogo
		_caracTipo[2].Mod = 0.5f;//planta
		//_caracTipo[3].Mod = 2f;//gelo
		_caracTipo[4].Mod = 1.5f;//terra
		_caracTipo[5].Mod = 1.25f;//pedra
		_caracTipo[6].Mod = 1.75f;//psiquico
		// 7 - Eletrico
		// 8 - NOrmal
		// 9 - veneno
		//_caracTipo[10].Mod = 1.25f;// Inseto
		_caracTipo [11].Mod = 1.25f;// Voador
		_caracTipo [12].Mod = 2f;//Gas
	}
}
