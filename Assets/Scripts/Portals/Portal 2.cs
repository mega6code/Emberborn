using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : Portals
{
    public GameObject player;

    private void Awake()
    {
        if (GameManager.Instance.Levelclears[0] == false)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            BeatLevel(1);
            SceneManager.LoadScene("Final Level");
            Debug.Log("Portal 2");

        }
    }
}
