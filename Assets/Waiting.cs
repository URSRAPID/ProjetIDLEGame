using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waiting : MonoBehaviour
{
    UnityEvent<Waypoints> _onEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddListener(UnityAction<Waypoints> method)
    {
        if (_onEnter == null)
        {
            _onEnter = new UnityEvent<Waypoints>();
        }
        _onEnter.AddListener(method);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if (collision.transform.CompareTag("Player"))
        {
            _onEnter.Invoke(collision.GetComponent<Waypoints>());
            
        }
    }
}
