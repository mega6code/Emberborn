using Emberborn.Interfaces;
using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ice;
    [SerializeField] private Vector3 spawning_position_offset = Vector3.zero;
    public void SpawnIce(Vector3 point)
    {
        Instantiate(ice, (point + spawning_position_offset), ice.transform.rotation);
    }
}
