using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

	public MainController button;

	public void OnClick(){
		if (button == null) {
			throw new System.Exception ("Button instance is null!!");
		}
		button.OnClick (this.gameObject.name);
	}

	protected virtual void OnClick(string objectName){
		Debug.Log ("Base Button");
	}
}
