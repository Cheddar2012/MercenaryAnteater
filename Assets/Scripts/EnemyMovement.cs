using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// RS: The enemy will run towards the player if the player is within
	//	"agroRange". 

	public float speed = 15.0f;		// RS: movespeed
	public float agroRange = 10.0f;	// RS: distance to trigger following

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// RS: just making sure the player isnt dead
		if (player != null) {	
			// RS: if within agroRange, hyena will move towards player
			if (Vector3.Distance (player.transform.position, transform.position) <= agroRange)
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, 
				                                         player.transform.position, step);
			}
		}
	}
}
