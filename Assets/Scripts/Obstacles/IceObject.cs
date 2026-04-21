using System;
using System.Collections.Generic;
using System.ComponentModel;
using Emberborn.Elements;
using Emberborn.Interfaces;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class IceObject : MonoBehaviour, IObstacle, IFreezable, IFlammable
{
    [Header("References")]
    [SerializeField] private ProgressiveScaler progressiveScaler;

    // In percentage from -100% to 100%
    [Header("Resistances")]
    [Range(-100, 100)]
    [SerializeField] private float freeze_resistance = 0;
    [Range(-100, 100)]
    [SerializeField] private float flamed_resistance = 0;

    [Header("Additional Cool Stuff It Can Do")]
    [SerializeField] private bool destroy_at_minimum = false;

    private void OnEnable()
    {
        progressiveScaler.minimumScaleReached += OnMinimumScaleReached;
    }

    private void OnDisable()
    {
        progressiveScaler.minimumScaleReached -= OnMinimumScaleReached;
    }

    private void OnMinimumScaleReached()
    {
        if (destroy_at_minimum)
        {
            Destroy(gameObject);
        }
    }
    private float CalculateResistance(float strength, float resistance)
    {
        if(resistance == 0)
        {
            return strength;
        }

        return strength - ( (freeze_resistance / 100) * strength );
    }
    public void OnFreeze(PureElementData message_objects)
    {
        progressiveScaler.ChangeTargetScale(CalculateResistance(message_objects.strength, freeze_resistance));
        Debug.Log("FREEEEZE!!!");
    }
    public void OnFire(PureElementData message_objects)
    {
        progressiveScaler.ChangeTargetScale(CalculateResistance(message_objects.strength, flamed_resistance));
        Debug.Log("FIIIRREEEEEEE!!!");
    }
}
