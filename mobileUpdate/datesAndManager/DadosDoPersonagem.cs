using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DadosDoPersonagem
{
    public List<CriatureBase> criaturesAtivos = new List<CriatureBase>();
    public List<CriatureBase> criaturesArmagedados = new List<CriatureBase>();
    public List<item> itens = new List<item>();
    public int criatureSai = 1;
    public int itemSai = 0;
    public int cristais = 1021;

    public void InicializadorDosDados()
    {
        criaturesAtivos = new List<CriatureBase>() {
             new CriatureBase(nomesCriatures.Florest),
              new CriatureBase(nomesCriatures.Xuash),
              new CriatureBase(nomesCriatures.Xuash),
             new CriatureBase(nomesCriatures.Florest)
        };

        itens.Add(new item(nomeIDitem.maca) { estoque = 20 });
        itens.Add(new item(nomeIDitem.cartaLuva) { estoque = 3 });
        itens.Add(new item(nomeIDitem.pergArmagedom) { estoque = 7 });
        itens.Add(new item(nomeIDitem.pergSabre) { estoque = 5 });
        itens.Add(new item(nomeIDitem.pergSaida) { estoque = 5 });
        itens.Add(new item(nomeIDitem.pergGosmaDeInseto) { estoque = 8 });
        itens.Add(new item(nomeIDitem.pergGosmaAcida) { estoque = 8 });
        itens.Add(new item(nomeIDitem.pergMultiplicar) { estoque = 7 });
        itens.Add(new item(nomeIDitem.estatuaMisteriosa) { estoque = 1 });


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
}
