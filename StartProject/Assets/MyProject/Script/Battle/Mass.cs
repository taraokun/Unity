using UnityEngine;
using System.Collections;

public class Mass : MonoBehaviour {

	public int pointX;
	public int pointY;
	public bool pieceFlag;


	void Update(){
		if (!pieceFlag) {
			if (this.transform.childCount == 1) {
				pieceFlag = true;
				Debug.Log (this.name + pieceFlag);
			}
		} else if (pieceFlag) {
			if (this.transform.childCount == 0) {
				pieceFlag = false;
				Debug.Log (this.name  + pieceFlag);
			}
		}

	}
}
