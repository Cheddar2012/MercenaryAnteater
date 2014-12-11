using UnityEngine;
using System.Collections;

public class EnemyCharge : MonoBehaviour {
	public bool charging{ get; private set; }

	private int chargeDamage;
	private int chargeSpeed;
	private float rollTime;
	private bool moving;
	private EnemyMovement moveScript;
	private GameObject player;
	private int facing;
	// Use this for initialization
	void Start () {

		rollTime = Time.time;
		chargeDamage = 15;
		chargeSpeed = 20;


		charging = false;
		moving = false;
		moveScript = GetComponent<EnemyMovement>();
		player = GameObject.Find ("Player");
		facing = 2;
	}

	bool LetsRoll() {
		bool time = rollTime < Time.time;

		return time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		facing = moveScript.facing;
		if (player != null) {
			
		}
	}
}
