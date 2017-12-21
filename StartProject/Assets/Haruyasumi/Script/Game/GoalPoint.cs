using UnityEngine;
using System.Collections;

public class GoalPoint : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			BGMS.Instance.PlayEndBgm ();
			Destroy (this.gameObject);
		}
	}
}
