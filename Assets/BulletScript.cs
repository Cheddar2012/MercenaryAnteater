using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	float damage;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (new Vector2 (10.0f,0));
	}

	void ApplyDamage(float d)
	{
		print ("damage dealt");
	}

	void OnTriggerEnter(Collider other)
	{
		gameObject.SendMessage ("ApplyDamage", damage);
		Destroy (other.gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
