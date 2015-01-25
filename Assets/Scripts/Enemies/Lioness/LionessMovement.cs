using UnityEngine;
using System.Collections;

public class LionessMovement : MonoBehaviour 
{
	
	// RS: The enemy will run towards the player if the player is within
	//	"agroRange". 
	
	public float speed = 2.0f;				// RS: movespeed
	public float aggroRange = 0.0f;		// RS: distance to trigger following
	public bool mobile = true;				// RS: tells if player CAN move
	public bool moving {get; private set;}	// RS: tells if moving

	private int prevFacing;
	public int facing{ get; set; }	// RS: direction facing: 2-Left, 4-Right
	private bool stop;						// RS: whether enemy is stopped or not
	private GameObject player;

	private LionessShooting ls;
	// Use this for initialization

	/**********
	 * transform.position.y will always = 20 for Lioness
	 * 
	 * transform.position.x will range from 300 to 600 for Lioness
	 * **********/
	void Start () 
	{
		prevFacing = facing = 2;
		stop = false;
		player = GameObject.Find ("Player");
		moving = false;
		ls = GetComponent<LionessShooting>();
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
	void FixedUpdate () 
	{
		prevFacing = facing;

		if(ls.shooting)
		{
			stop = true;
			facing = 2;
		}

		// RS: just making sure the player isnt dead
		if (player != null) 
		{	
			/*
			if(player.transform.position.x - transform.position.x < 0)
			{
				facing = 2; 	// RS: face left

			}
			else
			{
				facing = 4;		// RS: face right
			}
			*/

			if(!stop)
			{
				moving = true;

				// facing left
				if( (facing == 2) && (transform.position.x > 300) )
				{
					transform.position = new Vector2(transform.position.x - speed, transform.position.y);
				}

				else if( (facing == 4) && (transform.position.x < 600) )
				{
					transform.position = new Vector2(transform.position.x + speed, transform.position.y);
				}

				else if(transform.position.x <= 300)
				{
					facing = 4;
				}

				else if(transform.position.x >= 600)
				{
					facing = 2;
				}
			}

			else
			{

			}

			/*
			if (GetComponent<SnakeAnimator>() != null) 
			{
				// Debug.Log("playerInAggroRange: " + playerInAggroRange() + ", stop: " + stop + ", speed: " + speed + ", mobile: " + mobile);
			}
			*/

			/*
			// RS: if within agroRange, enemy will move towards player
			if (playerInAggroRange() && !stop && speed > 0 && mobile)
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, 
				                                         player.transform.position, step);
				moving = true;
			}
			else
				moving = false;
				*/
		}
	}

	public bool playerInAggroRange() 
	{
		return (Vector3.Distance (player.transform.position, transform.position) <= aggroRange);
	}
}