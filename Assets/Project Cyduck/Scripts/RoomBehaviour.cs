using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomBehaviour : MonoBehaviour {

	public GameManager manager;
	public RoomStates state = RoomStates.mati;
	private float invokeMin = 2f;
	private float invokeMax = 10f;
	private Image image;

	// Use this for initialization
	void Start () {
		image = this.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.invokeMax = manager.invokeMax;
		this.invokeMin = manager.invokeMin;
	}


	public void Selected(){
		if (this.manager.selectedName == this.gameObject.name) {
			this.DeactivateSelected ();			
		}
		this.manager.Select (state, this.gameObject.name);
	}

	public void ActivateState(){
		this.state = (RoomStates) Random.Range (1, 3);

		if (manager.criminalCount == 0)
			this.state = RoomStates.kriminal;

		if (this.state == RoomStates.kriminal)
			manager.criminalCount++;
		
		if (this.state == RoomStates.hidup) {
			image.color = new Color (0.0f, 1.0f, 0.0f);
		} else {
			image.color = new Color (1.0f, 0.0f, 1.0f);
		}
		manager.lightsCount++;
		Invoke ("DeactivateStateAuto", Random.Range (invokeMin, invokeMax));
	}


	void DeactivateStateAuto(){
		if (this.state == RoomStates.kriminal) {
			//TODO combo beak here
		}

		DeactivateState ();
	}

	void DeactivateSelected(){
		if (this.state == RoomStates.kriminal) {
			//TODO TAMBAH POIN
		} else {
			//TODO KURANGIN POIN DAN KOMBO BREAK
		}

		DeactivateState ();
	}

	void DeactivateState(){
		if (this.state == RoomStates.kriminal) {
			this.manager.criminalCount--;
		}
		image.color = new Color (1.0f, 1.0f, 1.0f);
		manager.lightsCount--;
		this.state = 0;
	}
}
