using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;


	public AudioClip winSound, startSound;
	public GUISkin layout;
	public GUIStyle style;

	private bool gameWon = false;
	Transform theBall;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().PlayOneShot (startSound);
		theBall = GameObject.FindGameObjectWithTag ("Ball").transform;
	}

	public static void Score(string wallID) {
		if (wallID == "rightWall") {
			PlayerScore1++;
		} else {
			PlayerScore2++;
		}
	}

	void OnGUI() {

		GUI.skin = layout;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
		GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

		if (GUI.Button (new Rect (Screen.width / 2 - 60, 35, 120, 53), "RESET")) {
			PlayerScore1 = 0;
			PlayerScore2 = 0;
			theBall.gameObject.SendMessage("newBall", 0.5f, SendMessageOptions.RequireReceiver);
		}

		if (PlayerScore1 == 10) {
				GUI.Label (new Rect (Screen.width / 2 - 150, 100, 500, 500), "Player ONE wins!");
				theBall.gameObject.SendMessage ("centerBall", null, SendMessageOptions.RequireReceiver);
				if ( !gameWon ) {
					GetComponent<AudioSource>().PlayOneShot(winSound);
					gameWon = true;
				}

					
		} else if (PlayerScore2 == 10) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 100, 500, 500), "Player TWO wins!");
			theBall.gameObject.SendMessage ("centerBall", null, SendMessageOptions.RequireReceiver);
			if ( !gameWon ) {
				GetComponent<AudioSource>().PlayOneShot(winSound);
				gameWon = true;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
