using UnityEngine;
using System.Collections;

public class BlueKey : MonoBehaviour 
{
	public bool blueKey;
	
	Inventory inve;
	
	// Use this for initialization
	void Start () 
	{
		blueKey = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			inve = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
			
			inve.blueKey = true;
			Destroy(gameObject);
		}
	}
}
