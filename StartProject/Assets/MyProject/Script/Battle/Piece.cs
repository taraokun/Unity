using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {
	public string kind;
	public int pieceId;
	public int pointX;
	public int pointY;
	public bool captured;
	public int ownerId;// 0 or 1
	// ゲーム準備完了を認めるか判断するための情報
	public bool massFlag{ get;set;}

	private string currentParentObject = "";

	void Start(){
		massFlag = false;
	}

	void Update(){
		Mass mass = this.transform.parent.GetComponent<Mass> ();
		if (!massFlag) {
			if (this.transform.parent.name.Contains ("Mass")) {
				pointX = mass.pointX;
				pointY = mass.pointY;
				massFlag = true;
				currentParentObject = this.transform.name;
				Debug.Log ("massFlag " + massFlag);
				Debug.Log ("Piece X" + pointX);
			}
		} else if (massFlag) {
			if (!this.transform.parent.name.Contains ("Mass")) {
				massFlag = false;
				Debug.Log ("massFlag " + massFlag);
				pointX = 0;
				pointY = 0;
				currentParentObject = "";
			}
		}
		if (transform.parent.name.Contains ("Mass")) {
			if (mass.pointX != pointX || mass.pointY != pointY && massFlag) {
				pointX = mass.pointX;
				pointY = mass.pointY;
				currentParentObject = this.transform.parent.name;
				Debug.Log ("move " + pointX);
				Debug.Log ("move " + pointY);
			}
		}

	}
}
