using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {
	public AudioClip impact;
	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "ball") {
			audio.PlayOneShot(impact, 0.7f);
			string wallName = transform.name;
			GameManager.Score (wallName);
			hitInfo.gameObject.SendMessage ("newBall", 0.5f, SendMessageOptions.RequireReceiver);
		}
	}
}
