using UnityEngine;
using System.Collections;

public class caminheAteOAlvo : MonoBehaviour {
	public Transform alvo;
	public bool podeAtualizar = true;

	private Animator animator;
	private float v = 0;
	private bool naoInvocou = true;
	private Vector3 direcaoMeta;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void setaDirecao()
	{
		direcaoMeta = alvo.position - transform.position;
		direcaoMeta = new Vector3(direcaoMeta.x,0,direcaoMeta.z);

		transform.rotation = Quaternion.Lerp(
			transform.rotation,
			Quaternion.LookRotation(direcaoMeta),
			Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(podeAtualizar){
			setaDirecao();

		if(direcaoMeta.sqrMagnitude>3)
			v = Mathf.Lerp(v,1,Time.deltaTime);
		else{
				v = Mathf.Lerp(v,0,5*Time.deltaTime);
			if(naoInvocou)
			{
				naoInvocou = false;
				Invoke("andeDeNovo",Random.Range(8,20));
			}
		}

		animator.SetFloat("velocidade",v);
		}
		else
		{
			animator.SetFloat("velocidade",0);
		}
	}

	public void pareACaminhada()
	{
		animator.SetFloat("velocidade",0);
		this.enabled = false;
	}

	void andeDeNovo()
	{
		alvo = alvo.GetComponent<possiveisAlvos>().sorteiaAlvo();
		naoInvocou = true;
	}
}
