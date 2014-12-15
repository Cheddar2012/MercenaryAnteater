	using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour {

	private int speed;
	private int damage;
	private int xPrev;	//RS: 1 is up, 2 is left, 3 is down, 4 is right
	private int yPrev;
	private int xDir;
	private int yDir;
	// Use this for initialization
	void Start () {
		speed = 2;
		damage = 5;
		xDir = 1;
		yDir = 1;
		xPrev = xDir;
		yPrev = yDir;
	}

	void ChangeDirection() {
		if (xDir == 1 && yDir == 1)
			yDir = -1;
		else if (xDir == 1 && yDir == -1)
			xDir = -1;
		else if (xDir == -1 && yDir == -1)
			yDir = 1;
		else 
			xDir = 1;

		transform.position -= new Vector3 (0.5f, 0.5f, 0.0f);
	}

	void Move() {
		transform.position += new Vector3 (xDir * speed, yDir * speed, 0);
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player")
			col.gameObject.BroadcastMessage ("ApplyDamage", damage);
	
		ChangeDirection ();
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}
}
