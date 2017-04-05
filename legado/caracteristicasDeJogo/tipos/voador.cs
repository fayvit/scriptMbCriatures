using System;

public class voador {
	
	public tipos[] _caracTipo ;
	
	public voador()
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
		
		_caracTipo[1].Mod =0.75f;//fogo
		//_caracTipo[2].Mod = 1.75f;//planta
		_caracTipo[3].Mod = 2f;//gelo
		_caracTipo[4].Mod = 0.75f;//terra
		//_caracTipo[5].Mod = 0.75f;//pedra
		_caracTipo[6].Mod = 0.75f;//psiquico
		_caracTipo[7].Mod = 1.5f;//eletrico
		_caracTipo[9].Mod = 1.5f;//Veneno
		_caracTipo[12].Mod = 0.25f;//Gas
		
	}
}