using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planicieDeInfinity : encontros {
	
	private readonly List<List<encontravel>> secaoEncontravel = new List<List<encontravel>>()
	{new List<encontravel>()// indice zero
		{
			new encontravel(nomesCriatures.Arpia,4),
			new encontravel(nomesCriatures.Wisks,1),
			new encontravel(nomesCriatures.Escorpion,1.5f),
			new encontravel(nomesCriatures.Iruin,1.5f),
			new encontravel(nomesCriatures.Marak,1.5f),
			new encontravel(nomesCriatures.Babaucu,0.5f)
		},
		new List<encontravel>()//indice 1
		{
			new encontravel(nomesCriatures.Arpia,1.2f),
			new encontravel(nomesCriatures.Escorpion,1.2f),
			new encontravel(nomesCriatures.Iruin,1.4f),
			new encontravel(nomesCriatures.Marak,1.2f),
			new encontravel(nomesCriatures.Wisks,1),
			new encontravel(nomesCriatures.Babaucu,5f)
		},
		new List<encontravel>()//indice 2
		{
			new encontravel(nomesCriatures.Arpia,1.9f),
			new encontravel(nomesCriatures.Escorpion,1.9f),
			new encontravel(nomesCriatures.Iruin,1.4f),
			new encontravel(nomesCriatures.Marak,1.4f),
			new encontravel(nomesCriatures.Wisks,0.9f),
			new encontravel(nomesCriatures.Babaucu,2.5f)
		},
		new List<encontravel>()//indice 3
		{
			new encontravel(nomesCriatures.Arpia,2f),
			new encontravel(nomesCriatures.Escorpion,2f),
			new encontravel(nomesCriatures.Iruin,1.5f),
			new encontravel(nomesCriatures.Marak,1.5f),
			new encontravel(nomesCriatures.Babaucu,2.5f),
			new encontravel(nomesCriatures.PolyCharm,0.5f)
		},
		new List<encontravel>()//indice 4
		{
			new encontravel(nomesCriatures.Arpia,1.8f),
			new encontravel(nomesCriatures.Escorpion,1.8f),
			new encontravel(nomesCriatures.Iruin,1.4f),
			new encontravel(nomesCriatures.Marak,1.4f),
			new encontravel(nomesCriatures.Babaucu,1.8f),
			new encontravel(nomesCriatures.Aladegg,1f),
			new encontravel(nomesCriatures.Wisks,0.8f)
		},
		new List<encontravel>()//indice 5
		{
			new encontravel(nomesCriatures.Arpia,1.4f),
			new encontravel(nomesCriatures.Escorpion,1.65f),
			new encontravel(nomesCriatures.Iruin,1.65f),
			new encontravel(nomesCriatures.Marak,1.65f),
			new encontravel(nomesCriatures.Babaucu,0.9f),
			new encontravel(nomesCriatures.Aladegg,1.15f),
			new encontravel(nomesCriatures.Wisks,0.7f),
			new encontravel(nomesCriatures.Onarac,0.9f)
		},
		new List<encontravel>()//indice 6
		{
			new encontravel(nomesCriatures.Arpia,1.5f),
			new encontravel(nomesCriatures.Escorpion,1.75f),
			new encontravel(nomesCriatures.Iruin,1.75f),
			new encontravel(nomesCriatures.Marak,1.5f),
			new encontravel(nomesCriatures.Babaucu,1f),
			new encontravel(nomesCriatures.Aladegg,1.25f),
			new encontravel(nomesCriatures.Onarac,1f),
			new encontravel(nomesCriatures.Steal,0.25f)
		},
		new List<encontravel>()//indice 7
		{
			new encontravel(nomesCriatures.Arpia,1.5f),
			new encontravel(nomesCriatures.Escorpion,1.5f),
			new encontravel(nomesCriatures.Iruin,1.75f),
			new encontravel(nomesCriatures.Marak,1.5f),
			new encontravel(nomesCriatures.Babaucu,1f),
			new encontravel(nomesCriatures.Aladegg,1.25f),
			new encontravel(nomesCriatures.Onarac,1f),
			new encontravel(nomesCriatures.Florest,0.5f)
		},
		new List<encontravel>()//indice 8
		{
			new encontravel(nomesCriatures.Arpia,1.5f),
			new encontravel(nomesCriatures.Escorpion,1.5f),
			new encontravel(nomesCriatures.Iruin,1.75f),
			new encontravel(nomesCriatures.Marak,1.5f),
			new encontravel(nomesCriatures.Babaucu,1f),
			new encontravel(nomesCriatures.Aladegg,1.25f),
			new encontravel(nomesCriatures.Onarac,1f),
			new encontravel(nomesCriatures.Xuash,0.5f)
		},
		new List<encontravel>()//indice 9
		{
			new encontravel(nomesCriatures.Arpia,1.5f),
			new encontravel(nomesCriatures.Escorpion,1.5f),
			new encontravel(nomesCriatures.Iruin,1.25f),
			new encontravel(nomesCriatures.Marak,1.5f),
			new encontravel(nomesCriatures.Babaucu,1f),
			new encontravel(nomesCriatures.Aladegg,1.25f),
			new encontravel(nomesCriatures.Onarac,1f),
			new encontravel(nomesCriatures.Serpente,1f)
		},
		new List<encontravel>()//indice10
		{
			new encontravel(nomesCriatures.Serpente,2),
			new encontravel(nomesCriatures.Wisks,1.5f),
			new encontravel(nomesCriatures.Escorpion,1.5f),
			new encontravel(nomesCriatures.Onarac,1.5f),
			new encontravel(nomesCriatures.Iruin,1.5f),
			new encontravel(nomesCriatures.Babaucu,1.5f),
			new encontravel(nomesCriatures.Marak,0.5f),
		}
	};
	
	protected override List<encontravel> listaEncontravel()
	{
		return secaoEncontravel[IndiceDoLocal()];
	}
	//	private readonly string[] osDaki = new string[11]
	//	{"Xuash",nomesCriatures.Babaucu,"Florest",nomesCriatures.PolyCharm,nomesCriatures.Marak,nomesCriatures.Iruin,nomesCriatures.Arpia,"Steal",nomesCriatures.Escorpion,nomesCriatures.Aladegg,nomesCriatures.Onarac};
	
	// Use this for initialization
	/*
	new void Start () {
		base.Start();
		//elementos = GameObject.Find ("elementosDoJogo").GetComponent<elementosDoJogo> ();

	}*/
	
	// Update is called once per frame
	
	
	int IndiceDoLocal()
	{
		int indiceDoLocal = -1;
		if(posHeroi.x>731//floresta Oeste de Infinity - Floresta de Babauçu
		   &&
		   posHeroi.z<1587
		   &&
		   posHeroi.z>1533
		   &&
		   posHeroi.x<778)
		{
			indiceDoLocal = 1;
		}else
			if((posHeroi.x>521//Floresta ao sul de Infinity com formato de cruz
			    &&
			    posHeroi.z<2009
			    &&
			    posHeroi.z>1610
			    &&
			    posHeroi.x<569)
			   ||
			   (posHeroi.x>330//Floresta ao sul de Infinity com formato de cruz
			 &&
			 posHeroi.z<1738
			 &&
			 posHeroi.z>1696
			 &&
			 posHeroi.x<712)
			   ||
			   (posHeroi.x>406//Floresta ao sul de Infinity com formato de cruz
			 &&
			 posHeroi.z<1920
			 &&
			 posHeroi.z>1873
			 &&
			 posHeroi.x<654)	   )
		{
			indiceDoLocal = 2;
		}else
			if(posHeroi.x>38 && posHeroi.z<1763)//em volta de Infinity
		{
			indiceDoLocal = 0;
		}
		else if((posHeroi.x>-887//Floresta do POlyCharm
		         &&
		         posHeroi.z<1378
		         &&
		         posHeroi.z>1211
		         &&
		         posHeroi.x<-458)
		        ||
		        (
			posHeroi.x>-458//pequeno anexo a floresta do Polycharm
			&&
			posHeroi.z<1351
			&&
			posHeroi.z>1281
			&&
			posHeroi.x<-354))
		{
			indiceDoLocal = 3;
		}
		else if(
			(
			posHeroi.x>-310//floresta Leste da Fortaleza
			&&
			posHeroi.z<1616
			&&
			posHeroi.z>1456
			&&
			posHeroi.x<-113)
			||
			(
			posHeroi.x>-690//FLoresta em Losangulo
			&&
			posHeroi.z<1791
			&&
			posHeroi.z>1576
			&&
			posHeroi.x<-436)
			)
		{
			indiceDoLocal = 4;
		}
		else if(
			
			posHeroi.x>-357//perto da fortaleza sem floresta
			&&
			posHeroi.z<2677
			&&
			posHeroi.z>2169
			&&
			posHeroi.x<215
			
			)
		{
			indiceDoLocal = 5;
		}
		else if
			(
				posHeroi.x>-441//floresta da fortaleza com Steal
				&&
				posHeroi.z<2711
				&&
				posHeroi.z>2066
				&&
				posHeroi.x<306
				)
		{
			indiceDoLocal = 6;
		}
		else if(
			
			posHeroi.x>-758//floresta atras da montanha leste de Ive - floresta do FLorest
			&&
			posHeroi.z<3317
			&&
			posHeroi.z>3239
			&&
			posHeroi.x<-406
			
			)
		{
			indiceDoLocal = 7;
		}
		else if(
			
			posHeroi.x>634//floresta atras da montanha oeste de Ive - FLoresta do Xuash
			&&
			posHeroi.z<3354
			&&
			posHeroi.z>3232
			&&
			posHeroi.x<800
			
			)
		{
			indiceDoLocal = 8;
		}else if(
			
			posHeroi.x>623//floresta de folhinhas Oeste da Fortaleza
			&&
			posHeroi.z<3034
			&&
			posHeroi.z>2799
			&&
			posHeroi.x<837
			)
		{
			indiceDoLocal = 9;
		}else if(
			
			//floresta de folhinhas SuldOeste da Fortaleza
			relativoAReta(528,3077,362,3256,true,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(410,3312,578,3141,false,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(528,3077,578,3141,true,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(410,3312,362,3256,false,posHeroi.x,posHeroi.z)
			)
		{
			indiceDoLocal = 10;
		}else if(
			
			//floresta de folhinhas Suldeste da Fortaleza sul do cano de esgoto
			relativoAReta(-778,3114,-350,3114,false,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(-350,3114,-362,2955,true,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(-362,2955,-652,2765,true,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(-652,2765,-761,2765,true,posHeroi.x,posHeroi.z)
			&&
			relativoAReta(-778,3114,-761,2765,true,posHeroi.x,posHeroi.z)
			)
		{
			indiceDoLocal = 10;
		}else
			indiceDoLocal = 5;
		
		return indiceDoLocal;
	}

	protected override bool lugarSeguro(){
		bool seguro;
		if(
			// Esse primeiro local seguro e onde o guarda da fortaleza patrulha
			(posHeroi.x>-110
		    &&
		    posHeroi.x<0.5
		    &&
		    posHeroi.z<3610.6
		    &&
		    posHeroi.z>2520)
		   ||
			(posHeroi.x>-74.3
		 &&
		 posHeroi.x<192.6
		 &&
		 posHeroi.z>3610.6
		 &&
		 posHeroi.z<3774.9)
			||
			(posHeroi.x>468
		 &&
		 posHeroi.x<737
		 &&
		 posHeroi.z>1310
		 &&
		 posHeroi.z<1465)
			||
			(posHeroi.x>-6.3
		 &&
		 posHeroi.z<1425.3
		 &&
		 posHeroi.x<62.1
		 &&
		 posHeroi.z>1368.9)
			)
			seguro = true;
		else
			seguro = false;
		return seguro;
	}
}