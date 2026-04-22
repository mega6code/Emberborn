using UnityEngine;

public class MazeBarrier : MonoBehaviour
{
    [SerializeField] private GameObject mazeBarrier;

    [SerializeField] private GemsTrigger triggerCollider_pink;
    [SerializeField] private GemsTrigger triggerCollider_green;
    [SerializeField] private GemsTrigger triggerCollider_yellow;
    void Start()
    {
        if (mazeBarrier != null)
        {
            mazeBarrier.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerCollider_pink.wasTriggered && triggerCollider_green.wasTriggered && triggerCollider_yellow.wasTriggered)
        {
            mazeBarrier.SetActive(false);
        }
    }
}
