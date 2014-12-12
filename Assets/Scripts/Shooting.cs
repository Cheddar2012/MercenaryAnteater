using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet; 	// RS: currently our blue circle sprite
	public float shotCD = 0.2f;	// RS: can be changed in inspector, may not be the best implementation
	public KeyCode code = KeyCode.Z;

	// JH adding code for short range shotgun
	public KeyCode shotgun = KeyCode.V;
	public GameObject bullet2;
	public GameObject bullet3;

	private float multiplier; 	// RS: is the distance between player and bullet's instantiation
	private Movement player; 	// RS: gets the player's movement script for "facing"
	private float timestamp;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Movement> ();
		timestamp = Time.time;
		multiplier = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// RS: if the player wants to shoot, we make sure that it has been 
		//  long enough of a cooldown
		if(Input.GetKeyDown (code) && timestamp <= Time.time)
		{
			GameObject clone;	

			switch(player.facing)
			{
			case 1:
				clone = (GameObject) Instantiate(bullet, transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				break;
			case 2:
				clone = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left , Quaternion.identity);
				break;
			case 3:
				clone = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				break;
			case 4:
				clone = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				break;
			}

			// RS: means next time player can shoot will be the current time + however long
			//	the cooldown is
			timestamp = Time.time + shotCD;
		}

		// JH created a similar if/switch shotgun attacks
		// shotgun shoots 3 bullets, but the range is short 
		// need to create a new prefab to be bullets that are short range 
			if(Input.GetKeyDown (shotgun) && timestamp <= Time.time)
		{
			GameObject clone1;
			GameObject clone2;
			GameObject clone3;
			
			switch(player.facing)
			{
			case 1:
				clone1 = (GameObject) Instantiate(bullet, 
				                                  transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				
				clone2 = (GameObject) Instantiate(bullet, 
				                                  transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				clone2.rigidbody2D.AddForce(new Vector2
				                            (100, 0) );
				
				clone3 = (GameObject) Instantiate(bullet, 
				                                  transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				clone3.rigidbody2D.AddForce(new Vector2
				                            (-100, 0) );
				break;
			case 2:
				clone1 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.left , Quaternion.identity);
				
				clone2 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.left , Quaternion.identity);
				clone2.rigidbody2D.AddForce(new Vector2
				                            (0, 100) );
				
				clone3 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.left , Quaternion.identity);
				clone3.rigidbody2D.AddForce(new Vector2
				                            (0, -100) );
				break;
			case 3:
				clone1 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.down , Quaternion.identity);
				
				clone2 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.down , Quaternion.identity);
				clone2.rigidbody2D.AddForce(new Vector2
				                            (-100, 0) );
				
				clone3 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.down , Quaternion.identity);
				clone3.rigidbody2D.AddForce(new Vector2
				                            (100, 0) );
				break;
			case 4:
				clone1 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.right , Quaternion.identity);
				
				clone2 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.right , Quaternion.identity);
				clone2.rigidbody2D.AddForce(new Vector2
				                            (0, -100) );
				
				clone3 = (GameObject) Instantiate(bullet, 
				                                  transform.position + multiplier * Vector3.right , Quaternion.identity);
				clone3.rigidbody2D.AddForce(new Vector2
				                            (0, 100) );
				break;
			}
			
			// RS: means next time player can shoot will be the current time + however long
			//	the cooldown is
				timestamp = Time.time + shotCD;
		}
	}
}
