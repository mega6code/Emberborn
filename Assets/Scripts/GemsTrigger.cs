using UnityEngine;

public class GemsTrigger : MonoBehaviour
{
    public bool wasTriggered = false;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            wasTriggered = true;
        }
    }
}
