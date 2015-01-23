using UnityEngine;
using System.Collections;

public class HyenaAttack : MonoBehaviour {

	public int facing = 1;			// RS: 1 is Left, 2 is Right
	public float range = 3.5f;		// RS: attack range (from center of enemy)
	public float damage = 5.0f;		// RS: damage dealt
	public int attackCD = 1;		// RS: attack speed

	private GameObject player;
	private float timestamp;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		timestamp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// RS: timestamp indicates the earliest time at which the hyena can attack.
		//	Then compared against the current time we see if it is time for its next attack.
		if(timestamp <= Time.time)
		{
			// RS: if within range, hyena will attack and set a new cooldown timestamp
			if (player != null && 
			    	Vector3.Distance (player.transform.position, gameObject.transform.position) <= range) 
			{
				player.BroadcastMessage("ApplyDamage", damage);
				timestamp = Time.time + attackCD;
			}
			
		}
	}
}
