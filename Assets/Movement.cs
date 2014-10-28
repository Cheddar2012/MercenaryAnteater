using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float speed = 1.0f;

	/*
	 * FOR MOVING AND FACING:  
	 * 0 IS not moving
	 * 1 IS UP
	 * 2 IS LEFT
	 * 3 IS DOWN
	 * 4 IS RIGHT
	 */
	public bool moving;
	public int facing;
	
	// Use this for initialization
	void Start () 
	{
		moving = false;
		facing = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKey(KeyCode.UpArrow) )
		{
			moving = true;
			facing = 1;
		}
		else if(Input.GetKey(KeyCode.LeftArrow) )
		{
			moving = true;
			facing = 2;
		}
		else if(Input.GetKey(KeyCode.DownArrow) )
		{
			moving = true;
			facing = 3;
		}
		else if(Input.GetKey(KeyCode.RightArrow) )
		{
			moving = true;
			facing = 4;
		}
		else
		{
			moving = false;
		}

		if (moving) {
			switch (facing) {
			case 1: // Moving Up
				transform.position = new Vector2(transform.position.x, transform.position.y + speed);
				break;
			case 2: // Moving Left
				transform.position = new Vector2(transform.position.x - speed, transform.position.y);
				break;
			case 3: // Moving Down
				transform.position = new Vector2(transform.position.x, transform.position.y - speed);
				break;
			case 4: // Moving Right
				transform.position = new Vector2(transform.position.x + speed, transform.position.y);
				break;
			}
		}
	}
}
