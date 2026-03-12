using System;
using System.Collections.Generic;
using Emberborn.Interfaces;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IceObstacle : MonoBehaviour, IObstacle, IFreezable, IFlammable
{
    [SerializeField] private UnityEvent<float> Frozen;
    [SerializeField] private UnityEvent<float> Flamed;

    public void OnFreeze(object o)
    {
        Frozen?.Invoke((float)o);
        Debug.Log("FREEEEZE!!!");
    }

    public void OnFire(object o)
    {
        Flamed?.Invoke((float)o);
        Debug.Log("FIIIRREEEEEEE!!!");
    }
}
