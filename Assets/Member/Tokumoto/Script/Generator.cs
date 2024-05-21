using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnObject());
    }
    
    IEnumerator SpawnObject()
    {
        while (true)
        {
            float randomX = Random.Range (-boxCollider2D.size.x, boxCollider2D.size.x) *.5f;
            float randomY = Random.Range (-boxCollider2D.size.y, boxCollider2D.size.y) *.5f;

            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);
            yield return new WaitForSeconds(spawnInterval);
        }
        }
}
