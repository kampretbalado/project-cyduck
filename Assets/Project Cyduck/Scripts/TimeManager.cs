using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public int initialTime;
	public Text textViewer;

	private float remaining; 
	public int remainingTime {
		get {
			return Mathf.FloorToInt (remaining);
		}
		set {
			remaining = value;
		}
	}

	void Awake() {
		remaining = (float) initialTime + 1.0f;
	}

	// Update is called once per frame
	void Update () {
		remaining -= Time.deltaTime;
		if (IsTimeUp()) {
			remaining = 0f;
		}

		if (textViewer != null) {
			textViewer.text = remainingTime.ToString ();
		}
	}

	public void AddRemainingTime(float addTime) {
		remaining += addTime;
	}

	public bool IsTimeUp() {
		return remaining > 0f ? false : true;
	}
}