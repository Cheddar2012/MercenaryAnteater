using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Rigidbody bullet;
	public int shotCD;
	private int counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z) && counter >= shotCD)
		{
			Rigidbody clone;
			clone = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);

			counter = 0;
		}
		counter++;
	}
}
