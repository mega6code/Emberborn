using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    private AudioSource audioSource; 
    public GameObject player; // the dragon prefab 
    public GameObject textbox; // the textbox object in game manager
    public GameObject subtitles1; // the --- Dialogue 1 of the corresponding npc
    public GameObject subtitles2; // same as above but dialogue 2 (optional)
    public GameObject subtitles3; // same as above but dialogue 3 (optional)
    public float textTime1 = 1.0f;
    public float textTime2 = 1.0f;
    public float textTime3 = 1.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            // if player gets close enough, play audio and start subtitles
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
            yield return new WaitForSeconds(textTime1);
            subtitles1.SetActive(false);

            if (subtitles2 != null)
            {
                subtitles2.SetActive(true);
                yield return new WaitForSeconds(textTime2);
                subtitles2.SetActive(false);

                if (subtitles3 != null)
                {
                    subtitles3.SetActive(true);
                    yield return new WaitForSeconds(textTime3);
                    subtitles3.SetActive(false);
                }
            }    
            textbox.SetActive(false);
        }
    }
}
