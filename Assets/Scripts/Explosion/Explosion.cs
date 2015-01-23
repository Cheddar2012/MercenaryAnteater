using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	public float damage = 20;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// collision does not destroy explosions; they destroy themselves 
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy") // RS: will only deal damage if the unit is an enemy
			other.BroadcastMessage ("ApplyDamage", damage);

		/*
		// JH Pits no longer destroy bullets
		if( (other.tag != "Player") && (other.tag != "Pit") )
			Destroy (gameObject);
		*/
	}
}
