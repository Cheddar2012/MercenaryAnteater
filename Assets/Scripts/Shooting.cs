using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet; 	// RS: currently our blue circle sprite
								// JH changed to a smaller black circle, more like a bullet :-p
	public GameObject bullet2;
	public GameObject bullet3;

	public float shotCD = 0.2f;	// RS: can be changed in inspector, may not be the best implementation
	public KeyCode code = KeyCode.Z;

	// JH adding code for rapid fire gun
	public KeyCode daka = KeyCode.X;

	// JH adding code for shotgun
	public KeyCode shotgun = KeyCode.V;


	private float multiplier; 	// RS: is the distance between player and bullet's instantiation
	private Movement player; 	// RS: gets the player's movement script for "facing"
	private float basicShotStamp;
	private float rapidShotStamp;
	private float shotgunShotStamp;

	//JH added ammo implementation
	private Ammo playerAmmo;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Movement> ();
		basicShotStamp = 0;
		rapidShotStamp = 0;
		shotgunShotStamp = 0;
		multiplier = 1;
		playerAmmo = GameObject.Find("Player").GetComponent<Ammo>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// RS: if the player wants to shoot, we make sure that it has been 
		//  long enough of a cooldown
		if(Input.GetKeyDown (code) && basicShotStamp <= Time.time)
		{
			GameObject shooter;

			switch(player.facing)
			{
			case 1:
				shooter = (GameObject) Instantiate(bullet, transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				break;
			case 2:
				shooter = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left , Quaternion.identity);
				break;
			case 3:
				shooter = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				break;
			case 4:
				shooter = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				break;
			}

			// RS: means next time player can shoot will be the current time + however long
			//	the cooldown is
			basicShotStamp = Time.time + shotCD;
		}

		// JH if/switch for machine gun attack
		// fires 3 bullets at one
		// each bullet has a slightly different start point and a 
		// slightly different speed
		if( (Input.GetKeyDown (daka) ) && (rapidShotStamp <= Time.time) && (playerAmmo.rapidFire > 0) )
		{
			GameObject rapid1;
			GameObject rapid2;
			GameObject rapid3;

			switch(player.facing)
			{
			case 1:
				rapid1 = (GameObject) Instantiate(bullet, transform.position + 27 * multiplier * Vector3.up , Quaternion.identity);

				rapid2 = (GameObject) Instantiate(bullet, transform.position + 26 * multiplier * Vector3.up , Quaternion.identity);
				rapid2.rigidbody2D.AddForce(new Vector2(0, -20) );

				rapid3 = (GameObject) Instantiate(bullet, transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				rapid3.rigidbody2D.AddForce(new Vector2(0, -40) );

				break;

			case 2:
				rapid1 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left , Quaternion.identity);
				rapid1.rigidbody2D.transform.position = new Vector2(rapid1.rigidbody2D.transform.position.x -2, rapid1.rigidbody2D.transform.position.y);

				rapid2 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left, Quaternion.identity);
				rapid2.rigidbody2D.transform.position = new Vector2(rapid2.rigidbody2D.transform.position.x -1, rapid2.rigidbody2D.transform.position.y);
				rapid2.rigidbody2D.AddForce(new Vector2(20, 0) );

				rapid3 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left, Quaternion.identity);
				rapid3.rigidbody2D.AddForce(new Vector2(40, 0) );

				break;

			case 3:
				rapid1 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				rapid1.rigidbody2D.transform.position = new Vector2(rapid1.rigidbody2D.transform.position.x, rapid1.rigidbody2D.transform.position.y -2);

				rapid2 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				rapid2.rigidbody2D.transform.position = new Vector2(rapid2.rigidbody2D.transform.position.x, rapid2.rigidbody2D.transform.position.y -1);
				rapid2.rigidbody2D.AddForce(new Vector2(0, 20) );

				rapid3 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				rapid3.rigidbody2D.AddForce(new Vector2(0, 40) );
				break;

			case 4:
				rapid1 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				rapid1.rigidbody2D.transform.position = new Vector2(rapid1.rigidbody2D.transform.position.x + 4, rapid1.rigidbody2D.transform.position.y);

				rapid2 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				rapid2.rigidbody2D.transform.position = new Vector2(rapid2.rigidbody2D.transform.position.x + 2, rapid2.rigidbody2D.transform.position.y);
				rapid2.rigidbody2D.AddForce(new Vector2(-20, 0) );

				rapid3 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				rapid3.rigidbody2D.AddForce(new Vector2(-40, 0) );
				break;
			}

			// RS: means next time player can shoot will be the current time + however long
			//	the cooldown is
			rapidShotStamp = Time.time + shotCD;

			// JH costs one bullet to fire rapid fire
			playerAmmo.rapidFire -=1;
		}

		// JH created a similar if/switch shotgun attacks
		// shotgun shoots 3 bullets, but the range is short 
		// need to create a new prefab to be bullets that are short range 
		if( (Input.GetKeyDown (shotgun) ) && (shotgunShotStamp <= Time.time) && (playerAmmo.sGun > 0) )
		{
			GameObject shell1;
			GameObject shell2;
			GameObject shell3;

			switch(player.facing)
			{
			case 1:
				shell1 = (GameObject) Instantiate(bullet, transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				
				shell2 = (GameObject) Instantiate(bullet, transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				shell2.rigidbody2D.AddForce(new Vector2(100, 0) );
				
				shell3 = (GameObject) Instantiate(bullet, transform.position + 25 * multiplier * Vector3.up , Quaternion.identity);
				shell3.rigidbody2D.AddForce(new Vector2(-100, 0) );
				break;
			case 2:
				shell1 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left , Quaternion.identity);
				
				shell2 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left , Quaternion.identity);
				shell2.rigidbody2D.AddForce(new Vector2(0, 100) );
				
				shell3 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.left , Quaternion.identity);
				shell3.rigidbody2D.AddForce(new Vector2(0, -100) );
				break;
			case 3:
				shell1 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				
				shell2 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				shell2.rigidbody2D.AddForce(new Vector2(-100, 0) );
				
				shell3 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.down , Quaternion.identity);
				shell3.rigidbody2D.AddForce(new Vector2(100, 0) );
				break;
			case 4:
				shell1 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				
				shell2 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				shell2.rigidbody2D.AddForce(new Vector2(0, -100) );
				
				shell3 = (GameObject) Instantiate(bullet, transform.position + multiplier * Vector3.right , Quaternion.identity);
				shell3.rigidbody2D.AddForce(new Vector2(0, 100) );
				break;
			}
			
			// RS: means next time player can shoot will be the current time + however long
			//	the cooldown is
			shotgunShotStamp = Time.time + shotCD;

			// JH costs one shell to fire the S gun
			playerAmmo.sGun -= 1;
		}
	}
}
