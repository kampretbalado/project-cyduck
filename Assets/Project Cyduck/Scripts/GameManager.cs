using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public string selectedName;
	public RoomStates selectedState;

	//konvensi 0 = mati
	public Image[] imageList;
	public int[] stateList;
	public int[] correctAnsList; 
	public RoomBehaviour[] roomList;
	public float invokeMin;
	public float invokeMax;
	public float activeDelay;
	public int lightsCount = 0;
	public int criminalCount = 0;
	public int maxLights = 10;


	private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		RoomBehaviour target = getTarget();
		if(lightsCount <= maxLights && timer > activeDelay){
			target.ActivateState ();
			timer = 0;
			Debug.Log (
				roomList [0].state + " , " + roomList [1].state + " , " + roomList [2].state + " , " + roomList [3].state + "\n" +
				roomList [4].state + " , " + roomList [5].state + " , " + roomList [6].state + " , " + roomList [7].state + "\n" +
				roomList [8].state + " , " + roomList [9].state + " , " + roomList [10].state + " , " + roomList [11].state + "\n" +
				roomList [12].state + " , " + roomList [13].state + " , " + roomList [14].state + " , " + roomList [15].state + "\n" +
				roomList [16].state + " , " + roomList [17].state + " , " + roomList [18].state + " , " + roomList [19].state
			);
		}
			
	}

	public void Select(RoomStates state, string name){
		this.selectedState = state;
		this.selectedName = name;
		Debug.Log (name + ": " + state);
	}


	private RoomBehaviour getTarget(){
		RoomBehaviour target = roomList[Random.Range(0, roomList.Length)];
		while(target.state != RoomStates.mati){
			target = roomList[Random.Range(0, roomList.Length)];
		}
		return target;
	}
}
