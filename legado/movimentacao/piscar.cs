using UnityEngine;
using System.Collections;

public class piscar : MonoBehaviour {

	private const float TEMPO_DE_PISCAR = 3;

	private float tempo = 0;
	private Material material;
	private Animator animator;
	private AnimatorStateInfo animaState;


	public int qualMaterial = 0;
	public float deslocamento = 0;

	// Use this for initialization
	void Start () {
		material = GetComponentInChildren<Renderer>().materials[qualMaterial];
		animator = GetComponent<Animator>();
		if(animator)
			animaState = animator.GetCurrentAnimatorStateInfo(0);
	}
	
	// Update is called once per frame
	void Update () {
		tempo+=Time.deltaTime;

		if(animator)
		{
			animaState = animator.GetCurrentAnimatorStateInfo(0);
			if(animaState.IsName("padrao")){
				if(tempo>TEMPO_DE_PISCAR )
				{
					piscarAgora();
				}
			}else if(animaState.IsName("cair")){
				material.mainTextureOffset = new Vector3(3*deslocamento,0);
			}else if(animaState.IsName("dano1")){
				tempo = TEMPO_DE_PISCAR;
				piscarAgora();
			}else
				material.mainTextureOffset = new Vector3(0,0);
		}else
		{
			animator = GetComponent<Animator>();
			if(animator)
				animaState = animator.GetCurrentAnimatorStateInfo(0);
		}

	
	}

	void piscarAgora()
	{
		if(tempo>TEMPO_DE_PISCAR&&tempo<TEMPO_DE_PISCAR+0.07f)
			material.mainTextureOffset = new Vector3(deslocamento,0);

		if(tempo>TEMPO_DE_PISCAR+0.07f&&tempo<TEMPO_DE_PISCAR+0.14f)
			material.mainTextureOffset = new Vector3(2*deslocamento,0);

		if(tempo>TEMPO_DE_PISCAR+0.14f&&tempo<TEMPO_DE_PISCAR+0.5f)
			material.mainTextureOffset = new Vector3(3*deslocamento,0);

		if(tempo>TEMPO_DE_PISCAR+0.5f&&tempo<TEMPO_DE_PISCAR+0.57f)
			material.mainTextureOffset = new Vector3(2*deslocamento,0);

		if(tempo>TEMPO_DE_PISCAR+0.57f&&tempo<TEMPO_DE_PISCAR+0.64f)
			material.mainTextureOffset = new Vector3(deslocamento,0);

		if(tempo>TEMPO_DE_PISCAR+0.64f){
			material.mainTextureOffset = new Vector3(0,0);
			tempo = 0;
		}
	}
}
