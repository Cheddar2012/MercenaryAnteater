using UnityEngine;
using System.Collections;

public class AntHillAnimator : MonoBehaviour 
{
	// The array of sprites used for animating this character
	public Sprite[] antHills;
	
	// Number of frames to animate each second
	public int framesPerSecond = 2;
	
	// The object's SpriteRenderer
	public SpriteRenderer antHillRend;
	
	// Countdown until the next frame
	private float frameTimer;
	
	// Number of frames in  animation
	private float antFrames;
	
	// Which sprite to show in the sprites array
	public int spriteToShow;
	
	// Use this for initialization
	void Start () 
	{
		antHillRend = (SpriteRenderer)GetComponent("SpriteRenderer");
		ResetFrameTimer();
		antHillRend.sprite = antHills[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		frameTimer -= Time.deltaTime;
		if (frameTimer <= 0) 
		{
			spriteToShow = (spriteToShow + 1) % 4;
			ResetFrameTimer();
		}
		
		antHillRend.sprite = antHills[spriteToShow];
	}

	void ResetFrameTimer() 
	{
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
