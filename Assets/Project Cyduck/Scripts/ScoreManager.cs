using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreViewer;
	public Text highScoreViewer;

	private int gameScore;
	public int score {
		get {
			return gameScore;
		}
	}

	void Awake() {
		if (highScoreViewer != null) {
			highScoreViewer.text = PlayerPrefs.GetInt ("HighScore", 0).ToString();
		}
	}

	public void AddScore(int added) {
		gameScore += added;
	}

	void Update() {
		if (scoreViewer != null) {
			scoreViewer.text = gameScore.ToString();
		}
	}
}
