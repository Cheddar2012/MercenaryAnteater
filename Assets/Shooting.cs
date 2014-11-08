using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet; 	// RS: currently our blue circle sprite
	public int shotCD; 			// RS: can be changed in inspector, may not be the best implementation
	public float multiplier; 	// RS: is the distance between player and bullet's instantiation
								// 		must be greater than 0.6						

	private int counter; 
	private Movement player; 	// RS: gets the player's movement script for "facing"

	// Use this for initialization
	void Start () {
		shotCD = 10;
		player = GameObject.Find ("Player").GetComponent<Movement> ();
		counter = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// RS: if the player wants to shoot, we make sure that it has been 
		//  long enough of a cooldown
		if(Input.GetKeyDown(KeyCode.Z) && counter >= shotCD)
		{
			GameObject clone;

			switch(player.facing)
			{
			case 1:
				clone = Instantiate(bullet, transform.position + multiplier* Vector3.up , Quaternion.identity) as GameObject;
				break;
			case 2:
				clone = Instantiate(bullet, transform.position + multiplier*Vector3.left , Quaternion.identity) as GameObject;
				break;
			case 3:
				clone = Instantiate(bullet, transform.position + multiplier*Vector3.down , Quaternion.identity) as GameObject;
				break;
			case 4:
				clone = Instantiate(bullet, transform.position + multiplier*Vector3.right , Quaternion.identity) as GameObject;
				break;
			}

			// RS: this counter will be reset zero only if the player decides to shoot
			//  and has waited long enough
			counter = 0;
		}
		// update every frame for our cooldown counter
		counter++;
	}
}
