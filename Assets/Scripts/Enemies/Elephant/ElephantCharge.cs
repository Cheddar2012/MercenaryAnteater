using UnityEngine;
using System.Collections;

public class ElephantCharge : MonoBehaviour {
	public bool charging{ get; private set; }

	private int chargeDamage;
	private int chargeSpeed;
	private float rollTime;
	private bool moving;
	private EnemyMovement moveScript;
	private GameObject player;
	private int facing;
	private ElephantPunch punchScript;
	private Vector3 playerPos;
	// Use this for initialization
	void Start () {

		rollTime = Time.time;
		chargeDamage = 15;
		chargeSpeed = 20;


		charging = false;
		moving = false;
		moveScript = GetComponent<EnemyMovement>();
		punchScript = GetComponent<ElephantPunch>();
		player = GameObject.Find ("Player");
		playerPos = player.transform.position;
		facing = 2;
	}

	bool PlayerInPath()
	{
		bool xAxis = Mathf.Abs (player.GetComponent<Movement> ().transform.position.x - gameObject.transform.position.x) < 5;
		bool yAxis = Mathf.Abs (player.GetComponent<Movement> ().transform.position.y - gameObject.transform.position.y) < 5;
		return  xAxis || yAxis; 
	}

	bool CanRoll() {
		bool time = rollTime < Time.time;
		return time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		facing = moveScript.facing;

		if (player != null) {
			if(!charging)
			{
				playerPos = player.transform.position;
				moveScript.mobile = true;
			}

			if(PlayerInPath() && CanRoll() && !punchScript.punching)
			{
				charging = true;
				moveScript.mobile = false;
			}

			if(transform.position == playerPos)
				charging = false;

			if(charging)
				transform.position = Vector3.MoveTowards(transform.position, playerPos, chargeSpeed);
		}
	}
}
