using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveExit : MonoBehaviour
{
    public LoadingScreen loadingScreen;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Animal")
        {
            loadingScreen.LoadScene(3);
        }
    }
}
