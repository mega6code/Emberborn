using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;

public class Moving_plaftorms : MonoBehaviour
{

    [SerializeField] GameObject MovingPlatform;

    [SerializeField] Transform point_1;
    [SerializeField] Transform point_2;

    [SerializeField] Transform targetPoint;

    [SerializeField] float platformSpeed = 5f;

    private Vector3 lastPosition;
    private PlayerController player;

    void Start()
    {
        targetPoint = point_1;    
    }

        //go to to point 1 -> is in point1 = true
        //if is In point 1 is true...
        //go to point 2 -> is in point2 = true
        //if is In poin2 1 is true..
        //go to to point 1
        //...
        //if the player collides, on collision Exit, the grativi is true and the platfrom falls and is inactive

    void Update()
    {
        //save current position before moving
        Vector3 oldPosition = transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, platformSpeed * Time.deltaTime);
        //if the MovingPlatform isat a certain distance from the target point, we switch the other point to be the target

        if (Vector3.Distance(transform.position, targetPoint.position) < 2f)
        {
            targetPoint = point_2;

            if (Vector3.Distance(transform.position, targetPoint.position) < 2f)
            {
                targetPoint = point_1;
            }
        }

        //calculate how much platform moved this frame
        Vector3 platformDelta = transform.position - oldPosition;

        //move player with platform if player is standing on it
        if (player != null)
        {
            player.OnPlatform(platformDelta);
        }

        lastPosition = transform.position;

    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();
        //player.OnPlatform(this.transform.position);
        //transform.SetParent(other.transform);
        //other.transform.SetParent(this.transform);
        if (player != null)
        {
            this.player = player;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //other.transform.SetParent(null);

        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null && this.player == player)
        {
            this.player = null;
        }

    }

}
