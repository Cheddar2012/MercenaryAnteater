﻿using UnityEngine;
using System.Collections;

public class AimedShooting : MonoBehaviour {
	
	// public int attackRange = 50;
	public int attackCooldown = 1;
	public GameObject bullet;
	public int multiplier = 5;
	public int facing{ get; private set; }	// RS: 2 is Left, 4 is Right
	
	private EnemyMovement em; 			
	private GameObject player;
	private float nextShotTime;

	public float shotForce = 50;

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

	// RS: returns true if player is within attackRange
//	bool InAttackRange() {
//		return Vector3.Distance (player.transform.position, transform.position) < attackRange;
//	}
	
	// Update is called once per frame
	void Update () {
		facing = em.facing;
		
		if (player != null && (player.transform.position.y - transform.position.y) < 15
		    && TimeToShoot()) {
			GameObject clone;

			Vector3 aim = player.transform.position - transform.position;
			if(facing == 2) 
				clone = (GameObject) Instantiate(bullet, transform.position + Vector3.left * multiplier, Quaternion.identity);
			else
				clone = (GameObject) Instantiate(bullet, transform.position + Vector3.right * multiplier, Quaternion.identity);
			clone.rigidbody2D.velocity = aim * shotForce / Vector3.Distance (player.transform.position, transform.position);

			clone.transform.parent = gameObject.transform;
			nextShotTime = Time.time + attackCooldown;			
		}
		
	}
}

