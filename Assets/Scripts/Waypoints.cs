using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
    private List<GameObject> _waypointsLists;
    int current = 0;
    public float speed;
    float WPradius = 1;
    public bool stop;
    int randomlist;


    public void UpdateMove()
    {
        
        if (!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypointsLists[randomlist].transform.GetChild(current).transform.position, Time.deltaTime * speed);

            if (Vector3.Distance(_waypointsLists[randomlist].transform.GetChild(current).transform.position, transform.position) < WPradius)
            {

                current++;
                if (current >= _waypointsLists[randomlist].transform.childCount)
                {
                    stop = true;
                }

            }
            
        }
    }

    internal void Init(GameObject wayPointsToCafe, GameObject wayPointsToThe, GameObject wayPointsToJus, GameObject wayPointsToMilk, GameObject wayPointsToPatisserie)
    {
        _waypointsLists = new List<GameObject>();
        _waypointsLists.Add(wayPointsToCafe);
        _waypointsLists.Add(wayPointsToThe);
        _waypointsLists.Add(wayPointsToJus);
        _waypointsLists.Add(wayPointsToMilk);
        _waypointsLists.Add(wayPointsToPatisserie);
    }

    private void Start()
    {
        Debug.Log(randomlist);
        randomlist = Random.Range(0, 5);
    }
    void Update()
    {
        UpdateMove();

    }
}
