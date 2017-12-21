using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class EnemyStatus : MonoBehaviour {
	private TextAsset csvFile; // CSVファイル
//	private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
//	private List<int> readToIntData = new List<int>();

	private static int id;
	/* parameterId 0~7 */
	private static int parameterId;
	private static int enemyId;
	private static string objName;
	private static double maxHp;
	private static int hp;
	private static double attack;
	private static double block;
	private static int level = 1;
	/* Enemy Status Rank */
	private static int rank;

	/* idは敵味方の判別 0:味方 1:敵 */
	public int Id{
		get { return id; }
		set { id = value; }
	}
	public int EnemyId {
		get { return enemyId; }
		set { enemyId = value; }
	}
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
	public int Rank{
		get { return rank; }
		set { rank = value; }
	}

	/* クラスマッピング */
	private class DefultStatusClassMap{
		[CsvColumnAttribute(0,0)]
		public int EnemyId { get; set; }
		[CsvColumnAttribute(1,"NoName")]
		public string Name { get; set; }
		[CsvColumnAttribute(2,1)]
		public int Hp { get; set; }
		[CsvColumnAttribute(3,1)]
		public int Attack { get; set; }
		[CsvColumnAttribute(4,1)]
		public int Block { get; set; }
		[CsvColumnAttribute(5,1)]
		public int Rank { get; set; }

		// Debug用（まとめて）
		public override string ToString(){
			return string.Format ("Id={0}, Name{1}, HP={2}", EnemyId, Name, Hp);
		}
	}


	void Start(){
		/*
		csvFile = Resources.Load("EnemyData") as TextAsset; // Resouces/CSV下のCSV読み込み
		StringReader reader = new StringReader(csvFile.text);

		while(reader.Peek() > -1) {
			string line = reader.ReadLine();
			csvDatas.Add(line.Split(',')); // リストに入れる
			height++; // 行数加算
		}
		readToIntData.Add (int.Parse (csvDatas [0][2]));
		Debug.Log (readToIntData[0]);
		Debug.Log (csvDatas[1][1]);
		Debug.Log (csvDatas [2] [1]);
		*/
		Enemy (2,2);
	}




	/* 敵オブジェクトのレベルを含めての生成*/
	public void Enemy(int enemyId,int level){
		using(var reader = new CSVReader<DefultStatusClassMap>("EnemyData",true)){
			foreach(var enemy in reader){
				if(enemy.EnemyId == enemyId){
					EnemyId = enemy.EnemyId;
					ObjName = enemy.Name;
					Hp = enemy.Hp;
					Attack = enemy.Attack;
					Block = enemy.Block;
					Rank = enemy.Rank;
					Debug.Log ("EnemyId " + EnemyId);
					Debug.Log ("Name " + ObjName);
					Debug.Log ("Rank "+Rank);
					Debug.Log ("1 Hp " + Hp);
					Debug.Log ("1 Attack " + Attack);
					Debug.Log ("1 Block " + Block);
					Debug.Log ("1 Level " + Level);
					break;
				}
			}
		}
		UpdateStatus (level, Rank);

	}

	/* 敵専用レベルアップ処理(敵生成時のみ) */
	private void UpdateStatus(int level, int rank){
		Hp = (int)(((double)rank /10.0f + 1.0f) * 1);
		Attack = (int)(((double)rank /10.0f + 1.0f) * 1);
		Block = (int)(((double)rank /10.0f + 1.0f) * 1);
		Level = level - 1;
		Debug.Log ("2 Hp " + Hp);
		Debug.Log ("2 Attack " + Attack);
		Debug.Log ("2 Block " + Block);
		Debug.Log ("2 Level " + Level);
	}

}