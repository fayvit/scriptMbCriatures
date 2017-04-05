using UnityEngine;
using System.Collections;

public class gerenciadorDoFinalAlpha010 : verificaTrocaMens {

	public Transform[] meusTransforms;
	public GameObject canvas;

	private Vector3[] posicoes;
	private bool terminou;
	private float tempoDecorrido = 0;
	private pretoMorte p;
	private fasesDoFim fase = fasesDoFim.escurecendo;

	private enum fasesDoFim
	{
		maisUmBotao,
		escurecendo,
		clarear,
		visiteAPaginaOuFim,
	}


	// Use this for initialization
	void Start () {
		posicoes = new Vector3[meusTransforms.Length];
		for(int i=0;i<meusTransforms.Length;i++)
		{
			posicoes[i] = meusTransforms[i].position;
		}
		mens = gameObject.AddComponent<mensagemBasica>();
		essaConversa = bancoDeTextos.falacoes[heroi.lingua]["encerraAlpha0.0.1"].ToArray();
		mens.mensagem = essaConversa[0];
	}

	void organizaPosicoes(int pos)
	{
		meusTransforms[pos].position = Vector3.Lerp(
			meusTransforms[pos].position,
			new Vector3(0,1,-5),
			Time.deltaTime);
		meusTransforms[pos].rotation = Quaternion.Lerp(
			meusTransforms[pos].rotation,
			Quaternion.LookRotation(Vector3.forward),
			Time.deltaTime
			);

		for(int i=0;i<4;i++)
		{
			int num = (3*pos+i)%4;
			if(i!=pos)
			{
				meusTransforms[i].position = Vector3.Lerp(
					meusTransforms[i].position,
					posicoes[num],
					Time.deltaTime);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(mensagemAtual+1<essaConversa.Length)
			facaTrocaMens();
		else
		{
			switch(fase)
			{
			case fasesDoFim.escurecendo:
				if(encontros.botoesPrincipais())
				{
					p = gameObject.AddComponent<pretoMorte>();
					fase  = fasesDoFim.clarear;
					mens.entrando = false;
				}
			break;
			case fasesDoFim.clarear:
				tempoDecorrido+=Time.deltaTime;
				if(tempoDecorrido>2)
				{
					p.entrando = false;
					fase = fasesDoFim.visiteAPaginaOuFim;
					tempoDecorrido = 0;
					canvas.SetActive(true);
				}
			break;
			case fasesDoFim.visiteAPaginaOuFim:
				tempoDecorrido+=Time.deltaTime;
				if(tempoDecorrido>1f)
				{
					if(Input.GetButtonDown("menu e auxiliar"))
						Application.LoadLevel("saveAndLoad");
				}
			break;
			}
		}

		switch(mensagemAtual)
		{
		case 3:
		case 4:
			organizaPosicoes(0);
		break;
		case 5:
		case 6:
		case 7:
			organizaPosicoes(1);
		break;
		case 8:
		case 9:
		case 10:
			organizaPosicoes(2);
		break;
		case 11:
		case 12:
			organizaPosicoes(3);
		break;
		}
	}

	public void paginaDoCriatures()
	{
		Application.OpenURL("https://www.facebook.com/criaturesDeOrion/?ref=bookmarks");
	}

	public void paginaIvan()
	{
		Application.OpenURL("https://www.facebook.com/ivan.fayvit?ref=ts&fref=ts");
	}
}
