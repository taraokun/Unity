using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManeger : MonoBehaviour {
	public static List<Room> rooms = new List<Room>();


	[System.Serializable]
	public struct Room{
		public int room_id;
		public string status;
		public string owner_name;
		public int game_id;
		public int user_id;
		public int player_entry_id;
		public string create_at;
		public string update_at;
	}

	void Start(){
		ResponseListRooms ();
	}

	private void ResponseListRooms(){
		rooms.Clear ();
		for (int i = 0; i < 10; i++) {
			Room room = new Room ();
			room.room_id = i;
			room.status = "waitting";
			room.owner_name = "monokeshi" + i;

			rooms.Add (room);
		}
	}
}
