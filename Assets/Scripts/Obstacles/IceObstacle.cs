using System;
using Emberborn.Interfaces;
using TMPro;
using UnityEngine;

public class IceObstacle : MonoBehaviour, IObstacle, IFreezable, IFlammable
{
    [SerializeField] private Vector3 min_scale;
    [SerializeField] private Vector3 max_scale;
    [SerializeField] private float scale_rate; //
    private Vector3 default_scale;

    private void Awake()
    {
        defaultScale = transform.localScale;
    }

    private void Update()
    {
        Debug.Log(transform.localScale);
    }

    private void AddScale(Vector3 scale)
    {
        transform.localScale += scale;
    }

    private bool IsScaleOverMax(Vector3 scale)
    {
        if (scale.x >= max_scale.x || scale.y >= max_scale.y || scale.z >= max_scale.z)
        {
            return true;
        }
        
        return false;
    }

    private Vector3 CalculateScaleAmount()
    {
        transform.localScale ;
        if ()
        {
            
        }
        return defaultScale * 0.25f;
        
    }
    private void OnFreeze()
    {
        Vector3 scale_to_add = CalculateScaleAmount();
        AddScale(scale_to_add);
    }

    public void OnFire()
    {
        throw new NotImplementedException();
    }
}
