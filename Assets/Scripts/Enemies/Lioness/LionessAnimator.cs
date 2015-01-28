using UnityEngine;
using System.Collections;

public class LionessAnimator : MonoBehaviour 
{
	/*
	 * this entire code was coy pasted
	 * from other classes whose renderers
	 * are fully functional and tested
	 */

	public Sprite[] lions;
	public SpriteRenderer lionRender;
	public LionessMovement lm;
	public int spriteToShow;

	private float frameTimer;
	public int framesPerSecond = 10;

	// Use this for initialization
	void Start () 
	{
		lionRender = (SpriteRenderer)GetComponent("SpriteRenderer");
		lm = (LionessMovement)GetComponent("LionessMovement");
		ResetFrameTimer();
		lionRender.sprite = lions[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(lm.moving)
		{
			// facing left, walk left
			if(lm.facing == 2)
			{
				frameTimer -= Time.deltaTime;
				if (frameTimer <= 0) 
				{
					spriteToShow = (spriteToShow + 1) % 5;
					ResetFrameTimer();
				}
				
				lionRender.sprite = lions[spriteToShow];
			}

			// facing right, walk right


			else if(lm.facing == 4)
			{
				frameTimer -= Time.deltaTime;
				if (frameTimer <= 0) 
				{
					spriteToShow = ( (spriteToShow + 1) % 5) + 5;
					ResetFrameTimer();
				}
				
				lionRender.sprite = lions[spriteToShow];
			}
		}

		else
		{
			lionRender.sprite = lions[12];
		}
	}

	void ResetFrameTimer() 
	{
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
