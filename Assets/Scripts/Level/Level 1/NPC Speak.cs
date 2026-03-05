using Unity.VisualScripting;
using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject player;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            if (other.gameObject == player)
            {
                audioSource.Play();
            }
        }
    }
}
