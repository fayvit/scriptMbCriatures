using System;
using UnityEngine;

[System.Serializable]
public class modificadorDeNivel{
	[SerializeField,HideInInspector]private uint _nivel;
	[SerializeField,HideInInspector]private uint _XP;
	[SerializeField,HideInInspector]private uint _paraProxNivel;
	[SerializeField,HideInInspector]private float _modNivel;
	[SerializeField,HideInInspector]private uint _ultimoPassaNivel;

	public modificadorDeNivel()
	{
		_nivel = 1;
		_XP = 0;
		_paraProxNivel = 40;
		_modNivel = 1.25f;
		_ultimoPassaNivel = 0;
	}

	public uint Nivel
	{
		get{return _nivel;}
		set{_nivel = value;}
	}

	public uint XP
	{
		get{return _XP;}
		set{_XP = value;}
	}

	public uint ParaProxNivel
	{
		get{return _paraProxNivel;}
		set{_paraProxNivel = value;}
	}

	public void calculaUpDeNivel(int esseNivel,atributos[] A,bool total = false)
	{
		//float[] taxas = new float[5]{0.15f,0.25f,0.25f,0.15f,0.2f};//taxas fantasia para testes;
		float[] taxas = new float[5]{
			A[0].Taxa,
			A[1].Taxa,
			A[2].Taxa,
			A[3].Taxa,
			A[4].Taxa
		};
		float[] pontosAcumulados = new float[5]{1,1,1,1,1};
		float[] antigoAcumulado= new float[5]{0,0,0,0,0};

		//antigoAcumulado = (float[])pontosAcumulados.Clone();

//		int somaDosInteiros;
		for(int i=1;i<esseNivel;i++)
		{

			antigoAcumulado = (float[])pontosAcumulados.Clone();
		//for(int k=0;k<pontosAcumulados.Length;k++)
		//	antigoAcumulado[k] = pontosAcumulados[k];

//		Debug.Log(antigoAcumulado);

			for(int j=0;j<taxas.Length;j++)
			{
				pontosAcumulados[j] = (i+1)*5*taxas[j];

			}

//			Debug.Log(SomaDosInteiros(pontosAcumulados)%5);
			float[] queRolo = SobraAosEleitos(SomaDosInteiros((float[])pontosAcumulados.Clone())%5,
			                                  (float[])pontosAcumulados.Clone());

			for(int j=0;j<taxas.Length;j++){
				//Debug.Log(pontosAcumulados[j]+" : "+(int)pontosAcumulados[j]+" : "+queRolo[j]  );
				pontosAcumulados[j] = (int)pontosAcumulados[j]+queRolo[j];
			}
/*
			for(int j=0; j<pontosAcumulados.Length;j++)
				Debug.Log("Nivel: "+i+
				          " pontosAcumulados: "+pontosAcumulados[j]+
				          " diferança de Nivel: "+(pontosAcumulados[j]-antigoAcumulado[j]));

*/

		}

		if(total)
			atualizaAtributos(pontosAcumulados,A,total);
		else
		{
			for(int j=0; j<pontosAcumulados.Length;j++)
				pontosAcumulados[j]-=antigoAcumulado[j];

//			Debug.Log(pontosAcumulados[0]+" : cade eu");
			atualizaAtributos(pontosAcumulados,A,total);
		}




//		Debug.Log(somaDosInteiros);

	}

	void atualizaAtributos(float[] pontinhos,atributos[] A,bool total = false)
	{
		if(total)
		{
			for(int i=0;i<A.Length;i++)
			{
				if(i<2)
				{
//					Debug.Log(A[i].Maximo+" : "+A[i].Nome+" : "+(uint)(Mathf.RoundToInt((A[i].Maximo)/4)));
					A[i].Basico = (uint)pontinhos[i]+(uint)Mathf.RoundToInt((A[i].Maximo)/4-1);
//					Debug.Log(A[i].Basico+" : "+A[i].Basico*4+" : "+pontinhos[i]);
					A[i].Corrente = (uint)pontinhos[i]*4+A[i].Corrente-4;
					A[i].Maximo = (uint)pontinhos[i]*4+A[i].Maximo-4;
					
				}else
				{
					if(pontinhos[i]>5)
					{
						A[i].Basico = A[i].padrao()-1+(uint)(pontinhos[i]-5);
						A[i].Corrente =A[i].padrao()-1+ (uint)pontinhos[i];
						A[i].Maximo = A[i].padrao()-1+(uint)(pontinhos[i]+5);
					}else
					{
						A[i].Basico = A[i].padrao();
						A[i].Corrente = A[i].padrao()-1+(uint)pontinhos[i];
						A[i].Maximo = A[i].padrao()-1+(uint)(2*pontinhos[i]-1);
					}


				}
			}
		}else
		{
			int j=0;
			for(int i=0;i<A.Length;i++)
			{
				if(i<2)
				{

					A[i].Basico = A[i].Maximo/4 + (uint)pontinhos[i];
					A[i].Corrente += (uint)pontinhos[i]*4;
					A[i].Maximo = A[i].Basico*4;
				}else
				{
					if(pontinhos[i]>0)
					{
						j=0;
						while(j<pontinhos[i])
						{
							if((A[i].Basico+A[i].Maximo)/2+1>5)
							{
								A[i].Basico ++;
								A[i].Corrente ++;
								A[i].Maximo ++;
							}else
							{
								A[i].Basico = 1;
								A[i].Corrente ++;
								A[i].Maximo = (A[i].Basico+A[i].Maximo)+1;
							}
							j++;
						}
					}
				}
			}
		}
/*
		for(int  i=0;i<5;i++)
			Debug.Log(A[i].Basico+" : "+pontinhos[i]+" :"+A[i].Corrente+" : "+A[i].Maximo);
*/
	}

