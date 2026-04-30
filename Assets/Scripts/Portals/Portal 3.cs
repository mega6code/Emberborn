using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal3 : Portals
{
    public GameObject player;
    public LoadingScreen loadingScreen;
    public GameObject vfxPortal;

    private void Awake()
    {
        this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            BeatLevel(2);
            loadingScreen.LoadScene(4);
            Debug.Log("Portal 3");

        }
    }
}
