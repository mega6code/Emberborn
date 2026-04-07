using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject player;
    public GameObject textbox;
    public GameObject subtitles1;
    public GameObject subtitles2;
    public GameObject subtitles3;

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
                StartCoroutine(Subtitles());
            }
        }
    }

    IEnumerator Subtitles()
    {

        if (subtitles1 != null)
        {
            textbox.SetActive(true);
            subtitles1.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            subtitles1.SetActive(false);

            if (subtitles2 != null)
            {
                subtitles2.SetActive(true);
                yield return new WaitForSeconds(5.0f);
                subtitles2.SetActive(false);

                if (subtitles3 != null)
                {
                    subtitles3.SetActive(true);
                    yield return new WaitForSeconds(5.0f);
                    subtitles3.SetActive(false);
                }
            }    
            textbox.SetActive(false);
        }
    }
}
