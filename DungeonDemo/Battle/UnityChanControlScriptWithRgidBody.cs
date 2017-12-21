using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 必要なコンポーネントの列記
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class UnityChanControlScriptWithRgidBody : MonoBehaviour{

	public float animSpeed = 1.5f;				// アニメーション再生速度設定
	// キャラクターコントローラ（カプセルコライダ）の参照
	private CapsuleCollider col;
	private Rigidbody rb;
	// キャラクターコントローラ（カプセルコライダ）の移動量
	private Vector3 velocity;
	// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
	private float orgColHight;
	private Vector3 orgVectColCenter;
	
	private Animator anim;							// キャラにアタッチされるアニメーターへの参照
	private AnimatorStateInfo currentBaseState;			// base layerで使われる、アニメーターの現在の状態の参照

	private float time = 0;
	private int Vx = 0;
	private int Vz = 0;
	private Vector3 CharaPos;
		
// アニメーター各ステートへの参照
	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int restState = Animator.StringToHash("Base Layer.Rest");
	static int spinState = Animator.StringToHash("Base Layer.Spinkick");

	private enum STEP {
		NONE = -1,
		STOP = 0,
		MOVE
	};
	private STEP step = STEP.STOP;

// 初期化
	void Start (){
		// Animatorコンポーネントを取得する
		anim = GetComponent<Animator>();
		// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();
		// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
		orgColHight = col.height;
		orgVectColCenter = col.center;
		CharaPos = transform.position;
	}
	
	
// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
	void FixedUpdate (){
		
		rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする	
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		// 以下、Animatorの各ステート中での処理
		// Locomotion中
		// IDLE中の処理
		// 現在のベースレイヤーがidleStateの時
		if (currentBaseState.nameHash == idleState){
			// スペースキーを入力したらRest状態になる
			if (Input.GetButtonDown ("Jump")) {
				anim.SetBool ("Rest", true);
			} else if (Input.GetButtonDown ("Fire2")) {
				anim.SetBool ("Kick", true);
			}
		}
		// REST中の処理
		// 現在のベースレイヤーがrestStateの時
		else if (currentBaseState.nameHash == restState){
			// ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
			if(!anim.IsInTransition(0))
			{
				anim.SetBool("Rest", false);
			}
		}else if (currentBaseState.nameHash == spinState){
			if(!anim.IsInTransition(0))
			{
				anim.SetBool("Kick", false);
			}
		}

		Move ();
	}

	// キャラクターのコライダーサイズのリセット関数
	void resetCollider(){
	// コンポーネントのHeight、Centerの初期値を戻す
		col.height = orgColHight;
		col.center = orgVectColCenter;
	}

	void Move() {
		time--;
		if (this.step == STEP.STOP) {
			//向きを変える（ターンが経過しない）
			if (Input.GetKey (KeyCode.LeftShift)) {
				if (Input.GetKeyDown (KeyCode.W))
					transform.rotation = Quaternion.Euler (0, 0, 0);
				else if (Input.GetKeyDown (KeyCode.S))
					transform.rotation = Quaternion.Euler (0, 180, 0);
				else if (Input.GetKeyDown (KeyCode.D))
					transform.rotation = Quaternion.Euler (0, 90, 0);
				else if (Input.GetKeyDown (KeyCode.A))
					transform.rotation = Quaternion.Euler (0, 270, 0);
				else
					anim.SetBool ("Locomotion", false);
			} else {
				//移動
				if (Input.GetKey (KeyCode.W)) {
					transform.rotation = Quaternion.Euler (0, 0, 0);
					anim.SetBool ("Locomotion", true);
					this.step = STEP.MOVE;
					time = 50;
					Vz = 2;
					CharaPos.z += Vz;
				} else if (Input.GetKey (KeyCode.S)) {
					transform.rotation = Quaternion.Euler (0, 180, 0);
					anim.SetBool ("Locomotion", true);
					this.step = STEP.MOVE;
					time = 50;
					Vz = -2;
					CharaPos.z += Vz;
				} else if (Input.GetKey (KeyCode.D)) {
					transform.rotation = Quaternion.Euler (0, 90, 0);
					anim.SetBool ("Locomotion", true);
					this.step = STEP.MOVE;
					time = 50;
					Vx = 2;
					CharaPos.x += Vx;
				} else if (Input.GetKey (KeyCode.A)) {
					transform.rotation = Quaternion.Euler (0, 270, 0);
					anim.SetBool ("Locomotion", true);
					this.step = STEP.MOVE;
					time = 50;
					Vx = -2;
					CharaPos.x += Vx;
				} else {
					anim.SetBool ("Locomotion", false);
				}
			}
		}
		// 実際の移動部分
		if (time >= 0 && this.step == STEP.MOVE) {
			transform.position = new Vector3 (CharaPos.x - Vx * time * 0.02f, transform.position.y, CharaPos.z - Vz * time * 0.02f);
		}
		// 移動後の処理　速度の設定
		if (time <= 0) {
			this.step = STEP.STOP;
			Vx = 0;
			Vz = 0;
		}
	}
}

