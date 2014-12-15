﻿using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	// The array of sprites used in walking animation
	public Sprite[] walkingSprites;

	// Number of frames to animate each second
	public int framesPerSecond = 10;

	// The player object's SpriteRenderer
	public SpriteRenderer renderer;

	// This player object's Movement script
	public Movement movement;

	// Countdown until the next frame
	private float frameTimer;

	// Number of frames in walking animation
	private float numberOfFrames;

	// Which sprite to show in the walking animation
	public int spriteToShow = 0;

	Health health;

	// Use this for initialization
	void Start () {
		renderer = (SpriteRenderer)GetComponent("SpriteRenderer");
		movement = (Movement)GetComponent("Movement");
		health = GameObject.Find("Player").GetComponent<Health>();

		ResetFrameTimer();

		CalculateNumberOfFrames();

		renderer.sprite = walkingSprites[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( (!movement.moving) && (health.health > 0) ) 
		{
			switch (movement.facing) {
			case 1:
				renderer.sprite = walkingSprites[0];
				break;
			case 2:
				renderer.sprite = walkingSprites[5];
				break;
			case 3:
				renderer.sprite = walkingSprites[9];
				break;
			case 4:
				renderer.sprite = walkingSprites[13];
				break;
			}
		}
		else if(health.health > 0)
		{
			frameTimer -= Time.deltaTime;
			if (frameTimer <= 0) {
				spriteToShow = (spriteToShow + 1) % 4;
				ResetFrameTimer();
			}
			switch (movement.facing) {
			case 1:
				renderer.sprite = walkingSprites[spriteToShow];
				break;
			case 2:
				renderer.sprite = walkingSprites[4 + spriteToShow];
				break;
			case 3:
				renderer.sprite = walkingSprites[8 + spriteToShow];
				break;
			case 4:
				renderer.sprite = walkingSprites[12 + spriteToShow];
				break;
			}
		}
	}

	void ResetFrameTimer() {
		frameTimer = 1.0f / (float)framesPerSecond;
	}

	void CalculateNumberOfFrames() {
		// Length of walking sprites array divided by four walking directions
		numberOfFrames = walkingSprites.Length / 4;
	}
}
