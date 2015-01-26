﻿using UnityEngine;
using System.Collections;

public class LionessMovement : MonoBehaviour 
{
	
	// RS: The enemy will run towards the player if the player is within
	//	"agroRange". 
	
	public float speed = 2.0f;				// RS: movespeed
	public float aggroRange = 0.0f;		// RS: distance to trigger following
	public bool mobile = true;				// RS: tells if player CAN move
	public bool moving {get; private set;}	// RS: tells if moving

	private int prevFacing;
	public int facing{ get; set; }	// RS: direction facing: 2-Left, 4-Right
	private GameObject player;

	private LionessShooting ls;
	// Use this for initialization

	/********** Level 1 boss: 
	 * transform.position.y will always = 20 for Lioness
	 * 
	 * transform.position.x will range from 300 to 600 for Lioness
	 * **********/
	void Start () 
	{
		prevFacing = facing = 2;
		moving = true;
		player = GameObject.Find ("Player");
		moving = false;
		ls = GetComponent<LionessShooting>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			moving = false;
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			moving = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// conditions to handle
		// if facing character and moving, stop to shoot
		// if facing character and moving, move forward
		// go from stop to moving left

		// if facing away from character and moving, stop, turn, shoot
		// if facing away from character and moving, move forward
		// go from stop to moving right

		// used when going from stop to moving
		prevFacing = facing;

		// if time to shoot, stop and face the player (left)
		if(ls.shooting)
		{
			moving = false;
			facing = 2;
		}

		// if moving, then continue moving
		if(moving)
		{
			// facing left
			if( (facing == 2) && (transform.position.x > 300) )
			{
				transform.position = new Vector2(transform.position.x - speed, transform.position.y);
			}
			else if( (facing == 4) && (transform.position.x < 600) )
			{
				transform.position = new Vector2(transform.position.x + speed, transform.position.y);
			}

			// at edges of bounding box, turn around
			else if(transform.position.x <= 300)
			{
				facing = 4;
			}
			
			else if(transform.position.x >= 600)
			{
				facing = 2;
			}
		}
			
		/*
		if(player.transform.position.x - transform.position.x < 0)
		{
			facing = 2; 	// RS: face left
		}
		else
		{
			facing = 4;		// RS: face right
		}
		*/



		else
		{

		}
	}

	public bool playerInAggroRange() 
	{
		return (Vector3.Distance (player.transform.position, transform.position) <= aggroRange);
	}
}