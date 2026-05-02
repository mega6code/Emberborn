using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : Portals
{
    public GameObject player;
    public LoadingScreen loadingScreen;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            loadingScreen.LoadScene(1);//loads the forest level (1)
            Debug.Log("Portal 1");

        }
    }
}
