
using System;
using System.Collections.Generic;

public class FloatObservable : IObservable<float>
{
    private List<IObserver<float>> _observers;

    private float _value;

    public FloatObservable(float initValue)
    {
        _value = initValue;
        _observers = new List<IObserver<float>>();
    }

    public void Add(float deltaValue)
    {
        _value += deltaValue;
        foreach (IObserver<float> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }

    public IDisposable Subscribe(IObserver<float> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }
    public float GetValue()
    {
        return _value;
    }
}
