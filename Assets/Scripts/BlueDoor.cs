using UnityEngine;
using System.Collections;

public class BlueDoor : MonoBehaviour 
{
	Inventory inve;

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
	}
}
