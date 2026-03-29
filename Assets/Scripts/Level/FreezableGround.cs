using Emberborn.Elements;
using Emberborn.Interfaces;
using UnityEngine;

public class FreezableGround : MonoBehaviour, IFreezable
{
    [SerializeField] private IceSpawner ice_spawner;
    public void OnFreeze(PureElementMessageObjects message_objects)
    {
        ice_spawner.SpawnIce(message_objects.point_of_collision);
    }
}
