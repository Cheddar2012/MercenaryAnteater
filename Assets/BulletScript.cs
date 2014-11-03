using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float damage;
	public float pushForce;

	private int direction;

	// constructor will be passed the direction of the player
	// this will allow us to apply the force in the proper
	// direction

	// Use this for initialization
	void Start () {
		direction = GameObject.Find ("Player").GetComponent<Movement> ().facing;

		switch (direction) 
		{
			case 1:
				rigidbody2D.AddForce (new Vector2 (pushForce, 0));
				break;
			case 2:
				rigidbody2D.AddForce (new Vector2 (0, -pushForce));
				break;
			case 3:
				rigidbody2D.AddForce (new Vector2 (-pushForce, 0));
				break;
			case 4:
				rigidbody2D.AddForce (new Vector2 (0, pushForce));
				break;
		}
	}

	void ApplyDamage(float d)
	{
		print ("damage dealt");
	}

	void OnTriggerEnter(Collider other)
	{
		gameObject.SendMessage ("ApplyDamage", damage);
		Destroy (other.gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
