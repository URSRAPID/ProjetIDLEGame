using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VendeursView : MonoBehaviour
{

    UnityEvent _eventOnClic;

    public void AddListener(UnityAction method)
    {
        if (_eventOnClic == null)
        {
            _eventOnClic = new UnityEvent();
        }
        _eventOnClic.AddListener(method);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        _eventOnClic.Invoke();
    }

}

