using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	
	public float damage = 10;
	public Vector2 speed;
	
	public int direction{ get; set; }
	// Use this for initialization
	void Start () 
	{
		speed = transform.rigidbody2D.velocity;
		// direction = transform.parent.gameObject.GetComponent<EnemyMovement>().facing;
	}

	
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
			col.BroadcastMessage ("ApplyDamage", damage);

		// JH Pits no longer destroy bullets
		if( (col.tag != "Enemy") && (col.tag != "Pit") ) 
			Destroy (gameObject);
						
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.rigidbody2D.velocity != speed)
		{
			transform.rigidbody2D.velocity = speed;
		}
	}
}
