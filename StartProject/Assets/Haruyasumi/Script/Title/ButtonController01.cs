using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController01 : MainController {
	// Update is called once per frame
	public GameObject InputName;

	protected override void OnClick(string objectName){
		if ("startButton".Equals (objectName)) {
			this.StartButton ();
		} else if ("endButton".Equals (objectName)) {
			this.EndButton ();
		} else if("enterButton".Equals(objectName)){
			this.EnterButton ();
		}else {
			throw new System.Exception ("Not implemented!!");
		}
	}

	private void StartButton(){
		GameObject Buttons = GameObject.Find ("ButtonController");
		GameObject sButton = Buttons.transform.FindChild ("startButton").gameObject;
		GameObject eButton = Buttons.transform.FindChild ("endButton").gameObject;
		sButton.SetActive (false);
		eButton.SetActive (false);
		InputName.SetActive (true);
	}

	private void EndButton(){
		GameObject Buttons = GameObject.Find ("ButtonController");
		GameObject sButton = Buttons.transform.FindChild ("startButton").gameObject;
		GameObject eButton = Buttons.transform.FindChild ("endButton").gameObject;
		sButton.SetActive (false);
		eButton.SetActive (false);
		Application.Quit ();
	}

	private void EnterButton(){
		SceneManager.LoadScene (1);
	}
}