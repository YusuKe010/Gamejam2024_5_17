using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float deleteTime = 10;

    [SerializeField] float _speedUpRate;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,deleteTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -speed * Time.deltaTime * (1 + _speedUpRate * LevelManager.Instance.Level), 0f);
    }
}
