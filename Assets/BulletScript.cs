using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float damage;
	public float pushForce;

	private int direction;
	
	// Use this for initialization
	void Start () {
		damage = 25;

		// RS: upon creating the bullet, we give it a directin based on the players
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
		Debug.Log ("Trigger");
		other.BroadcastMessage ("ApplyDamage", damage);
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
