using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour 
{
	public bool paused;
	public Texture pauseScreen;

	// Use this for initialization
	void Start () 
	{
		paused = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(paused)
		{
			Time.timeScale = 0;
		}

		else
		{
			Time.timeScale = 1;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
		}
	}

	void OnGUI()
	{
		if(paused)
		{
			// print (Screen.width + "   " + Screen.height);

			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseScreen); // 

			// GUI.Box(new Rect(0, 0, 1300, 600), pauseScreen); // 

			if(GUI.Button(new Rect(600,200,100,60),"Resume") )
			{
				// Debug.Log("Clicked the button with text");
				paused = !paused;
			}	

			if(GUI.Button(new Rect(600,400,100,60),"Quit") )
			{
				// Debug.Log("Clicked the button with text");
				Application.LoadLevel("Scene001");
			}

			/*
			GUI.Box(new Rect(0,500,300,120),"Arrow keys up/left/down/right to move \n" +
			        "Z to Shoot Basic Attack (unlimited) \n" +
			        "X to Shoot Rapid Gun \n" +
					"C to Toss Grenade \n" +
			        "V To Shoot Spread Gun \n");
			*/


		}

	}
}
