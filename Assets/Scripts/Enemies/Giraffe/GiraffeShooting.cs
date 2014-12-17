using UnityEngine;
using System.Collections;

public class GiraffeShooting : MonoBehaviour {
	
	public int attackRange = 500;
	public int attackCooldown = 1;
	public GameObject bullet;
	public int multiplier = 5;
	public int facing{ get; private set; }	// RS: 2 is Left, 4 is Right
	
	public EnemyMovement em; 			
	public GameObject player;
	public float nextShotTime;
	public int numberShots;
	public int shotCap;

	public bool shooting;
	public float shootTime = 0.4f;
	public float stopShoot;

	public int shotForce = 150;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		em = GetComponent<EnemyMovement> ();

		facing = 2;
		nextShotTime = Time.time;

		numberShots = 0;
		shotCap = 5;

		shooting = false;
		stopShoot = 0.0f;
	}
	
	bool TimeToShoot()
	{
		return nextShotTime < Time.time;
	}
	
	bool InAggroRange() 
	{
		return Vector3.Distance (player.transform.position, transform.position) < attackRange;
	}
	
	// Update is called once per frame
	void Update () 
	{
		facing = em.facing;
		
		if (InAggroRange() && TimeToShoot() ) 
		{
			// print ("FORE");
			
			GameObject clone;
			
			Vector3 leftAdj = new Vector3(-30, -15, 0);
			Vector3 rightAdj = new Vector3(30, -15, 0);

			// JH 
			// fire the bullet
			// increment number of shots
			Vector3 aim = player.transform.position - transform.position;
			if(facing == 2) 
			{
				clone = (GameObject) Instantiate(bullet, (transform.position + leftAdj) + Vector3.left * multiplier, Quaternion.identity);
			}
			else
			{
				clone = (GameObject) Instantiate(bullet, (transform.position + rightAdj) + Vector3.right * multiplier, Quaternion.identity);
			}
			clone.rigidbody2D.velocity = aim * shotForce / Vector3.Distance (player.transform.position, transform.position);
			numberShots++;
			shooting = true;
			stopShoot = Time.time + shootTime;
			
			clone.transform.parent = gameObject.transform;
			
			nextShotTime = Time.time + attackCooldown;

			// JH after firing so many times. 
			// waits an amt of time equal to number of shots fired 
			// before firing again
			if(numberShots >= shotCap)
			{
				nextShotTime = Time.time + numberShots;
				numberShots = 0;
			}
		}

		if(Time.time > stopShoot)
		{
			shooting = false;
		}
	}
}

