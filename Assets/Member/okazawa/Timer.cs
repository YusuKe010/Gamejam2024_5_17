using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI�𑀍삷��̂ŋL�q
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //��������
    [SerializeField] int timeLimit;
    //�^�C�}�[�p�e�L�X�g
    [SerializeField] Text timerText;
    //�o�ߎ���
    float time;



    void Update()
    {
        //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
        int remaining = timeLimit - (int)time;
        //timerText���X�V���Ă���
        timerText.text = $"�̂���:{remaining.ToString("D3")}";
    }
}
