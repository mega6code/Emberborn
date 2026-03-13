using UnityEngine;
using UnityEngine.UIElements;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField] private Transform checkPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            player.TeleportTo(checkPoint.position);
        }
    }

}
