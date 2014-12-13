using UnityEngine;
using System.Collections;

public class ElephantPunch : MonoBehaviour {
	public int facing { get; private set; }
	public bool punching { get; set; }
	public GameObject trunk;

	private float punchCD;
	private float punchRange;
	private float punchTime;
	private bool moving;
	private EnemyMovement moveScript;
	private EnemyCharge chargeScript;
	private GameObject player;
	private int verticalRange;
	// Use this for initialization
	void Start () {
		punchRange = 70;
		punchTime = Time.time;
		punchCD = 3;
		punching = false;
		player = GameObject.Find ("Player");
		moveScript = gameObject.GetComponent<EnemyMovement> ();
		facing = moveScript.facing;
		verticalRange = 25;
		chargeScript = gameObject.GetComponent<EnemyCharge> ();
	}

	bool Charging() {
		return chargeScript.charging;
	}

	bool PunchingTime() {
		return punchTime < Time.time;
	}
	
	bool InPunchRange(){
		bool range =  Mathf.Abs(Vector3.Distance (player.transform.position, transform.position)) < punchRange; 
		bool height = Mathf.Abs (player.transform.position.y - transform.position.y) < verticalRange * 2;
		return range && height;
	}
	
	// Update is called once per frame
	void Update () {
		facing = moveScript.facing;
		if (InPunchRange() && PunchingTime () && !Charging ()) {
			GameObject clone = (GameObject) Instantiate (trunk, transform.position + Vector3.up * verticalRange, Quaternion.identity);
			clone.transform.parent = gameObject.transform;
			punchTime = Time.time + punchCD;
			punching = true;
		}
	}
}