	float[] SobraAosEleitos(int distribuidos,float[] pegaRestos)
	{
		int aDistribuir = (distribuidos==0)?0:5 - distribuidos;
		if(aDistribuir>0)
		{
			for(int i=0;i<pegaRestos.Length;i++)
				pegaRestos[i] -=(int)pegaRestos[i]; 

			int j;
			float[][] ordenaMaiores = new float[5][];
			float[] temp;
			for(int i=0;i<pegaRestos.Length;i++)
			{
				ordenaMaiores[i] = new float[2]{i,pegaRestos[i]};
				j = i;
				if(j>0)
				while(j>0 && ordenaMaiores[j][1] >= ordenaMaiores[j-1][1])
				{
					temp = ordenaMaiores[j];
					ordenaMaiores[j] = ordenaMaiores[j-1];
					ordenaMaiores[j-1] = temp;
					j--;
				}
			}

			/*

			for(int i=0;i<pegaRestos.Length;i++)
				Debug.Log(ordenaMaiores[i][0]);

*/
			pegaRestos = new float[5]{0,0,0,0,0};

			for(int i=0;i<aDistribuir;i++){
//				Debug.Log(ordenaMaiores[i][0]+" : "+aDistribuir);
				pegaRestos[(int)ordenaMaiores[i][0]] = 1;
			}

		}else
			pegaRestos = new float[5]{0,0,0,0,0};
		

		return pegaRestos;
	}

	int SomaDosInteiros(float[] X)
	{
		int Z = 0;
		for(int i=0;i<X.Length;i++)
			Z+=(int)(X[i]);
		return Z;
	}

	public bool verificaPassaNivel(atributos[] A)
	{
		bool retorno = _XP >= _paraProxNivel;
		if(retorno)
		{
			_nivel++;
			uint U = calculaPassaNivelAtual();
			_ultimoPassaNivel=_paraProxNivel;
			_paraProxNivel += U;
			calculaUpDeNivel((int) _nivel , A);
		}

		return retorno;
	}

	public void simulaPassaNivel(atributos[] A)
	{
		for(int i=0;i<99;i++)
		{
			verificaPassaNivel(A);
			_XP = _paraProxNivel+1;
			Debug.Log(_nivel+" : "+_XP+"/"+_paraProxNivel+" : "+_ultimoPassaNivel
			          +" : "+calculaPassaNivelInicial(_nivel,true));
		}
	}

	public uint calculaPassaNivelInicial(uint N,bool tudo = false)
	{
		uint retorno = 0;
		uint XparaProxNivel = 40;
		uint XultimoPassaNivel = 0;

		for(int i=0;i<N;i++)
		{
			XultimoPassaNivel = retorno;
			retorno = XparaProxNivel;
			XparaProxNivel +=  (uint)(Math.Floor (_modNivel * (XparaProxNivel - XultimoPassaNivel)));


		}
		return tudo ? retorno : retorno-XultimoPassaNivel;
	}
		/*
	{
		uint novoPassaNivel = _paraProxNivel;
		uint aux;
		uint ultimoPassaNivel = 0;
		for(uint i=1;i < N ;i++)
		{
			aux = novoPassaNivel;
			novoPassaNivel = (uint)(Math.Floor ( _modNivel*(novoPassaNivel - ultimoPassaNivel)));
			ultimoPassaNivel = aux;
			Debug.Log("nosPassaNivel"+ultimoPassaNivel+" : "+novoPassaNivel);
		}

		return tudo ? novoPassaNivel : novoPassaNivel - ultimoPassaNivel;
	}*/

	public uint calculaPassaNivelAtual()
	{
		return (uint)(Math.Floor (_modNivel * (_paraProxNivel - _ultimoPassaNivel)));
	}

}
