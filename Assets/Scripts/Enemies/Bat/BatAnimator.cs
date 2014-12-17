using UnityEngine;
using System.Collections;

public class BatAnimator : MonoBehaviour 
{
	// The array of sprites used for animating this character
	public Sprite[] bats;

	// Number of frames to animate each second
	public int framesPerSecond = 10;

	// The object's SpriteRenderer
	public SpriteRenderer batRend;

	// This enemy object's EnemyMovement script
	public BatMovement batMove;

	// Countdown until the next frame
	private float frameTimer;
	
	// Number of frames in walking animation
	private float walkingFrames;
	
	// Which sprite to show in the sprites array
	public int spriteToShow;

	// Use this for initialization
	void Start () 
	{
		batRend = (SpriteRenderer)GetComponent("SpriteRenderer");
		batMove = (BatMovement)GetComponent("BatMovement");
		ResetFrameTimer();
		batRend.sprite = bats[2];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(batMove.moving)
		{
			frameTimer -= Time.deltaTime;
			if (frameTimer <= 0) 
			{
				spriteToShow = (spriteToShow + 1) % 2;
				ResetFrameTimer();
			}

			batRend.sprite = bats[spriteToShow];
		}

		else
		{
			batRend.sprite = bats[2];
		}
	}


	void ResetFrameTimer() 
	{
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
