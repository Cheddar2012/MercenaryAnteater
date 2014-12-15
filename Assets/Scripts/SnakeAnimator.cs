using UnityEngine;
using System.Collections;

public class SnakeAnimator : MonoBehaviour {

	// The array of sprites used for animating this character
	public Sprite[] sprites;

	// Number of frames to animate each second
	public int framesPerSecond = 10;

	// The object's SpriteRenderer
	public SpriteRenderer renderer;

	// This enemy object's EnemyMovement script
	public EnemyMovement movement;

	// Countdown until the next frame
	private float frameTimer;

	// Number of frames in walking animation
	private float walkingFrames;

	// Which sprite to show in the sprites array
	public int spriteToShow;

	// We need to know the player's position to know whether to look right or left
	public GameObject player;

	// We need to know whether or not the enemy is attacking
	public SnakeAttack sAttack;
	public float attackTime = 0.3f;

	public int direction;

	// Use this for initialization
	void Start () {

		renderer = (SpriteRenderer)GetComponent("SpriteRenderer");
		movement = (EnemyMovement)GetComponent("EnemyMovement");

		ResetFrameTimer();

		renderer.sprite = sprites[0];

		sAttack = (SnakeAttack)GetComponent("SnakeAttack");

		player = GameObject.Find ("Player");

		direction = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if(!sAttack.attacking)
		{
			if (!movement.moving) 
			{
				switch (movement.facing) {
				case 2:
					renderer.sprite = sprites[0];
					break;
				case 4:
					renderer.sprite = sprites[4];
					break;
				}
			}
			else {
				frameTimer -= Time.deltaTime;
				if (frameTimer <= 0) {
					spriteToShow = (spriteToShow + 1) % 3;
					ResetFrameTimer();
				}
				switch (movement.facing) {
				case 2:
					renderer.sprite = sprites[spriteToShow];
					break;
				case 4:
					renderer.sprite = sprites[4 + spriteToShow];
					break;
				}
			}
		}

		else
		{
			if(movement.facing == 2)
			{
				renderer.sprite = sprites[3];
			}
			
			else
			{
				renderer.sprite = sprites[7];
			}
			
			attackTime = Time.time + attackTime;
		}
	}

	void ResetFrameTimer() {
		frameTimer = 1.0f / (float)framesPerSecond;
	}
}
