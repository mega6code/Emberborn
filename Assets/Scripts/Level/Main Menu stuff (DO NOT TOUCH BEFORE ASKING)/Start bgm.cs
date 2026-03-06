using UnityEngine;

public class Startbgm : MonoBehaviour
{
    //doing this because I can't think of another way

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBGM()
    {
        audioSource.Play();
    }
}
