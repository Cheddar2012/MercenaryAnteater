using UnityEngine;
using System.Collections;

public class PlayerGrenade : MonoBehaviour 
{
	public Vector3 speed;
	private int direction;

	public Vector3 startPoint;
	int distanceTraveled;

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
		speed = transform.rigidbody2D.velocity;

		if(Vector3.Distance(transform.position, startPoint) > 125)
		{
			explode = (GameObject)Instantiate(explode, (transform.position), Quaternion.identity);
			
			Destroy (gameObject);
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
