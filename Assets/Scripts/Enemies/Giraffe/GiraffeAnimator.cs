using UnityEngine;
using System.Collections;

public class GiraffeAnimator : MonoBehaviour 
{
	// JH borrowed this from playerAnimator
	public Sprite[] animals;
	public SpriteRenderer giraffeRend;
	public int spriteToShow;
	public GameObject player;

	// JH trying to figure out how to animate muzzle flash
	public GiraffeShooting gShoot;
	public float shootTime = 0.3f;

	// jh 2 is left, 4 is right
	public int direction;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
		giraffeRend = (SpriteRenderer)GetComponent("SpriteRenderer");
		gShoot = (GiraffeShooting)GetComponent("GiraffeShooting");
		direction = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// JH if Giraffe is not shooting
		if(!gShoot.shooting)
		{
			// JH facing left
			if( (player.transform.position.x - transform.position.x < 0) )
			{
				direction = 2;
				giraffeRend.sprite = animals[0];
			}
			
			// jh facing right
			else
			{
				direction = 4;
				giraffeRend.sprite = animals[2];
			}
		}

		// JH then Giraffe is shooting
		else
		{
			if(direction == 2)
			{
				giraffeRend.sprite = animals[1];
			}

			else
			{
				giraffeRend.sprite = animals[3];
			}

			shootTime = Time.time + shootTime;
		}
	}
}
