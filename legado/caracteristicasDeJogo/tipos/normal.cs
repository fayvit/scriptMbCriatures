using System;

public class normal {
	
	public tipos[] _caracTipo ;
	
	public normal()
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

		//_caracTipo[4].Mod = 0.5f;//terra
		//_caracTipo[5].Mod = 0.25f;//pedra
		
	}
}
