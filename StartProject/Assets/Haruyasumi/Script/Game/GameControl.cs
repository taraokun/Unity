using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	private int score = 0;
	private float elapsedTime;
	const float BASE_WIDTH = 511;
	public GUIStyle style = new GUIStyle();
	public GUIStyle endMsgStyle = new GUIStyle();
	private Rect scoreRect = new Rect(400, 10, 70, 30);
	private Rect timerRect = new Rect(330, 75, 120, 30);
	private Rect bulletRect = new Rect (330, 30, 100, 30);
	private Rect enemyRect = new Rect (330, 45, 100, 30);
	private Rect camerasRect = new Rect (330, 60, 100, 30);
	private Rect playerNameRect = new Rect (330, 90, 100, 30);
	private Rect endMsgRect = new Rect(50, 10, 200, 35);
	private Rect rankMsgRect = new Rect(50, 85, 250, 30);
	private Rect replayBtnRect = new Rect(50, 150, 120, 40);
	private Rect statusRect = new Rect(330, 130, 100, 120);

	void Update () {	
		if (!FinishedGame ()) {
			elapsedTime += Time.deltaTime;
			Time.timeScale = 1.0f;
		}	
	}

	public void AddScore(){
		score++;
	}

	bool FinishedGame(){
		return GameObject.FindWithTag ("Goal") == null;
	}

	float GetValueByScreenSize(float x) {
		float ratio = Screen.width / BASE_WIDTH;
		return x * ratio;
	}

	void OnGUI() {
		GUIStyleState styleState = new GUIStyleState();
		styleState.textColor = Color.green;
		style.normal = styleState;
		string name = InputPlayerName.getPlayerName ();


		GUI.Label(scoreRect, "スコア " + score, style);
		GUI.Label(timerRect, "タイム " + elapsedTime, style);
		GUI.Label(bulletRect, "残り弾数 " + Player.Instance.GetBulletCount() + "/ 20", style);
		GUI.Label (enemyRect, "残り敵数 " + GameObject.FindGameObjectsWithTag ("enemy").Length + " / 5", style);
		GUI.Label (camerasRect, "サブカメラの数 " + CameraController.Instance.cameras + " / 5", style);
		GUI.Label(playerNameRect,"プレイヤー " + name,style);
		GUI.Label (statusRect, "MaxHP   " + Player.Instance.PostFullHp ()
		+ "\r\n" + "HP         " + Player.Instance.PostHp ()
		+ "\r\n" + "Attack    " + Player.Instance.PostAttack ()
		+ "\r\n" + "Block      " + Player.Instance.PostBlock (), style);

		if (FinishedGame()) {

			GUI.Label(endMsgRect, "Game Clear!!", endMsgStyle);
			GUI.Label(rankMsgRect, "あなたのタイムは" + elapsedTime + "です！", style);
			Time.timeScale = 0;
			if (GUI.Button(replayBtnRect, "もう一度プレイする")) {
				int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene (sceneIndex);
			}
		}
	}
}
