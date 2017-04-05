using System;

public class gas {
	
	public tipos[] _caracTipo ;
	
	public gas()
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

		//_caracTipo [0].Mod = 1.5f;//agua
		_caracTipo[1].Mod = 2f;//fogo
		//_caracTipo[2].Mod = 0.5f;//planta
		//_caracTipo[3].Mod = 2f;//gelo
		//_caracTipo[4].Mod = 1.5f;//terra
		//_caracTipo[5].Mod = 1.25f;//pedra
		_caracTipo[6].Mod = 0.5f;//psiquico
		// 7 - Eletrico
		// 8 - NOrmal
		_caracTipo[9].Mod = 0.75f;//veneno
		_caracTipo[10].Mod = 0.5f;// Inseto
		_caracTipo [11].Mod = 2f;// Voador
		//_caracTipo [12].Mod = 2f;//Gas
	}
}
