using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Room Management/Room Description")]
public class RoomDescription : ScriptableObject {
	public bool isCrime;
	public string roomName;
	public Sprite roomImage;
	public string roomDescription;
	public Color color;
}
