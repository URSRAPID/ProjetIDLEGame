using System;
using UnityEngine;

public class SpawnClientSpecial : MonoBehaviour , IObserver<bool>
{
    public float spawnDeltaTime = 2f;
    private float nextSpawn = 0.0f;
    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabClientSpecial;
    [SerializeField] public GameObject _spawnPointClient;
    [SerializeField] private GameObject _wayPointsClientSpecial;
    private bool _isActive;

    void Start()
    {
        nextSpawn = Time.time;
    }


    void Update()
    {
        if(_isActive)
        {
            ClientSpecial();
        }
        
    }

    private void ClientSpecial()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDeltaTime;
            whereToSpawn = new Vector2(_spawnPointClient.transform.position.x, _spawnPointClient.transform.position.y);
            GameObject clientSpecial = Instantiate(_spawnPrefabClientSpecial, whereToSpawn, Quaternion.identity);
            clientSpecial.GetComponent<ClientSpecialMove>().Init(_wayPointsClientSpecial);
        }
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(bool value)
    {
        _isActive = value;
    }
}
