using UnityEngine;
using System.Collections;

public class HUDCriaturesComMuda : HUDCriatures {

	public bool  podeMudar = true;

	private float testeDeEixo = 0;

	new void Start()
	{
		base.Start();
		comMouse  = true;
	}
	// Update is called once per frame
	void Update () {
		if(podeMudar)
		{
			H.criatureSai = (int)mudaDestaque((uint)H.criatureSai,criatures.Count );

			//print(qualBox+" : "+comMouse+" : "+ondeMouseEsta);
			if(qualBox>-1)
				if(qualBox<criatures.Count)
					H.criatureSai = qualBox+1;
				else
				 	H.criatureSai = 0;
		}
	
	}

	public int dentroOuFora()
	{
		//		Rect R = new Rect(posXr,posY,larg+0.03f*Screen.width,maxHeight);
		print(qualBox);
		if(qualBox>-1){
			if(qualBox<criatures.Count)
				H.criatureSai = qualBox+1;
			else
			 	H.criatureSai = 0;
		}
		
		return qualBox;
	}



	public uint mudaDestaque(uint dest,int escol)
	{
		float v = Input.GetAxisRaw ("Vertical") ;
		if(v<0f &&testeDeEixo==0)
			if(dest<escol-1)
				dest++;
		else
			dest = 0;
		if(v>0f && testeDeEixo == 0)
			if(dest>0)
				dest--;
		else
			dest = (uint)escol-1;
		testeDeEixo = v;
		
		
		return dest;
		
	}
}
