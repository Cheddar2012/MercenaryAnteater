using UnityEngine;
using System.Collections;

public class HyenaMovement : MonoBehaviour {

	public float speed;
	public float range;
	public float damage;
	public int attackCD;

	private float timestamp;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		//speed = 15.0f;
		range = 3.5f;
		damage = 5.0f;
		attackCD = 1;
		timestamp = Time.time;
	}

	void Attack()
	{
		if(timestamp <= Time.time)
		{
			if (Vector3.Distance (player.transform.position, gameObject.transform.position) <= range) 
			{
				player.BroadcastMessage("ApplyDamage", damage);
				timestamp = Time.time + attackCD;
			}

		}
	}


	void Follow()
	{
		if (Vector3.Distance (player.transform.position, transform.position) <= 12)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, 
                               player.transform.position, step);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (player != null) {	
			Attack ();
			Follow ();
		}
	}
}
