using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI�𑀍삷��̂ŋL�q
using UnityEngine.UI;

public class Timer : MonoBehaviour, IPose
{
    //��������
    [SerializeField] int timeLimit;
    //�^�C�}�[�p�e�L�X�g
    [SerializeField] Text timerText;
    //�o�ߎ���
    float time;
    int remaining;

    bool _isPose;

    private void Start()
    {
        remaining = timeLimit - (int)time;
        timerText.text = $"�̂���:{remaining.ToString("D3")}";
    }

    void Update()
    {
        if (!_isPose)
        {
            //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
            time += Time.deltaTime;
            //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
            remaining = timeLimit - (int)time;
            //timerText���X�V���Ă���
            timerText.text = $"�̂���:{remaining.ToString("D3")}";

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
