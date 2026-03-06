using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal3 : Portals
{
    public GameObject player;

    private void Awake()
    {
       if (GameManager.Instance.Levelclears[1] == false)
        {
            this.gameObject.SetActive(false);
        } 
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
