using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _wayPointsToCafe;
    [SerializeField] private GameObject _wayPointsToThe;
    [SerializeField] private GameObject _wayPointsToJus;
    [SerializeField] private GameObject _wayPointsToMilk;
    [SerializeField] private GameObject _wayPointsToPatisserie;

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
            GameObject client = Instantiate(_spawnPrefab, whereToSpawn, Quaternion.identity);
            client.GetComponent<Waypoints>().Init(_wayPointsToCafe, _wayPointsToThe, _wayPointsToJus, _wayPointsToMilk, _wayPointsToPatisserie);
            

        }
    }

    private void OnMouseDown()
    {
        
    }
}
