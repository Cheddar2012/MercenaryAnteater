using UnityEngine;
using System.Collections;

public class RabbitShooting : MonoBehaviour {
	
	public int attackRange = 500;
	public int attackCooldown = 2;
	public GameObject bullet;
	public int multiplier = 5;
	
	public RabbitMovement rm; 			
	public GameObject player;
	public float nextShotTime;
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
					clone.rigidbody2D.AddForce(new Vector2(0, 2) );
					break;
				case 2: 
					Vector3 leftAdj = new Vector3(-5, 0, 0) + Vector3.left;
					clone = (GameObject) Instantiate(bullet, transform.position + leftAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.rigidbody2D.AddForce(new Vector2(-2, 0) );
					break;
				case 3:
					Vector3 downAdj = new Vector3(0, 5, 0) + Vector3.down;
					clone = (GameObject) Instantiate(bullet, transform.position + downAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.rigidbody2D.AddForce(new Vector2(0, -2) );
					break;
				case 4:
					Vector3 rightAdj = new Vector3(5, 0, 0) + Vector3.right;
					clone = (GameObject) Instantiate(bullet, transform.position + rightAdj * multiplier, Quaternion.identity);
					clone.transform.parent = gameObject.transform;
					clone.rigidbody2D.AddForce(new Vector2(2, 0) );
					break;
			}
			
			nextShotTime = Time.time + attackCooldown;			
		}
		
	}
}

