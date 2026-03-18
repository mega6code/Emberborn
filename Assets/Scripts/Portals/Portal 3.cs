using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal3 : Portals
{
    public GameObject player;

    private void Awake()
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
        if (other.gameObject == player)
        {
            BeatLevel(2);
            //SceneManager.LoadScene("");
            // Debug.Log("Portal 3");

        }
    }
}
