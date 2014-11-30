using UnityEngine;
using System.Collections;

public class CameraRoomTransition : MonoBehaviour {

	public float roomWidth = 480;
	public float roomHeight = 288;

	Vector3 currentPosition;
	//Vector3 newPosition;
	GameObject player;

	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > currentPosition.x + roomWidth/2) {
			currentPosition = currentPosition + new Vector3(roomWidth,0,0);
		} else if (player.transform.position.x < currentPosition.x - roomWidth/2) {
			currentPosition = currentPosition - new Vector3(roomWidth,0,0);
		} else if (player.transform.position.y > currentPosition.y + roomHeight/2) {
			currentPosition = currentPosition + new Vector3(0,roomHeight,0);
		} else if (player.transform.position.y < currentPosition.y - roomHeight/2) {
			currentPosition = currentPosition - new Vector3(0,roomHeight,0);
		}
		transform.position = currentPosition;
	}
}
