using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Criature : caracteristicasBasicas {
	public string Nome;
	public nomesCriatures nomeID;
	public modificadorDeNivel mNivel;
	public tipos[] contraTipos;
	public string[] meusTipos;
	public atributos[] cAtributos;
	public string emissor;
	public golpe[] Golpes;


	public float tempoReacaoBasico = 2f;
	public float tempoReacaoCorrente = 2f;
	public float tempoReacaoMinimo = 2f;


	public Dictionary<nomesGolpes,colisor> colisores = new Dictionary<nomesGolpes,colisor>();
	public Dictionary<nomesGolpes,float> distanciaEmissora = new Dictionary<nomesGolpes,float>();
	public Dictionary<nomesGolpes,float> tempoDeInstancia = new Dictionary<nomesGolpes,float>();
	public Dictionary<nomesGolpes,float> acimaDoChao = new Dictionary<nomesGolpes,float>();
	public List<statusTemporario> statusTemporarios = new List<statusTemporario>();
	public int golpeEscolhido = 0;

	protected nivelGolpe[] listaDeGolpes;

    [SerializeField]private CaracteristicasDeMovimentacao mov;

    public CaracteristicasDeMovimentacao Mov
    {
        get { mov = new CaracteristicasDeMovimentacao() {
            velocidadeAndando = this.velocidadeAndando,
            caracPulo = new CaracteristicasDePulo()
            {
                alturaDoPulo = this.apiceDoPulo,
                velocidadeSubindo = this.velocidadeSubindo,
                velocidadeDuranteOPulo = this.velocidadeNoAr,
                velocidadeDescendo = this.velocidadeCaindo,
                amortecimentoNaTransicaoDePulo = 0.75f,
                impulsoInicial = this.distanciaFundamentadora
            }
        };
            return mov;
        }
        
    }

    public Criature()
	{
		//Debug.Log("bugadaço");
		contraTipos = new tipos[Enum.GetValues(typeof(nomeTipos)).Length];
		
		for(int cnt = 0; cnt < contraTipos.Length; cnt++)
		{
			contraTipos[cnt] = new tipos();
			contraTipos[cnt].Nome= ((nomeTipos)cnt).ToString();
		}

		mNivel = new modificadorDeNivel ();
		
		cAtributos = new atributos[Enum.GetValues(typeof(nomesAtributos)).Length];
		for(int cnt = 0; cnt<cAtributos.Length;cnt++)
		{
			cAtributos[cnt] = new atributos();
			cAtributos[cnt].Nome = ((nomesAtributos)cnt).ToString();
			cAtributos[cnt].Basico = cAtributos[cnt].padrao()>1
				?(uint)Mathf.RoundToInt(cAtributos[cnt].padrao()/4)
					:1;
			cAtributos[cnt].Corrente = cAtributos[cnt].padrao();
			cAtributos[cnt].Maximo = cAtributos[cnt].padrao();

//			Debug.Log(cnt+" : "+cAtributos[cnt].padrao());
		}
	}


	public nivelGolpe verificaNovoGolpe(){
		/*
			Essa linha e responsavel por atualizar a lista de golpes a media que golpes forem sendo 
			criados e inseridos na lista

			Uma coisa chata que ocorria e que, os Criatures durante o jogo tinham a lista de golpes 
			de quando o jogo foi iniciado, ao atualizar o jogo, atualizando as listas de golpes
			inserindo novos golpes, as passagens de nivel nao tinham os 
			golpes criados posteriormente

			enquanto nao encontrar soluçao melhor, a melhor coisa e atualizar a lista cada vez que 
			for necessario procurar novos golpes.
		 */

		listaDeGolpes = new cCriature(nomeID).criature().listaDeGolpes;

		/*			-----------------------------------------------			*/


		nivelGolpe retorno = new nivelGolpe(-1,nomesGolpes.nulo,0,0);
		for(int i=0;i<listaDeGolpes.Length;i++)
		{
			if(listaDeGolpes[i].nivel == mNivel.Nivel){
				retorno = listaDeGolpes[i];
			}
		}
		return retorno;
	}

	public nivelGolpe GolpeNaLista(nomesGolpes[] nomeDoGolpe)
	{
		listaDeGolpes = new cCriature(nomeID).criature().listaDeGolpes;
		
		/*			-----------------------------------------------			*/
		
		
		nivelGolpe retorno = new nivelGolpe(-1,nomesGolpes.nulo,0,0);
		for(int j=0;j<nomeDoGolpe.Length;j++)
			for(int i=0;i<listaDeGolpes.Length;i++)
			{
				if(listaDeGolpes[i].nome == nomeDoGolpe[j]){
					retorno = listaDeGolpes[i];
				}
			}
		return retorno;
	}

	public bool NosMeusGolpes(nomesGolpes[] esseGolpe)
	{
		bool retorno = false;
		for(int i=0;i<esseGolpe.Length;i++)
			if(!retorno)
				retorno = NosMeusGolpes(esseGolpe[i]);

		return retorno;
	}

	public bool NosMeusGolpes(nomesGolpes esseGolpe)
	{
		bool retorno = false;
		for(int i=0;i<Golpes.Length;i++)
			if(Golpes[i].nomeID == esseGolpe)
				retorno = true;

		return retorno;
	}

	protected void incrementaNivel(uint nivel)
	{

		mNivel.calculaUpDeNivel((int)nivel,cAtributos,true);
		mNivel.Nivel = nivel;
		mNivel.ParaProxNivel = mNivel.calculaPassaNivelInicial(nivel);

	}

	protected golpe[] golpesAtivos(uint nivel,nivelGolpe[] listaGolpes)
	{
		List<nivelGolpe> L = new List<nivelGolpe> ();
		int i = 0;
		//int N = -1;
		while(i<listaGolpes.Length)
		{ 
			if(listaGolpes[i].nivel<=nivel && listaGolpes[i].nivel>-1){
				if(L.Count<4)
					L.Add(listaGolpes[i]);
				else
				{
					L[0] = L[1];
					L[1] = L[2];
					L[2] = L[3];
					L[3] = listaGolpes[i];
				}
			}
			i++;
		}

		golpe[] Y = new golpe[L.Count];
		for(i = 0;i<L.Count;i++)
		{
			Y[i] = new pegaUmGolpe(L[i].nome).OGolpe();
			Y[i].taxaDeUso = L[i].taxaDeUso;
			Y[i].mod = L[i].mod;
		}



		return Y;
	}

	}


