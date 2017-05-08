using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadAndSaveGame
{
    private int indiceDoJogoAtualSelecionado = 0;

    public void Save(SaveDates paraSalvar)
    {

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/criatures.ori"+indiceDoJogoAtualSelecionado);
        bf.Serialize(file, paraSalvar);

        file.Close();
    }

    public SaveDates Load(int indice)
    {
        indiceDoJogoAtualSelecionado = indice;
        SaveDates retorno = null;
        if (File.Exists(Application.persistentDataPath + "/criatures.ori" + indiceDoJogoAtualSelecionado))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/criatures.ori" + indiceDoJogoAtualSelecionado, FileMode.Open);
            retorno = (SaveDates)bf.Deserialize(file);
            file.Close();
        }

        return retorno;
    }
}
