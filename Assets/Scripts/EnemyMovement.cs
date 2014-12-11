using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	// RS: The enemy will run towards the player if the player is within
	//	"agroRange". 
	
	public float speed = 15.0f;				// RS: movespeed
	public float agroRange = 10.0f;			// RS: distance to trigger following
	public bool mobile = true;				// RS: tells if player CAN move
	public bool moving {get; private set;}	// RS: tells if moving

	public int facing{ get; private set; }	// RS: direction facing: 2-Left, 4-Right
	private bool stop;						// RS: whether enemy is stopped or not
	private GameObject player;
	// Use this for initialization
	void Start () {
		facing = 2;
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
		// RS: just making sure the player isnt dead
		if (player != null) {	
			
			if(player.transform.position.x - transform.position.x < 0)
				facing = 2; 	// RS: face left
			else
				facing = 4;		// RS: face right
			
			// RS: if within agroRange, enemy will move towards player
			if (Vector3.Distance (player.transform.position, transform.position) <= agroRange 
			    && !stop && speed > 0 && mobile)
			{
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, 
				                                         player.transform.position, step);
				moving = true;
			}
		}
		
	}
}