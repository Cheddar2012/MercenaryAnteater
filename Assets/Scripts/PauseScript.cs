using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour 
{
	public bool paused;
	public GameObject pauseBkgd;

	// Use this for initialization
	void Start () 
	{
		paused = false;
		pauseBkgd = GameObject.Find("PauseScreen");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(paused)
		{
			Time.timeScale = 0;
			pauseBkgd.active = true;
		}

		else
		{
			Time.timeScale = 1;
			pauseBkgd.active = false;
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
			if(GUI.Button(new Rect(200,200,100,60),"Resume") )
			{
				// Debug.Log("Clicked the button with text");
				paused = !paused;
			}	

			if(GUI.Button(new Rect(200,400,100,60),"Quit") )
			{
				// Debug.Log("Clicked the button with text");
				Application.LoadLevel("Scene001");
			}	
		}

	}
}
