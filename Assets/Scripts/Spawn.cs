using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject _spawn;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    float x;
    float y;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            x = 2;
            y = 2;
            whereToSpawn = new Vector2(x, y);
            Instantiate(_spawn, whereToSpawn, Quaternion.identity);


        }
    }
}
