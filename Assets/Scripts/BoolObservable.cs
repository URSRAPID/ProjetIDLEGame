using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class BoolObservable : IObservable<bool>
{
    private List<IObserver<bool>> _observers;

    private bool _value;

    public BoolObservable(bool initValue)
    {
        _value = initValue;
        _observers = new List<IObserver<bool>>();
    }

   
    public IDisposable Subscribe(IObserver<bool> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }
    public bool GetValue()
    {
        return _value;
    }
    public void SetValue(bool newValue)
    {
        _value = newValue; 
        foreach (IObserver<bool> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }

}