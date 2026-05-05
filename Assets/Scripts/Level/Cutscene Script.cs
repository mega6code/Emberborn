using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] AudioSource creditSong;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject player;
    public GameObject fakePlayer;
    public Animator set1;
    public Animator set2;
    public Animator set3;
    public CinemachineCamera daCamera;
    public GameObject oldCam;

    public static event Action KILLJOHN;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        KILLJOHN?.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        credits.SetActive(false);
        fakePlayer.SetActive(false);
        set1.SetBool("Paused", true);
        set2.SetBool("Paused", true);
        set3.SetBool("Paused", true);
    }

    void Credits()
    {
        creditSong.Play();
        credits.SetActive(true);
        Debug.Log("set1 animator: " + set1);
        set1.SetBool("Paused", false);
        Debug.Log("set2 animator: " + set2);
        set2.SetBool("Paused", false);
        Debug.Log("set3 animator: " + set3);
        set3.SetBool("Paused", false);
    }

    void Spawn()
    {
        fakePlayer.SetActive(true);
        oldCam.SetActive(false);
        daCamera.Follow = fakePlayer.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Spawn();
            Credits();
            player.SetActive(false);
            StartCoroutine(MouseTimer());
        }
    }

    IEnumerator MouseTimer()
    {
        yield return new WaitForSecondsRealtime(20.0f);
        Cursor.lockState = CursorLockMode.None;
    }
}
