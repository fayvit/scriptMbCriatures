using UnityEngine;
using System.Collections;

public class elementosDoJogo : LuvaDeGuarde {

	public GameObject[] doJogo;
	public Material[] materiais;
	public GameObject[] colisores;
	public GameObject[] criatures;
	public Texture2D[] miniGolpes;
	public Texture2D[] miniCriatures;
	public Texture2D[] miniItens;
	public Texture2D[] miniStatus;
	public static elementosDoJogo el;

	public GUISkin skin;
	public GUISkin destaque;

	void Start()
	{
		el = this;
	}

    public GameObject retorna(DoJogo doJogo)
    {
        return retorna(doJogo.ToString(), "doJogo");
    }

    public GameObject retorna(Huds doJogo)
    {
        return retorna(doJogo.ToString(), "doJogo");
    }

    public GameObject retorna(nomesCriatures nome)
    {
        return retorna(nome.ToString(), "criature");
    }

    public GameObject retorna(string ele,string oq = "doJogo")
	{

		GameObject retorno = null;

		switch(oq)
		{
		case "doJogo":
			for(int i=0;i<doJogo.Length;i++)
			{
				if(doJogo[i].name == ele)
					retorno = doJogo[i];
			}
		break;
		case "criature":
		case "Criature":
			retorno = criature(ele);
		break;
		case "colisor":
			retorno = retornaColisor(ele);
		break;
		}


		return retorno;
	}

    public Texture2D RetornaMini(nomesCriatures nome)
    {
        return retornaMini(nome.ToString(),"criature");
    }

    public Texture2D RetornaMini(nomeIDitem nome)
    {
        return retornaMini(nome.ToString(), "itens");
    }
    public Texture2D RetornaMini(nomesGolpes nome)
    {
        return retornaMini(nome.ToString(), "golpe");
    }

    public Texture2D retornaMini(string ele,string oQ)
	{

		Texture2D retorno = null;
		Texture2D[] conjunto = null;

		switch(oQ)
		{
		case "golpe":
			conjunto = miniGolpes;
		break;
		case "criature":
			conjunto = miniCriatures;
		break;
		case "itens":
			conjunto = miniItens;
		break;
		case "status":
			conjunto = miniStatus;
		break;
		}

		for(int i=0;i<conjunto.Length;i++)
		{
			if(conjunto[i].name == ele)
				retorno = conjunto[i];
		}
		
		return retorno;
	}

	public GameObject criature(string ele)
	{
		
		GameObject retorno = null;
		for(int i=0;i<criatures.Length;i++)
		{
			if(criatures[i].name == ele)
				retorno = criatures[i];
		}
		
		return retorno;
	}

	public GameObject retornaColisor(string ele)
	{
		
		GameObject retorno = null;
		for(int i=0;i<colisores.Length;i++)
		{
			if(colisores[i].name == ele)
				retorno = colisores[i];
		}
		
		return retorno;
	}
}

/// <summary>
/// Enumerador para gameObjects que são instanciados durante o jogo
/// </summary>
public enum DoJogo
{
    rajadaDeAgua,
    particulasDerrotado,
    AlvoFoco,
    impactoDeAgua,
    GiraCubo,
    particulaLuvaDeGuarde,
    raioDeLuvaDeGuarde,
    acaoDeCura1,
    particulasCoisasBoasUI,
    particulasUpeiDeNivel,
    encontro
}

/// <summary>
/// Enumerador para tipos de HUDs instanciadas durante o jogo
/// </summary>
public enum Huds
{
    HUD_Vida,
    HUD_Golpes,
    HUD_Criatures,
    HUD_Itens
}
/// <summary>
/// Enumerador para miniaturas que são chamadas durante o jogo
/// </summary>
public enum RetornaMiniTipos
{
    golpe,
    criature,
    itens,
    status
}