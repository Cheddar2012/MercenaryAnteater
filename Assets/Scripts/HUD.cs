using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	Health healthScript;
	GameObject health;

	// Use this for initialization
	void Start () {
		healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		health = new GameObject();
		health.AddComponent("GUIText");
		health.transform.position = new Vector3(0.11f,0.98f,0.0f);
		health.guiText.text = "";
		health.guiText.fontSize = 64;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		health.guiText.text = "" + healthScript.health;
	}
}
