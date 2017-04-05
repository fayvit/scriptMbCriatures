using System;

public class pedra {

	public tipos[] _caracTipo ;

	public pedra()
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

		_caracTipo[0].Mod = 2f;//Agua
		_caracTipo[1].Mod =0.25f;//fogo
		_caracTipo[2].Mod = 1.75f;//planta
		//_caracTipo[3].Mod = 2f;//gelo
		//_caracTipo[4].Mod = 0.5f;//terra
		//_caracTipo[5].Mod = 0.5f;//pedra
		_caracTipo[6].Mod = 1.5f;//psiquico
		_caracTipo[7].Mod = 0.1f;//eletrico
		_caracTipo[8].Mod = 0.25f;//NOrmal
		_caracTipo[9].Mod = 0.25f;// Veneno
		//_caracTipo[10].Mod = 0.5f;// Inseto
		_caracTipo [11].Mod = 0.75f;// Voador
		_caracTipo[12].Mod = 0.5f;//Gas

	}
}
