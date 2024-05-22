using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UIを操作するので記述
using UnityEngine.UI;

public class Timer : MonoBehaviour, IPose
{
    //制限時間
    [SerializeField] int timeLimit;
    //タイマー用テキスト
    [SerializeField] Text timerText;
    //経過時間
    float time;
    int remaining;

    bool _isPose;

    private void Start()
    {
        remaining = timeLimit - (int)time;
        timerText.text = $"のこり:{remaining.ToString("D3")}";
    }

    void Update()
    {
        if (!_isPose)
        {
            //フレーム毎の経過時間をtime変数に追加
            time += Time.deltaTime;
            //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
            remaining = timeLimit - (int)time;
            //timerTextを更新していく
            timerText.text = $"のこり:{remaining.ToString("D3")}";

            if(remaining <= 0)
            {
                SceneChanger.Instance.SceneChange("result");
            }
        }
    }


    public void InPose()
    {
        _isPose = true;
    }

    public void OutPose()
    {
        _isPose = false;
    }
}
