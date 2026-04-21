using System;
using Emberborn.Elements;
using UnityEditor;
using UnityEngine;

public class DragonBreath : MonoBehaviour
{
    [SerializeField] private Raycaster raycaster;
    [SerializeField] private PureElement pureElement;
    
    public event Action dragonBreathActivated;

    private void FireRay()
    {
        if (raycaster.FireRay(out RaycastHit hit))
        {
            pureElement.ApplyElement(hit.transform.gameObject, hit.point);
        }
    }

    public void ActivateBreath(ElementalTypes type)
    {
        dragonBreathActivated?.Invoke();
        
        pureElement.elemental_type = type;
        FireRay();
    }
}
