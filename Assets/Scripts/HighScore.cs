using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int score = 1000;

	public Text hs;

	void Start() {
		hs = this.GetComponent<Text> ();
	}

	void Awake () {
		if (PlayerPrefs.HasKey("ApplePickerHighScore")) {
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
			PlayerPrefs.SetInt("ApplePickerHighScore", score);
		}
	}

	void Update () {
		hs.text = "Highscore : " + score;
		if (score > PlayerPrefs.GetInt("ApplePickerHighScore")) {
			PlayerPrefs.SetInt("ApplePickerHighScore", score);
		}
	}
}
