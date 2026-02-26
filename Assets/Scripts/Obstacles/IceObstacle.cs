using Emberborn.Interfaces;
using UnityEngine;

public class IceObstacle : MonoBehaviour, IObstacle, IFreezable
{

    private void Update()
    {
        Debug.Log(transform.localScale);
        Debug.Log(transform.lossyScale);
    }
    public void OnFreeze()
    {
        transform.localScale += (transform.localScale * 0.25f); 
    }
}
