using UnityEngine;
using System.Collections;

public class animaPergFuga : LuvaDeGuarde {

	public GameObject G;
	public string estado = "tentandoFugir";

	private float tempoEmCena = 0;
	private int disparado = 0;

	
	private bool fugiu;
	private bool fim;
	//private string[] mensagens;
	private GameObject particula;
	private bool arremesso = false;
	private CharacterController  controle;


	private const int LOOPS = 8;

	// Use this for initialization
	void Start () {
		fugiu = contaDeFuga();
		IA = G.GetComponent<IA_inimigo>();
		elementos = GameObject.Find("elementosDoJogo").GetComponent<elementosDoJogo>();
		animator = G.GetComponent<Animator>();
		//mensagens = bancoDeTextos.falacoes[heroi.lingua]["tentaCapturar"].ToArray();
		particula = (GameObject)Instantiate(
			elementos.retorna("particulaDaFuga"),
			G.transform.position,
			Quaternion.identity
			);
		paralisaInimigo();
	}

	void oFim()
	{
		Destroy(this);
	}

	void voltarParaPasseio()
	{
		estado = "finalisaUsaItem";
		Destroy(GameObject.FindWithTag("Player").GetComponent<centralizaEGiraCamera>());
		GameObject.Find("Terrain").GetComponent<encontros>().voltarParaPasseio();
	}

	// Update is called once per frame
	void Update () {
		tempoEmCena+=Time.deltaTime;
		int arredondado = Mathf.RoundToInt(tempoEmCena);

		
		if(arredondado!=disparado&& arredondado<LOOPS)
		{
			//particulasSaiDaLuva(G.transform);
			animator.CrossFade("dano1",0);
			animator.SetBool("dano1",true);
			animator.SetBool("dano2",true);
			paralisaInimigo();
			
			disparado = arredondado;
		}

		if(arredondado>=LOOPS&&!fim)
		{
			if(fugiu)
			{
				animator.SetBool("dano1",false);
				animator.SetBool("dano2",false);
				Destroy(particula);
				GameObject Gg = elementos.retorna("sucessoDaFuga");
				Gg = (GameObject)Instantiate(Gg,G.transform.position,Quaternion.identity);
				Destroy(Gg,2);
				arremesso = true;
				controle = transform.GetComponent<CharacterController>();
				Destroy(GetComponent<centralizaEGiraCamera>());
				Invoke("voltarParaPasseio",2);
			}else
			{
				animator.SetBool("dano1",false);
				animator.SetBool("dano2",false);
				Destroy(particula);
				GameObject Gg = elementos.retorna("encontro");
				Gg = (GameObject)Instantiate(Gg,G.transform.position,Quaternion.identity);
				Gg.GetComponent<ParticleSystem>().GetComponent<Renderer>().material 
					=  elementos.materiais[0];
				Destroy(Gg,2);
				Invoke("oFim",1);
			}
			fim = true;
		}

		if(arremesso)
		{
			transform.Rotate(1000*Time.deltaTime,0,0);
			controle.Move((Camera.main.transform.position-transform.position)*Time.deltaTime*2);
		}
	}


	bool contaDeFuga()
	{
		return true;
	}
}
