	using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour {

	private int speed;
	private int damage;
	private float xPrev;	//RS: 1 is up, 2 is left, 3 is down, 4 is right
	private float yPrev;
	public float xDir;
	public float yDir;

	// JH changing bat movement to stop and rest sometimes 
	// adding values for bat renderer 
	public bool moving;
	int restTime = 3;
	int moveTime = 8;
	public float nextMove;
	public float nextRest;

	public int upDist;
	public int leftDist;
	public int downDist;
	public int rightDist;

	public float top; 
	public float left;
	public float bottom;
	public float right;

	public PauseScript gamePause;

	// Use this for initialization
	void Start () {
		speed = 2;
		damage = 5;
		xDir = 1;
		yDir = 1;
		// xPrev = xDir;
		// yPrev = yDir;

		moving = true;
		nextRest = 8.0f;
		nextMove = 11.0f;

		upDist = leftDist = downDist = rightDist = 300;

		top = transform.position.y + upDist;
		left = transform.position.x - leftDist;
		bottom = transform.position.y - downDist;
		right = transform.position.x + rightDist;

		gamePause = GameObject.Find("Pause").GetComponent<PauseScript>();
	}

	void ChangeDirection() {
		xDir = Random.Range(-0.9f, 0.9f);
		yDir = Random.Range(-0.9f, 0.9f);

		speed = Random.Range (1,3);

		// transform.position -= new Vector3 (0.5f, 0.5f, 0.0f);
	}

	void Move() 
	{
		if(transform.position.y > top)
		{
			yDir = -yDir;
			// xDir = Random.Range(-0.9f, 0.9f);
		}

		else if(transform.position.y < bottom)
		{
			yDir = -yDir;
		}

		if(transform.position.x > right)
		{
			xDir = -xDir;
			// yDir = Random.Range(-0.9f, 0.9f);
		}

		else if(transform.position.x < left)
		{
			xDir = -xDir;
		}

		transform.position += new Vector3 (xDir * speed, yDir * speed, 0);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.BroadcastMessage ("ApplyDamage", damage);
		}

		ChangeDirection ();

		// print ("bonk");
	}

	// Update is called once per frame
	void Update () 
	{
		// continue to move
		if(moving && Time.time < nextRest)
		{
			Move ();
		}

		// stop moving
		if(moving && Time.time > nextRest)
		{
			moving = false;
			nextMove = Time.time + restTime;
		}

		// continue to rest
		if(!moving && Time.time < nextMove)
		{
			// do nothing
		}

		// if at rest and time to start moving again, 
		// start moving again
		if(!moving && Time.time > nextMove)
		{
			moving = true;
			ChangeDirection();
			Move ();
			nextRest = Time.time + moveTime;
		}

		if(gamePause.paused)
		{
			moving = false;
		}
	}
}
