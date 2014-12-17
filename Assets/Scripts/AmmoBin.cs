using UnityEngine;
using System.Collections;

public class AmmoBin : MonoBehaviour 
{
	Ammo thisAmmo;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// on collision: 
	// 1) give the player 28 rapid shot ammo
	// 2) give the player 12 Grenades (if implemented)
	// 3) destroy the ammo crate
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			thisAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();

			if(! thisAmmo.hasGun)
			{
				thisAmmo.hasGun = true;
			}

			thisAmmo.rapidFire += 28;
			Destroy(gameObject);
		}
	}
}
