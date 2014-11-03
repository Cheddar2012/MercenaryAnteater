using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet; // RS: currently our blue circle sprite
	public int shotCD; // RS: can be changed in inspector, may not be the best implementation

	private int counter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// RS: if the player wants to shoot, we make sure that it has been 
		//  long enough of a cooldown
		if(Input.GetKeyDown(KeyCode.Z) && counter >= shotCD)
		{
			GameObject clone;
			clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;

			// RS: this counter will be reset zero only if the player decides to shoot
			//  and has waited long enough
			counter = 0;
		}
		// update every frame for our cooldown counter
		counter++;
	}
}
