using UnityEngine;
using UnityEngine.UIElements;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private Transform checkPoint;

    /*
    //if there is a collision in the triggered area
    //if its the player colliding
    //move th eplayer position to the check point position

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Debug.Log(other.gameObject.name);
            player.transform.position = checkPoint.position;
            
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            player.TeleportTo(checkPoint.position);
        }
    }

}
