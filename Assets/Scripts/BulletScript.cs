using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float damage = 20;
	public float pushForce = 20;

	private int direction;
	
	// Use this for initialization
	void Start () {
		// RS: upon creating the bullet, we give it a direction based on the players
		//  direction which is saved in the "Movement" script
		direction = GameObject.Find ("Player").GetComponent<Movement> ().facing;

		// RS: 1 for Up, 2 for Right, 3 for Down, 4 for Up
		switch (direction) 
		{
			case 4:
				rigidbody2D.AddForce (new Vector2 (pushForce, 0));
				break;
			case 3:
				rigidbody2D.AddForce (new Vector2 (0, -pushForce));
				break;
			case 2:
				rigidbody2D.AddForce (new Vector2 (-pushForce, 0));
				break;
			case 1:
				rigidbody2D.AddForce (new Vector2 (0, pushForce));
				break;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy") // RS: will only deal damage if the unit is an enemy
			other.BroadcastMessage ("ApplyDamage", damage);
		if(other.tag != "Player")
			Destroy (gameObject);
	}

	// RS: destroy the bullet once it goes entirely off the screen
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
