using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMoveStandard : ClientMove

{
    
    private List<GameObject> _waypointsLists;
    [SerializeField] Animator _animator;
    int current = 0;
    public float _speed;
    float WPradius = 1;
   
    int randomlist;

    public float GetSpeedClientStandardl()
    {
        return _speed;
    }

    public void AddSpeedClientStandard(float speedSpecial)
    {
        _speed += speedSpecial;
    }

    public void UpdateMove()
    {
        
        if (!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypointsLists[randomlist].transform.GetChild(current).transform.position, Time.deltaTime * _speed);

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

    internal void Init(float speed , GameObject wayPointsToCafe, GameObject wayPointsToThe, GameObject wayPointsToJus, GameObject wayPointsToMilk, GameObject wayPointsToPatisserie)
    {
        _waypointsLists = new List<GameObject>();
        _waypointsLists.Add(wayPointsToCafe);
        _waypointsLists.Add(wayPointsToThe);
        _waypointsLists.Add(wayPointsToJus);
        _waypointsLists.Add(wayPointsToMilk);
        _waypointsLists.Add(wayPointsToPatisserie);
        _speed = speed;
    }

    private void Start()
    {
        randomlist = Random.Range(0, 5);
    }
    void Update()
    {
        UpdateMove();

    }

   
}
