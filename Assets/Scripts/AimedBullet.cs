using UnityEngine;
using System.Collections;

public class AimedBullet : MonoBehaviour {
	
	public float damage = 20;
	public float speed = 20;

	private GameObject player;
	private Vector3 playerPos;
	
	// Use this for initialization
	void Start () {
		// RS: upon creating the bullet, we give it a destination
		player = GameObject.Find ("Player");
		playerPos = player.transform.position;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player") // RS: will only deal damage if the unit is an enemy
			other.BroadcastMessage ("ApplyDamage", damage);
		if(other.tag != "Enemy")
			Destroy (gameObject);
	}
	
	// RS: destroy the bullet once it goes entirely off the screen
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards (transform.position, playerPos, speed);
	}
}
