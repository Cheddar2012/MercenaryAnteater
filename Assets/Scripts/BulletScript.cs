using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float damage = 10;

	private int direction;

	public Vector3 speed;
	
	// Use this for initialization
	void Start () 
	{
		// RS: upon creating the bullet, we give it a direction based on the players
		//  direction which is saved in the "Movement" script
		direction = GameObject.Find ("Player").GetComponent<Movement> ().facing;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy") // RS: will only deal damage if the unit is an enemy
			other.BroadcastMessage ("ApplyDamage", damage);

		// JH Pits no longer destroy bullets
		if( (other.tag != "Player") && (other.tag != "Pit") )
			Destroy (gameObject);
	}

	// RS: destroy the bullet once it goes entirely off the screen
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		speed = transform.rigidbody2D.velocity;
	}
}
