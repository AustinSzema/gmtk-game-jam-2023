using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evt
{
    private event Action _action = delegate { };

    public void Invoke()
    {
        _action.Invoke();
    }

    public void AddListener(Action listener)
    {
        _action += listener;
    }

    public void RemoveListener(Action listener)
    {
        _action -= listener;
    }
}

public class Evt<T>
{
    private event Action<T> _action = delegate { };

    public void Invoke(T param)
    {
        _action.Invoke(param);
    }

    public void AddListener(Action<T> listener)
    {
        _action += listener;
    }

    public void RemoveListener(Action<T> listener)
    {
        _action -= listener;
    }
}

public class Evt<T, Y>
{
    private event Action<T, Y> _action = delegate { };

    public void Invoke(T param, Y param2)
    {
        _action.Invoke(param, param2);
    }

    public void AddListener(Action<T, Y> listener)
    {
        _action += listener;
    }

    public void RemoveListener(Action<T, Y> listener)
    {
        _action -= listener;
    }
}

public class Evt<T, Y, U>
{
    private event Action<T, Y, U> _action = delegate { };

    public void Invoke(T param, Y param2, U param3)
    {
        _action.Invoke(param, param2, param3);
    }

    public void AddListener(Action<T, Y, U> listener)
    {
        _action += listener;
    }

    public void RemoveListener(Action<T, Y, U> listener)
    {
        _action -= listener;
    }
}
