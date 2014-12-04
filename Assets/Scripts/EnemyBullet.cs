using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	
	public float damage = 15;
	public float pushForce = 20;
	
	public int direction{ get; set; }
	// Use this for initialization
	void Start () {
		direction = transform.parent.gameObject.GetComponent<EnemyMovement>().facing;
		if(direction == 2)
			rigidbody2D.AddForce(new Vector2(-pushForce, 0));
		else if(direction == 4)
			rigidbody2D.AddForce(new Vector2(pushForce, 0));
	}

	
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
			col.BroadcastMessage ("ApplyDamage", damage);
		if (col.gameObject.tag != "Enemy")
			Destroy (gameObject);
						
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
