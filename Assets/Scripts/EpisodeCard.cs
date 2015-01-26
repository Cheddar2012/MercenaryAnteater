using UnityEngine;
using System.Collections;

public class EpisodeCard : MonoBehaviour 
{
	public Texture epiCard;

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
		if(Time.time < 5)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), epiCard); 
		}
	}
}
