using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<TimeManager> {

	protected ScoreManager () {}

	public Text scoreViewer;

	private int gameScore;
	public int score {
		get {
			return gameScore;
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
