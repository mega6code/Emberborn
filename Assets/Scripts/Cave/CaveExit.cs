using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveExit : MonoBehaviour
{
    /*public LoadingScreen loadingScreen;

    private void Start()
    {
        loadingScreen = GameManager.Instance.loadingScreen;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Animal")
        {
            loadingScreen.LoadScene(3);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            SceneManager.LoadScene("Ice Scene");
        }
    }
}
