using System;
using Emberborn.Elements;
using UnityEditor;
using UnityEngine;

public class DragonBreath : MonoBehaviour
{
    [SerializeField] private Transform breath_start;
    [SerializeField] private float ray_max_distance = 10;
    [SerializeField] private float p_element_strength = 0.1f;

    private PureElement pure_element;

    private void FireRay()
    {
        Ray ray = new Ray(breath_start.position, breath_start.forward);
        RaycastHit ray_hit;

        if( Physics.Raycast(ray, out ray_hit, ray_max_distance, LayerMask.GetMask("Water"), QueryTriggerInteraction.Collide) )
        {
            pure_element.ApplyElement(ray_hit.transform.gameObject, ray_hit.point);
        }
        else if (Physics.Raycast(ray, out ray_hit, ray_max_distance))
        {
            pure_element.ApplyElement(ray_hit.transform.gameObject, ray_hit.point);
        }
        
        //new Animator().
    }

    public void ActiveBreath(ElementalTypes type)
    {
        pure_element = new PureElement(type, this.p_element_strength);
        FireRay();
    }

    public void ActiveBreath(ElementalTypes type, float strength)
    {
        pure_element = new PureElement(type, strength);
        FireRay();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = pure_element?.elemental_type == ElementalTypes.Ice ? Color.blue :
            pure_element?.elemental_type == ElementalTypes.Fire ? Color.red : Color.purple;

        Gizmos.DrawLine(breath_start.position, (breath_start.position + breath_start.forward) * ray_max_distance);

    }
}
