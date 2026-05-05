using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal3 : Portals
{
    public GameObject player;
    public LoadingScreen loadingScreen;

    private void Start()
    {
        this.gameObject.SetActive(false);

        if (GameManager.Instance.Levelclears[1] == true)
        {
            this.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == player.tag)
        {
            BeatLevel(2);
            GameManager.Instance.GetComponent<LoadingScreen>().LoadScene(4);
            Debug.Log("Portal 3");

        }
    }
}
