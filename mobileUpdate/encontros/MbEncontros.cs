﻿using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MbEncontros
{
    [SerializeField]private int minEncontro = 50;
    [SerializeField]private int maxEncontro = 300;
    [SerializeField]private float andado = 0;
    [SerializeField]private float proxEncontro = 100;

    private Vector3 posHeroi;
    private Vector3 posAnterior = Vector3.zero;
    private CharacterManager manager;
    private encontravel encontrado;
    private EncounterManager gerenteDeEncontro;
    private bool luta = false;

    public bool Luta
    {
        get{return luta;}
    }

    public Transform InimigoAtivo
    {
        get { return gerenteDeEncontro.Inimigo.transform; }
    }
    // Use this for initialization
    public void Start()
    {
        manager = MonoBehaviour.FindObjectOfType<CharacterManager>();
        posAnterior = manager.transform.position;
        gerenteDeEncontro = new EncounterManager();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!pausaJogo.pause)
        {
            
            if (!luta)
                posHeroi = manager.transform.position;

            //  if (!heroiMB)
            //    heroiMB = tHeroi.GetComponent<movimentoBasico>();

            if (!lugarSeguro() && !luta && comandos.noChaoS(manager.Mov.Controle,0.01f))
            {
                andado += (posHeroi - posAnterior).magnitude;
                posAnterior = posHeroi;
            }


            if (!luta && andado >= proxEncontro)
            {
                
                proxEncontro = SorteiaPassosParaEncontro();                
                encontrado = criatureEncontrado();
                InsereElementosDoEncontro.encontroPadrao(manager);
                gerenteDeEncontro.InicializarEncounterManager(InsereInimigoEmCampo.RetornaInimigoEmCampo(encontrado, manager),manager);  
                luta = true;
                andado = 0;
            }

            if (gerenteDeEncontro.Update() && luta)
            {
                
                RetornaParaModoPasseio();
            }


            Debug.DrawRay(posHeroi - 40f * manager.transform.forward, 1000f * Vector3.up, Color.yellow);
        }
    }

    void RetornaParaModoPasseio()
    {
        MonoBehaviour.Destroy(GameObject.Find("cilindroEncontro"));
        luta = false;
        heroi.emLuta = false;
        manager.BotaoAlternar();        
        manager.transform.position = posHeroi;
    }

    protected virtual bool lugarSeguro()
    {
        return false;
    }

    protected float SorteiaPassosParaEncontro()
    {
        return Random.Range(minEncontro, maxEncontro);
    }

    protected virtual List<encontravel> listaEncontravel()
    {
        return new List<encontravel>() { new encontravel(nomesCriatures.Florest,1)};
    }

    encontravel criatureEncontrado()
    {
        List<encontravel> encontraveis = listaEncontravel();//secaoEncontravel[IndiceDoLocal()];
        float maiorAleatorio = 0;
        for (int i = 0; i < encontraveis.Count; i++)
        {
            maiorAleatorio += encontraveis[i].taxa;
        }
        //		print(maiorAleatorio);
        float roleta = Random.Range(0, maiorAleatorio);
        //		print(roleta);
        float sum = 0;
        int retorno = -1;
        for (int i = 0; i < encontraveis.Count; i++)
        {
            sum += encontraveis[i].taxa;

            if (roleta <= sum && retorno == -1)
                retorno = i;
        }

        return encontraveis[retorno];
    }


    /*
    Funções originalmente criadas para testes
        */

    #region TestRegion
    public void ZerarPassosParaProxEncontro()
    {
        proxEncontro = 0;
    }

    public void ColocarUmPvNoInimigo()
    {
        gerenteDeEncontro.Inimigo.MeuCriatureBase.CaracCriature.meusAtributos.PV.Corrente = 1;
    }

    #endregion
}