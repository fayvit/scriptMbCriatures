using UnityEngine;
using System.Collections;

[System.Serializable]
public class CaracteristicasDeCriature
{
    public nomeTipos[] meusTipos;
    public tipos[] contraTipos;    
    public Atributos meusAtributos = new Atributos(new ContainerDeAtributos());
    public IGerenciadorDeExperiencia mNivel = new GerenciadorDeExperiencia();
    public float distanciaFundamentadora = 0.2f;

    public void incrementaNivel(int nivel)
    {
        UpDeNivel.calculaUpDeNivel(nivel, meusAtributos,true);

        mNivel.Nivel = nivel;
        mNivel.ParaProxNivel = mNivel.CalculaPassaNivelInicial(nivel);

    }
}
