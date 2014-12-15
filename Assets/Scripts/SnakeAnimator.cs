using UnityEngine;
using System.Collections;

public class SnakeAnimator : MonoBehaviour {

	public Sprite[] animals;
	public SpriteRenderer renderer;
	public int spriteToShow;
	public GameObject player;

	public SnakeAttack sAttack;
	public float attackTime = 0.3f;

	public int direction;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		renderer = (SpriteRenderer)GetComponent("SpriteRenderer");
		sAttack = (SnakeAttack)GetComponent("SnakeAttack");
		direction = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if(!sAttack.attacking)
		{
			// facing left
			if( (player.transform.position.x - transform.position.x < 0) )
			{
				direction = 2;
				renderer.sprite = animals[0];
			}
			
			// facing right
			else
			{
				direction = 4;
				renderer.sprite = animals[2];
			}
		}

		else
		{
			if(direction == 2)
			{
				renderer.sprite = animals[1];
			}
			
			else
			{
				renderer.sprite = animals[3];
			}
			
			attackTime = Time.time + attackTime;
		}
	}
}
