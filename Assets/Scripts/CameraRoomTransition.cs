using UnityEngine;
using System.Collections;

public class CameraRoomTransition : MonoBehaviour {

	public float roomWidth = 480;
	public float roomHeight = 288;

	Vector3 currentPosition;
	//Vector3 newPosition;
	Transform playerTransform;

	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.x > currentPosition.x + roomWidth/2) {
			currentPosition = currentPosition + new Vector3(roomWidth,0,0);
		} else if (playerTransform.position.x < currentPosition.x - roomWidth/2) {
			currentPosition = currentPosition - new Vector3(roomWidth,0,0);
		} else if (playerTransform.position.y > currentPosition.y + roomHeight/2) {
			currentPosition = currentPosition + new Vector3(0,roomHeight,0);
		} else if (playerTransform.position.y < currentPosition.y - roomHeight/2) {
			currentPosition = currentPosition - new Vector3(0,roomHeight,0);
		}
		transform.position = currentPosition;
	}
}
