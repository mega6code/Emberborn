using UnityEngine;
using UnityEngine.SceneManagement;

public class ClutterManagement : MonoBehaviour
{
    public GameObject levelUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.scene.name == "Main Menu")
        {
            levelUI.SetActive(false);
        }
        else
        {
            levelUI.SetActive(true);
        }
    }
}
