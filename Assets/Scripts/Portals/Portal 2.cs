using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : Portals
{
    public GameObject player;
    public LoadingScreen loadingScreen;
    SceneManager sceneManager;

    private void Start()
    {
        this.gameObject.SetActive(false);

        if (gameObject.scene.buildIndex == 0)
        {
            this.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            BeatLevel(1);
            GameManager.Instance.GetComponent<LoadingScreen>().LoadScene(2);
            //loadingScreen.LoadScene(2);
            Debug.Log("Portal 2 used");
        }
    }
}
