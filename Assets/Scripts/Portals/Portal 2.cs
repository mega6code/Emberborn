using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : Portals
{
    public GameObject player;
    public LoadingScreen loadingScreen;

    private void Start()
    {
        this.gameObject.SetActive(false);

        if (GameManager.Instance.Levelclears[0] == true)
        {
            this.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            BeatLevel(1);
            loadingScreen.LoadScene(2);
            Debug.Log("Portal 2 used");
        }
    }
}
