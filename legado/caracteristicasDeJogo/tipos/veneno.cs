using System;

public class veneno {

	public tipos[] _caracTipo ;

	public veneno()
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

		_caracTipo [0].Mod = 1.25f;//agua
		_caracTipo[1].Mod =0.75f;//fogo
		//_caracTipo[2].Mod = 0.75f;//planta
		_caracTipo[3].Mod = 1.25f;//gelo
		_caracTipo[4].Mod = 1.25f;//terra
		_caracTipo[5].Mod = 1.25f;//pedra
		_caracTipo[6].Mod = 0.75f;//psiquico
		//_caracTipo[7].Mod = 0.75f;//eletrico
		// 8 - NOrmal
		//_caracTipo[9].Mod = 2f;// Veneno
		_caracTipo[10].Mod = 0.5f;// Inseto
		//_caracTipo [11].Mod = 1.75f;// Voador
		_caracTipo[12].Mod = 0.5f;//Gas

	}
}
