using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(400,500,100,60),"Back") )
		{
			// Debug.Log("Clicked the button with text");
			Application.LoadLevel("Scene001");
		}	
	}
}
