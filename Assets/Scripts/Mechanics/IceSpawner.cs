using Emberborn.Interfaces;
using UnityEngine;

public class IceSpawner : MonoBehaviour, IFreezable
{
    [SerializeField] private GameObject ice;
    public void SpawnIce()
    {
        Instantiate(ice);
    }
    public void OnFreeze(object o)
    {
        
    }
}
