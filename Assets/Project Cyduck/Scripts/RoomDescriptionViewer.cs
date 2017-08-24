using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDescriptionViewer : MonoBehaviour {

	public Image roomImage;
	public Text roomTitle;
	public Text roomDescription;
	public RoomBehaviour roomBehaviour;
	private RoomDescription currentRoomDescription;

	void Start() {
		UpdateRoomDescription ();
	}

	// Update is called once per frame
	void Update () {
		if (!currentRoomDescription.roomName.Equals(roomBehaviour.roomDescription.roomName)) {
			UpdateRoomDescription ();
		}
	}

	void UpdateRoomDescription() {
		currentRoomDescription = roomBehaviour.roomDescription;
		if (currentRoomDescription != null) {
			roomImage.sprite = currentRoomDescription.roomImage;
			roomImage.color = currentRoomDescription.color;
			roomTitle.text = currentRoomDescription.roomName;
			roomDescription.text = currentRoomDescription.roomDescription;
		}
	}
}
