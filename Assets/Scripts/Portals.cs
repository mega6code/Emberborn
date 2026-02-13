using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;

    public bool level1beat = false;
    public bool level2beat = false;



    private void Awake()
    {
        portal2.SetActive(false);
        portal3.SetActive(false);
    }

    private void Update()
    {
        if (level1beat == true)
        {
            portal2.SetActive(true);

        }

        if (level2beat == true)
        {
            portal3.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == portal1)
        {
            SceneManager.LoadScene("Wind Level");
            Debug.Log("Portal 1");
        }
        else if (other.gameObject == portal2)
        {
            SceneManager.LoadScene("Fire Level");
            Debug.Log("Portal 2");
        }
        else if (other.gameObject == portal3)
        {
            SceneManager.LoadScene("Ice Level");
            Debug.Log("Portal 3");
        }
    }
}
