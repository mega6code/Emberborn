using UnityEngine;

public class DragonBreath : MonoBehaviour
{
    [SerializeField] private Transform breath_start;
    [SerializeField] private float ray_max_distance = 10;

    private void Start()
    {
        if(breath_start == null)
        {
            breath_start = transform;
        }
    }
    private void Update()
    {

        Ray ray = new Ray(breath_start.position, breath_start.forward);
        RaycastHit ray_hit;

        if( Physics.Raycast(ray, out ray_hit, ray_max_distance) )
        {
            ray_hit.transform.BroadcastMessage("");
        }

    }
}
