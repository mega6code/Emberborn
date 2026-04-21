using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [SerializeField] private Transform start;
    [SerializeField] private float distance = 100f;
    [SerializeField] private LayerMask validLayers;
    [SerializeField] private bool hitTriggerColliders = false;
    [SerializeField] private Color gizmosColor;

    private Ray ray;
    private QueryTriggerInteraction queryTriggerInteraction;

    private bool GetRaycastTarget(out RaycastHit hit)
    {
        ray = new Ray(start.position, start.forward);

        if (hitTriggerColliders)
        {
            queryTriggerInteraction = QueryTriggerInteraction.Collide;
        }
        else 
        {
            queryTriggerInteraction = QueryTriggerInteraction.Ignore;
        }

        return Physics.Raycast(ray, out hit, distance, validLayers, queryTriggerInteraction);
    }

    //float distance = 100f, Transform start, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore

    public bool FireRay(out RaycastHit hit)
    {
        if (GetRaycastTarget(out hit))
        {
            Debug.Log("hit: " + hit.collider.name);
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;

        if(GetRaycastTarget(out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point, 0.25f);
        }
        Gizmos.DrawRay(ray);
    }
}
