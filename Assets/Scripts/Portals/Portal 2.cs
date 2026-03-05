using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
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
            SceneManager.LoadScene("Final Level");
            Debug.Log("Portal 2");

        }
    }
}
