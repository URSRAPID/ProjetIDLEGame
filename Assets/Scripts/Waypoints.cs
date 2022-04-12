using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List <GameObject> _waypointsList1;
    public List<GameObject> _waypointsList2;
    public List<GameObject> _waypointsList3;
    public List<GameObject> _waypointsList4;
    public List<GameObject> _waypointsList5;

    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    public bool stop;

    

    private void Start()
    {
        

    }
    void Update()
    {
        if (!stop)
        {
            if (Vector3.Distance(_waypointsList1[current].transform.position, transform.position) < WPradius)
            {

                current++;

            }
            transform.position = Vector3.MoveTowards(transform.position, _waypointsList1[current].transform.position, Time.deltaTime * speed);
        }
    }
}
