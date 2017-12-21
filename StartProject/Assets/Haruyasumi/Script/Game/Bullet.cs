using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start(){
		BGMS.Instance.PlaybulletShotSound ();
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Ground") {
			Destroy (this.gameObject, 1.0f);
		}else if (collision.gameObject.tag == "RWall") {
			Destroy (this.gameObject);
		}else if (collision.gameObject.tag == "enemy") {
			Destroy (this.gameObject);
		}
	}
}
