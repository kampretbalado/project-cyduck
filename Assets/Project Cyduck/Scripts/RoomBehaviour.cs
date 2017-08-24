using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomBehaviour : MonoBehaviour {

	private GameManager gameManager;
	private ScoreManager scoreManager;
	private TimeManager timeManager;
	public RoomDescription defaultRoomDescription;
	public RoomDescription roomDescription;
	public RoomStates state;

	//private float invokeMin = 2f;
	//private float invokeMax = 10f;
	private Image image;

	void Awake() {
		GameObject manager = GameObject.FindGameObjectWithTag ("GameController");
		this.gameManager = manager.GetComponent<GameManager> ();
		this.scoreManager = manager.GetComponent<ScoreManager> ();
		this.timeManager = manager.GetComponent<TimeManager> ();

		this.image = this.GetComponent<Image> ();
		this.state = RoomStates.OFF;
	}

	public void Selected(){
		if (this.gameManager.selectedDescription != null && this.gameManager.selectedBehaviour == this) {
			this.DeactivateSelected ();
		}
		this.gameManager.Select (this);
	}

	public void ActivateState(float invokeMin, float invokeMax, RoomDescription description){
		if (description.isCrime)
			this.state = RoomStates.CRIME;
		else
			this.state = RoomStates.NORMAL;

		this.roomDescription = description;
		this.image.color = Color.yellow;
		
		Invoke ("DeactivateStateAuto", Random.Range (invokeMin, invokeMax));
	}


	void DeactivateStateAuto(){
		if (this.state == RoomStates.CRIME) {
			//TODO combo beak here
		}

		DeactivateState ();
	}

	void DeactivateSelected(){
		if (this.state == RoomStates.CRIME) {
			//TODO TAMBAH POIN
			scoreManager.AddScore(100);
			timeManager.AddRemainingTime (0.2f);
		} else {
			//TODO KURANGIN POIN DAN KOMBO BREAK
			scoreManager.AddScore(-100);

		}

		DeactivateState ();
	}

	void DeactivateState(){
		if (this.state == RoomStates.CRIME) {
			this.gameManager.criminalCount--;
		}
		image.color = Color.white;
		gameManager.lightsCount--;
		roomDescription = defaultRoomDescription;
		this.state = 0;
	}
}
