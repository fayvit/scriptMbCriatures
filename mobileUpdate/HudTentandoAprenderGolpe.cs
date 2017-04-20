using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudTentandoAprenderGolpe : MonoBehaviour
{
    [SerializeField]private DadoDaHudRapida[] btns;
    [SerializeField]private Text labelDaHud;

    /*
    public DadoDaHudRapida[] Btns
    {
        get { return btns; }
    }

    public Text LabelDaHud
    {
        get { return labelDaHud; }
    }*/

    public void Aciona(GolpeBase[] meusGolpes, nomesGolpes golpeNovo,string txt, System.Action<int> acao)
    {
        gameObject.SetActive(true);
        labelDaHud.text = txt;

        for (int i = 0; i < meusGolpes.Length; i++)
        {
            btns[i].SetarGolpe(meusGolpes[i].Nome);
            btns[i].SetarAcao(acao);
        }

        btns[4].SetarGolpe(golpeNovo);
        btns[4].SetarAcao(acao);
    }

    public void Finalizar()
    {
        for (int i = 0; i < btns.Length; i++)
            btns[i].LimparAcao();

        gameObject.SetActive(false);
    }
}
