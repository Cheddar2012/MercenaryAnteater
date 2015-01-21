using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string text;
	public int fontSize;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent("GUIText");
		gameObject.guiText.text = text;
		gameObject.guiText.anchor = TextAnchor.MiddleCenter;
		gameObject.guiText.alignment = TextAlignment.Center;
		gameObject.guiText.fontSize = fontSize;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if (Input.GetMouseButtonDown(0)) 
		{

		}
		*/
	}

	// got the entire onGUI button interaction from Unity API 
	void OnGUI() 
	{
		/*
		if (!btnTexture) 
		{
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button(Rect(10,10,50,50),btnTexture))
			Debug.Log("Clicked the button with an image");
		*/
		if(GUI.Button(new Rect(400,400,100,60),"Start") )
		{
			// Debug.Log("Clicked the button with text");
			Application.LoadLevel("Scene002");
		}

		if(GUI.Button(new Rect(400,500,100,60),"Credits") )
		{
			// Debug.Log("Clicked the button with text");
			Application.LoadLevel("credits");
		}

		if(GUI.Button(new Rect(400,600,100,60),"Quit") )
		{
			// Debug.Log("Clicked the button with text");
			Application.Quit();
		}
	}
}
