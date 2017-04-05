using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lutaDeCantoDeParede : encontros {

	// Use this for initialization{

	public string chaveDaLuta = "bauTeste";
	
	public temItem itemExtra = new temItem{quantidade = 0,nomeID = nomeIDitem.generico};
	public nomesCriatures encontradoDaqui;

	public int tipoDeEncontro = 1;
	public int nivelMin = 10;
	public int nivelMax = 12;

	public bool autoKey = false;

	private bool encontrou;
	private bool lutou;
	private bool recebendoItemExtra;

	private Collider meuColider;

	void Awake()
	{
		meuColider = GetComponent<Collider>();

		if(autoKey)
			variaveisChave.vericaAutoKey(chaveDaLuta);
	}
	
	protected override bool lugarSeguro()
	{
		if(encontrou && !lutou)
		{
			lutou = true;
			return false;
		}
		else
		{
			return true;
		}
	}
	
	protected override List<encontravel> listaEncontravel()
	{
		List<encontravel> L = new List<encontravel>(){new encontravel(encontradoDaqui,1.1f,nivelMin,nivelMax,tipoDeEncontro)};
		return L;
	}

	public override void voltarParaPasseio()
	{
		variaveisChave.shift[chaveDaLuta] = true;
		if(!recebendoItemExtra)
			{

			if(itemExtra.quantidade == 0)
			{
				base.voltarParaPasseio();
				GameObject.Find("Terrain").GetComponent<encontros>().enabled  = true;
			}
			else
			{
				mens = Camera.main.gameObject.AddComponent<mensagemBasica>();
				mens.mensagem = string.Format(textinhos[4],
				                              new cCriature(encontradoDaqui).criature().Nome,
				                              itemExtra.quantidade+" "+item.nomeEmLinguas(itemExtra.nomeID)
				                              );
				recebendoItemExtra = true;
			}
		}
	}

	new void Update()
	{

		if(!pausaJogo.pause){
			base.Update();

			if(recebendoItemExtra)
			{
				if(botoesPrincipais())
				{
					mens.fechaJanela();
					shopBasico.adicionaItem(itemExtra.nomeID,oHeroi.GetComponent<heroi>(),itemExtra.quantidade); 
					GameObject.Find("Terrain").GetComponent<encontros>().enabled  = true;
					base.voltarParaPasseio();
				}
			}
			if(heroi.emLuta)
				meuColider.enabled = false;
			else
				meuColider.enabled = true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!variaveisChave.shift[chaveDaLuta])
		{
			if(col.gameObject.tag == "Player" && this.enabled)
			{
				
				if(!encontrou)
				{
					proxEncontro = 0;
					encontrou = true;

					meuColider.enabled = false;
					
					GameObject.Find("Terrain").GetComponent<encontros>().enabled  = false;
				}
			}
		}else
			Destroy(gameObject);

	}
}