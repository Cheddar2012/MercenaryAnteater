using UnityEngine;
using System.Collections;

public class AntHill : MonoBehaviour {

	Health thisHealth;
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			thisHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
			
			if(thisHealth.poisoned)
			{
				thisHealth.poisoned = false;
			}

			if(thisHealth.health < 50)
			{
				thisHealth.health += 1;
			}

		}
	}
}
