using UnityEngine;
using System.Collections;

public class PlayerGrenade : MonoBehaviour 
{
	public Vector3 speed;
	private int direction;

	public Vector3 startPoint;
	float distanceTraveled;

	public GameObject explode;

	// Use this for initialization
	void Start () 
	{
		// RS: upon creating the bullet, we give it a direction based on the players
		//  direction which is saved in the "Movement" script
		direction = GameObject.Find ("Player").GetComponent<Movement> ().facing;
		startPoint = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		distanceTraveled = Vector3.Distance(transform.position, startPoint);

		speed = transform.rigidbody2D.velocity;
		transform.Rotate(0, 0, 13.5f);

		if(distanceTraveled > 125)
		{
			explode = (GameObject)Instantiate(explode, (transform.position), Quaternion.identity);
			Destroy (gameObject);
		}

		if(distanceTraveled < 62)
			// 
		{
			transform.localScale = new Vector3(transform.localScale.x * 1.05f, transform.localScale.y * 1.05f, 1.0f);
		}

		else
		{
			transform.localScale = new Vector3(transform.localScale.x * 0.95f, transform.localScale.y * 0.95f, 1.0f);
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
