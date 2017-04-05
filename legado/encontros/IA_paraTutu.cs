using UnityEngine;
using System.Collections;

public class IA_paraTutu : IA_inimigo {


	private bool estaEnchendo = false;
	private int numeroDeGolpes = 0;
	private Tutorial tuto;


	protected override void disparador()
	{

		coolDown = 2;//C.tempoReacaoCorrente;
		
		Vector3 olhe = alvo.position - transform.position;
		olhe = new Vector3(olhe.x,0,olhe.z);
		transform.rotation = Quaternion.LookRotation(olhe);
		if(C.Golpes[C.golpeEscolhido].CustoPE<=C.cAtributos[1].Corrente){
			
			numeroDeGolpes++;
			aplicaGolpe(C);

			/*
		aplicaGolpe(C.Golpes[C.golpeEscolhido],transform.Find(C.emissor).position
		            +transform.forward*C.Golpes[C.golpeEscolhido].DistanciaDeEmissao );
		            */
		}else{
			procureColisao();
		}
		C.golpeEscolhido = proximoGolpe();	
	}

	new void Update()
	{
		if(podeAtualizar)
		{
			base.Update();

			if(C.cAtributos[0].Corrente>25)
			{
				esteveMaiorQue20 = true;
				//C.cAtributos[0].Corrente = 23;
			}

			if(C.cAtributos[0].Corrente<25  && !estaEnchendo && esteveMaiorQue20)
			{
				encheAVida();
				estaEnchendo = true;
				Invoke("agoraNaoEstaEnchendo",5);
			}
		}
	}

	void agoraNaoEstaEnchendo()
	{
		print("nao esta enchendo");
		estaEnchendo = false;
	}

	bool esteveMaiorQue20 = false;

	void encheAVida()
	{
		inimigoUsaItem iUsa =  gameObject.AddComponent<inimigoUsaItem>();
		iUsa.nomeItem = nomeIDitem.pergaminhoDePerfeicao;
	}

	protected override int proximoGolpe()
	{

		int retorno = 0;
		switch(numeroDeGolpes)
		{
		case 5:
			retorno = 0;
		break;
		case 7:
			this.podeAtualizar = false;
			tuto = Camera.main.GetComponent<Tutorial>();
			paraMovimento();
			tuto.EnsineAUsarMaca();
			retorno  = 1;
		break;
		case 12:
			print("Cade o use a energia de garras");
			tuto.useAEnergiaDeGarras();
			retorno = 1;
			paraMovimento();
			this.enabled = false;

		break;
		default:
			retorno = 1;
		break;
		}
		print(numeroDeGolpes);
		return retorno;
	}
}
