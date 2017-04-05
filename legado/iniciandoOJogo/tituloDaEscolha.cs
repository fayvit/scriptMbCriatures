using UnityEngine;
using System.Collections;

public class tituloDaEscolha : abaixoDeMenu {

	// Use this for initialization
	void Start () {
		posXrr = -2*Screen.width;
		posX = 0.1f;
		posY = 0.05f;
		aCaixa = 0.1f;
		lCaixa = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		deslizar(false,false);

		Rect R = new Rect(posXrr,posYrr,lCr,aCr);

		GUI.Box(R," <color=yellow>Armagedom de Infinity</color>\r\n escolha seu CRIATURE inicial",skin.box);

	}
}



/*
using UnityEngine;
using System.Collections;

public class tituloDaEscolha : MonoBehaviour 
{
	//converter string em int
	//public int i;
	
	//public string s ="2";
	
	
	
	//converter string em int
	////i=int.Parse(password);
	
	
	
	
	
	public static string user = "", name = "";
	private string password = "", rePass = "", message = "";
	
	private bool register = false;
	private bool mensagem = false;
	
	private void OnGUI()
	{
		
		if (mensagem)
		{
			
			
		}
		GUILayout.BeginArea(new Rect(   
		                             0.4f*Screen.width,
		                             0.3f*Screen.height,
		                             0.2f*Screen.width,
		                             0.7f*Screen.height
		                             ));


		if (message != "")
			GUILayout.Box(message);
		
		if (register)
		{
			GUILayout.Label("Usuario");
			user = GUILayout.TextField(user);
			GUILayout.Label("Nome");
			name = GUILayout.TextField(name);
			GUILayout.Label("Senha");
			password = GUILayout.PasswordField(password, "*"[0]);
			GUILayout.Label("Confirme senha");
			rePass = GUILayout.PasswordField(rePass, "*"[0]);
			
			GUILayout.BeginHorizontal();
			
			if (GUILayout.Button("Voltar"))
				register = false;
			
			if (GUILayout.Button("Registrar"))
			{
				message = "";
				
				if (user == "" || name == "" || password == "")
					message += "Por favor preencha todos os campos";
				else
				{
					if (password == rePass)
					{
						WWWForm form = new WWWForm();
						form.AddField("user", user);
						form.AddField("name", name);
						form.AddField("password", password);
						WWW w = new WWW("http://battleboxofficial.zz.vc/register.php", form);
						StartCoroutine(registerFunc(w));
					}
					else
						message += "Sua senha nao corresponde";
				}
			}
			
			GUILayout.EndHorizontal();
		}
		else
		{
			GUILayout.Label("Usuario:");
			user = GUILayout.TextField(user);
			GUILayout.Label("Senha:");
			password = GUILayout.PasswordField(password, "*"[0]);
			
			GUILayout.BeginHorizontal();
			
			if (GUILayout.Button("Entar"))
			{
				message = "";
				
				if (user == "" || password == "")
					message += "Por favor preencha todos os campos";
				else
				{
					WWWForm form = new WWWForm();
					form.AddField("user", user);
					form.AddField("password", password);
					WWW w = new WWW("http://battleboxofficial.zz.vc/login.php", form);
					StartCoroutine(login(w));
				}
			}
			
			if (GUILayout.Button("Registar"))
				register = true;
			
			GUILayout.EndHorizontal();

			// seus GUILayout aqui
			
			GUILayout.EndArea();
		}
	}
	
	IEnumerator login(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			if (w.text == "login-SUCCESS")
			{
				Application.LoadLevel ("MenuGeral");
			}
			else
				message += w.text;
		}
		else
		{
			message += "ERROR: " + w.error + "\n";
		}
	}
	
	IEnumerator registerFunc(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			message += w.text;
		}
		else
		{
			message += "ERROR: " + w.error + "\n";
		}
	}
}*/