[Serializable]
public struct nivelGolpe
{
	public int nivel;
	public nomesGolpes nome;
	public int mod;
	public float taxaDeUso;
	public nivelGolpe(int _nv,nomesGolpes _nome,int _mod,float tax)
	{
		nivel = _nv;
		nome = _nome;
		mod = _mod;
		taxaDeUso = tax;
	}
}


[Serializable]
public struct colisor
{
	public string osso;
	/*
	[NonSerializedAttribute]
	public Vector3 deslColisor;
	[NonSerializedAttribute]
	public Vector3 deslTrail;
*/

	private float dCx;
	private float dCy;
	private float dCz;

	private float dTx;
	private float dTy;
	private float dTz;


	public colisor(string _osso="",Vector3 _deslColisor = default(Vector3) ,Vector3 _deslTrail = default(Vector3))
	{
		osso = _osso;
		dCx = _deslColisor.x;
		dCy = _deslColisor.y;
		dCz = _deslColisor.z;

		dTx = _deslTrail.x;
		dTy = _deslTrail.y;
		dTz = _deslTrail.z;
	}

	public Vector3 deslColisor
	{
		get{return new Vector3(dCx,dCy,dCz);}
		set{Vector3 dC = value;
			dCx = dC.x;
			dCy = dC.y;
			dCz = dC.z;
		}
	}

	public Vector3 deslTrail
	{
		get{return new Vector3(dTx,dTy,dTz);}
		set{Vector3 dC = value;
			dTx = dC.x;
			dTy = dC.y;
			dTz = dC.z;
		}
	}
}
