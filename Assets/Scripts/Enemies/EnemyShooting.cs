using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	
	public int attackRange = 50;
	public int attackCooldown = 1;
	public GameObject bullet;
	public int multiplier = 5;
	public int facing{ get; private set; }	// RS: 2 is Left, 4 is Right

	public EnemyMovement em; 			
	public GameObject player;
	public float nextShotTime;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		em = GetComponent<EnemyMovement> ();
		facing = 2;
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
		facing = em.facing;

		if (player != null && InAgroRange() && (player.transform.position.y - transform.position.y) < 3
		    	&& TimeToShoot()) 
		{
			// print ("FORE");

			GameObject clone;

			if(facing == 2) 
			{
				clone = (GameObject) Instantiate(bullet, transform.position + Vector3.left * multiplier, Quaternion.identity);
			}
			else
			{
				clone = (GameObject) Instantiate(bullet, transform.position + Vector3.right * multiplier, Quaternion.identity);
			}

			clone.transform.parent = gameObject.transform;

			nextShotTime = Time.time + attackCooldown;			
		}
		
	}
}

