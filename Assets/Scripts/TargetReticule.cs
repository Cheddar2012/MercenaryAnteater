using UnityEngine;
using System.Collections;

public class TargetReticule : MonoBehaviour 
{
	private int direction;
	private Transform playerLoc;
	private Movement face;

	// Use this for initialization
	void Start () 
	{
		playerLoc = GameObject.Find("Player").GetComponent<Transform>();
		face = GameObject.Find ("Player").GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// 1 is up
		// 2 is left
		// 3 is down
		// 4 is right

		// range of the grenade is 125 from the player position

		switch(face.facing)
		{
		case 1:
			// up is +y
			transform.position = new Vector2(playerLoc.position.x - 18, playerLoc.position.y + 160);
			break;

			// left is -x
		case 2:
			transform.position = new Vector2(playerLoc.position.x - 185, playerLoc.position.y + 10);
			break;

			// down is -y
		case 3:
			transform.position = new Vector2(playerLoc.position.x + 5, playerLoc.position.y - 170);
			break;

			// right is +x
		case 4:
			transform.position = new Vector2(playerLoc.position.x + 185, playerLoc.position.y + 10);
			break;
		}
	}
}
