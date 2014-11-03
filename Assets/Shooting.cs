using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public int shotCD;

	private int counter;
	private Movement movement;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z) && counter >= shotCD)
		{
			// cannot convert this to rigidbody2d
			GameObject clone;
			clone = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);

			counter = 0;
		}
		counter++;
	}
}
