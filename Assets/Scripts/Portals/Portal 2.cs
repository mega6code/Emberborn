using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : Portals
{
    public GameObject player;

    private void Awake()
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
            SceneManager.LoadScene("Cave Scene");
            Debug.Log("Portal 2");
        }
    }
}
