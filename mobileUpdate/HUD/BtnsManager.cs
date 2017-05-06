using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BtnsManager
{
    public Button btnPauseMenu;
    public Button btnParaCriature;
    public Button btnMaisCriature;
    public Button btnItens;
    public Button btnMaisAtaques;
    public Button btnPular;
    public Button btnAtaque;
    public RawImage imgDoAtaque;

    public void BotoesDoHeroi(CharacterManager manager)
    {
        AlternaBotoes(manager,true);
    }

    public void BotoesDoCriature(CharacterManager manager)
    {
        AlternaBotoes(manager, false);
    }

    void AlternaBotoes(CharacterManager manager,bool heroi)
    {
        //btnPauseMenu.gameObject.SetActive(heroi);
        btnMaisAtaques.gameObject.SetActive(!heroi);
        btnAtaque.gameObject.SetActive(!heroi);

        bool aparece = true;
        if (manager.Dados.Itens.Count > 0)
            aparece = true;
        else
            aparece = false;

        btnItens.gameObject.SetActive(aparece);

        if (manager.Dados.CriaturesAtivos.Count > 1)
            aparece = true;
        else
            aparece = false;

        btnMaisCriature.gameObject.SetActive(aparece);
        ImagemDoAtaque(manager);
    }

    public void ImagemDoAtaque(CharacterManager manager)
    {
        GerenciadorDeGolpes gg = manager.CriatureAtivo.MeuCriatureBase.GerenteDeGolpes;
        imgDoAtaque.texture = elementosDoJogo.el.RetornaMini(gg.meusGolpes[gg.golpeEscolhido].Nome);
    }

    /// <summary>
    /// Desliga os Botoes do gameObject paramentro
    /// </summary>
    /// <param name="container">GameObject que terá todos os seus botoes desligados</param>
    public static void DesligarBotoes(GameObject container)
    {
        Button[] Bs = container.GetComponentsInChildren<Button>();

        foreach (Button B in Bs)
            B.interactable = false;
    }

    /// <summary>
    /// Religa os botoes do gameObject parametro
    /// </summary>
    /// <param name="G">GameObject que tera os botoes religados</param>
    public static void ReligarBotoes(GameObject G)
    {

        Button[] Bs = G.GetComponentsInChildren<Button>();

        foreach (Button B in Bs)
            B.interactable = true;
    }
}