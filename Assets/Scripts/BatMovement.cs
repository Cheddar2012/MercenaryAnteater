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
