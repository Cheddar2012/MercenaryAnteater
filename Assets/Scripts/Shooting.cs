using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet; 	// RS: currently our blue circle sprite
	public float shotCD; 			// RS: can be changed in inspector, may not be the best implementation
	public float multiplier; 	// RS: is the distance between player and bullet's instantiation
								// 		must be greater than 0.6						
	 
	private Movement player; 	// RS: gets the player's movement script for "facing"
	private float timestamp;
	// Use this for initialization
	void Start () {
		shotCD = 0.2f;
		player = GameObject.Find ("Player").GetComponent<Movement> ();
		timestamp = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// RS: if the player wants to shoot, we make sure that it has been 
		//  long enough of a cooldown
		if(Input.GetKeyDown(KeyCode.Z) && timestamp <= Time.time)
		{
			GameObject clone;

			switch(player.facing)
			{
			case 1:
				Instantiate(bullet, transform.position + multiplier* Vector3.up , Quaternion.identity);
				break;
			case 2:
				Instantiate(bullet, transform.position + multiplier*Vector3.left , Quaternion.identity);
				break;
			case 3:
				Instantiate(bullet, transform.position + multiplier*Vector3.down , Quaternion.identity);
				break;
			case 4:
				Instantiate(bullet, transform.position + multiplier*Vector3.right , Quaternion.identity);
				break;
			}

			// RS: means next time player can shoot will be the current time + however long
			//	the cooldown is
			timestamp = Time.time + shotCD;
		}
	}
}
