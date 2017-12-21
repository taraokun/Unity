using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class InputPlayerName : MonoBehaviour {
	private static InputPlayerName instance;
	public static string str;
	public Text text;
	public InputField inputField;

	public void SaveText(){
		str = inputField.text;
		text.text = str;
		inputField.text = "";
	}

	public static string getPlayerName(){
		return str;
	}

	public static InputPlayerName Instance {
		get {
			if (instance == null) {
				instance = (InputPlayerName)FindObjectOfType(typeof(InputPlayerName));
				if (instance == null) {
					Debug.LogError("Player Instance Error");
				}
			}
			return instance;
		}
	}
}
