using UnityEngine;
using System.Collections;

//敵の動き制御。距離を考慮するタイプ
public class Enemy : MonoBehaviour {
	private static Enemy instance;
	public Transform player;    //プレイヤーを代入
	public float speed = 5f; //移動速度
	public float limitDistance = 500f; //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）
	public bool encount = false;

	private int Attack = 20;
	private int Block = 5;
	private int Hp = 20;
	private int FullHp = 20;
	//ゲーム開始時に一度
	void Start () {
		//Playerオブジェクトを検索し、参照を代入
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	//毎フレームに一度
	void Update () {
		Vector3 playerPos = player.position;                 //プレイヤーの位置
		Vector3 direction = playerPos - transform.position; //方向と距離を求める。
		float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
		direction = direction.normalized;                   //単位化（距離要素を取り除く）
		direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。

		//プレイヤーの距離が一定以上でなければ、敵キャラクターはプレイヤーへ近寄ろうとしない
		if (distance <= limitDistance || encount) {

			//プレイヤーとの距離が制限値以上なので普通に近づく
			transform.position = transform.position + (direction  * Time.deltaTime);
			if (encount == false) {
				BGMS.Instance.PlaybattleBgm ();
				this.encount = true;
			}
		} 
		//プレイヤーの方を向く
		transform.rotation = Quaternion.LookRotation(direction);
		if(Hp <= 0){
			Destroy (this.gameObject);
			BGMS.Instance.PlayburnSound ();
			BGMS.Instance.PlayNormalBgm ();
		}

	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			this.encount = false;
		} else if (collision.gameObject.tag == "Bullet") {
			Hp -= Player.Instance.PostAttack () - Block;
		}
	}

	public static Enemy Instance {
		get {
			if (instance == null) {
				instance = (Enemy)FindObjectOfType(typeof(Enemy));
				if (instance == null) {
					Debug.LogError("Player Instance Error");
				}
			}
			return instance;
		}
	}
}
