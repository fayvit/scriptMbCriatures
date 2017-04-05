using System;

public class agua {

	public tipos[] _caracTipo ;

	public agua()
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

		_caracTipo[1].Mod =0.25f;//fogo
		_caracTipo[2].Mod = 1.75f;//planta
		_caracTipo[3].Mod = 2f;//gelo
		_caracTipo[4].Mod = 0.5f;//terra
		_caracTipo[5].Mod = 0.5f;//pedra
		_caracTipo[6].Mod = 1.75f;//psiquico
		_caracTipo[7].Mod = 2f;//eletrico

	}
}
