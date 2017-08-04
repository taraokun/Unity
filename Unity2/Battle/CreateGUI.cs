using UnityEngine;
using System.Collections;

public class CreateGUI : MonoBehaviour {
	private float elapsedTime;
	const float BASE_WIDTH = 511;
	public GUIStyle style = new GUIStyle();
	public GUIStyle endMsgStyle = new GUIStyle();
	private Rect statusRect = new Rect(10, 15, 100, 120);

	void Start(){
		PlayerStatus playerStatus = FindObjectOfType<PlayerStatus> ();
		playerStatus.ExpensivePoint = 50;
	}

	void Update () {	
		elapsedTime += Time.deltaTime;
		Time.timeScale = 1.0f;
	}

	float GetValueByScreenSize(float x) {
		float ratio = Screen.width / BASE_WIDTH;
		return x * ratio;
	}

	Rect MakeRect(Rect defaultRect) {
		float left = GetValueByScreenSize(defaultRect.left);
		float top = GetValueByScreenSize(defaultRect.y);
		float width = GetValueByScreenSize(defaultRect.width);
		float height = GetValueByScreenSize(defaultRect.height);
		Rect newRect = new Rect(left, top, width, height);
		return newRect;
	}

	void OnGUI() {
		PlayerStatus playerStatus = FindObjectOfType<PlayerStatus> ();
		GUIStyleState styleState = new GUIStyleState();
		styleState.textColor = Color.green;
		style.normal = styleState;
		Rect StatusRect = MakeRect (statusRect);

		GUI.Label (StatusRect,
			"タイム " + elapsedTime
			+ "\r\n" + "ParameterId " + playerStatus.ParameterId
			+ "\r\n" + "MaxHP   " + playerStatus.MaxHp 
			+ "\r\n" + "HP         " + playerStatus.Hp
			+ "\r\n" + "Attack    " + playerStatus.Attack
			+ "\r\n" + "Block     " + playerStatus.Block
			+ "\r\n" + "Level      " + playerStatus.Level, style);
	}
}