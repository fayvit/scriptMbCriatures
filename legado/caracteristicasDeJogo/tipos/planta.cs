using System;

public class planta {
	
	public tipos[] _caracTipo ;
	
	public planta()
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
		
		_caracTipo [0].Mod = 0.25f;//agua
		_caracTipo[1].Mod = 2f;//fogo
		//_caracTipo[2].Mod = 2f;//planta
		_caracTipo[3].Mod = 1.25f;//gelo
		_caracTipo[4].Mod = 0.75f;//terra
		_caracTipo[5].Mod = 0.75f;//pedra
		_caracTipo[6].Mod = 1.25f;//psiquico
		// 7 - Eletrico
		// 8 - NOrmal
		// 9 - veneno
		_caracTipo[10].Mod = 1.25f;// Inseto
		_caracTipo [11].Mod = 1.25f;// Voador
	}
}
