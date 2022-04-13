using UnityEngine;

public class SpawnClientSpecial : MonoBehaviour
{
    public float spawnRate = 2f;
    private float nextSpawn = 0.0f;
    Vector2 whereToSpawn;
    [SerializeField] public GameObject _spawnPrefabClientSpecial;
    [SerializeField] public GameObject _spawnPointClient;
    [SerializeField] private GameObject _wayPointsClientSpecial;
    bool OffSpawn;

    void Start()
    {

    }


    void Update()
    {
        ClientSpecial();
    }

    private void ClientSpecial()
    {
        if (!OffSpawn)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time * spawnRate;
                whereToSpawn = new Vector2(_spawnPointClient.transform.position.x, _spawnPointClient.transform.position.y);
                GameObject clientSpecial = Instantiate(_spawnPrefabClientSpecial, whereToSpawn, Quaternion.identity);
                clientSpecial.GetComponent<ClientSpecialMove>().Init(_wayPointsClientSpecial);
            }
        }

    }
}
