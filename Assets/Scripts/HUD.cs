using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	Health healthScript;
	GameObject health;

	//JH added ammo counts to GUI

	Ammo ammoScript;
	GameObject rapid;
	GameObject sGun;

	// Use this for initialization
	void Start () {
		healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		health = new GameObject();
		health.AddComponent("GUIText");
		health.name = "Health GUI";
		health.transform.position = new Vector3(0.05f,0.99f,0.0f);
		health.guiText.text = "";
		health.guiText.fontSize = 48;

		ammoScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
		rapid = new GameObject();
		rapid.AddComponent("GUIText");
		rapid.name = "Rapid Ammo GUI";
		rapid.transform.position = new Vector3(0.35f, 0.99f, 0.0f);
		rapid.guiText.text = "";
		rapid.guiText.fontSize = 26;

		// an element below Rapid Ammo for Grenades

		sGun = new GameObject();
		sGun.AddComponent("GUIText");
		sGun.name = "sGun Ammo GUI";
		sGun.transform.position = new Vector3(0.7f, 0.99f, 0.0f);
		sGun.guiText.text = "";
		sGun.guiText.fontSize = 26;

		// an element below S Gun for E Gun
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		health.guiText.color = Color.red;
		health.guiText.text = "Health: " + healthScript.health;

		rapid.guiText.color = Color.red;
		rapid.guiText.text = "Rapid Gun ammo: " + ammoScript.rapidFire;
		sGun.guiText.color = Color.red;
		sGun.guiText.text = "S Gun ammo: " + ammoScript.sGun;
	}
}
