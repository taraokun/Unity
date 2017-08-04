using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	private static int id;
	/* parameterId 0~7 */
	private static int parameterId;
	private static string objName;
	private static double maxHp;
	private static int hp;
	private static double attack;
	private static double block;
	private static int level = 1;
	/* Enemy Status Rank */
	private static int expensivePoints = 10;

	/* idは敵味方の判別 0:味方 1:敵 */
	public int Id{
		get { return id; }
		set { id = value; }
	}
	public int ParameterId{
		get{ return parameterId; }
	}
	/* parameterIdはレベルアップの上昇パターンを決定するものである */

	public string ObjName {
		get { return objName; }
		set { objName = value; }
	}
	public int MaxHp{
		get { return (int)maxHp; }
		set { maxHp += value; }
	}
	public int Hp{
		get { return hp; }
		set { hp += value; }
	}
	public int Attack{
		get { return (int)attack; }
		set { attack += value; }
	}
	public int Block{
		get { return (int)block; }
		set { block += value; }
	}
	public int Level{
		get { return level; }
		set { level += value; }
	}
	public int ExpensivePoint{
		get { return expensivePoints; }
		set {
			expensivePoints -= value;
			if(expensivePoints < 1){
				expensivePoints = LevelUp(expensivePoints);
			} 
		}
	}

	// 初期ステータスの設定
	void Start(){
		Id = 0;
		parameterId = (int)Random.Range (0,8);
		MaxHp = 10;
		Hp = 10;
		Attack = 5;
		Block = 5;
	}


	//レベルアップテーブル
	private int LevelUp(int expensive){
		int i, exp = 0, modulus;
		do{
			level++; modulus = 0;
			for (i = 0; i < level; i++)
				modulus += i;
			exp = 10 + modulus + expensive;
			expensive = exp;
			UpDateStatus();
		}while(exp < 1);
		return exp;
	}

	/* parameterIdによってのステータス上昇 */
	private void UpDateStatus(){
		switch (ParameterId) {
		// weak
		case 0:
			maxHp += 2.0;
			attack += 1.5f;
			block += 1.5f;
			Debug.Log (ParameterId);
			break;
			// strong
		case 1:
			maxHp += 2.6f;
			attack += 2.7f;
			block += 1.7f;
			break;
		case 2:
			// power
			maxHp += 2.0f;
			attack += 3.5f;
			block += 0.5f;
			break;
		case 3:
			// Berserker
			maxHp += 1.5f;
			attack += 5.0f;
			block += 0.5f;
			break;
		case 4:
			// barance
			maxHp += 3.0f;
			attack += 2.0f;
			block += 2.0f;
			break;
		case 5:
			// defence
			maxHp += 2.5f;
			attack += 2.0f;
			block += 2.5f;
			break;
		case 6:
			// Wall
			maxHp += 3.0f;
			attack += 1.0f;
			block += 3.0f;
			break;
		case 7:
			maxHp += 4.0f;
			attack += 3.0f;
			block += 3.0f;
			break;
		}
	}
}