﻿using UnityEngine;
using System.Collections;

public class EncounterManager
{
    private float contadorDeTempo = 0;
    private AplicadorDeCamera cam;
    private ApresentadorDeAdversario apresentaAdv;
    private ApresentaFim apresentaFim;
    private ApresentaDerrota apresentaDerrota;
    private CreatureManager inimigo;
    private CharacterManager manager;
    private EncounterState estado = EncounterState.emEspera;
    private Atributos aDoI;
    private Atributos aDoH;


    private enum EncounterState
    {
        emEspera,
        truqueDeCamera,
        apresentaAdversario,
        comecaLuta,
        verifiqueVida,
        vitoriaNaLuta,
        VoltarParaPasseio,
        morreuEmLuta,
        fimDaApresentacaoDaMorte,
        irParaDepoisDaMorte,
        passouDeNivel,
        gerenciaGolpe,
        aprendeuEsse
            // O 13 era aprendendo golpe fora, deverá ser feito separadamente
    }

    public CreatureManager Inimigo
    {
        get { return inimigo; }
    }

    public void InicializarEncounterManager(CreatureManager inimigo,CharacterManager manager)
    {
        this.inimigo = inimigo;    
        this.manager = manager;

        VerificaContainerDeAtributos();

        apresentaAdv = new ApresentadorDeAdversario(inimigo);
        estado = EncounterState.truqueDeCamera;
    }

    public bool Update()
    {
        bool retorno = false;
        switch (estado)
        {
            case EncounterState.truqueDeCamera:
                TruqueDeCamera();
            break;
            case EncounterState.apresentaAdversario:
                contadorDeTempo += Time.deltaTime;
                if (apresentaAdv.Apresenta(contadorDeTempo, cam))
                    depoisDeTerminarAApresentacao();
            break;
            case EncounterState.comecaLuta:
                GameController.g.HudM.InicializaHudDeLuta(inimigo.MeuCriatureBase);
                ((IA_Agressiva)inimigo.IA).PodeAtualizar = true;
                manager.CriatureAtivo.Estado = CreatureManager.CreatureState.emLuta;
                cam.InicializaCameraDeLuta(manager.CriatureAtivo,inimigo.transform);
                cam.enabled = true;
                estado = EncounterState.verifiqueVida;
            break;
            case EncounterState.verifiqueVida:
                GameController.g.HudM.AtualizeHud(manager, inimigo.MeuCriatureBase);
                VerifiqueVida();                
            break;
            case EncounterState.vitoriaNaLuta:
                if (!apresentaFim.EstouApresentando())
                {
                    RecebePontosDaVitoria();
                }
            break;
            case EncounterState.VoltarParaPasseio:
                MonoBehaviour.Destroy(inimigo.gameObject);
                cam.FocarBasica(manager.transform,10,10);
                estado = EncounterState.emEspera;
                retorno = true;                
            break;
            case EncounterState.morreuEmLuta:
                apresentaDerrota.Update();
            break;
        }
        return retorno;
    }

    void VoltarParaPasseio()
    {
        //mbemben
    }

    void RecebePontosDaVitoria()
    {
        IGerenciadorDeExperiencia G_XP = manager.CriatureAtivo.MeuCriatureBase.CaracCriature.mNivel;
        G_XP.XP += (int)((float)aDoI.PV.Maximo/2);
        if (G_XP.VerificaPassaNivel())
        {
            estado = EncounterState.passouDeNivel;
        }
        else
            estado = EncounterState.VoltarParaPasseio;

        manager.Dados.cristais += aDoI.PV.Maximo;
    }

    protected void VerifiqueVida()
    {
        VerificaContainerDeAtributos();

        contadorDeTempo = 0;

        if (aDoI.PV.Corrente <= 0 && aDoH.PV.Corrente > 0)
        {
           UmaVitoria();
        }

        if (aDoH.PV.Corrente <= 0)
            UmaDerrota();

    }

    void UmaDerrota()
    {
        InterrompeFluxoDeLuta();
        inimigo.Estado = CreatureManager.CreatureState.parado;
        apresentaDerrota = new ApresentaDerrota(manager, inimigo);
        estado = EncounterState.morreuEmLuta;
    }

    public void VerificaContainerDeAtributos()
    {
        aDoI = inimigo.MeuCriatureBase.CaracCriature.meusAtributos;
        aDoH = manager.CriatureAtivo.MeuCriatureBase.CaracCriature.meusAtributos;
    }

    void UmaVitoria()
    {
        InterrompeFluxoDeLuta();
        apresentaFim = new ApresentaFim(manager.CriatureAtivo, inimigo, cam);
        estado = EncounterState.vitoriaNaLuta;   
    }

    void InterrompeFluxoDeLuta()
    {
        manager.CriatureAtivo.Estado = CreatureManager.CreatureState.parado;
    }

    protected virtual void depoisDeTerminarAApresentacao()
    {
        estado = EncounterState.comecaLuta;
    }

    void TruqueDeCamera()
    {
        contadorDeTempo += Time.deltaTime;
        if (contadorDeTempo > 0.5f)
        {
            estado = EncounterState.apresentaAdversario;
            cam = MonoBehaviour.FindObjectOfType<AplicadorDeCamera>();
            cam.enabled = false;            
            contadorDeTempo = 0;
        }
    }
}