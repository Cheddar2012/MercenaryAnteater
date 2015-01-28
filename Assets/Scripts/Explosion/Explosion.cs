using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	public float damage = 20;

	public bool hero;

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
		if( (other.tag == "Enemy") && (hero) ) // RS: will only deal damage if the unit is an enemy
			other.BroadcastMessage ("ApplyDamage", damage);

		if( (other.tag == "Player") && (!hero) )
		{
			other.BroadcastMessage ("ApplyDamage", damage);
		}
	}
}
