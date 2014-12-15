using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 50;		// RS: self-explanatory 
	public bool poisoned = false;	// RS: will make life easier for animation

	private float poisonDamage;		// RS: damage to deal over time
	private float poisonedTime;		// RS: marker for when poison ends

	GameObject message;

	// Use this for initialization
	void Start () {
		poisoned = false;
		poisonedTime = Time.time;
	}

	// RS: applies poison damage
	void ApplyPoison()
	{
		ApplyDamage (poisonDamage);
	}

	// RS: sets poison damage
	void SetPoisonDamage(int damage)
	{
		poisonDamage = damage;
	}

	// RS: poisons player and creates DOT (damage over time)
	void PoisonPlayer(float duration){
		poisoned = true;
		poisonedTime = Time.time + duration;
		InvokeRepeating ("ApplyPoison", 1, 1);
	}

	// RS: player takes i damage
	void ApplyDamage (float i) {
		health -= i;
		if (health <= 0) { // RS: kill
			health = 0;

			if(gameObject.tag != "Player")
			{
				Destroy (gameObject);
			}

			else
			{
				message = new GameObject();
				message.AddComponent("GUIText");
				message.transform.position = new Vector3(0.25f, 0.5f, 0);
				
				message.guiText.fontSize = 60;
				message.guiText.color = Color.blue;
				message.guiText.text = "YOU DIED";
				
				Application.LoadLevel("Scene002");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (poisoned && Time.time >= poisonedTime) {
			poisoned = false;
			CancelInvoke("ApplyPoison");
		}
	}

	/*
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Heal") {
			GetComponent<Health>().health = 50;
		}
	}
	*/
}
