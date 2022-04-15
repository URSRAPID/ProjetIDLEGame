using System;
using UnityEngine;

public class ClientMove : MonoBehaviour
{
    public bool stop;
    [SerializeField] Animator _animator;

    internal void Stop()
    {
        stop = true;
        if (_animator != null)
        {
            _animator.SetBool("Idle_Dos", true);
        }
    }
    internal void Start()
    {
        stop = false;
        if (_animator != null)
        {
            _animator.SetBool("Idle_Dos", false);
        }
    }
}