using UnityEngine;
using System.Collections;

public class SnakeAttack : MonoBehaviour {

	public int facing{ get; private set; }

	public EnemyMovement em; 			
	public GameObject player;

	public bool attacking;
	public float attackTime = 0.4f;
	public float stopAttack;

	public int damage = 1;				// RS: damage to deal per second
	public float attackCD = 3;			// RS: seconds between poison resets
	public float attackRange = 50;		// RS: range to apply poision
	public float poisonDuration = 6;	// RS: time poison lasts (in seconds)
	
	private float attackTimestamp;		// RS: game time at which snake can re-poison

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		em = GetComponent<EnemyMovement> ();

		facing = 2;

		attacking = false;
		stopAttack = 0.0f;

		attackTimestamp = Time.time;
	}

	// RS: if the snake can attack, tell set poision damage and tell player he is poisned
	//	then set cooldown for attack
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {

			if (Time.time >= attackTimestamp) {
				player.BroadcastMessage("SetPoisonDamage", damage);
				player.BroadcastMessage ("PoisonPlayer", poisonDuration);
				attackTimestamp = Time.time + poisonDuration;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		facing = em.facing;

		if (player != null && em.playerInAggroRange() && !attacking ) 
		{
			attacking = true;
			stopAttack = Time.time + attackTime;
		}

		if(Time.time > stopAttack)
		{
			Debug.Log("Swag");
			attacking = false;
		}
	}
}
