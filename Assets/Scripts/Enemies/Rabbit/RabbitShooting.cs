using UnityEngine;
using System.Collections;

public class RabbitShooting : MonoBehaviour {
	
	public int attackRange = 200;
	public int attackCooldown = 3;
	public GameObject bullet;
	public int multiplier = 5;
	
	public RabbitMovement rm; 			
	public GameObject player;
	public float nextShotTime;

	public float shootingTime = 0.5f;
	public float shotEnds;

	public bool shooting;

	public int shootForce = 120;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		rm = GetComponent<RabbitMovement> ();
		nextShotTime = Time.time;
	}
	
	bool TimeToShoot()
	{
		return nextShotTime < Time.time;
	}
	
	bool InAgroRange() 
	{
		return Vector3.Distance (player.transform.position, transform.position) < attackRange;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (InAgroRange() && TimeToShoot()) 
		{
			// print ("FORE");
			
			GameObject clone;

			switch(rm.facing)
			{
				case 1:
					Vector3 upAdj = new Vector3(0, -5, 0) + Vector3.up;
					clone = (GameObject) Instantiate(bullet, transform.position + upAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.transform.Rotate(new Vector3(0, 0, 1), 270);
					clone.rigidbody2D.velocity = new Vector2(0, shootForce);
					break;
				case 2: 
					Vector3 leftAdj = new Vector3(-5, 0, 0) + Vector3.left;
					clone = (GameObject) Instantiate(bullet, transform.position + leftAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.rigidbody2D.velocity = new Vector2(-shootForce, 0);
					break;
				case 3: 
					Vector3 downAdj = new Vector3(0, 5, 0) + Vector3.down;
					clone = (GameObject) Instantiate(bullet, transform.position + downAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.transform.Rotate(new Vector3(0, 0, 1), 90);
					clone.rigidbody2D.velocity = new Vector2(0, -shootForce);
					break;
				case 4:
					Vector3 rightAdj = new Vector3(5, 0, 0) + Vector3.right;
					clone = (GameObject) Instantiate(bullet, transform.position + rightAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.transform.Rotate(Vector3.up, 180);
					clone.rigidbody2D.velocity = new Vector2(shootForce, 0);
					break;
			}

			shooting = true;
			
			nextShotTime = Time.time + attackCooldown;
			shotEnds = Time.time + shootingTime;
		}

		if(Time.time > shotEnds)
		{
			shooting = false;
		}
	}
}

