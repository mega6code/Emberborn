using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [SerializeField] private LayerMask validLayers;

    public RaycastHit GetRaycastTarget(Ray ray, float distance)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, validLayers))
        {
            return hit;
        }

        return hit;
    }



    public RaycastHit FireShot(float distance = 100f)
    {
        Vector3 startingPosition = this.transform.position;
        Ray ray = new Ray(startingPosition, transform.forward);
        RaycastHit hit = GetRaycastTarget(ray, distance);

        if (hit.collider != null)
        {
            Debug.Log("hit: " + hit.collider.name);
        }

        return hit;
    }

    private void OnDrawGizmos()
    {
        Vector3 startingPosition = this.transform.position;
        Ray ray = new Ray(startingPosition, transform.forward);
        RaycastHit hit = GetRaycastTarget(ray, 100f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(startingPosition, transform.forward * 100f);
        Gizmos.DrawSphere(hit.point, 0.25f);
    }
}
