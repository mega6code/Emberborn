using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{

    //THIS SCRIPT IS UNDER RECONSTRUCTION

    public GameObject thisPortal;

    public bool level1beat = false;
    public bool level2beat = false;



    private void Awake()
    {
        if (thisPortal.name == "Portal 1")
        {
            thisPortal.SetActive(true);
        }

        if (level1beat == true)
        {
            if (thisPortal.name == "Portal 2")
            {
                thisPortal.SetActive(true);

            }

        }
        else
        {
            thisPortal.SetActive(false);
        }

        if (level2beat == true)
        {
            if (thisPortal.name == "Portal 3")
            {
                thisPortal.SetActive(true);

            }

        }
        else
        {
            thisPortal.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {


           if (thisPortal.name == "Portal 2")
        {
            SceneManager.LoadScene("Final Level");
            Debug.Log("Portal 2");
        }
        //else if (thisPortal.name == "Portal 3")
        //{
        // SceneManager.LoadScene("");
        // Debug.Log("Portal 3");
        //}
    
    }
}
