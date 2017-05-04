using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class KeyVar
{

    private Dictionary<KeyShift, bool> shift = new Dictionary<KeyShift, bool>();
    private Dictionary<KeyCont, int> contadorChave = new Dictionary<KeyCont, int>();
    private Dictionary<nomesCriatures, bool> visto = new Dictionary<nomesCriatures, bool>();
    private Dictionary<nomesCriatures, bool> colecionado = new Dictionary<nomesCriatures, bool>();
    private List<Scene> cenasAtivas = new List<Scene>();

    public void AdicioneCenaAtiva(Scene cena)
    {
        if(!cenasAtivas.Contains(cena))
            cenasAtivas.Add(cena);
    }

    public void RemoverCenaAtiva(Scene cena)
    {
        cenasAtivas.Remove(cena);
    }

    void MudaDic<T1,T2>(Dictionary<T1,T2> dic, T1 key, T2 val)
    {
        if (!dic.ContainsKey(key))
        {
            dic.Add(key, val);
        }
    }

    public void MudaShift(KeyShift key, bool val = false)
    {
        MudaDic(shift, key, val);
    }

    public void MudaVisto(nomesCriatures nome, bool val = false)
    {
        MudaDic(visto, nome, val);
    }

    public void MudaColecionado(nomesCriatures nome, bool val = false)
    {
        MudaDic(colecionado, nome, val);
    }

    public void MudaCont(KeyCont key, int val = 0)
    {
        MudaDic(contadorChave, key,val);
    }


    public bool VerificaAutoShift(KeyShift key)
    {
        if (!shift.ContainsKey(key))
        {
            shift.Add(key, false);
            return false;
        } else return shift[key];
    }

    public bool VerificaVisto(nomesCriatures key)
    {
        if (!visto.ContainsKey(key))
        {
            visto.Add(key, false);
            return false;
        }
        else return visto[key];
    }

    public bool VerificaColecionado(nomesCriatures key)
    {
        if (!colecionado.ContainsKey(key))
        {
            colecionado.Add(key, false);
            return false;
        }
        else return colecionado[key];
    }

    public int VerificaAutoCont(KeyCont key)
    {
        if (!contadorChave.ContainsKey(key))
        {
            contadorChave.Add(key, 0);
            return 0;
        }
        else return contadorChave[key];
    }
}

public enum KeyShift
{
    primeiraCaptura
}

public enum KeyCont
{

}
