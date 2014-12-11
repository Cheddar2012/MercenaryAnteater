using UnityEngine;
using System.Collections;

public class ElephantTrunk : MonoBehaviour {

	public int damage = 20;
	public float range = 30;

	private int direction;
	private ElephantPunch ePunch;
	private Vector3 finishPos;
	// Use this for initialization
	void Start () {
		ePunch = transform.parent.gameObject.GetComponent<ElephantPunch> ();
		direction = ePunch.facing;

		damage = 20;
		range = 30;

		if (direction == 2)
			finishPos = transform.position + Vector3.left * range;
		else
			finishPos = transform.position + Vector3.right * range;

		Destroy (gameObject, 1);
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.tag == "Player") {
			col.BroadcastMessage ("ApplyDamage", damage);
			Destroy (gameObject);
		}
	}

	void OnDestroy(){
		ePunch.punching = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards(transform.position, finishPos, 8);
	}
}