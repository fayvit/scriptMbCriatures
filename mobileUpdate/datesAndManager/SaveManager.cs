using UnityEngine;
using System.Collections;

public class SaveManager
{
    private float tempoDecorrido = 0;
    private LoadAndSaveGame loadSave = new LoadAndSaveGame();
    private const float INTERVALO_DE_SAVE = 60;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        tempoDecorrido += Time.deltaTime;
        if (tempoDecorrido > INTERVALO_DE_SAVE)
        {
            SalvarAgora();
        }
    }

    public void SalvarAgora()
    {
        loadSave.Save(new SaveDates());
        tempoDecorrido = 0;
    }
}
