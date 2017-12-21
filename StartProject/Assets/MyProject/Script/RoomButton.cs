using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomButton : MainController {
	// Update is called once per frame

	protected override void OnClick(string objectName){
		if (objectName.Contains("Room")) {
			
		}else if("UpdateButton".Equals (objectName)){
			this.UpdateRoomButton ();
		}else {
			throw new System.Exception ("Not implemented!!");
		}
	}

	private void UpdateRoomButton(){
		GameObject Buttons = GameObject.Find ("RoomList");
		Debug.Log (RoomManeger.rooms.Count);
		for(int i = 0; i < RoomManeger.rooms.Count; i++){
			Button room = Buttons.transform.FindChild ("RoomButton" + i).gameObject.GetComponent<Button>();
			Text room_id = room.transform.FindChild ("Text").gameObject.GetComponent<Text>();
			//room_id = transform.GetComponent<Text> ();
			Debug.Log (room_id.text);
			Debug.Log (RoomManeger.rooms[i].owner_name);
		}
	}

}