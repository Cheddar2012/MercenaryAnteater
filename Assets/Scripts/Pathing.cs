using UnityEngine;
using System.Collections;

public class Pathing : MonoBehaviour {

	// Currently only moves to the right

	// RS: Pathing will be applied to most enemies. We know if they are mobile,
	//	what their agro range is, and how fast they run.

	public bool 		moves 		= true;
	public int 			agroRange 	= 5;
	public float 		speed 		= 1.0f; // may want to make public ?
	private GameObject 	player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// if the NPC chases, then move it towards the player
		if (moves) { 
			if(Vector3.Distance(player.transform.position, transform.position) > agroRange) {
				transform.Translate(new Vector2(speed, 0));
			}
		}
	}
}
