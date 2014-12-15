using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour 
{
	public bool hasGun = false;
	public int rapidFire = 0;
	public int sGun = 0;

	// Use this for initialization
	void Start () 
	{
		hasGun = true;
	}

	void AddAmmo(int rAmmo, int sAmmo) 
	{
		rapidFire += rAmmo;
		sGun += sAmmo;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
