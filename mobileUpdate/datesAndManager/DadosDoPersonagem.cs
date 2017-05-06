using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DadosDoPersonagem
{
    private List<CriatureBase> criaturesAtivos = new List<CriatureBase>();
    private List<CriatureBase> criaturesArmagedados = new List<CriatureBase>();
    private List<MbItens> itens = new List<MbItens>();
    private int criatureSai = 1;
    public int itemSai = 0;
    public int cristais = 1021;
    public int maxCarregaveis = 5;

    public List<CriatureBase> CriaturesAtivos
    {
        get { return criaturesAtivos; }
        set { criaturesAtivos = value; }
    }

    public List<CriatureBase> CriaturesArmagedados
    {
        get { return criaturesArmagedados; }
        set { criaturesArmagedados = value; }
    }

    public List<MbItens> Itens
    {
        get { return itens; }
        set { itens = value; }
    }

    public int CriatureSai
    {
        get
        {
            return criatureSai;
        }

        set
        {
            criatureSai = value;
        }
    }

    public void InicializadorDosDados()
    {
        CriaturesAtivos = new List<CriatureBase>() {
             //new CriatureBase(nomesCriatures.Urkan,2),
             new CriatureBase(nomesCriatures.Xuash,1),
             //new CriatureBase(nomesCriatures.Arpia,2),
              //new CriatureBase(nomesCriatures.Florest,1),              
             //new CriatureBase(nomesCriatures.PolyCharm)
        };

        CriaturesArmagedados = new List<CriatureBase>() {
             new CriatureBase(nomesCriatures.Urkan,2),
             new CriatureBase(nomesCriatures.Florest,1),
             new CriatureBase(nomesCriatures.Arpia,2),
              new CriatureBase(nomesCriatures.Xuash,1),              
             new CriatureBase(nomesCriatures.PolyCharm)
        };

        Itens = new List<MbItens>()
        {
            PegaUmItem.Retorna(nomeIDitem.maca,1),
            //PegaUmItem.Retorna(nomeIDitem.cartaLuva,11),
            PegaUmItem.Retorna(nomeIDitem.maca,2),
            PegaUmItem.Retorna(nomeIDitem.maca,3),
            PegaUmItem.Retorna(nomeIDitem.maca,93),
        };
        /*
        itens.Add(new item(nomeIDitem.maca) { estoque = 20 });
        itens.Add(new item(nomeIDitem.cartaLuva) { estoque = 3 });
        itens.Add(new item(nomeIDitem.pergArmagedom) { estoque = 7 });
        itens.Add(new item(nomeIDitem.pergSabre) { estoque = 5 });
        itens.Add(new item(nomeIDitem.pergSaida) { estoque = 5 });
        itens.Add(new item(nomeIDitem.pergGosmaDeInseto) { estoque = 8 });
        itens.Add(new item(nomeIDitem.pergGosmaAcida) { estoque = 8 });
        itens.Add(new item(nomeIDitem.pergMultiplicar) { estoque = 7 });
        itens.Add(new item(nomeIDitem.estatuaMisteriosa) { estoque = 1 });
        */


    }

    public bool TemCriatureVivo()
    {
        bool retorno = false;
        for (int i = 0; i < CriaturesAtivos.Count; i++)
        {
            if (CriaturesAtivos[i].CaracCriature.meusAtributos.PV.Corrente > 0)
                retorno = true;
        }

        return retorno;
    }

    public void TodosCriaturesPerfeitos()
    {
        for (int i = 0; i < CriaturesAtivos.Count; i++)
        {
            CriatureBase.EnergiaEVidaCheia(CriaturesAtivos[i]);
        }
    }

    public int TemItem(nomeIDitem nome)
    {
        int tanto = 0;
        for (int i = 0; i < Itens.Count; i++)
        {
            if (Itens[i].ID == nome)
                tanto += Itens[i].Estoque;
        }

        return tanto;
    }

    public void AdicionaItem(nomeIDitem nomeItem, int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            AdicionaItem(nomeItem);
        }
    }

    public void AdicionaItem(nomeIDitem nomeItem)
    {
        MbItens I = PegaUmItem.Retorna(nomeItem);
        bool foi = false;
        if (I.Acumulavel > 1)
        {

            int ondeTem = -1;
            for (int i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].ID == I.ID)
                {
                    if (Itens[i].Estoque < Itens[i].Acumulavel)
                    {
                        if (!foi)
                        {
                            ondeTem = i;
                            foi = true;
                        }
                    }
                }
            }

            if (foi)
            {
                Itens[ondeTem].Estoque++;
            }
            else
            {
                Itens.Add(PegaUmItem.Retorna(nomeItem));
            }
        }
        else
        {
            Itens.Add(PegaUmItem.Retorna(nomeItem));
        }
    }
}
