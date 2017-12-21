using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private Vector3 targetPosition;		// the position the camera is trying to be in

	Transform follow;

	void Start(){
		follow = GameObject.FindWithTag ("Player").transform;	
	}

	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the hovercraft
		targetPosition = follow.position;

		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);

		// make sure the camera is looking the right way!
		transform.LookAt(follow);
	}
}
