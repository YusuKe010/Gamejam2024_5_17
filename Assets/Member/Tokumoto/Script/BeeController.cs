using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public float speed;
    public float moveRange = 5f;
    public float xmovespeed = 1f;
    public float nowPosi;

    public float deleteTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        nowPosi = transform.position.x;
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(nowPosi + Mathf.PingPong(Time.time * xmovespeed, moveRange), transform.position.y, transform.position.z);
        transform.Translate(0f, -speed * 0.001f, 0f);
    }
}
