using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VendeursView : MonoBehaviour
{

    [SerializeField] Animator _animatorPort; 
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

    internal void OpenPort()
    {
        if (_animatorPort != null)
        {
            _animatorPort.SetBool("IsDoorOpen", true);
        }
    }

   

}

