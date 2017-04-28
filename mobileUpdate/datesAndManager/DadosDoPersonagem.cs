using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DadosDoPersonagem
{
    public List<CriatureBase> criaturesAtivos = new List<CriatureBase>();
    public List<CriatureBase> criaturesArmagedados = new List<CriatureBase>();
    public List<MbItens> itens = new List<MbItens>();
    public int criatureSai = 1;
    public int itemSai = 0;
    public int cristais = 1021;
    public int maxCarregaveis = 5;

    public void InicializadorDosDados()
    {
        criaturesAtivos = new List<CriatureBase>() {
             //new CriatureBase(nomesCriatures.Urkan,2),
             new CriatureBase(nomesCriatures.Florest,1),
             new CriatureBase(nomesCriatures.Arpia,2),
              new CriatureBase(nomesCriatures.Xuash,1),              
             //new CriatureBase(nomesCriatures.PolyCharm)
        };

        criaturesArmagedados = new List<CriatureBase>() {
             new CriatureBase(nomesCriatures.Urkan,2),
             new CriatureBase(nomesCriatures.Florest,1),
             new CriatureBase(nomesCriatures.Arpia,2),
              new CriatureBase(nomesCriatures.Xuash,1),              
             new CriatureBase(nomesCriatures.PolyCharm)
        };

        itens = new List<MbItens>()
        {
            PegaUmItem.Retorna(nomeIDitem.maca,1),
            PegaUmItem.Retorna(nomeIDitem.cartaLuva,11),
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
        for (int i = 0; i < criaturesAtivos.Count; i++)
        {
            if (criaturesAtivos[i].CaracCriature.meusAtributos.PV.Corrente > 0)
                retorno = true;
        }

        return retorno;
    }

    public void TodosCriaturesPerfeitos()
    {
        for (int i = 0; i < criaturesAtivos.Count; i++)
        {
            CriatureBase.EnergiaEVidaCheia(criaturesAtivos[i]);
        }
    }
}
