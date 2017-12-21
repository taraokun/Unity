using UnityEngine;
using System.Collections;

public class RWall : MonoBehaviour {
	public Material RWallMaterial;
	private bool hit = true;
	// Use this for initialization

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet") {
			if (hit) {
				this.GetComponent<Renderer> ().material = RWallMaterial;
				hit = false;
			} else {
				Destroy (this.gameObject);
			}
		}
	}
}
