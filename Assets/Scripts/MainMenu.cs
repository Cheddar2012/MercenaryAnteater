using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string text;
	public int fontSize;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent("GUIText");
		gameObject.guiText.text = text;
		gameObject.guiText.anchor = TextAnchor.MiddleCenter;
		gameObject.guiText.alignment = TextAlignment.Center;
		gameObject.guiText.fontSize = fontSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Application.LoadLevel("Scene002");
		}
	}
}
