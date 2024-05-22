using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float deleteTime = 10;

    [SerializeField] float _speedUpRate;

    void Update()
    {
        transform.Translate(0f, -speed * Time.deltaTime * (1 + _speedUpRate * LevelManager.Instance.Level), 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance.LevelUp(1);
            SceneChanger.Instance.SceneChange("InGame");
        }
    }
}
