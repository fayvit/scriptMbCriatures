using UnityEngine;
using System.Collections;

public class botoes : pauseBase {

	// Use this for initialization
	void Start () {
		posXrr = -2*Screen.width;
		tempoDeMenu = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		deslizar(false,false);

		GUI.depth = -3;
		Rect R = new Rect(posXrr,posYrr,lCr,aCr);
		GUILayout.BeginArea(R);
		R = new Rect(0,0,lCr,aCr);
		GUI.Box(R,"",skin.box);
		R = new Rect(0.01f*Screen.width,0.01f*Screen.height,0.5f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"com Cesar Corean: ",skin.label);

		R = new Rect(0.01f*Screen.width,0.1f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"A,W,S,D (ou) Setas : ",skin.label);

		R = new Rect(0.26f*Screen.width,0.1f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," andar ",skin.label);

		R = new Rect(0.01f*Screen.width,0.18f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"esquerdo do Mouse (ou) Insert : ",skin.label);
		
		R = new Rect(0.26f*Screen.width,0.18f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Botao de açao ",skin.label);

		R = new Rect(0.01f*Screen.width,0.26f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"direito do Mouse (ou) Delete : ",skin.label);
		
		R = new Rect(0.26f*Screen.width,0.26f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Botao de menu ",skin.label);

		R = new Rect(0.01f*Screen.width,0.34f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"botao do meio do Mouse (ou) ALT : ",skin.label);
		
		R = new Rect(0.26f*Screen.width,0.34f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Centraliza camera ",skin.label);

		R = new Rect(0.01f*Screen.width,0.42f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"ESC: ",skin.label);
		
		R = new Rect(0.26f*Screen.width,0.42f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Altera para o Criature ",skin.label);

		R = new Rect(0.01f*Screen.width,0.5f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"Shift: ",skin.label);
		
		R = new Rect(0.26f*Screen.width,0.5f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Correr ",skin.label);

		R = new Rect(0.51f*Screen.width,0.01f*Screen.height,0.5f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"com Criature ",skin.label);
		
		R = new Rect(0.51f*Screen.width,0.1f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"A,W,S,D (ou) Setas : ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.1f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," andar ",skin.label);
		
		R = new Rect(0.51f*Screen.width,0.18f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"esquerdo do Mouse (ou) Insert : ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.18f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Botao de Ataque ",skin.label);
		
		R = new Rect(0.51f*Screen.width,0.26f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," R : ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.26f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Utiliza Item ",skin.label);
		
		R = new Rect(0.51f*Screen.width,0.34f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"botao do meio do Mouse (ou) ALT : ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.34f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Centraliza camera ",skin.label);
		
		R = new Rect(0.51f*Screen.width,0.42f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"ESC: ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.42f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Altera para Cesar Corean (quando nao em Luta) ",skin.label);

		R = new Rect(0.51f*Screen.width,0.5f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"Mouse Scrool (ou) Page Up/Page Down: ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.5f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Alterna entre itens ",skin.label);

		R = new Rect(0.51f*Screen.width,0.58f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"Shift + Mouse Scrool (ou) Shift +Page Up/Page Down: ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.58f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Alterna entre Criatures ",skin.label);

		R = new Rect(0.51f*Screen.width,0.66f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R,"Shift + R ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.66f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Troca o Criature ",skin.label);

		R = new Rect(0.51f*Screen.width,0.74f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Tab ",skin.label);
		
		R = new Rect(0.76f*Screen.width,0.74f*Screen.height,0.25f*Screen.width,0.7f*Screen.height);
		GUI.Label(R," Alterna entre os Golpes ",skin.label);



		GUILayout.EndArea();
	}
}
