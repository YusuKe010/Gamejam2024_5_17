using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed = 0.1f;
    public float deleteTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,deleteTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -speed * 0.001f, 0f);
    }
}
