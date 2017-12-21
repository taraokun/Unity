using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private TurnController turnController = new TurnController();
	public GameObject myScore;
	public GameObject enemyScore;

	private float timeleft;
	private int myGood = 4;
	private int myEvil = 4;
	private int enemyGood = 4;
	private int enemyEvil = 4;
	// public List<Piece> pieceInfo;
	// マスのゲームオブジェクトを管理




	public GameObject[,] massList = new GameObject[8,8];

	/*public List<PiecePoint> piecePoint = new List<PiecePoint> ();

	public struct PiecePoint{
		int pointX;
		int pointY;
		GameObject piece;
	}*/

	void Start(){
		int count = 1;
		foreach(GameObject obs in GameObject.FindGameObjectsWithTag("Player")){
			Piece player = obs.GetComponent<Piece> ();
			player.ownerId = 1; // 自分のものは1？
			if (obs.name.Contains ("Good")) {
				player.kind = "good"; // Good?
			} else {
				player.kind = "evil"; //evil?
			}
			count++;
		}
		/*foreach (GameObject obs in GameObject.FindGameObjectsWithTag("Enemy")) {
		}*/

		for (int i = 1; i <= 6; i++) {
			
			GameObject line = GameObject.Find ("Line" + i);
			if(i==1 || i == 6){
				for(int j = 0; j <= 7; j++){
					GameObject mass = line.transform.Find ("Mass" + j).gameObject;
					massList [i, j] = mass;
					//Debug.Log ("massList "+ i +" "+ j  + " "+ massList[i,j].name);
				}
			}else {
				for(int j = 1; j <= 6; j++){
					GameObject mass = line.transform.Find ("Mass" + j).gameObject;
					massList [i, j] = mass;
					//Debug.Log ("massList "+ i +" "+ j  + " "+ massList[i,j].name);
				}
			}
		}
		turnController.myturn = true;
		turnController.firstMover = true;

	}


	void Update(){
		timeleft -= Time.deltaTime;
		if(timeleft <= 0.0){
			timeleft = 1.0f;

		
				int goodCount = 0, evilCount = 0;
				foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")){
					if (player.name == "GoodPiece") {
						goodCount++;
					} else if (player.name == "BadPiece") {
						evilCount++;
					}
				}
				Debug.Log (goodCount + evilCount);
				if (myGood != goodCount) {
					var goodChild = myScore.transform.GetChild (goodCount).gameObject;
					Destroy (goodChild);
					myGood--;
				}else if(myEvil != evilCount){
				var badChild = myScore.transform.GetChild (evilCount + goodCount).gameObject;
					Destroy (badChild);
					myEvil--;
				}


		}
	}

	public TurnController GetTurnController()
	{
		return turnController;
	}

	public void ChangeTurn(){
		turnController.myturn = true;
	}

}
