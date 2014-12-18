using UnityEngine;
using System.Collections;

public class RabbitAnimator : MonoBehaviour 
{
	// The array of sprites used for animating this character
	public Sprite[] rabbits;

	// Number of frames to animate each second
	public int framesPerSecond = 10;

	// The object's SpriteRenderer
	public SpriteRenderer rabbitRend;

	// This enemy object's EnemyMovement script
	public RabbitMovement rabMove;

	// Countdown until the next frame
	private float frameTimer;

	// Which sprite to show in the sprites array
	public int spriteToShow;

	// We need to know the player's position to know whether to look right or left
	public GameObject player;

	// We need to know whether or not the enemy is attacking
	public RabbitShooting rShoot;

	public int direction;

	// Use this for initialization
	void Start () 
	{
		rabbitRend = (SpriteRenderer)GetComponent("SpriteRenderer");
		rabMove = (RabbitMovement)GetComponent("RabbitMovement");

		ResetFrameTimer();

		rabbitRend.sprite = rabbits[6];
		
		rShoot = (RabbitShooting)GetComponent("RabbitShooting");
		
		player = GameObject.Find ("Player");
		
		direction = 4;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!rShoot.shooting)
		{
			if(!rabMove.moving)
			{
				switch(rabMove.facing)
				{
				case 1:
					rabbitRend.sprite = rabbits[0];
					break;
					
				case 2:
					rabbitRend.sprite = rabbits[2];
					break;
					
				case 3:
					rabbitRend.sprite = rabbits[4];
					break;
					
				case 4:
					rabbitRend.sprite = rabbits[6];
					break;
				}
			}

			else
			{
				frameTimer -= Time.deltaTime;
				if (frameTimer <= 0) 
				{
					spriteToShow = (spriteToShow + 1) % 2;
					ResetFrameTimer();
				}
				
				switch (rabMove.facing) 
				{
				case 1:
					rabbitRend.sprite = rabbits[spriteToShow];
					break;
				case 2:
					rabbitRend.sprite = rabbits[spriteToShow + 2];
					break;
				case 3:
					rabbitRend.sprite = rabbits[spriteToShow + 4];
					break;
				case 4:
					rabbitRend.sprite = rabbits[spriteToShow + 6];
					break;
				}
			}
		}

		else
		{
			switch(rabMove.facing)
			{
			case 1:
				rabbitRend.sprite = rabbits[8];
				break;
			case 2:
				rabbitRend.sprite = rabbits[8];
				break;

			case 3:
				rabbitRend.sprite = rabbits[9];
				break;
			case 4:
				rabbitRend.sprite = rabbits[9];
				break;
			}
		}

	}

	void ResetFrameTimer() 
	{
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
