using UnityEngine;
using System.Collections;

public class SubCamera : MonoBehaviour {

	private Vector3 targetPosition;		// the position the camera is trying to be in
	private Transform follow;

	void Start(){
		follow = GameObject.FindWithTag ("Player").transform;	
	}

	void LateUpdate (){
		Vector3 newPosition = transform.position;
		newPosition.x = follow.position.x;
		newPosition.y = follow.position.y + 8;
		newPosition.z = follow.position.z;
		this.transform.position = newPosition;
	}
}