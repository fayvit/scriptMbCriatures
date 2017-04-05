using UnityEngine;
using System.Collections;

[System.Serializable]
public class statusTemporario  {


	public float forcaDoDano = 1;
	public float tempoAteOProximoApply = 50;

	public tipoStatus esseStatus = tipoStatus.nulo;

	public statusTemporario(float forca,float tempo,tipoStatus tipo)
	{
		forcaDoDano = forca;
		tempoAteOProximoApply = tempo;
		esseStatus = tipo;
	}
}