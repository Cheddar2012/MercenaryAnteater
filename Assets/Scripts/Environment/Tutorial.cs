using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Vector3.Distance(transform.position, player.transform.position) > 1000)
		{
			Destroy (gameObject);
		}
	}

	void OnGUI()
	{
			GUI.Box(new Rect(400,400,300,120),"Arrow keys up/left/down/right to move \n" +
				"Z to Shoot Basic Attack (unlimited) \n" + 
		        "ESC key to pause or view controls");
	}
}
