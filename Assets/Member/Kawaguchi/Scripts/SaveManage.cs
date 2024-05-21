using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SaveManage : MonoBehaviour
{
	private static SaveManage _instance;
	public static SaveManage Instance => _instance;
	
	[SerializeField] SaveData _data;// json変換するデータのクラス
	string _filepath;// jsonファイルのパス
	string _fileName = "SaveData.json";// jsonファイル名

	public SaveData Data => _data;
	
	//-------------------------------------------------------------------
	// 開始時にファイルチェック、読み込み
	void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
		// パス名取得
		_filepath = Application.dataPath + "/" + _fileName;       

		// ファイルがないとき、ファイル作成
		if (!File.Exists(_filepath)) {
			Save(_data);
		}

		// ファイルを読み込んでdataに格納
		_data = Load(_filepath);
	}

	private void Start()
	{
		
	}

	//-------------------------------------------------------------------
	// jsonとしてデータを保存
	public void Save(SaveData data)
	{
		Array.Sort(data.Score);
		Array.Reverse(data.Score);
		string json = JsonUtility.ToJson(data);                 // jsonとして変換
		StreamWriter wr = new StreamWriter(_filepath, false);    // ファイル書き込み指定
		wr.WriteLine(json);                                     // json変換した情報を書き込み
		wr.Close();                                             // ファイル閉じる
	}

	// jsonファイル読み込み
	public SaveData Load(string path)
	{
		StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
		string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
		rd.Close();                                             // ファイル閉じる
                                                                
		return JsonUtility.FromJson<SaveData>(json);            // jsonファイルを型に戻して返す
	}

	//-------------------------------------------------------------------
	// ゲーム終了時に保存
	void OnDestroy()
	{
		Save(_data);
	}
}

[System.Serializable]
public class SaveData
{
	///<summary>感染人数</summary>
	public int InfectionCount;

	public const int st = 6;
	///<summary>スコア</summary>
	public float[] Score = new float[st];
}
