using UnityEngine;
using System.Collections;

public class BlueDoor : MonoBehaviour 
{
	Inventory inve;

	public bool colliding;
	public float clueTime;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		inve = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

		if( (col.gameObject.tag == "Player") && (inve.blueKey) )
		{
			Destroy(gameObject);
		}

		else if(col.gameObject.tag == "Player")
		{
			colliding = true;
			clueTime = Time.time +5;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			colliding = false;
		}
	}

	void OnGUI()
	{
		if(Time.time < clueTime) 
		{
			GUI.Box(new Rect(600,600,300,120),"You need a Blue Key");
		}
	}
}
