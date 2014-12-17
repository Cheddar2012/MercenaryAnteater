using UnityEngine;
using System.Collections;

public class BatAnimator : MonoBehaviour 
{
	// The array of sprites used for animating this character
	public Sprite[] bats;

	// Number of frames to animate each second
	public int framesPerSecond = 10;

	// The object's SpriteRenderer
	public SpriteRenderer renderer;

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
		renderer = (SpriteRenderer)GetComponent("SpriteRenderer");
		batMove = (BatMovement)GetComponent("BatMovement");
		ResetFrameTimer();
		renderer.sprite = bats[2];
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

			renderer.sprite = bats[spriteToShow];
		}

		else
		{
			renderer.sprite = bats[2];
		}
	}


	void ResetFrameTimer() 
	{
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
