using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//public string selectedName;
	public RoomBehaviour selectedBehaviour;
	public RoomDescription selectedDescription;
	public RoomDescription[] possibleCrimeRooms;
	public RoomDescription[] possibleNormalRooms;
	public Canvas guiCanvas;

	public RoomDescriptionViewer viewer;

	//konvensi 0 = mati
	public RoomBehaviour[] roomList;
	public float invokeMin;
	public float invokeMax;
	public float activeDelay;
	public int lightsCount = 0;
	public int criminalCount = 0;
	public int maxLights = 10;

	private TimeManager timeManager;

	void Awake() {
		Time.timeScale = 1.0f;
		timeManager = GetComponent<TimeManager> ();

		// init the roomList
		for (int i = 0; i < roomList.Length; i++) {
			roomList [i].defaultRoomDescription = selectedDescription;
			roomList [i].roomDescription = selectedDescription;
		}
		selectedBehaviour = roomList [0];
		Select(selectedBehaviour);

	}

	private float timer = 0;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		RoomBehaviour target = getTarget();
		if(lightsCount <= maxLights && timer > activeDelay){
			RoomDescription desc = GetRandomRoomDescription ();
			target.ActivateState (invokeMin, invokeMax, desc);
			timer = 0;
		}
			
		if (timeManager.IsTimeUp ()) {
			Time.timeScale = 0f;
			guiCanvas.gameObject.SetActive (true);
		}
	}

	RoomDescription GetRandomRoomDescription () {
		int n = Random.Range (0, 2);

		/*
		 * n = 0 -> criminal
		 * n = 1 -> normal
		 */
		
		if (n == 0) {
			criminalCount++;
			lightsCount++;
			return possibleCrimeRooms[Random.Range(0, possibleCrimeRooms.Length)];
		} else {
			lightsCount++;
			return possibleNormalRooms[Random.Range(0, possibleNormalRooms.Length)];
		}
	}

	public void Select(RoomBehaviour selectedRoom){
		selectedBehaviour.gameObject.GetComponent<Outline> ().enabled = false;
		selectedBehaviour = selectedRoom;
		selectedBehaviour.gameObject.GetComponent<Outline> ().enabled = true;

		this.selectedDescription = selectedRoom.roomDescription;
		Debug.Log (selectedDescription.roomName + " isCrime? " + selectedDescription.isCrime);
		viewer.roomBehaviour = selectedRoom;
	}


	private RoomBehaviour getTarget(){
		RoomBehaviour target = roomList[Random.Range(0, roomList.Length)];
		while(target.state != RoomStates.OFF){
			target = roomList[Random.Range(0, roomList.Length)];
		}
		return target;
	}
}

/*
Debug.Log (
				roomList [0].state + " , " + roomList [1].state + " , " + roomList [2].state + " , " + roomList [3].state + "\n" +
				roomList [4].state + " , " + roomList [5].state + " , " + roomList [6].state + " , " + roomList [7].state + "\n" +
				roomList [8].state + " , " + roomList [9].state + " , " + roomList [10].state + " , " + roomList [11].state + "\n" +
				roomList [12].state + " , " + roomList [13].state + " , " + roomList [14].state + " , " + roomList [15].state + "\n" +
				roomList [16].state + " , " + roomList [17].state + " , " + roomList [18].state + " , " + roomList [19].state
			);
*/