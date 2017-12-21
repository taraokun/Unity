using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class PieceClick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Vector3 currentTransform;
	private GameObject nearObj;
	public bool battlFlag = false;
	[SerializeField]
	private TurnController turnInfo;


	void Start(){
		turnInfo = GameObject.Find ("GameManager").GetComponent<GameManager> ().GetTurnController();
	}

	public void OnBeginDrag(PointerEventData PED){
		currentTransform = this.transform.position;
		this.transform.position = PED.position;
	}

	// ドラック中
	public void OnDrag(PointerEventData PED){
		this.transform.position = PED.position;
	}

	// ドラック後
	public void OnEndDrag(PointerEventData PED){
		if (!battlFlag) {
			nearObj = searchTag (gameObject, "FirstMass");
			//移動先に子要素があれば入れ替える
			if (nearObj == null) {
				this.transform.position = currentTransform;
			} else if (nearObj.transform.childCount == 1) {
				var nearObjchild = nearObj.transform.GetChild (0);
				nearObjchild.transform.SetParent (this.transform.parent.gameObject.transform);
				nearObjchild.transform.position = currentTransform;
			}
			if (nearObj != null) {
				this.transform.SetParent (nearObj.transform);
				this.transform.localPosition = Vector3.zero;
			}	
		} else if (battlFlag && turnInfo.myturn) {
			nearObj = searchMoveObject ();
			if (nearObj == null) {
				this.transform.position = currentTransform;
			} else if (nearObj.transform.childCount == 1) {
				var nearObjchild = nearObj.transform.GetChild (0);
				nearObjchild.transform.SetParent (this.transform.parent.gameObject.transform);
				nearObjchild.transform.position = currentTransform;
			}
			if (nearObj != null) {
				this.transform.SetParent (nearObj.transform);
				this.transform.localPosition = Vector3.zero;
				turnInfo.myturn = false;
			}	
		} else if(battlFlag && !turnInfo.myturn){
			this.transform.position = currentTransform;
		}

	}


	GameObject searchTag(GameObject nowObj, string tagName){
		float tmpDis = 0;
		float nearDis = 0;
		GameObject targetObj = null;

		foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName)){
			tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);
			if (nearDis == 0 || nearDis > tmpDis){
				nearDis = tmpDis;
				targetObj = obs;
				if(tmpDis > 60){
					targetObj = null;
				}
			}
		}
		//最も近かったオブジェクトを返す
		return targetObj;
	}

	GameObject searchMoveObject(){
		
		GameManager mass = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		float tmpDis = 0;
		float nearDis = 0;
		GameObject targetObj = null;
		Piece point = this.GetComponent<Piece> ();

		for (int i = -1; i <= 1; i++) {
			
			for (int j = -1; j <= 1; j++) {
				if (i != 0 || j != 0) {
					if (point.pointX + i >= 1 && point.pointX + i <= 6
						&& point.pointY+ j >= 1 && point.pointY + j <= 6 && Mathf.Abs(i) + Mathf.Abs(j) == 1) {
						tmpDis = Vector3.Distance (mass.massList [point.pointY+ j, point.pointX + i].transform.position, this.gameObject.transform.position);
						if (nearDis == 0 || nearDis > tmpDis) {
							nearDis = tmpDis;
							targetObj = mass.massList [point.pointY + j, point.pointX + i];

						}
					}
				}
			}
		}
		// Debug.Log (targetObj.transform.name);
	
		return targetObj;
	}

}


