using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private static CameraController instance;
	private GameObject mainCamera;
	private GameObject subCamera;
	public int cameras = 5;
	private bool change = true;
	// Use this for initialization	
	// Update is called once per frame
	void Start(){
		mainCamera = GameObject.Find ("MainCamera");
		subCamera = GameObject.Find ("SubCamera");

		subCamera.SetActive (false);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && cameras > 0) {
			mainCamera.SetActive (false);
			subCamera.SetActive (true);
			if (change) {
				cameras--;
				change = false;
			}
		}else if(Input.GetKeyUp(KeyCode.Space) ){
			mainCamera.SetActive (true);
			subCamera.SetActive (false);
			change = true;
		}
	}

	public static CameraController Instance {
		get {
			if (instance == null) {
				instance = (CameraController)FindObjectOfType(typeof(CameraController));
				if (instance == null) {
					Debug.LogError("CameraController Instance Error");
				}
			}
			return instance;
		}
	}
}
