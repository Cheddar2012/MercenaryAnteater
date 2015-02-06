using UnityEngine;
using System.Collections;

public class LionessShooting : MonoBehaviour {

	public float shootCooldown = 8.3f;
	public float bombCooldown = 19;

	public GameObject bullet;
	public int multiplier = 5;
	
	private LionessMovement em; 			
	private GameObject player;
	private float nextShotTime;
	private float nextTimeBomb;

	public float shotForce = 75;

	public bool shooting;
	public bool bombing;

	public float moveShootCooldown = 0.6f;
	public float startMovingTime;

	public GameObject bombAttack;

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

	bool TimeToBomb()
	{
		return nextTimeBomb < Time.time;
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

			Vector3 heightAdj = new Vector3(-50, 20, 0);
			Vector3 aim = player.transform.position - (transform.position + heightAdj);

			// Lioness only shoots to the left, this time 
			if(em.facing != 2) 
			{
				em.facing = 2;
			}

			clone = (GameObject) Instantiate(bullet, transform.position + heightAdj + Vector3.left * multiplier, Quaternion.identity);
			clone.rigidbody2D.velocity = aim * shotForce / Vector3.Distance (player.transform.position, transform.position);

			// clone.transform.parent = gameObject.transform;
			nextShotTime = Time.time + shootCooldown;	

			startMovingTime = Time.time + moveShootCooldown;
		}

		if(TimeToBomb() )
		{
			bombing = true;

			GameObject[] bombClones = new GameObject[2];

			bombClones[0] = (GameObject)Instantiate(bombAttack, new Vector2(transform.position.x - 180, transform.position.y + 300), Quaternion.identity);
			bombClones[0].GetComponent<FallingBomb>().targetY = (int)transform.position.y + 100;

			bombClones[1] = (GameObject)Instantiate(bombAttack, new Vector2(transform.position.x - 180, transform.position.y + 300), Quaternion.identity);
			bombClones[1].GetComponent<FallingBomb>().targetY = (int)transform.position.y - 100;

			nextTimeBomb = Time.time + bombCooldown; // 
			startMovingTime = Time.time + moveShootCooldown;
		}

		if(Time.time > startMovingTime)
		{
			shooting = false;
		}
	}
}

