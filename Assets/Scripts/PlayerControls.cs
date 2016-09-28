using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public float speed = 10.0f;

	// Update is called once per frame
	void Update () {

		var vel = rigidbody2D.velocity;
		vel.x = 0;
		vel.y = 0;
		if (Input.GetKey(moveUp)) {
			vel.y = speed;
		} else if (Input.GetKey(moveDown)) {
			vel.y = -1*speed;
		} else if ( !Input.anyKey ) {
			vel.y = 0f;
		}
		rigidbody2D.velocity = vel;
	}
}