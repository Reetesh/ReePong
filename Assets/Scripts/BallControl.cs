using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	public AudioClip playerImpactSound;

	// Use this for initialization
	void Start () {
		delayAction (2.0f);
		goBall ();
	}

	IEnumerator delayAction(float sec) {
		yield return new WaitForSeconds (sec);
	}

	void goBall() {
		float rand = Random.Range (0.0f, 100.0f);
		if (rand < 50.0f) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(20.0f, 15.0f));
		} else {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-20.0f, -15.0f));
		}
	}

	void centerBall() {
		var vel = GetComponent<Rigidbody2D>().velocity;
		vel.y = 0;
		vel.x = 0;
		GetComponent<Rigidbody2D>().velocity = vel;
		gameObject.transform.position = new Vector2 (0, 0);
	}

	void newBall() {
		centerBall ();
		delayAction (0.5f);
		goBall ();
	}

	void OnCollisionEnter2D ( Collision2D collision) {
		if( collision.collider.CompareTag ("Player")) {
			GetComponent<AudioSource>().PlayOneShot(playerImpactSound);
			var velY = GetComponent<Rigidbody2D>().velocity;
			//TODO maybe add actual 2D geometry math to this later on
			velY.y = (velY.y/2.0f) + (collision.collider.GetComponent<Rigidbody2D>().velocity.y/3.0f);
			GetComponent<Rigidbody2D>().velocity = velY;
		}
	}

	// Update is called once per frame
	void Update () {
			
	}
}