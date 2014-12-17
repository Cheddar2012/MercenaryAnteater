using UnityEngine;
using System.Collections;

public class RabbitMovement : MonoBehaviour {
	
	// RS: The enemy will run towards the player if the player is within
	//	"agroRange". 
	
	public float speed = 15.0f;				// RS: movespeed
	public float aggroRange = 100.0f;		// RS: distance to trigger following
	public bool mobile = true;				// RS: tells if player CAN move
	public bool moving {get; private set;}	// RS: tells if moving
	
	public int facing;	// RS: direction facing: 2-Left, 4-Right
	private bool stop;						// RS: whether enemy is stopped or not
	private GameObject player;
	// Use this for initialization
	void Start () {
		// JH starts facing to the right
		facing = 4;
		stop = false;
		player = GameObject.Find ("Player");
		moving = false;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			stop = true;
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			stop = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// jh death sequence initiated; death check no longer needed

		// print(" y check " + (player.transform.position.y - transform.position.y) );

		float diffY = player.transform.position.y - transform.position.y;
		float diffX = player.transform.position.x - transform.position.x;

		// if Merc Ante is above Rabbit and closer along Y than along X, look up
		if( (diffY >= 0) && (Mathf.Abs(diffY) > Mathf.Abs(diffX) ) )
		{
			facing = 1;
		}

		// if to left of Rabbit and closer to side than top, look left
		else if( (diffX < 0) && (Mathf.Abs(diffY) < Mathf.Abs(diffX) ) )
		{
			facing = 2; 	// RS: face left
		}

		else if( (diffY < 0) && (Mathf.Abs(diffY) > Mathf.Abs(diffX) ) )
		{
			facing = 3;
		}

		else if( (diffX >= 0) && (Mathf.Abs(diffY) < Mathf.Abs(diffX) ) )
		{
			facing = 4;		// RS: face right
		}
		
		if(!mobile)
			stop = true;

		/*
		if (GetComponent<SnakeAnimator>() != null) {
			// Debug.Log("playerInAggroRange: " + playerInAggroRange() + ", stop: " + stop + ", speed: " + speed + ", mobile: " + mobile);
		}
		*/

		// RS: if within agroRange, enemy will move towards player
		if (playerInAggroRange() && !stop && speed > 0 && mobile)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
			moving = true;
		}
		else
			moving = false;
		
	}
	
	public bool playerInAggroRange() {
		return (Vector3.Distance (player.transform.position, transform.position) <= aggroRange);
	}
}