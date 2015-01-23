using UnityEngine;
using System.Collections;

public class ExplosionAnimator : MonoBehaviour 
{
	// The array of sprites used for animating this character
	public Sprite[] exploder;
	
	// Number of frames to animate each second
	public int framesPerSecond = 5;
	
	// The object's SpriteRenderer
	public SpriteRenderer explodeRend;

	// Countdown until the next frame
	private float frameTimer;

	// Which sprite to show in the sprites array
	public int spriteToShow;

	// Use this for initialization
	void Start () 
	{
		explodeRend = (SpriteRenderer)GetComponent("SpriteRenderer");
		ResetFrameTimer();
		explodeRend.sprite = exploder[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		frameTimer -= Time.deltaTime;
		if ( (frameTimer <= 0) && (spriteToShow < 5) )
		{
			if(spriteToShow == 4)
			{
				Destroy(gameObject);
			}

			else
			{
				ResetFrameTimer();
				explodeRend.sprite = exploder[spriteToShow];
				spriteToShow = (spriteToShow + 1);
			}
		}

	}

	void ResetFrameTimer() 
	{
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
