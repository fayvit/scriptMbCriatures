using UnityEngine;
using System.Collections;

public class abreBau : MonoBehaviour {

	public Transform tampa;
	public Transform dobradica;
	public armadilha temArmadilha = armadilha.nao;
	public temItem itemDoBau = new temItem(){quantidade = 2,nomeID = nomeIDitem.cristais};
	public string chaveBau = "bauTeste";
	public bool autoKey = false;

	private bool abrindo = false;
	private bool fechando = false;
	private Transform tHeroi;
	private movimentoBasico mB;
	private estadosBau estado = estadosBau.emEspera;
	private mensagemBasica mens;
	private string[] mensagensDeBau;
	private Menu menu;

	private enum estadosBau
	{
		emEspera,
		iniciouInteracao,
		mensDeJaPegou
	}

	public enum armadilha
	{
		nao,
		lancas,
		bomba,
		bombaDeFogo,
		bombaDeGas,
		congelante,
		acido,
		veneno,
		deAgua,
		eletrica
	}



	// Use this for initialization
	void Start () {

		if(autoKey)
			variaveisChave.vericaAutoKey(chaveBau);

		tHeroi = GameObject.FindWithTag("Player").transform;
		mB = tHeroi.GetComponent<movimentoBasico>();
		mensagensDeBau = bancoDeTextos.falacoes[heroi.lingua]["bau"].ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position,tHeroi.position)<2)
		{

			if(!pausaJogo.pause && !heroi.emLuta)
			{

				leituraDoBau();
			}
		}

		if(abrindo)
			if(Vector3.Angle(tampa.forward,transform.right)>10)
				tampa.RotateAround(dobradica.position,dobradica.up,75*Time.deltaTime);
			else
				abrindo = false;

		if(fechando)
			if(Vector3.Angle(tampa.forward,transform.up)>1)
				tampa.RotateAround(dobradica.position,dobradica.up,-75*Time.deltaTime);
		else
			fechando = false;
	}

	void leituraDoBau()
	{
		bool acao = Input.GetButtonDown("acao");
		bool menuEAux = Input.GetButtonDown("menu e auxiliar");
		bool acaoAlt = Input.GetButtonDown("acaoAlt");

		switch(estado)
		{
		case estadosBau.emEspera:
			if(mB.podeAndar==true && mB.enabled==true)
				if(acao||acaoAlt)
				{

					estado = estadosBau.iniciouInteracao;
					if(!mens)
						mens = gameObject.AddComponent<mensagemBasica>();

					mens.mensagem = mensagensDeBau[0];
					mens.entrando = true;

					if(!menu)
					{
						menu = gameObject.AddComponent<Menu>();
						menu.aMenu = 0.2f;
						menu.lMenu = 0.2f;
						
						menu.opcoes = bancoDeTextos.falacoes[heroi.lingua]["simOuNao"].ToArray();
						menu.posXalvo = 0.7f;
						menu.posYalvo = 0.4f;
						menu.skin = elementosDoJogo.el.skin;
						menu.Nome = "responde";
						menu.destaque = elementosDoJogo.el.destaque;
					}

					menu.podeMudar = true;
					menu.entrando = true;

					mB.pararOHeroi();
					mB.desabilitaCamera();
					mB.enabled = false;
				}
		break;
		case estadosBau.iniciouInteracao:
			if(acaoAlt && menu.dentroOuFora()>-1  )
				acao = true;

			if(acao)
			{
				if(menu.escolha==0)
					escolheuSim();
				else
					VoltaParaPasseio();
			}


			if(menuEAux)
				VoltaParaPasseio();
		break;
		case estadosBau.mensDeJaPegou:
			if(encontros.botoesPrincipais())
				VoltaParaPasseio();
		break;
		}
	}

	void depoisDaArmadilha()
	{
		if(variaveisChave.shift[chaveBau])
		{
			estado = estadosBau.mensDeJaPegou;
			mens.entrando = true;
			mens.mensagem = mensagensDeBau[1];
		}else
		{
			estado = estadosBau.mensDeJaPegou;
			mens.entrando = true;
			mens.mensagem = string.Format(mensagensDeBau[2],
			                              itemDoBau.quantidade.ToString(),
			                              item.nomeEmLinguas (itemDoBau.nomeID));

			variaveisChave.shift[chaveBau] = true;

			heroi H = mB.GetComponent<heroi>();

			if(itemDoBau.nomeID==nomeIDitem.cristais)
				H.cristais+=(uint)itemDoBau.quantidade;
			else
				shopBasico.adicionaItem(itemDoBau.nomeID,H,itemDoBau.quantidade);


		}
	}

	void voltaMens()
	{
		switch(temArmadilha)
		{
		case armadilha.nao:
			depoisDaArmadilha();
		break;
		}

	}

	void escolheuSim()
	{
		abrindo = true;
		menu.entrando = false;
		mens.entrando = false;
		Invoke("voltaMens",0.15f);
	}

	void VoltaParaPasseio()
	{
		fechando = true;
		abrindo = false;
		estado = estadosBau.emEspera;
		mB.enabled = true;
		mB.habilitaCamera();

		if(menu)
			Destroy(menu);
		if(mens)
			Destroy(mens);
	}
}

[System.Serializable]
public struct temItem
{
	public int quantidade ;
	public nomeIDitem nomeID ;
	
	public temItem(int q,nomeIDitem s)
	{
		quantidade = q;
		nomeID = s;
	}
}