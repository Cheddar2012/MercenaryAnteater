using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	public bool collide;

	// Use this for initialization
	void Start () 
	{
		collide = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if(collide)
		{
			GUI.Box(new Rect(400,400,300,120),"Arrow keys up/down/left/right to move");
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			print ("collide");

			collide = true;
		}
	}
}
