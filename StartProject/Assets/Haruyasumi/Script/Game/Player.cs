using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private static Player instance;
	private float speed = 10;	
	public Transform CameraPoint;
	public GameObject bullet;
	private int count = 20;
	private float BulletSpeed = 1000;
	// Update is called once per frame	
	private int Attack = 10;
	private int Block = 5;
	private int Hp = 700;
	private int FullHp = 700;
	private float elapsedTime;

	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		elapsedTime += Time.deltaTime;
		Hp = FullHp - (int)elapsedTime;

		this.GetComponent<Rigidbody>().AddForce(x * speed, 0, z * speed);

		if(Input.GetKeyDown(KeyCode.X) && count > 0 && Input.GetKey(KeyCode.Space) == false){
			// 弾丸の複製
			GameObject bullets = GameObject.Instantiate(bullet)as GameObject;

			Vector3 point = CameraPoint.gameObject.transform.position;
			point.y = 1.86f;
			// Rigidbodyに力を加えて発射
			bullets.GetComponent<Rigidbody>().AddForce (x * BulletSpeed, 0, z * BulletSpeed);
			// 弾丸の位置を調整
			bullets.transform.position = point;

			count--;
		}
	}

	public int GetBulletCount(){
		return count;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "enemy") {
			this.gameObject.transform.position = new Vector3 (-23.5f, 2.0f, -23.5f);
			BGMS.Instance.PlayNormalBgm ();
			BGMS.Instance.PlayReturnSound ();
		}
	}

	// 現在のステータスの情報
	public int PostAttack(){
		return Attack;
	}
	public int PostBlock(){
		return Block;
	}
	public int PostHp(){
		return Hp;
	}
	public int PostFullHp(){
		return FullHp;
	}

	public static Player Instance {
		get {
			if (instance == null) {
				instance = (Player)FindObjectOfType(typeof(Player));
				if (instance == null) {
					Debug.LogError("Player Instance Error");
				}
			}
			return instance;
		}
	}


}
