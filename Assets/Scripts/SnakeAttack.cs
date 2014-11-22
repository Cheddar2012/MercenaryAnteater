using UnityEngine;
using System.Collections;

public class SnakeAttack : MonoBehaviour {

	public int damage = 2;				// RS: damage to deal per second
	public float attackCD = 3;			// RS: seconds between poison resets
	public float attackRange = 50;		// RS: range to apply poision
	public float poisonDuration = 3;	// RS: time poison lasts (in seconds)
	
	private float attackTimestamp;		// RS: game time at which snake can re-poison
	private GameObject player;			
	// Use this for initialization
	void Start () {
		attackTimestamp = Time.time;
		player = GameObject.Find ("Player");
	}

	// RS: if the snake can attack, tell set poision damage and tell player he is poisned
	//	then set cooldown for attack
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && Time.time >= attackTimestamp) {
			player.BroadcastMessage("SetPoisonDamage", damage);
			player.BroadcastMessage ("PoisonPlayer", poisonDuration);
			attackTimestamp = Time.time + poisonDuration;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
