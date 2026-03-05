using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal3 : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //SceneManager.LoadScene("");
            // Debug.Log("Portal 3");

        }
    }
}
