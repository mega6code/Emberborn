using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    public string scene;

    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Portal works");
            SceneManager.LoadScene(scene);
        }
    }
}
