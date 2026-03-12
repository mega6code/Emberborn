using UnityEngine;

public class PlatformParenting : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            player.transform.SetParent(null);
        }
    }
}
