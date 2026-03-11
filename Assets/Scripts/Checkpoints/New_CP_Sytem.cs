using UnityEngine;

public class New_CP_Sytem : MonoBehaviour
{
    [SerializeField] private Transform current_checkPoint;
    [SerializeField] private Transform target_checkPoint;

    [SerializeField] private Collider first_Collider;
    [SerializeField] private Collider second_Collider;
    [SerializeField] private Collider third_Collider;

    [SerializeField] private Transform checkPoint_1; //in the spawn
    [SerializeField] private Transform checkPoint_2; //after the 1st river
    [SerializeField] private Transform checkPoint_3; //before the bridge
    [SerializeField] private Transform checkPoint_4; //after the bridge

    void Start()
    {
        current_checkPoint = checkPoint_1;
        target_checkPoint = checkPoint_2;
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the player passed the 1st collider then i change the checkpoint
        if (other.gameObject.CompareTag("Animal"))
        {
            current_checkPoint = checkPoint_2; 
            target_checkPoint = checkPoint_3;
        }
    }
}
