using UnityEngine;
using System.Collections;
public class cCriature {

	private Criature X;
	public 	cCriature(nomesCriatures nome,uint nivel=1)
	{
		switch(nome)
		{
		case nomesCriatures.Xuash:
			X = new Xuash(nivel);
		break;
		case nomesCriatures.Florest:
			X = new Florest(nivel);
		break;
		case nomesCriatures.Marak:
			X = new Marak(nivel);
		break;
		case nomesCriatures.PolyCharm:
			X = new PolyCharm(nivel);
		break;
		case nomesCriatures.FelixCat:
			X = new FelixCat(nivel);
		break;
		case nomesCriatures.Babaucu:
			X = new Babaucu(nivel);
		break;
		case nomesCriatures.Arpia:
			X = new Arpia(nivel);
		break;
		case nomesCriatures.Iruin:
			X = new Iruin(nivel);
		break;
		case nomesCriatures.Steal:
			X = new Steal(nivel);
		break;
		case nomesCriatures.Escorpion:
			X = new Escorpion(nivel);
		break;
		case nomesCriatures.Escorpirey:
			X = new Escorpirey(nivel);
		break;
		case nomesCriatures.Aladegg:
			X = new Aladegg(nivel);
		break;
		case nomesCriatures.Onarac:
			X = new Onarac(nivel);
		break;
		case nomesCriatures.Wisks:
			X = new Wisks(nivel);
		break;

		case nomesCriatures.Serpente:
			X = new Serpente(nivel);
		break;

		case nomesCriatures.Nessei:
			X = new Nessei(nivel);
		break;

		case nomesCriatures.Rabitler:
			X = new Rabitler(nivel);
		break;

		case nomesCriatures.Rocketler:
			X = new Rocketler(nivel);
		break;

		case nomesCriatures.Cabecu:
			X = new Cabecu(nivel);
		break;

		case nomesCriatures.Vampire:
			X = new Vampire(nivel);
		break;



		case nomesCriatures.Fajin:
			X = new Fajin(nivel);
		break;
		case nomesCriatures.Flam:
			X = new Flam(nivel);
		break;
		case nomesCriatures.Croc:
			X = new Croc(nivel);
		break;
		case nomesCriatures.Oderc:
			X = new Oderc(nivel);
		break;

		case nomesCriatures.Abutre:
			X = new Abutre(nivel);
		break;

		case nomesCriatures.Urkan:
			X = new Urkan(nivel);
		break;

		case nomesCriatures.Baratarab:
			X = new Baratarab(nivel);
		break;

		case nomesCriatures.DogMour:
			X = new DogMour(nivel);
		break;
		case nomesCriatures.Izicuolo:
			X = new Izicuolo(nivel);
		break;
		case nomesCriatures.Cracler:
			X = new Cracler(nivel);
		break;
		case nomesCriatures.Nedak:
			X = new Nedak(nivel);
		break;
		case nomesCriatures.Estrep:
			X = new Estrep(nivel);
		break;

		}

		if(X!=null)
			X.nomeID = nome;

		float sum = 0;
		for(int i=0;i<5;i++)
			sum+=X.cAtributos[i].Taxa;

		if(sum!=1)
		{
			Debug.LogWarning("O Criature "+X.nomeID+" nao tem a soma das taxas igual a 1");
		}


		}
		
		public Criature criature()
		{
			return X;
		}


}

public enum nomesCriatures
{
	Xuash,
    Florest, FlorestR,
    Marak,
	PolyCharm,
	FelixCat,
	Babaucu,
	Arpia,
	Iruin,
	Steal,
	Escorpion,
	Escorpirey,
	Aladegg,
	Onarac,
	Wisks,
	Serpente,
	Nessei,
	Rabitler,
	Rocketler,
	Cabecu,
	Vampire,
	Fajin,
	Flam,
	Croc,
	Oderc,
	Abutre,
	Urkan,
	Baratarab,
	DogMour,
	Izicuolo,
	Cracler,
	Nedak,
	Estrep
}
