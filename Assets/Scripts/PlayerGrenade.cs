using UnityEngine;
using System.Collections;

public class PlayerGrenade : MonoBehaviour 
{
	public float damage = 20;
	public Vector3 speed;
	private int direction;

	// Use this for initialization
	void Start () 
	{
		// direction = GameObject.Find ("Player").GetComponent<Movement> ().facing;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
