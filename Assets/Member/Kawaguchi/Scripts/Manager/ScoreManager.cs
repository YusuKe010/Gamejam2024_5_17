using System;
using UnityEngine;

///<summary></summary>
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance => _instance;

    private float _totalScore = 0;
    public float TotalScore => _totalScore;

    private void Awake()
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
    }

    /// <summary>
    /// スコアアップして、セーブする
    /// </summary>
    /// <param name="score"></param>
    public void ScoreUp(float score)
    {
        _totalScore += score;
        SaveManage.Instance.Data.CurrentScore = _totalScore;
        SaveManage.Instance.Save(SaveManage.Instance.Data);
    }
}
