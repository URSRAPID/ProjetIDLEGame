using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpecialMove : ClientMove
{
    private List<GameObject> _waypointsListsClientSpecial;
    int current = 0;
    public float speed = 3.5f;
    float WPradius = 1;
   
    int randomlist;
    public float GetSpeedClientSpecial()
    {
        return speed;
    }

    public void AddSpeedClientSpecial(float speedSpecial)
    {
        speed = speedSpecial;
    }


    public void UpdateMoveClientSpecial()
    {


        if (!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypointsListsClientSpecial[randomlist].transform.GetChild(current).transform.position, Time.deltaTime * speed);

            if (Vector3.Distance(_waypointsListsClientSpecial[randomlist].transform.GetChild(current).transform.position, transform.position) < WPradius)
            {

                current++;
                if (current >= _waypointsListsClientSpecial[randomlist].transform.childCount)
                {
                    stop = true;
                }

            }

        }
    }

    internal void Init(GameObject WaypointsClientSpecial)
    {
        _waypointsListsClientSpecial = new List<GameObject>();
        _waypointsListsClientSpecial.Add(WaypointsClientSpecial);
       
    }

    private void Start()
    {
        randomlist = Random.Range(0, 1);
    }
    void Update()
    {
        UpdateMoveClientSpecial();

    }

   
}
