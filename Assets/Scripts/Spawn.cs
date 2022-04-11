using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject _spawn;
    public GameObject _spawnPrefab;
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
            whereToSpawn = new Vector2(_spawn.transform.position.x, _spawn.transform.position.y);
            Instantiate(_spawnPrefab, whereToSpawn, Quaternion.identity);


        }
    }

    private void OnMouseDown()
    {
        
    }
}
