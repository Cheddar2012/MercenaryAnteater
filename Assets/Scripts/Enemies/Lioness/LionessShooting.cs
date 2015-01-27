using UnityEngine;
using System.Collections;

public class LionessShooting : MonoBehaviour {

	public int attackCooldown = 4;

	public GameObject bullet;
	public int multiplier = 5;
	
	private LionessMovement em; 			
	private GameObject player;
	private float nextShotTime;

	public float shotForce = 50;

	public bool shooting;

	public float moveShootCooldown = 0.6f;
	public float startMovingTime;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
		em = GetComponent<LionessMovement>();
		nextShotTime = Time.time;
		startMovingTime = Time.time;
	}
	
	bool TimeToShoot()
	{
		return nextShotTime < Time.time;
	}

	// RS: returns true if player is within attackRange
//	bool InAttackRange() {
//		return Vector3.Distance (player.transform.position, transform.position) < attackRange;
//	}
	
	// Update is called once per frame
	void Update () 
	{
		if (TimeToShoot() ) 
		{
			shooting = true; 

			GameObject clone;

			Vector3 aim = player.transform.position - transform.position;

			// Lioness only shoots to the left, this time 
			if(em.facing != 2) 
			{
				em.facing = 2;
			}

			clone = (GameObject) Instantiate(bullet, transform.position + Vector3.left * multiplier, Quaternion.identity);
			clone.rigidbody2D.velocity = aim * shotForce / Vector3.Distance (player.transform.position, transform.position);

			// clone.transform.parent = gameObject.transform;
			nextShotTime = Time.time + attackCooldown;	

			startMovingTime = Time.time + moveShootCooldown;
		}

		if(Time.time > startMovingTime)
		{
			shooting = false;
		}
	}
}

