using UnityEngine;

public class MazeBarrier : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private GameObject mazeBarrier;

    [SerializeField] private GemsTrigger triggerCollider_pink;
    [SerializeField] private GemsTrigger triggerCollider_green;
    [SerializeField] private GemsTrigger triggerCollider_yellow;
    [SerializeField] public GameObject portal;
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
            Portal();
        }
    }

    void Portal()
    {
        if (portal != null)
        {
            portal.SetActive(true);
            audio.Play();
        }
    }
}
