using UnityEngine;
using System.Collections;

public class MiniMapCamera : MonoBehaviour {
	GameObject obj;
	Transform frontPos;			// Front Camera locater
	Transform standardPos;
	bool bQuickSwitch = false;	//Change Camera Position Quickly
	public float smooth = 3f;		// カメラモーションのスムーズ化用変数

	void Start(){
		// Playerの経験値のデバッグ
		standardPos = GameObject.Find ("CamPos").transform;
		if(GameObject.Find ("FrontPos"))
			frontPos = GameObject.Find ("FrontPos").transform;

		transform.position = standardPos.position;	
		transform.forward = standardPos.forward;

		/*
		obj = GameObject.Find ("Wall");

		wallGene = obj.GetComponent<WallGenelater>();

		Vector3 newPosition = transform.position;
		newPosition.x = ((float)wallGene.GetWidth()*0.5f - 0.5f);
		newPosition.y = 1.0f + (float)wallGene.GetHeight();
		newPosition.z = 0.5f + ((float)wallGene.GetWidth() * -0.5f);
	    this.transform.position = newPosition;*/
	}

	void FixedUpdate(){
		setCameraPositionNormalView();
	}

	void setCameraPositionNormalView()
	{
		if(bQuickSwitch == false){
			// the camera to standard position and direction
			transform.position = Vector3.Lerp(transform.position, standardPos.position, Time.fixedDeltaTime * smooth);	
			transform.forward = Vector3.Lerp(transform.forward, standardPos.forward, Time.fixedDeltaTime * smooth);
		}
		else{
			// the camera to standard position and direction / Quick Change
			transform.position = standardPos.position;	
			transform.forward = standardPos.forward;
			bQuickSwitch = false;
		}
	}
}
