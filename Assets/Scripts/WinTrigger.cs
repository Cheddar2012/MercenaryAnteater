using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	public GameObject boss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if (boss == null) {
				Application.LoadLevel("Scene003");
			}
		}
	}
}
