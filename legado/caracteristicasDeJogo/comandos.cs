using UnityEngine;
using System.Collections;

public class comandos :MonoBehaviour{
	protected Animator animator;
	protected CharacterController controle;
	protected bool pulo = false;
	protected Vector3 movimentoVertical = Vector3.zero;
	protected float ultimoYFundamentado = 0f;
	protected float tempoMaxPulo = 0.5f;
	protected string[] textos;

	private float tempoDePulo;
	private bool estavaPulando = false;
	private float erroMaior = 0.01f;
	private string colidi;
	// Use this for initialization

	public static string mostradorDeTempo(float t,string tipo  = "m.s.ms",bool tiraZero = true)
	{
		string retorno = "";
		float ms = (int)(t*1000)%1000;
		float s = ((int)t)%60;
		float h = ((int)t)/3600;
		float m = (((int)t)/60)%60;

		switch(tipo)
		{
		case "m.s.ms":
			if(tiraZero)
			{
				if(m==0)
					retorno = s+"s"+ms+"ms";
				else
					retorno = m+"m"+s+"s"+ms+"ms";
			}else
				retorno = m+"m"+s+"s"+ms+"ms";

		break;
		case "h.m.s.ms":
			retorno = h+"h"+m+"min"+s+"s"+ms+"ms";
		break;
		}

		return retorno;
	}

	protected void verificaPulo(Vector3 direcaoMovimento,caracteristicasBasicas Y)
	{
		if(estavaPulando==false&& pulo==true)
			tempoDePulo = 0;

		estavaPulando = pulo;

		//print(tempoDePulo+" : "+tempoMaxPulo+" : "+pulo);
		if (
			pulo == true 
			&& 
			(transform.position.y - ultimoYFundamentado < Y.apiceDoPulo
		 &&
		 tempoDePulo<tempoMaxPulo
		 )) 
		{
			tempoDePulo+=Time.deltaTime;
			movimentoVertical = (direcaoMovimento * Y.velocidadeNoAr + Vector3.up * Y.velocidadeSubindo);
			controle.Move (movimentoVertical * Time.deltaTime);
		} else if (
			(transform.position.y - ultimoYFundamentado >= Y.apiceDoPulo
		 ||
		 tempoDePulo>=tempoMaxPulo
		 )
			&&
			pulo == true) {
			pulo = false;
		} else if (pulo == false) {
			movimentoVertical = Vector3.Lerp(movimentoVertical,
			                                 (direcaoMovimento * Y.velocidadeAndando + Vector3.down * Y.velocidadeCaindo),
			                                 3*Time.deltaTime);//Y.apliqueGravidade(movimentoVertical,direcaoMovimento);
			controle.Move (movimentoVertical * Time.deltaTime);
			//tempoDePulo = 0;
			
		}
	}

	protected void aplicaRotacao(caracteristicasBasicas Y,Vector3 direcaoMovimento,float v,float h)
	{
		if (Input.GetButton ("Correr")) {
			Y.rot = Y.velocidadeDeRotacaoCorrendo;
			//Y.velocidade = Y.velocidadeCorrendo;
		} else {
			Y.rot = Y.velocidadeDeRotacao;
			//Y.velocidade = Y.velocidadeAndando;
		}
		
		if (v > 0) {
			
			//controle.Move ((direcaoMovimento)*velocidade*Time.deltaTime);
			transform.rotation = Quaternion.Lerp (
				transform.rotation,
				Quaternion.LookRotation (direcaoMovimento),
				Time.deltaTime * Y.rot
				);
		} else if (Mathf.Abs (h) > 0 && v>=0)
			transform.rotation = Quaternion.Lerp (
				transform.rotation,
				Quaternion.LookRotation (direcaoMovimento),
				Time.deltaTime * Y.velocidadeDeRotacaoParado
				);
		else if(v<0)
			transform.rotation = Quaternion.Lerp (
				transform.rotation,
				Quaternion.LookRotation (direcaoMovimento),
				Time.deltaTime * Y.velocidadeDeRotacao
				);
	}

	public void aplicaGolpe(Criature daki)
	{
		golpe G = daki.Golpes[daki.golpeEscolhido];

		System.GC.Collect();
		Resources.UnloadUnusedAssets();
/*
		print(G.UltimoUso+" : "+ Time.time+" : "+heroi.tempoNoJogo+" : "+G.TempoReuso);

		print(G.UltimoUso < Time.time -  G.TempoReuso);
*/
		if(G.UltimoUso < Time.time -  G.TempoReuso){
			daki.cAtributos[1].Corrente-=daki.Golpes[daki.golpeEscolhido].CustoPE;

			G.UltimoUso = Time.time;
			acaoDeGolpe acao = gameObject.AddComponent<acaoDeGolpe> ();
			acao.ativa = G;
			//acao.emissor = emissor;
		}else if(gameObject.GetComponent<movimentoBasico>())
		{

			mensagemEmLuta mL = GetComponent<mensagemEmLuta>(); 
			if(mL)
				mL.fechador();
			mL = gameObject.AddComponent<mensagemEmLuta>();
			mL.mensagem = string.Format(textos[1],mostradorDeTempo(G.UltimoUso-(Time.time-G.TempoReuso)));
		}
	}



	private void OnControllerColliderHit(ControllerColliderHit hit)	
	{
		if(controle){
		CollisionFlags collisionFlags = controle.collisionFlags;
		bool um = (collisionFlags & CollisionFlags.CollidedBelow) != 0 ;

		colidi = hit.transform.name;
		//Debug.Log(colidi);
		if(um && hit.transform.name=="Terrain" && transform.tag!="Criature"&&Vector3.Angle(Vector3.up,hit.normal)>30)
		{
			if(!Physics.Raycast (transform.position, Vector3.down, erroMaior))
			{
				print("serei eu "+hit.transform.name);
				controle.Move(Time.deltaTime*(hit.normal+Vector3.down).normalized*10);
			}
		}

		}

	}

	public bool noChao (float erroDeAncora,bool especial = false)
	{
		erroMaior = erroDeAncora;
		if(especial && colidi=="Terrain")
		{
			return	
				Physics.Raycast (transform.position, Vector3.down, erroDeAncora);
		}else
		{

			//CharacterController controle =  GetComponent<CharacterController>();
			CollisionFlags collisionFlags = controle.collisionFlags;
			bool um = (collisionFlags & CollisionFlags.CollidedBelow) != 0 ;
			return um ||
			Physics.Raycast (transform.position, Vector3.down, erroDeAncora);
		}
	}
    public static bool noChaoS(CharacterController controle,float erroDeAncora, bool especial = false)
    {
        
        if (especial)
        {
            return
                Physics.Raycast(controle.transform.position, Vector3.down, erroDeAncora);
        }
        else
        {

            //CharacterController controle =  GetComponent<CharacterController>();
            CollisionFlags collisionFlags = controle.collisionFlags;
            bool um = (collisionFlags & CollisionFlags.CollidedBelow) != 0;
            return um ||
            Physics.Raycast(controle.transform.position, Vector3.down, erroDeAncora);
        }
    }

}
