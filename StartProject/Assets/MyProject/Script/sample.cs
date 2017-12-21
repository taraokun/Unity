using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class sample : MonoBehaviour
{
	//---
	public int a;
	[System.Serializable]
	public class Item
	{
		public int id;
		public string name;
		public string description;
	}

	//---
	string savePath = "Assets/Resources/saveData/saveData.json";

	// Use this for initialization
	void Start ()
	{
		
		Item item = load();
		TestLog(item);

		SaveData.Instance.Save ();
	}

	//セーブ
	private void save(Item item)
	{
		string json = JsonUtility.ToJson(item);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(savePath);
		bf.Serialize(file, json);
		file.Close();
	}

	//ロード
	private Item load()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(savePath, FileMode.Open);
		string json = (string)bf.Deserialize(file);
		file.Close();
		return JsonUtility.FromJson<Item>(json);
	}

	//確認用のログを表示
	private void TestLog(Item item)
	{
		Debug.Log("item id " + item.id);
		Debug.Log("item name " + item.name);
		Debug.Log("item description " + item.description);
	}
}