using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class jogoParaSalvar {
	public static jogoParaSalvar corrente;

	public List<item> osItens;
	public List<Criature> ativos;
	public List<Criature> armagedados;
	public uint cristais;
	public List<float> posicao = new List<float>();
	public Rotacao rotacao = new Rotacao();
	public entreiPor ondeEntrei;
	public string nomeCena;
	public string nomeSave;
	public float tempoDeJogo = 0;
	public Dictionary<string,bool> shift = new Dictionary<string,bool>();
	public Dictionary<string,int> contadorChave = new Dictionary<string, int>();
    [SerializeField,HideInInspector]string sShift;
    [SerializeField,HideInInspector]string sContadorDeChaves;

	public jogoParaSalvar()
	{

	}

    public jogoParaSalvar jogoPScomStringsPreenchidas()
    {
        sShift = DicParaString(shift);
        sContadorDeChaves = DicParaString(contadorChave);
        return this;
    }

    string DicParaString<T1,T2>(Dictionary<T1,T2> dic)
    {
        string retorno = "";
        Dictionary<T1,T2>.KeyCollection keys = dic.Keys;
        foreach(T1 t in keys)
        {
            retorno += t.ToString() + ":" + dic[t].ToString()+",";
        }

        retorno = "{" + retorno.Remove(retorno.Length-1) + "}";
        Debug.Log(retorno);

        return retorno;
    }

    public void RetornarStringParaDic()
    {
        string[] r = sShift.Substring(1,sShift.Length-2).Split(',');
        string[] r2;
        shift = new Dictionary<string, bool>();
        for (int i = 0; i < r.Length; i++)
        {
            r2 = r[i].Split(':');
            shift[r2[0].Trim()] = r2[1].Trim()=="False"? false:true;
        }

        Dictionary<string, bool>.KeyCollection X9 = shift.Keys;
        foreach (string s in X9)
        {
            Debug.Log(s + " : " + shift[s]);
        }

        r = sContadorDeChaves.Substring(1, sContadorDeChaves.Length - 2).Split(',');
        r2 = new string[0];
        contadorChave = new Dictionary<string, int>();

        for (int i = 0; i < r.Length; i++)
        {
            r2 = r[i].Split(':');
            contadorChave[r2[0].Trim()] = int.Parse(r2[1]);
        }

        Dictionary<string, int>.KeyCollection X = contadorChave.Keys;
        foreach (string s in X)
        {
            Debug.Log(s + " : " + contadorChave[s]);
        }
        
    }

}

[System.Serializable]
public struct Rotacao
{
	float x,y,z;
	List<string> chavesViagens;

	public Rotacao(Vector3 V,List<string> listaDessasChaves)
	{
		x = V.x;
		y = V.y;
		z = V.z;
		chavesViagens = listaDessasChaves;
	}

	public Vector3 forward
	{
		get{return new Vector3(x,y,z);}
	}

	public List<string> ChavesViagens
	{
		get{
			if(chavesViagens!=null)
				return chavesViagens;
			else
				return new List<string>();

		}
	}
}
