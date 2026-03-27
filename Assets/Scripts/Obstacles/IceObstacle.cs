using System;
using System.Collections.Generic;
using Emberborn.Elements;
using Emberborn.Interfaces;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IceObstacle : MonoBehaviour, IObstacle, IFreezable, IFlammable
{
    [SerializeField] private UnityEvent<float> Frozen;
    [SerializeField] private UnityEvent<float> Flamed;

    public void OnFreeze(PureElementMessageObjects message_objects)
    {
        Frozen?.Invoke(message_objects.strength);
        Debug.Log("FREEEEZE!!!");
    }

    public void OnFire(PureElementMessageObjects message_objects)
    {
        Flamed?.Invoke(message_objects.strength);
        Debug.Log("FIIIRREEEEEEE!!!");
    }
}
