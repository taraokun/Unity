using UnityEngine;
using System.Collections;

public class RandomWalls : MonoBehaviour {
	public GameObject RWall;
	// Use this for initialization
	void Start () {
		int random;

		for (float a = 0; a < 24; a++) {
			for (float b = 0; b < 24; b++) {
				random = Random.Range (0, 4);
				if (random == 0) {
					Instantiate(RWall, new Vector3(-22.5f + (2.0f * a) + 1.0f, 1.0f, -22.5f + (2.0f * b)), Quaternion.identity);
				} else if (random == 1) {
					Instantiate(RWall, new Vector3(-22.5f + (2.0f * a) + (-1.0f), 1.0f, -22.5f + (2.0f * b)), Quaternion.identity);
				} else if (random == 2) {
					Instantiate(RWall, new Vector3(-22.5f + (2.0f * a) , 1.0f, -22.5f + (2.0f * b) + 1.0f), Quaternion.identity);
				} else if (random == 3) {
					Instantiate(RWall, new Vector3(-22.5f + (2.0f * a) , 1.0f, -22.5f + (2.0f * b) + (-1.0f)), Quaternion.identity);
				}

				Instantiate(RWall, new Vector3(-22.5f + 2.0f * a, 1.0f, -22.5f + 2.0f * b), Quaternion.identity);
			}
		}
	}
}
