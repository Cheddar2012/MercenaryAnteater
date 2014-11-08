using UnityEngine;
using System.Collections;

public class HyenaMovement : MonoBehaviour {

	// RS: The Hyena will run towards the player if the player is within
	//	an "agroRange" set by us. He can attack every X seconds represented by
	//	"attackCD". "speed" is how fast the hyena moves and "range" is how
	//	far in from of him he can attack.

	public float speed;
	public float range;
	public float damage;
	public int attackCD;

	private float timestamp;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		//speed = 15.0f;
		range = 3.5f;
		damage = 5.0f;
		attackCD = 1;
		timestamp = Time.time; // RS: takes timestamp from beginning of game
	}

	void Attack()
	{
		// RS: timestamp indicates the earliest time at which the hyena can attack.
		//	Then compared against the current time we see if it is time for its next attack.
		if(timestamp <= Time.time)
		{
			// RS: if within range, hyena will attack and set a new timestamp
			if (Vector3.Distance (player.transform.position, gameObject.transform.position) <= range) 
			{
				player.BroadcastMessage("ApplyDamage", damage);
				timestamp = Time.time + attackCD;
			}

		}
	}


	void Follow()
	{
		// RS: if within agroRange, hyena will move towards player
		if (Vector3.Distance (player.transform.position, transform.position) <= 12)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, 
                               player.transform.position, step);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		// just making sure the player isnt dead
		if (player != null) {	
			Attack ();
			Follow ();
		}
	}
}
