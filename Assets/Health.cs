using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
		health = 50;
	}

	void ApplyDamage (float i) {
		health -= i;
		if (health <= 0) 
			Destroy (gameObject);
		Debug.Log (health);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
